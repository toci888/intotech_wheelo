using Intotech.Common;
using Intotech.Common.Bll.ComplexResponses;
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
    public class OrganizeMeetingManager : IOrganizeMeetingManager
    {
        protected IAccountBll AccountManager;
        protected IOrganizemeetingLogic OrganizemeetingLogic;
        protected IMeetingskippedaccountLogic MeetingskippedaccountLogic;

        public OrganizeMeetingManager(IAccountBll accountManager, IOrganizemeetingLogic organizemeetingLogic,
            IMeetingskippedaccountLogic meetingskippedaccountLogic)
        {
            AccountManager = accountManager;
            OrganizemeetingLogic = organizemeetingLogic;
            MeetingskippedaccountLogic = meetingskippedaccountLogic;
        }

        public virtual ReturnedResponse<OrganizemeetingDto> GetMeetingForUser(int accountId)
        {
            Organizemeeting orgM = OrganizemeetingLogic.Select(m => m.Idaccount == accountId && m.Isover == false).First();

            OrganizemeetingDto result = DtoModelMapper.Map<OrganizemeetingDto, Organizemeeting>(orgM);

            return new ReturnedResponse<OrganizemeetingDto>(GetMeetingDto(accountId, result), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual OrganizemeetingDto OrganizeMeeting(CreateMeetingDto meeting)
        {
            Organizemeeting organizedMeeting = OrganizemeetingLogic.Insert(meeting);

            foreach (int accountId in meeting.MeetingMissAccounts)
            {
                MeetingskippedaccountLogic.Insert(new Meetingskippedaccount() { 
                    Idgroups = organizedMeeting.Idgroups,
                    Idorganizemeeting = organizedMeeting.Id,
                    Idaccount = accountId
                });
            }

            return GetMeetingDto(organizedMeeting.Idaccount, DtoModelMapper.Map<OrganizemeetingDto, Organizemeeting>(organizedMeeting));
        }

        protected virtual OrganizemeetingDto GetMeetingDto(int accountId, OrganizemeetingDto result)
        {
            Accountrole accR = AccountManager.GetUserAccounts(accountId);

            result.OrganizerEmail = accR.Email;
            result.OrganizerName = accR.Name;
            result.OrganizerSurname = accR.Surname;

            return result;
        }
    }
}
