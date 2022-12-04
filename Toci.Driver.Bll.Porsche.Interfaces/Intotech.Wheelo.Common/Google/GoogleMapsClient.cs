using Intotech.Wheelo.Common.Interfaces.Google;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Google
{
    public class GoogleMapsClient : IGoogleMapsClient<string, GooglePlaceGeoModel>
    {
        private const string ApiKey = "AIzaSyDxVQqaiKE1L6N9Etv9SUgKsEHfPr9Et40";
        //ChIJ0eZpEy9FBEcRieu3xGIT0wc
        private const string Url = "https://maps.googleapis.com/";
        private const string Uri = "maps/api/place/details/json?language=pl&place_id={0}&key={1}";


        protected HttpClient HttpClient = new HttpClient();

        public virtual GooglePlaceGeoModel CallGoogleApiPlaceId(string request)
        {
            string uri = string.Format(Uri, request, ApiKey);

            HttpClient.BaseAddress = new Uri(Url);

            string json = HttpClient.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<GooglePlaceGeoModel>(json);
        }

        public virtual GooglePredictionsGeoModel CallGoogleAutocomplete(string query)
        {
            string uri = string.Format("maps/api/place/autocomplete/json?input={0}&language=pl&types=geocode&key={1}", query, ApiKey);

            HttpClient.BaseAddress = new Uri(Url);

            string json = HttpClient.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<GooglePredictionsGeoModel>(json);
        }
    }
}
