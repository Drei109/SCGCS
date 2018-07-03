namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cnfSIApSolicitudInformeAprobacion")]
    public partial class cnfSIApSolicitudInformeAprobacion
    {
        [Key]
        public int SIAcodigo { get; set; }

        public int? SICcodigo { get; set; }

        public int? SOLcodigo { get; set; }

        [StringLength(250)]
        public string SIAinforme_Aprobacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SICfecha_Registro { get; set; }

        public virtual cnfSICpSolicitudInformeCambio cnfSICpSolicitudInformeCambio { get; set; }

        public virtual cnfSOLpSolicitud cnfSOLpSolicitud { get; set; }
    }
}
