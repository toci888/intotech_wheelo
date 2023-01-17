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
    protected IAccountService AccountService;
    protected IRoomLogic RoomLogic;
    protected IRoomsaccountLogic RoomsAccountLogic;

    public RoomService(IAccountService accountService, IRoomLogic roomLogic, IRoomsaccountLogic roomsAccountLogic)
    {
        AccountService = accountService;
        RoomLogic = roomLogic;
        RoomsAccountLogic = roomsAccountLogic;
    }

    public virtual bool ApproveRoom(int roomId, string email, bool decision)
    {
        Roomsaccount roomAccount = RoomsAccountLogic.Select(m => m.Memberemail == email && m.Idroom == roomId).FirstOrDefault();

        if (roomAccount != null)
        {
            roomAccount.Isapproved = decision;

            RoomsAccountLogic.Update(roomAccount);

            return true;
        }

        return false;
    }

    public RoomsDto CreateRoom(string hostEmail, List<string> members)
    {
        RoomsDto result = new RoomsDto();
        
        List<Account> chatMembers = new List<Account>();

        Account author = AccountService.GetAccount(hostEmail);

        if (author == null)
        {
            return null;
        }

        chatMembers.Add(author);
        
        result.RoomMembers = new List<RoomMembersDto>();

        foreach (string memberEmail in members)
        {
            Account member = AccountService.GetAccount(memberEmail);

            if (member != null)
            {
                chatMembers.Add(member);

                result.RoomMembers.Add(new RoomMembersDto() { CreatedAt = member.Createdat.Value, AccountId = member.Id, Email = member.Email, FirstName = member.Name, LastName = member.Surname });
            }
        }

        result.RoomMembers.Add(new RoomMembersDto() { CreatedAt = author.Createdat.Value, AccountId = author.Id, Email = author.Email, FirstName = author.Name, LastName = author.Surname });

        //Kacper, Julia, Bartek
        result.RoomName = string.Join(", ", chatMembers.Select(m => m.Name));
  
        Room room = RoomLogic.Insert(new Room() { Ownerid = hostEmail, Roomname = result.RoomName });

        result.IdRoom = room.Id;
        result.OwnerEmail = hostEmail;


        foreach (Account chatMember in chatMembers)
        {
            RoomsAccountLogic.Insert(new Roomsaccount() { Idroom = result.IdRoom, Memberemail = chatMember.Email });
        }
        
        return result;
    }

    public virtual List<int> GetAllRooms(string email)
    {
        return RoomsAccountLogic.Select(m => m.Memberemail == email).Select(m => m.Idroom).ToList();
    }
}