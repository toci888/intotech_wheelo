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
using Intotech.Wheelo.Common.Interfaces.Models;
using System.Text.Json;

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
                new NotificationModelBase<SignInNotification>(NotificationsKinds.SignIn, new List<string>() { PushTokenKacper },  //
                new SignInNotification(), "Sign In test body", "Sign In test", "Sign In test subtitle"));

        }

        [TestMethod]
        public void NotificationSettingsInTest()
        {
            NotificationManager.SendNotifications<SignInNotification>(
                new NotificationModelBase<SignInNotification>(NotificationsKinds.Settings, new List<string>() { PushTokenKacper },  //
                new SignInNotification(), "settings test body", "settings test", "settings test subtitle"));

        }

        [TestMethod]
        public void NotificationSavedTest()
        {
            NotificationManager.SendNotifications<SignInNotification>(
                 new NotificationModelBase<SignInNotification>(NotificationsKinds.Saved, new List<string>() { PushTokenKacper },  //
                 new SignInNotification(), "saved test body", "saved test", "saved test subtitle"));

        }

        [TestMethod]
        public void NotificationSearchTest()
        {
            WorkTripSearchDto searchDto = JsonSerializer.Deserialize<WorkTripSearchDto>(SearchJson(), new JsonSerializerOptions() { AllowTrailingCommas = true });

            NotificationManager.SendNotifications<WorkTripSearchDto>(
               new NotificationModelBase<WorkTripSearchDto>(NotificationsKinds.Search, new List<string>() { PushTokenKacper },  //PushTokenKacper
                searchDto, "Search test body", "Search test", "Search test subtitle"));

        }

        private string SearchJson()
        {
            return "{\r\n  \"endLocation\": {\r\n    \"address\": {\r\n      \"city\": \"Wrocław\",\r\n      \"country\": \"Polska\",\r\n      \"country_code\": null,\r\n      \"house_number\": null,\r\n      \"name\": \"Wrocław, 51\",\r\n      \"postcode\": \"51\",\r\n      \"road\": null,\r\n      \"state\": \"Dolnośląskie\",\r\n    },\r\n    \"display_name\": \"Wrocław, 51\",\r\n    \"lat\": \"51.107883\",\r\n    \"lon\": \"17.038538\",\r\n    \"place_id\": \"ChIJv4q11MLpD0cR9eAFwq5WCbc\",\r\n  },\r\n  \"endLocationTime\": \"16:00\",\r\n  \"startLocation\": {\r\n    \"address\": {\r\n      \"city\": \"Poznań\",\r\n      \"country\": \"Polska\",\r\n      \"country_code\": null,\r\n      \"house_number\": null,\r\n      \"name\": \"Poznań, 62\",\r\n      \"postcode\": \"62\",\r\n      \"road\": null,\r\n      \"state\": \"Wielkopolskie\",\r\n    },\r\n    \"display_name\": \"Poznań, 62\",\r\n    \"lat\": \"52.406376\",\r\n    \"lon\": \"16.925169\",\r\n    \"place_id\": \"ChIJtwrh7NJEBEcR0b80A5gx6qQ\",\r\n  },\r\n  \"startLocationTime\": \"08:00\"\r\n}";
        }
    
    }
}
