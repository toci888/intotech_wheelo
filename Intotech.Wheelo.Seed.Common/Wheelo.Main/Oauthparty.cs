using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedOauthparty : SeedWheeloMainLogic<Oauthparty>
    {
        public override void Insert()
        {
            List<Oauthparty> list = new List<Oauthparty>()
            {
                new Oauthparty { Name = "PartyOne"},
                new Oauthparty { Name = "PartyTwo"}
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Oauthparty, bool>> TakeWhereCondition(Oauthparty searchValue)
        {
            return m=> m.Name == searchValue.Name;
        }
    }
}