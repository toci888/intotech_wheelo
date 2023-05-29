using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVacollocationsgeolocation : SeedWheeloMainLogic<Vacollocationsgeolocation>
    {
        public override void Insert()
        {
            List<Vacollocationsgeolocation> list = new List<Vacollocationsgeolocation>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}