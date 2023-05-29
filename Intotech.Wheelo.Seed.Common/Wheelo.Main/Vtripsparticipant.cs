using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVtripsparticipant : SeedWheeloMainLogic<Vtripsparticipant>
    {
        public override void Insert()
        {
            List<Vtripsparticipant> list = new List<Vtripsparticipant>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}