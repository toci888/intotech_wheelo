using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVaccountscollocationsworktrip : SeedWheeloMainLogic<Vaccountscollocationsworktrip>
    {
        public override void Insert()
        {
            List<Vaccountscollocationsworktrip> list = new List<Vaccountscollocationsworktrip>()
            {
                  new Vaccountscollocationsworktrip()
                  {Name = "Jan", Surname = "Kowalski", Suggestedname = "Adam", Suggestedsurname = "Nowak", Accountid = 1 + AccountIdOffset, 
                   Suggestedaccountid = 54321, Distancefrom = 10.5m,Distanceto = 15.7m, Latitudefrom = 52.2297, Longitudefrom = 21.0122, 
                   Latitudeto = 50.0647, Longitudeto = 19.9450, Fromhour = new TimeOnly(8, 0), Tohour = new TimeOnly(17, 0)},

                  new Vaccountscollocationsworktrip()
                  {Name = "Szczepan", Surname = "Kozdra", Suggestedname = "Adam", Suggestedsurname = "Nowak", Accountid = 2 + AccountIdOffset, 
                   Suggestedaccountid = 54321, Distancefrom = 10.5m, Distanceto = 15.7m, Latitudefrom = 52.2297, Longitudefrom = 21.0122, 
                   Latitudeto = 50.0647, Longitudeto = 19.9450, Fromhour = new TimeOnly(8, 0), Tohour = new TimeOnly(17, 0)},

                  new Vaccountscollocationsworktrip()
                  {Name = "Zbyszek", Surname = "Kamiński", Suggestedname = "Adam", Suggestedsurname = "Nowak", Accountid = 3 + AccountIdOffset, 
                   Suggestedaccountid = 54321, Distancefrom = 10.5m, Distanceto = 15.7m, Latitudefrom = 52.2297, Longitudefrom = 21.0122, 
                   Latitudeto = 50.0647, Longitudeto = 19.9450, Fromhour = new TimeOnly(8, 0), Tohour = new TimeOnly(17, 0)}
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Vaccountscollocationsworktrip, bool>> TakeWhereCondition(Vaccountscollocationsworktrip searchValue)
        {
            return m => m.Accountid == searchValue.Accountid;
        }
    }
}