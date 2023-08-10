using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedCarsmodel : SeedWheeloMainLogic<Carsmodel>
    {
        public override void Insert()
        {
            List<Carsmodel> list = new List<Carsmodel>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}