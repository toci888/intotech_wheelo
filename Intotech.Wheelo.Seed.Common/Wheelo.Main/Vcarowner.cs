using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVcarowner : SeedWheeloMainLogic<Vcarowner>
    {
        public override void Insert()
        {
            List<Vcarowner> list = new List<Vcarowner>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}