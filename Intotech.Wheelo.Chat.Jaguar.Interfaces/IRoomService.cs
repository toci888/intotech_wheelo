using Intotech.Wheelo.Chat.Models;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IRoomService
{
    RoomsDto CreateRoom(int idAccount, List<int> idMembersAccounts);

    bool ApproveRoom(string roomId, string email, bool decision);

    List<int> GetAllRooms(string email);

    RoomsDto GetRoom(int roomId);
    RoomsDto GetRoom(string roomId);

}