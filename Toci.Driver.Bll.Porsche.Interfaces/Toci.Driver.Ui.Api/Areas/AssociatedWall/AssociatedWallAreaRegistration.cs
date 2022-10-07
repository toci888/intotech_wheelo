using System.Web.Mvc;

namespace Toci.Driver.Ui.Api.Areas.AssociatedWall
{
    public class AssociatedWallAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AssociatedWall";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AssociatedWall_default",
                "AssociatedWall/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}