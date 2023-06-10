using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVacollocationsgeolocation : SeedWheeloMainLogic<Vacollocationsgeolocation>
    {
        public override void Insert()
        {
            List<Vacollocationsgeolocation> list = new List<Vacollocationsgeolocation>()
            {
                new Vacollocationsgeolocation { Idaccount = 1 + AccountIdOffset, Accountidcollocated = 2, Name = "Jan", Surname = "Kowalski", Namecollocated = "Anna",
                    Surnamecollocated = "Nowak", Latitudefrom = 52.2297, Longitudefrom = 21.0122, Latitudeto = 50.0647, Longitudeto = 19.9450,
                    Fromhour = new TimeOnly(8, 0, 0), Tohour = new TimeOnly(16, 0, 0), Searchid = "ABC123", Isdriver = 1, Image = "obraz1.jpg"},

                new Vacollocationsgeolocation { Idaccount = 2 + AccountIdOffset, Accountidcollocated = 4, Name = "Maria", Surname = "Nowak",
                    Namecollocated = "Janusz", Surnamecollocated = "Kowalczyk", Latitudefrom = 51.2195, Longitudefrom = 19.1451, Latitudeto = 53.4289,
                    Longitudeto = 14.5530, Fromhour = new TimeOnly(9, 0, 0), Tohour = new TimeOnly(17, 0, 0), Searchid = "DEF456", Isdriver = 0,
                    Image = "obraz2.jpg"},

                new Vacollocationsgeolocation {Idaccount = 3 + AccountIdOffset, Accountidcollocated = 6, Name = "Piotr", Surname = "Wójcik",
                    Namecollocated = "Magda", Surnamecollocated = "Kowalska", Latitudefrom = 54.3520,  Longitudefrom = 18.6466, Latitudeto = 52.2370,
                    Longitudeto = 21.0175, Fromhour = new TimeOnly(10, 0, 0), Tohour = new TimeOnly(18, 0, 0), Searchid = "GHI789", Isdriver = 1,
                    Image = "obraz3.jpg"}
            };

            //TODO Here !

            InsertCollection(list);
        }

        public override Expression<Func<Vacollocationsgeolocation, bool>> TakeWhereCondition(Vacollocationsgeolocation searchValue)
        {
            return m => m.Idaccount == searchValue.Idaccount;
        }
    }
}