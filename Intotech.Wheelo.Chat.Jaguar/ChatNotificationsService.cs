using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Intotech.Wheelo.Chat.Models.Caching;
using Intotech.Wheelo.Notifications.Interfaces;
using Intotech.Wheelo.Notifications.Interfaces.Models;
using System.Collections.Concurrent;

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

    public virtual NotificationResponseDto SendChatNotifications(string roomId, string senderEmail, ChatMessageDto chatMessage, ConcurrentDictionary<string, string> connectedUsers)
    {
        RoomsDto roomDto = RoomService.GetRoom(roomId);

        List<RoomMembersDto> roomMembers = roomDto.RoomMembers.Where(m => m.Email != senderEmail).Except(connectedUsers.Values.Select(m => new RoomMembersDto() { Email = m })).ToList();

        List<string> pushTokens = new List<string>();

        foreach (RoomMembersDto roomMember in roomMembers)
        {
            pushTokens.AddRange(roomMember.PushTokens);
        }



        NotificationModelBase<ChatMessageDto> notificationData = new NotificationModelBase<ChatMessageDto>(
            NotificationsKinds.ChatMessage, pushTokens, chatMessage, chatMessage.Text, 
            chatMessage.Author.FirstName, chatMessage.Author.LastName);

        return NotificationManager.SendNotifications(notificationData);
    }
}