namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cnfEEMpEntregaEntregableMiembro")]
    public partial class cnfEEMpEntregaEntregableMiembro
    {
        [Key]
        public int EEMcodigo { get; set; }

        public int? EMEcodigo { get; set; }

        public int? PECcodigo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EEMfecha_Registro { get; set; }

        [StringLength(30)]
        public string EEMversion { get; set; }

        [StringLength(30)]
        public string EEMrevision { get; set; }

        [StringLength(30)]
        public string EEMestado { get; set; }

        [StringLength(250)]
        public string EEMentregable { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EEMfecha_Version { get; set; }

        public virtual cnfEMEpEntregableMiembroEntregable cnfEMEpEntregableMiembroEntregable { get; set; }

        public virtual cnfPECpProyectoElementoConfiguracion cnfPECpProyectoElementoConfiguracion { get; set; }
    }
}
