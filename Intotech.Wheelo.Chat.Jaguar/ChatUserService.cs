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
    public class ChatUserService : IChatUserService
    {
        protected IAccountService AccountService;
        protected IConnecteduserLogic ConnecteduserLogic;
        protected IUseractivityLogic UserActivityLogic;
        protected IRoomsaccountLogic RoomsAccountLogic;

        public ChatUserService(IAccountService accountService, IConnecteduserLogic connecteduserLogic, 
            IUseractivityLogic userActivityLogic, IRoomsaccountLogic roomsAccountLogic)
        {
            AccountService = accountService;
            ConnecteduserLogic = connecteduserLogic;
            UserActivityLogic = userActivityLogic;
            RoomsAccountLogic = roomsAccountLogic;
        }

        public virtual ChatUserDto Connect(int accountId)
        {
            Account userData = AccountService.GetAccount(accountId);

            ConnecteduserLogic.Insert(new Connecteduser() { Idaccount = accountId }); // TODO what if 2 or more locations
            UserActivityLogic.Insert(new Useractivity() { Idaccount = accountId, Connectedfrom = DateTime.Now });

            return new ChatUserDto() { UserId = accountId, UserName = userData.Name, UserSurname = userData.Surname };
        }

        public virtual bool JoinRoom(int accountId, string roomId)
        {
            return RoomsAccountLogic.Insert(new Roomsaccount() { Idmember = accountId, Roomid = roomId }).Id > 0;
        }
    }
}
