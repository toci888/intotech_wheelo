using Intotech.Wheelo.Chat.Database.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces
{
    public interface IMessagesService
    {
        Message AddMessage(Message message);


    }
}
