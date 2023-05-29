using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedOauthparty : SeedWheeloMainLogic<Oauthparty>
    {
        public override void Insert()
        {
            List<Oauthparty> list = new List<Oauthparty>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}