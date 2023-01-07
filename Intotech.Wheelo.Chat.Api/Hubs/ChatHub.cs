using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Chat.Jaguar;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Microsoft.AspNetCore.SignalR;
using System.Xml.Linq;

namespace Intotech.Wheelo.Chat.Api.Hubs
{
    public class ChatHub : Hub
    {
        private const string ClientReceiveMessageCallback = "ReceiveMessage";
        private const string ClientAddUserCallback = "AddUser";
        private const string InviteToConversationCallback = "InviteToConversation";
        private const string RoomIdPattern = "{0}_RoomIdText";

        protected IChatUserService ChatUserService;
        protected IRoomService RoomService;

        public ChatHub(IChatUserService chatUser, IRoomService roomService)
        {
            ChatUserService = chatUser;
            RoomService = roomService;
        }

        public async Task ConnectUser(int accountId) // accountId room for synchronizations
        {
            ChatUserDto user = ChatUserService.Connect(accountId);

            RoomsDto result = RoomService.CreateRoom(accountId, new List<int>());

            await JoinRoom(result.RoomId);

            ChatUserService.JoinRoom(accountId, 1);

            user.RoomId = result.IdRoom;

            await Clients.Group(result.RoomId).SendAsync(ClientAddUserCallback, user);
        }

        public async Task RequestConversation(RequestConversationDto requestConversation)
        {
            requestConversation = ChatUserService.Invite(requestConversation);

            if (!requestConversation.IsInvited)
            {
                foreach (int accountId in requestConversation.InvitedAccountIds)
                {
                    string invitedUserId = string.Format(RoomIdPattern, accountId);

                    await Clients.Group(invitedUserId).SendAsync(InviteToConversationCallback, requestConversation);
                }
            }
        }

        public async Task ApproveChat(int ownerId, List<int> participantsIds)
        {
            RoomsDto result = RoomService.CreateRoom(ownerId, participantsIds);

            await JoinRoom(result.IdRoom);
        }

        public async Task SendMessage(ChatMessageDto chatMessage)
        {
            chatMessage = ChatUserService.SendMessage(chatMessage);

            await Clients.Group(chatMessage.ID.ToString()).SendAsync(ClientReceiveMessageCallback, chatMessage);
           
        }

        protected virtual async Task JoinRoom(int roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        protected virtual async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }
    }
}
