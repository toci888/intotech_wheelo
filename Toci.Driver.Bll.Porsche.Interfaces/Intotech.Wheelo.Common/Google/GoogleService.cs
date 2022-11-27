using Intotech.Wheelo.Common.Interfaces.Google;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Google
{
    public class GoogleService : IGoogleService
    {
        protected GoogleMapsClient GoogleClient = new GoogleMapsClient();
        protected GooglePlaceToGeographicLocationConverter Converter = new GooglePlaceToGeographicLocationConverter();

        public virtual GeographicLocation GetLocationByPlaceId(string placeId)
        {
            GooglePlaceGeoModel googleModel = GoogleClient.CallGoogleApiPlaceId(placeId);

            return Converter.Convert(googleModel);
        }
    }
}
