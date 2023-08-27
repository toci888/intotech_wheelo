using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountscollocation : SeedWheeloMainLogic<Accountscollocation>
    {
        public override void Insert()
        {
            List<Accountscollocation> list = new List<Accountscollocation>()
            {
                new Accountscollocation(){Idaccount = 1 + AccountIdOffset, Createdat = DateTime.Now, Distancefrom = 10.4m, Distanceto = 1233.3m, Idcollocated = 0},
                new Accountscollocation(){Idaccount = 2 + AccountIdOffset , Createdat = DateTime.Now, Distancefrom = 15.4m, Distanceto = 1000.3m, Idcollocated = 1},
                new Accountscollocation(){Idaccount = 3 + AccountIdOffset, Createdat = DateTime.Now, Distancefrom = 50.3m, Distanceto = 1508.3m, Idcollocated = 2}
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Accountscollocation, bool>> TakeWhereCondition(Accountscollocation searchValue)
        {
            return m => true; // m.Idaccount == searchValue.Idaccount; ??
        }
    }
}