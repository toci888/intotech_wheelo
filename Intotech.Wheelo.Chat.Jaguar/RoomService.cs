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

    public RoomsDto CreateRoom(string hostEmail, List<string> members)
    {
        RoomsDto result = new RoomsDto();
        
        List<Account> chatMembers = new List<Account>();

        Account author = AccountService.GetAccount(hostEmail);

        chatMembers.Add(author);
        
        result.RoomMembers = new List<RoomMembersDto>();

        foreach (string memberEmail in members)
        {
            Account member = AccountService.GetAccount(memberEmail);

            chatMembers.Add(member);

            result.RoomMembers.Add(new RoomMembersDto() { CreatedAt = member .Createdat.Value, AccountId = member.Id, Email = member.Email, FirstName = member .Name, LastName = member.Surname });
        }
        //Kacper, Julia, Bartek
        result.RoomName = string.Join(", ", chatMembers.Select(m => m.Name));
        // result.RoomId = HashGenerator.Md5(string.Format(RoomIdPattern, authorId));

        //Room testRoomExists = RoomLogic.Select(m => m.Roomid == result.RoomId).FirstOrDefault();

        Room room = RoomLogic.Insert(new Room() { Ownerid = hostEmail, Roomid = result.RoomId, Roomname = result.RoomName });

        result.IdRoom = room.Id;

        //if (testRoomExists == null)
        //{
        //    Room room = RoomLogic.Insert(new Room() { Ownerid = authorId, Roomid = result.RoomId, Roomname = result.RoomName });

        //    result.IdRoom = room.Id;
        //}
        //else
        //{
        //    result.IdRoom = testRoomExists.Id;
        //}

        result.OwnerEmail = hostEmail;


        foreach (Account chatMember in chatMembers)
        {
            RoomsAccountLogic.Insert(new Roomsaccount() { Idroom = result.IdRoom, Memberemail = chatMember.Email });
        }
        
        return result;
    }
}