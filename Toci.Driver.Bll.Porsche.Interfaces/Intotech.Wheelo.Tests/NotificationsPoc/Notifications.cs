using ExpoCommunityNotificationServer.Client;
using ExpoCommunityNotificationServer.Models;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Tests.NotificationsPoc
{
    [TestClass]
    public class Notifications
    {
        [TestMethod]
        public void SendNotification()
        {
            string SERVER_API_KEY = "AAAAF_FlC3I:APA91bFTbLX6KEcC_m2LSJsjJncYLUvD2BzOkTVInPjHHXPtypzRBudrCOxgxBCHJuyo6cJSwzVNsMQ0BefDAWk4kiJtZB2 - bitBgKUITF9mV0wUbMh1hRWUx4MtRA3DI0gCOUgMTjpI";
            var SENDER_ID = "102834178930";

            string key = "59c9789b29b73f43e8aebf6021d0cb308eff6174";

            string ApiKey = "AIzaSyDxVQqaiKE1L6N9Etv9SUgKsEHfPr9Et40";

            string deviceToken = "eotQtMDpTkiwHRFDGEQRlL:APA91bGHj-SbymBwwgok_gqHoT-XDFMiF2MN978RFzpm3aaKRiHGJKrxWFu8SiNPOPwLLTS4rnm07qqHRHuACv0Om6wAUv5DipLej_VFb7lgZwthvHW4_0oWc5ykrwhLTggnMoC2itrj";

            WebRequest tRequest;
            tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));
            tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));


            //var data = new
            //{
            //    notification = new
            //    {
            //        body = "message",
            //        title = "title"
            //    }
            //      ,
            //    to = "/topics/marketing"
            //};

            string json = "{ to: \"" + deviceToken + "\", data: { message: \"Kurde\", name: \"Lol xd\" } }";

            //var serializer = new JavaScriptSerializer();

            //var json = serializer.Serialize(data);
            //logger.Info("json: " + json);
            Byte[] byteArray = Encoding.UTF8.GetBytes(json);
            tRequest.ContentLength = byteArray.Length;

            Stream dataStream = tRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse tResponse = tRequest.GetResponse();
            dataStream = tResponse.GetResponseStream();
            StreamReader tReader = new StreamReader(dataStream);
            String sResponseFromServer = tReader.ReadToEnd();

            tReader.Close();
            dataStream.Close();
            tResponse.Close();
            string x = sResponseFromServer;
        }

        [TestMethod]
        public void doopa()
        {

            string deviceToken = "eotQtMDpTkiwHRFDGEQRlL:APA91bGHj-SbymBwwgok_gqHoT-XDFMiF2MN978RFzpm3aaKRiHGJKrxWFu8SiNPOPwLLTS4rnm07qqHRHuACv0Om6wAUv5DipLej_VFb7lgZwthvHW4_0oWc5ykrwhLTggnMoC2itrj";

            WebpushConfig webC = new WebpushConfig();

            webC.Headers = new Dictionary<string, string>()
            {
                { "SenderId", "102834178930" }
            };

            // See documentation on defining a message payload.
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
    {
        { "score", "850" },
        { "time", "2:45" },
    },
                Token = deviceToken,
                Webpush = webC
            };

            string ServiceAccountFile = @"C:\Users\bzapa\source\pushtokens.txt";

            FirebaseApp fireBase = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(ServiceAccountFile),
                ProjectId = "wheelo-368119",
                ServiceAccountId = "102834178930"
            });

            CreateHttpClientArgs createHttpClientArgs = new Google.Apis.Http.CreateHttpClientArgs();

            createHttpClientArgs.ApplicationName = "wheelo-368119";

            ConfigurableHttpClient configurableHttpClient = fireBase.Options.HttpClientFactory.CreateHttpClient(createHttpClientArgs);

            configurableHttpClient.BaseAddress = new Uri("https://fcm.googleapis.com/");

            //HttpContent con = new HttpRequestMessage();

            //configurableHttpClient.PostAsync("fcm/send", );


            // Send a message to the device corresponding to the provided
            // registration token.
            string result = FirebaseMessaging.GetMessaging(fireBase).SendAsync(message, true).Result;


            // new HttpClient() { BaseAddress = new Uri("https://expo.dev/") } );

            //pac.SetToken("AAAAF_FlC3I:APA91bFTbLX6KEcC_m2LSJsjJncYLUvD2BzOkTVInPjHHXPtypzRBudrCOxgxBCHJuyo6cJSwzVNsMQ0BefDAWk4kiJtZB2-bitBgKUITF9mV0wUbMh1hRWUx4MtRA3DI0gCOUgMTjpI");
            string myPushToken = "ExponentPushToken[rtWCLaAF92lqq4mIgmzvRV]";
            //string deviceToken = "eotQtMDpTkiwHRFDGEQRlL:APA91bGHj-SbymBwwgok_gqHoT-XDFMiF2MN978RFzpm3aaKRiHGJKrxWFu8SiNPOPwLLTS4rnm07qqHRHuACv0Om6wAUv5DipLej_VFb7lgZwthvHW4_0oWc5ykrwhLTggnMoC2itrj";
            // AAAAF_FlC3I:APA91bFTbLX6KEcC_m2LSJsjJncYLUvD2BzOkTVInPjHHXPtypzRBudrCOxgxBCHJuyo6cJSwzVNsMQ0BefDAWk4kiJtZB2 - bitBgKUITF9mV0wUbMh1hRWUx4MtRA3DI0gCOUgMTjpI
            try
            { //102834178930
              //FirebaseApp fireBase = FirebaseApp.Create(new AppOptions()
              //{
              //    Credential = GoogleCredential.GetApplicationDefault(),
              //    ProjectId = "wheelo-368119"
              //});

                //fireBase.
                //https://fcm.googleapis.com/fcm/send

                //FirebaseAuth fireBaseAuth = FirebaseAuth.GetAuth(fireBase);

                ////fireBaseAuth.GetUserAsync().Result.

                //Message mess = new Message() { Token = deviceToken, Notification = new Notification() { Body = "doopa", Title = "Lol Xd" } };

                ////FirebaseMessaging.GetMessaging(fireBase).SendAsync(mess);

                //string result = FirebaseMessaging.GetMessaging(fireBase).SendAsync(mess).Result;

                //string token = fireBaseAuth.CreateCustomTokenAsync("102834178930").Result;

                //PushApiClient pac = new PushApiClient(fireBase.Options.HttpClientFactory.CreateHttpClient(new Google.Apis.Http.CreateHttpClientArgs()));

                //pac.SetToken(token);

                //var x = fireBase.Options.Credential;

                //var d = pac.SendPushAsync(new PushTicketRequest() { PushTo = new List<string>() { "ExponentPushToken[rtWCLaAF92lqq4mIgmzvRV]" }, PushBadgeCount = 7, PushTitle = "Me & Julietta", PushBody = "Witam Szefa :)", PushSubTitle = "Bartek z tej strony :P" }).Result;
            }
            catch (Exception ex)
            {

            }
        }
    }


}
