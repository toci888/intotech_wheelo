using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
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

        public InvitationService(IVinvitationLogic vinvitationLogic)
        {
            VinvitationLogic = vinvitationLogic;      
        }
        public List<Vinvitation> GetInvitedAccounts(int accountId)
        {
            return VinvitationLogic.Select(invitation=>invitation.Accountid==accountId).ToList();
        }
    }
}
