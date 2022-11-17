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
        protected IAccountLogic AccountLogic;

        public AccountBll(IAccountLogic accountLogic)
        {
            AccountLogic = accountLogic;
        }

        public virtual Accountrole GetUserAccounts(int accountId)
        {
            return AccountLogic.Select(m => m.Id.Value == accountId).FirstOrDefault();
        }

        public virtual List<Accountrole> GetUsersAccounts(List<int> accountIds)
        {
            return AccountLogic.Select(m => accountIds.Contains(m.Id.Value)).ToList();
        }
    }
}
