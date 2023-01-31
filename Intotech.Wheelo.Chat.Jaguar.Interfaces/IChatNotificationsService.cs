using Intotech.Wheelo.Chat.Models;
using Intotech.Wheelo.Chat.Models.Caching;
using Intotech.Wheelo.Notifications.Interfaces.Models;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IChatNotificationsService
{
    NotificationResponseDto SendChatNotifications(int roomId, string senderEmail, ChatMessageDto chatMessage);
}