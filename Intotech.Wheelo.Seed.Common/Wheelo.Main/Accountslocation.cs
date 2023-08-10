using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountslocation : SeedWheeloMainLogic<Accountslocation>
    {
        public override void Insert()
        {
            List<Accountslocation> list = new List<Accountslocation>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}