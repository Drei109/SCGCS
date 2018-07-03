using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cnfPrySGCS.Models;

namespace cnfPrySGCS.Areas.cnfProyecto.Controllers
{
    public class cnfClsProyectoMiembroController : Controller
    {
        cnfPMIpProyectoMiembro GobjProyectoMiembro = new cnfPMIpProyectoMiembro();
        // GET: cnfProyecto/cnfClsProyectoMiembro
        public ActionResult cnfFrmProyectoMiembroVista()
        {
            var codigoUsuario = (int)Session["GintCodigoUsuario"];
            ViewBag.GobjListarProyecto = mtdCargarComboProyecto(codigoUsuario);
            ViewBag.GblnCargarTabla = false;

            try
            {
                if (ViewBag.GblnMensaje == null)
                {
                    ViewBag.GblnMensaje = Convert.ToBoolean(Session["GblnMensaje"].ToString());
                    ViewBag.GstrMensajeRespuesta = Convert.ToString(Session["GstrMensajeRespuesta"].ToString());
                }
            }
            catch
            {

            }

            try
            {
                if (Session["GintCodigoProyecto"] != null)
                {
                    ViewBag.GobjListarDatos = mtdCargarDatos(Convert.ToInt32(Session["GintCodigoProyecto"]));
                    ViewBag.GobjListarCargoMiembro = mtdListarCargoMiembro(Convert.ToInt32(Session["GintCodigoProyecto"]));
                    ViewBag.GobjListarUsuario = mtdListarUsuario();
                    ViewBag.GblnCargarTabla = Convert.ToBoolean(Session["GblnCargarTabla"]);
                }
            }
            catch (Exception e)
            {

            }
            return View();
        }

        public object mtdCargarComboProyecto(int LintCodigoUsuario)
        {
            return GobjProyectoMiembro.mtdCargarComboProyecto(LintCodigoUsuario);
        }

        public ActionResult mtdCargarTablaMiembro(string ddlProyecto = "")
        {
            Session["GblnCargarTabla"] = false;

            if (Convert.ToInt32(ddlProyecto) == 0)
            {
                Session["GblnCargarTabla"] = false;
            }
            else
            {
                Session["GintCodigoProyecto"] = ddlProyecto;
                Session["GblnCargarTabla"] = true;
            }

            return Redirect("~/cnfProyecto/cnfClsProyectoMiembro/cnfFrmProyectoMiembroVista");
        }

        public object mtdCargarDatos(int LintCodigoProyecto)
        {
            return GobjProyectoMiembro.mtdCargarDatos(LintCodigoProyecto);
        }

        public object mtdListarCargoMiembro(int LintCodigoProyecto)
        {
            return GobjProyectoMiembro.mtdListarCargoMiembro(LintCodigoProyecto);
        }

        public object mtdListarUsuario()
        {
            return GobjProyectoMiembro.mtdListarUsuario();
        }

        public ActionResult mtdGuardar(string[] PMCcargo = null, string[] PMIestado = null, string[] LstrRegistro = null)
        {
            string LstrMensajeRespuesta = "";

            LstrMensajeRespuesta = GobjProyectoMiembro.mtdGuardar(PMCcargo, PMIestado, LstrRegistro, Convert.ToInt32(Session["GintCodigoProyecto"]));
            mtdRespuestaMensaje(LstrMensajeRespuesta);

            Session["GblnCargarTabla"] = false;

            return Redirect("~/cnfProyecto/cnfClsProyectoMiembro/cnfFrmProyectoMiembroVista");
        }

        public void mtdRespuestaMensaje(string LstrMensajeRespuesta)
        {
            if (LstrMensajeRespuesta.Equals("Correcto"))
            {
                Session["GblnMensaje"] = true;
                Session["GstrMensajeRespuesta"] = "La Operación se Realizó Correctamente";
            }
            else
            {
                Session["GblnMensaje"] = true;
                Session["GstrMensajeRespuesta"] = "Ocurrió un Fallo en la Operación";
            }
        }
    }
}