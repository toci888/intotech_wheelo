using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVfriend : SeedWheeloMainLogic<Vfriend>
    {
        public override void Insert()
        {
            List<Vfriend> list = new List<Vfriend>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}