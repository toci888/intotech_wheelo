using Intotech.Common;
using Intotech.Wheelo.Chat.Api.Logic;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
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
        private const string InviteToConversation = "InviteToConversation";
        private const string UserOwnIdPattern = "accountId: {0} random ending";
        private const string UsersRoomIdPattern = "{0}_{1}";

        protected ChatLogic ChatLogic;
        protected IChatUserService ChatUser;

        public ChatHub(ChatLogic chatLogic, IChatUserService chatUser)
        {
            ChatLogic = chatLogic;
            ChatUser = chatUser;
        }

        public async Task ConnectUser(int accountId)
        {
            ChatUserDto user = ChatUser.Connect(accountId);

            string roomId = HashGenerator.Md5(string.Format(UserOwnIdPattern, accountId));

            await JoinRoom(roomId);

            ChatUser.JoinRoom(accountId, roomId);

            await Clients.Group(roomId).SendAsync(ClientAddUserCallback, roomId);
        }

        public async Task RequestConversation(RequestConversationDto requestConversation)
        {
            string invitedUserId = HashGenerator.Md5(string.Format(UserOwnIdPattern, requestConversation.InvitedAccountId, requestConversation.InvitedUserName));

            await Clients.Group(invitedUserId).SendAsync(InviteToConversation, requestConversation.InvitingAccountId, requestConversation.InvitingUserName); 
        }

        public async Task SendMessage(ChatMessageDto chatMessage)
        {
            await Clients.Group(chatMessage.RoomName).SendAsync(ClientReceiveMessageCallback, chatMessage);

            chatMessage.RoomId = 8;

            ChatLogic.SendMessage(chatMessage);
        }

        protected virtual async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }
    }
}
