using Intotech.Wheelo.Chat.Models;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IConversationService
{
    ConversationDto GetConversationById(int roomId, bool isAccountIdRequest = false);

    ConversationDto GetConversationById(string roomId, bool isAccountIdRequest = false);

    FullConversationsDto GetConversationsByAccountId(string email);
}