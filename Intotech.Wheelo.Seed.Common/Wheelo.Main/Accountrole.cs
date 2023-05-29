using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountrole : SeedWheeloMainLogic<Accountrole>
    {
        public override void Insert()
        {
            List<Accountrole> list = new List<Accountrole>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}