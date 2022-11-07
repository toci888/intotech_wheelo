using Intotech.Common.Tests;

namespace Intotech.Wheelo.Tests.Persistence.Seed;

[TestClass]
public class SeedManager
{
    [TestMethod]
    public void SeedAllDb()
    {
        new SeedRole().Insert();
    }
}
