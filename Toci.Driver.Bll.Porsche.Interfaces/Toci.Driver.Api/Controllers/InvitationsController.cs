﻿using Intotech.Common.Bll.ComplexResponses;
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
        public class InvitationPostDto
        {
            public int InvitingAccountId { get; set; }
            public int InvitedAccountId { get; set; }
        }

        public InvitationsController(IInvitationService logic) : base(logic)
        {
            
        }

        [HttpGet("view-invitations")]
        public ReturnedResponse<List<Vinvitation>> GetInvitations(int idAccount)
        {
            return Service.GetInvitedAccounts(idAccount);
        }

        [HttpPost]
        [Route("invite-to-friends")]
        public ReturnedResponse<Vinvitation> InviteAssociated(InvitationPostDto invitation)
        {
            return Service.InviteToFriends(invitation.InvitingAccountId, invitation.InvitedAccountId);
        }
    }
}
