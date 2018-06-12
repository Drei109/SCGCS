namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("cnfPMIpProyectoMiembro")]
    public partial class cnfPMIpProyectoMiembro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnfPMIpProyectoMiembro()
        {
            cnfEMEpEntregableMiembroEntregable = new HashSet<cnfEMEpEntregableMiembroEntregable>();
            cnfEMEpEntregableMiembroEntregable1 = new HashSet<cnfEMEpEntregableMiembroEntregable>();
            cnfPMCpProyectoMiembroCargo = new HashSet<cnfPMCpProyectoMiembroCargo>();
            cnfSCCpSolicitudComiteCambio = new HashSet<cnfSCCpSolicitudComiteCambio>();
            cnfSEVpSolicitudEvaluador = new HashSet<cnfSEVpSolicitudEvaluador>();
            cnfSMCpSolicitudMiembroCambio = new HashSet<cnfSMCpSolicitudMiembroCambio>();
        }

        [Key]
        public int PMIcodigo { get; set; }

        public int? PRYcodigo { get; set; }

        public int? USUcodigo { get; set; }

        [StringLength(250)]
        public string PMIestado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfEMEpEntregableMiembroEntregable> cnfEMEpEntregableMiembroEntregable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfEMEpEntregableMiembroEntregable> cnfEMEpEntregableMiembroEntregable1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPMCpProyectoMiembroCargo> cnfPMCpProyectoMiembroCargo { get; set; }

        public virtual cnfPRYpProyecto cnfPRYpProyecto { get; set; }

        public virtual cnfUSUpUsuario cnfUSUpUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSCCpSolicitudComiteCambio> cnfSCCpSolicitudComiteCambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSEVpSolicitudEvaluador> cnfSEVpSolicitudEvaluador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSMCpSolicitudMiembroCambio> cnfSMCpSolicitudMiembroCambio { get; set; }

        public List<cnfPRYpProyecto> mtdCargarComboProyecto(int LintCodigoUsuario)
        {
            List<cnfPRYpProyecto> LlstLista = new List<cnfPRYpProyecto>();
            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPRYpProyecto>("exec usp_S_cnfPMIpProyectoMiembro_ComboProyecto " + LintCodigoUsuario).ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfPMIpProyectoMiembro> mtdCargarDatos(int LintCodigoProyecto)
        {
            List<cnfPMIpProyectoMiembro> LlstLista = new List<cnfPMIpProyectoMiembro>();
            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPMIpProyectoMiembro>("exec usp_S_cnfPMIpProyectoMiembro_CargarDatos '" + LintCodigoProyecto + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfPMCpProyectoMiembroCargo> mtdListarCargoMiembro(int LintCodigoProyecto)
        {
            List<cnfPMCpProyectoMiembroCargo> LlstLista = new List<cnfPMCpProyectoMiembroCargo>();
            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPMCpProyectoMiembroCargo>("exec usp_S_cnfPMIpProyectoMiembro_CargoMiembro " + LintCodigoProyecto).ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfUSUpUsuario> mtdListarUsuario()
        {
            List<cnfUSUpUsuario> LlstLista = new List<cnfUSUpUsuario>();
            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfUSUpUsuario>("exec usp_S_cnfPMIpProyectoMiembro_CargarUsuario").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public string mtdGuardar(string[] PMCcargo, string[] PMIestado, string[] LobjRegistro, int LintCodigoProyecto)
        {
            int LintMensajeRespuesta = -1;
            int LintContador = 0;
            cnfPMIpProyectoMiembro LobjProyectoMiembro = new cnfPMIpProyectoMiembro();
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    LobjContexto.Database.ExecuteSqlCommand("usp_D_cnfPMIpProyectoMiembro_BorrarSecundario '" + LintCodigoProyecto + "';");
                    LobjContexto.Database.ExecuteSqlCommand("usp_D_cnfPMIpProyectoMiembro_BorrarPrincipal '" + LintCodigoProyecto + "';");

                    if (LobjRegistro != null)
                    {
                        for (int i = 0; i < LobjRegistro.Count(); i++)
                        {
                            LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("usp_I_cnfPMIpProyectoMiembro_GuardarPrincipal '" + LintCodigoProyecto + "', '" + LobjRegistro[i] + "', '" + PMIestado[i] + "';");

                            LobjProyectoMiembro = LobjContexto.Database.SqlQuery<cnfPMIpProyectoMiembro>("usp_S_cnfPMIpProyectoMiembro_ObtenerUltimoGuardadoPrincipal").Single();

                            for (int j = 0; j < 3; j++)
                            {
                                LobjContexto.Database.ExecuteSqlCommand("usp_I_cnfPMIpProyectoMiembro_GuardarSecundario '" + LobjProyectoMiembro.PMIcodigo + "', '" + PMCcargo[LintContador] + "';");
                                LintContador++;
                            }
                        }
                    }
                    else
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
    }
}
