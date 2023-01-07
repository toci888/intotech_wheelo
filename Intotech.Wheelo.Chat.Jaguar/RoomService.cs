using Intotech.Common;
using Intotech.Wheelo.Chat.Bll.Persistence;
using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Chat.Dodge.Interfaces;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Jaguar;

public class RoomService : IRoomService
{
    private const string RoomIdPattern = "{0}_RoomIdText";

    protected IAccountService AccountService;
    protected IRoomLogic RoomLogic;
    protected IRoomsaccountLogic RoomsAccountLogic;

    public RoomService(IAccountService accountService, IRoomLogic roomLogic, IRoomsaccountLogic roomsAccountLogic)
    {
        AccountService = accountService;
        RoomLogic = roomLogic;
        RoomsAccountLogic = roomsAccountLogic;
    }

    public RoomsDto CreateRoom(int authorId, List<int> members)
    {
        List<Account> chatMembers = new List<Account>();

        Account author = AccountService.GetAccount(authorId);

        chatMembers.Add(author);

        RoomsDto result = new RoomsDto();
        
        result.RoomMembers = new List<RoomMembersDto>();

        foreach (int memberId in members)
        {
            Account member = AccountService.GetAccount(memberId);

            chatMembers.Add(member);

            result.RoomMembers.Add(new RoomMembersDto() { CreatedAt = member .Createdat.Value, AccountId = member.Id, FirstName = member .Name, LastName = member.Surname });
        }
        //Kacper, Julia, Bartek
        result.RoomName = string.Join(", ", chatMembers.Select(m => m.Name));
        result.RoomId = HashGenerator.Md5(string.Format(RoomIdPattern, authorId));

        Room room = RoomLogic.Insert(new Room() { Ownerid = authorId, Roomid = result.RoomId, Roomname = result.RoomName });

        result.OwnerId = authorId;
        result.IdRoom = room.Id;

        foreach (Account chatMember in chatMembers)
        {
            RoomsAccountLogic.Insert(new Roomsaccount() { Idroom = room.Id, Idmember = chatMember.Id });
        }
        
        return result;
    }
}