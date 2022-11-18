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
            };

            InsertCollection(members);
        }
    }
}
