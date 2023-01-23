using ExpoCommunityNotificationServer.Client;
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
    public class NotificationClient : INotificationClient
    {
        //private const string AccessToken = "HiEwn2qhRGh2GkVX7jhS3FG1GP88Ilx9kV1KD84Z";
        private const string AccessToken = "4CBXDdgBr7SOrOc0x7eK2a9b-pVHV9Xt-IYjyQ2n";

        protected PushApiClient PushApiClient;

        public NotificationClient()
        {
            PushApiClient = new PushApiClient();

            PushApiClient.SetToken(AccessToken);
        }

        public virtual PushTicketResponse SendNotification<TNotificationData>(NotificationModelBase<TNotificationData> notification)
        {
            PushTicketResponse response = PushApiClient.SendPushAsync(notification.ToRequest()).Result;

            return response;
        }
    }
}
