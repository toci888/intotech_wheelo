using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedPasswordsstrenght : SeedWheeloMainLogic<Passwordsstrenght>
    {
        public override void Insert()
        {
            List<Passwordsstrenght> list = new List<Passwordsstrenght>()
            {
                new Passwordsstrenght { Idaccount = 1 + AccountIdOffset, Level= 1},
                new Passwordsstrenght { Idaccount = 2 + AccountIdOffset, Level= 2},
                new Passwordsstrenght { Idaccount = 3 + AccountIdOffset, Level= 3},
                new Passwordsstrenght { Idaccount = 4 + AccountIdOffset, Level= 4},
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Passwordsstrenght, bool>> TakeWhereCondition(Passwordsstrenght searchValue)
        {
            return m=> m.Idaccount == searchValue.Idaccount;
        }
    }
}