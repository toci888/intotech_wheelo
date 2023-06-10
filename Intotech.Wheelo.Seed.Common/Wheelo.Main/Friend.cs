using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedFriend : SeedWheeloMainLogic<Friend>
    {
        public override void Insert()
        {
            List<Friend> list = new List<Friend>()
            {
                new Friend() { Idaccount = 1 + AccountIdOffset, Idfriend = 11 },
                new Friend() { Idaccount = 2 + AccountIdOffset, Idfriend = 12 },
                new Friend() { Idaccount = 3 + AccountIdOffset, Idfriend = 13 },
                new Friend() { Idaccount = 4 + AccountIdOffset, Idfriend = 14 },
                new Friend() { Idaccount = 5 + AccountIdOffset, Idfriend = 15 },
                new Friend() { Idaccount = 6 + AccountIdOffset, Idfriend = 16 },
                new Friend() { Idaccount = 7 + AccountIdOffset, Idfriend = 17 },
                new Friend() { Idaccount = 8 + AccountIdOffset, Idfriend = 18 },
                new Friend() { Idaccount = 9 + AccountIdOffset, Idfriend = 19 },
                new Friend() { Idaccount = 31 + AccountIdOffset, Idfriend = 41 },
                new Friend() { Idaccount = 32 + AccountIdOffset, Idfriend = 42 },
                new Friend() { Idaccount = 33 + AccountIdOffset, Idfriend = 43 },
                new Friend() { Idaccount = 34 + AccountIdOffset, Idfriend = 44 },
                new Friend() { Idaccount = 35 + AccountIdOffset, Idfriend = 45 },
                new Friend() { Idaccount = 36 + AccountIdOffset, Idfriend = 46 },
                new Friend() { Idaccount = 37 + AccountIdOffset, Idfriend = 47 },
                new Friend() { Idaccount = 38 + AccountIdOffset, Idfriend = 48 }
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Friend, bool>> TakeWhereCondition(Friend searchValue)
        {
            return m=> m.Idaccount == searchValue.Idaccount && m.Idfriend == searchValue.Idfriend;
        }
    }
}