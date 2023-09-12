using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedFriend : SeedWheeloMainLogic<Friend>
    {
        public override void Insert()
        {
            List<Friend> list = new List<Friend>();

            //TODO Here !
            list.Add(new Friend()
            {
                Idaccount = 1000000001,
                Idfriend = 1000000002
            });

            InsertCollection(list);
        }
    }
}