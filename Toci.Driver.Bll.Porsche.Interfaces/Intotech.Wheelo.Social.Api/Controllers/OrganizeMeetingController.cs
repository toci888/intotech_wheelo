using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models.Social;
using Intotech.Wheelo.Social.Bll.Pontiac.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Intotech.Wheelo.Social.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizeMeetingController : ApiSimpleControllerBase<IOrganizeMeetingManager>
    {
        public OrganizeMeetingController(IOrganizeMeetingManager logic) : base(logic)
        {
        }

        [HttpGet]
        [Route("get-meeting-for-user")]
        public ReturnedResponse<OrganizemeetingDto> GetMeetingForUser(int accountId)
        {
            return Service.GetMeetingForUser(accountId);
        }
    }
}
