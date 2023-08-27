using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedUserextradatum : SeedWheeloMainLogic<Userextradatum>
    {
        public override void Insert()
        {
            List<Userextradatum> list = new List<Userextradatum>()
            {
                new Userextradatum {Idaccount = 1 + AccountIdOffset,  Token = "token123", Method = "method", Tokendatajson = "data",  Origin = 3, Createdat = DateTime.Now},
                new Userextradatum {Idaccount = 2 + AccountIdOffset,  Token = "token234", Method = "method", Tokendatajson = "data",  Origin = 3, Createdat = DateTime.Now},
                new Userextradatum {Idaccount = 3 + AccountIdOffset,  Token = "token567", Method = "method", Tokendatajson = "data",  Origin = 3, Createdat = DateTime.Now},
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Userextradatum, bool>> TakeWhereCondition(Userextradatum searchValue)
        {
            return m=> true; //??
        }
    }
}