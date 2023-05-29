using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccount : SeedWheeloMainLogic<Account>
    {
        public override void Insert()
        {
            List<Account> list = new List<Account>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}