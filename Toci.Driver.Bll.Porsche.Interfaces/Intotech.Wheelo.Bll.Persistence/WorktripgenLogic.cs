using Intotech.Common;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence
{
    public class WorktripgenLogic : Logic<Worktripgen>, IWorktripgenLogic
    {
        public const int AccountIdOffset = 1000000000;

        public static string GetWorktripSearchId(Worktripgen workTrip)
        {
            return HashGenerator.Md5(string.Format("AccountId: {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}",
                workTrip.Idaccount, workTrip.Longitudefrom, workTrip.Latitudefrom, workTrip.Longitudeto, workTrip.Latitudeto,
                workTrip.Fromhour.Value.Hour, workTrip.Tohour.Value.Hour, workTrip.Fromhour.Value.Minute, 
                workTrip.Tohour.Value.Minute,  workTrip.Acceptabledistance));
        }
    }
}
