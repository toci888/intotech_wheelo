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

    public ConversationService(IMessageLogic messageLogic, IAccountService accountService, IRoomLogic roomLogic)
    {
        MessageLogic = messageLogic;
        AccountService = accountService;
        RoomLogic = roomLogic;
    }

    public virtual ConversationDto GetConversationById(string roomId)
    {
        List<Message> messages = MessageLogic.Select(m => m.Roomid == roomId).OrderBy(m => m.Createdat).ToList();

        List<Message> distinctAuthors = messages.DistinctBy(m => m.Idauthor).ToList();

        Dictionary<int, MessageAuthorDto> authorsData = GetDistinctNames(distinctAuthors);

        Room room = RoomLogic.Select(m => m.Roomid == roomId).First();

        Account acc = AccountService.GetAccount(room.Ownerid);

        ConversationDto resElement = new ConversationDto();

        resElement.OwnerID = room.Ownerid;
        resElement.CreatedAt = room.Createdat.Value;
        resElement.TenantID = resElement.ID = room.Roomid;
        resElement.OwnerFirstName = acc.Name;
        resElement.OwnerLastName = acc.Surname;
        resElement.Messages = new List<ChatMessageDto>();

        foreach (Message message in messages)
        {
            resElement.Messages.Add(new ChatMessageDto()
            {
                CreatedAt = message.Createdat.Value,
                SenderID = message.Idauthor,
                Text = message.Message1,
                ID = message.Id,
                AuthorFirstName = authorsData[message.Idauthor].MessageAuthorFirstName,
                AuthorLastName = authorsData[message.Idauthor].MessageAuthorLastName
            });
        }

        return resElement;
    }

    protected virtual Dictionary<int, MessageAuthorDto> GetDistinctNames(List<Message> distinctAuthors)
    {
        Dictionary<int, MessageAuthorDto> result = new Dictionary<int, MessageAuthorDto>();

        foreach (Message message in distinctAuthors)
        {
            MessageAuthorDto resElement = new MessageAuthorDto();

            Account acc = AccountService.GetAccount(message.Idauthor);

            resElement.MessageAuthorFirstName = acc.Name;
            resElement.MessageAuthorLastName = acc.Surname;

            result.Add(message.Idauthor, resElement);
        }

        return result;
    }
}