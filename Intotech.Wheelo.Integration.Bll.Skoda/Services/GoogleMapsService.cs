using Intotech.Wheelo.Common.Interfaces.Models;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Converters;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Models;
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

        protected IGoogleMapsClient<string, GooglePlaceGeoModel> PlaceIdGoogleClient;
        protected IGoogleMapsClient<string, GooglePredictionsGeoModel> PredictionsGoogleClient;
        protected IGooglePlaceToGeographicLocationConverter<GooglePlaceGeoModel, GeographicLocation> PlaceConverter;
        protected IGooglePlaceToGeographicLocationConverter<GooglePredictionsGeoModel, GeographicLocation[]> PredictionsConverter;

        public GoogleMapsService(IGoogleMapsClient<string, GooglePlaceGeoModel> placeIdGoogleClient, 
            IGoogleMapsClient<string, GooglePredictionsGeoModel> predictionsGoogleClient,
            IGooglePlaceToGeographicLocationConverter<GooglePlaceGeoModel, GeographicLocation> placeConverter,
            IGooglePlaceToGeographicLocationConverter<GooglePredictionsGeoModel, GeographicLocation[]> predictionsConverter) 
        {
            PlaceIdGoogleClient = placeIdGoogleClient;
            PredictionsGoogleClient = predictionsGoogleClient;
            PredictionsConverter = predictionsConverter;
            PlaceConverter = placeConverter;
        }

        public virtual GeographicLocation GetCurrentButtonLocation(string latitue, string longitude)
        {
            throw new NotImplementedException();
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

            if (gPredModel.status == InvalidRequest)
            {
                return null;
            }

            return PredictionsConverter.Convert(gPredModel);
        }
    }
}
