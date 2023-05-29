using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedPushtoken : SeedWheeloMainLogic<Pushtoken>
    {
        public override void Insert()
        {
            List<Pushtoken> list = new List<Pushtoken>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}