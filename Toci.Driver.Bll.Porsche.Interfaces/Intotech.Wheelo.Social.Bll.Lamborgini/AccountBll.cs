using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Social.Bll.Lamborgini.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Social.Bll.Lamborgini
{
    public class AccountBll : IAccountBll
    {
        //protected IAccountRoleLogic AccountLogic;
        protected AccountLogic AccountLogic;

        public AccountBll() //IAccountRoleLogic accountLogic
        {
            AccountLogic = new AccountLogic();
        }

        public virtual Account GetUserAccounts(int accountId)
        {
            return AccountLogic.Select(m => m.Id == accountId).FirstOrDefault(); //HttpClient -> api wheelo (nie social czasami)
        }

        public virtual List<Account> GetUsersAccounts(List<int> accountIds)
        {
            return AccountLogic.Select(m => accountIds.Contains(m.Id)).ToList();
        }
    }
}
