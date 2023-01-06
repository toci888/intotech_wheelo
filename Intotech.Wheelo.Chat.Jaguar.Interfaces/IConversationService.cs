using Intotech.Wheelo.Chat.Models;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IConversationService
{
    ConversationDto GetConversationById(string roomId, bool isAccountIdRequest = false);

    List<ConversationDto> GetConversationsByAccountId(int accountId);
}