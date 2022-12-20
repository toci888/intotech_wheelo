using ExpoCommunityNotificationServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Notifications.Interfaces.Models
{
    public abstract class NotificationModelBase
    {
        public abstract PushTicketRequest ToRequest();
    }
}
