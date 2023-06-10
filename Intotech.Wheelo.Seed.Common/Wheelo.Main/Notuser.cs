using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedNotuser : SeedWheeloMainLogic<Notuser>
    {
        public override void Insert()
        {
            List<Notuser> list = new List<Notuser>()
            {
                new Notuser() { Searchid = "abc123"},
                new Notuser() { Searchid = "def456" }
            };

            //TODO Here !

            InsertCollection(list);
        }

        public override Expression<Func<Notuser, bool>> TakeWhereCondition(Notuser searchValue)
        {
            return m=> m.Searchid == searchValue.Searchid ;
        }
    }
}