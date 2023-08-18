using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Bll.Models.Isfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa
{
    public interface IInvitationService : IService
    {
        ReturnedResponse<List<VInvitationDto>> GetInvitedAccounts(int accountId);
        ReturnedResponse<Vinvitation> InviteToFriends(int invitingAccountId, int invitedAccountId);
        ReturnedResponse<bool> CancelInvitation(int invitingAccountId, int invitedAccountId);

    }
}
