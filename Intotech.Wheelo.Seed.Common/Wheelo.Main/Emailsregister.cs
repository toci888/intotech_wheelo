using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedEmailsregister : SeedWheeloMainLogic<Emailsregister>
    {
        public override void Insert()
        {
            List<Emailsregister> list = new List<Emailsregister>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}