namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.SqlClient;

    [Table("cnfMNTpMetodologiaEntregable")]
    public partial class cnfMNTpMetodologiaEntregable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnfMNTpMetodologiaEntregable()
        {
            cnfEMEpEntregableMiembroEntregable = new HashSet<cnfEMEpEntregableMiembroEntregable>();
            cnfEREpEntregableRelacion = new HashSet<cnfEREpEntregableRelacion>();
            cnfEREpEntregableRelacion1 = new HashSet<cnfEREpEntregableRelacion>();
            cnfPECpProyectoElementoConfiguracion = new HashSet<cnfPECpProyectoElementoConfiguracion>();
            cnfSOLpSolicitud = new HashSet<cnfSOLpSolicitud>();
        }

        [Key]
        public int MNTcodigo { get; set; }

        public int? MEFcodigo { get; set; }

        [StringLength(250)]
        public string MNTnombre { get; set; }

        [StringLength(100)]
        public string MNTdescripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MNTfecha_Registro { get; set; }

        [StringLength(250)]
        public string MNTnomenclatura { get; set; }

        [StringLength(250)]
        public string MNTestado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfEMEpEntregableMiembroEntregable> cnfEMEpEntregableMiembroEntregable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfEREpEntregableRelacion> cnfEREpEntregableRelacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfEREpEntregableRelacion> cnfEREpEntregableRelacion1 { get; set; }

        public virtual cnfMEFpMetodologiaFase cnfMEFpMetodologiaFase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPECpProyectoElementoConfiguracion> cnfPECpProyectoElementoConfiguracion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSOLpSolicitud> cnfSOLpSolicitud { get; set; }

        public List<cnfMNTpMetodologiaEntregables> mtdCargarDatosPrincipal()
        {
            List<cnfMNTpMetodologiaEntregables> LlstLista = new List<cnfMNTpMetodologiaEntregables>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMNTpMetodologiaEntregables>("exec usp_S_cnfMNTpMetodologiaEntregable_CargarDatosPrincipal").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfMTDpMetodologia> mtdCargarComboMetodologia()
        {
            List<cnfMTDpMetodologia> LlstLista = new List<cnfMTDpMetodologia>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMTDpMetodologia>("exec usp_S_cnfMNTpMetodologiaEntregable_ComboMetodologia").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfMEFpMetodologiaFase> mtdCargarComboFase(int MTDcodigo)
        {
            List<cnfMEFpMetodologiaFase> LlstLista = new List<cnfMEFpMetodologiaFase>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMEFpMetodologiaFase>("exec usp_S_cnfMNTpMetodologiaEntregable_ComboFase '" + MTDcodigo + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public cnfMNTpMetodologiaEntregables mtdBuscar(int LintParametro)
        {
            cnfMNTpMetodologiaEntregables LobjEntregable = new cnfMNTpMetodologiaEntregables();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMNTpMetodologiaEntregables>("exec usp_S_cnfMNTpMetodologiaEntregable_Buscar " + LintParametro).Single();
                LobjEntregable = LobjQuery;
            }

            return LobjEntregable;
        }

        public string mtdGuardarPrincipal(cnfMNTpMetodologiaEntregable LobjEntregable)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    string LstrFechaActual = Convert.ToDateTime(LobjEntregable.MNTfecha_Registro).ToString("d");

                    if (LobjEntregable.MNTcodigo == 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_I_cnfMNTpMetodologiaEntregable_GuardarPrincipal " + "'" + LobjEntregable.MEFcodigo + "', '" + LobjEntregable.MNTnombre + "', '" + LobjEntregable.MNTdescripcion + "', '" + LstrFechaActual + "', '" + LobjEntregable.MNTnomenclatura + "', '" + LobjEntregable.MNTestado + "';");
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

        public string mtdModificar(cnfMNTpMetodologiaEntregable LobjEntregable)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    string LstrFechaActual = Convert.ToDateTime(LobjEntregable.MNTfecha_Registro).ToString("d");


                    if (LobjEntregable.MEFcodigo != 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_U_cnfMNTpMetodologiaEntregable_Modificar '" + LobjEntregable.MNTcodigo + "', '" + LobjEntregable.MEFcodigo + "', '" + LobjEntregable.MNTnombre + "', '" + LobjEntregable.MNTdescripcion + "', '" + LstrFechaActual + "', '" + LobjEntregable.MNTnomenclatura + "', '" + LobjEntregable.MNTestado + "';");
                    }
                }
            }
            catch (Exception)
            {

            }
            return mtdRespuestaMensaje(LintMensajeRespuesta);
        }

        public List<cnfMNTpMetodologiaEntregables> mtdCargarDatosSecundario(int LintCodigo)
        {
            List<cnfMNTpMetodologiaEntregables> LlstLista = new List<cnfMNTpMetodologiaEntregables>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMNTpMetodologiaEntregables>("exec usp_S_cnfEREpEntregableRelacion_CargarDatosSecundario '" + LintCodigo + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfEREpEntregableRelacion> mtdCargarDatosSecundarioRelacion(int LintCodigo)
        {
            List<cnfEREpEntregableRelacion> LlstLista = new List<cnfEREpEntregableRelacion>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfEREpEntregableRelacion>("exec usp_S_cnfEREpEntregableRelacion_CargarDatosRelacion '" + LintCodigo + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public string mtdGuardarSecundario(string[] LstrCodigo, int MNTcodigo)
        {
            int LintMensajeRespuesta = -1;
            List<cnfEREpEntregableRelacion> LobjRelacionEntregable = new List<cnfEREpEntregableRelacion>();
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    var LobjListaRelacion = LobjContexto.Database.SqlQuery<cnfEREpEntregableRelacion>("usp_S_cnfEREpEntregableRelacion_CargarDatosRelacion '" + MNTcodigo + "';").ToList();
                    LobjRelacionEntregable = LobjListaRelacion;

                    foreach(var LobjRegistro in LobjRelacionEntregable)
                    {
                        LobjContexto.Database.ExecuteSqlCommand("usp_D_cnfEREpEntregableRelacion_Borrar '" + LobjRegistro.MNTcodigo_Origen + "', '" + LobjRegistro.MNTcodigo_Relacion + "';");
                        LobjContexto.Database.ExecuteSqlCommand("usp_D_cnfEREpEntregableRelacion_Borrar '" + LobjRegistro.MNTcodigo_Relacion + "', '" + LobjRegistro.MNTcodigo_Origen + "';");
                    }

                    try
                    {
                        foreach (var LstrRegistro in LstrCodigo)
                        {
                            LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("usp_I_cnfEREpEntregableRelacion_GuardarDatosSecundario '" + MNTcodigo + "', '" + LstrRegistro + "';");
                            LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("usp_I_cnfEREpEntregableRelacion_GuardarDatosSecundario '" + LstrRegistro + "', '" + MNTcodigo + "';");
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








        public class cnfMNTpMetodologiaEntregables
        {
            public int MNTcodigo { get; set; }

            public int MEFcodigo { get; set; }

            public int MTDcodigo { get; set; }

            [StringLength(250)]
            public string MEFnombre { get; set; }

            [StringLength(250)]
            public string MTDnombre { get; set; }

            [StringLength(250)]
            public string MNTnombre { get; set; }

            [StringLength(100)]
            public string MNTdescripcion { get; set; }

            [Column(TypeName = "date")]
            public DateTime? MNTfecha_Registro { get; set; }

            [StringLength(250)]
            public string MNTnomenclatura { get; set; }

            [StringLength(250)]
            public string MNTestado { get; set; }
        }
    }
}
