using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedCarsModels : SeedLogic<Carsmodel>
    {
        public override void Insert()
        {
            List<Carsmodel> cars = new List<Carsmodel>()
            {
                new Carsmodel() { Idcarsbrands = 1, Model = "Fabia" },
                new Carsmodel() { Idcarsbrands = 1, Model = "Octavia" },
                new Carsmodel() { Idcarsbrands = 1, Model = "Superb" },
                new Carsmodel() { Idcarsbrands = 1, Model = "Kodiaq" },
                new Carsmodel() { Idcarsbrands = 2, Model = "Caro Plus" },
                new Carsmodel() { Idcarsbrands = 2, Model = "Caro" },
                new Carsmodel() { Idcarsbrands = 3, Model = "Primera" },
                new Carsmodel() { Idcarsbrands = 3, Model = "Micra" },
                new Carsmodel() { Idcarsbrands = 3, Model = "Almera" },
                new Carsmodel() { Idcarsbrands = 4, Model = "Golf" },
                new Carsmodel() { Idcarsbrands = 4, Model = "Passat" },
                new Carsmodel() { Idcarsbrands = 4, Model = "Arteon" },
                new Carsmodel() { Idcarsbrands = 5, Model = "Corolla"},
                new Carsmodel() { Idcarsbrands = 5, Model = "Aygo"},
            };

            InsertCollection(cars);
        }
    }
}
