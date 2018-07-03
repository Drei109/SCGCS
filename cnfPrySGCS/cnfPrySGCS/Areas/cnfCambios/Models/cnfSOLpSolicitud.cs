namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cnfSOLpSolicitud")]
    public partial class cnfSOLpSolicitud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnfSOLpSolicitud()
        {
            cnfSCCpSolicitudComiteCambio = new HashSet<cnfSCCpSolicitudComiteCambio>();
            cnfSEVpSolicitudEvaluador = new HashSet<cnfSEVpSolicitudEvaluador>();
            cnfSIApSolicitudInformeAprobacion = new HashSet<cnfSIApSolicitudInformeAprobacion>();
            cnfSICpSolicitudInformeCambio = new HashSet<cnfSICpSolicitudInformeCambio>();
            cnfSMCpSolicitudMiembroCambio = new HashSet<cnfSMCpSolicitudMiembroCambio>();
        }

        [Key]
        public int SOLcodigo { get; set; }

        public int? PRYcodigo { get; set; }

        public int? PECcodigo { get; set; }

        public int? MNTcodigo { get; set; }

        public int? USUcodigo { get; set; }

        [StringLength(250)]
        public string SOLsolicitud { get; set; }

        public int? SOLestado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SOLfecha_Registro { get; set; }

        [StringLength(250)]
        public string SOLnivel { get; set; }

        public virtual cnfMNTpMetodologiaEntregable cnfMNTpMetodologiaEntregable { get; set; }

        public virtual cnfPECpProyectoElementoConfiguracion cnfPECpProyectoElementoConfiguracion { get; set; }

        public virtual cnfPRYpProyecto cnfPRYpProyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSCCpSolicitudComiteCambio> cnfSCCpSolicitudComiteCambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSEVpSolicitudEvaluador> cnfSEVpSolicitudEvaluador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSIApSolicitudInformeAprobacion> cnfSIApSolicitudInformeAprobacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSICpSolicitudInformeCambio> cnfSICpSolicitudInformeCambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSMCpSolicitudMiembroCambio> cnfSMCpSolicitudMiembroCambio { get; set; }

        public virtual cnfUSUpUsuario cnfUSUpUsuario { get; set; }
    }
}
