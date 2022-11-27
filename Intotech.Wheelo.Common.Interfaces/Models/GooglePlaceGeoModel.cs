using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Models
{
    public class GooglePlaceGeoModel
    {
        public object[] html_attributions { get; set; }
        public Result result { get; set; }
        public string status { get; set; }
    }

    public class Result
    {
        public Address_Components[] address_components { get; set; }
        public string adr_address { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string icon_background_color { get; set; }
        public string icon_mask_base_uri { get; set; }
        public string name { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
        public string[] types { get; set; }
        public string url { get; set; }
        public int utc_offset { get; set; }
        public string vicinity { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
        public Viewport viewport { get; set; }
    }

    public class Location
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Northeast
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Southwest
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Address_Components
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; } //postal_code street_number route sublocality locality administrative_area_level_1 - wojewodztwo country
        /*
        {
            "long_name" : "6",
            "short_name" : "6",
            "types" : [ "street_number" ]
         },
         {
            "long_name" : "Kordeckiego",
            "short_name" : "Kordeckiego",
            "types" : [ "route" ]
         },
         {
            "long_name" : "Grunwald",
            "short_name" : "Grunwald",
            "types" : [ "sublocality_level_1", "sublocality", "political" ]
         },
         {
            "long_name" : "Poznań",
            "short_name" : "Poznań",
            "types" : [ "locality", "political" ]
         },
         {
            "long_name" : "Poznań",
            "short_name" : "Poznań",
            "types" : [ "administrative_area_level_2", "political" ]
         },
         {
            "long_name" : "Wielkopolskie",
            "short_name" : "Wielkopolskie",
            "types" : [ "administrative_area_level_1", "political" ]
         },
         {
            "long_name" : "Polska",
            "short_name" : "PL",
            "types" : [ "country", "political" ]
         },
         {
            "long_name" : "60-131",
            "short_name" : "60-131",
            "types" : [ "postal_code" ]
         }
        */
    }

}
