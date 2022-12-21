using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Jaguar
{
    public class MessagesService : IMessagesService
    {
        protected IMessageLogic MessageLogic;
        protected IRoomLogic RoomLogic;

        public MessagesService(IMessageLogic messageLogic, IRoomLogic roomLogic)
        {
            MessageLogic = messageLogic;
            RoomLogic = roomLogic;
        }

        public virtual Message AddMessage(Message message)
        {
            //Room room = RoomLogic.Select(m => m.Id == message.Idroom).FirstOrDefault();



            Message result = MessageLogic.Insert(message);

            return result;
        }

        public virtual Room CreateRoom(int userInitiatingId, int userMessagedId)
        {
            return null; 
        }
    }
}
