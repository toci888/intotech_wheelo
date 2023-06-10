using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVfriendsuggestion : SeedWheeloMainLogic<Vfriendsuggestion>
    {
        public override void Insert()
        {
            List<Vfriendsuggestion> list = new List<Vfriendsuggestion>()
            {
                new Vfriendsuggestion() { Name = "Anna", Surname = "Kowalska", Suggestedname = "Jan", Suggestedsurname = "Nowak",
                                          Accountid = 1 + AccountIdOffset, Suggestedaccountid = 2,  Suggestedfriendname = "Ewa",
                                          Suggestedfriendsurname = "Wójcik", Suggestedfriendid = 3},

                new Vfriendsuggestion() { Name = "Piotr", Surname = "Nowicki", Suggestedname = "Maria", Suggestedsurname = "Kwiatkowska",
                                          Accountid = 4 + AccountIdOffset, Suggestedaccountid = 5, Suggestedfriendname = "Tomasz",
                                          Suggestedfriendsurname = "Lewandowski", Suggestedfriendid = 6},

                new Vfriendsuggestion() { Name = "Karolina", Surname = "Mazur", Suggestedname = "Marcin", Suggestedsurname = "Wójcik",
                                          Accountid = 7 + AccountIdOffset, Suggestedaccountid = 8, Suggestedfriendname = "Aleksandra",
                                          Suggestedfriendsurname = "Kowalczyk", Suggestedfriendid = 9},

                new Vfriendsuggestion() { Name = "Tomasz", Surname = "Lis", Suggestedname = "Katarzyna", Suggestedsurname = "Szymańska",
                                          Accountid = 10 + AccountIdOffset, Suggestedaccountid = 11, Suggestedfriendname = "Michał",
                                          Suggestedfriendsurname = "Nowakowski", Suggestedfriendid = 12}
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Vfriendsuggestion, bool>> TakeWhereCondition(Vfriendsuggestion searchValue)
        {
            return m => m.Accountid == searchValue.Accountid && m.Suggestedfriendid == searchValue.Suggestedfriendid;
        }
    }
}