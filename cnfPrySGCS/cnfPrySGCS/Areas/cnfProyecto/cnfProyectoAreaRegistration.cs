using System.Web.Mvc;

namespace cnfPrySGCS.Areas.cnfProyecto
{
    public class cnfProyectoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "cnfProyecto";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "cnfProyecto_default",
                "cnfProyecto/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}