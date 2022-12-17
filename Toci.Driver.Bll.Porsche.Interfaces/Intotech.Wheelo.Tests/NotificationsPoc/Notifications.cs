using ExpoCommunityNotificationServer.Client;
using ExpoCommunityNotificationServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Tests.NotificationsPoc
{
    [TestClass]
    public class Notifications
    {
        [TestMethod]
        public void doopa()
        {
            
            PushApiClient pac = new PushApiClient("ExponentPushToken[XqgL8PLm-p-XsCtlZ_dapr]", new HttpClient() { BaseAddress = new Uri("https://exp.host/") } );

            pac.SetToken("ExponentPushToken[XqgL8PLm-p-XsCtlZ_dapr]");

            PushTicketResponse resp = pac.SendPushAsync(new PushTicketRequest() { PushBody = "Witam Szefa :)", PushSubTitle = "Bartek z tej strony :P" } ).Result;
        }
    }
}
