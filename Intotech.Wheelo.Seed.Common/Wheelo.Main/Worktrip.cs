using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedWorktrip : SeedWheeloMainLogic<Worktrip>
    {
        public override void Insert()
        {
            List<Worktrip> list = new List<Worktrip>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}