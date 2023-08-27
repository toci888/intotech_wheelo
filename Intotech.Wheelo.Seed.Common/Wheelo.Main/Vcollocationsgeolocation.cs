using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVcollocationsgeolocation : SeedWheeloMainLogic<Vcollocationsgeolocation>
    {
        public override void Insert()
        {
            List<Vcollocationsgeolocation> list = new List<Vcollocationsgeolocation>()
            {
                new Vcollocationsgeolocation() { Idaccount = 1 + AccountIdOffset, Name = "Jan", Surname = "Kowalski", Latitudefrom = 52.2297,
                    Longitudefrom = 21.0122, Latitudeto = 52.2370, Longitudeto = 21.0175, Fromhour = new TimeOnly(8, 0), Tohour = new TimeOnly(16, 0),
                    Searchid = "ABC123",  Driverpassenger = 1, Image = "image1.jpg"},

                new Vcollocationsgeolocation() { Idaccount = 2 + AccountIdOffset, Name = "Anna", Surname = "Nowak", Latitudefrom = 50.0647,
                    Longitudefrom = 24.0122, Latitudeto = 55.2370, Longitudeto = 26.0175, Fromhour = new TimeOnly(3, 0), Tohour = new TimeOnly(6, 0),
                    Searchid = "DEF456",  Driverpassenger = 0, Image = "image2.jpg"},

                new Vcollocationsgeolocation() { Idaccount = 3 + AccountIdOffset, Name = "Piotr", Surname = "Burak", Latitudefrom = 43.2297,
                    Longitudefrom = 54.0122, Latitudeto = 12.2370, Longitudeto = 56.0175, Fromhour = new TimeOnly(21, 0), Tohour = new TimeOnly(3, 0),
                    Searchid = "HNJ903",  Driverpassenger = 1, Image = "image3.jpg"},

                new Vcollocationsgeolocation() { Idaccount = 4 + AccountIdOffset, Name = "Jan", Surname = "Kowalski", Latitudefrom = 52.2297,
                    Longitudefrom = 21.0122, Latitudeto = 68.2370, Longitudeto = 25.0175, Fromhour = new TimeOnly(5, 30), Tohour = new TimeOnly(8, 43),
                    Searchid = "MND136",  Driverpassenger = 0, Image = "image4.jpg"}
            };

            //TODO Here !

            InsertCollection(list);
        }

        public override Expression<Func<Vcollocationsgeolocation, bool>> TakeWhereCondition(Vcollocationsgeolocation searchValue)
        {
            return m => m.Idaccount == searchValue.Idaccount;
        }
    }
}