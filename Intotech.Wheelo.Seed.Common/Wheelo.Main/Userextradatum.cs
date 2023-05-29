using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedUserextradatum : SeedWheeloMainLogic<Userextradatum>
    {
        public override void Insert()
        {
            List<Userextradatum> list = new List<Userextradatum>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}