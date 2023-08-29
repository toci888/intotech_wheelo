using System.Collections.Concurrent;
using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Chat.Jaguar;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Microsoft.AspNetCore.SignalR;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Intotech.Wheelo.Chat.Api.Attributes;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Models.Gaf;
using AutoMapper.Execution;
using Intotech.Wheelo.Common.Interfaces.CachingService;

namespace Intotech.Wheelo.Chat.Api.Hubs
{
    public class ChatHub : Hub
    {
        private const string ClientReceiveMessageCallback = "getMessage";
        private const string RoomEstablished = "RoomEstablished";
        private const string ClientAddUserCallback = "session";
        private const string InviteToConversationCallback = "InviteToConversation";
        private const string RoomIdPattern = "{0}_RoomIdText";

        private static readonly ConcurrentDictionary<string, string> _connectedUsers =
            new ConcurrentDictionary<string, string>();

        protected IChatUserService ChatUserService;
        protected IRoomService RoomService;
        protected ICachingService CachingService;
        protected IChatNotificationsService ChatNotificationsService;

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _connectedUsers.TryRemove(Context.ConnectionId, out string userId);

            await base.OnDisconnectedAsync(exception);
        }

        public ChatHub(IChatUserService chatUser, IRoomService roomService, ICachingService cachingService,
            IChatNotificationsService chatNotificationsService)
        {
            ChatUserService = chatUser;
            RoomService = roomService;
            CachingService = cachingService;
            ChatNotificationsService = chatNotificationsService;
        }


        [Authorize(Roles = "User")]
        public async Task ConnectUser(int idAccount) // accountId room for synchronizations
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
                await Groups.AddToGroupAsync(Context.ConnectionId, userRoomId.ToString());
            }

            await this.Clients.User(Context.UserIdentifier).SendAsync(ClientAddUserCallback, new { data });
        }

        [Authorize(Roles = "User")]
        public async Task<RoomsDto> CreateRoom(int idAccount, List<int> remainingAccountIds) // TODO KACPER DOC
        {

            RoomsDto room = RoomService.CreateRoom(idAccount, remainingAccountIds);

            foreach (RoomMembersDto member in room.RoomMembers)
            {
                Clients.User(member.Email).SendAsync(RoomEstablished, new { room });
            }

            return room;
        }

        [Authorize(Roles = "User")]
        public virtual async Task JoinRoom(string roomId) // TODO KACPER DOC
        {
            RoomService.ApproveRoom(roomId, Context.UserIdentifier, true);

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        [Authorize(Roles = "User")]
        public async Task<ChatMessageDto> SendMessage(LiveChatMessageDto chatMessage)
        {
            chatMessage.SenderEmail = Context.UserIdentifier;
            chatMessage = ChatUserService.SendMessage(chatMessage);

            if (chatMessage != null)
            {
                //await Groups.AddToGroupAsync(Context.ConnectionId, chatMessage.ID.ToString());
                //await Clients.OthersInGroup(chatMessage.RoomId).SendAsync(ClientReceiveMessageCallback, new { chatMessage });
                try
                {
                    await Clients.Group(chatMessage.RoomId).SendAsync(ClientReceiveMessageCallback, new { chatMessage });
                    //await Clients.User(Context.UserIdentifier).SendAsync(ClientReceiveMessageCallback, new { chatMessage });
                    ChatNotificationsService.SendChatNotifications(chatMessage.RoomId, chatMessage.SenderEmail, chatMessage, _connectedUsers);
                }
                catch (Exception ex)
                {

                }
            }                                                            //roomid

            return chatMessage;
        }

    }
}
