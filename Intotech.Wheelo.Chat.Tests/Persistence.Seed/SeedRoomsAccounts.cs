using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class SeedRoomsAccounts : SeedChatLogic<Roomsaccount>
{
    public override void Insert()
    {
        List<Roomsaccount> list = new List<Roomsaccount>();

        for (int i = 1; i < 11; i++)
        { 
            Roomsaccount ra = new Roomsaccount() { Idroom = i, Memberemail = "bzapart@gmail.com" };

            list.Add(ra);

            list.Add(new Roomsaccount() { Memberemail = "warriorr@poczta.fm", Idroom = i });
            list.Add(new Roomsaccount() { Memberemail = "bartek@gg.pl", Idroom = i });
        }
        InsertCollection(list);
    }
}