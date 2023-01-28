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
        protected Dictionary<NotificationsKinds, NotificationDataField<TNotificationData>> NotificationKindDataMapper = new Dictionary<NotificationsKinds, NotificationDataField<TNotificationData>>()
        {
            { NotificationsKinds.Settings, new NotificationDataField<TNotificationData>() { root = "AccountRoot", screen = "Settings" } },
            { NotificationsKinds.Saved, new NotificationDataField<TNotificationData>() { root = "Root", screen = "Saved" } },
            { NotificationsKinds.AccountRoot, new NotificationDataField<TNotificationData>() { root = "Root", screen = "AccountRoot" } },
            { NotificationsKinds.SignIn, new NotificationDataField<TNotificationData>() { root = "SignIn" } },
            { NotificationsKinds.Search, new NotificationDataField<TNotificationData>() { root = "Root", screen = "Search" } },
            { NotificationsKinds.Chat, new NotificationDataField<TNotificationData>() { root = "Chat", screen = "Messages" } },
        };

        protected List<string> PushTokens { get; set; }
        protected NotificationDataField<TNotificationData> NotificationCustomData;

        public NotificationModelBase(NotificationsKinds notificationKinds, List<string> pushTokens, TNotificationData notificationCustomData, string messageBody, 
            string messageTitle, string messageSubtitle)
        {
            PushTokens = pushTokens;

            NotificationCustomData = ResolveKind(notificationKinds);

            NotificationCustomData.screenParams = notificationCustomData;
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

        protected virtual NotificationDataField<TNotificationData> ResolveKind(NotificationsKinds notificationKinds)
        {
            if (NotificationKindDataMapper.ContainsKey(notificationKinds))
            {
                return NotificationKindDataMapper[notificationKinds];
            }

            return new NotificationDataField<TNotificationData>();
        }
    }
}

/*
     navigation.navigate("AccountRoot", {screen: "Settings"}) 
navigation.navigate("Root", {screen: "Saved"})
navigation.navigate("Root", {screen: "AccountRoot"});
navigation.navigate("SignIn")
navigation.navigate("SignUp", {screen: ""})
navigation.navigate("SignUp")
navigation.navigate("EditProperty", { collocationId: collocation.idAccount });
navigation.navigate("Root", {
screen: "Search",
params: {
  startLocation,
  endLocation,
  startLocationTime: startTime,
  endLocationTime: endTime
}
}
     */
