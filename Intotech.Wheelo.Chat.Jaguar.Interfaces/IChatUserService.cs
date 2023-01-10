﻿using Intotech.Wheelo.Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces
{
    public interface IChatUserService
    {
        ChatUserDto Connect(string email);

        //bool JoinRoom(int accountId, int roomId);

        //RequestConversationDto Invite(RequestConversationDto invitation);

        //ChatMessageDto SendMessage(ChatMessageDto chatMessage);
    }
}
