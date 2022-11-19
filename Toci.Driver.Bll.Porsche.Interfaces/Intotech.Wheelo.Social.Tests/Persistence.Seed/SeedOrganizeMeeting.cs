using Intotech.Wheelo.Social.Database.Persistence.Models;
using Intotech.Wheelo.Tests.Persistence.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Social.Tests.Persistence.Seed
{
    public class SeedOrganizeMeeting : SeedSocialLogic<Organizemeeting>
    {
        public override void Insert()
        {
            List<Organizemeeting> organizemeetings = new List<Organizemeeting>()
            {
                new Organizemeeting() { Idaccount = 1, Idgroups = 1, Isover = false, Meetingdate = DateTime.Now.AddHours(5), Name = "Bemowo pije" },
            };

            InsertCollection(organizemeetings);
        }
    }
}
