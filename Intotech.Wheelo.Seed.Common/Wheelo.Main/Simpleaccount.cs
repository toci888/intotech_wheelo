using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedSimpleaccount : SeedWheeloMainLogic<Simpleaccount>
    {
        public override void Insert()
        {
            List<Simpleaccount> list = new List<Simpleaccount>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}