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
using System.Net.Http.Json;
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
            //102834178930-t16uufr3sf8jk6g0evgv335dudjon7vu.apps.googleusercontent.com

            //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

            string SERVER_API_KEY = "AAAAF_FlC3I:APA91bFTbLX6KEcC_m2LSJsjJncYLUvD2BzOkTVInPjHHXPtypzRBudrCOxgxBCHJuyo6cJSwzVNsMQ0BefDAWk4kiJtZB2 - bitBgKUITF9mV0wUbMh1hRWUx4MtRA3DI0gCOUgMTjpI";
            var SENDER_ID = "102834178930";
            string yetAnotherKey = "BN7CbsQa5qnoxkZYbExHYE6TDULyJluPbc3nbF9GSxjrQrwgyN7XkvfYdcL8FehegrNgTX9qSATnPcqHhl9TOs4";
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

            string json = "{ to: \"" + deviceToken + "\", body: \"message\", title: \"title\", data: { message: \"Kurde\", name: \"Lol xd\" } }";

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

            PushApiClient pac = new PushApiClient();
            string devToken = "ExponentPushToken[rtWCLaAF92lqq4mIgmzvRV]";

            pac.SetToken("HiEwn2qhRGh2GkVX7jhS3FG1GP88Ilx9kV1KD84Z"); // HERE !!!!!!!!!!!!!!!!!!!!!!

            PushTicketRequest ptr = new PushTicketRequest() {
                PushTo = new List<string>() { "ExponentPushToken[rtWCLaAF92lqq4mIgmzvRV]", "ExponentPushToken[XqgL8PLm-p-XsCtlZ_dapr]" },
                PushBadgeCount = 7,
                PushTitle = "Me & Julietta",
                PushBody = "Witam Szefa :)",
                PushSubTitle = "Bartek z tej strony :P",
                //PushSound = 
                PushData = new { test = "doopa" }
            };

            PushTicketResponse response = pac.SendPushAsync(ptr).Result;

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

            string isitright = "dsIjMYW-T-CWdi7qi6Roo-:APA91bHgjyLJnYv30_3tg6r-noKERA-rcxK-UH2T4feVacd7VkX02e_kOS-FHV3i2Wp1rmqBcvZDNSzxmzSbQpkiXvB0Phx1cmt2B7TfSLQyHlEAKMSnvst9vLLudRLMuSknQ_5omn9U";

            
            //deviceToken
            string json = "{ to: \"" + isitright + "\", body: \"message\", title: \"title\", data: { message: \"Kurde\", name: \"Lol xd\" } }";

            string ServiceAccountFile = @"C:\Users\bzapa\source\pushtokens.txt";

            //ServiceAccountCredential serviceAccountCredential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer("102834178930"));
            //serviceAccountCredential.User

            

            //FirebaseAuth defaultAuth = FirebaseAuth.GetAuth(fireBase);


           // UserRecord rec = defaultAuth.GetUserByEmailAsync("bzapart@gmail.com").Result;

            //defaultAuth.sign

            /*
             "serviceAccounts": [
   {
    "email": "your.gserviceaccount.com",
    "scopes": [
     "https://www.googleapis.com/auth/cloud-platform",
     "https://www.googleapis.com/auth/userinfo.email"
     ]
    }
  ],
             */
            //GoogleCredential cred = fireBase.Options.Credential.CreateScoped("");

            //new OidcTokenOptions();

            //cred.GetOidcTokenAsync();
            //cred.GetOidcTokenAsync



            CreateHttpClientArgs createHttpClientArgs = new Google.Apis.Http.CreateHttpClientArgs();
            //fireBase.Options.Credential.CreateScoped();
            createHttpClientArgs.ApplicationName = "wheelo-368119";
            
            FirebaseApp fireBase = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(ServiceAccountFile).
                CreateScoped("https://www.googleapis.com/auth/firebase.messaging"), //.CreateWithUser("firebase-adminsdk-6a8bi@wheelo-368119.iam.gserviceaccount.com"),
                ProjectId = "wheelo-368119",
                ServiceAccountId = "59c9789b29b73f43e8aebf6021d0cb308eff6174\r\n13f83110ab17d2ea09dfd52e3e05521483e1dd2c",


            });

            ConfigurableHttpClient configurableHttpClient = fireBase.Options.HttpClientFactory.CreateHttpClient(createHttpClientArgs);

            configurableHttpClient.BaseAddress = new Uri("https://fcm.googleapis.com/");

            //configurableHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=AAAAF_FlC3I:APA91bFTbLX6KEcC_m2LSJsjJncYLUvD2BzOkTVInPjHHXPtypzRBudrCOxgxBCHJuyo6cJSwzVNsMQ0BefDAWk4kiJtZB2 - bitBgKUITF9mV0wUbMh1hRWUx4MtRA3DI0gCOUgMTjpI");
            //configurableHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=AIzaSyDxVQqaiKE1L6N9Etv9SUgKsEHfPr9Et40");
            //configurableHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=BN7CbsQa5qnoxkZYbExHYE6TDULyJluPbc3nbF9GSxjrQrwgyN7XkvfYdcL8FehegrNgTX9qSATnPcqHhl9TOs4");
//            configurableHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=59c9789b29b73f43e8aebf6021d0cb308eff6174");
            configurableHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=AAAAF_FlC3I:APA91bFTbLX6KEcC_m2LSJsjJncYLUvD2BzOkTVInPjHHXPtypzRBudrCOxgxBCHJuyo6cJSwzVNsMQ0BefDAWk4kiJtZB2-bitBgKUITF9mV0wUbMh1hRWUx4MtRA3DI0gCOUgMTjpI");
            configurableHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Sender", "id=102834178930");

            //fireBase.Options.HttpClientFactory = new HttpClientFactory();


            //HttpContent con = new HttpRequestMessage();
            
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "fcm/send");
            httpRequestMessage.Content = new StringContent(json);

            var dp = configurableHttpClient.SendAsync(httpRequestMessage).Result;

            //var dp = configurableHttpClient.SendAsync("fcm/send", new StringContent(json)).Result;

            Message mess = new Message() { Token = deviceToken, Notification = new Notification() { Body = "doopa", Title = "Lol Xd" } ,
                   
                FcmOptions= new FcmOptions() {  }
            };

            fireBase.Options.ServiceAccountId = deviceToken;

            FirebaseMessaging firebaseMessaging =  FirebaseMessaging.GetMessaging(fireBase);

            string resultOne = firebaseMessaging.SendAsync(new Message() { Token = isitright, Notification = new Notification() { Body = "doopa", Title = "jak to zadziala" } }).Result;

            //Mes mess = FirebaseMessaging.GetMessaging(fireBase); //.SendAsync(mess).Result;


            // Send a message to the device corresponding to the provided
            // registration token.
            //string result = FirebaseMessaging.GetMessaging(fireBase).SendAsync(message, true).Result;


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

               // Message mess = new Message() { Token = deviceToken, Notification = new Notification() { Body = "doopa", Title = "Lol Xd" } };

              //  string res = FirebaseMessaging.GetMessaging(fireBase).SendAsync(mess).Result;

                //string result = FirebaseMessaging.GetMessaging(fireBase).SendAsync(mess).Result;

                //string token = fireBaseAuth.CreateCustomTokenAsync("102834178930").Result;

                
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void challenge()
        {
            /*
               const message = {
    to: expoPushToken,
    sound: 'default',
    title: 'Original Title',
    body: 'And here is the body!',
    data: { someData: 'goes here' },
  };

  await fetch('https://exp.host/--/api/v2/push/send', {
    method: 'POST',
    headers: {
      Accept: 'application/json',
      'Accept-encoding': 'gzip, deflate',
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(message),
  });*/
            string devToken = "ExponentPushToken[rtWCLaAF92lqq4mIgmzvRV]";
            string json = "{ to: \"" + devToken + "\", data: { message: \"Kurde\", name: \"Lol xd\" } }";

            string json2 = "{\r\n    to: '" + devToken + "',\r\n    sound: 'default',\r\n    title: 'Original Title',\r\n    body: 'And here is the body!',\r\n    data: { someData: 'goes here' }\r\n  }";

            HttpClient cl = new HttpClient();

            cl.BaseAddress = new Uri("https://exp.host");

            cl.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
            cl.DefaultRequestHeaders.TryAddWithoutValidation("Accept-encoding", "gzip, deflaten");
            cl.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            HttpResponseMessage mess = cl.PostAsync("/--/api/v2/push/send", new StringContent(json2)).Result;
        }
    }


}
