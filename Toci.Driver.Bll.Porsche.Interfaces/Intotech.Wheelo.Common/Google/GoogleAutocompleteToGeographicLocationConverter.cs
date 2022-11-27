using Intotech.Wheelo.Common.Interfaces.Google;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Google
{
    public class GoogleAutocompleteToGeographicLocationConverter : IGooglePlaceToGeographicLocationConverter<GeographicLocation[], GooglePredictionsGeoModel>
    {
    
       public virtual GeographicLocation[] Convert(GooglePredictionsGeoModel googlePlaceGeoModel)
        {
            List<GeographicLocation> glList = new List<GeographicLocation>();

            foreach (Prediction prediction in googlePlaceGeoModel.predictions)
            {
                glList.Add(new GeographicLocation()
                {
                    place_id= prediction.place_id,
                    display_name = prediction.description
                });
            }

            return glList.ToArray();
        }
    }
}
