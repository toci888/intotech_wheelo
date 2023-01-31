using Intotech.Wheelo.Chat.Models;
using Intotech.Wheelo.Chat.Models.Caching;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IChatNotificationsService
{
    List<RoomMembersDto> GetChatNotificationReceivers(int roomId, string senderEmail);
}