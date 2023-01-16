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
    protected IRoomsaccountLogic RoomsAccountLogic;

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

        Dictionary<string, MessageAuthorDto> authorsData = GetDistinctNames(distinctAuthors);

        Room room = RoomLogic.Select(m => m.Id == roomId).FirstOrDefault();

        if (room == null)
        {
            return null;
        }

        Account acc = AccountService.GetAccount(room.Ownerid);

        if (acc != null)
        {
            ConversationDto resElement = new ConversationDto();

            resElement.TenantID = resElement.ID = room.Id;
            resElement.OwnerID = room.Ownerid;
            resElement.IdAccount = acc.Id;
            resElement.CreatedAt = room.Createdat.Value;
            //= room.Roomid;
            resElement.OwnerFirstName = acc.Name;
            resElement.OwnerLastName = acc.Surname;
            resElement.Messages = new List<ChatMessageDto>();

            foreach (Message message in messages)
            {
                resElement.Messages.Add(new ChatMessageDto()
                {
                    CreatedAt = message.Createdat.Value,
                    SenderID = message.Authoremail,
                    Text = message.Message1,
                    ID = message.Id,
                    IdAccount = authorsData.ContainsKey(message.Authoremail) ? authorsData[message.Authoremail].AccountId : 0,
                    RoomID = roomId,
                    AuthorFirstName = authorsData.ContainsKey(message.Authoremail) ? authorsData[message.Authoremail].MessageAuthorFirstName : string.Empty,
                    AuthorLastName = authorsData.ContainsKey(message.Authoremail) ? authorsData[message.Authoremail].MessageAuthorLastName : string.Empty,
                    ImageUrl = authorsData.ContainsKey(message.Authoremail) ? authorsData[message.Authoremail].ImageUrl : string.Empty
                });

                if (isAccountIdRequest)
                {
                    break;
                }
            }

            return resElement;
        }

        return null;
    }

    public virtual List<ConversationDto> GetConversationsByAccountId(string email)
    {
        List<ConversationDto> conversations = new List<ConversationDto>();

        List<int> roomsIds = RoomsAccountLogic.Select(m => m.Memberemail == email).Select(m => m.Idroom).ToList();

        foreach (int roomId in roomsIds)
        {
            conversations.Add(GetConversationById(roomId, true));
        }

        return conversations;
    }

    protected virtual Dictionary<string, MessageAuthorDto> GetDistinctNames(List<Message> distinctAuthors)
    {
        Dictionary<string, MessageAuthorDto> result = new Dictionary<string, MessageAuthorDto>();

        foreach (Message message in distinctAuthors)
        {
            MessageAuthorDto resElement = new MessageAuthorDto();

            Account acc = AccountService.GetAccount(message.Authoremail);

            if (acc == null)
            {
                continue;
            }

            resElement.MessageAuthorFirstName = acc.Name;
            resElement.MessageAuthorLastName = acc.Surname;
            resElement.AccountId = acc.Id;
            resElement.ImageUrl = acc.Image;

            result.Add(message.Authoremail, resElement);
        }

        return result;
    }
}