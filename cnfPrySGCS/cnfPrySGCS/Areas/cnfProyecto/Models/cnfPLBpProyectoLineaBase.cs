namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("cnfPLBpProyectoLineaBase")]
    public partial class cnfPLBpProyectoLineaBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnfPLBpProyectoLineaBase()
        {
            cnfPECpProyectoElementoConfiguracion = new HashSet<cnfPECpProyectoElementoConfiguracion>();
        }

        [Key]
        public int PLBcodigo { get; set; }

        public int? PRYcodigo { get; set; }

        public int? MEFcodigo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PLBfecha_LineaBase { get; set; }

        [StringLength(250)]
        public string PLBestado { get; set; }

        public virtual cnfMEFpMetodologiaFase cnfMEFpMetodologiaFase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPECpProyectoElementoConfiguracion> cnfPECpProyectoElementoConfiguracion { get; set; }

        public virtual cnfPRYpProyecto cnfPRYpProyecto { get; set; }

        public List<cnfPLBpProyectoLineaBases> mtdCargarDatos(int LintCodigoUsuario)
        {
            List<cnfPLBpProyectoLineaBases> LlstLista = new List<cnfPLBpProyectoLineaBases>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPLBpProyectoLineaBases>("exec usp_S_cnfPLBpProyectoLineaBase_CargarDatos '" + LintCodigoUsuario + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfPRYpProyecto> mtdCargarComboProyecto(int LintCodigoUsuario)
        {
            List<cnfPRYpProyecto> LlstLista = new List<cnfPRYpProyecto>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPRYpProyecto>("exec usp_S_cnfPLBpProyectoLineaBase_ComboProyecto '" + LintCodigoUsuario + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfMEFpMetodologiaFase> mtdCargarComboFase(int PRYcodigo)
        {
            List<cnfMEFpMetodologiaFase> LlstLista = new List<cnfMEFpMetodologiaFase>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMEFpMetodologiaFase>("exec usp_S_cnfPLBpProyectoLineaBase_ComboFase '" + PRYcodigo + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public cnfPLBpProyectoLineaBases mtdBuscar(int LintParametro)
        {
            cnfPLBpProyectoLineaBases LobjProyectoLineaBase = new cnfPLBpProyectoLineaBases();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPLBpProyectoLineaBases>("exec usp_S_cnfPLBpProyectoLineaBase_Buscar " + LintParametro).Single();
                LobjProyectoLineaBase = LobjQuery;
            }

            return LobjProyectoLineaBase;
        }

        public string mtdGuardar(cnfPLBpProyectoLineaBase LobjLineaBase)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    string LstrFechaActual = Convert.ToDateTime(LobjLineaBase.PLBfecha_LineaBase).ToString("dd/MM/yyyy");

                    if (LobjLineaBase.PLBcodigo == 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_I_cnfPLBpProyectoLineaBase_Guardar " + "'" + LobjLineaBase.PRYcodigo + "', '" + LobjLineaBase.MEFcodigo + "', '" + LstrFechaActual + "', '" + LobjLineaBase.PLBestado + "';");
                    }
                }
            } 
            catch (Exception e)
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

        public string mtdModificar(cnfPLBpProyectoLineaBase LobjLineaBase)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    string LstrFechaActual = Convert.ToDateTime(LobjLineaBase.PLBfecha_LineaBase).ToString("dd/MM/yyyy");


                    if (LobjLineaBase.PLBcodigo != 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_U_cnfPLBpProyectoLineaBase_Modificar '" + LobjLineaBase.PLBcodigo + "', '" + LobjLineaBase.PRYcodigo + "', '" + LobjLineaBase.MEFcodigo + "', '" + LstrFechaActual + "', '" + LobjLineaBase.PLBestado + "';");
                    }
                }
            }
            catch (Exception e)
            {

            }
            return mtdRespuestaMensaje(LintMensajeRespuesta);
        }

















        public class cnfPLBpProyectoLineaBases
        {
            public int PLBcodigo { get; set; }

            public int PRYcodigo { get; set; }

            public string PRYnombre { get; set; }

            public int MEFcodigo { get; set; }

            public string MEFnombre { get; set; }

            [Column(TypeName = "date")]
            public DateTime PLBfecha_LineaBase { get; set; }

            [StringLength(250)]
            public string PLBestado { get; set; }
        }
    }
}
