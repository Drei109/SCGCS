namespace cnfPrySGCS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class cnfModelo : DbContext
    {
        public cnfModelo()
            : base("name=cnfModelo")
        {
        }

        public virtual DbSet<cnfEEMpEntregaEntregableMiembro> cnfEEMpEntregaEntregableMiembro { get; set; }
        public virtual DbSet<cnfEMEpEntregableMiembroEntregable> cnfEMEpEntregableMiembroEntregable { get; set; }
        public virtual DbSet<cnfEREpEntregableRelacion> cnfEREpEntregableRelacion { get; set; }
        public virtual DbSet<cnfMEFpMetodologiaFase> cnfMEFpMetodologiaFase { get; set; }
        public virtual DbSet<cnfMNTpMetodologiaEntregable> cnfMNTpMetodologiaEntregable { get; set; }
        public virtual DbSet<cnfMTDpMetodologia> cnfMTDpMetodologia { get; set; }
        public virtual DbSet<cnfPECpProyectoElementoConfiguracion> cnfPECpProyectoElementoConfiguracion { get; set; }
        public virtual DbSet<cnfPERpProyectoElementoRelacion> cnfPERpProyectoElementoRelacion { get; set; }
        public virtual DbSet<cnfPLBpProyectoLineaBase> cnfPLBpProyectoLineaBase { get; set; }
        public virtual DbSet<cnfPMCpProyectoMiembroCargo> cnfPMCpProyectoMiembroCargo { get; set; }
        public virtual DbSet<cnfPMIpProyectoMiembro> cnfPMIpProyectoMiembro { get; set; }
        public virtual DbSet<cnfPRYpProyecto> cnfPRYpProyecto { get; set; }
        public virtual DbSet<cnfPYEpProyectoEntregable> cnfPYEpProyectoEntregable { get; set; }
        public virtual DbSet<cnfSCCpSolicitudComiteCambio> cnfSCCpSolicitudComiteCambio { get; set; }
        public virtual DbSet<cnfSEVpSolicitudEvaluador> cnfSEVpSolicitudEvaluador { get; set; }
        public virtual DbSet<cnfSIApSolicitudInformeAprobacion> cnfSIApSolicitudInformeAprobacion { get; set; }
        public virtual DbSet<cnfSICpSolicitudInformeCambio> cnfSICpSolicitudInformeCambio { get; set; }
        public virtual DbSet<cnfSMCpSolicitudMiembroCambio> cnfSMCpSolicitudMiembroCambio { get; set; }
        public virtual DbSet<cnfSOLpSolicitud> cnfSOLpSolicitud { get; set; }
        public virtual DbSet<cnfUSUpUsuario> cnfUSUpUsuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cnfEEMpEntregaEntregableMiembro>()
                .Property(e => e.EEMversion)
                .IsUnicode(false);

            modelBuilder.Entity<cnfEEMpEntregaEntregableMiembro>()
                .Property(e => e.EEMrevision)
                .IsUnicode(false);

            modelBuilder.Entity<cnfEEMpEntregaEntregableMiembro>()
                .Property(e => e.EEMestado)
                .IsUnicode(false);

            modelBuilder.Entity<cnfEEMpEntregaEntregableMiembro>()
                .Property(e => e.EEMentregable)
                .IsUnicode(false);

            modelBuilder.Entity<cnfMEFpMetodologiaFase>()
                .Property(e => e.MEFnombre)
                .IsUnicode(false);

            modelBuilder.Entity<cnfMEFpMetodologiaFase>()
                .Property(e => e.MEFestado)
                .IsUnicode(false);

            modelBuilder.Entity<cnfMNTpMetodologiaEntregable>()
                .Property(e => e.MNTnombre)
                .IsUnicode(false);

            modelBuilder.Entity<cnfMNTpMetodologiaEntregable>()
                .Property(e => e.MNTdescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<cnfMNTpMetodologiaEntregable>()
                .Property(e => e.MNTnomenclatura)
                .IsUnicode(false);

            modelBuilder.Entity<cnfMNTpMetodologiaEntregable>()
                .Property(e => e.MNTestado)
                .IsUnicode(false);

            modelBuilder.Entity<cnfMNTpMetodologiaEntregable>()
                .HasMany(e => e.cnfEREpEntregableRelacion)
                .WithOptional(e => e.cnfMNTpMetodologiaEntregable)
                .HasForeignKey(e => e.MNTcodigo_Origen);

            modelBuilder.Entity<cnfMNTpMetodologiaEntregable>()
                .HasMany(e => e.cnfEREpEntregableRelacion1)
                .WithOptional(e => e.cnfMNTpMetodologiaEntregable1)
                .HasForeignKey(e => e.MNTcodigo_Relacion);

            modelBuilder.Entity<cnfMTDpMetodologia>()
                .Property(e => e.MTDnombre)
                .IsUnicode(false);

            modelBuilder.Entity<cnfMTDpMetodologia>()
                .Property(e => e.MTDestado)
                .IsUnicode(false);

            modelBuilder.Entity<cnfPECpProyectoElementoConfiguracion>()
                .Property(e => e.PEClocalizacion)
                .IsUnicode(false);

            modelBuilder.Entity<cnfPECpProyectoElementoConfiguracion>()
                .Property(e => e.PECnombre)
                .IsUnicode(false);

            modelBuilder.Entity<cnfPECpProyectoElementoConfiguracion>()
                .Property(e => e.PECdescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<cnfPECpProyectoElementoConfiguracion>()
                .Property(e => e.PECtipo)
                .IsUnicode(false);

            modelBuilder.Entity<cnfPECpProyectoElementoConfiguracion>()
                .Property(e => e.PECestado)
                .IsUnicode(false);

            modelBuilder.Entity<cnfPECpProyectoElementoConfiguracion>()
                .Property(e => e.PECestado_InOut)
                .IsUnicode(false);

            modelBuilder.Entity<cnfPECpProyectoElementoConfiguracion>()
                .HasMany(e => e.cnfPERpProyectoElementoRelacion)
                .WithOptional(e => e.cnfPECpProyectoElementoConfiguracion)
                .HasForeignKey(e => e.PECcodigo_Relacion);

            modelBuilder.Entity<cnfPECpProyectoElementoConfiguracion>()
                .HasMany(e => e.cnfPERpProyectoElementoRelacion1)
                .WithOptional(e => e.cnfPECpProyectoElementoConfiguracion1)
                .HasForeignKey(e => e.PECcodigo_Origen);

            modelBuilder.Entity<cnfPLBpProyectoLineaBase>()
                .Property(e => e.PLBestado)
                .IsUnicode(false);

            modelBuilder.Entity<cnfPMCpProyectoMiembroCargo>()
                .Property(e => e.PMCcargo)
                .IsUnicode(false);

            modelBuilder.Entity<cnfPMIpProyectoMiembro>()
                .Property(e => e.PMIestado)
                .IsUnicode(false);

            modelBuilder.Entity<cnfPMIpProyectoMiembro>()
                .HasMany(e => e.cnfEMEpEntregableMiembroEntregable)
                .WithOptional(e => e.cnfPMIpProyectoMiembro)
                .HasForeignKey(e => e.PMIcodigo_Responsable);

            modelBuilder.Entity<cnfPMIpProyectoMiembro>()
                .HasMany(e => e.cnfEMEpEntregableMiembroEntregable1)
                .WithOptional(e => e.cnfPMIpProyectoMiembro1)
                .HasForeignKey(e => e.PMIcodigo_Evaluador);

            modelBuilder.Entity<cnfPRYpProyecto>()
                .Property(e => e.PRYnombre)
                .IsUnicode(false);

            modelBuilder.Entity<cnfPRYpProyecto>()
                .Property(e => e.PRYdescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<cnfPRYpProyecto>()
                .Property(e => e.PRYestado)
                .IsUnicode(false);

            modelBuilder.Entity<cnfSIApSolicitudInformeAprobacion>()
                .Property(e => e.SIAinforme_Aprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<cnfSICpSolicitudInformeCambio>()
                .Property(e => e.SICinforme_Cambio)
                .IsUnicode(false);

            modelBuilder.Entity<cnfSICpSolicitudInformeCambio>()
                .Property(e => e.SICcomentario)
                .IsUnicode(false);

            modelBuilder.Entity<cnfSICpSolicitudInformeCambio>()
                .Property(e => e.SICestado_Cambio)
                .IsUnicode(false);

            modelBuilder.Entity<cnfSOLpSolicitud>()
                .Property(e => e.SOLsolicitud)
                .IsUnicode(false);

            modelBuilder.Entity<cnfSOLpSolicitud>()
                .Property(e => e.SOLnivel)
                .IsUnicode(false);

            modelBuilder.Entity<cnfUSUpUsuario>()
                .Property(e => e.USUdni)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<cnfUSUpUsuario>()
                .Property(e => e.USUnombre)
                .IsUnicode(false);

            modelBuilder.Entity<cnfUSUpUsuario>()
                .Property(e => e.USUapellido)
                .IsUnicode(false);

            modelBuilder.Entity<cnfUSUpUsuario>()
                .Property(e => e.USUcorreo)
                .IsUnicode(false);

            modelBuilder.Entity<cnfUSUpUsuario>()
                .Property(e => e.USUtelefono)
                .IsUnicode(false);

            modelBuilder.Entity<cnfUSUpUsuario>()
                .Property(e => e.USUusuario)
                .IsUnicode(false);

            modelBuilder.Entity<cnfUSUpUsuario>()
                .Property(e => e.USUcontrasena)
                .IsUnicode(false);

            modelBuilder.Entity<cnfUSUpUsuario>()
                .Property(e => e.USUnivel)
                .IsUnicode(false);

            modelBuilder.Entity<cnfUSUpUsuario>()
                .Property(e => e.USUestado)
                .IsUnicode(false);
        }
    }
}
