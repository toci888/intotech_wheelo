using Intotech.Wheelo.Chat.Models;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IConversationService
{
    ConversationDto GetConversationById(string roomId);

    List<ConversationDto> GetConversationsByAccountId(int accountId);
}