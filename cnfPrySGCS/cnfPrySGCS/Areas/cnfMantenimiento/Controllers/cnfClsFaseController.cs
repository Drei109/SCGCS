using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cnfPrySGCS.Models;

namespace cnfPrySGCS.Areas.cnfMantenimiento.Controllers
{
    public class cnfClsFaseController : Controller
    {
        cnfMEFpMetodologiaFase PobjFase = new cnfMEFpMetodologiaFase();
        // GET: cnfMantenimiento/cnfClsFase
        public ActionResult cnfFrmFaseVista(int id = 0)
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

            ViewBag.GobjListarFase = mtdCargarDatos();
            ViewBag.GobjListarMetodologia = mtdCargarComboMetodologia();
            Session["GblnMensaje"] = false;
            Session["GstrMensajeRespuesta"] = "";
            return View(id == 0 ? new cnfMEFpMetodologiaFase()
                : mtdBuscar(id));
        }

        public object mtdCargarComboMetodologia()
        {
            cnfMEFpMetodologiaFase LobjFase = new cnfMEFpMetodologiaFase();
            return LobjFase.mtdCargarComboMetodologia();
        }

        public object mtdBuscar(int LintCodigo)
        {
            cnfMEFpMetodologiaFase LobjFase = new cnfMEFpMetodologiaFase();
            return LobjFase.mtdBuscar(LintCodigo);
        }

        public object mtdCargarDatos()
        {
            return PobjFase.mtdCargarDatos();
        }

        public ActionResult mtdGuardar(cnfMEFpMetodologiaFase PobjFaseModelo)
        {
            string LstrMensajeRespuesta = "";

            if (ModelState.IsValid)
            {
                if (PobjFaseModelo.MEFcodigo == 0)
                {
                    LstrMensajeRespuesta = PobjFase.mtdGuardar(PobjFaseModelo);
                    mtdRespuestaMensaje(LstrMensajeRespuesta);
                }
                else
                {
                    LstrMensajeRespuesta = mtdModificar(PobjFaseModelo);
                    mtdRespuestaMensaje(LstrMensajeRespuesta);
                }
            }
            return Redirect("~/cnfMantenimiento/cnfClsFase/cnfFrmFaseVista");
        }

        public string mtdModificar(cnfMEFpMetodologiaFase PobjFaseModelo)
        {
            string LstrMensajeRespuesta = "";
            LstrMensajeRespuesta = PobjFase.mtdModificar(PobjFaseModelo);
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