namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class ChatSeedManager
{
    public void SeedAllDb()
    {
        new SeedMessages().Insert();
    }
}