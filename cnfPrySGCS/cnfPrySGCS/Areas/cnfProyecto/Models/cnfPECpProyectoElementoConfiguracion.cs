namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("cnfPECpProyectoElementoConfiguracion")]
    public partial class cnfPECpProyectoElementoConfiguracion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnfPECpProyectoElementoConfiguracion()
        {
            cnfEEMpEntregaEntregableMiembro = new HashSet<cnfEEMpEntregaEntregableMiembro>();
            cnfEMEpEntregableMiembroEntregable = new HashSet<cnfEMEpEntregableMiembroEntregable>();
            cnfPERpProyectoElementoRelacion = new HashSet<cnfPERpProyectoElementoRelacion>();
            cnfPERpProyectoElementoRelacion1 = new HashSet<cnfPERpProyectoElementoRelacion>();
            cnfSOLpSolicitud = new HashSet<cnfSOLpSolicitud>();
        }

        [Key]
        public int PECcodigo { get; set; }

        public int? MEFcodigo { get; set; }

        public int? PRYcodigo { get; set; }

        public int? MNTcodigo { get; set; }

        public int? PLBcodigo { get; set; }

        [StringLength(250)]
        public string PEClocalizacion { get; set; }

        [StringLength(250)]
        public string PECnombre { get; set; }

        [StringLength(250)]
        public string PECdescripcion { get; set; }

        [StringLength(250)]
        public string PECtipo { get; set; }

        [StringLength(250)]
        public string PECestado { get; set; }

        [StringLength(250)]
        public string PECestado_InOut { get; set; }

        [StringLength(250)]
        public string PECarchivo { get; set; }

        [StringLength(100)]
        public string PECextension { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfEEMpEntregaEntregableMiembro> cnfEEMpEntregaEntregableMiembro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfEMEpEntregableMiembroEntregable> cnfEMEpEntregableMiembroEntregable { get; set; }

        public virtual cnfMEFpMetodologiaFase cnfMEFpMetodologiaFase { get; set; }

        public virtual cnfMNTpMetodologiaEntregable cnfMNTpMetodologiaEntregable { get; set; }

        public virtual cnfPLBpProyectoLineaBase cnfPLBpProyectoLineaBase { get; set; }

        public virtual cnfPRYpProyecto cnfPRYpProyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPERpProyectoElementoRelacion> cnfPERpProyectoElementoRelacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPERpProyectoElementoRelacion> cnfPERpProyectoElementoRelacion1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSOLpSolicitud> cnfSOLpSolicitud { get; set; }

        public List<cnfPECpProyectoElementoConfiguracions> mtdCargarDatosPrincipal(int LintCodigo)
        {
            List<cnfPECpProyectoElementoConfiguracions> LlstLista = new List<cnfPECpProyectoElementoConfiguracions>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPECpProyectoElementoConfiguracions>("exec usp_S_cnfPECpProyectoElementoConfiguracion_CargarDatosPrincipal '" + LintCodigo + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfPRYpProyecto> mtdCargarComboProyecto(int LintCodigo)
        {
            List<cnfPRYpProyecto> LlstLista = new List<cnfPRYpProyecto>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPRYpProyecto>("exec usp_S_cnfPECpProyectoElementoConfiguracion_ComboProyecto '" + LintCodigo +"';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfMEFpMetodologiaFase> mtdCargarComboFase(int PRYcodigo)
        {
            List<cnfMEFpMetodologiaFase> LlstLista = new List<cnfMEFpMetodologiaFase>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMEFpMetodologiaFase>("exec usp_S_cnfPECpProyectoElementoConfiguracion_ComboFase '" + PRYcodigo + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfPLBpProyectoLineaBase> mtdCargarComboLineaBase(int MEFcodigo)
        {
            List<cnfPLBpProyectoLineaBase> LlstLista = new List<cnfPLBpProyectoLineaBase>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPLBpProyectoLineaBase>("exec usp_S_cnfPECpProyectoElementoConfiguracion_ComboLineaBase '" + MEFcodigo + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfMNTpMetodologiaEntregable> mtdCargarComboEntregable(int MEFcodigo)
        {
            List<cnfMNTpMetodologiaEntregable> LlstLista = new List<cnfMNTpMetodologiaEntregable>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMNTpMetodologiaEntregable>("exec usp_S_cnfPECpProyectoElementoConfiguracion_ComboEntregable '" + MEFcodigo + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public cnfPECpProyectoElementoConfiguracions mtdBuscar(int LintParametro)
        {
            cnfPECpProyectoElementoConfiguracions LobjEntregable = new cnfPECpProyectoElementoConfiguracions();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPECpProyectoElementoConfiguracions>("exec usp_S_cnfPECpProyectoElementoConfiguracion_Buscar " + LintParametro).Single();
                LobjEntregable = LobjQuery;
            }

            return LobjEntregable;
        }

        public string mtdGuardarPrincipal(cnfPECpProyectoElementoConfiguracion LobjElementoConfiguracion)
        {
            var lintMensajeRespuesta = -1;
            try
            {
                using (var lobjContexto = new cnfModelo())
                {
                    if (LobjElementoConfiguracion.PECcodigo == 0)
                    {
                        //LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_I_cnfPECpProyectoElementoConfiguracion_GuardarPrincipal " + "'" + LobjElementoConfiguracion.MEFcodigo + "', '" + LobjElementoConfiguracion.PRYcodigo + "', '" + LobjElementoConfiguracion.MNTcodigo + "', '" + LobjElementoConfiguracion.PLBcodigo + "', '" + LobjElementoConfiguracion.PEClocalizacion + "', '" + LobjElementoConfiguracion.PECnombre + "', '" + LobjElementoConfiguracion.PECdescripcion + "', '" + LobjElementoConfiguracion.PECtipo + "', '" + LobjElementoConfiguracion.PECestado + "', '" + LobjElementoConfiguracion.PECestado_InOut + "', '" + LobjElementoConfiguracion.PECarchivo + "';");
                        lobjContexto.cnfPECpProyectoElementoConfiguracion.Add(LobjElementoConfiguracion);
                        lobjContexto.SaveChanges();
                        LobjElementoConfiguracion.PECarchivo = LobjElementoConfiguracion.PECcodigo + LobjElementoConfiguracion.PECextension;
                        lobjContexto.SaveChanges();
                        lintMensajeRespuesta = 1;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return mtdRespuestaMensaje(-1);
            }

            return mtdRespuestaMensaje(lintMensajeRespuesta);
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

        public string mtdModificar(cnfPECpProyectoElementoConfiguracion LobjElementoConfiguracion)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    if (LobjElementoConfiguracion.PECcodigo != 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_U_cnfPECpProyectoElementoConfiguracion_Modificar " + "'" + LobjElementoConfiguracion.PECcodigo + "', '" + LobjElementoConfiguracion.MEFcodigo + "', '" + LobjElementoConfiguracion.PRYcodigo + "', '" + LobjElementoConfiguracion.MNTcodigo + "', '" + LobjElementoConfiguracion.PLBcodigo + "', '" + LobjElementoConfiguracion.PEClocalizacion + "', '" + LobjElementoConfiguracion.PECnombre + "', '" + LobjElementoConfiguracion.PECdescripcion + "', '" + LobjElementoConfiguracion.PECtipo + "', '" + LobjElementoConfiguracion.PECestado + "', '" + LobjElementoConfiguracion.PECestado_InOut + "';");
                    }
                }
            }
            catch (Exception)
            {

            }
            return mtdRespuestaMensaje(LintMensajeRespuesta);
        }

        public List<cnfPECpProyectoElementoConfiguracions> mtdCargarDatosSecundario(int LintCodigo)
        {
            List<cnfPECpProyectoElementoConfiguracions> LlstLista = new List<cnfPECpProyectoElementoConfiguracions>();

            using (var LobjContexto = new cnfModelo())
            {
                cnfPRYpProyecto LobjObtenerProyecto = new cnfPRYpProyecto();
                var LobjProyecto = LobjContexto.Database.SqlQuery<cnfPRYpProyecto>("exec usp_S_cnfPECpProyectoElementoConfiguracion_ObtenerProyecto '" + LintCodigo + "';").Single();

                LobjObtenerProyecto = LobjProyecto;

                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPECpProyectoElementoConfiguracions>("exec usp_S_cnfPECpProyectoElementoConfiguracion_CargarDatosSecundario '" + LintCodigo + "', '" + LobjObtenerProyecto.PRYcodigo + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfPERpProyectoElementoRelacion> mtdCargarDatosSecundarioRelacion(int LintCodigo)
        {
            List<cnfPERpProyectoElementoRelacion> LlstLista = new List<cnfPERpProyectoElementoRelacion>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPERpProyectoElementoRelacion>("exec usp_S_cnfPERpProyectoElementoRelacion_CargarDatosRelacion '" + LintCodigo + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public string mtdGuardarSecundario(string[] LstrCodigo, int PECcodigo)
        {
            int LintMensajeRespuesta = -1;
            List<cnfPERpProyectoElementoRelacion> LobjRelacionElementoConfiguracion = new List<cnfPERpProyectoElementoRelacion>();
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    var LobjListaRelacion = LobjContexto.Database.SqlQuery<cnfPERpProyectoElementoRelacion>("usp_S_cnfPERpProyectoElementoRelacion_CargarDatosRelacion '" + PECcodigo + "';").ToList();
                    LobjRelacionElementoConfiguracion = LobjListaRelacion;

                    foreach (var LobjRegistro in LobjRelacionElementoConfiguracion)
                    {
                        LobjContexto.Database.ExecuteSqlCommand("usp_D_cnfPERpProyectoElementoRelacion_Borrar '" + LobjRegistro.PECcodigo_Origen + "', '" + LobjRegistro.PECcodigo_Relacion + "';");
                        LobjContexto.Database.ExecuteSqlCommand("usp_D_cnfPERpProyectoElementoRelacion_Borrar '" + LobjRegistro.PECcodigo_Relacion + "', '" + LobjRegistro.PECcodigo_Origen + "';");
                    }

                    try
                    {
                        foreach (var LstrRegistro in LstrCodigo)
                        {
                            LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("usp_I_cnfPERpProyectoElementoRelacion_GuardarDatosSecundario '" + PECcodigo + "', '" + LstrRegistro + "';");
                            LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("usp_I_cnfPERpProyectoElementoRelacion_GuardarDatosSecundario '" + LstrRegistro + "', '" + PECcodigo + "';");
                        }
                    }
                    catch
                    {
                        LintMensajeRespuesta = 1;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return mtdRespuestaMensaje(LintMensajeRespuesta);
        }


































        public class cnfPECpProyectoElementoConfiguracions
        {
            public int PECcodigo { get; set; }

            public int MEFcodigo { get; set; }

            public string MEFnombre { get; set; }

            public int PRYcodigo { get; set; }

            public string PRYnombre { get; set; }

            public int MNTcodigo { get; set; }

            public string MNTnombre { get; set; }

            public int PLBcodigo { get; set; }

            public DateTime PLBfecha_LineaBase { get; set; }

            [StringLength(250)]
            public string PEClocalizacion { get; set; }

            [StringLength(250)]
            public string PECnombre { get; set; }

            [StringLength(250)]
            public string PECdescripcion { get; set; }

            [StringLength(250)]
            public string PECtipo { get; set; }

            [StringLength(250)]
            public string PECestado { get; set; }

            [StringLength(250)]
            public string PECestado_InOut { get; set; }

            [StringLength(250)]
            public string PECarchivo { get; set; }

            [StringLength(100)]
            public string PECextension { get; set; }
        }
    }
}
