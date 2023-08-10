using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedOccupationsmokercrat : SeedWheeloMainLogic<Occupationsmokercrat>
    {
        public override void Insert()
        {
            List<Occupationsmokercrat> list = new List<Occupationsmokercrat>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}