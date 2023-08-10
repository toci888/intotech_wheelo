using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedOccupation : SeedWheeloMainLogic<Occupation>
    {
        public override void Insert()
        {
            List<Occupation> list = new List<Occupation>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}