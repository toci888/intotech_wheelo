using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class SeedRoomsAccounts : SeedChatLogic<Roomsaccount>
{
    public override void Insert()
    {
        List<Roomsaccount> list = new List<Roomsaccount>();

        Roomsaccount ra = new Roomsaccount() { Idroom = 1, Idmember = 1000000018 };

        list.Add(ra);

        list.Add(new Roomsaccount() { Idmember = 1000000015, Idroom = 1 });

        InsertCollection(list);
    }
}