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
        private const string UserOwnIdPattern = "accountId: {0}";
        private const string UsersRoomIdPattern = "accountId: {0}, accountId: {1}";

        protected IChatUserService ChatUserService;

        public ChatHub(IChatUserService chatUser)
        {
            ChatUserService = chatUser;
        }

        public async Task ConnectUser(int accountId) // accountId room for synchronizations
        {
            ChatUserDto user = ChatUserService.Connect(accountId);

            string roomId = string.Format(UserOwnIdPattern, accountId);

            await JoinRoom(roomId);

            ChatUserService.JoinRoom(accountId, roomId);

            user.RoomId = roomId;

            await Clients.Group(roomId).SendAsync(ClientAddUserCallback, user);
        }

        public async Task RequestConversation(RequestConversationDto requestConversation)
        {
            requestConversation = ChatUserService.Invite(requestConversation);

            if (!requestConversation.IsInvited)
            {
                foreach (int accountId in requestConversation.InvitedAccountIds)
                {
                    string invitedUserId = string.Format(UserOwnIdPattern, accountId);

                    await Clients.Group(invitedUserId).SendAsync(InviteToConversationCallback, requestConversation);
                }
            }
        }

        public async Task ApproveChat(int firstParticipantId, int secondParticipantId)
        {
            string roomId;

            if (firstParticipantId > secondParticipantId)
            {
                roomId = string.Format(UsersRoomIdPattern, secondParticipantId, firstParticipantId);
            }
            else
            {
                roomId = string.Format(UsersRoomIdPattern, firstParticipantId, secondParticipantId);
            }

            await JoinRoom(roomId);
        }

        public async Task SendMessage(ChatMessageDto chatMessage)
        {
            if (chatMessage.ChatMessageAuthorId > chatMessage.ChatParticipantId)
            {
                chatMessage.RoomId = string.Format(UsersRoomIdPattern, chatMessage.ChatParticipantId, chatMessage.ChatMessageAuthorId);
            }
            else
            {
                chatMessage.RoomId = string.Format(UsersRoomIdPattern, chatMessage.ChatMessageAuthorId, chatMessage.ChatParticipantId);
            }

            chatMessage = ChatUserService.SendMessage(chatMessage);

            await Clients.Group(chatMessage.RoomId).SendAsync(ClientReceiveMessageCallback, chatMessage);
        }

        protected virtual async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }
    }
}
