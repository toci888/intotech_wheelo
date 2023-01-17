﻿using Intotech.Wheelo.Chat.Bll.Persistence;
using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Chat.Dodge.Interfaces;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Jaguar;

public class ConversationService : IConversationService
{
    protected IMessageLogic MessageLogic;
    protected IRoomLogic RoomLogic;
    protected IAccountService AccountService;
    protected IRoomsaccountLogic RoomsAccountLogic;

    protected Dictionary<string, MessageAuthorDto> DistinctAuthors = new Dictionary<string, MessageAuthorDto>();

    public ConversationService(IMessageLogic messageLogic, IAccountService accountService, IRoomLogic roomLogic, IRoomsaccountLogic roomsAccountLogic)
    {
        MessageLogic = messageLogic;
        AccountService = accountService;
        RoomLogic = roomLogic;
        RoomsAccountLogic = roomsAccountLogic;
    }

    public virtual ConversationDto GetConversationById(int roomId, bool isAccountIdRequest = false)
    {
        List<Message> messages = MessageLogic.Select(m => m.Idroom == roomId).OrderByDescending(m => m.Createdat).ToList();

        List<Message> distinctAuthors = messages.DistinctBy(m => m.Authoremail).ToList();

        GetDistinctNames(distinctAuthors);

        Room room = RoomLogic.Select(m => m.Id == roomId).FirstOrDefault();

        if (room == null)
        {
            return null;
        }

        Account acc = AccountService.GetAccount(room.Ownerid);

        if (acc != null)
        {
            ConversationDto resElement = new ConversationDto();

            resElement.ID = room.Id;
            resElement.RoomName = room.Roomname;
            resElement.OwnerEmail = room.Ownerid;
            resElement.IdAccount = acc.Id;
            resElement.CreatedAt = room.Createdat.Value;
            resElement.OwnerFirstName = acc.Name;
            resElement.OwnerLastName = acc.Surname;
            resElement.Messages = new List<ChatMessageDto>();
            
            foreach (Message message in messages)
            {
                resElement.Messages.Add(new ChatMessageDto()
                {
                    CreatedAt = message.Createdat.Value,
                    SenderEmail = message.Authoremail,
                    Text = message.Message1,
                    ID = message.Id,
                    IdAccount = DistinctAuthors.ContainsKey(message.Authoremail) ? DistinctAuthors[message.Authoremail].Id : 0,
                    RoomID = roomId,
                    AuthorFirstName = DistinctAuthors.ContainsKey(message.Authoremail) ? DistinctAuthors[message.Authoremail].FirstName : string.Empty,
                    AuthorLastName = DistinctAuthors.ContainsKey(message.Authoremail) ? DistinctAuthors[message.Authoremail].LastName : string.Empty,
                    //ImageUrl = DistinctAuthors.ContainsKey(message.Authoremail) ? DistinctAuthors[message.Authoremail].ImageUrl : string.Empty
                });

                if (isAccountIdRequest)
                {
                    //resElement.UsersData = DistinctAuthors.Values.ToList();
                    break;
                }
            }

            if (!isAccountIdRequest)
            {
                resElement.RoomParticipants = GetRoomParticipants(roomId).Values.ToList();
            }

            return resElement;
        }

        return null;
    }

    public virtual FullConversationsDto GetConversationsByAccountId(string email)
    {
        FullConversationsDto result = new FullConversationsDto();

        result.Conversations = new List<ConversationDto>();

        List<int> roomsIds = RoomsAccountLogic.Select(m => m.Memberemail == email).Select(m => m.Idroom).Take(3).ToList();

        foreach (int roomId in roomsIds)
        {
            result.Conversations.Add(GetConversationById(roomId, true));
        }

        result.UsersData = DistinctAuthors.Values.ToList();

        return result;
    }

    protected virtual Dictionary<string, MessageAuthorDto> GetRoomParticipants(int roomId)
    {
        Dictionary<string, MessageAuthorDto> result = new Dictionary<string, MessageAuthorDto>();   

        List<Roomsaccount> roomsAccounts = RoomsAccountLogic.Select(m => m.Idroom == roomId).ToList();

        foreach (Roomsaccount item in roomsAccounts)
        {
            Account acc = AccountService.GetAccount(item.Memberemail);

            MessageAuthorDto resElement = new MessageAuthorDto();

            resElement.FirstName = acc.Name;
            resElement.LastName = acc.Surname;
            resElement.Id = acc.Id;
            resElement.ImageUrl = acc.Image;
            resElement.SenderEmail = acc.Email;

            result.Add(item.Memberemail, resElement);
        }

        return result;
    }

    protected virtual Dictionary<string, MessageAuthorDto> GetDistinctNames(List<Message> distinctAuthors)
    {
        foreach (Message message in distinctAuthors)
        {
            if (DistinctAuthors.ContainsKey(message.Authoremail))
            {
                continue;
            }

            MessageAuthorDto resElement = new MessageAuthorDto();

            Account acc = AccountService.GetAccount(message.Authoremail);

            if (acc == null)
            {
                continue;
            }

            resElement.FirstName = acc.Name;
            resElement.LastName = acc.Surname;
            resElement.Id = acc.Id;
            resElement.ImageUrl = acc.Image;
            resElement.SenderEmail = acc.Email;

            DistinctAuthors.Add(message.Authoremail, resElement);
        }

        return DistinctAuthors;
    }
}