using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Dodge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Dodge
{
    public class AccountService : IAccountService
    {
        protected IAccountLogic AccountLogic;

        public AccountService(IAccountLogic accountLogic)
        {
            AccountLogic = accountLogic;
        }

        public virtual Account GetAccount(string email)
        {
            return AccountLogic.Select(m => m.Email == email).FirstOrDefault();
        }
    }
}
