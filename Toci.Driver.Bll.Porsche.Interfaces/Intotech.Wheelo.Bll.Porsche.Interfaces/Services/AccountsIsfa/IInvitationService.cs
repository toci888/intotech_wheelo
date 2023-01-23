using Intotech.Common.Bll.ComplexResponses;
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
        ReturnedResponse<List<Vinvitation>> GetInvitedAccounts(int accountId);
        ReturnedResponse<Vinvitation> InviteToFriends(int invitingAccountId, int invitedAccountId);
        ReturnedResponse<bool> CancelInvitation(int invitingAccountId, int invitedAccountId);

    }
}
