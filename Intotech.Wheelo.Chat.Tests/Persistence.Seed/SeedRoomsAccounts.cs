using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Chat.Jaguar.Utils;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class SeedRoomsAccounts : SeedChatLogic<Roomsaccount>
{
    public override void Insert()
    {
        List<Roomsaccount> list = new List<Roomsaccount>();

        int accountId = 1000000001;
        int peerAccountId = 1000000002;
        int thirdAccountId = 1000000003;


        for (int i = 1; i < 4; i++)
        { 
            Roomsaccount ra = new Roomsaccount() { Idroom = i, Memberemail = "bzapart@gmail.com", Memberidaccount = accountId,  Roomid = ChatUtils.GetRoomId(accountId, SeedCrossData.GetAccountsIdsWithSkip(accountId))  };

            list.Add(ra);

            list.Add(new Roomsaccount() { Memberemail = "warriorr@poczta.fm", Idroom = i, Memberidaccount = peerAccountId, Roomid = ChatUtils.GetRoomId(peerAccountId, SeedCrossData.GetAccountsIdsWithSkip(peerAccountId)) });
            list.Add(new Roomsaccount() { Memberemail = "bartek@gg.pl", Idroom = i, Memberidaccount = thirdAccountId, Roomid = ChatUtils.GetRoomId(thirdAccountId, SeedCrossData.GetAccountsIdsWithSkip(thirdAccountId)) });
        }
        InsertCollection(list);
    }
}