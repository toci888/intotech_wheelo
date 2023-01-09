﻿using Intotech.Common;
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
        private const string ClientReceiveMessageCallback = "getMessage";
        private const string ClientAddUserCallback = "session";
        private const string InviteToConversationCallback = "InviteToConversation";
        private const string RoomIdPattern = "{0}_RoomIdText";

        protected IChatUserService ChatUserService;
        protected IRoomService RoomService;

        public ChatHub(IChatUserService chatUser, IRoomService roomService)
        {
            ChatUserService = chatUser;
            RoomService = roomService;
        }

        //public override Task OnConnectedAsync()
        //{
        //    //string roomId = HashGenerator.Md5(Context.ConnectionId);
        //    //HttpRequestMessage
        //    JoinRoom(Context.UserIdentifier);
           
        //    Clients.Group(Context.UserIdentifier).SendAsync("session", new { data = new { sessionID = Context.UserIdentifier } });

        //    return base.OnConnectedAsync();
        //}

        public async Task ConnectUser(int accountId, string accessToken) // accountId room for synchronizations
        {
           //string test = Context.ConnectionId;

            ChatUserDto data = ChatUserService.Connect(accountId);

            if (data == null)
            {
                await Clients.Caller.SendAsync("connect_error", "Invalid userId");
            }

            RoomsDto result = RoomService.CreateRoom(accountId, new List<int>());

            await JoinRoom(result.IdRoom); //connectionId

            ChatUserService.JoinRoom(accountId, result.IdRoom);

            data.SessionId = result.IdRoom;

            await Clients.Group(result.IdRoom.ToString()).SendAsync(ClientAddUserCallback, new { data }); //new { sessionID = user.SessionId }  // , new { data = user.SessionId }
        }

        public async Task SendMessage(ChatMessageDto chatMessage)
        {
            string test = Context.ConnectionId;

            chatMessage = ChatUserService.SendMessage(chatMessage);

            await Clients.Group(chatMessage.ID.ToString()).SendAsync(ClientReceiveMessageCallback, new { chatMessage });

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

        protected virtual async Task JoinRoom(int roomId, string connectionId)
        {
            await Groups.AddToGroupAsync(connectionId, roomId.ToString());
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
