using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedCarsmodel : SeedWheeloMainLogic<Carsmodel>
    {
        public override void Insert()
        {
            List<Carsmodel> list = new List<Carsmodel>()
            {
                new Carsmodel {Model = "Vectra", Idcarsbrands = 0},
                new Carsmodel {Model = "Astra", Idcarsbrands = 0},
                new Carsmodel {Model = "Passat", Idcarsbrands = 1},
                new Carsmodel {Model = "Polo", Idcarsbrands = 1},
                new Carsmodel {Model = "Micra", Idcarsbrands = 2},
                new Carsmodel {Model = "Leaf", Idcarsbrands = 2}

            };

            //TODO Here !

            InsertCollection(list);
        }

        public override Expression<Func<Carsmodel, bool>> TakeWhereCondition(Carsmodel searchValue)
        {
            return m=> m.Model == searchValue.Model;
        }
    }
}