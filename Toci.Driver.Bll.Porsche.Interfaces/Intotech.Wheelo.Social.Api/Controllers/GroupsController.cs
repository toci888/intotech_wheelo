using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models.Social;
using Intotech.Wheelo.Social.Bll.Pontiac.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Intotech.Wheelo.Social.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ApiSimpleControllerBase<IGroupManager>
    {
        public GroupsController(IGroupManager logic) : base(logic)
        {
        }

        [HttpGet]
        [Route("get-group-with-members")]
        public GroupMemebersDto GetGroupWithMembers(int groupId)
        {
            return Logic.GetGroupWithMembers(groupId);
        }
    }
}
