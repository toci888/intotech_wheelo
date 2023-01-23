using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedInvitation : SeedLogic<Invitation>
    {
        public override void Insert()
        {
            List<Invitation> list = new List<Invitation>();

            list.Add(new Invitation() { Idaccount= 1 + AccountIdOffset, Idinvited = 4 + AccountIdOffset, Origin=1 });
            list.Add(new Invitation() { Idaccount = 2 + AccountIdOffset, Idinvited = 5 + AccountIdOffset, Origin = 2 });
            list.Add(new Invitation() { Idaccount = 3 + AccountIdOffset, Idinvited = 6 + AccountIdOffset, Origin = 2 });
            list.Add(new Invitation() { Idaccount = 4 + AccountIdOffset, Idinvited = 14 + AccountIdOffset, Origin = 1 });
            list.Add(new Invitation() { Idaccount = 5 + AccountIdOffset, Idinvited = 45 + AccountIdOffset, Origin = 2 });
            list.Add(new Invitation() { Idaccount = 6 + AccountIdOffset, Idinvited = 36 + AccountIdOffset, Origin = 2 });

            InsertCollection(list);
        }
    }
}
