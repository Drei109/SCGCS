namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("cnfPYEpProyectoEntregable")]
    public partial class cnfPYEpProyectoEntregable
    {
        [Key]
        public int PYEcodigo { get; set; }

        public int? MEFcodigo { get; set; }

        public int? PRYcodigo { get; set; }

        public int? MNTcodigo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PYEfecha_InicioFase { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PYEfecha_FinFase { get; set; }

        public virtual cnfMEFpMetodologiaFase cnfMEFpMetodologiaFase { get; set; }

        public virtual cnfMNTpMetodologiaEntregable cnfMNTpMetodologiaEntregable { get; set; }

        public virtual cnfPRYpProyecto cnfPRYpProyecto { get; set; }

        public List<cnfPRYpProyecto.cnfPRYpProyectos> mtdCargarComboProyecto(int LintCodigoUsuario)
        {
            List<cnfPRYpProyecto.cnfPRYpProyectos> LlstLista = new List<cnfPRYpProyecto.cnfPRYpProyectos>();
            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPRYpProyecto.cnfPRYpProyectos>("exec usp_S_cnfPRYpProyectoEntregable_ComboProyecto " + LintCodigoUsuario).ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfPRYpProyectosEntregables> mtdCargarDatos(int LintCodigoProyecto)
        {
            List<cnfPRYpProyectosEntregables> LlstLista = new List<cnfPRYpProyectosEntregables>();
            using (var LobjContexto = new cnfModelo())
            {
                var LobjConsulta = LobjContexto.Database.SqlQuery<cnfPRYpProyecto>("exec usp_S_cnfPRYpProyectoEntregable_Buscar " + LintCodigoProyecto).Single();

                cnfPRYpProyecto LobjProyecto = LobjConsulta;

                string LintCodigoMetodologiaProyecto = Convert.ToString(LobjProyecto.MTDcodigo);

                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPRYpProyectosEntregables>("exec usp_S_cnfPRYpProyectoEntregable_CargarDatos '" + LintCodigoMetodologiaProyecto + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfPYEpProyectoEntregable> mtdCargarDatosRelacion(int LintCodigoProyecto)
        {
            List<cnfPYEpProyectoEntregable> LlstLista = new List<cnfPYEpProyectoEntregable>();
            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfPYEpProyectoEntregable>("exec usp_S_cnfPRYpProyectoEntregable_CargarDatosRelacion " + LintCodigoProyecto).ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public List<cnfMEFpMetodologiaFase> mtdListarFase(int LintCodigoProyecto)
        {
            List<cnfMEFpMetodologiaFase> LlstLista = new List<cnfMEFpMetodologiaFase>();
            using (var LobjContexto = new cnfModelo())
            {
                var LobjConsulta = LobjContexto.Database.SqlQuery<cnfPRYpProyecto>("exec usp_S_cnfPRYpProyectoEntregable_Buscar " + LintCodigoProyecto).Single();

                cnfPRYpProyecto LobjProyecto = LobjConsulta;

                string LintCodigoMetodologiaProyecto = Convert.ToString(LobjProyecto.MTDcodigo);

                var LobjQuery = LobjContexto.Database.SqlQuery<cnfMEFpMetodologiaFase>("exec usp_S_cnfPRYpProyectoEntregable_ListarFase '" + LintCodigoMetodologiaProyecto + "';").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public string mtdGuardar(string[] PYEfecha_InicioFase , string[] PYEfecha_FinFase, string[] LobjRegistro, int LintCodigoProyecto)
        {
            int LintMensajeRespuesta = -1;
            int LintContador = 0;
            List<cnfPYEpProyectoEntregable> LobjProyectoEntregable = new List<cnfPYEpProyectoEntregable>();
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    LobjContexto.Database.ExecuteSqlCommand("usp_D_cnfPRYpProyectoEntregable_Borrar '" + LintCodigoProyecto + "';");

                    for(int i = 0; i<LobjRegistro.Count(); i++)
                    {
                        string[] LobjReg1 = LobjRegistro[i].Split(',');
                        string[] LobjReg2 = null;
                        bool LblnFlag = false;
                        try
                        {
                            LobjReg2 = LobjRegistro[i + 1].Split(',');
                        }
                        catch
                        {
                            LblnFlag = true;
                        }

                        if(LblnFlag)
                        {
                            LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("usp_I_cnfPRYpProyectoEntregable_Guardar '" + LobjReg1[0] + "', '" + LintCodigoProyecto + "', '" + LobjReg1[1] + "', '" + PYEfecha_InicioFase[LintContador] + "', '" + PYEfecha_FinFase[LintContador] + "';");
                            break;
                        }

                        if (LobjReg1[0] == LobjReg2[0])
                        {
                            LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("usp_I_cnfPRYpProyectoEntregable_Guardar '" + LobjReg1[0] + "', '" + LintCodigoProyecto + "', '" + LobjReg1[1] + "', '" + PYEfecha_InicioFase[LintContador] + "', '" + PYEfecha_FinFase[LintContador] + "';");
                        }
                        else
                        {
                            LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("usp_I_cnfPRYpProyectoEntregable_Guardar '" + LobjReg1[0] + "', '" + LintCodigoProyecto + "', '" + LobjReg1[1] + "', '" + PYEfecha_InicioFase[LintContador] + "', '" + PYEfecha_FinFase[LintContador] + "';");
                            LintContador++;
                        }
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

















        public class cnfPRYpProyectoEntregables
        {
            public int PYEcodigo { get; set; }

            public int MEFcodigo { get; set; }

            public int MEFnombre { get; set; }

            public int PRYcodigo { get; set; }

            public string PRYnombre { get; set; }

            public int MNTcodigo { get; set; }

            public string MNTnombre { get; set; }

            [Column(TypeName = "date")]
            public DateTime? PYEfecha_InicioFase { get; set; }

            [Column(TypeName = "date")]
            public DateTime? PYEfecha_FinFase { get; set; }
        }

        public class cnfPRYpProyectosEntregables
        {
            public int MTDcodigo { get; set; }

            public string MTDnombre { get; set; }

            public int MEFcodigo { get; set; }

            public string MEFnombre { get; set; }

            public int MNTcodigo { get; set; }

            public string MNTnombre { get; set; }
        }
    }
}
