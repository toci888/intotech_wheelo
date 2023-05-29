using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVinvitation : SeedWheeloMainLogic<Vinvitation>
    {
        public override void Insert()
        {
            List<Vinvitation> list = new List<Vinvitation>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}