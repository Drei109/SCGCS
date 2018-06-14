using System.IO;
using System.Web;

namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    

    [Table("cnfPRYpProyecto")]
    public partial class cnfPRYpProyecto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnfPRYpProyecto()
        {
            cnfEMEpEntregableMiembroEntregable = new HashSet<cnfEMEpEntregableMiembroEntregable>();
            cnfPECpProyectoElementoConfiguracion = new HashSet<cnfPECpProyectoElementoConfiguracion>();
            cnfPLBpProyectoLineaBase = new HashSet<cnfPLBpProyectoLineaBase>();
            cnfPMIpProyectoMiembro = new HashSet<cnfPMIpProyectoMiembro>();
            cnfPYEpProyectoEntregable = new HashSet<cnfPYEpProyectoEntregable>();
            cnfSOLpSolicitud = new HashSet<cnfSOLpSolicitud>();
        }

        [Key]
        public int PRYcodigo { get; set; }

        public int? MTDcodigo { get; set; }

        public int? USUcodigo { get; set; }

        [StringLength(250)]
        public string PRYnombre { get; set; }

        [StringLength(250)]
        public string PRYdescripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PRYfecha_Registro { get; set; }

        [StringLength(250)]
        public string PRYestado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfEMEpEntregableMiembroEntregable> cnfEMEpEntregableMiembroEntregable { get; set; }

        public virtual cnfMTDpMetodologia cnfMTDpMetodologia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPECpProyectoElementoConfiguracion> cnfPECpProyectoElementoConfiguracion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPLBpProyectoLineaBase> cnfPLBpProyectoLineaBase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPMIpProyectoMiembro> cnfPMIpProyectoMiembro { get; set; }

        public virtual cnfUSUpUsuario cnfUSUpUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPYEpProyectoEntregable> cnfPYEpProyectoEntregable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSOLpSolicitud> cnfSOLpSolicitud { get; set; }

        public List<cnfPRYpProyectos> mtdCargarDatos(int LintCodigoUsuario)
        {
            List<cnfPRYpProyectos> LlstLista = new List<cnfPRYpProyectos>();
            
            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPRYpProyectos>("exec usp_S_cnfPRYpProyecto_CargarDatos " + LintCodigoUsuario).ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfMTDpMetodologia> mtdCargarComboMetodologia()
        {
            List<cnfMTDpMetodologia> LlstLista = new List<cnfMTDpMetodologia>();
            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMTDpMetodologia>("exec usp_S_cnfPRYpProyecto_ComboMetodologia").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public cnfPRYpProyectos mtdBuscar(int LintParametro)
        {
            cnfPRYpProyectos LobjProyecto = new cnfPRYpProyectos();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPRYpProyectos>("exec usp_S_cnfPRYpProyecto_Buscar " + LintParametro).Single();
                LobjProyecto = LobjQuery;
            }

            return LobjProyecto;
        }

        public string mtdGuardar(cnfPRYpProyecto LobjProyecto)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    string LstrFechaActual = Convert.ToDateTime(LobjProyecto.PRYfecha_Registro).ToString("d");

                    if (LobjProyecto.PRYcodigo == 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_I_cnfPRYpProyecto_Guardar " + "'" + LobjProyecto.MTDcodigo + "', '" + LobjProyecto.USUcodigo + "', '" + LobjProyecto.PRYnombre + "', '" + LobjProyecto.PRYdescripcion + "', '" + LstrFechaActual + "', '" + LobjProyecto.PRYestado + "';");
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath($"~/Uploads/{LobjProyecto.PRYnombre}"));
                    }
                }
            }
            catch (Exception e)
            {

            }

            return mtdRespuestaMensaje(LintMensajeRespuesta);
        }

        public string mtdModificar(cnfPRYpProyecto LobjProyecto)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    string LstrFechaActual = Convert.ToDateTime(LobjProyecto.PRYfecha_Registro).ToString("d");


                    if (LobjProyecto.PRYcodigo != 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_U_cnfPRYpProyecto_Modificar '" + LobjProyecto.PRYcodigo + "', '" + LobjProyecto.MTDcodigo + "', '" + LobjProyecto.USUcodigo + "', '" + LobjProyecto.PRYnombre + "', '" + LobjProyecto.PRYdescripcion + "', '" + LstrFechaActual + "', '" + LobjProyecto.PRYestado + "';");
                    }
                }
            }
            catch (Exception)
            {

            }
            return mtdRespuestaMensaje(LintMensajeRespuesta);
        }

        public string mtdRespuestaMensaje(int LintMensajeRespuesta)
        {
            string LstrMensajeRespuesta = "";
            if (LintMensajeRespuesta > 0)
            {
                LstrMensajeRespuesta = "Correcto";
            }
            else
            {
                LstrMensajeRespuesta = "Incorrecto";
            }
            return LstrMensajeRespuesta;
        }

        public List<cnfPRYpProyectos> mtdListarProyecto(int LintCodigoUsuario)
        {
            List<cnfPRYpProyectos> LlstLista = new List<cnfPRYpProyectos>();
            cnfUSUpUsuario LobjUsuario = new cnfUSUpUsuario();

            using (var LobjContexto = new cnfModelo())
            {
                LobjUsuario = LobjContexto.Database.SqlQuery<cnfUSUpUsuario>("exec usp_S_cnfPRYpProyectoEntregable_ObtenerNivelUsuario " + LintCodigoUsuario).Single();

                if(LobjUsuario.USUnivel.Contains("Jefe") || LobjUsuario.USUnivel.Contains("Miembro"))
                {
                    var LobjQuery = LobjContexto.Database.SqlQuery<cnfPRYpProyectos>("exec usp_S_cnfPRYpProyectoEntregable_ListarProyecto " + LintCodigoUsuario).ToList();
                    LlstLista = LobjQuery;
                }
                if(LobjUsuario.USUnivel.Contains("Administrador"))
                {
                    var LobjQuery = LobjContexto.Database.SqlQuery<cnfPRYpProyectos>("exec usp_S_cnfPRYpProyectoEntregable_ListarTodoProyecto").ToList();
                    LlstLista = LobjQuery;
                }
            }

            return LlstLista;
        }

        public cnfPRYpProyectos mtdProyecto(int LintCodigProyecto)
        {
            cnfPRYpProyectos LlstLista = new cnfPRYpProyectos();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPRYpProyectos>("exec usp_S_cnfPRYpProyectoEntregable_ObtenerProyecto " + LintCodigProyecto).Single();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfUSUpUsuario> mtdListarMiembros(int LintCodigProyecto)
        {
            List<cnfUSUpUsuario> LlstLista = new List<cnfUSUpUsuario>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfUSUpUsuario>("exec usp_S_cnfPRYpProyectoEntregable_ListarMiembrosProyecto " + LintCodigProyecto).ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }










        public class cnfPRYpProyectos
        {
            public int PRYcodigo { get; set; }

            public int MTDcodigo { get; set; }

            public string MTDnombre { get; set; }

            public int USUcodigo { get; set; }

            public string USUnombre { get; set; }

            public string USUapellido { get; set; }

            [StringLength(250)]
            public string PRYnombre { get; set; }

            [StringLength(250)]
            public string PRYdescripcion { get; set; }

            [Column(TypeName = "date")]
            public DateTime PRYfecha_Registro { get; set; }

            [StringLength(250)]
            public string PRYestado { get; set; }
        }

        public List<cnfPRYpProyecto> mtdCargarComboProyecto()
        {
            List<cnfPRYpProyecto> LlstLista = new List<cnfPRYpProyecto>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPRYpProyecto>("exec usp_S_cnfEMEpEntregableMiembroEntregable_CargarComboProyecto").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }
    }
}
