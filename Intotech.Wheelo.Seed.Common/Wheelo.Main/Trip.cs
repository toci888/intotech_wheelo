using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedTrip : SeedWheeloMainLogic<Trip>
    {
        public override void Insert()
        {
            List<Trip> list = new List<Trip>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}