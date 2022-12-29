using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Integration.Bll.Skoda.Google
{
    public class GooglePredictionsGeoModelClient : GoogleMapsClientBase, IGoogleMapsClient<string, GooglePredictionsGeoModel>
    {
        public virtual GooglePredictionsGeoModel CallMapApi(string query)
        {
            string uri = string.Format("maps/api/place/autocomplete/json?input={0}&components=country:pl&language=pl&types=geocode&key={1}", query, ApiKey);

            string json = HttpClient.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<GooglePredictionsGeoModel>(json);
        }
    }
}
