using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class SeedRoomsAccounts : SeedChatLogic<Roomsaccount>
{
    public override void Insert()
    {
        Roomsaccount ra = new Roomsaccount() { Roomid = HashGenerator.Md5("1000000015, 1000000018"), Idmember = 1000000018 };
    }
}