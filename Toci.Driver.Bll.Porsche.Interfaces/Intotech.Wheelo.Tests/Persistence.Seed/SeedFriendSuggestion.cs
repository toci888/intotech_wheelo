using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedFriendSuggestion : SeedLogic<Friendsuggestion>
    {
        public override void Insert()
        {
            List<Friendsuggestion> list = new List<Friendsuggestion>();

            list.Add(new Friendsuggestion() { Idaccount = 1, Idsuggested = 14, Idsuggestedfriend = 23 });
            list.Add(new Friendsuggestion() { Idaccount = 2, Idsuggested = 13, Idsuggestedfriend = 22 });


            InsertCollection(list);
        }
    }
}
