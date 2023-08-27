using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountmetadatum : SeedWheeloMainLogic<Accountmetadatum>
    {
        public override void Insert()
        {
            List<Accountmetadatum> list = new List<Accountmetadatum>()
            {
                new Accountmetadatum {Idaccount = 1 + AccountIdOffset, Createdat = DateTime.UtcNow, Pesel = "11122233344"},
                new Accountmetadatum {Idaccount = 2 + AccountIdOffset, Createdat = DateTime.UtcNow, Pesel = "44433322211"},
                new Accountmetadatum {Idaccount = 3 + AccountIdOffset , Createdat = DateTime.UtcNow, Pesel = "99988877744"}
            };

            //TODO Here !

            InsertCollection(list);
        }

        public override Expression<Func<Accountmetadatum, bool>> TakeWhereCondition(Accountmetadatum searchValue)
        {
            return m => m.Pesel == searchValue.Pesel;
        }
    }
}