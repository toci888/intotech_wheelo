using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Intotech.Wheelo.Chat.Models.Caching;

namespace Intotech.Wheelo.Chat.Jaguar;

public class ChatNotificationsService : IChatNotificationsService
{
    protected IRoomService RoomService;

    public ChatNotificationsService(IRoomService roomService)
    {
        RoomService = roomService;
    }

    public virtual List<RoomMembersDto> GetChatNotificationReceivers(int roomId, string senderEmail)
    {
        RoomsDto roomDto = RoomService.GetRoom(roomId);

        return roomDto.RoomMembers.Where(m => m.Email != senderEmail).ToList();
    }
}