﻿using Intotech.Wheelo.Chat.Models;

namespace Intotech.Wheelo.Chat.Jaguar.Interfaces;

public interface IConversationService
{
    List<ConversationDto> GetConversationById(string roomId);
}