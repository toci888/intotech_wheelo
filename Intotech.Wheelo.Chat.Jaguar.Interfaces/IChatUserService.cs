using Intotech.Wheelo.Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces
{
    public interface IChatUserService
    {
        ChatUserDto Connect(int accountId);

        bool JoinRoom(int accountId, string roomId);

        RequestConversationDto Invite(RequestConversationDto invitation);

        ChatMessageDto SendMessage(ChatMessageDto chatMessage);
    }
}
