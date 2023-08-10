using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedGeographicregion : SeedWheeloMainLogic<Geographicregion>
    {
        public override void Insert()
        {
            List<Geographicregion> list = new List<Geographicregion>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}