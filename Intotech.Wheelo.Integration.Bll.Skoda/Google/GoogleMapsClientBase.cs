using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Integration.Bll.Skoda.Google
{
    public abstract class GoogleMapsClientBase : IGoogleMapsClientBase
    {
        protected const string ApiKey = "AIzaSyBG5S1teD2Ao2xzvqcxL4JYYfdGn4CykE0";
        protected const string Url = "https://maps.googleapis.com/";

        protected HttpClient HttpClient;

        protected GoogleMapsClientBase()
        {
            HttpClient = new HttpClient();

            HttpClient.BaseAddress = new Uri(Url);
        }
    }
}
