using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedTripparticipant : SeedWheeloMainLogic<Tripparticipant>
    {
        public override void Insert()
        {
            List<Tripparticipant> list = new List<Tripparticipant>()
            {
                new Tripparticipant {Idtrip = 2, Idaccount = 3 + AccountIdOffset, Isconfirmed = true, Isoccasion = false, Createdat = DateTime.Now},
                new Tripparticipant {Idtrip = 1, Idaccount = 1 + AccountIdOffset, Isconfirmed = true, Isoccasion = false, Createdat = DateTime.Now},
                new Tripparticipant {Idtrip = 3, Idaccount = 2 + AccountIdOffset, Isconfirmed = true, Isoccasion = false, Createdat = DateTime.Now},
                new Tripparticipant {Idtrip = 4, Idaccount = 5 + AccountIdOffset, Isconfirmed = true, Isoccasion = false, Createdat = DateTime.Now},
                new Tripparticipant {Idtrip = 6, Idaccount = 4 + AccountIdOffset, Isconfirmed = true, Isoccasion = false, Createdat = DateTime.Now},
                new Tripparticipant {Idtrip = 5, Idaccount = 5 + AccountIdOffset, Isconfirmed = true, Isoccasion = false, Createdat = DateTime.Now},
                new Tripparticipant {Idtrip = 7, Idaccount = 6 + AccountIdOffset, Isconfirmed = true, Isoccasion = false, Createdat = DateTime.Now},
                new Tripparticipant {Idtrip = 8, Idaccount = 7 + AccountIdOffset, Isconfirmed = true, Isoccasion = false, Createdat = DateTime.Now},
                new Tripparticipant {Idtrip = 9, Idaccount = 8 + AccountIdOffset, Isconfirmed = true, Isoccasion = false, Createdat = DateTime.Now},
                new Tripparticipant {Idtrip = 10, Idaccount = 9 + AccountIdOffset, Isconfirmed = true, Isoccasion = false, Createdat = DateTime.Now},
                new Tripparticipant {Idtrip = 11, Idaccount = 0 + AccountIdOffset, Isconfirmed = true, Isoccasion = false, Createdat = DateTime.Now},

            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Tripparticipant, bool>> TakeWhereCondition(Tripparticipant searchValue)
        {
            return m => m.Idtrip == searchValue.Idtrip;
        }
    }
}