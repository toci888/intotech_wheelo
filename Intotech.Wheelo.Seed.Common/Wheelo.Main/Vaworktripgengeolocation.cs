using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVaworktripgengeolocation : SeedWheeloMainLogic<Vaworktripgengeolocation>
    {
        public override void Insert()
        {
            List<Vaworktripgengeolocation> list = new List<Vaworktripgengeolocation>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}