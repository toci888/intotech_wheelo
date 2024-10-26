using System.Collections.Concurrent;
using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Api.Hubs
{
    public class ChatHub : Hub
    {
        private const string ClientReceiveMessageCallback = "getMessage";
        private const string RoomEstablished = "RoomEstablished";
        private const string ClientAddUserCallback = "session";
        private const string TypingCallback = "userTyping";
        private const string StopTypingCallback = "stopTyping";
        private static readonly ConcurrentDictionary<string, string> _connectedUsers = new ConcurrentDictionary<string, string>();

        protected IChatUserService ChatUserService;
        protected IRoomService RoomService;
        protected IChatNotificationsService ChatNotificationsService;

        public ChatHub(IChatUserService chatUser, IRoomService roomService, IChatNotificationsService chatNotificationsService)
        {
            ChatUserService = chatUser;
            RoomService = roomService;
            ChatNotificationsService = chatNotificationsService;
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _connectedUsers.TryRemove(Context.ConnectionId, out string userId);
            await base.OnDisconnectedAsync(exception);
        }

        [Authorize(Roles = "User")]
        public async Task ConnectUser(int idAccount)
        {
            ChatUserDto data = ChatUserService.Connect(idAccount);
            if (data == null)
            {
                await Clients.Caller.SendAsync("connect_error", "Invalid userId");
                return;
            }
            data.SessionId = Context.UserIdentifier;
            _connectedUsers.TryAdd(Context.ConnectionId, Context.UserIdentifier);
            List<string> userRoomIds = RoomService.GetAllRooms(Context.UserIdentifier);
            foreach (string userRoomId in userRoomIds)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, userRoomId);
            }
            await Clients.User(Context.UserIdentifier).SendAsync(ClientAddUserCallback, new { data });
        }

        [Authorize(Roles = "User")]
        public async Task<RoomsDto> CreateRoom(int idAccount, List<int> remainingAccountIds)
        {
            RoomsDto room = RoomService.CreateRoom(idAccount, remainingAccountIds);
            foreach (RoomMembersDto member in room.RoomMembers)
            {
                await Clients.User(member.Email).SendAsync(RoomEstablished, new { room });
            }
            return room;
        }

        [Authorize(Roles = "User")]
        public async Task JoinRoom(string roomId)
        {
            RoomService.ApproveRoom(roomId, Context.UserIdentifier, true);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            // Fetch previous messages when joining the room
            var messages = await ChatUserService.GetMessagesForRoom(roomId);
            await Clients.Caller.SendAsync("loadMessages", messages);
        }

        [Authorize(Roles = "User")]
        public async Task<ChatMessageDto> SendMessage(LiveChatMessageDto chatMessage)
        {
            chatMessage.SenderEmail = Context.UserIdentifier;
            chatMessage = ChatUserService.SendMessage(chatMessage);
            if (chatMessage != null)
            {
                await Clients.Group(chatMessage.RoomId).SendAsync(ClientReceiveMessageCallback, new { chatMessage });
                ChatNotificationsService.SendChatNotifications(chatMessage.RoomId, chatMessage.SenderEmail, chatMessage, _connectedUsers);
            }
            return chatMessage;
        }

        [Authorize(Roles = "User")]
        public async Task Typing(string roomId)
        {
            await Clients.OthersInGroup(roomId).SendAsync(TypingCallback, Context.UserIdentifier);
        }

        [Authorize(Roles = "User")]
        public async Task StopTyping(string roomId)
        {
            await Clients.OthersInGroup(roomId).SendAsync(StopTypingCallback, Context.UserIdentifier);
        }

        // Additional methods for file uploads, message history, etc., can be added here
    }
}