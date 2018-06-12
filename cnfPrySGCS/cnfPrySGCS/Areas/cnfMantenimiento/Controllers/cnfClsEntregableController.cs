using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cnfPrySGCS.Models;

namespace cnfPrySGCS.Areas.cnfMantenimiento.Controllers
{
    public class cnfClsEntregableController : Controller
    {
        cnfMNTpMetodologiaEntregable PobjEntregable = new cnfMNTpMetodologiaEntregable();
        // GET: cnfMantenimiento/cnfClsEntregable
        public ActionResult cnfFrmEntregableVista(int id = 0)
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

            ViewBag.GobjListarEntregable = mtdCargarDatosPrincipal();
            ViewBag.GobjListarMetodologia = mtdCargarComboMetodologia();
            Session["GblnMensaje"] = false;
            Session["GstrMensajeRespuesta"] = "";
            Session["GintMNTcodigo"] = id;
            return View(id == 0 ? new cnfMNTpMetodologiaEntregable.cnfMNTpMetodologiaEntregables()
                : mtdBuscar(id));
        }

        public object mtdCargarComboMetodologia()
        {
            cnfMNTpMetodologiaEntregable LobjEntregable = new cnfMNTpMetodologiaEntregable();
            return LobjEntregable.mtdCargarComboMetodologia();
        }

        [HttpPost]
        public ActionResult mtdCargarComboFase(int MTDcodigo)
        {
            cnfMNTpMetodologiaEntregable LobjEntregable = new cnfMNTpMetodologiaEntregable();
            ViewBag.GobjListarFase = LobjEntregable.mtdCargarComboFase(MTDcodigo);
            ViewBag.GobjListarMetodologia = mtdCargarComboMetodologia();
            ViewBag.GobjListarEntregable = mtdCargarDatosPrincipal();
            ViewBag.GintMetodologiaSeleccionada = MTDcodigo;
            return View("cnfFrmEntregableVista", Convert.ToInt32(Session["GintMNTcodigo"].ToString()) == 0 ? new cnfMNTpMetodologiaEntregable.cnfMNTpMetodologiaEntregables()
                : mtdBuscar(Convert.ToInt32(Session["GintMNTcodigo"].ToString())));
        }

        public object mtdBuscar(int LintCodigo)
        {
            cnfMNTpMetodologiaEntregable LobjEntregable = new cnfMNTpMetodologiaEntregable();
            cnfMNTpMetodologiaEntregable.cnfMNTpMetodologiaEntregables LobjEntregables = LobjEntregable.mtdBuscar(LintCodigo);
            ViewBag.GobjListarFase = LobjEntregable.mtdCargarComboFase(LobjEntregables.MTDcodigo);
            return LobjEntregable.mtdBuscar(LintCodigo);
        }

        public object mtdCargarDatosPrincipal()
        {
            return PobjEntregable.mtdCargarDatosPrincipal();
        }

        public ActionResult mtdGuardarPrincipal(cnfMNTpMetodologiaEntregable.cnfMNTpMetodologiaEntregables LobjEntregableModelo)
        {
            string LstrMensajeRespuesta = "";

            cnfMNTpMetodologiaEntregable LobjEntregable = new cnfMNTpMetodologiaEntregable();
            LobjEntregable.MNTcodigo = LobjEntregableModelo.MNTcodigo;
            LobjEntregable.MEFcodigo = LobjEntregableModelo.MEFcodigo;
            LobjEntregable.MNTnombre = LobjEntregableModelo.MNTnombre;
            LobjEntregable.MNTdescripcion = LobjEntregableModelo.MNTdescripcion;
            LobjEntregable.MNTfecha_Registro = Convert.ToDateTime(LobjEntregableModelo.MNTfecha_Registro);
            LobjEntregable.MNTnomenclatura = LobjEntregableModelo.MNTnomenclatura;
            LobjEntregable.MNTestado = LobjEntregableModelo.MNTestado;

            if (LobjEntregable.MNTcodigo == 0)
            {
                LstrMensajeRespuesta = PobjEntregable.mtdGuardarPrincipal(LobjEntregable);
                mtdRespuestaMensaje(LstrMensajeRespuesta);
            }
            else
            {
                LstrMensajeRespuesta = mtdModificar(LobjEntregable);
                mtdRespuestaMensaje(LstrMensajeRespuesta);

            }
            return Redirect("~/cnfMantenimiento/cnfClsEntregable/cnfFrmEntregableVista");
        }

        public string mtdModificar(cnfMNTpMetodologiaEntregable PobjEntregableModelo)
        {
            string LstrMensajeRespuesta = "";
            LstrMensajeRespuesta = PobjEntregable.mtdModificar(PobjEntregableModelo);
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

        public ActionResult cnfFrmEntregableRelacionVista(int id = 0)
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
            ViewBag.GintCodigoEntregable = id;
            ViewBag.GobjListarEntregable = mtdCargarDatosSecundario(id);
            ViewBag.GobjListarEntregableRelacion = mtdCargarDatosSecundarioRelacion(id);
            Session["GblnMensaje"] = false;
            Session["GstrMensajeRespuesta"] = "";
            Session["GintMNTcodigo"] = id;
            return View();
        }

        public object mtdCargarDatosSecundario(int LintCodigo)
        {
            return PobjEntregable.mtdCargarDatosSecundario(LintCodigo);
        }

        public object mtdCargarDatosSecundarioRelacion(int LintCodigo)
        {
            return PobjEntregable.mtdCargarDatosSecundarioRelacion(LintCodigo);
        }

        public ActionResult mtdGuardarSecundario(string[] MNTcodigo_Relacion = null, int MNTcodigo = 0)
        {
            string LstrMensajeRespuesta = "";

            LstrMensajeRespuesta = PobjEntregable.mtdGuardarSecundario(MNTcodigo_Relacion, MNTcodigo);
            mtdRespuestaMensaje(LstrMensajeRespuesta);

            return Redirect("~/cnfMantenimiento/cnfClsEntregable/cnfFrmEntregableVista");
        }
    }
}