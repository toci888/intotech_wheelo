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
                new Group() { Idaccountcreated = 1, Name = "Herosi Toci"},
                new Group() { Idaccountcreated = 14, Name = "Praca Fiat"},
                new Group() { Idaccountcreated = 11, Name = "Fuu Foo"},
                new Group() { Idaccountcreated = 12, Name = "Polowanie na czarownice"},
                new Group() { Idaccountcreated = 25, Name = "Szybka strzała"}
            };

            InsertCollection(groups);
        }
    }
}
