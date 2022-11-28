using Intotech.Common.Bll.ComplexResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Social.Bll.Lamborgini.Interfaces
{
    public interface IAccountBll
    {
        ReturnedResponse<List<Accountrole>> GetUsersAccounts(List<int> accountIds);

        ReturnedResponse<Accountrole> GetUserAccounts(int accountId);
    }
}
