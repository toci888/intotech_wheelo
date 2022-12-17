using ExpoCommunityNotificationServer.Client;
using ExpoCommunityNotificationServer.Models;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
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

            // new HttpClient() { BaseAddress = new Uri("https://expo.dev/") } );

            //pac.SetToken("AAAAF_FlC3I:APA91bFTbLX6KEcC_m2LSJsjJncYLUvD2BzOkTVInPjHHXPtypzRBudrCOxgxBCHJuyo6cJSwzVNsMQ0BefDAWk4kiJtZB2-bitBgKUITF9mV0wUbMh1hRWUx4MtRA3DI0gCOUgMTjpI");
            string myPushToken = "ExponentPushToken[rtWCLaAF92lqq4mIgmzvRV]";

            try
            {
                FirebaseApp fireBase = FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.GetApplicationDefault()
                });

                FirebaseAuth fireBaseAuth = FirebaseAuth.GetAuth(fireBase);

                //fireBaseAuth.GetUserAsync().Result.

                Message mess = new Message() { Token = myPushToken, Notification = new Notification() { Body = "doopa", Title = "Lol Xd" } };

                //FirebaseMessaging.GetMessaging(fireBase).SendAsync(mess);

                string result = FirebaseMessaging.GetMessaging(fireBase).SendAsync(mess).Result;

                string token = fireBaseAuth.CreateCustomTokenAsync("102834178930").Result;

                PushApiClient pac = new PushApiClient(fireBase.Options.HttpClientFactory.CreateHttpClient(new Google.Apis.Http.CreateHttpClientArgs()));

                pac.SetToken(token);

                var x = fireBase.Options.Credential;

                var d = pac.SendPushAsync(new PushTicketRequest() { PushTo = new List<string>() { "ExponentPushToken[rtWCLaAF92lqq4mIgmzvRV]" }, PushBadgeCount = 7, PushTitle = "Me & Julietta", PushBody = "Witam Szefa :)", PushSubTitle = "Bartek z tej strony :P" }).Result;
            }
            catch (Exception ex)
            {
                
            }
        }
    }

    
}
