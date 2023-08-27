using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountmode : SeedWheeloMainLogic<Accountmode>
    {
        public const int WhiteMode = 1;
        public const int DarkMode = 2;
        public override void Insert()
        {
            List<Accountmode> list = new List<Accountmode>()
            {
                new Accountmode {Idaccount = 1 + AccountIdOffset, Mode = WhiteMode},
                new Accountmode {Idaccount = 2 + AccountIdOffset, Mode = DarkMode},
                new Accountmode {Idaccount = 3 + AccountIdOffset, Mode = WhiteMode}
            };

            //TODO Here !

            InsertCollection(list);
        }

        public override Expression<Func<Accountmode, bool>> TakeWhereCondition(Accountmode searchValue)
        {
            return m=> m.Idaccount == searchValue.Idaccount && m.Mode == searchValue.Mode;
        }
    }
}