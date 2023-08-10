using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedColour : SeedWheeloMainLogic<Colour>
    {
        public override void Insert()
        {
            List<Colour> list = new List<Colour>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}