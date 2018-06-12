using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cnfPrySGCS.Models;

namespace cnfPrySGCS.Areas.cnfMantenimiento.Controllers
{
    public class cnfClsUsuarioController : Controller
    {
        private cnfUSUpUsuario PobjUsuario = new cnfUSUpUsuario();

        // GET: cnfMantenimiento/cnfClsUsuario
        public ActionResult cnfFrmUsuarioVista(int id=0)
        {try
            {
                if (ViewBag.GblnMensaje == null)
                {
                    ViewBag.GblnMensaje = Convert.ToBoolean(Session["GblnMensaje"].ToString());
                    ViewBag.GstrMensajeRespuesta = Convert.ToString(Session["GstrMensajeRespuesta"].ToString());
                }
            }
            catch {
            }

            ViewBag.GobjListarUsuario = mtdCargarDatos();
            Session["GstrMensajeRespuesta"] = "";
            return View(id==0 ? new cnfUSUpUsuario() : mtdBuscar(id));
        }



        public object mtdBuscar(int LintCodigo)
        {
            cnfUSUpUsuario LobjUsuario = new cnfUSUpUsuario();
            return PobjUsuario.mtdBuscar(LintCodigo);
        }

        public object mtdCargarDatos()
        {
            return PobjUsuario.mtdCargarDatos();
        }

        public ActionResult mtdGuardar(cnfUSUpUsuario PobjUsuarioModelo)
        {
            string LstrMensajeRespuesta = "";

            if (ModelState.IsValid)
            {
                if (PobjUsuarioModelo.USUcodigo == 0)
                {
                    LstrMensajeRespuesta = PobjUsuarioModelo.mtdGuardar(PobjUsuarioModelo);
                    mtdRespuestaMensaje(LstrMensajeRespuesta);
                }
                else
                {
                    LstrMensajeRespuesta = mtdModificar(PobjUsuarioModelo);
                    mtdRespuestaMensaje(LstrMensajeRespuesta);
                }
            }
            return Redirect("~/cnfMantenimiento/cnfClsUsuario/cnfFrmUsuarioVista");
        }

        public string mtdModificar(cnfUSUpUsuario PobjUsuarioModelo)
        {
            string LstrMensajeRespuesta = "";
            LstrMensajeRespuesta = PobjUsuarioModelo.mtdModificar(PobjUsuarioModelo);
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