using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Google
{
    public interface IGooglePlaceToGeographicLocationConverter<TGeographicLocation, TGooglePlaceGeoModel>
    {
        //https://maps.googleapis.com/maps/api/place/details/json?place_id=ChIJ0eZpEy9FBEcRieu3xGIT0wc&key=AIzaSyDxVQqaiKE1L6N9Etv9SUgKsEHfPr9Et40
        TGeographicLocation Convert(TGooglePlaceGeoModel googlePlaceGeoModel);
    }
}
