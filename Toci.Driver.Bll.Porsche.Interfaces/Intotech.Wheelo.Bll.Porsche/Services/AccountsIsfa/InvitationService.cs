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
        public const int InvitationOriginCollocations = 1;
        public const int InvitationOriginSuggestions = 2;

        protected IVinvitationLogic VinvitationLogic;
        protected IInvitationLogic InvitationLogic;


        public InvitationService(IVinvitationLogic vinvitationLogic, IInvitationLogic invitationLogic)
        {
            VinvitationLogic = vinvitationLogic;      
            InvitationLogic = invitationLogic;
        }

        public ReturnedResponse<List<Vinvitation>> GetInvitedAccounts(int accountId)
        {
            return new ReturnedResponse<List<Vinvitation>>(VinvitationLogic.Select(invitation => invitation.Accountid == accountId || invitation.Suggestedaccountid == accountId).ToList(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<Vinvitation> InviteToFriends(int invitingAccountId, int invitedAccountId)
        {
            //WheeloUtils.PotentialSwapIds(ref invitingAccountId, ref invitedAccountId);
            Invitation invitation = InvitationLogic.Select(m => m.Idinvited == invitedAccountId && m.Idaccount == invitingAccountId).FirstOrDefault();

            if (invitation == null)
            {
                InvitationLogic.Insert(new Invitation() { Idaccount = invitingAccountId, Idinvited = invitedAccountId });
            }

            Vinvitation result =  VinvitationLogic.Select(m => m.Accountid == invitingAccountId && m.Suggestedaccountid == invitedAccountId).FirstOrDefault();

            return new ReturnedResponse<Vinvitation>(result, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}
