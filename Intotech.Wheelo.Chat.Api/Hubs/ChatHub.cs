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

        [Authorize(Roles = "User")]
        public async Task ProofOfConcept(int accountId)
        {
            string doopa = Context.User.Identity.Name;

            await this.Clients.User(Context.UserIdentifier).SendAsync("PocResponse", Context.UserIdentifier);
        }

        [Authorize(Roles = "User")]
        public async Task ConnectUser(string email) // accountId room for synchronizations
        {
            
            //string test = Context.ConnectionId;
            //Clients.User().SendAsync()
            ChatUserDto data = ChatUserService.Connect(email);

            if (data == null) 
            {
                await Clients.Caller.SendAsync("connect_error", "Invalid userId");

                return;
            }

            data.SessionId = Context.UserIdentifier;

            await this.Clients.User(Context.UserIdentifier).SendAsync(ClientAddUserCallback, new { data });

            //RoomsDto result = RoomService.CreateRoom(accountId, new List<int>());

            //await JoinRoom(result.IdRoom); //connectionId

            // ChatUserService.JoinRoom(accountId, result.IdRoom);

            //  data.SessionId = result.IdRoom;

            // await Clients.Group(result.IdRoom.ToString()).SendAsync(ClientAddUserCallback, new { data }); //new { sessionID = user.SessionId }  // , new { data = user.SessionId }
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
       
        public async Task SendMessage(ChatMessageDto chatMessage)
        {
            chatMessage = ChatUserService.SendMessage(chatMessage);

            await Clients.Group(chatMessage.ID.ToString()).SendAsync(ClientReceiveMessageCallback, new { chatMessage });

        }
        /*
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

       public async Task ApproveConversation(int ownerId, List<int> participantsIds)
       {
           RoomsDto result = RoomService.CreateRoom(ownerId, participantsIds);

           await JoinRoom(result.IdRoom);
       }

       protected virtual async Task JoinRoom(int roomId, string connectionId)
       {
           await Groups.AddToGroupAsync(connectionId, roomId.ToString());
       }



       protected virtual async Task JoinRoom(string roomId)
       {
           await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
       }*/
    }
}
