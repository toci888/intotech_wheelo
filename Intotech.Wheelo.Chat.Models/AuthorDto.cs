using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Models
{
    public class AuthorDto
    {
        public DateTime CreatedAt { get; set; }
        public string SenderEmail { get; set; }
        public int IdAccount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public int IdRoom { get; set; }
        public string RoomId { get; set; }
    }
}
