using System.Linq.Expressions;
using System.Xml.Linq;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVaworktripgengeolocation : SeedWheeloMainLogic<Vaworktripgengeolocation>
    {
        public override void Insert()
        {
            List<Vaworktripgengeolocation> list = new List<Vaworktripgengeolocation>()
            {
                new Vaworktripgengeolocation { Accountid = 1 + AccountIdOffset, Fromhour = new TimeOnly(4,0,0), Tohour = new TimeOnly(15,30,0),
                Name = "Jan", Surname = "Kowalski", Latitudefrom = 52.2297, Longitudefrom = 21.0122, Latitudeto = 50.0647, Longitudeto = 19.9450,
                Isdriver = 1, Searchid = "searchId1" , Image ="image1.png"},

                new Vaworktripgengeolocation { Accountid = 2 + AccountIdOffset, Fromhour = new TimeOnly(7,30,0), Tohour = new TimeOnly(8,30,0),
                Name = "Szczepan", Surname = "Kozdra", Latitudefrom = 40.2227, Longitudefrom = 15.0122, Latitudeto = 60.0647, Longitudeto = 21.9450,
                Isdriver = 0, Searchid = "searchId2" , Image ="image2.png"},

                new Vaworktripgengeolocation { Accountid = 3 + AccountIdOffset, Fromhour = new TimeOnly(12,45,0), Tohour = new TimeOnly(16,23,0),
                Name = "Zbyszek", Surname = "Zybura", Latitudefrom = 10.2297, Longitudefrom = 24.0122, Latitudeto = 59.0647, Longitudeto = 11.9450,
                Isdriver = 1, Searchid = "searchId3" , Image ="image3.png"},

                new Vaworktripgengeolocation { Accountid = 4 + AccountIdOffset, Fromhour = new TimeOnly(18,0,0), Tohour = new TimeOnly(21,32,0),
                Name = "Staszek", Surname = "Zurawski", Latitudefrom = 52.2297, Longitudefrom = 21.0122, Latitudeto = 42.0647, Longitudeto = 45.9450,
                Isdriver = 0, Searchid = "searchId4" , Image ="image4.png"},
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Vaworktripgengeolocation, bool>> TakeWhereCondition(Vaworktripgengeolocation searchValue)
        {
            return m => m.Accountid == searchValue.Accountid;
        }
    }
}