using Intotech.Common.Tests;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Tests.Crap;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed;

[TestClass]
public class WheeloMainSeedManager
{
    [TestMethod]
    public void SeedAllDb()
    {
        // new SeedAutomaticCars().Insert();
        new CarsXmlParser().Insert();
        new SeedCarsModelsParser().Insert();
        new ColourTxtParser().Insert();
        new SeedRole().Insert();
        new SeedAccount().Insert();
        new SeedWorktrip().Insert();
        //new SeedCarsbrand().Insert();
        //new SeedCarsModels().Insert();
        new SeedCars().Insert();

        new Shit().CalcCollocations();
    }

    [TestMethod]
    public void LongLat()
    {
        //Logic<Testcoordinate> logicCoord = new Logic<Testcoordinate>();

        //Testcoordinate element = logicCoord.Select(m => true).First();
    }
}
