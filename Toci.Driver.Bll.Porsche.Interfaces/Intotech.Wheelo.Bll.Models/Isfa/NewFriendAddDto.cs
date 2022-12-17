using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.Isfa
{
    public class NewFriendAddDto
    {
        public NewFriendAddDto RefreshSwapDto()
        {
            int swap = 0;

            if (Idaccount  > Idfriend)
            {
                swap = Idaccount;
                Idaccount = Idfriend;
                Idfriend = swap;
            }

            return this;
        }

        public int Idaccount { get; set; }
        public int Idfriend { get; set; }
        public int Method { get; set; } // Inv = 1, sugg - 2, assoc - 3
    }
}
