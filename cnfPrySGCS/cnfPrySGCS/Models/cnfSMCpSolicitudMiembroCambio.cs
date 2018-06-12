namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cnfSMCpSolicitudMiembroCambio")]
    public partial class cnfSMCpSolicitudMiembroCambio
    {
        [Key]
        public int SMCcodigo { get; set; }

        public int? SOLcodigo { get; set; }

        public int? PMIcodigo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SMCfecha_EntregaCambio { get; set; }

        public virtual cnfPMIpProyectoMiembro cnfPMIpProyectoMiembro { get; set; }

        public virtual cnfSOLpSolicitud cnfSOLpSolicitud { get; set; }
    }
}
