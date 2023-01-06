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
        public const int LoggedInViaRegistration = 5;
        public const int NoData = 8;
        public const int FriendshipNotFound = 16;
        public const int DataAlreadyExistInDatabase = 32;
        public const int FailedToAddInformation = 64;
        public const int AccountNotFound = 128;
        public const int EmailIsNotConfirmed = 256;
        public const int AccountExists = 512;
        public const int ErrorPleaseLogInToApp = 1024;
        public const int RefreshTokenExpiredPleaseLogIn = 2048;
        public const int DataIntegrityViolated = 4096;
        public const int UnderAttack = 8192;
        public const int PleaseConfirmEmail = 16384;
        public const int PleaseLogIn = 32768;
        public const int EmailIsNotConfirmedPassMatch = 65536;
        public const int EmailDoesNotExistResetPassword = 131072;
        public const int WrongPushTokenOperations = 262144;
        // dodajesz swoje nowe errory
        // 4 8 16 32 64 128
        public const int Success = 1;
    }
}
