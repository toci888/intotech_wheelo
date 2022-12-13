using Intotech.Common.Microservices;
using Intotech.Wheelo.Common.Google;
using Intotech.Wheelo.Common.Interfaces.Models;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Services;
using Intotech.Wheelo.Integration.Bll.Skoda.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intotech.Wheelo.Integration.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoogleMapController : ApiSimpleControllerBase<IGoogleMapsService>
    {
        public GoogleMapController(IGoogleMapsService service) : base(service)
        {
        }

        [HttpGet("recognize-place-id")]
        public virtual GeographicLocation GetLocationByPlaceId(string placeId)
        {
            GeographicLocation x = Service.GetLocationByPlaceId(placeId);

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
            
            return Service.GetLocationsByQueryText(query);
        }

        [HttpGet("current-button-location")]
        public GeographicLocation GetCurrentButtonLocation(string latitue, string longitude)
        {
            return Service.GetCurrentButtonLocation(latitue, longitude);
        }
    }
}