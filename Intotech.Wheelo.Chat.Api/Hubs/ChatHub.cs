using Intotech.Common;
using Intotech.Wheelo.Chat.Api.Logic;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
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
        private const string UserOwnIdPattern = "accountId: {0}, accountName: {1} random ending";

        protected ChatLogic ChatLogic;

        public ChatHub(ChatLogic chatLogic)
        {
            ChatLogic = chatLogic;
        }

        public async Task ConnectUser(string accountId, string userName)
        {
            string userId = HashGenerator.Md5(string.Format(UserOwnIdPattern, accountId, userName));

            await JoinRoom(userId);

            //TODO save id to db

            await Clients.Group(userId).SendAsync(ClientAddUserCallback, userId);
        }

        public async Task RequestConversation(RequestConversationDto requestConversation)
        {
            string invitedUserId = HashGenerator.Md5(string.Format(UserOwnIdPattern, requestConversation.InvitedAccountId, requestConversation.InvitedUserName));

            await Clients.Group(invitedUserId).SendAsync(InviteToConversation, requestConversation.InvitingAccountId, requestConversation.InvitingUserName); 
        }

        public async Task SendMessage(ChatMessageDto chatMessage)
        {
            await Clients.Group(chatMessage.RoomName).SendAsync(ClientReceiveMessageCallback, chatMessage);

            //chatMessage.RoomId = 8;

            ChatLogic.SendMessage(chatMessage);
        }

        protected virtual async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }
    }
}
