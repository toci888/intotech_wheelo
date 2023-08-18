using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Bll.Models.Social;
using Intotech.Wheelo.Social.Database.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Social.Bll.Pontiac.Interfaces
{
    public interface IGroupManager  : IManager
    {
        ReturnedResponse<GroupMembersDto> GetGroupWithMembers(int groupId);

        ReturnedResponse<GroupMemberAddDto> AddMemberToGroup(Groupmember model);
    }
}
