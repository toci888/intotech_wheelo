using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Models
{
    public class RoomsDto
    {
        public string OwnerEmail { get; set; }
        public int IdRoom { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public List<RoomMembersDto> RoomMembers { get; set; }
    }
}
