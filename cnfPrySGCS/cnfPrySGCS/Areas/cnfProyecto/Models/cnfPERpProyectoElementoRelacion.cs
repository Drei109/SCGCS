namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cnfPERpProyectoElementoRelacion")]
    public partial class cnfPERpProyectoElementoRelacion
    {
        [Key]
        public int PERcodigo { get; set; }

        public int? PECcodigo_Relacion { get; set; }

        public int? PECcodigo_Origen { get; set; }

        public virtual cnfPECpProyectoElementoConfiguracion cnfPECpProyectoElementoConfiguracion { get; set; }

        public virtual cnfPECpProyectoElementoConfiguracion cnfPECpProyectoElementoConfiguracion1 { get; set; }
    }
}
