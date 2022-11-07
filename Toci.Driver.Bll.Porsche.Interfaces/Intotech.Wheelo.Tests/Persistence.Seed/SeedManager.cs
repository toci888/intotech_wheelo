using Intotech.Common.Tests;
using Intotech.Wheelo.Bll.Persistence;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed;

[TestClass]
public class SeedManager
{
    [TestMethod]
    public void SeedAllDb()
    {
        new SeedRole().Insert();
        new SeedAccount().Insert();
        new SeedWorktrip().Insert();
    }

    [TestMethod]
    public void LongLat()
    {
        //Logic<Testcoordinate> logicCoord = new Logic<Testcoordinate>();

        //Testcoordinate element = logicCoord.Select(m => true).First();
    }
}
