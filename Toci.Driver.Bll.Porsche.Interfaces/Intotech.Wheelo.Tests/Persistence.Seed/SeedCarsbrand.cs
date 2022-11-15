using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedCarsbrand : SeedLogic<Carsbrand>
    {
        public override void Insert()
        {
            List<Carsbrand> cars = new List<Carsbrand>()
            {
                new Carsbrand() { Brand = "Skoda" },
                new Carsbrand() { Brand = "Polonez" },
                new Carsbrand() { Brand = "Nissan" },
                new Carsbrand() { Brand = "Volkswagen" },
                new Carsbrand() { Brand = "Toyota" },
            };

            InsertCollection(cars);
        }
    }
}
