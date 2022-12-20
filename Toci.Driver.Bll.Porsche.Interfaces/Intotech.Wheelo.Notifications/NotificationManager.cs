using ExpoCommunityNotificationServer.Models;
using Intotech.Wheelo.Notifications.Interfaces;
using Intotech.Wheelo.Notifications.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Notifications
{
    public class NotificationManager : INotificationManager
    {
        protected Dictionary<NotificationsKinds, Func<NotificationModelBase, PushTicketResponse>> NotificationsRunners;

        protected INotificationClient NotificationClient;

        public NotificationManager(INotificationClient notificationClient)
        {
            NotificationClient = notificationClient;

            NotificationsRunners = new Dictionary<NotificationsKinds, Func<NotificationModelBase, PushTicketResponse>>()
            {
                { NotificationsKinds.Association, (notification) => NotificationClient.SendNotification(notification) }
            };
        }

        public virtual PushTicketResponse SendNotifications(NotificationsKinds notificationsKind, NotificationModelBase notificationModel)
        {
            if (NotificationsRunners.ContainsKey(notificationsKind))
            {
                return NotificationsRunners[notificationsKind](notificationModel);
            }

            return null;
        }
    }
}
