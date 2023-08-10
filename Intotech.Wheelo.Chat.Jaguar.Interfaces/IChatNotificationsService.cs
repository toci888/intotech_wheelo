using Intotech.Wheelo.Chat.Models;
using Intotech.Wheelo.Chat.Models.Caching;
using Intotech.Wheelo.Notifications.Interfaces.Models;
using System.Collections.Concurrent;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IChatNotificationsService
{
    void SendChatNotifications(string roomId, string senderEmail, LiveChatMessageDto chatMessage, ConcurrentDictionary<string, string> connectedUsers);
}