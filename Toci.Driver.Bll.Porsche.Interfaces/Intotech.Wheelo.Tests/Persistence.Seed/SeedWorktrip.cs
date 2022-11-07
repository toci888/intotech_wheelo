using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedWorktrip : SeedLogic<Worktrip>
    {
        public override void Insert()
        {
            List<Worktrip> worktripList = new List<Worktrip>();

            Worktrip wt = new Worktrip() { Idaccount = 2, Latitudefrom = (decimal)52.23151900096433, Longitudefrom = (decimal)21.083137973493866 }; //52.23151900096433, 21.083137973493866

            worktripList.Add(wt);

            InsertCollection(worktripList);
        }
    }
}
