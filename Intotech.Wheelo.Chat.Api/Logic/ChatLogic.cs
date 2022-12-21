using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;

namespace Intotech.Wheelo.Chat.Api.Logic
{
    public class ChatLogic
    {
        protected IMessagesService MessagesService;

        public ChatLogic(IMessagesService messagesService)
        {
            MessagesService = messagesService;
        }

        public bool SendMessage(ChatMessageDto chatMessage)
        {
            return MessagesService.AddMessage(new Message() 
            { 
                Idauthor = chatMessage.User.UserId,
                Idroom = chatMessage.RoomId,
                Message1 = chatMessage.Message
            }).Id != "0";
        }
    }
}
