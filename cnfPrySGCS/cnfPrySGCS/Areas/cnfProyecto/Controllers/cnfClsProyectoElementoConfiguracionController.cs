using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cnfPrySGCS.Models;

namespace cnfPrySGCS.Areas.cnfProyecto.Controllers
{
    public class cnfClsProyectoElementoConfiguracionController : Controller
    {
        cnfPECpProyectoElementoConfiguracion PobjProyectoElementoConfiguracion = new cnfPECpProyectoElementoConfiguracion();
        // GET: cnfProyecto/cnfClsProyectoElementoConfiguracion
        public ActionResult cnfFrmProyectoElementoConfiguracionVista(int id = 0)
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
            ViewBag.GobjListarElementoConfiguracion = mtdCargarDatosPrincipal(codigoUsuario);
            ViewBag.GobjListarProyecto = mtdCargarComboProyecto(codigoUsuario);
            Session["GblnMensaje"] = false;
            Session["GstrMensajeRespuesta"] = "";
            Session["GintPECcodigo"] = id;
            return View(id == 0 ? new cnfPECpProyectoElementoConfiguracion.cnfPECpProyectoElementoConfiguracions()
                : mtdBuscar(id));
        }

        public object mtdCargarComboProyecto(int LintCodigo)
        {
            cnfPECpProyectoElementoConfiguracion LobjElementoConfiguracion = new cnfPECpProyectoElementoConfiguracion();
            return LobjElementoConfiguracion.mtdCargarComboProyecto(LintCodigo);
        }

        [HttpPost]
        public ActionResult mtdCargarComboFase(int PRYcodigo)
        {
            var codigoUsuario = (int)Session["GintCodigoUsuario"];
            cnfPECpProyectoElementoConfiguracion LobjElementoConfiguracion = new cnfPECpProyectoElementoConfiguracion();
            ViewBag.GobjListarFase = LobjElementoConfiguracion.mtdCargarComboFase(PRYcodigo);
            ViewBag.GobjListarProyecto = mtdCargarComboProyecto(codigoUsuario);
            ViewBag.GobjListarElementoConfiguracion = mtdCargarDatosPrincipal(codigoUsuario);
            ViewBag.GintProyectoSeleccionado = PRYcodigo;
            Session["GintPRYcodigo"] = PRYcodigo;
            return View("cnfFrmProyectoElementoConfiguracionVista", Convert.ToInt32(Session["GintPECcodigo"].ToString()) == 0 ? new cnfPECpProyectoElementoConfiguracion.cnfPECpProyectoElementoConfiguracions()
                : mtdBuscar(Convert.ToInt32(Session["GintPECcodigo"].ToString())));
        }

        [HttpPost]
        public ActionResult mtdCargarComboLineaBaseEntregable(int MEFcodigo)
        {
            var codigoUsuario = (int)Session["GintCodigoUsuario"];
            var codigoProyecto = Convert.ToInt32(Session["GintPRYcodigo"].ToString());
            cnfPECpProyectoElementoConfiguracion LobjElementoConfiguracion = new cnfPECpProyectoElementoConfiguracion();
            ViewBag.GobjListarLineaBase = LobjElementoConfiguracion.mtdCargarComboLineaBase(MEFcodigo);
            // AGREGAR codigoProyecto a la consulta
            ViewBag.GobjListarEntregable = LobjElementoConfiguracion.mtdCargarComboEntregable(MEFcodigo);

            ViewBag.GobjListarFase = LobjElementoConfiguracion.mtdCargarComboFase(Convert.ToInt32(Session["GintPRYcodigo"].ToString()));
            ViewBag.GobjListarProyecto = mtdCargarComboProyecto(codigoUsuario);
            ViewBag.GobjListarElementoConfiguracion = mtdCargarDatosPrincipal(codigoUsuario);
            ViewBag.GintProyectoSeleccionado = Convert.ToInt32(Session["GintPRYcodigo"].ToString());
            ViewBag.GintFaseSeleccionada = MEFcodigo;
            Session["GintMEFcodigo"] = MEFcodigo;
            return View("cnfFrmProyectoElementoConfiguracionVista", Convert.ToInt32(Session["GintPECcodigo"].ToString()) == 0 ? new cnfPECpProyectoElementoConfiguracion.cnfPECpProyectoElementoConfiguracions()
                : mtdBuscar(Convert.ToInt32(Session["GintPECcodigo"].ToString())));
        }

        public object mtdBuscar(int LintCodigo)
        {
            cnfPECpProyectoElementoConfiguracion LobjElementoConfiguracion = new cnfPECpProyectoElementoConfiguracion();
            cnfPECpProyectoElementoConfiguracion.cnfPECpProyectoElementoConfiguracions LobjElementoConfiguracions = LobjElementoConfiguracion.mtdBuscar(LintCodigo);
            Session["GintPRYcodigo"] = LobjElementoConfiguracions.PRYcodigo;
            Session["GintMEFcodigo"] = LobjElementoConfiguracions.MEFcodigo;
            return LobjElementoConfiguracion.mtdBuscar(LintCodigo);
        }

        public object mtdCargarDatosPrincipal(int LintCodigo)
        {
            return PobjProyectoElementoConfiguracion.mtdCargarDatosPrincipal(LintCodigo);
        }

        public ActionResult mtdGuardarPrincipal(cnfPECpProyectoElementoConfiguracion.cnfPECpProyectoElementoConfiguracions LobjElementoConfiguracionModelo, HttpPostedFileBase file)
        {
            var lstrMensajeRespuesta = "";

            var lobjElementoConfiguracion = new cnfPECpProyectoElementoConfiguracion();
            lobjElementoConfiguracion.PECcodigo = LobjElementoConfiguracionModelo.PECcodigo;
            lobjElementoConfiguracion.MEFcodigo = Convert.ToInt32(Session["GintMEFcodigo"].ToString());
            lobjElementoConfiguracion.PRYcodigo = Convert.ToInt32(Session["GintPRYcodigo"].ToString());
            lobjElementoConfiguracion.MNTcodigo = LobjElementoConfiguracionModelo.MNTcodigo;
            lobjElementoConfiguracion.PLBcodigo = LobjElementoConfiguracionModelo.PLBcodigo;
            lobjElementoConfiguracion.PEClocalizacion = LobjElementoConfiguracionModelo.PEClocalizacion;
            lobjElementoConfiguracion.PECnombre = LobjElementoConfiguracionModelo.PECnombre;
            lobjElementoConfiguracion.PECdescripcion = LobjElementoConfiguracionModelo.PECdescripcion;
            lobjElementoConfiguracion.PECtipo = LobjElementoConfiguracionModelo.PECtipo;
            lobjElementoConfiguracion.PECestado = LobjElementoConfiguracionModelo.PECestado;
            lobjElementoConfiguracion.PECestado_InOut = LobjElementoConfiguracionModelo.PECestado_InOut;
            lobjElementoConfiguracion.PECextension = Path.GetExtension(file.FileName);
            lobjElementoConfiguracion.PECarchivo = LobjElementoConfiguracionModelo.PECcodigo + Path.GetExtension(file.FileName);

            if (lobjElementoConfiguracion.PECcodigo == 0)
            {
                   lstrMensajeRespuesta = lobjElementoConfiguracion.mtdGuardarPrincipal(lobjElementoConfiguracion);
                mtdRespuestaMensaje(lstrMensajeRespuesta);
            }
            else
            {
                lstrMensajeRespuesta = mtdModificar(lobjElementoConfiguracion);
                mtdRespuestaMensaje(lstrMensajeRespuesta);

            }

            if (file != null)
            {
                Directory.CreateDirectory(Server.MapPath($"~/Uploads/{lobjElementoConfiguracion.PEClocalizacion}"));
                file.SaveAs(Server.MapPath($"~/Uploads/{lobjElementoConfiguracion.PEClocalizacion}/{lobjElementoConfiguracion.PECarchivo}"));
                //file.SaveAs();
            }

            return Redirect("~/cnfProyecto/cnfClsProyectoElementoConfiguracion/cnfFrmProyectoElementoConfiguracionVista");
        }

        public string mtdModificar(cnfPECpProyectoElementoConfiguracion PobjElementoConfiguracionModelo)
        {
            string LstrMensajeRespuesta = "";
            LstrMensajeRespuesta = PobjProyectoElementoConfiguracion.mtdModificar(PobjElementoConfiguracionModelo);
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

        public ActionResult cnfFrmProyectoElementoConfiguracionRelacionVista(int id = 0)
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
            ViewBag.GintCodigoElementoConfiguracion = id;
            ViewBag.GobjListarElementoConfiguracion = mtdCargarDatosSecundario(id);
            ViewBag.GobjListarElementoConfiguracionRelacion = mtdCargarDatosSecundarioRelacion(id);
            Session["GblnMensaje"] = false;
            Session["GstrMensajeRespuesta"] = "";
            Session["GintPECcodigo"] = id;
            return View();
        }

        public object mtdCargarDatosSecundario(int LintCodigo)
        {
            return PobjProyectoElementoConfiguracion.mtdCargarDatosSecundario(LintCodigo);
        }

        public object mtdCargarDatosSecundarioRelacion(int LintCodigo)
        {
            return PobjProyectoElementoConfiguracion.mtdCargarDatosSecundarioRelacion(LintCodigo);
        }

        public ActionResult mtdGuardarSecundario(string[] PECcodigo_Relacion = null, int PECcodigo = 0)
        {
            string LstrMensajeRespuesta = "";

            LstrMensajeRespuesta = PobjProyectoElementoConfiguracion.mtdGuardarSecundario(PECcodigo_Relacion, PECcodigo);
            mtdRespuestaMensaje(LstrMensajeRespuesta);

            return Redirect("~/cnfProyecto/cnfClsProyectoELementoConfiguracion/cnfFrmProyectoElementoConfiguracionVista");
        }
    }
}