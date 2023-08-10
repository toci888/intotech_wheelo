using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedStatsprovider : SeedWheeloMainLogic<Statsprovider>
    {
        public override void Insert()
        {
            List<Statsprovider> list = new List<Statsprovider>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}