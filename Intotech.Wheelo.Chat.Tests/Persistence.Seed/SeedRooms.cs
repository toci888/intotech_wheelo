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


        for (int i = 0; i < 10; i++)
        {
            rooms.Add(new Room() { Roomname = "Bartek", Owneremail = "bzapart@gmail.com", Roomid = ChatUtils.GetRoomId(accountId, peerAccountId + i) });
            peerAccountId++;
            rooms.Add(new Room() { Roomname = "Kacper", Owneremail = "bartek@gg.pl", Roomid = ChatUtils.GetRoomId(accountId, peerAccountId + i) });
            peerAccountId++;
            rooms.Add(new Room() { Roomname = "Warrior", Owneremail = "warriorr@poczta.fm", Roomid = ChatUtils.GetRoomId(accountId, peerAccountId + i) });
            peerAccountId++;
        }

        InsertCollection(rooms);
    }
}