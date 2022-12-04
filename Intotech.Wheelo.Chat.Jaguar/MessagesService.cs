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

        public MessagesService(IMessageLogic messageLogic)
        {
            MessageLogic = messageLogic;
        }

        public virtual Message AddMessage(Message message)
        {
            Message result = MessageLogic.Insert(message);

            return result;
        }
    }
}
