using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cnfPrySGCS.Models;
using Octokit;
using System.Threading.Tasks;

namespace cnfPrySGCS.Areas.cnfProyecto.Controllers
{
    public class cnfClsProyectoController : Controller
    {
        // GET: cnfProyecto/cnfClsProyecto
        cnfPRYpProyecto PobjProyecto = new cnfPRYpProyecto();

        public ActionResult cnfFrmProyectoVista(int id = 0)
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

            ViewBag.GobjListarProyecto = mtdCargarDatos(codigoUsuario);
            ViewBag.GobjListarMetodologia = mtdCargarComboMetodologia();
            Session["GblnMensaje"] = false;
            Session["GstrMensajeRespuesta"] = "";
            Session["GintMNTcodigo"] = id;
            return View(id == 0 ? new cnfPRYpProyecto.cnfPRYpProyectos()
                : mtdBuscar(id));
        }

        public object mtdCargarComboMetodologia()
        {
            return PobjProyecto.mtdCargarComboMetodologia();
        }

        public object mtdCargarDatos(int usuarioId)
        {
            return PobjProyecto.mtdCargarDatos(usuarioId);
        }

        public object mtdBuscar(int LintCodigo)
        {
            return PobjProyecto.mtdBuscar(LintCodigo);
        }

        public async Task<ActionResult> mtdGuardar(cnfPRYpProyecto PobjProyectoModelo)
        {
            string LstrMensajeRespuesta = "";

            bool LblnModificar = false;
            bool LblnGuardar = false;

            if (ModelState.IsValid)
            {
                if (PobjProyectoModelo.PRYcodigo == 0)
                {
                    LstrMensajeRespuesta = PobjProyecto.mtdGuardar(PobjProyectoModelo);
                    mtdRespuestaMensaje(LstrMensajeRespuesta);
                    LblnModificar = false;
                    LblnGuardar = true;
                }
                else
                {
                    LstrMensajeRespuesta = mtdModificar(PobjProyectoModelo);
                    mtdRespuestaMensaje(LstrMensajeRespuesta);
                    LblnModificar = true;
                    LblnGuardar = false;
                }
            }
            if(LstrMensajeRespuesta == "Correcto")
            {
                if(LblnGuardar)
                {
                    await mtdGit(PobjProyectoModelo.PRYnombre, Convert.ToInt32(PobjProyectoModelo.USUcodigo),"Guardar");
                }
                if(LblnModificar)
                {
                    await mtdGit(PobjProyectoModelo.PRYnombre, Convert.ToInt32(PobjProyectoModelo.USUcodigo),"Modificar");
                }
            }
            return Redirect("~/cnfProyecto/cnfClsProyecto/cnfFrmProyectoVista");
        }

        async public Task<cnfPRYpProyecto.cnfPRYpProyectos> mtdGit(string PRYnombre, int USUcodigo, string LstrMotivo)
        {
            if(LstrMotivo.Equals("Guardar"))
            {
                GitHubClient LobjCliente = new GitHubClient(
                            new Octokit.ProductHeaderValue("SGCS"));

                LobjCliente.Credentials = new Credentials("UserSGCS", "sgcs1234567890");

                PRYnombre = PRYnombre.Replace(" ", "-");

                var LobjRepositorio = new NewRepository(PRYnombre)
                {
                    AutoInit = true
                };

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var LobjRepositorioNuevo = await LobjCliente.Repository.Create(LobjRepositorio);
                cnfUSUpUsuario LobjUsuario = new cnfUSUpUsuario();
                using (var LobjContexto = new cnfModelo())
                {
                    PRYnombre = PRYnombre.Replace("-", " ");
                    LobjUsuario = LobjContexto.Database.SqlQuery<cnfUSUpUsuario>("exec usp_S_cnfPRYpProyecto_ObtenerUsuario '" + Convert.ToInt32(USUcodigo) + "', '" + PRYnombre + "';").Single();
                }

                List<cnfMEFpMetodologiaFase> LobjFase = new List<cnfMEFpMetodologiaFase>();

                using (var LobjContexto = new cnfModelo())
                {
                    PRYnombre = PRYnombre.Replace("-", " ");
                    LobjFase = LobjContexto.Database.SqlQuery<cnfMEFpMetodologiaFase>("exec usp_S_cnfPRYpProyecto_ObtenerFase '" + Convert.ToInt32(USUcodigo) + "', '" + PRYnombre + "';").ToList();
                }

                var LstrBranch = "master";

                foreach (var LobjRegistro in LobjFase)
                {
                    PRYnombre = PRYnombre.Replace(" ", "-");
                    await LobjCliente.Repository.Content.CreateFile("UserSGCS",PRYnombre,LobjRegistro.MEFnombre + "/Léeme.txt",new CreateFileRequest("Léeme", "Creado por Jefe de Proyecto: " + LobjUsuario.USUnombre + " " + LobjUsuario.USUapellido + " " + DateTime.Now, LstrBranch));
                }
                cnfPRYpProyecto.cnfPRYpProyectos LobjProyecto = new cnfPRYpProyecto.cnfPRYpProyectos();
                return LobjProyecto;
            }
            else
            {
                GitHubClient LobjCliente = new GitHubClient(
                            new Octokit.ProductHeaderValue("SGCS"));

                LobjCliente.Credentials = new Credentials("UserSGCS", "sgcs1234567890");

                PRYnombre = PRYnombre.Replace(" ", "-");
                string LstrAntiguoNombreProyecto = Session["GstrNombreProyectoModificado"].ToString();
                LstrAntiguoNombreProyecto = LstrAntiguoNombreProyecto.Replace(" ", "-");

                var LobjRepositorio = new NewRepository(PRYnombre)
                             
                {
                    AutoInit = true
                };

                var LobjRepositorioNuevo = await LobjCliente.Repository.Edit("UserSGCS", LstrAntiguoNombreProyecto, new RepositoryUpdate(PRYnombre));

                cnfPRYpProyecto.cnfPRYpProyectos LobjProyecto = new cnfPRYpProyecto.cnfPRYpProyectos();
                return LobjProyecto;
            }
        }

        public string mtdModificar(cnfPRYpProyecto PobjProyectoModelo)
        {
            string LstrMensajeRespuesta = "";
            LstrMensajeRespuesta = PobjProyecto.mtdModificar(PobjProyectoModelo);
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