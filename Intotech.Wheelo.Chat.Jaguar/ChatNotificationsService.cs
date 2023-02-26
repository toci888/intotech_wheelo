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

    public virtual void SendChatNotifications(string roomId, string senderEmail, LiveChatMessageDto chatMessage, ConcurrentDictionary<string, string> connectedUsers)
    {
        RoomsDto roomDto = RoomService.GetRoom(roomId);

        List<RoomMembersDto> roomMembers = roomDto.RoomMembers.Where(m => m.Email != senderEmail).Except(connectedUsers.Values.Select(m => new RoomMembersDto() { Email = m })).ToList();

        List<string> pushTokens = new List<string>();

        foreach (RoomMembersDto roomMember in roomMembers)
        {
            List<string> pushTokensMid = roomMember.PushTokens.Where(m => m.StartsWith("ExponentPushToken")).ToList();

            if (pushTokensMid.Count() > 0)
            {
                pushTokens.AddRange(pushTokensMid);
            }
        }


        if (pushTokens.Count > 0)
        {
            NotificationModelBase<LiveChatMessageDto> notificationData = new NotificationModelBase<LiveChatMessageDto>(
                NotificationsKinds.ChatMessage, pushTokens, chatMessage, chatMessage.Text,
                chatMessage.Author.FirstName, chatMessage.Author.LastName);

            NotificationManager.SendNotifications(notificationData);
        }
    }
}