using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedCarsbrand : SeedWheeloMainLogic<Carsbrand>
    {
        public override void Insert()
        {
            List<Carsbrand> list = new List<Carsbrand>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}