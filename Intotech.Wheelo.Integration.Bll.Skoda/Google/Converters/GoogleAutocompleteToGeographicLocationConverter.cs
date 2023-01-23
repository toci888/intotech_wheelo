using Intotech.Wheelo.Common.Interfaces.Models;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Converters;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Google
{
    public class GoogleAutocompleteToGeographicLocationConverter : IGooglePlaceToGeographicLocationConverter<GooglePredictionsGeoModel, GeographicLocation[]>
    {
    
       public virtual GeographicLocation[] Convert(GooglePredictionsGeoModel googlePlaceGeoModel)
        {
            List<GeographicLocation> glList = new List<GeographicLocation>();

            foreach (Prediction prediction in googlePlaceGeoModel.predictions)
            {
                GeographicLocation geographicLocation = new GeographicLocation()
                {
                    place_id = prediction.place_id,
                    display_name = prediction.description,
                    lat = string.Empty, 
                    lon = string.Empty,
                };

                geographicLocation.address.name = prediction.description;

                glList.Add(geographicLocation);
            }

            return glList.ToArray();
        }
    }
}
