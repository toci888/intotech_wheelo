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
        protected ICachingService CachingService;

        public ChatUserService(IAccountService accountService, IConnecteduserLogic connecteduserLogic, 
            IUseractivityLogic userActivityLogic, IRoomsaccountLogic roomsAccountLogic,
            IConversationinvitationLogic conversationInvitationLogic,
            IMessageLogic messageLogic, ICachingService cachingService)
        {
            AccountService = accountService;
            ConnecteduserLogic = connecteduserLogic;
            UserActivityLogic = userActivityLogic;
            RoomsAccountLogic = roomsAccountLogic;
            ConversationInvitationLogic = conversationInvitationLogic;
            MessageLogic = messageLogic;
            CachingService = cachingService;
        }

        public virtual ChatUserDto Connect(string email)
        {
            UserCacheDto userCached = GetUser(email);

            if (userCached == null)
            {
                return null;
            }

            ConnecteduserLogic.Insert(new Connecteduser() { Email = email }); // TODO what if 2 or more locations
            UserActivityLogic.Insert(new Useractivity() { Email = email, Connectedfrom = DateTime.Now });

            return new ChatUserDto() { SenderEmail = email, UserName = userCached.UserName, UserSurname = userCached.UserSurname, 
                ImageUrl = userCached.ImageUrl, IdAccount = userCached.IdAccount, SessionId = email };
        }

        public virtual ChatMessageDto SendMessage(ChatMessageDto chatMessage)
        {
            UserCacheDto userCached = GetUser(chatMessage.SenderEmail);

            Message mess = MessageLogic.Insert(new Message() { Authoremail = chatMessage.SenderEmail, Message1 = chatMessage.Text, Idroom = chatMessage.ID });

            chatMessage.CreatedAt = mess.Createdat.Value;
            chatMessage.AuthorFirstName = userCached.UserName;
            chatMessage.AuthorLastName = userCached.UserSurname;
            chatMessage.IdAccount = userCached.IdAccount;
            chatMessage.ImageUrl = ImageServiceUtils.GetImageUrl(userCached.IdAccount);

            return chatMessage;
        }

        protected virtual UserCacheDto GetUser(string email)
        {
            UserCacheDto userCached = CachingService.Get<UserCacheDto>(email);

            if (userCached == null)
            {
                UserCacheDto userData = AccountService.GetAccount(email);

                if (userData == null)
                {
                    return null;
                }

                CachingService.Set(userData.SenderEmail, userData);

                userCached = userData;
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
