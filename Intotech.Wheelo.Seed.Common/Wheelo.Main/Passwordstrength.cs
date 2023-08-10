using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedPasswordstrength : SeedWheeloMainLogic<Passwordstrength>
    {
        public override void Insert()
        {
            List<Passwordstrength> list = new List<Passwordstrength>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}