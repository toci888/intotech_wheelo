using Intotech.Wheelo.Common.Interfaces.Models;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Converters;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Models.LatLng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Integration.Bll.Skoda.Google.Converters
{
    public class GoogleLatLngToGeographicLocationConveter : IGooglePlaceToGeographicLocationConverter<GoogleLatLngGeoModel, GeographicLocation>
    {
        protected Dictionary<string, Func<Address_Components, GeographicLocation, GeographicLocation>> AddressMap =
            new Dictionary<string, Func<Address_Components, GeographicLocation, GeographicLocation>>()
            {
                { "postal_code", (component, geoLocation) => { geoLocation.address.postcode = component.long_name; return geoLocation; } },
                { "route", (component, geoLocation) => { geoLocation.address.road = component.long_name; return geoLocation; } },
                { "street_number", (component, geoLocation) => { geoLocation.address.house_number = component.long_name; return geoLocation; } },
                { "locality", (component, geoLocation) => { geoLocation.address.city = component.long_name; return geoLocation; } },
                { "administrative_area_level_1", (component, geoLocation) => { geoLocation.address.state = component.long_name; return geoLocation; } },
                { "country", (component, geoLocation) => { geoLocation.address.country = component.long_name; return geoLocation; } }
            };

        public virtual GeographicLocation Convert(GoogleLatLngGeoModel googlePlaceModel)
        {
            GeographicLocation geographicLocation = new GeographicLocation();

            Result data = googlePlaceModel.results.FirstOrDefault();

            if (data == null)
            {
                return null;
            }

            geographicLocation = MapAddress(data.address_components, geographicLocation);

            geographicLocation.lat = data.geometry.location.lat.ToString();
            geographicLocation.lon = data.geometry.location.lng.ToString();


            geographicLocation.display_name =
                geographicLocation.address.ToString();
            geographicLocation.place_id = data.place_id;

            return geographicLocation;
        }

        protected virtual GeographicLocation MapAddress(Address_Components[] address, GeographicLocation geoLoc)
        {
            foreach (KeyValuePair<string, Func<Address_Components, GeographicLocation, GeographicLocation>> itemMap in AddressMap)
            {
                foreach (Address_Components item in address)
                {
                    if (item.types.Contains(itemMap.Key))
                    {
                        itemMap.Value(item, geoLoc);
                    }
                }
            }

            return geoLoc;
        }
    }
}
