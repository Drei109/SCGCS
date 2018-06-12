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

    [Table("cnfMEFpMetodologiaFase")]
    public partial class cnfMEFpMetodologiaFase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnfMEFpMetodologiaFase()
        {
            cnfMNTpMetodologiaEntregable = new HashSet<cnfMNTpMetodologiaEntregable>();
            cnfPECpProyectoElementoConfiguracion = new HashSet<cnfPECpProyectoElementoConfiguracion>();
            cnfPLBpProyectoLineaBase = new HashSet<cnfPLBpProyectoLineaBase>();
        }

        [Key]
        public int MEFcodigo { get; set; }

        public int? MTDcodigo { get; set; }

        [StringLength(250)]
        public string MEFnombre { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MEFfecha_Registro { get; set; }

        [StringLength(250)]
        public string MEFestado { get; set; }

        public virtual cnfMTDpMetodologia cnfMTDpMetodologia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfMNTpMetodologiaEntregable> cnfMNTpMetodologiaEntregable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPECpProyectoElementoConfiguracion> cnfPECpProyectoElementoConfiguracion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPLBpProyectoLineaBase> cnfPLBpProyectoLineaBase { get; set; }

        public List<clsAyuda> mtdCargarDatos()
        {
            List<clsAyuda> LlstLista = new List<clsAyuda>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<clsAyuda>("exec usp_S_cnfMEFpMetodologiaFase_CargarDatos").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfMTDpMetodologia> mtdCargarComboMetodologia()
        {
            List<cnfMTDpMetodologia> LlstLista = new List<cnfMTDpMetodologia>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMTDpMetodologia>("exec usp_S_cnfMEFpMetodologiaFase_ComboMetodologia").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public cnfMEFpMetodologiaFase mtdBuscar(int LintParametro)
        {
            cnfMEFpMetodologiaFase LobjFase = new cnfMEFpMetodologiaFase();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMEFpMetodologiaFase>("exec usp_S_cnfMEFpMetodologiaFase_Buscar " + LintParametro).Single();
                LobjFase = LobjQuery;
            }

            return LobjFase;
        }


        public string mtdGuardar(cnfMEFpMetodologiaFase LobjFase)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    string LstrFechaActual = Convert.ToDateTime(LobjFase.MEFfecha_Registro).ToString("d");

                    if (LobjFase.MEFcodigo == 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_I_cnfMEFpMetodologiaFase_Guardar " + "'" + LobjFase.MTDcodigo + "', '" + LobjFase.MEFnombre + "', '" + LstrFechaActual + "', '" + LobjFase.MEFestado + "';");
                    }
                }
            }
            catch (Exception)
            {

            }
            return mtdRespuestaMensaje(LintMensajeRespuesta);
        }

        public string mtdModificar(cnfMEFpMetodologiaFase LobjFase)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    string LstrFechaActual = Convert.ToDateTime(LobjFase.MEFfecha_Registro).ToString("d");


                    if (LobjFase.MEFcodigo != 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_U_cnfMEFpMetodologiaFase_Modificar  '" + LobjFase.MEFcodigo + "', '" + LobjFase.MTDcodigo + "', '" + LobjFase.MEFnombre + "', '" + LstrFechaActual + "', '" + LobjFase.MEFestado + "';");
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
            if (LintMensajeRespuesta > 0)
            {
                LstrMensajeRespuesta = "Correcto";
            }
            else
            {
                LstrMensajeRespuesta = "Incorrecto";
            }
            return LstrMensajeRespuesta;
        }

















        public class clsAyuda
        {
            public int MEFcodigo { get; set; }

            public string MTDnombre { get; set; }

            [StringLength(250)]
            public string MEFnombre { get; set; }

            [Column(TypeName = "date")]
            public DateTime? MEFfecha_Registro { get; set; }

            [StringLength(250)]
            public string MEFestado { get; set; }
        }
    }
}
