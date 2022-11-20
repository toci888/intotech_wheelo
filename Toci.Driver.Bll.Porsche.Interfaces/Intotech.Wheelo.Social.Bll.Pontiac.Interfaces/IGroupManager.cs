using Intotech.Wheelo.Bll.Models.Social;
using Intotech.Wheelo.Social.Database.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Social.Bll.Pontiac.Interfaces
{
    public interface IGroupManager
    {
        GroupMemebersDto GetGroupWithMembers(int groupId);

        GroupMemberAddDto AddMemberToGroup(Groupmember model);
    }
}
