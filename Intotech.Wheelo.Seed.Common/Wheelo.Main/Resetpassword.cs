using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedResetpassword : SeedWheeloMainLogic<Resetpassword>
    {
        public override void Insert()
        {
            List<Resetpassword> list = new List<Resetpassword>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}