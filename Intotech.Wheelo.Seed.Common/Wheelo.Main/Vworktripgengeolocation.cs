using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVworktripgengeolocation : SeedWheeloMainLogic<Vworktripgengeolocation>
    {
        public override void Insert()
        {
            List<Vworktripgengeolocation> list = new List<Vworktripgengeolocation>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}