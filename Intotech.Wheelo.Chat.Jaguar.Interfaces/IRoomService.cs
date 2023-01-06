using Intotech.Wheelo.Chat.Models;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IRoomService
{
    RoomsDto CreateRoom(int authorId, List<int> members);

}