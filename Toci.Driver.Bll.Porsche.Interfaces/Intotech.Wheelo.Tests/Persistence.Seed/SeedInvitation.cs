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

            list.Add(new Invitation() { Idaccount=1, Idinvited = 4, Origin=1 });
            list.Add(new Invitation() { Idaccount = 2, Idinvited = 5, Origin = 2 });
            list.Add(new Invitation() { Idaccount = 3, Idinvited = 6, Origin = 2 });
            list.Add(new Invitation() { Idaccount = 4, Idinvited = 14, Origin = 1 });
            list.Add(new Invitation() { Idaccount = 5, Idinvited = 45, Origin = 2 });
            list.Add(new Invitation() { Idaccount = 6, Idinvited = 36, Origin = 2 });

            InsertCollection(list);
        }
    }
}
