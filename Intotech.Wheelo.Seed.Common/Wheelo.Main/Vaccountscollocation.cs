using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVaccountscollocation : SeedWheeloMainLogic<Vaccountscollocation>
    {
        public override void Insert()
        {
            List<Vaccountscollocation> list = new List<Vaccountscollocation>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}