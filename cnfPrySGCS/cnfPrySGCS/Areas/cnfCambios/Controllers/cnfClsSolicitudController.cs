using System;
using System.Linq;
using System.Web.Mvc;
using cnfPrySGCS.Models;

namespace cnfPrySGCS.Areas.cnfCambios.Controllers
{
    public class cnfClsSolicitudController : Controller
    {
        private readonly cnfModelo _db = new cnfModelo();

        // GET: cnfCambios/cnfClsSolicitud
        public ActionResult Index()
        {
            var codigoUsuario = (int)Session["GintCodigoUsuario"];
            var proyectos = _db.cnfPRYpProyecto.Where(x => x.USUcodigo == codigoUsuario).ToList();
            ViewBag.PRYcodigo = new SelectList(proyectos, "PRYcodigo", "PRYnombre");
            ViewBag.UsuarioNombre = _db.cnfUSUpUsuario.FirstOrDefault(x => x.USUcodigo == codigoUsuario)?.USUnombre + " " + 
                                    _db.cnfUSUpUsuario.FirstOrDefault(x => x.USUcodigo == codigoUsuario)?.USUapellido;
            ViewBag.Solicitudes = _db.cnfSOLpSolicitud.Include("cnfPRYpProyecto").Include("cnfUSUpUsuario").ToList();

            return View("cnfFrmSolicitudVista");
        }

        public ActionResult Guardar(cnfSOLpSolicitud solicitud)
        {
            var codigoUsuario = (int)Session["GintCodigoUsuario"];
            
            solicitud.SOLfecha_Registro = DateTime.Now;
            solicitud.USUcodigo = codigoUsuario;

            ModelState.Remove("SOLcodigo");

            if (ModelState.IsValid)
            {
                _db.cnfSOLpSolicitud.Add(solicitud);
                _db.SaveChanges();
                return View("cnfFrmSolicitudVista");
            }

            var proyectos = _db.cnfPRYpProyecto.Where(x => x.USUcodigo == codigoUsuario).ToList();

            ViewBag.PRYcodigo = new SelectList(proyectos, "PRYcodigo", "PRYnombre");
            ViewBag.UsuarioNombre = _db.cnfUSUpUsuario.FirstOrDefault(x => x.USUcodigo == codigoUsuario)?.USUnombre + " " +
                                    _db.cnfUSUpUsuario.FirstOrDefault(x => x.USUcodigo == codigoUsuario)?.USUapellido;
            ViewBag.Solicitudes = _db.cnfSOLpSolicitud.Include("cnfPRYpProyecto").Include("cnfUSUpUsuario").ToList();

            return View("cnfFrmSolicitudVista", solicitud);
        }

        [HttpGet]
        public JsonResult CargarMetodologiaFase(string term, int pryCod)
        {
            if (term.Equals(" "))
            {
                var userList =
                    _db.cnfMEFpMetodologiaFase
                        .Join(
                            _db.cnfPRYpProyecto,
                            f => f.MTDcodigo,
                            p => p.MTDcodigo,
                            (f, p) => new { id = f.MEFcodigo, nombre = f.MEFnombre, pry = p.PRYcodigo })
                        .Where(j => j.pry == pryCod)
                        .Take(10)
                        .ToList();
                return Json(userList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var userList =
                    _db.cnfMEFpMetodologiaFase
                        .Join(
                            _db.cnfPRYpProyecto, 
                            f => f.MTDcodigo, 
                            p => p.MTDcodigo,
                            (f,p) => new {id = f.MEFcodigo, nombre = f.MEFnombre, pry = p.PRYcodigo})
                        .Where(j => j.nombre.ToLower().StartsWith(term.ToLower()) && j.pry == pryCod)
                        .Take(10)
                        .ToList();

                return Json(userList, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult CargarComboLineaBase(int mefCod)
        {
            var userList =
                _db.cnfPLBpProyectoLineaBase
                    .Where(x => x.PLBestado.Equals("Activo") && x.MEFcodigo == mefCod)
                    .Select(x => new
                    {
                        id = x.PLBcodigo,
                        nombre = x.PLBfecha_LineaBase.ToString()
                    })
                    .Take(10)
                    .ToList();

            return Json(userList, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult CargarComboElementoConfiguracion(string term, int pryCod, int mefCod, int mntCod)
        {
            if (term.Equals(" "))
            {
                var userList = _db.cnfPECpProyectoElementoConfiguracion
                    .Where(x => x.MEFcodigo == mefCod &&
                                x.MNTcodigo == mntCod &&
                                x.PRYcodigo == pryCod)
                    .Select(x => new
                    {
                        id = x.PECcodigo,
                        nombre = x.PECnombre
                    }).Take(10).ToList();
                return Json(userList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var userList = _db.cnfPECpProyectoElementoConfiguracion
                    .Where(x => x.PECnombre.ToLower().StartsWith(term.ToLower()) && 
                                x.MEFcodigo == mefCod &&
                                x.MNTcodigo == mntCod &&
                                x.PRYcodigo == pryCod)
                    .Select(x => new
                    {
                        id = x.PECcodigo,
                        nombre = x.PECnombre
                    }).Take(10).ToList();
                return Json(userList, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult CargarComboEntregable(string term, int mefCod)
        {
            if (term.Equals(" "))
            {
                var userList = _db.cnfMNTpMetodologiaEntregable
                    .Where(x => x.MEFcodigo == mefCod &&
                                x.MNTestado.Equals("Activo"))
                    .Select(x => new
                    {
                        id = x.MNTcodigo,
                        nombre = x.MNTnombre
                    }).Take(10).ToList();
                return Json(userList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var userList = _db.cnfMNTpMetodologiaEntregable
                    .Where(x => x.MNTnombre.ToLower().StartsWith(term.ToLower()) && 
                                x.MEFcodigo == mefCod && 
                                x.MNTestado.Equals("Activo"))
                    .Select(x => new
                    {
                        id = x.MNTcodigo,
                        nombre = x.MNTnombre
                    }).Take(10).ToList();
                return Json(userList, JsonRequestBehavior.AllowGet);
            }
        }
    }
}