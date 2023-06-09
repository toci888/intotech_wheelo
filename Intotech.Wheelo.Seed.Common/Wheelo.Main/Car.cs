using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedCar : SeedWheeloMainLogic<Car>
    {
        public override void Insert()
        {
            List<Car> list = new List<Car>()
            {
                new Car() { Registrationplate = "WM 5797A" }
            };

            InsertCollection(list);
        }

        public override Expression<Func<Car, bool>> TakeWhereCondition(Car searchValue)
        {
            return m => m.Registrationplate == searchValue.Registrationplate;
        }
    }

    
}