using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedResetpassword : SeedWheeloMainLogic<Resetpassword>
    {
        public override void Insert()
        {
            List<Resetpassword> list = new List<Resetpassword>()
            {
                new Resetpassword() { Email = "bzapart@gmail.com"},
                new Resetpassword() { Email = "warriorr@poczta.fm"},
                new Resetpassword() { Email = "bartek@gg.pl"},
                new Resetpassword() { Email = "staszek@gmail.com"},
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Resetpassword, bool>> TakeWhereCondition(Resetpassword searchValue)
        {
            return m=> m.Email == searchValue.Email;
        }
    }
}