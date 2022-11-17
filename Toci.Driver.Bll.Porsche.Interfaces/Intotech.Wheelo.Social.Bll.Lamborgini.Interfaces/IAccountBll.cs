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
        List<Accountrole> GetUsersAccounts(List<int> accountIds);

        Accountrole GetUserAccounts(int accountId);
    }
}
