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
            list.Add(new Friendsuggestion() { Idaccount = 3, Idsuggested = 11, Idsuggestedfriend = 12 });
            list.Add(new Friendsuggestion() { Idaccount = 4, Idsuggested = 22, Idsuggestedfriend = 23 });
            list.Add(new Friendsuggestion() { Idaccount = 5, Idsuggested = 33, Idsuggestedfriend = 34 });
            list.Add(new Friendsuggestion() { Idaccount = 6, Idsuggested = 44, Idsuggestedfriend = 45 });
            list.Add(new Friendsuggestion() { Idaccount = 7, Idsuggested = 15, Idsuggestedfriend = 16 });
            list.Add(new Friendsuggestion() { Idaccount = 8, Idsuggested = 25, Idsuggestedfriend = 26 });
            list.Add(new Friendsuggestion() { Idaccount = 9, Idsuggested = 35, Idsuggestedfriend = 36 });
           
            list.Add(new Friendsuggestion() { Idaccount = 10, Idsuggested = 14, Idsuggestedfriend = 25 });
            list.Add(new Friendsuggestion() { Idaccount = 11, Idsuggested = 15, Idsuggestedfriend = 12 });
            list.Add(new Friendsuggestion() { Idaccount = 12, Idsuggested = 14, Idsuggestedfriend = 23 });
            list.Add(new Friendsuggestion() { Idaccount = 13, Idsuggested = 14, Idsuggestedfriend = 27 });
            list.Add(new Friendsuggestion() { Idaccount = 14, Idsuggested = 44, Idsuggestedfriend = 24 });
            list.Add(new Friendsuggestion() { Idaccount = 15, Idsuggested = 17, Idsuggestedfriend = 18 });
            list.Add(new Friendsuggestion() { Idaccount = 16, Idsuggested = 4, Idsuggestedfriend = 17 });
            list.Add(new Friendsuggestion() { Idaccount = 17, Idsuggested = 34, Idsuggestedfriend = 15 });
            list.Add(new Friendsuggestion() { Idaccount = 18, Idsuggested = 17, Idsuggestedfriend = 47 });
            list.Add(new Friendsuggestion() { Idaccount = 19, Idsuggested = 4, Idsuggestedfriend = 22 });
            list.Add(new Friendsuggestion() { Idaccount = 20, Idsuggested = 5, Idsuggestedfriend = 11 });

            foreach (Friendsuggestion sugg in list)
            {
                sugg.Idsuggestedfriend += AccountIdOffset;
                sugg.Idsuggested += AccountIdOffset;
                sugg.Idaccount += AccountIdOffset;

                ModelsEntities.Add(sugg);
            }

            InsertCollection(ModelsEntities);
        }
    }
}
