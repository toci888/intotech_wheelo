using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVfriendsuggestion : SeedWheeloMainLogic<Vfriendsuggestion>
    {
        public override void Insert()
        {
            List<Vfriendsuggestion> list = new List<Vfriendsuggestion>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}