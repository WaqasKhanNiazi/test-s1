using System.Web.Mvc;

namespace office360.Areas.ABilling
{
    public class ABillingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ABilling";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ABilling_default",
                "ABilling/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}