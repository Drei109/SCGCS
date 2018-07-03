namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cnfSEVpSolicitudEvaluador")]
    public partial class cnfSEVpSolicitudEvaluador
    {
        [Key]
        public int SEVcodigo { get; set; }

        public int? SOLcodigo { get; set; }

        public int? PMIcodigo { get; set; }

        public virtual cnfPMIpProyectoMiembro cnfPMIpProyectoMiembro { get; set; }

        public virtual cnfSOLpSolicitud cnfSOLpSolicitud { get; set; }
    }
}
