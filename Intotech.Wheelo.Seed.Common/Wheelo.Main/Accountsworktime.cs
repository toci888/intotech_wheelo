using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountsworktime : SeedWheeloMainLogic<Accountsworktime>
    {
        public override void Insert()
        {
            List<Accountsworktime> list = new List<Accountsworktime>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}