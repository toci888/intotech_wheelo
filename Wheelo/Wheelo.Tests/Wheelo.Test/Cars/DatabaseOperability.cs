using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheelo.Nfs.Database.Persistence;
using Wheelo.Nfs.Database.Persistence.Models;

namespace Wheelo.Test.Cars
{
    public class DatabaseOperability
    {

        

        public int Reptile(Dictionary<string, List<CarEntity>> skrillex)
        {

            PostgresqlRepository<Carsbrand> repouser = new PostgresqlRepository<Carsbrand>();

            foreach (KeyValuePair<string, List<CarEntity>> item in skrillex)
            {
                Carsbrand ent = createCarEntity(item.Value.First());

                repouser.Insert(ent);

            }


            /* [ foreach (  )
                    { BMW,  List< CarEntity, CarEntity, CarEntity ... > }, 
                    { Seat,  List< CarEntity, CarEntity, CarEntity ... > } 
               ]
            */

            return 1;
        }

        protected Carsbrand createCarEntity(CarEntity carek)
        {

            Carsbrand c = new Carsbrand();

            c.Brand = carek.make;

            return c;
            // {"year": 2016, "id": 1, "horsepower": 201, "make": "acura", "model": "ilx", "price": 31890.0, "img_url": "ht.1"}
            /*
                public Carsbrand()
                {
                    Cars = new HashSet<Car>();
                    Carsmodels = new HashSet<Carsmodel>();
                }

                public int Id { get; set; }
                public string Brand { get; set; }

                public virtual ICollection<Car> Cars { get; set; }
                public virtual ICollection<Carsmodel> Carsmodels { get; set; }
            */
        }




    }
}
