using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVtripsparticipant : SeedWheeloMainLogic<Vtripsparticipant>
    {
        public override void Insert()
        {
            List<Vtripsparticipant> list = new List<Vtripsparticipant>()
            {
                new Vtripsparticipant { Name = "Jan", Surname = "Kowalski", Suggestedname = "Adam", Suggestedsurname = "Nowak",
                                        Accountid = 1 + AccountIdOffset, Suggestedaccountid = 2, Tripdate = new DateOnly(2023, 6, 15),
                                        Summary = "Podróż do Warszawy", Tripid = 123, Iscurrent = true, Fromhour = new TimeOnly(9, 0),
                                        Tohour = new TimeOnly(12, 0), Leftseats = 2, Isoccasion = false},

                new Vtripsparticipant { Name = "Anna", Surname = "Nowak", Suggestedname = "Maria", Suggestedsurname = "Kowalska",
                                        Accountid = 3 + AccountIdOffset, Suggestedaccountid = 4, Tripdate = new DateOnly(2023, 6, 20),
                                        Summary = "Wycieczka nad morze", Tripid = 456, Iscurrent = true, Fromhour = new TimeOnly(14, 0),
                                        Tohour = new TimeOnly(18, 0), Leftseats = 3, Isoccasion = false},

                new Vtripsparticipant { Name = "Piotr", Surname = "Wiśniewski", Suggestedname = "Krzysztof", Suggestedsurname = "Kowalczyk",
                                        Accountid = 5 + AccountIdOffset, Suggestedaccountid = 6, Tripdate = new DateOnly(2023, 6, 25),
                                        Summary = "Wyjazd na wakacje", Tripid = 789, Iscurrent = true, Fromhour = new TimeOnly(8, 0),
                                        Tohour = new TimeOnly(16, 0), Leftseats = 4, Isoccasion = true},
                 
                new Vtripsparticipant { Name = "Magda", Surname = "Kaczmarek", Suggestedname = "Ewa", Suggestedsurname = "Nowicka",
                                        Accountid = 7 + AccountIdOffset, Suggestedaccountid = 8, Tripdate = new DateOnly(2023, 7, 1),
                                        Summary = "Wypad do parku rozrywki", Tripid = 987, Iscurrent = false, Fromhour = new TimeOnly(10, 0),
                                        Tohour = new TimeOnly(17, 0), Leftseats = 1, Isoccasion = false}
            };

            //TODO Here !

            InsertCollection(list);
        }

        public override Expression<Func<Vtripsparticipant, bool>> TakeWhereCondition(Vtripsparticipant searchValue)
        {
            return m => m.Tripid == searchValue.Tripid;
        }
    }
}