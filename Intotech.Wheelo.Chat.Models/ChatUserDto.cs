using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Models
{
    public class ChatUserDto
    {
        public string SenderEmail { get; set; }
        public int IdAccount { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string SessionId { get; set; }
        public string ImageUrl { get; set; }


    }
}
