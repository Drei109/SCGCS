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
    [Table("cnfEMEpEntregableMiembroEntregable")]
    public partial class cnfEMEpEntregableMiembroEntregable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnfEMEpEntregableMiembroEntregable()
        {
            cnfEEMpEntregaEntregableMiembro = new HashSet<cnfEEMpEntregaEntregableMiembro>();
        }

        [Key]
        public int EMEcodigo { get; set; }

        public int? PECcodigo { get; set; }

        public int? PMIcodigo_Responsable { get; set; }

        public int? PMIcodigo_Evaluador { get; set; }

        public int? PRYcodigo { get; set; }

        public int? MNTcodigo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EMEfecha_Registro { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EMEfecha_Entrega { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfEEMpEntregaEntregableMiembro> cnfEEMpEntregaEntregableMiembro { get; set; }

        public virtual cnfMNTpMetodologiaEntregable cnfMNTpMetodologiaEntregable { get; set; }

        public virtual cnfPECpProyectoElementoConfiguracion cnfPECpProyectoElementoConfiguracion { get; set; }

        public virtual cnfPMIpProyectoMiembro cnfPMIpProyectoMiembro { get; set; }

        public virtual cnfPMIpProyectoMiembro cnfPMIpProyectoMiembro1 { get; set; }

        public virtual cnfPRYpProyecto cnfPRYpProyecto { get; set; }
        public List<cnfEMEpEntregableMiembroEntregables> mtdCargarDatosPrincipal()
        {
            List<cnfEMEpEntregableMiembroEntregables> LlstLista = new List<cnfEMEpEntregableMiembroEntregables>();

            using (var LobjContexto = new cnfModelo())
            {

                var LobjQuery = LobjContexto.Database.SqlQuery<cnfEMEpEntregableMiembroEntregables>("exec usp_S_cnfEMEpEntregableMiembroEntregable_CargarDatosPrincipal").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }
        //public List<cnfPRYpProyectosEntregables> mtdCargarDatos(int LintCodigoProyecto)
        //{
        //    List<cnfPRYpProyectosEntregables> LlstLista = new List<cnfPRYpProyectosEntregables>();
        //    using (var LobjContexto = new cnfModelo())
        //    {
        //        var LobjConsulta = LobjContexto.Database.SqlQuery<cnfPRYpProyecto>("exec usp_S_cnfPRYpProyectoEntregable_Buscar " + LintCodigoProyecto).Single();

        //        cnfPRYpProyecto LobjProyecto = LobjConsulta;

        //        string LintCodigoMetodologiaProyecto = Convert.ToString(LobjProyecto.MTDcodigo);

        //        var LobjQuery = LobjContexto.Database.SqlQuery<cnfPRYpProyectosEntregables>("exec usp_S_cnfPRYpProyectoEntregable_CargarDatos '" + LintCodigoMetodologiaProyecto + "';").ToList();
        //        LlstLista = LobjQuery;
        //    }

        //    return LlstLista;
        //}

        public cnfEMEpEntregableMiembroEntregable mtdBuscar(int LintParametro)
        {
            cnfEMEpEntregableMiembroEntregable LobjEntrega = new cnfEMEpEntregableMiembroEntregable();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfEMEpEntregableMiembroEntregable>("exec usp_S_cnfEMEpEntregableMiembroEntregable_Buscar " + LintParametro).Single();
                LobjEntrega = LobjQuery;
            }

            return LobjEntrega;
        }


        public string mtdGuardar(cnfEMEpEntregableMiembroEntregable LobjEntrega)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    string LstrFechaActual = Convert.ToDateTime(LobjEntrega.EMEfecha_Registro).ToString("d");

                    if (LobjEntrega.EMEcodigo == 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_I_cnfEMEpEntregableMiembroEntregable_Guardar " + "'" + LobjEntrega.PMIcodigo_Evaluador + "', '" + LstrFechaActual + "', '");
                    }
                }
            }
            catch (Exception)
            {

            }
            return mtdMensajeRespuesta(LintMensajeRespuesta);
        }

        public string mtdModificar(cnfEMEpEntregableMiembroEntregable LobjEntrega)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    string LstrFechaActual = Convert.ToDateTime(LobjEntrega.EMEfecha_Registro).ToString("d");


                    if (LobjEntrega.EMEcodigo != 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_U_EMEpEntregableMiembroEntregable_Modificar " + LobjEntrega.EMEcodigo + ", '" + LobjEntrega.PMIcodigo_Responsable + "', '" + LstrFechaActual + "', '" + LobjEntrega.PRYcodigo + "';");
                    }
                }
            }
            catch (Exception)
            {

            }
            return mtdMensajeRespuesta(LintMensajeRespuesta);
        }

        public string mtdMensajeRespuesta(int LintMensajeRespuesta)
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





































        public class cnfEMEpEntregableMiembroEntregables
        {
            public int EMEcodigo { get; set; }
            public string EMEnombre { get; set; }
            public int PECcodigo { get; set; }
            public string PECnombre { get; set; }
            public int PMIcodigo { get; set; }
            public string PMInombre { get; set; }
            public int PMIcodigo_Responsable { get; set; }
            public string PMIcodigo_Responsable_nombre { get; set; }
            public int PMIcodigo_Evaluador { get; set; }
            public string PMIcodigo_Evaluador_nombre { get; set; }
            public int PRYcodigo { get; set; }
            public string PRYnombre { get; set; }
            public int MNTcodigo { get; set; }
            public string MNTnombre { get; set; }

            [Column(TypeName = "date")]
            public DateTime? EMEfecha_Registro { get; set; }

            [Column(TypeName = "date")]
            public DateTime? EMEfecha_Entrega { get; set; }



        }

        }
}
    

