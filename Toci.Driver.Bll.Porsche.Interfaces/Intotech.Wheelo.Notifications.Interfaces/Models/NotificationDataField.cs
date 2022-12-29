using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Notifications.Interfaces.Models
{
    public class NotificationDataField<TNotificationData>
    {
        public string root { get; set; }
        public string screen { get; set; }
        public TNotificationData screenParams { get; set; }
    }
}
