using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedCars : SeedLogic<Car>
    {
        public override void Insert()
        {
            List<Car> cars = new List<Car>();

            cars.Add(new Car() { Idaccounts = 1, Availableseats = 3, Idcolours = 3, Idcarsbrands = 1, Idcarsmodels = 1, Registrationplate = "OPO 80F4" });
            cars.Add(new Car() { Idaccounts = 2, Availableseats = 4, Idcolours = 8, Idcarsbrands = 3, Idcarsmodels = 7, Registrationplate = "OP 1667L" });

            InsertCollection(cars);
        }
    }
}
