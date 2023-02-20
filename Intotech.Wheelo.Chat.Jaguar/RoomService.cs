using Intotech.Common;
using Intotech.Wheelo.Chat.Bll.Persistence;
using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Chat.Dodge.Interfaces;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Intotech.Wheelo.Chat.Models.Caching;
using Intotech.Wheelo.Common.Utils;
using System.Security.Principal;
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

    public virtual bool ApproveRoom(string roomId, string email, bool decision)
    {
        Room room = RoomLogic.Select(m => m.Roomid == roomId).FirstOrDefault();

        if (room != null) 
        {
            Roomsaccount roomAccount = RoomsAccountLogic.Select(m => m.Memberemail == email && m.Idroom == room.Id).FirstOrDefault();

            if (roomAccount != null)
            {
                roomAccount.Isapproved = decision;

                RoomsAccountLogic.Update(roomAccount);

                return true;
            }
        }

        return false;
    }

    public RoomsDto CreateRoom(int idAccount, List<int> idMembersAccounts)
    {
        string roomId = ChatUtils.GetRoomId(idAccount, idMembersAccounts);

        Room existingRoom = RoomLogic.Select(m => m.Roomid == roomId).FirstOrDefault();

        RoomsDto result = new RoomsDto();
        
        List<UserCacheDto> chatMembers = new List<UserCacheDto>();

        UserCacheDto author = AccountService.GetAccount(idAccount);

        if (author == null)
        {
            return null;
        }

        chatMembers.Add(author);
        
        result.RoomMembers = new List<RoomMembersDto>();

        foreach (int memberId in idMembersAccounts)
        {
            UserCacheDto member = AccountService.GetAccount(memberId);

            if (member != null)
            {
                chatMembers.Add(member);

                result.RoomMembers.Add(new RoomMembersDto() { CreatedAt = member.AccountCreatedAt, IdAccount = member.IdAccount, Email = member.SenderEmail, FirstName = member.UserName, LastName = member.UserSurname, PushTokens = member.PushTokens });
            }
        }

        result.RoomMembers.Add(new RoomMembersDto() { CreatedAt = author.AccountCreatedAt, IdAccount = author.IdAccount, Email = author.SenderEmail, FirstName = author.UserName, LastName = author.UserSurname, PushTokens = author.PushTokens });

        //Kacper, Julia, Bartek
        result.RoomName = string.Join(", ", chatMembers.Select(m => m.UserName));
        result.RoomId = ChatUtils.GetRoomId(idAccount, idMembersAccounts);

        Room room = null;

        if (existingRoom != null)
        {
            room = existingRoom;
        }
        else
        {
            room = RoomLogic.Insert(new Room() { Owneremail = author.SenderEmail, Roomname = result.RoomName, Roomid = result.RoomId });
        }

        result.IdRoom = room.Id;
        result.OwnerEmail = author.SenderEmail;

        if (existingRoom == null)
        {
            foreach (UserCacheDto chatMember in chatMembers)
            {
                RoomsAccountLogic.Insert(new Roomsaccount() { Roomid = result.RoomId, Idroom = result.IdRoom, Memberemail = chatMember.SenderEmail });
            }
        }

        return result;
    }

    public virtual List<string> GetAllRooms(string email)
    {
        return RoomsAccountLogic.Select(m => m.Memberemail == email).Select(m => m.Roomid).ToList();
    }

    public virtual RoomsDto GetRoom(string roomId)
    {
        Room room = RoomLogic.Select(m => m.Roomid == roomId).FirstOrDefault();

        if (room == null)
        {
            return null;
        }

        return GetRoom(room.Id);
    }

    public virtual RoomsDto GetRoom(int roomId)
    {
        Room room = RoomLogic.Select(m => m.Id == roomId).FirstOrDefault();

        if (room == null)
        {
            return null;
        }

        RoomsDto result = new RoomsDto();

        result.IdRoom = room.Id;
        result.RoomName = room.Roomname;
        result.OwnerEmail = room.Owneremail;
        result.RoomId = room.Roomid;
        //TODO isapproved
        List<string> membersEmails = RoomsAccountLogic.Select(m => m.Idroom == room.Id).Select(m => m.Memberemail).ToList();

        result.RoomMembers = new List<RoomMembersDto>();

        foreach (string member in membersEmails)
        {
            RoomMembersDto roomMember = GetRoomMemberByEmail(member);

            if (roomMember != null)
            {
                result.RoomMembers.Add(roomMember);
            }
        }

        return result;
    }

    protected virtual RoomMembersDto GetRoomMemberByEmail(string memberEmail)
    {
        UserCacheDto member = AccountService.GetAccount(memberEmail);

        if (member == null)
        {
            return null;
        }

        return new RoomMembersDto()
        {
            CreatedAt = member.AccountCreatedAt, IdAccount = member.IdAccount, Email = member.SenderEmail,
            FirstName = member.UserName, LastName = member.UserSurname, PushTokens = member.PushTokens
        };
    }
}