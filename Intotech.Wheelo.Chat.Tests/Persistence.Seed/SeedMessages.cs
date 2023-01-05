using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class SeedMessages : SeedChatLogic<Message>
{
    public override void Insert()
    {
        List<Message> messages = new List<Message>();

        List<int> chatParticipants = new List<int>() { 1000000015, 1000000018 };

        string roomId = HashGenerator.Md5("1000000015, 1000000018");

        Random rnd = new Random();

        for (int i = 0; i < 50; i++)
        {                                                                                                                               // cadewi yhiklo
            Message newMessage = new Message() { Idauthor = chatParticipants[rnd.Next(1)], Roomid = roomId, Message1 = StringUtils.CreateChat(rnd.Next(4,15))};

            messages.Add(newMessage);
        }

        InsertCollection(messages);
    }
}