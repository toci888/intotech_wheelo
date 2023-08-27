using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVaccountscollocation : SeedWheeloMainLogic<Vaccountscollocation>
    {
        public override void Insert()
        {
            List<Vaccountscollocation> list = new List<Vaccountscollocation>()
            {
                new Vaccountscollocation() {Name = "Jan", Surname = "Kowalski", Suggestedname = "Adam", Suggestedsurname = "Nowak", 
                    Accountid = 1 + AccountIdOffset, Suggestedaccountid = 2 + AccountIdOffset, Distancefrom = 10.5m, Distanceto = 15.7m},
                new Vaccountscollocation() {Name = "Sztefan", Surname = "Baczyński", Suggestedname = "Jacek", Suggestedsurname = "Nowak",
                    Accountid = 2 + AccountIdOffset, Suggestedaccountid = 2 + AccountIdOffset, Distancefrom = 8m, Distanceto = 15.7m},
                new Vaccountscollocation() {Name = "Jacek", Surname = "Kozara", Suggestedname = "Adam", Suggestedsurname = "Nowak",
                    Accountid = 3 + AccountIdOffset, Suggestedaccountid = 2 + AccountIdOffset, Distancefrom = 2m, Distanceto = 15.7m},
                new Vaccountscollocation() {Name = "Kuba", Surname = "Kozdra", Suggestedname = "Adam", Suggestedsurname = "Nowak",
                    Accountid = 4 + AccountIdOffset, Suggestedaccountid = 2 + AccountIdOffset, Distancefrom = 5m, Distanceto = 15.7m},
                new Vaccountscollocation() {Name = "Tomasz", Surname = "Sarnikowski", Suggestedname = "Adam", Suggestedsurname = "Nowak",
                    Accountid = 5 + AccountIdOffset, Suggestedaccountid = 2 + AccountIdOffset, Distancefrom = 6.7m, Distanceto = 15.7m},

            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Vaccountscollocation, bool>> TakeWhereCondition(Vaccountscollocation searchValue)
        {
            return m => m.Accountid == searchValue.Accountid;
        }
    }
}