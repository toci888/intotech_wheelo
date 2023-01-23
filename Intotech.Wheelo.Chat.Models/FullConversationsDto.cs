namespace Intotech.Wheelo.Chat.Models;

public class FullConversationsDto
{
    public List<ConversationDto> Conversations { get; set; }
    public List<MessageAuthorDto> UsersData { get; set; }
}