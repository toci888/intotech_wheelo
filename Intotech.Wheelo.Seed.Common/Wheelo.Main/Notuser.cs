using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedNotuser : SeedWheeloMainLogic<Notuser>
    {
        public override void Insert()
        {
            List<Notuser> list = new List<Notuser>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}