namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class ChatSeedManager
{
    public void SeedAllDb()
    {
        new SeedRooms().Insert();
        new SeedRoomsAccounts().Insert();
        new SeedMessages().Insert();
    }
}