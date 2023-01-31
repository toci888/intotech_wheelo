using Intotech.Common;
using Intotech.Wheelo.Chat.Bll.Persistence;
using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Chat.Dodge.Interfaces;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Intotech.Wheelo.Chat.Models.Caching;
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
        
        List<UserCacheDto> chatMembers = new List<UserCacheDto>();

        UserCacheDto author = AccountService.GetAccount(hostEmail);

        if (author == null)
        {
            return null;
        }

        chatMembers.Add(author);
        
        result.RoomMembers = new List<RoomMembersDto>();

        foreach (string memberEmail in members)
        {
            UserCacheDto member = AccountService.GetAccount(memberEmail);

            if (member != null)
            {
                chatMembers.Add(member);

                result.RoomMembers.Add(new RoomMembersDto() { CreatedAt = member.AccountCreatedAt, IdAccount = member.IdAccount, Email = member.SenderEmail, FirstName = member.UserName, LastName = member.UserSurname });
            }
        }

        result.RoomMembers.Add(new RoomMembersDto() { CreatedAt = author.AccountCreatedAt, IdAccount = author.IdAccount, Email = author.SenderEmail, FirstName = author.UserName, LastName = author.UserSurname });

        //Kacper, Julia, Bartek
        result.RoomName = string.Join(", ", chatMembers.Select(m => m.UserName));
  
        Room room = RoomLogic.Insert(new Room() { Ownerid = hostEmail, Roomname = result.RoomName });

        result.IdRoom = room.Id;
        result.OwnerEmail = hostEmail;


        foreach (UserCacheDto chatMember in chatMembers)
        {
            RoomsAccountLogic.Insert(new Roomsaccount() { Idroom = result.IdRoom, Memberemail = chatMember.SenderEmail });
        }
        
        return result;
    }

    public virtual List<int> GetAllRooms(string email)
    {
        return RoomsAccountLogic.Select(m => m.Memberemail == email).Select(m => m.Idroom).ToList();
    }
}