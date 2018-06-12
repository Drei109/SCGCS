namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cnfPMCpProyectoMiembroCargo")]
    public partial class cnfPMCpProyectoMiembroCargo
    {
        [Key]
        public int PMCcodigo { get; set; }

        public int? PMIcodigo { get; set; }

        [StringLength(250)]
        public string PMCcargo { get; set; }

        public virtual cnfPMIpProyectoMiembro cnfPMIpProyectoMiembro { get; set; }
    }
}
