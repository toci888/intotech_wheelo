using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedCar : SeedWheeloMainLogic<Car>
    {
        public override void Insert()
        {
            List<Car> list = new List<Car>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}