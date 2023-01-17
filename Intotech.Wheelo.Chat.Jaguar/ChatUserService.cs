using Intotech.Wheelo.Chat.Bll.Persistence;
using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Chat.Dodge;
using Intotech.Wheelo.Chat.Dodge.Interfaces;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
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

        public ChatUserService(IAccountService accountService, IConnecteduserLogic connecteduserLogic, 
            IUseractivityLogic userActivityLogic, IRoomsaccountLogic roomsAccountLogic,
            IConversationinvitationLogic conversationInvitationLogic,
            IMessageLogic messageLogic)
        {
            AccountService = accountService;
            ConnecteduserLogic = connecteduserLogic;
            UserActivityLogic = userActivityLogic;
            RoomsAccountLogic = roomsAccountLogic;
            ConversationInvitationLogic = conversationInvitationLogic;
            MessageLogic = messageLogic;
        }

        public virtual ChatUserDto Connect(string email)
        {
            Account userData = AccountService.GetAccount(email);

            if (userData == null)
            {
                return null;
            }

            ConnecteduserLogic.Insert(new Connecteduser() { Email = email }); // TODO what if 2 or more locations
            UserActivityLogic.Insert(new Useractivity() { Email = email, Connectedfrom = DateTime.Now });

            return new ChatUserDto() { SenderID = email, UserName = userData.Name, UserSurname = userData.Surname, ImageUrl = userData.Image, IdAccount = userData.Id, SessionId = email };
        }

        public virtual ChatMessageDto SendMessage(ChatMessageDto chatMessage)
        {
            Account acc = AccountService.GetAccount(chatMessage.SenderID);

            if (acc == null)
            {
                return null;
            }

            Message mess = MessageLogic.Insert(new Message() { Authoremail = chatMessage.SenderID, Message1 = chatMessage.Text, Idroom = chatMessage.ID });

            chatMessage.CreatedAt = mess.Createdat.Value;
            chatMessage.AuthorFirstName = acc.Name;
            chatMessage.AuthorLastName = acc.Surname;
            chatMessage.IdAccount = acc.Id;
           // chatMessage.ImageUrl = acc.Image; // TODO Hub request

            return chatMessage;
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
