using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class SeedMessages : SeedChatLogic<Message>
{
    public override void Insert()
    {
        List<Message> messages = new List<Message>();

        List<string> chatParticipants = new List<string>() { "bzapart@gmail.com", "warriorr@poczta.fm", "bartek@gg.pl" };

        List<int> chatParticipantsAccIds = new List<int>() { 1000000001, 1000000002, 1000000003 };

        Random rnd = new Random();

        for (int j = 1; j < 4; j++)
        for (int i = 0; i < 50; i++)
        {                                                                    
            // cadewi yhiklo
            int index = rnd.Next(0, 3);
            Message newMessage = new Message() { Authoremail = chatParticipants[index], Idaccount = chatParticipantsAccIds[index],  Idroom = j, Message1 = StringUtils.CreateChat(rnd.Next(4,15))};

            messages.Add(newMessage);
        }

        InsertCollection(messages);
    }
}