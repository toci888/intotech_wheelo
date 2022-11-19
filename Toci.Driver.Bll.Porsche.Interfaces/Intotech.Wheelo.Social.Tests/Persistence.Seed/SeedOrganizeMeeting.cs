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
                new Organizemeeting() { Idaccount = 14, Idgroups = 2, Isover = false, Meetingdate = DateTime.Now.AddHours(7), Name = "Jak do pracy?" },
                new Organizemeeting() { Idaccount = 11, Idgroups = 3, Isover = false, Meetingdate = DateTime.Now.AddHours(8), Name = "Ożesz ty go fuu" },
                new Organizemeeting() { Idaccount = 12, Idgroups = 4, Isover = false, Meetingdate = DateTime.Now.AddHours(10), Name = "Piwko zapoznawcze" },
                new Organizemeeting() { Idaccount = 25, Idgroups = 5, Isover = false, Meetingdate = DateTime.Now.AddHours(3), Name = "Na Szybko" },
            };

            InsertCollection(organizemeetings);
        }
    }
}
