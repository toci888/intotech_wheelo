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

            Worktrip wt = new Worktrip() { Idaccount = 2, Latitudefrom = 52.24602984098752, Longitudefrom = 21.08428642005573,
                Latitudeto = 52.20678607141056, Longitudeto = 21.0108489021064, Fromhour = new TimeOnly(8, 0), 
                Tohour = new TimeOnly(16, 0) }; //52.23151900096433, 21.083137973493866
            worktripList.Add(wt);

            worktripList.Add(new Worktrip() { Idaccount = 3, Latitudefrom = 52.24587632734148, Longitudefrom = 21.087258004124745,
                Latitudeto = 52.20478607141056, Longitudeto = 21.0118489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10)});

            

            InsertCollection(worktripList);
        }
    }
}
