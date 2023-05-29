using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountscarslocation : SeedWheeloMainLogic<Accountscarslocation>
    {
        public override void Insert()
        {
            List<Accountscarslocation> list = new List<Accountscarslocation>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}