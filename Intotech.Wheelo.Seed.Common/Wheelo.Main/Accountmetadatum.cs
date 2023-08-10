using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountmetadatum : SeedWheeloMainLogic<Accountmetadatum>
    {
        public override void Insert()
        {
            List<Accountmetadatum> list = new List<Accountmetadatum>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}