using Intotech.Common.Database.DbSetup;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class WheeloMainSeedManager : SeedManagerBase<IntotechWheeloContext>
    {
        public WheeloMainSeedManager() : base(new IntotechWheeloContext())
        {
            AddSeedRole();
        }

        protected virtual void AddSeedRole()
        {
            SeedHandler seedRole = new SeedHandler(DbContext);

            seedRole.AddEntity(new Role() { Name = "User" });
            seedRole.AddEntity(new Role() { Name = "Admin" });

            SeedHandlers.Add(seedRole);
        }
    }
}