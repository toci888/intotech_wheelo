using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa
{
    public interface IInvitationService
    {
        List<Vinvitation> GetInvitedAccounts(int accountId);
    }
}
