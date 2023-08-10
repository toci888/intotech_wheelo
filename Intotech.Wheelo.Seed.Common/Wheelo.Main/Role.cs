using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedRole : SeedWheeloMainLogic<Role>
    {
        public override void Insert()
        {
            List<Role> list = new List<Role>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}