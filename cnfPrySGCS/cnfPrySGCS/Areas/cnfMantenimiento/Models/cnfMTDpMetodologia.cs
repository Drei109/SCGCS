namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.SqlClient;

    [Table("cnfMTDpMetodologia")]
    public partial class cnfMTDpMetodologia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnfMTDpMetodologia()
        {
            cnfMEFpMetodologiaFase = new HashSet<cnfMEFpMetodologiaFase>();
            cnfPRYpProyecto = new HashSet<cnfPRYpProyecto>();
        }

        [Key]
        public int MTDcodigo { get; set; }

        [StringLength(250)]
        public string MTDnombre { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MTDfecha_Registro { get; set; }

        [StringLength(250)]
        public string MTDestado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfMEFpMetodologiaFase> cnfMEFpMetodologiaFase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPRYpProyecto> cnfPRYpProyecto { get; set; }

        public List<cnfMTDpMetodologia> mtdCargarDatos()
        {
            List<cnfMTDpMetodologia> LlstLista = new List<cnfMTDpMetodologia>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMTDpMetodologia>("exec usp_S_cnfMTDpMetodologia_CargarDatos").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public cnfMTDpMetodologia mtdBuscar(int LintParametro)
        {
            cnfMTDpMetodologia LobjMetodologia = new cnfMTDpMetodologia();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMTDpMetodologia>("exec usp_S_cnfMTDpMetodologia_Buscar " + LintParametro).Single();
                LobjMetodologia = LobjQuery;
            }

            return LobjMetodologia;
        }


        public string mtdGuardar(cnfMTDpMetodologia LobjMetodologia)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    string LstrFechaActual = Convert.ToDateTime(LobjMetodologia.MTDfecha_Registro).ToString("d");

                    if (LobjMetodologia.MTDcodigo == 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_I_cnfMTDpMetodologia_Guardar " + "'" + LobjMetodologia.MTDnombre + "', '" + LstrFechaActual + "', '" + LobjMetodologia.MTDestado + "';");
                    }
                }
            }
            catch (Exception)
            {
                
            }
            return mtdRespuestaMensaje(LintMensajeRespuesta);
        }

        public string mtdModificar(cnfMTDpMetodologia LobjMetodologia)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    string LstrFechaActual = Convert.ToDateTime(LobjMetodologia.MTDfecha_Registro).ToString("d");

                    
                    if (LobjMetodologia.MTDcodigo != 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_U_cnfMTDpMetodologia_Modificar " + LobjMetodologia.MTDcodigo + ", '" + LobjMetodologia.MTDnombre + "', '" + LstrFechaActual + "', '" + LobjMetodologia.MTDestado + "';");
                    }
                }
            }
            catch (Exception)
            {
                
            }
            return mtdRespuestaMensaje(LintMensajeRespuesta);
        }

        public string mtdRespuestaMensaje(int LintMensajeRespuesta)
        {
            string LstrMensajeRespuesta = "";
            if(LintMensajeRespuesta > 0)
            {
                LstrMensajeRespuesta = "Correcto";
            }
            else
            {
                LstrMensajeRespuesta = "Incorrecto";
            }
            return LstrMensajeRespuesta;
        }
    }
}
