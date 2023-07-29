using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Social;
using Intotech.Wheelo.Social.Database.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Social.Bll.Pontiac.Interfaces
{
    public interface IOrganizeMeetingManager
    {
        ReturnedResponse<OrganizemeetingDto> GetMeetingForUser(int accountId);

        ReturnedResponse<OrganizemeetingDto> OrganizeMeeting(CreateMeetingDto meeting);


    }
}
