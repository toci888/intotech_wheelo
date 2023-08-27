using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVworktripgengeolocation : SeedWheeloMainLogic<Vworktripgengeolocation>
    {
        public override void Insert()
        {
            List<Vworktripgengeolocation> list = new List<Vworktripgengeolocation>()
            {
                new Vworktripgengeolocation() { Idaccount = 1 + AccountIdOffset, Accountidcollocated = 2, Name = "Jan", Surname = "Kowalski",
                                                Latitudefrom = 52.2297, Longitudefrom = 21.0122, Latitudeto = 50.0647, Longitudeto = 19.9450,
                                                Fromhour = new TimeOnly(9, 0, 0), Tohour = new TimeOnly(17, 0, 0), Searchid = "ABC123"},

                new Vworktripgengeolocation() { Idaccount = 3 + AccountIdOffset,  Accountidcollocated = 4, Name = "Anna", Surname = "Nowak",
                                                Latitudefrom = 48.8566, Longitudefrom = 2.3522, Latitudeto = 51.5074, Longitudeto = -0.1278,
                                                Fromhour = new TimeOnly(8, 30, 0), Tohour = new TimeOnly(16, 30, 0), Searchid = "DEF456"},

                new Vworktripgengeolocation() { Idaccount = 5 + AccountIdOffset, Accountidcollocated = 6, Name = "Maria", Surname = "Wójcik",
                                                Latitudefrom = 40.7128, Longitudefrom = -74.0060, Latitudeto = 34.0522, Longitudeto = -118.2437,
                                                Fromhour = new TimeOnly(10, 0, 0), Tohour = new TimeOnly(18, 0, 0), Searchid = "GHI789"},

                new Vworktripgengeolocation() { Idaccount = 7 + AccountIdOffset, Accountidcollocated = 8, Name = "Piotr", Surname = "Kowalczyk",
                                                Latitudefrom = 45.4215, Longitudefrom = -75.6981, Latitudeto = 43.6532, Longitudeto = -79.3832,
                                                Fromhour = new TimeOnly(9, 30, 0), Tohour = new TimeOnly(17, 30, 0), Searchid = "JKL012"}
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Vworktripgengeolocation, bool>> TakeWhereCondition(Vworktripgengeolocation searchValue)
        {
            return m => m.Searchid == searchValue.Searchid;
        }
    }
}