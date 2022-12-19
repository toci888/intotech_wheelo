using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common
{
    public static class WheeloUtils
    {
        public static void PotentialSwapIds(ref int id, ref int secondId)
        {
            int swap = id;

            if (id > secondId)
            {
                id = secondId;
                secondId = swap;
            }
        }
    }
}
