using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Notifications.Interfaces.Models.DataNotification
{
    public class ChatNotification
    {
        public int RoomId { get; set; }
        public string AuthorEmail { get; set; }
        public string Message { get; set; }
        public int AuthorAccountId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
