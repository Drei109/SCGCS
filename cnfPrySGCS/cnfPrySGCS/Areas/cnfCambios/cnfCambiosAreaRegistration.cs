using System.Web.Mvc;

namespace cnfPrySGCS.Areas.cnfCambios
{
    public class cnfCambiosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "cnfCambios";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "cnfCambios_default",
                "cnfCambios/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}