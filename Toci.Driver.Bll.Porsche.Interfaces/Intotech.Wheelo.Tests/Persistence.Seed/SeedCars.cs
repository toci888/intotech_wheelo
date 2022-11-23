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
            cars.Add(new Car() { Idaccounts = 2, Availableseats = 2, Idcolours = 13, Idcarsbrands = 36, Idcarsmodels = 239, Registrationplate = "ZAK 4567L" });
            cars.Add(new Car() { Idaccounts = 2, Availableseats = 2, Idcolours = 38, Idcarsbrands = 36, Idcarsmodels = 240, Registrationplate = "KRA 2435P" });
            cars.Add(new Car() { Idaccounts = 2, Availableseats = 2, Idcolours = 31, Idcarsbrands = 36, Idcarsmodels = 241, Registrationplate = "KAT 4532A" });
            cars.Add(new Car() { Idaccounts = 2, Availableseats = 4, Idcolours = 8, Idcarsbrands = 197, Idcarsmodels = 1864, Registrationplate = "GDA 9986K" });
            cars.Add(new Car() { Idaccounts = 2, Availableseats = 4, Idcolours = 45, Idcarsbrands = 197, Idcarsmodels = 1865, Registrationplate = "WAW 3434B" });
            cars.Add(new Car() { Idaccounts = 2, Availableseats = 2, Idcolours = 43, Idcarsbrands = 197, Idcarsmodels = 1866, Registrationplate = "BIA 5432Z" });
            cars.Add(new Car() { Idaccounts = 2, Availableseats = 2, Idcolours = 8, Idcarsbrands = 628, Idcarsmodels = 82, Registrationplate = "WRO 1234D" });
            cars.Add(new Car() { Idaccounts = 2, Availableseats = 2, Idcolours = 2, Idcarsbrands = 9, Idcarsmodels = 2403, Registrationplate = "SZC 1453Z" });
            //9

            InsertCollection(cars);
        }
    }
}
