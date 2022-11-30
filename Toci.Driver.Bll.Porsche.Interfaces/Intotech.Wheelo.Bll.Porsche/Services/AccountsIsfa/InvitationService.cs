using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Services.AccountsIsfa
{
    public class InvitationService : IInvitationService
    {
        protected IVinvitationLogic VinvitationLogic;
        protected IInvitationLogic InvitationLogic;


        public InvitationService(IVinvitationLogic vinvitationLogic, IInvitationLogic invitationLogic)
        {
            VinvitationLogic = vinvitationLogic;      
            InvitationLogic = invitationLogic;
        }

        public ReturnedResponse<List<Vinvitation>> GetInvitedAccounts(int accountId)
        {
            return new ReturnedResponse<List<Vinvitation>>(VinvitationLogic.Select(invitation => invitation.Accountid == accountId).ToList(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<Vinvitation> InviteToFriends(int invitingAccountId, int invitedAccountId)
        {
            InvitationLogic.Insert(new Invitation() { Idaccount = invitingAccountId, Idinvited = invitedAccountId });

            return new ReturnedResponse<Vinvitation>(VinvitationLogic.Select(m => m.Accountid == invitingAccountId).FirstOrDefault(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}
