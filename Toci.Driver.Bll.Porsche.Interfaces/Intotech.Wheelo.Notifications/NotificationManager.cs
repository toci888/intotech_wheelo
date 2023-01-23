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
        protected INotificationClient NotificationClient;

        public NotificationManager(INotificationClient notificationClient)
        {
            NotificationClient = notificationClient;
        }

        public virtual NotificationResponseDto SendNotifications<TNotificationData>(NotificationModelBase<TNotificationData> notificationModel)
        {
            PushTicketResponse response = NotificationClient.SendNotification(notificationModel);

            //response.Errors.

            return new NotificationResponseDto(); // TODO
        }         
    }
}
