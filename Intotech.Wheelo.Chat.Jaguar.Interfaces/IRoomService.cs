using Intotech.Wheelo.Chat.Models;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IRoomService
{
    RoomsDto CreateRoom(string hostEmail, List<string> members);

    bool ApproveRoom(int roomId, string email, bool decision);

}