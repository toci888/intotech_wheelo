using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitationsController : ApiSimpleControllerBase<IInvitationService>
    {
        public InvitationsController(IInvitationService logic) : base(logic)
        {
            
        }

        [HttpPost]
        [Route("invite-associated")]
        public ReturnedResponse<Vinvitation> InviteAssociated(int invitingAccountId, int invitedAccountId)
        {
            return Service.InviteToFriends(invitingAccountId, invitedAccountId);
        }
    }
}
