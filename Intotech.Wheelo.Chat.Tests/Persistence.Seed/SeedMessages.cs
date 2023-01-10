using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class SeedMessages : SeedChatLogic<Message>
{
    public override void Insert()
    {
        List<Message> messages = new List<Message>();

        List<string> chatParticipants = new List<string>() { "bzapart@gmail.com", "warriorr@poczta.fm" };
        
        Random rnd = new Random();

        for (int i = 0; i < 50; i++)
        {                                                                    
            // cadewi yhiklo
            int index = rnd.Next(0, 2);
            Message newMessage = new Message() { Authoremail = chatParticipants[index], Idroom = 1, Message1 = StringUtils.CreateChat(rnd.Next(4,15))};

            messages.Add(newMessage);
        }

        InsertCollection(messages);
    }
}