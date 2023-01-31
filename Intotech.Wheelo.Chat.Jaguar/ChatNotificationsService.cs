using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Intotech.Wheelo.Chat.Models.Caching;
using Intotech.Wheelo.Notifications.Interfaces;
using Intotech.Wheelo.Notifications.Interfaces.Models;

namespace Intotech.Wheelo.Chat.Jaguar;

public class ChatNotificationsService : IChatNotificationsService
{
    protected IRoomService RoomService;
    protected INotificationManager NotificationManager;

    public ChatNotificationsService(IRoomService roomService, INotificationManager notificationManager)
    {
        RoomService = roomService;
        NotificationManager = notificationManager;
    }

    public virtual NotificationResponseDto SendChatNotifications(int roomId, string senderEmail, ChatMessageDto chatMessage)
    {
        RoomsDto roomDto = RoomService.GetRoom(roomId);

        List<RoomMembersDto> roomMembers = roomDto.RoomMembers.Where(m => m.Email != senderEmail).ToList();

        List<string> pushTokens = new List<string>();

        foreach (RoomMembersDto roomMember in roomMembers)
        {
            pushTokens.AddRange(roomMember.PushTokens);
        }

        NotificationModelBase<ChatMessageDto> notificationData = new NotificationModelBase<ChatMessageDto>(
            NotificationsKinds.ChatMessage, pushTokens, chatMessage, chatMessage.Text, 
            chatMessage.AuthorFirstName, chatMessage.AuthorLastName);

        return NotificationManager.SendNotifications(notificationData);
    }
}