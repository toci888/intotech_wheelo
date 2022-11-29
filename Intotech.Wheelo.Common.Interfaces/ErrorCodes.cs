using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces
{
    public static class ErrorCodes
    {
        public const int WorkTripFormNotFilled = 2; // | 10 100
        public const int FailVerifyingAccount = 4;
        // dodajesz swoje nowe errory
        // 4 8 16 32 64 128
        public const int Success = 1;
    }
}
