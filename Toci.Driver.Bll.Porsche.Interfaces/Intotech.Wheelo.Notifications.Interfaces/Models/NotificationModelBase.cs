using ExpoCommunityNotificationServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Notifications.Interfaces.Models
{
    public class NotificationModelBase<TNotificationData>
    {
        protected List<string> PushTokens { get; set; }
        protected NotificationDataField<TNotificationData> NotificationCustomData;

        public NotificationModelBase(List<string> pushTokens, NotificationDataField<TNotificationData> notificationCustomData, string messageBody, 
            string messageTitle, string messageSubtitle)
        {
            PushTokens = pushTokens;
            NotificationCustomData = notificationCustomData;
            MessageBody = messageBody;
            MessageTitle = messageTitle;
            MessageSubtitle = messageSubtitle;
        }

        protected string MessageBody { get; set; }

        protected string MessageTitle { get; set; }

        protected string MessageSubtitle { get; set; }

        public virtual PushTicketRequest ToRequest()
        {
            return new PushTicketRequest() { PushTo = PushTokens, PushBody = MessageBody, PushData = NotificationCustomData, PushTitle = MessageTitle, 
                PushSubTitle = MessageSubtitle };
        }
    }
}
