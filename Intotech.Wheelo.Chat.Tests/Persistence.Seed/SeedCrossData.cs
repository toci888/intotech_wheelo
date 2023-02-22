using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed
{
    public class SeedCrossData
    {
        public static Dictionary<string, int> AccountsMap = new Dictionary<string, int>()
        {
            { "bzapart@gmail.com", 1000000001 },
            { "warriorr@poczta.fm", 1000000002 },
            { "bartek@gg.pl", 1000000003 },
        };

        public static List<int> GetAccountsIdsWithSkip(int accountIdToSkip)
        {
            return AccountsMap.Values.Where(m => m != accountIdToSkip).ToList();   
        }
    }
}
