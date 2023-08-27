using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedSimpleaccount : SeedWheeloMainLogic<Simpleaccount>
    {
        public override void Insert()
        {
            List<Simpleaccount> list = new List<Simpleaccount>()
            {
                new Simpleaccount { Email = "bzapart@gmail.com", Firstname = "Bartek", Lastname = "Zapart",
                    Password = "fbd623cdcf27c1cf99595b52154e699d1ae95e7c48bd7c34ba73d0091a5b2af2", Verificationcode = 256378 },
                new Simpleaccount { Email = "warriorr@poczta.fm", Firstname = "Wojtek", Lastname = "Ruchaja",
                    Password = "fbd623cdcf27c1cf99595b52154e699d1ae95e7c48bd7c34ba73d0091a5b2af2", Verificationcode = null},
                new Simpleaccount { Email = "bartek@gg.pl", Firstname = "Julia", Lastname = "Wesoia",
                    Password = "fbd623cdcf27c1cf99595b52154e699d1ae95e7c48bd7c34ba73d0091a5b2af2", Verificationcode = 698742 },
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Simpleaccount, bool>> TakeWhereCondition(Simpleaccount searchValue)
        {
            return m => m.Email == searchValue.Email;
        }
    }
}