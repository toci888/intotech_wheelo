using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedFriendsuggestion : SeedWheeloMainLogic<Friendsuggestion>
    {
        public override void Insert()
        {
            List<Friendsuggestion> list = new List<Friendsuggestion>();
            list.Add(new Friendsuggestion() { Idaccount = 1 + AccountIdOffset, Idsuggested = 14, Idsuggestedfriend = 23 });
            list.Add(new Friendsuggestion() { Idaccount = 2 + AccountIdOffset, Idsuggested = 13, Idsuggestedfriend = 22 });
            list.Add(new Friendsuggestion() { Idaccount = 3 + AccountIdOffset, Idsuggested = 11, Idsuggestedfriend = 12 });
            list.Add(new Friendsuggestion() { Idaccount = 4 + AccountIdOffset, Idsuggested = 22, Idsuggestedfriend = 23 });
            list.Add(new Friendsuggestion() { Idaccount = 5 + AccountIdOffset, Idsuggested = 33, Idsuggestedfriend = 34 });
            list.Add(new Friendsuggestion() { Idaccount = 6 + AccountIdOffset, Idsuggested = 44, Idsuggestedfriend = 45 });
            list.Add(new Friendsuggestion() { Idaccount = 7 + AccountIdOffset, Idsuggested = 15, Idsuggestedfriend = 16 });
            list.Add(new Friendsuggestion() { Idaccount = 8 + AccountIdOffset, Idsuggested = 25, Idsuggestedfriend = 26 });
            list.Add(new Friendsuggestion() { Idaccount = 9 + AccountIdOffset, Idsuggested = 35, Idsuggestedfriend = 36 });

            list.Add(new Friendsuggestion() { Idaccount = 10 + AccountIdOffset, Idsuggested = 14, Idsuggestedfriend = 25 });
            list.Add(new Friendsuggestion() { Idaccount = 11 + AccountIdOffset, Idsuggested = 15, Idsuggestedfriend = 12 });
            list.Add(new Friendsuggestion() { Idaccount = 12 + AccountIdOffset, Idsuggested = 14, Idsuggestedfriend = 23 });
            list.Add(new Friendsuggestion() { Idaccount = 13 + AccountIdOffset, Idsuggested = 14, Idsuggestedfriend = 27 });
            list.Add(new Friendsuggestion() { Idaccount = 14 + AccountIdOffset, Idsuggested = 44, Idsuggestedfriend = 24 });
            list.Add(new Friendsuggestion() { Idaccount = 15 + AccountIdOffset, Idsuggested = 17, Idsuggestedfriend = 18 });
            list.Add(new Friendsuggestion() { Idaccount = 16 + AccountIdOffset, Idsuggested = 4, Idsuggestedfriend = 17 });
            list.Add(new Friendsuggestion() { Idaccount = 17 + AccountIdOffset, Idsuggested = 34, Idsuggestedfriend = 15 });
            list.Add(new Friendsuggestion() { Idaccount = 18 + AccountIdOffset, Idsuggested = 17, Idsuggestedfriend = 47 });
            list.Add(new Friendsuggestion() { Idaccount = 19 + AccountIdOffset, Idsuggested = 4, Idsuggestedfriend = 22 });
            list.Add(new Friendsuggestion() { Idaccount = 20 + AccountIdOffset, Idsuggested = 5, Idsuggestedfriend = 11 });


            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Friendsuggestion, bool>> TakeWhereCondition(Friendsuggestion searchValue)
        {
            return m=> m.Idaccount == searchValue.Idaccount && m.Idsuggested == searchValue.Idsuggested && m.Idsuggestedfriend == searchValue.Idsuggestedfriend;
        }
    }
}