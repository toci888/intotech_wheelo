using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountscollocation : SeedWheeloMainLogic<Accountscollocation>
    {
        public override void Insert()
        {
            List<Accountscollocation> list = new List<Accountscollocation>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}