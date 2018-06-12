namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cnfEREpEntregableRelacion")]
    public partial class cnfEREpEntregableRelacion
    {
        [Key]
        public int EREcodigo { get; set; }

        public int? MNTcodigo_Origen { get; set; }

        public int? MNTcodigo_Relacion { get; set; }

        public virtual cnfMNTpMetodologiaEntregable cnfMNTpMetodologiaEntregable { get; set; }

        public virtual cnfMNTpMetodologiaEntregable cnfMNTpMetodologiaEntregable1 { get; set; }
    }
}
