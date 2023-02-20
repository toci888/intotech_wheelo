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


        for (int i = 1; i < 11; i++)
        { 
            Roomsaccount ra = new Roomsaccount() { Idroom = i, Memberemail = "bzapart@gmail.com", Roomid = ChatUtils.GetRoomId(accountId, peerAccountId + i)  };

            list.Add(ra);

            list.Add(new Roomsaccount() { Memberemail = "warriorr@poczta.fm", Idroom = i, Roomid = ChatUtils.GetRoomId(accountId, peerAccountId + i) });
            list.Add(new Roomsaccount() { Memberemail = "bartek@gg.pl", Idroom = i, Roomid = ChatUtils.GetRoomId(accountId, peerAccountId + i) });
        }
        InsertCollection(list);
    }
}