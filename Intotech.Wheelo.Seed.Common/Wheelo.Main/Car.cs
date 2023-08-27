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
                new Car() {Idaccounts = 1 + AccountIdOffset , Availableseats = 2, Registrationplate = "MBK 1320A", Createdat = DateTime.Now, Idcarsbrands = 0,
                 Idcarsmodels = 0, Idcolours = 0},
                new Car() { Idaccounts = 2 + AccountIdOffset, Availableseats = 2, Registrationplate = "RNI KA93", Createdat = DateTime.Now, Idcarsbrands = 1,
                 Idcarsmodels = 1, Idcolours = 1},
                new Car() {Idaccounts = 3 + AccountIdOffset, Availableseats = 2, Registrationplate = "WMZ MK20", Createdat = DateTime.Now, Idcarsbrands = 2,
                 Idcarsmodels = 2, Idcolours = 2}
            };

            InsertCollection(list);
        }

        public override Expression<Func<Car, bool>> TakeWhereCondition(Car searchValue)
        {
            return m => m.Registrationplate == searchValue.Registrationplate;
        }
    }

    
}