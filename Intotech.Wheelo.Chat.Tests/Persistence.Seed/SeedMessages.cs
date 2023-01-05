using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class SeedMessages : SeedChatLogic<Message>
{
    public override void Insert()
    {
        List<Message> messages = new List<Message>();

        List<int> chatParticipants = new List<int>() { 1000000014, 1000000017 };

        string roomId = HashGenerator.Md5("1000000014, 1000000017");

        for (int i = 0; i < 50; i++)
        {
            Message newMessage = new Message() { Idauthor = chatParticipants[i % 2], Roomid = roomId, Message1 = StringUtils.GetRandomText(25)};

            messages.Add(newMessage);
        }

        InsertCollection(messages);
    }
}