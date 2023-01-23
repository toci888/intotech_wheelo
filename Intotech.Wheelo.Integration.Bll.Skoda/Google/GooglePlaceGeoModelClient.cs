using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Integration.Bll.Skoda.Google
{
    public class GooglePlaceGeoModelClient : GoogleMapsClientBase, IGoogleMapsClient<string, GooglePlaceGeoModel>
    {
        public virtual GooglePlaceGeoModel CallMapApi(string request)
        {
            string uri = string.Format("maps/api/place/details/json?language=pl&place_id={0}&key={1}", request, ApiKey);

            string json = HttpClient.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<GooglePlaceGeoModel>(json);
        }
    }
}
