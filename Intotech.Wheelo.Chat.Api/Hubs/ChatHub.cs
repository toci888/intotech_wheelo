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

        protected IChatUserService ChatUserService;
        protected IRoomService RoomService;
        protected ICachingService CachingService;
        protected IChatNotificationsService ChatNotificationsService;

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

            List<int> userRoomIds = RoomService.GetAllRooms(Context.UserIdentifier);

            foreach (int userRoomId in userRoomIds)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, userRoomId.ToString());
            }

            await this.Clients.User(Context.UserIdentifier).SendAsync(ClientAddUserCallback, new { data });
        }

        [Authorize(Roles = "User")]
        public async Task CreateRoom(string hostEmail, List<string> members)
        {

            RoomsDto room = RoomService.CreateRoom(hostEmail, members);

            foreach (RoomMembersDto member in room.RoomMembers)
            {
                Clients.User(member.Email).SendAsync(RoomEstablished, new { room });
            }
        }

        [Authorize(Roles = "User")]
        public virtual async Task JoinRoom(int roomId)
        {
            RoomService.ApproveRoom(roomId, Context.UserIdentifier, true);

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        [Authorize(Roles = "User")]
        public async Task SendMessage(ChatMessageDto chatMessage)
        {
            chatMessage = ChatUserService.SendMessage(chatMessage);

            if (chatMessage != null)
            {
                //await Groups.AddToGroupAsync(Context.ConnectionId, chatMessage.ID.ToString());
                await Clients.OthersInGroup(chatMessage.ID.ToString()).SendAsync(ClientReceiveMessageCallback, new { chatMessage });

                ChatNotificationsService.SendChatNotifications(chatMessage.ID, chatMessage.SenderEmail, chatMessage);
            }

        }
        
    }
}
