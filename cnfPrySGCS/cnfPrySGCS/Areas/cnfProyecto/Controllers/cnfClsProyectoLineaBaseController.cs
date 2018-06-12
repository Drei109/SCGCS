using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cnfPrySGCS.Models;

namespace cnfPrySGCS.Areas.cnfProyecto.Controllers
{
    public class cnfClsProyectoLineaBaseController : Controller
    {
        cnfPLBpProyectoLineaBase PobjLineaBase = new cnfPLBpProyectoLineaBase();
        // GET: cnfProyecto/cnfClsProyectoLineaBase
        public ActionResult cnfFrmProyectoLineaBaseVista(int id = 0)
        {
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

            var codigoUsuario = (int)Session["GintCodigoUsuario"];

            ViewBag.GobjListarLineaBase = mtdCargarDatos(codigoUsuario);
            ViewBag.GobjListarProyecto = mtdCargarComboProyecto(codigoUsuario);
            Session["GblnMensaje"] = false;
            Session["GstrMensajeRespuesta"] = "";
            Session["GintPLBcodigo"] = id;
            return View(id == 0 ? new cnfPLBpProyectoLineaBase.cnfPLBpProyectoLineaBases()
                : mtdBuscar(id));
        }

        public object mtdCargarComboProyecto(int LintCodigoUsuario)
        {
            cnfPLBpProyectoLineaBase PobjLineaBase = new cnfPLBpProyectoLineaBase();
            return PobjLineaBase.mtdCargarComboProyecto(LintCodigoUsuario);
        }

        [HttpPost]
        public ActionResult mtdCargarComboFase(int PRYcodigo)
        {
            var codigoUsuario = (int)Session["GintCodigoUsuario"];
            cnfPLBpProyectoLineaBase LobjLineaBase = new cnfPLBpProyectoLineaBase();
            ViewBag.GobjListarFase = LobjLineaBase.mtdCargarComboFase(PRYcodigo);
            ViewBag.GobjListarProyecto = mtdCargarComboProyecto(codigoUsuario);
            ViewBag.GobjListarLineaBase = mtdCargarDatos(codigoUsuario);
            ViewBag.GintProyectoSeleccionado = PRYcodigo;
            return View("cnfFrmProyectoLineaBaseVista", Convert.ToInt32(Session["GintPLBcodigo"].ToString()) == 0 ? new cnfPLBpProyectoLineaBase.cnfPLBpProyectoLineaBases()
                : mtdBuscar(Convert.ToInt32(Session["GintPLBcodigo"].ToString())));
        }

        public object mtdBuscar(int LintCodigo)
        {
            cnfPLBpProyectoLineaBase PobjLineaBase = new cnfPLBpProyectoLineaBase();
            cnfPLBpProyectoLineaBase.cnfPLBpProyectoLineaBases LobjProyectoLineaBases = PobjLineaBase.mtdBuscar(LintCodigo);
            ViewBag.GobjListarFase = PobjLineaBase.mtdCargarComboFase(LobjProyectoLineaBases.PRYcodigo);
            return PobjLineaBase.mtdBuscar(LintCodigo);
        }

        public object mtdCargarDatos(int LintCodigoUsuario)
        {
            return PobjLineaBase.mtdCargarDatos(LintCodigoUsuario);
        }

        public ActionResult mtdGuardar(cnfPLBpProyectoLineaBase.cnfPLBpProyectoLineaBases LobjLineaBaseModelo)
        {
            string LstrMensajeRespuesta = "";

            cnfPLBpProyectoLineaBase LobjLineaBase = new cnfPLBpProyectoLineaBase();
            LobjLineaBase.PLBcodigo = LobjLineaBaseModelo.PLBcodigo;
            LobjLineaBase.PRYcodigo = LobjLineaBaseModelo.PRYcodigo;
            LobjLineaBase.MEFcodigo = LobjLineaBaseModelo.MEFcodigo;
            LobjLineaBase.PLBfecha_LineaBase = Convert.ToDateTime(LobjLineaBaseModelo.PLBfecha_LineaBase);
            LobjLineaBase.PLBestado = LobjLineaBaseModelo.PLBestado;

            if (LobjLineaBase.PLBcodigo == 0)
            {
                LstrMensajeRespuesta = LobjLineaBase.mtdGuardar(LobjLineaBase);
                mtdRespuestaMensaje(LstrMensajeRespuesta);
            }
            else
            {
                LstrMensajeRespuesta = mtdModificar(LobjLineaBase);
                mtdRespuestaMensaje(LstrMensajeRespuesta);

            }
            return Redirect("~/cnfProyecto/cnfClsProyectoLineaBase/cnfFrmProyectoLineaBaseVista");
        }

        public string mtdModificar(cnfPLBpProyectoLineaBase LobjLineaBaseModelo)
        {
            string LstrMensajeRespuesta = "";
            LstrMensajeRespuesta = PobjLineaBase.mtdModificar(LobjLineaBaseModelo);
            return LstrMensajeRespuesta;
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