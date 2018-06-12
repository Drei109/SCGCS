using System.Web.Mvc;

namespace cnfPrySGCS.Areas.cnfMantenimiento
{
    public class cnfMantenimientoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "cnfMantenimiento";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "cnfMantenimiento_default",
                "cnfMantenimiento/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}