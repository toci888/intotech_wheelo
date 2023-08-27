using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedPasswordstrength : SeedWheeloMainLogic<Passwordstrength>
    {
        public override void Insert()
        {
            List<Passwordstrength> list = new List<Passwordstrength>()
            {
                new Passwordstrength() { Idaccount =  1 + AccountIdOffset, Level = 1},
                new Passwordstrength() { Idaccount =  2 + AccountIdOffset, Level = 2},
                new Passwordstrength() { Idaccount =  3 + AccountIdOffset, Level = 3},
                new Passwordstrength() { Idaccount =  4 + AccountIdOffset, Level = 4},
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Passwordstrength, bool>> TakeWhereCondition(Passwordstrength searchValue)
        {
            return m => m.Idaccount == searchValue.Idaccount;
        }
    }
}