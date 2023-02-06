using Intotech.Wheelo.Chat.Models;
using Intotech.Wheelo.Chat.Models.Caching;
using Intotech.Wheelo.Notifications.Interfaces.Models;
using System.Collections.Concurrent;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IChatNotificationsService
{
    NotificationResponseDto SendChatNotifications(int roomId, string senderEmail, ChatMessageDto chatMessage, ConcurrentDictionary<string, string> connectedUsers);
}