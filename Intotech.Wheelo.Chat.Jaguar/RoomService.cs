﻿using Intotech.Common;
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
        
        string accountIds = string.Join(", ", chatMembers.Select(m => m.Id).OrderBy(m => m).Select(m => m.ToString()));

        result.OwnerId = authorId;
        result.RoomId = HashGenerator.Md5(accountIds);

        foreach (Account chatMember in chatMembers)
        {
            RoomsAccountLogic.Insert(new Roomsaccount() { Roomid = result.RoomId, Idmember = chatMember.Id });
        }

        //Kacper, Julia, Bartek
        result.RoomName = string.Join(", ", chatMembers.Select(m => m.Name));

        RoomLogic.Insert(new Room() { Ownerid = authorId, Roomid = result.RoomId, Roomname = result.RoomName });

        return result;
    }
}