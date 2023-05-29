using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedInvitation : SeedWheeloMainLogic<Invitation>
    {
        public override void Insert()
        {
            List<Invitation> list = new List<Invitation>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}