using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Intotech.Wheelo.Bll.Porsche.User;
using Intotech.Wheelo.Notifications.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intotech.Wheelo.Notifications;
using Intotech.Wheelo.Notifications.Interfaces.Models.DataNotification;
using Intotech.Wheelo.Notifications.Interfaces.Models;

namespace Intotech.Wheelo.Tests.NotificationsPoc.NotificationsTests
{
    [TestClass]
    public class NotificationNavigationTests
    {
        protected INotificationManager NotificationManager;

        protected string PushTokenKacper = "ExponentPushToken[XqgL8PLm-p-XsCtlZ_dapr]";
        protected string PushTokenBartek = "ExponentPushToken[rtWCLaAF92lqq4mIgmzvRV]";

        public NotificationNavigationTests()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddTransient<INotificationClient, NotificationClient>();
            services.AddTransient<INotificationManager, NotificationManager>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            NotificationManager = serviceProvider.GetService<INotificationManager>();
        }

        [TestMethod]
        public void NotificationSignInTest()
        {
            NotificationManager.SendNotifications<SignInNotification>( 
                new NotificationModelBase<SignInNotification>(NotificationsKinds.SignIn, new List<string>() { PushTokenBartek },  //PushTokenKacper
                new SignInNotification(), "Sign In test body", "Sign In test", "Sign In test subtitle"));

        }

        [TestMethod]
        public void NotificationSavedTest()
        {
           // NotificationManager.SendNotifications<AssociationNotification>(NotificationsKinds.Association,
             //   new NotificationModelBase<AssociationNotification>(new List<string>() { PushTokenBartek },  //PushTokenKacper
               // new NotificationDataField<AssociationNotification>() { screen = "Saved", screenParams = null, root = "Root" }, "Saved test body", "Saved test", "Saved test subtitle"));

        }

        [TestMethod]
        public void NotificationSettingsTest()
        {
           // NotificationManager.SendNotifications<AssociationNotification>(NotificationsKinds.Association,
             //   new NotificationModelBase<AssociationNotification>(new List<string>() { PushTokenBartek },  //PushTokenKacper
               // new NotificationDataField<AssociationNotification>() { screen = "Saved", screenParams = null, root = "Root" }, "Saved test body", "Saved test", "Saved test subtitle"));

        }

    
    }
}
