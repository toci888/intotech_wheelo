using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedOccupationsmokercrat : SeedWheeloMainLogic<Occupationsmokercrat>
    {
        public override void Insert()
        {
            List<Occupationsmokercrat> list = new List<Occupationsmokercrat>()
            {
                new Occupationsmokercrat { Idaccount = 1 + AccountIdOffset, Idoccupation = 2, Issmoker = true },
                new Occupationsmokercrat { Idaccount = 2 + AccountIdOffset, Idoccupation = 4, Issmoker = false},
                new Occupationsmokercrat { Idaccount = 3 + AccountIdOffset, Idoccupation = 1, Issmoker = true },
            };

            //TODO Here !

            InsertCollection(list);

        }
        public override Expression<Func<Occupationsmokercrat, bool>> TakeWhereCondition(Occupationsmokercrat searchValue)
        {
            return m=> m.Idaccount == searchValue.Idaccount && m.Idoccupation == searchValue.Idoccupation;
        }
    }
}