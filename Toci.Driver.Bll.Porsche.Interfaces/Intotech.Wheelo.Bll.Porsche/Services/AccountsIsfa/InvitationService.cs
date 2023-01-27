using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Isfa;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intotech.Common;
using Intotech.Wheelo.Common.ImageService;
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
        

        public virtual ReturnedResponse<bool> CancelInvitation(int invitingAccountId, int invitedAccountId)
        {
            Invitation fr = InvitationLogic.Select(m => m.Idaccount == invitingAccountId && m.Idinvited == invitedAccountId).FirstOrDefault();

            if (fr == null)
            {
                return new ReturnedResponse<bool>(false, I18nTranslation.Translation(I18nTags.FriendshipNotFound), false, ErrorCodes.FriendshipNotFound);
            }

            return new ReturnedResponse<bool>(InvitationLogic.Delete(fr) > 0, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<VInvitationDto>> GetInvitedAccounts(int accountId)
        {
            List<VInvitationDto> invitedResult = new List<VInvitationDto>();

            List<Vinvitation> currentInvitations = VinvitationLogic.Select(invitation => invitation.Idaccount == accountId).ToList();

            foreach (Vinvitation item in currentInvitations)
            {
                VInvitationDto element = DtoModelMapper.Map<VInvitationDto, Vinvitation>(item);

                element.InvitedImageUrl = ImageServiceUtils.GetImageUrl(element.Idaccountinvited.Value);
                element.InvitingImageUrl = ImageServiceUtils.GetImageUrl(element.Idaccount.Value);

                invitedResult.Add(element);
            }

            return new ReturnedResponse<List<VInvitationDto>>(invitedResult, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<Vinvitation> InviteToFriends(int invitingAccountId, int invitedAccountId)
        {
            //WheeloUtils.PotentialSwapIds(ref invitingAccountId, ref invitedAccountId);
            Invitation invitation = InvitationLogic.Select(m => m.Idinvited == invitedAccountId && m.Idaccount == invitingAccountId).FirstOrDefault();

            if (invitation == null)
            {
                InvitationLogic.Insert(new Invitation() { Idaccount = invitingAccountId, Idinvited = invitedAccountId });
            }

            Vinvitation result =  VinvitationLogic.Select(m => m.Idaccount == invitingAccountId && m.Idaccountinvited == invitedAccountId).FirstOrDefault();

            return new ReturnedResponse<Vinvitation>(result, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}
