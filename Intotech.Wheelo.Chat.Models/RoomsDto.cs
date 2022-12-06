using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Models
{
    public class RoomsDto
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public List<ChatUserDto> RoomUsers { get; set; }
    }
}
