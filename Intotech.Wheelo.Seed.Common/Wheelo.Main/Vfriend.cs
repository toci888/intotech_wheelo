using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVfriend : SeedWheeloMainLogic<Vfriend>
    {
        public override void Insert()
        {
            List<Vfriend> list = new List<Vfriend>()
            {
                new Vfriend() { Idaccount = 1 + AccountIdOffset, Name = "Jan", Surname = "Kowalski", Friendname = "Anna", Friendsurname = "Nowak",
                                Friendidaccount = 2, Method = 1, Latitudefrom = 52.2297, Longitudefrom = 21.0122, Latitudeto = 50.0647, Longitudeto = 19.9450,
                                Fromhour = new TimeOnly(9, 0), Tohour = new TimeOnly(12, 0), Searchid = "ABC123", Driverpassenger = 1},

                new Vfriend() { Idaccount = 3 + AccountIdOffset, Name = "Maria", Surname = "Nowak", Friendname = "Piotr", Friendsurname = "Kowalski",
                                Friendidaccount = 4, Method = 2, Latitudefrom = 48.8566, Longitudefrom = 2.3522, Latitudeto = 51.5074, Longitudeto = -0.1278,
                                Fromhour = new TimeOnly(14, 30), Tohour = new TimeOnly(18, 0), Searchid = "DEF456", Driverpassenger = 2},

                new Vfriend() { Idaccount = 5 + AccountIdOffset, Name = "Adam", Surname = "Nowicki", Friendname = "Ewa", Friendsurname = "Kowalczyk",
                                Friendidaccount = 6, Method = 1, Latitudefrom = 37.7749, Longitudefrom = -122.4194, Latitudeto = 34.0522, Longitudeto = -118.2437,
                                Fromhour = new TimeOnly(8, 0), Tohour = new TimeOnly(10, 0), Searchid = "GHI789", Driverpassenger = 1},

                new Vfriend() { Idaccount = 7 + AccountIdOffset, Name = "Katarzyna", Surname = "Wójcik", Friendname = "Michał", Friendsurname = "Lewandowski",
                                Friendidaccount = 8, Method = 2, Latitudefrom = 40.7128, Longitudefrom = -74.0060, Latitudeto = 39.9526, Longitudeto = -75.1652,
                                Fromhour = new TimeOnly(16, 0), Tohour = new TimeOnly(20, 0), Searchid = "JKL012", Driverpassenger = 2}
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Vfriend, bool>> TakeWhereCondition(Vfriend searchValue)
        {
            return m => m.Idaccount == searchValue.Idaccount;
        }
    }
}