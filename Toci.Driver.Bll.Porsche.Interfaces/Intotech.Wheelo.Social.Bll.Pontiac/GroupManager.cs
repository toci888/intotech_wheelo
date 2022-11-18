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

        public virtual GroupMemebersDto GetGroupWithMembers(int groupId)
        {
            GroupMemebersDto result = new GroupMemebersDto();

            Group group = GroupLogic.Select(m => m.Id == groupId).First();
            List<Groupmember> groupmembers = GroupMemberLogic.Select(m => m.Idgroups == groupId).ToList();

            List<Accountrole> accountroles = AccountLogic.GetUsersAccounts(groupmembers.Select(m => m.Idaccount).ToList());

            result.GroupName = group.Name;
            result.GroupId = group.Id;

            result.GroupMembers = new List<Account>();

            foreach (Accountrole accountrole in accountroles)
            {
                result.GroupMembers.Add(new Account() { 
                    Email = accountrole.Email, 
                    Name = accountrole.Name, 
                    Surname = accountrole.Surname }); //TODO
            }

            return result;
        }
    }
}
