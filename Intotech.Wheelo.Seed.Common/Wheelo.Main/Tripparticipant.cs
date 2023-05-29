using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedTripparticipant : SeedWheeloMainLogic<Tripparticipant>
    {
        public override void Insert()
        {
            List<Tripparticipant> list = new List<Tripparticipant>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}