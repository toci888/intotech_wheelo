using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedEmailsregister : SeedWheeloMainLogic<Emailsregister>
    {
        public override void Insert()
        {
            List<Emailsregister> list = new List<Emailsregister>()
            {
                new Emailsregister() {Email = "bzapart@gmail.com", Isverified= true, Verificationcode = 111333},
                new Emailsregister() {Email = "warriorr@poczta.fm", Isverified= true, Verificationcode = 222333},
                new Emailsregister() {Email = "bartek@gg.pl", Isverified= true, Verificationcode = 333444}
            };


            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Emailsregister, bool>> TakeWhereCondition(Emailsregister searchValue)
        {
            return m=> m.Email == searchValue.Email;
        }
    }

}