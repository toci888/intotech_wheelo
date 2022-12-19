﻿using ExpoCommunityNotificationServer.Client;
using ExpoCommunityNotificationServer.Models;
using Intotech.Wheelo.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Notifications
{
    public class NotificationClient : INotificationClient
    {
        private const string AccessToken = "HiEwn2qhRGh2GkVX7jhS3FG1GP88Ilx9kV1KD84Z";

        protected PushApiClient PushApiClient;

        public NotificationClient()
        {
            PushApiClient = new PushApiClient();
        }


    }
}
