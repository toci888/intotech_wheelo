using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountslocation : SeedWheeloMainLogic<Accountslocation>
    {
        public override void Insert()
        {
            List<Accountslocation> list = new List<Accountslocation>()
            {
                new Accountslocation() {Idaccounts = 1 + AccountIdOffset, Latitudefrom = 25.858844m, Latitudeto = 2.294350m},
                new Accountslocation() {Idaccounts = 2 + AccountIdOffset, Latitudefrom = 37.858844m, Latitudeto = 16.294350m},
                new Accountslocation() {Idaccounts = 3 + AccountIdOffset, Latitudefrom = 50.858844m, Latitudeto = 3.294350m}
            };

            //TODO Here !

            InsertCollection(list);
        }

        public override Expression<Func<Accountslocation, bool>> TakeWhereCondition(Accountslocation searchValue)
        {
            return m => m.Latitudefrom == searchValue.Longitudefrom && m.Latitudefrom == m.Latitudeto;
        }
    }
}