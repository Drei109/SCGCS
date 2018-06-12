using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cnfPrySGCS.Models;

namespace cnfPrySGCS.Areas.cnfProyecto.Controllers
{
    public class cnfClsVisualizarProyectoController : Controller
    {
        cnfPRYpProyecto GobjVisualizarProyecto = new cnfPRYpProyecto();
        cnfPYEpProyectoEntregable GobjRelleno = new cnfPYEpProyectoEntregable();
        // GET: cnfProyecto/cnfClsVisualizarProyecto
        public ActionResult cnfFrmVisualizarProyectoVista(int id = 0)
        {
            ViewBag.GobjListarProyecto = mtdListarProyecto(6);
            ViewBag.GblnCargarTabla = false;

            try
            {
                Session["GblnCargarTabla"] = false;

                if (id == 0)
                {
                    Session["GblnCargarTabla"] = false;
                }
                else
                {
                    Session["GintCodigoProyecto"] = id;
                }
            }
            catch
            {

            }

            try
            {
                if (Session["GintCodigoProyecto"] != null)
                {
                    ViewBag.GobjListarDatos = mtdCargarDatos(id);
                    ViewBag.GobjListarDatosRelacion = mtdCargarDatosRelacion(id);
                    ViewBag.GobjListarFase = mtdListarFase(id);
                    ViewBag.GobjProyecto = mtdProyecto(id);
                    ViewBag.GobjListarMiembros = mtdListarMiembros(id);
                    ViewBag.GblnCargarTabla = true;
                }
            }
            catch (Exception e)
            {

            }
            return View();
        }

        public List<cnfPRYpProyecto.cnfPRYpProyectos> mtdListarProyecto(int LintCodigoUsuario)
        {
            return GobjVisualizarProyecto.mtdListarProyecto(LintCodigoUsuario);
        }

        public object mtdCargarComboProyecto(int LintCodigoUsuario)
        {
            return GobjRelleno.mtdCargarComboProyecto(LintCodigoUsuario);
        }

        public object mtdCargarDatos(int LintCodigoProyecto)
        {
            return GobjRelleno.mtdCargarDatos(LintCodigoProyecto);
        }

        public object mtdCargarDatosRelacion(int LintCodigoProyecto)
        {
            return GobjRelleno.mtdCargarDatosRelacion(LintCodigoProyecto);
        }

        public object mtdListarFase(int LintCodigoProyecto)
        {
            return GobjRelleno.mtdListarFase(LintCodigoProyecto);
        }

        public object mtdProyecto(int LintCodigoProyecto)
        {
            return GobjVisualizarProyecto.mtdProyecto(LintCodigoProyecto);
        }

        public object mtdListarMiembros(int LintCodigoProyecto)
        {
            return GobjVisualizarProyecto.mtdListarMiembros(LintCodigoProyecto);
        }
    }
}