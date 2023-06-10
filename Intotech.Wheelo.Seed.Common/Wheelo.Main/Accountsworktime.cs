using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountsworktime : SeedWheeloMainLogic<Accountsworktime>
    {
        public override void Insert()
        {
            List<Accountsworktime> list = new List<Accountsworktime>()
            {
                new Accountsworktime {Idaccounts= 1 + AccountIdOffset, Workstarthour = new TimeOnly(15, 30, 0), Workendhour = new TimeOnly(18,45,0)},
                new Accountsworktime {Idaccounts= 2 + AccountIdOffset, Workstarthour = new TimeOnly(12, 40, 0), Workendhour = new TimeOnly(23,0,0)},
                new Accountsworktime {Idaccounts= 3 + AccountIdOffset, Workstarthour = new TimeOnly(2, 30, 0),  Workendhour = new TimeOnly(7,20,0)},
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Accountsworktime, bool>> TakeWhereCondition(Accountsworktime searchValue)
        {
            return m=> true; // m.Idaccount == searchValue.Idaccount; ??
        }
    }
}