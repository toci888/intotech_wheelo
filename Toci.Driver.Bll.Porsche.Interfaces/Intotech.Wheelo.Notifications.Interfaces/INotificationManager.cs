using ExpoCommunityNotificationServer.Models;
using Intotech.Wheelo.Notifications.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Notifications.Interfaces
{
    public interface INotificationManager
    {
        NotificationResponseDto SendNotifications<TNotificationData>(NotificationsKinds notificationsKind, NotificationModelBase<TNotificationData> notificationModel);
    }
}
