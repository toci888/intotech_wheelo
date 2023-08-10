using Intotech.Common;
using Intotech.Wheelo.Common;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Utils
{
    public static class ChatUtils
    {
        public static string GetRoomId(int idAccount, int idFriendAccount)
        {
            int idAcc = idAccount;
            int idFriend = idFriendAccount;

            WheeloUtils.PotentialSwapIds(ref idAcc, ref idFriend);

            string roomId = HashGenerator.Md5(string.Format("{0}_{1}_RoomIdSalt", idAcc, idFriend));

            return roomId;
        }

        public static string GetRoomId(int idAccount, List<int> members)
        {
            members.Add(idAccount);

            members = members.OrderBy(x => x).ToList();

            return HashGenerator.Md5(string.Format("{0}_{1}_RoomIdSalt", idAccount, string.Join(", ", members)));
        }
    }
}
