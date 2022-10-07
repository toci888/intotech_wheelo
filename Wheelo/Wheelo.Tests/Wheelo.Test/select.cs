using System.Linq;
using Wheelo.Nfs.Database.Persistence;
using Wheelo.Nfs.Database.Persistence.Models;

namespace Wheelo.Test
{
    class select
    {
        PostgresqlRepository<User> repousers = new PostgresqlRepository<User>();
        IQueryable<User> AllUsers = repousers.Select();
        PostgresqlRepository<Userslocation> repouserlocation = new PostgresqlRepository<Userslocation>();
        IQueryable<Userslocation> allUsersLocations = repouserlocation.Select();
    }
}
