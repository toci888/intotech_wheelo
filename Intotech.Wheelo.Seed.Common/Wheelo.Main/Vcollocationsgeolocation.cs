using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVcollocationsgeolocation : SeedWheeloMainLogic<Vcollocationsgeolocation>
    {
        public override void Insert()
        {
            List<Vcollocationsgeolocation> list = new List<Vcollocationsgeolocation>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}