using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedRole : SeedWheeloMainLogic<Role>
    {
        public override void Insert()
        {
            List<Role> list = new List<Role>()
            {
                new Role() { Name = "Admin"},
                new Role() { Name = "Moderator"},
                new Role() { Name = "User"},
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Role, bool>> TakeWhereCondition(Role searchValue)
        {
            return m=> m.Name == searchValue.Name;
        }
    }
}