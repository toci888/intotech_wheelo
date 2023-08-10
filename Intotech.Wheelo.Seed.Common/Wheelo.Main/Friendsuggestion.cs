using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedFriendsuggestion : SeedWheeloMainLogic<Friendsuggestion>
    {
        public override void Insert()
        {
            List<Friendsuggestion> list = new List<Friendsuggestion>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}