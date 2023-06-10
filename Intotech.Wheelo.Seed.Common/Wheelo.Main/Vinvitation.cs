using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVinvitation : SeedWheeloMainLogic<Vinvitation>
    {
        public override void Insert()
        {
            List<Vinvitation> list = new List<Vinvitation>()
            {
                new Vinvitation() { Firstname = "Jan",  Lastname = "Kowalski", Invitedfirstname = "Anna", Invitedlastname = "Nowak",
                                    Idaccount = 1 + AccountIdOffset, Idaccountinvited = 2 + AccountIdOffset, Createdat = new DateTime(2023, 1, 1)},

                new Vinvitation() { Firstname = "Adam", Lastname = "Nowak", Invitedfirstname = "Ewa",  Invitedlastname = "Kowalska",
                                    Idaccount = 3 + AccountIdOffset, Idaccountinvited = 4 + AccountIdOffset, Createdat = new DateTime(2023, 2, 15)},

                new Vinvitation() { Firstname = "Michał", Lastname = "Czarnecki", Invitedfirstname = "Magdalena", Invitedlastname = "Wójcik",
                                    Idaccount = 5 + AccountIdOffset, Idaccountinvited = 6 + AccountIdOffset, Createdat = new DateTime(2023, 3, 22)},

                new Vinvitation() { Firstname = "Karolina", Lastname = "Nowakowska", Invitedfirstname = "Piotr", Invitedlastname = "Kowalczyk",
                                    Idaccount = 7 + AccountIdOffset, Idaccountinvited = 8 + AccountIdOffset, Createdat = new DateTime(2023, 4, 10)}
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Vinvitation, bool>> TakeWhereCondition(Vinvitation searchValue)
        {
            return m => m.Idaccount == searchValue.Idaccount && m.Idaccountinvited == searchValue.Idaccountinvited;
        }
    }
}