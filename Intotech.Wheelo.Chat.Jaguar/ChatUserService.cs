using Intotech.Wheelo.Chat.Bll.Persistence;
using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Chat.Dodge;
using Intotech.Wheelo.Chat.Dodge.Interfaces;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Intotech.Wheelo.Chat.Models.Caching;
using Intotech.Wheelo.Common.ImageService;
using Intotech.Wheelo.Common.Interfaces.CachingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Jaguar
{
    public class ChatUserService : IChatUserService
    {
        protected IAccountService AccountService;
        protected IConnecteduserLogic ConnecteduserLogic;
        protected IUseractivityLogic UserActivityLogic;
        protected IRoomsaccountLogic RoomsAccountLogic;
        protected IConversationinvitationLogic ConversationInvitationLogic;
        protected IMessageLogic MessageLogic;
        protected IRoomLogic RoomLogic;
        protected ICachingService CachingService;

        public ChatUserService(IAccountService accountService, IConnecteduserLogic connecteduserLogic, 
            IUseractivityLogic userActivityLogic, IRoomsaccountLogic roomsAccountLogic,
            IConversationinvitationLogic conversationInvitationLogic,
            IMessageLogic messageLogic, ICachingService cachingService,
            IRoomLogic roomLogic)
        {
            AccountService = accountService;
            ConnecteduserLogic = connecteduserLogic;
            UserActivityLogic = userActivityLogic;
            RoomsAccountLogic = roomsAccountLogic;
            ConversationInvitationLogic = conversationInvitationLogic;
            MessageLogic = messageLogic;
            CachingService = cachingService;
            RoomLogic = roomLogic;
        }

        public virtual ChatUserDto Connect(int idAccount)
        {
            UserCacheDto userCached = GetUser(idAccount);

            if (userCached == null)
            {
                return null;
            }

            ConnecteduserLogic.Insert(new Connecteduser() { Email = userCached.SenderEmail }); // TODO what if 2 or more locations
            UserActivityLogic.Insert(new Useractivity() { Email = userCached.SenderEmail, Connectedfrom = DateTime.Now });

            return new ChatUserDto() { SenderEmail = userCached.SenderEmail, UserName = userCached.UserName, UserSurname = userCached.UserSurname, 
                ImageUrl = userCached.ImageUrl, IdAccount = userCached.IdAccount, SessionId = userCached.SenderEmail
            };
        }

        public virtual LiveChatMessageDto SendMessage(LiveChatMessageDto chatMessage)
        {
            UserCacheDto userCached = GetUser(chatMessage.IdAccount);

            Room room = RoomLogic.Select(m => m.Roomid == chatMessage.RoomId).FirstOrDefault();
            //if room is null? TODO
            Message mess = MessageLogic.Insert(new Message() { Idaccount = chatMessage.IdAccount, Authoremail = userCached.SenderEmail, Message1 = chatMessage.Text, Idroom = room.Id });

            chatMessage.Id = mess.Id;

            chatMessage.Author = new AuthorDto() { FirstName = userCached.UserName, 
                LastName = userCached.UserSurname, ImageUrl = userCached.ImageUrl, SenderEmail = userCached.SenderEmail, 
                RoomId = chatMessage.RoomId, IdRoom = room.Id };

            return chatMessage;
        }

        protected virtual UserCacheDto GetUser(int idAccount)
        {
            UserCacheDto userCached = CachingService.Get<UserCacheDto>(idAccount.ToString());

            if (userCached == null)
            {
                UserCacheDto userData = AccountService.GetAccount(idAccount);

                if (userData == null)
                {
                    return null;
                }

                CachingService.Set(idAccount.ToString(), userData);

                return userData;
            }

            return userCached;
        }

        /*public virtual RequestConversationDto Invite(RequestConversationDto invitation)
        {
            Account userInviting = AccountService.GetAccount(invitation.InvitingAccountId);

            invitation.InvitingUserName = userInviting.Name;

            foreach (int accountId in invitation.InvitedAccountIds)
            {
                Conversationinvitation check = ConversationInvitationLogic.Select(m => m.Idaccount == invitation.InvitingAccountId && m.Idaccountinvited == accountId).FirstOrDefault();

                if (check != null)
                {
                    invitation.IsInvited = true;

                    return invitation;
                }

                Account userInvited = AccountService.GetAccount(accountId);

                ConversationInvitationLogic.Insert(new Conversationinvitation()
                {
                    Idaccount = invitation.InvitingAccountId,
                    Idaccountinvited = accountId,
                    Idroom = invitation.RoomId
                });
            }

            return invitation;
        }*/

        /*public virtual bool JoinRoom(int accountId, int roomId)
        {
            return RoomsAccountLogic.Insert(new Roomsaccount() { Idmember = accountId, Idroom = roomId }).Id > 0;
        }

        */
    }
}
