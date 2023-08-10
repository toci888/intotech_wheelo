using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Models
{
    public class LiveChatMessageDto : ChatMessageDto
    {
        public AuthorDto Author { get; set; }
    }
}
