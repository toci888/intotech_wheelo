using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountrole : SeedWheeloMainLogic<Accountrole>
    {
        public override void Insert()
        {
            List<Accountrole> list = new List<Accountrole>()
            {
                new Accountrole { Name = "Bartek", Surname = "Zapart", Email = "bzapart@gmail.com",
                    Password = "fbd623cdcf27c1cf99595b52154e699d1ae95e7c48bd7c34ba73d0091a5b2af2",
                    Emailconfirmed = true, Refreshtoken = "cntgfu347frgwhu293"},
                new Accountrole { Name = "Wojtek", Surname = "Rucha³a", Email = "warriorr@poczta.fm",
                    Password = "fbd623cdcf27c1cf99595b52154e699d1ae95e7c48bd7c34ba73d0091a5b2af2",
                    Emailconfirmed = true, Refreshtoken = "cntgfu347frgwhu293"},
                new Accountrole { Name = "Julia", Surname = "Weso³a", Email = "bartek@gg.pl",
                    Password = "fbd623cdcf27c1cf99595b52154e699d1ae95e7c48bd7c34ba73d0091a5b2af2",
                    Emailconfirmed = true, Refreshtoken = "cntgfu347frgwhu293"}
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Accountrole, bool>> TakeWhereCondition(Accountrole searchValue)
        {
            return m=> m.Email == searchValue.Email;
        }
    }
}