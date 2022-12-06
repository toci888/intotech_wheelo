using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Models
{
    public class RequestConversationDto
    {
        public int InvitingAccountId { get; set; }
        public string InvitingUserName { get; set; }
        public int InvitedAccountId { get; set; }
        public string InvitedUserName { get; set; }
    }
}
