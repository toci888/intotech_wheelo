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
        // new SeedWorkTripGen().Insert();
        new SeedRole().Insert();
        new SeedAccount().Insert();
        new SeedWorkTripGen().Insert();
        new SeedFriendSuggestion().Insert();
        new SeedFriends().Insert();
        new SeedTrip().Insert();
        new SeedTripParticipants().Insert();
        new SeedInvitation().Insert();
        // new Shit().CalcCollocations();
    }

    [TestMethod]
    public void LongLat()
    {
        //Logic<Testcoordinate> logicCoord = new Logic<Testcoordinate>();

        //Testcoordinate element = logicCoord.Select(m => true).First();
    }
}
