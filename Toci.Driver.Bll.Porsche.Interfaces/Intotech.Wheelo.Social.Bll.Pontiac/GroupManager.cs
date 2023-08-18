using Intotech.Common;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Interfaces;
using Intotech.Wheelo.Bll.Models.Social;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
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
        protected ITranslationEngineI18n I18nTranslation; //= new TranslationEngineI18n();

        public GroupManager(IAccountBll accountLogic, IGroupLogic groupLogic, IGroupmemberLogic groupMemberLogic, ITranslationEngineI18n i18nTranslation)
        {
            AccountLogic = accountLogic;
            GroupLogic = groupLogic;
            GroupMemberLogic = groupMemberLogic;
            I18nTranslation = i18nTranslation;
        }

        public virtual ReturnedResponse<GroupMemberAddDto> AddMemberToGroup(Groupmember model)
        {
            Groupmember memberAdded = GroupMemberLogic.Insert(model);

            GroupMemberAddDto groupMemberAddDto = DtoModelMapper.Map<GroupMemberAddDto, Groupmember>(memberAdded);

            groupMemberAddDto.MemberWhoAdded = AccountLogic.GetUserAccounts(memberAdded.Idaccountwhoadded);
            groupMemberAddDto.AddedMember = AccountLogic.GetUserAccounts(memberAdded.Idaccount);

            Group group = GroupLogic.Select(m => m.Id == memberAdded.Idgroups).First();

            groupMemberAddDto.GroupName = group.Name;

            return new ReturnedResponse<GroupMemberAddDto>(groupMemberAddDto, I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<GroupMembersDto> GetGroupWithMembers(int groupId)
        {
            GroupMembersDto result = new GroupMembersDto();

            Group group = GroupLogic.Select(m => m.Id == groupId).First();
            List<Groupmember> groupmembers = GroupMemberLogic.Select(m => m.Idgroups == groupId).ToList();

            List<Account> accountroles = AccountLogic.GetUsersAccounts(groupmembers.Select(m => m.Idaccount).ToList());

            result.GroupName = group.Name;
            result.GroupId = group.Id;

            result.GroupMembers = accountroles;

            return new ReturnedResponse<GroupMembersDto>(result, I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}
