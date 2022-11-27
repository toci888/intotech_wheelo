using Intotech.Wheelo.Common.Interfaces.Google;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Google
{
    public class GooglePlaceToGeographicLocationConverter : IGooglePlaceToGeographicLocationConverter<GeographicLocation, GooglePlaceGeoModel>
    {
        //sublocality  administrative_area_level_1 - wojewodztwo country

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

        public virtual GeographicLocation Convert(GooglePlaceGeoModel googlePlaceGeoModel)
        {
            GeographicLocation geographicLocation = new GeographicLocation();

            geographicLocation = MapAddress(googlePlaceGeoModel.result.address_components, geographicLocation);

            geographicLocation.lat = googlePlaceGeoModel.result.geometry.location.lat.ToString();
            geographicLocation.lon = googlePlaceGeoModel.result.geometry.location.lng.ToString();

            geographicLocation.boundingbox = new string[] { 
                (googlePlaceGeoModel.result.geometry.location.lat - 0.002).ToString(), 
                (googlePlaceGeoModel.result.geometry.location.lat + 0.002).ToString(),
                (googlePlaceGeoModel.result.geometry.location.lng - 0.002).ToString(),
                (googlePlaceGeoModel.result.geometry.location.lng + 0.002).ToString()
            };

            geographicLocation.display_name = geographicLocation.display_address = 
                geographicLocation.address.ToString();
            geographicLocation.place_id = googlePlaceGeoModel.result.place_id;

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
