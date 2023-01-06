using Intotech.Wheelo.Chat.Models;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IConversationService
{
    ConversationDto GetConversationById(int roomId, bool isAccountIdRequest = false);

    List<ConversationDto> GetConversationsByAccountId(int accountId);
}