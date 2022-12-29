using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
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
    public class ChatUser : IChatUser
    {
        protected IAccountService AccountService;
        protected IConnecteduserLogic ConnecteduserLogic;

        public ChatUser(IAccountService accountService, IConnecteduserLogic connecteduserLogic)
        {
            AccountService = accountService;
            ConnecteduserLogic = connecteduserLogic;
        }

        public virtual ChatUserDto Connect(int accountId)
        {
            Account userData = AccountService.GetAccount(accountId);

            ConnecteduserLogic.Insert(new Connecteduser() { Idaccount = accountId }); // TODO what if 2 or more locations

            return new ChatUserDto() { UserId = accountId, UserName = userData.Name, UserSurname = userData.Surname };
        }
    }
}
