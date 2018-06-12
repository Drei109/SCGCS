using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cnfPrySGCS.Models;

namespace cnfPrySGCS.Areas.cnfProyecto.Controllers
{
    public class cnfClsProyectoEntregableController : Controller
    {
        
           cnfPYEpProyectoEntregable PobjProyectoEntregable = new cnfPYEpProyectoEntregable(); 
        // GET: cnfProyecto/cnfClsProyectoEntregable
        public ActionResult cnfFrmProyectoEntregableVista()
        {
            var usuarioId = (int) Session["GintCodigoUsuario"];
            ViewBag.GobjListarProyecto = mtdCargarComboProyecto(usuarioId);
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
                if(Session["GintCodigoProyecto"] != null)
                {
                    ViewBag.GobjListarDatos = mtdCargarDatos(Convert.ToInt32(Session["GintCodigoProyecto"]));
                    ViewBag.GobjListarDatosRelacion = mtdCargarDatosRelacion(Convert.ToInt32(Session["GintCodigoProyecto"]));
                    ViewBag.GobjListarFase = mtdListarFase(Convert.ToInt32(Session["GintCodigoProyecto"]));
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
            return PobjProyectoEntregable.mtdCargarComboProyecto(LintCodigoUsuario);
        }

        public ActionResult mtdCargarTablaEntregable(string ddlProyecto = "")
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

            return Redirect("~/cnfProyecto/cnfClsProyectoEntregable/cnfFrmProyectoEntregableVista");
        }

        public object mtdCargarDatos(int LintCodigoProyecto)
        {
            return PobjProyectoEntregable.mtdCargarDatos(LintCodigoProyecto);
        }

        public object mtdCargarDatosRelacion(int LintCodigoProyecto)
        {
            return PobjProyectoEntregable.mtdCargarDatosRelacion(LintCodigoProyecto);
        }

        public object mtdListarFase(int LintCodigoProyecto)
        {
            return PobjProyectoEntregable.mtdListarFase(LintCodigoProyecto);
        }

        public ActionResult mtdGuardar(string[] PYEfecha_InicioFase = null, string[] PYEfecha_FinFase = null, string[] LstrRegistro = null)
        {
            string LstrMensajeRespuesta = "";

            LstrMensajeRespuesta = PobjProyectoEntregable.mtdGuardar(PYEfecha_InicioFase, PYEfecha_FinFase, LstrRegistro, Convert.ToInt32(Session["GintCodigoProyecto"]));
            mtdRespuestaMensaje(LstrMensajeRespuesta);

            Session["GblnCargarTabla"] = false;

            return Redirect("~/cnfProyecto/cnfClsProyectoEntregable/cnfFrmProyectoEntregableVista");
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