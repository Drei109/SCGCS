namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cnfSICpSolicitudInformeCambio")]
    public partial class cnfSICpSolicitudInformeCambio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnfSICpSolicitudInformeCambio()
        {
            cnfSIApSolicitudInformeAprobacion = new HashSet<cnfSIApSolicitudInformeAprobacion>();
        }

        [Key]
        public int SICcodigo { get; set; }

        public int? SOLcodigo { get; set; }

        [StringLength(250)]
        public string SICinforme_Cambio { get; set; }

        [StringLength(250)]
        public string SICcomentario { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SICfecha_Registro { get; set; }

        [StringLength(20)]
        public string SICestado_Cambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSIApSolicitudInformeAprobacion> cnfSIApSolicitudInformeAprobacion { get; set; }

        public virtual cnfSOLpSolicitud cnfSOLpSolicitud { get; set; }
    }
}
