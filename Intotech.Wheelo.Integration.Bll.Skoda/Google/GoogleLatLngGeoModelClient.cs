using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Models;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Models.LatLng;
using System.Text.Json;

namespace Intotech.Wheelo.Integration.Bll.Skoda.Google
{
    public class GoogleLatLngGeoModelClient : GoogleMapsClientBase, IGoogleMapsClient<string, GoogleLatLngGeoModel>
    {
        public virtual GoogleLatLngGeoModel CallMapApi(string request)
        {
            string uri = string.Format("maps/api/geocode/json?latlng={0}&key={1}", request, ApiKey); //52.38701409770692,16.88172339782029

            string json = HttpClient.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<GoogleLatLngGeoModel>(json);
        }
    }
}
