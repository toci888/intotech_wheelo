using Intotech.Common;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Social;
using Intotech.Wheelo.Social.Bll.Lamborgini.Interfaces;
using Intotech.Wheelo.Social.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Social.Bll.Pontiac.Interfaces;
using Intotech.Wheelo.Social.Database.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Social.Bll.Pontiac
{
    public class GroupManager : IGroupManager
    {
        protected IAccountBll AccountLogic;
        protected IGroupLogic GroupLogic;
        protected IGroupmemberLogic GroupMemberLogic;

        public GroupManager(IAccountBll accountLogic, IGroupLogic groupLogic, IGroupmemberLogic groupMemberLogic)
        {
            AccountLogic = accountLogic;
            GroupLogic = groupLogic;
            GroupMemberLogic = groupMemberLogic;
        }

        public virtual ReturnedResponse<GroupMemberAddDto> AddMemberToGroup(Groupmember model)
        {
            Groupmember memberAdded = GroupMemberLogic.Insert(model);

            GroupMemberAddDto groupMemberAddDto = DtoModelMapper.Map<GroupMemberAddDto, Groupmember>(memberAdded);

            groupMemberAddDto.MemberWhoAdded = AccountLogic.GetUserAccounts(memberAdded.Idaccountwhoadded);
            groupMemberAddDto.AddedMember = AccountLogic.GetUserAccounts(memberAdded.Idaccount);

            Group group = GroupLogic.Select(m => m.Id == memberAdded.Idgroups).First();

            groupMemberAddDto.GroupName = group.Name;

            return new ReturnedResponse<GroupMemberAddDto>(groupMemberAddDto, "", true);
        }

        public virtual ReturnedResponse<GroupMembersDto> GetGroupWithMembers(int groupId)
        {
            GroupMembersDto result = new GroupMembersDto();

            Group group = GroupLogic.Select(m => m.Id == groupId).First();
            List<Groupmember> groupmembers = GroupMemberLogic.Select(m => m.Idgroups == groupId).ToList();

            List<Accountrole> accountroles = AccountLogic.GetUsersAccounts(groupmembers.Select(m => m.Idaccount).ToList());

            result.GroupName = group.Name;
            result.GroupId = group.Id;

            result.GroupMembers = accountroles;

            return new ReturnedResponse<GroupMembersDto>(result, "", true);
        }
    }
}
