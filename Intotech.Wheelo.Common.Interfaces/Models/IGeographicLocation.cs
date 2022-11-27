using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Models
{
    public interface IGeographicLocation
    {
        string place_id { get; set; }
        string osm_id { get; set; }
        string osm_type { get; set; }
        string lat { get; set; }
        string lon { get; set; }
        string[] boundingbox { get; set; }
        string Class { get; set; }
        string type { get; set; } //"city" | "state" | "country" | string;
        string display_name { get; set; }
        string display_place { get; set; }
        string display_address { get; set; }
        IAddress address { get; set; }
    }
}
