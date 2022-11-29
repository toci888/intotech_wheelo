using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models.Social;
using Intotech.Wheelo.Social.Bll.Pontiac.Interfaces;
using Intotech.Wheelo.Social.Database.Persistence.Models;
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
        [Route("group-with-members")]
        public ReturnedResponse<GroupMembersDto> GetGroupWithMembers(int groupId)
        {
            return Service.GetGroupWithMembers(groupId);
        }

        [HttpPost]
        [Route("add-member-to-group")]
        public ReturnedResponse<GroupMemberAddDto> AddMemberToGroup([FromBody]Groupmember memberAdd)
        {
            return Service.AddMemberToGroup(memberAdd);
        }
    }
}
