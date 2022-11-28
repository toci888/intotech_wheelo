using Intotech.Common.Bll.ComplexResponses;
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
        protected IAccountRoleLogic AccountLogic;

        public AccountBll(IAccountRoleLogic accountLogic)
        {
            AccountLogic = accountLogic;
        }

        public virtual ReturnedResponse<Accountrole> GetUserAccounts(int accountId)
        {
            return new ReturnedResponse<Accountrole>(AccountLogic.Select(m => m.Id.Value == accountId).FirstOrDefault(),"",true);
        }

        public virtual ReturnedResponse<List<Accountrole>> GetUsersAccounts(List<int> accountIds)
        {
            return new ReturnedResponse<List<Accountrole>>(AccountLogic.Select(m => accountIds.Contains(m.Id.Value)).ToList(), "", true);
        }
    }
}
