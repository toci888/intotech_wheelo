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
        public const int NoData = 8;
        public const int FriendshipNotFound = 16;
        public const int DataAlreadyExistInDatabase = 32;
        public const int FailedToAddInformation = 64;
        public const int AccountNotFound = 128;
        public const int EmailIsNotConfirmed = 256;
        public const int AccountExists = 512;
        // dodajesz swoje nowe errory
        // 4 8 16 32 64 128
        public const int Success = 1;
    }
}
