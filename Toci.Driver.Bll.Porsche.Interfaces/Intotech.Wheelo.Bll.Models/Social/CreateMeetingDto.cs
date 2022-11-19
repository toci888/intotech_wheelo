using Intotech.Wheelo.Social.Database.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.Social
{
    public class CreateMeetingDto : Organizemeeting
    {
        public List<int> MeetingMissAccounts { get; set; }
    }
}
