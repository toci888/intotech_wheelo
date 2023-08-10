using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedPasswordsstrenght : SeedWheeloMainLogic<Passwordsstrenght>
    {
        public override void Insert()
        {
            List<Passwordsstrenght> list = new List<Passwordsstrenght>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}