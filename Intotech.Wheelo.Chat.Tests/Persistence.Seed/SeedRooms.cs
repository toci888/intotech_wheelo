using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Common.Utils;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class SeedRooms : SeedChatLogic<Room>
{
    public override void Insert()
    {
        List<Room> rooms = new List<Room>();

        int accountId = 1000000001;
        int peerAccountId = 1000000002;
        int thirdAccountId = 1000000003;

        for (int i = 0; i < 10; i++)
        {
            rooms.Add(new Room() { Roomname = "bzapart", Owneremail = "bzapart@gmail.com", Roomid = ChatUtils.GetRoomId(accountId, SeedCrossData.GetAccountsIdsWithSkip(accountId)) });
            
            rooms.Add(new Room() { Roomname = "bartek", Owneremail = "bartek@gg.pl", Roomid = ChatUtils.GetRoomId(thirdAccountId, SeedCrossData.GetAccountsIdsWithSkip(thirdAccountId)) });

            rooms.Add(new Room() { Roomname = "warriorr", Owneremail = "warriorr@poczta.fm", Roomid = ChatUtils.GetRoomId(peerAccountId, SeedCrossData.GetAccountsIdsWithSkip(peerAccountId)) });
            
        }

        InsertCollection(rooms);
    }
}