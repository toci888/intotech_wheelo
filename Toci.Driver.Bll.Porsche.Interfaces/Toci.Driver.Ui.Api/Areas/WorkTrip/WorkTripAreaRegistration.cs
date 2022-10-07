using System.Web.Mvc;

namespace Toci.Driver.Ui.Api.Areas.WorkTrip
{
    public class WorkTripAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WorkTrip";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WorkTrip_default",
                "WorkTrip/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}