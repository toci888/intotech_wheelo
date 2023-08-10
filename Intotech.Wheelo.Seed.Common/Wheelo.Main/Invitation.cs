using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedInvitation : SeedWheeloMainLogic<Invitation>
    {
        public override void Insert()
        {
            List<Invitation> list = new List<Invitation>();

            list.Add(new Invitation() { Idaccount = 1 + AccountIdOffset, Idinvited = 4 + AccountIdOffset, Origin = 1 });
            list.Add(new Invitation() { Idaccount = 2 + AccountIdOffset, Idinvited = 5 + AccountIdOffset, Origin = 2 });
            list.Add(new Invitation() { Idaccount = 3 + AccountIdOffset, Idinvited = 6 + AccountIdOffset, Origin = 2 });
            list.Add(new Invitation() { Idaccount = 4 + AccountIdOffset, Idinvited = 14 + AccountIdOffset, Origin = 1 });
            list.Add(new Invitation() { Idaccount = 5 + AccountIdOffset, Idinvited = 45 + AccountIdOffset, Origin = 2 });
            list.Add(new Invitation() { Idaccount = 6 + AccountIdOffset, Idinvited = 36 + AccountIdOffset, Origin = 2 });


            InsertCollection(list);
        }

        public override Expression<Func<Invitation, bool>> TakeWhereCondition(Invitation searchValue)
        {
            return m => m.Idaccount == searchValue.Idaccount && m.Idinvited == searchValue.Idinvited;
        }
    }
}