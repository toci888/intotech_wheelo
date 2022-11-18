using Intotech.Wheelo.Social.Database.Persistence.Models;
using Intotech.Wheelo.Tests.Persistence.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Social.Tests.Persistence.Seed
{
    public class SeedGroups : SeedSocialLogic<Group>
    {
        public override void Insert()
        {
            List<Group> groups = new List<Group>()
            {
                new Group() { Idaccountcreated = 1, Name = "Herosi Toci"}
            };

            InsertCollection(groups);
        }
    }
}
