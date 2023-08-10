using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountmode : SeedWheeloMainLogic<Accountmode>
    {
        public override void Insert()
        {
            List<Accountmode> list = new List<Accountmode>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}