using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Chat.Models;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IConversationService : IService
{
    ConversationDto GetConversationById(int roomId, bool isAccountIdRequest = false);

    ConversationDto GetConversationById(string roomId, bool isAccountIdRequest = false);

    FullConversationsDto GetConversationsByEmail(string email);

    ConversationDto GetPersonalConversation(int IdAccount, int idFriendAccount);
}