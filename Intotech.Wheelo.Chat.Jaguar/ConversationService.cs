using Intotech.Wheelo.Chat.Bll.Persistence;
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

    public virtual List<ConversationDto> GetConversationById(string roomId)
    {
        List<ConversationDto> result = new List<ConversationDto>();

        List<Message> messages = MessageLogic.Select(m => m.Roomid == roomId).OrderBy(m => m.Createdat).ToList();

        List<Message> distinctAuthors = messages.DistinctBy(m => m.Idauthor).ToList();

        Dictionary<int, MessageAuthorDto> authorsData = GetDistinctNames(distinctAuthors);

        Room room = RoomLogic.Select(m => m.Roomid == roomId).First();

        ConversationDto resElement = new ConversationDto();

        //resElement.OwnerID = messages.First.Idauthor;
       // resElement.CreatedAt = message.Createdat.Value;

        foreach (Message message in messages)
        {
            

            
            //resElement. = message.Message1;
            //resElement.RoomId = message.Roomid;
            //resElement.MessageAuthorFirstName = authorsData[message.Idauthor].MessageAuthorFirstName;
            //resElement.MessageAuthorLastName = authorsData[message.Idauthor].MessageAuthorLastName;

            result.Add(resElement);
        }

        return result;
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