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
    public class OrganizeMeetingManager : IOrganizeMeetingManager
    {
        protected IAccountBll AccountManager;
        protected IOrganizemeetingLogic OrganizemeetingLogic;

        public OrganizeMeetingManager(IAccountBll accountManager, IOrganizemeetingLogic organizemeetingLogic)
        {
            AccountManager = accountManager;
            OrganizemeetingLogic = organizemeetingLogic;
        }

        public virtual OrganizemeetingDto GetMeetingForUser(int accountId)
        {
            Organizemeeting orgM = OrganizemeetingLogic.Select(m => m.Idaccount == accountId && m.Isover == false).First();

            OrganizemeetingDto result = OrganizemeetingDto.MapperFill(orgM);

            Accountrole accR = AccountManager.GetUserAccounts(accountId);

            result.OrganizerEmail = accR.Email;
            result.OrganizerName = accR.Name;
            result.OrganizerSurname = accR.Surname;

            return result;
        }
    }
}
