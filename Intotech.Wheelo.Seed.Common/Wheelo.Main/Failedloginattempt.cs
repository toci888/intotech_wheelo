using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedFailedloginattempt : SeedWheeloMainLogic<Failedloginattempt>
    {
        public override void Insert()
        {
            List<Failedloginattempt> list = new List<Failedloginattempt>()
            {
                new Failedloginattempt() {Idaccount = 1 + AccountIdOffset, Kind = 1, Createdat = DateTime.Now },
                new Failedloginattempt() {Idaccount = 2 + AccountIdOffset, Kind = 2, Createdat = DateTime.Now },
                new Failedloginattempt() {Idaccount = 3 + AccountIdOffset, Kind = 3, Createdat = DateTime.Now },
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Failedloginattempt, bool>> TakeWhereCondition(Failedloginattempt searchValue)
        {
            return m => true;
        }
    }
}