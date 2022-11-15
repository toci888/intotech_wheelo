using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    internal class SeedAutomaticCars : SeedLogic<Carsbrand>
    {
        public override void Insert()
        {
            List<Carsbrand> carsBr = new List<Carsbrand>();

            CarsTxtParser carsTxtParser = new CarsTxtParser();

            List<string> cars = carsTxtParser.GetCarsBrands("");

            foreach (string item in cars)
            {
                carsBr.Add(new Carsbrand() { Brand = item });
            }

            InsertCollection(carsBr);
        }
    }
}
