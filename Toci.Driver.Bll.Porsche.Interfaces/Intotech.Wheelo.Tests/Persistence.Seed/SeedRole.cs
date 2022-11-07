using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed;

public class SeedRole : SeedLogic<Role>
{
    public override void Insert()
    {
        List<Role> collection = new List<Role>()
        {
            new Role(){ Name = "User" },
            new Role(){ Name = "Admin" },
        };

        base.InsertCollection(collection);
    }
}