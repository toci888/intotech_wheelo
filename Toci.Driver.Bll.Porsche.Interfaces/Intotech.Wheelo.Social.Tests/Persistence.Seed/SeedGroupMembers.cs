using Intotech.Wheelo.Social.Database.Persistence.Models;
using Intotech.Wheelo.Tests.Persistence.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Social.Tests.Persistence.Seed
{
    public class SeedGroupMembers : SeedSocialLogic<Groupmember>
    {
        public override void Insert()
        {
            List<Groupmember> members = new List<Groupmember>()
            {
                new Groupmember() { Idaccount = 1, Idgroups = 1 },
                new Groupmember() { Idaccount = 2, Idgroups = 1 },
                new Groupmember() { Idaccount = 3, Idgroups = 1 },
                new Groupmember() { Idaccount = 4, Idgroups = 1 },
                new Groupmember() { Idaccount = 14, Idgroups = 2 },
                new Groupmember() { Idaccount = 24, Idgroups = 2 },
                new Groupmember() { Idaccount = 34, Idgroups = 2 },
                new Groupmember() { Idaccount = 44, Idgroups = 2 },
                new Groupmember() { Idaccount = 49, Idgroups = 2 },
                new Groupmember() { Idaccount = 11, Idgroups = 3 },
                new Groupmember() { Idaccount = 22, Idgroups = 3 },
                new Groupmember() { Idaccount = 33, Idgroups = 3 },
                new Groupmember() { Idaccount = 12, Idgroups = 4 },
                new Groupmember() { Idaccount = 13, Idgroups = 4 },
                new Groupmember() { Idaccount = 15, Idgroups = 4 },
                new Groupmember() { Idaccount = 16, Idgroups = 4 },
                new Groupmember() { Idaccount = 17, Idgroups = 4 },
                new Groupmember() { Idaccount = 18, Idgroups = 4 },
                new Groupmember() { Idaccount = 25, Idgroups = 5 },
                new Groupmember() { Idaccount = 35, Idgroups = 5 },
                new Groupmember() { Idaccount = 45, Idgroups = 5 },
            };

            InsertCollection(members);
        }
    }
}
