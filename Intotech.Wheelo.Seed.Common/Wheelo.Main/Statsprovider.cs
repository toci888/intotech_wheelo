using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedStatsprovider : SeedWheeloMainLogic<Statsprovider>
    {
        public override void Insert()
        {
            List<Statsprovider> list = new List<Statsprovider>()
            {
                new Statsprovider() { Tripdate = new DateOnly(2023, 6, 15), Countcars = 1, Countpeople = 1 },
                new Statsprovider() { Tripdate = new DateOnly(2023, 2, 3), Countcars = 2, Countpeople = 3 },
                new Statsprovider() { Tripdate = new DateOnly(2023, 6, 12), Countcars = 5, Countpeople = 15 },
                new Statsprovider() { Tripdate = new DateOnly(2023, 1, 7), Countcars = 10, Countpeople = 2 },
            };


            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Statsprovider, bool>> TakeWhereCondition(Statsprovider searchValue)
        {
            return m=> m.Tripdate == searchValue.Tripdate; // Czy filtrujemy po dniach?
        }
    }
}