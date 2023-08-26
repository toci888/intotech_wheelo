using Intotech.Wheelo.Common.Interfaces.Models;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Converters;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Models;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Models.LatLng;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Integration.Bll.Skoda.Services
{
    public class GoogleMapsService : IGoogleMapsService
    {
        public const string InvalidRequest = "INVALID_REQUEST";
        public const string RequestDenied = "REQUEST_DENIED";

        protected IGoogleMapsClient<string, GooglePlaceGeoModel> PlaceIdGoogleClient;
        protected IGoogleMapsClient<string, GooglePredictionsGeoModel> PredictionsGoogleClient;
        protected IGoogleMapsClient<string, GoogleLatLngGeoModel> LatLngGoogleClient;
        protected IGooglePlaceToGeographicLocationConverter<GooglePlaceGeoModel, GeographicLocation> PlaceConverter;
        protected IGooglePlaceToGeographicLocationConverter<GooglePredictionsGeoModel, GeographicLocation[]> PredictionsConverter;
        protected IGooglePlaceToGeographicLocationConverter<GoogleLatLngGeoModel, GeographicLocation> LatLngConverter;

        public GoogleMapsService(IGoogleMapsClient<string, GooglePlaceGeoModel> placeIdGoogleClient, 
            IGoogleMapsClient<string, GooglePredictionsGeoModel> predictionsGoogleClient,
            IGooglePlaceToGeographicLocationConverter<GooglePlaceGeoModel, GeographicLocation> placeConverter,
            IGooglePlaceToGeographicLocationConverter<GooglePredictionsGeoModel, GeographicLocation[]> predictionsConverter,
            IGoogleMapsClient<string, GoogleLatLngGeoModel> latLngGoogleClient,
            IGooglePlaceToGeographicLocationConverter<GoogleLatLngGeoModel, GeographicLocation> latLngConverter) 
        {
            PlaceIdGoogleClient = placeIdGoogleClient;
            PredictionsGoogleClient = predictionsGoogleClient;
            LatLngGoogleClient = latLngGoogleClient;
            PredictionsConverter = predictionsConverter;
            PlaceConverter = placeConverter;
            LatLngConverter = latLngConverter;
        }

        public virtual GeographicLocation GetCurrentButtonLocation(string latitue, string longitude)
        {
            GoogleLatLngGeoModel result = LatLngGoogleClient.CallMapApi(latitue + "," + longitude);

            if (result.status == InvalidRequest)
            {
                return null;
            }

            return LatLngConverter.Convert(result);
        }

        public virtual GeographicLocation GetLocationByPlaceId(string placeId)
        {
            GooglePlaceGeoModel result = PlaceIdGoogleClient.CallMapApi(placeId);

            if (result.status == InvalidRequest)
            {
                return null; 
            }

            return PlaceConverter.Convert(result);
        }

        public virtual GeographicLocation[] GetLocationsByQueryText(string query)
        {
            GooglePredictionsGeoModel gPredModel = PredictionsGoogleClient.CallMapApi(query);

            if (gPredModel.status == InvalidRequest || gPredModel.status == RequestDenied)
            {
                return null;
            }

            return PredictionsConverter.Convert(gPredModel);
        }
    }
}
