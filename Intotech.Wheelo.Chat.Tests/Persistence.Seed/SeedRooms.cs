using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class SeedRooms : SeedChatLogic<Room>
{
    public override void Insert()
    {
        List<Room> rooms = new List<Room>();

        //rooms.Add(new Room() { Roomid = HashGenerator.Md5("1000000015, 1000000018"), Ownerid = 1000000015 });
        //rooms.Add(new Room() { Roomid = HashGenerator.Md5("1000000014, 1000000018"), Ownerid = 1000000014 });
        //rooms.Add(new Room() { Roomid = HashGenerator.Md5("1000000015, 1000000023"), Ownerid = 1000000023 });

        InsertCollection(rooms);
    }
}