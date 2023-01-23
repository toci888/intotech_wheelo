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
        ChatMessageDto SendMessage(ChatMessageDto chatMessage);
    }
}