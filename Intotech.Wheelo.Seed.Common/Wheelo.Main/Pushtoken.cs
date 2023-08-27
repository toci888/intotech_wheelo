using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedPushtoken : SeedWheeloMainLogic<Pushtoken>
    {
        public override void Insert()
        {
            List<Pushtoken> list = new List<Pushtoken>()
            {
                new Pushtoken() { Idaccount = 1 + AccountIdOffset, Token =  "ABC123XYZ456"},
                new Pushtoken() { Idaccount = 2 + AccountIdOffset, Token =  "DEF789UVW123"},
                new Pushtoken() { Idaccount = 3 + AccountIdOffset, Token =  "GHI456JKL789"},
                new Pushtoken() { Idaccount = 4 + AccountIdOffset, Token =  "MNO123PQR456"},

            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Pushtoken, bool>> TakeWhereCondition(Pushtoken searchValue)
        {
            return m=> m.Token == searchValue.Token;
        }
    }
}