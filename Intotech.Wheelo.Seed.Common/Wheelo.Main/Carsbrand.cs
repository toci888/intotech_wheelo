using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedCarsbrand : SeedWheeloMainLogic<Carsbrand>
    {
        public override void Insert()
        {
            List<Carsbrand> list = new List<Carsbrand>()
            {
                new Carsbrand {Brand = "Opel",},
                new Carsbrand {Brand = "Volkswagen"},
                new Carsbrand {Brand = "Nissan"}
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Carsbrand, bool>> TakeWhereCondition(Carsbrand searchValue)
        {
            return m=> m.Brand == searchValue.Brand;
        }
    }
}