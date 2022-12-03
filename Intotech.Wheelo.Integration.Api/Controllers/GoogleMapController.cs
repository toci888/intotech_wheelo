using Intotech.Wheelo.Common.Google;
using Intotech.Wheelo.Common.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intotech.Wheelo.Integration.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoogleMapController : ControllerBase
    {
        [HttpGet("recognize-place-id")]
        public virtual GeographicLocation GetLocationByPlaceId(string placeId)
        {
            GeographicLocation x = new GoogleService().GetLocationByPlaceId(placeId);

            if (x == null)
            {
                return null;
            }

            x.address.name = x.display_name;
            x.lon = x.lon.Replace(",", ".");
            x.lat = x.lat.Replace(",", ".");
            return x;
        }

        [HttpGet("address-autocomplete")]
        public virtual GeographicLocation[] GetAutocompleteHints(string query)
        {
            
            return new GoogleService().GetLocationsByQueryText(query);
        }
    }
}