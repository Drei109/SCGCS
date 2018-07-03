namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cnfSCCpSolicitudComiteCambio")]
    public partial class cnfSCCpSolicitudComiteCambio
    {
        [Key]
        public int SCCcodigo { get; set; }

        public int? SOLcodigo { get; set; }

        public int? PMIcodigo { get; set; }

        public virtual cnfPMIpProyectoMiembro cnfPMIpProyectoMiembro { get; set; }

        public virtual cnfSOLpSolicitud cnfSOLpSolicitud { get; set; }
    }
}
