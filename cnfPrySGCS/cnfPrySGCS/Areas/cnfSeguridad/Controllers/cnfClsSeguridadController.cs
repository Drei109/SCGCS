using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cnfPrySGCS.Models;

namespace cnfPrySGCS.Areas.cnfSeguridad.Controllers
{
    public class cnfClsSeguridadController : Controller
    {


        private cnfUSUpUsuario PobjUsuario = new cnfUSUpUsuario();
        // GET: cnfSeguridad/cnfClsSeguridad
        public ActionResult cnfFrmSeguridadVista(int id = 0)
        {
            return View();
           
        }
        public ActionResult mtdSeguridad(string Lstrusuario, string LstrPassword)
        {
            Session["GstrMensajeLogin"] = PobjUsuario.mtdSeguridad(Lstrusuario,LstrPassword);
            Session["GblnMostrarMensaje"] = false;

            if(Session["GstrMensajeLogin"].ToString().Contains("Bienvenido"))
            {
                Session["GblnMostrarMensaje"] = false;
                return Redirect("~/cnfMantenimiento/cnfClsUsuario/cnfFrmUsuarioVista");
            }
            else if(Session["GstrMensajeLogin"].ToString().Contains("Inactivo"))
            {
                Session["GblnMostrarMensaje"] = true;
                return Redirect("~/cnfSeguridad/cnfClsSeguridad/cnfFrmSeguridadVista");
            }
            else
            {
                Session["GblnMostrarMensaje"] = true;
                return Redirect("~/cnfSeguridad/cnfClsSeguridad/cnfFrmSeguridadVista");
            }
        }
    }
}