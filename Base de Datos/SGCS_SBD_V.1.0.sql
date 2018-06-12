--Fecha: 15/10/2017
--Autor: Luis Mamani
--Comentario: Creación de la Base de Datos cnfConfiguracion

create database cnfConfiguracion
go

use cnfConfiguracion
go 

if (not exists(select 1 from sys.tables where name = 'cnfMTDpMetodologia'))
    CREATE TABLE cnfMTDpMetodologia (
		MTDcodigo integer identity(1,1),
		MTDnombre varchar(250) unique,
		MTDfecha_Registro date,
		MTDestado varchar(250),
		PRIMARY KEY (MTDcodigo)
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfMEFpMetodologiaFase'))
    CREATE TABLE cnfMEFpMetodologiaFase (
		MEFcodigo integer identity(1,1),
		MTDcodigo int,
		MEFnombre varchar(250) unique,
		MEFfecha_Registro date,
		MEFestado varchar(250),
		PRIMARY KEY (MEFcodigo),
		FOREIGN KEY (MTDcodigo) REFERENCES cnfMTDpMetodologia
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfMNTpMetodologiaEntregable'))
    CREATE TABLE cnfMNTpMetodologiaEntregable (
		MNTcodigo integer identity(1,1),
		MEFcodigo int,
		MNTnombre varchar(250) unique,
		MNTdescripcion varchar(100),
		MNTfecha_Registro date,
		MNTnomenclatura varchar(250),
		MNTestado varchar(250)
		PRIMARY KEY (MNTcodigo),
		FOREIGN KEY (MEFcodigo) REFERENCES cnfMEFpMetodologiaFase
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfEREpEntregableRelacion'))
    CREATE TABLE cnfEREpEntregableRelacion (
		EREcodigo integer identity(1,1),
		MNTcodigo_Origen int,
		MNTcodigo_Relacion int,
		PRIMARY KEY (EREcodigo),
		FOREIGN KEY (MNTcodigo_Origen) REFERENCES cnfMNTpMetodologiaEntregable,
		FOREIGN KEY (MNTcodigo_Relacion) REFERENCES cnfMNTpMetodologiaEntregable
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfUSUpUsuario'))
    CREATE TABLE cnfUSUpUsuario (
		USUcodigo integer identity(1,1),
		USUdni char(8) unique,
		USUnombre varchar(250),
		USUapellido varchar(250),
		USUcorreo varchar(250),
		USUtelefono varchar(10),
		USUusuario varchar(8) unique,
		USUcontrasena varchar(8),
		USUnivel varchar(20),
		USUestado varchar(20),
		PRIMARY KEY (USUcodigo)
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfPRYpProyecto'))
    CREATE TABLE cnfPRYpProyecto (
		PRYcodigo integer identity(1,1),
		MTDcodigo int,
		USUcodigo int,
		PRYnombre varchar(250) unique,
		PRYdescripcion varchar(250),
		PRYfecha_Registro date,
		PRYestado varchar(250),
		PRIMARY KEY (PRYcodigo),
		FOREIGN KEY (MTDcodigo) REFERENCES cnfMTDpMetodologia,
		FOREIGN KEY (USUcodigo) REFERENCES cnfUSUpUsuario
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfPMIpProyectoMiembro'))
    CREATE TABLE cnfPMIpProyectoMiembro (
		PMIcodigo integer identity(1,1),
		PRYcodigo int,
		USUcodigo int,
		PMIestado varchar(250),
		PRIMARY KEY (PMIcodigo),
		FOREIGN KEY (PRYcodigo) REFERENCES cnfPRYpProyecto,
		FOREIGN KEY (USUcodigo) REFERENCES cnfUSUpUsuario
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfPMCpProyectoMiembroCargo'))
    CREATE TABLE cnfPMCpProyectoMiembroCargo (
		PMCcodigo int identity(1,1),
		PMIcodigo int,
		PMCcargo varchar(250),
		PRIMARY KEY (PMCcodigo),
		FOREIGN KEY (PMIcodigo) REFERENCES cnfPMIpProyectoMiembro
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfPLBpProyectoLineaBase'))
    CREATE TABLE cnfPLBpProyectoLineaBase (
		PLBcodigo integer identity(1,1),
		PRYcodigo int,
		MEFcodigo int,
		PLBfecha_LineaBase date,
		PLBestado varchar(250),
		PRIMARY KEY (PLBcodigo),
		FOREIGN KEY (PRYcodigo) REFERENCES cnfPRYpProyecto,
		FOREIGN KEY (MEFcodigo) REFERENCES cnfMEFpMetodologiaFase
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfPYEpProyectoEntregable'))
    CREATE TABLE cnfPYEpProyectoEntregable (
		PYEcodigo int identity(1,1),
		MEFcodigo int,
		PRYcodigo int,
		MNTcodigo int,
		PYEfecha_InicioFase date,
		PYEfecha_FinFase date,
		PRIMARY KEY (PYEcodigo),
		FOREIGN KEY (MEFcodigo) REFERENCES cnfMEFpMetodologiaFase,
		FOREIGN KEY (PRYcodigo) REFERENCES cnfPRYpProyecto,
		FOREIGN KEY (MNTcodigo) REFERENCES cnfMNTpMetodologiaEntregable
      )
go


if (not exists(select 1 from sys.tables where name = 'cnfPECpProyectoElementoConfiguracion'))
    CREATE TABLE cnfPECpProyectoElementoConfiguracion (
		PECcodigo integer identity(1,1),
		MEFcodigo int,
		PRYcodigo int,
		MNTcodigo int,
		PLBcodigo int,
		PEClocalizacion varchar(250),
		PECnombre varchar(250),
		PECdescripcion varchar(250),
		PECtipo varchar(250),
		PECestado varchar(250),
		PECestado_InOut varchar(250),
		PRIMARY KEY (PECcodigo),
		FOREIGN KEY (MEFcodigo) REFERENCES cnfMEFpMetodologiaFase,
		FOREIGN KEY (PRYcodigo) REFERENCES cnfPRYpProyecto,
		FOREIGN KEY (MNTcodigo) REFERENCES cnfMNTpMetodologiaEntregable,
		FOREIGN KEY (PLBcodigo) REFERENCES cnfPLBpProyectoLineaBase
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfPERpProyectoElementoRelacion'))
    CREATE TABLE cnfPERpProyectoElementoRelacion (
		PERcodigo integer identity(1,1),
		PECcodigo_Relacion int,
		PECcodigo_Origen int,
		PRIMARY KEY (PERcodigo),
		FOREIGN KEY (PECcodigo_Relacion) REFERENCES cnfPECpProyectoElementoConfiguracion,
		FOREIGN KEY (PECcodigo_Origen) REFERENCES cnfPECpProyectoElementoConfiguracion
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfPERpProyectoElementoRelacion'))
    CREATE TABLE cnfPERpProyectoElementoRelacion (
		PERcodigo integer identity(1,1),
		PECcodigo_Relacion int,
		PECcodigo_Origen int,
		PRIMARY KEY (PERcodigo),
		FOREIGN KEY (PECcodigo_Relacion) REFERENCES cnfPECpProyectoElementoConfiguracion,
		FOREIGN KEY (PECcodigo_Origen) REFERENCES cnfPECpProyectoElementoConfiguracion
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfEMEpEntregableMiembroEntregable'))
    CREATE TABLE cnfEMEpEntregableMiembroEntregable (
		EMEcodigo integer identity(1,1),
		PECcodigo int,
		PMIcodigo_Responsable int,
		PMIcodigo_Evaluador int,
		PRYcodigo int,
		MNTcodigo int,
		EMEfecha_Registro date,
		EMEfecha_Entrega date,
		PRIMARY KEY (EMEcodigo),
		FOREIGN KEY (PECcodigo) REFERENCES cnfPECpProyectoElementoConfiguracion,
		FOREIGN KEY (PMIcodigo_Responsable) REFERENCES cnfPMIpProyectoMiembro,
		FOREIGN KEY (PMIcodigo_Evaluador) REFERENCES cnfPMIpProyectoMiembro,
		FOREIGN KEY (PRYcodigo) REFERENCES cnfPRYpProyecto,
		FOREIGN KEY (MNTcodigo) REFERENCES cnfMNTpMetodologiaEntregable
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfEEMpEntregaEntregableMiembro'))
    CREATE TABLE cnfEEMpEntregaEntregableMiembro (
		EEMcodigo integer identity(1,1),
		EMEcodigo int,
		PECcodigo int,
		EEMfecha_Registro date,
		EEMversion varchar(30),
		EEMrevision varchar(30),
		EEMestado varchar(30),
		EEMentregable varchar(250),
		EEMfecha_Version date,
		PRIMARY KEY (EEMcodigo),
		FOREIGN KEY (EMEcodigo) REFERENCES cnfEMEpEntregableMiembroEntregable,
		FOREIGN KEY (PECcodigo) REFERENCES cnfPECpProyectoElementoConfiguracion
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfSOLpSolicitud'))
    CREATE TABLE cnfSOLpSolicitud (
		SOLcodigo integer identity(1,1),
		PRYcodigo int,
		PECcodigo int,
		MNTcodigo int,
		USUcodigo int,
		SOLsolicitud varchar(250),
		SOLestado int,
		SOLfecha_Registro date,
		SOLnivel varchar(250),
		PRIMARY KEY (SOLcodigo),
		FOREIGN KEY (PRYcodigo) REFERENCES cnfPRYpProyecto,
		FOREIGN KEY (PECcodigo) REFERENCES cnfPECpProyectoElementoConfiguracion,
		FOREIGN KEY (MNTcodigo) REFERENCES cnfMNTpMetodologiaEntregable,
		FOREIGN KEY (USUcodigo) REFERENCES cnfUSUpUsuario
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfSMCpSolicitudMiembroCambio'))
    CREATE TABLE cnfSMCpSolicitudMiembroCambio (
		SMCcodigo int identity(1,1),
		SOLcodigo int,
		PMIcodigo int,
		SMCfecha_EntregaCambio date,
		PRIMARY KEY (SMCcodigo),
		FOREIGN KEY (SOLcodigo) REFERENCES cnfSOLpSolicitud,
		FOREIGN KEY (PMIcodigo) REFERENCES cnfPMIpProyectoMiembro
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfSEVpSolicitudEvaluador'))
    CREATE TABLE cnfSEVpSolicitudEvaluador (
		SEVcodigo int identity(1,1),
		SOLcodigo int,
		PMIcodigo int,
		PRIMARY KEY (SEVcodigo),
		FOREIGN KEY (SOLcodigo) REFERENCES cnfSOLpSolicitud,
		FOREIGN KEY (PMIcodigo) REFERENCES cnfPMIpProyectoMiembro
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfSCCpSolicitudComiteCambio'))
    CREATE TABLE cnfSCCpSolicitudComiteCambio (
		SCCcodigo int identity(1,1),
		SOLcodigo int,
		PMIcodigo int,
		PRIMARY KEY (SCCcodigo),
		FOREIGN KEY (SOLcodigo) REFERENCES cnfSOLpSolicitud,
		FOREIGN KEY (PMIcodigo) REFERENCES cnfPMIpProyectoMiembro
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfSICpSolicitudInformeCambio'))
    CREATE TABLE cnfSICpSolicitudInformeCambio (
		SICcodigo integer identity(1,1),
		SOLcodigo int,
		SICinforme_Cambio varchar(250),
		SICcomentario varchar(250),
		SICfecha_Registro date,
		SICestado_Cambio varchar(20),
		PRIMARY KEY (SICcodigo),
		FOREIGN KEY (SOLcodigo) REFERENCES cnfSOLpSolicitud
      )
go

if (not exists(select 1 from sys.tables where name = 'cnfSIApSolicitudInformeAprobacion'))
    CREATE TABLE cnfSIApSolicitudInformeAprobacion (
		SIAcodigo integer identity(1,1),
		SICcodigo int,
		SOLcodigo int,
		SIAinforme_Aprobacion varchar(250),
		SICfecha_Registro date
		PRIMARY KEY (SIAcodigo),
		FOREIGN KEY (SICcodigo) REFERENCES cnfSICpSolicitudInformeCambio,
		FOREIGN KEY (SOLcodigo) REFERENCES cnfSOLpSolicitud
      )
go

-------------------------------Procedimientos Almacenados---------------------------------

-----Autor: Luis Mamani
-----Version: 1.0
-----Gestionar Metodologia
----Metodologia

create procedure usp_S_cnfMTDpMetodologia_CargarDatos
as
    select * from cnfMTDpMetodologia
go

create procedure usp_I_cnfMTDpMetodologia_Guardar
(
@MTDnombre varchar(250),
@MTDfecha_Registro date,
@MTDestado varchar(250)
)
as
    insert into cnfMTDpMetodologia (MTDnombre,MTDfecha_Registro,MTDestado) values(@MTDnombre, @MTDfecha_Registro, @MTDestado)
go

create procedure usp_S_cnfMTDpMetodologia_Buscar
(
@MTDparametro varchar(250)
)
as
    select * from cnfMTDpMetodologia where MTDcodigo like @MTDparametro OR MTDnombre like @MTDparametro
go

create procedure usp_U_cnfMTDpMetodologia_Modificar
(
@MTDcodigo int,
@MTDnombre varchar(250),
@MTDfecha_Registro date,
@MTDestado varchar(250)
)
as
    update cnfMTDpMetodologia set MTDnombre = @MTDnombre, MTDfecha_Registro = @MTDfecha_Registro, MTDestado = @MTDestado where MTDcodigo = @MTDcodigo
go

----Fase

create procedure usp_S_cnfMEFpMetodologiaFase_CargarDatos
as
    select cnfMEFpMetodologiaFase.MEFcodigo, cnfMTDpMetodologia.MTDnombre, cnfMEFpMetodologiaFase.MEFnombre, cnfMEFpMetodologiaFase.MEFfecha_Registro, cnfMEFpMetodologiaFase.MEFestado from cnfMEFpMetodologiaFase inner join cnfMTDpMetodologia on cnfMEFpMetodologiaFase.MTDcodigo = cnfMTDpMetodologia.MTDcodigo
go

create procedure usp_S_cnfMEFpMetodologiaFase_ComboMetodologia
as
    select * from cnfMTDpMetodologia where MTDestado='Activo'
go

create procedure usp_I_cnfMEFpMetodologiaFase_Guardar
(
@MTDcodigo int,
@MEFnombre varchar(250),
@MEFfecha_Registro date,
@MEFestado varchar(250)
)
as
    insert into cnfMEFpMetodologiaFase (MTDcodigo,MEFnombre,MEFfecha_Registro,MEFestado) values(@MTDcodigo, @MEFnombre, @MEFfecha_Registro,@MEFestado)
go

create procedure usp_S_cnfMEFpMetodologiaFase_Buscar
(
@MEFparametro varchar(250)
)
as
    select * from cnfMEFpMetodologiaFase where MEFcodigo like @MEFparametro OR MEFnombre like @MEFparametro
go

create procedure usp_U_cnfMEFpMetodologiaFase_Modificar
(
@MEFcodigo int,
@MTDcodigo int,
@MEFnombre varchar(250),
@MEFfecha_Registro date,
@MEFestado varchar(250)
)
as
    update cnfMEFpMetodologiaFase set MTDcodigo = @MTDcodigo, MEFnombre = @MEFnombre, MEFfecha_Registro = @MEFfecha_Registro, MEFestado = @MEFestado where MEFcodigo = @MEFcodigo
go

----Entregable

create procedure usp_S_cnfMNTpMetodologiaEntregable_CargarDatosPrincipal
as
    select MNT.MNTcodigo, MEF.MEFcodigo, MTD.MTDcodigo, MEF.MEFnombre, MTD.MTDnombre, MNTnombre, MNTdescripcion, MNTfecha_Registro, MNTnomenclatura, MNTestado
	from cnfMNTpMetodologiaEntregable as MNT
	inner join cnfMEFpMetodologiaFase as MEF on 
	MNT.MEFcodigo = MEF.MEFcodigo inner join
	cnfMTDpMetodologia as MTD on MEF.MTDcodigo = MTD.MTDcodigo
go

create procedure usp_S_cnfMNTpMetodologiaEntregable_ComboMetodologia
as
    select * from cnfMTDpMetodologia where MTDestado='Activo'
go

create procedure usp_S_cnfMNTpMetodologiaEntregable_ComboFase
(
@MNTparametro int
)
as
    select * from cnfMEFpMetodologiaFase where MTDcodigo = @MNTparametro
go

create procedure usp_I_cnfMNTpMetodologiaEntregable_GuardarPrincipal
(
@MEFcodigo int,
@MNTnombre varchar(250),
@MNTdescripcion varchar(100),
@MNTfecha_Registro date,
@MNTnomenclatura varchar(250),
@MNTestado varchar(250)
)
as
    insert into cnfMNTpMetodologiaEntregable (MEFcodigo,MNTnombre,MNTdescripcion,MNTfecha_Registro,MNTnomenclatura,MNTestado) values(@MEFcodigo, @MNTnombre, @MNTdescripcion,@MNTfecha_Registro,@MNTnomenclatura,@MNTestado)
go

create procedure usp_S_cnfMNTpMetodologiaEntregable_Buscar
(
@MNTparametro varchar(250)
)
as
	select MNT.MNTcodigo, MEF.MEFcodigo, MTD.MTDcodigo, MEF.MEFnombre, MTD.MTDnombre, MNTnombre, MNTdescripcion, MNTfecha_Registro, MNTnomenclatura, MNTestado
	from cnfMNTpMetodologiaEntregable as MNT
	inner join cnfMEFpMetodologiaFase as MEF on 
	MNT.MEFcodigo = MEF.MEFcodigo inner join
	cnfMTDpMetodologia as MTD on MEF.MTDcodigo = MTD.MTDcodigo
	where MNT.MNTcodigo like @MNTparametro OR MNT.MNTnombre like @MNTparametro
go

create procedure usp_U_cnfMNTpMetodologiaEntregable_Modificar
(
@MNTcodigo int,
@MEFcodigo int,
@MNTnombre varchar(250),
@MNTdescripcion varchar(100),
@MNTfecha_Registro date,
@MNTnomenclatura varchar(250),
@MNTestado varchar(250)
)
as
    update cnfMNTpMetodologiaEntregable set MEFcodigo = @MEFcodigo, MNTnombre = @MNTnombre, MNTdescripcion = @MNTdescripcion, MNTfecha_Registro = @MNTfecha_Registro, MNTnomenclatura = @MNTnomenclatura, MNTestado = @MNTestado where MNTcodigo = @MNTcodigo
go

create procedure usp_S_cnfMNTpMetodologiaEntregable_CargarDatosSecundario
(
@MNTparametro int
)
as
    select * from cnfMNTpMetodologiaEntregable where MEFcodigo = @MNTparametro
go

create procedure usp_S_cnfEREpEntregableRelacion_CargarDatosRelacion
(
@EREparametro int
)
as
    select * from cnfEREpEntregableRelacion inner join cnfMNTpMetodologiaEntregable
	on cnfEREpEntregableRelacion.MNTcodigo_Origen = cnfMNTpMetodologiaEntregable.MNTcodigo where MNTcodigo_Origen = @EREparametro OR MNTcodigo_Relacion = @EREparametro
go

create procedure usp_S_cnfEREpEntregableRelacion_CargarDatosSecundario
(
@EREparametro int
)
as
	select cnfMNTpMetodologiaEntregable.MNTcodigo, cnfMNTpMetodologiaEntregable.MEFcodigo, cnfMTDpMetodologia.MTDcodigo, cnfMEFpMetodologiaFase.MEFnombre, cnfMTDpMetodologia.MTDnombre, cnfMNTpMetodologiaEntregable.MNTnombre, cnfMNTpMetodologiaEntregable.MNTdescripcion, cnfMNTpMetodologiaEntregable.MNTfecha_Registro, cnfMNTpMetodologiaEntregable.MNTnomenclatura, cnfMNTpMetodologiaEntregable.MNTestado from cnfMNTpMetodologiaEntregable inner join cnfMEFpMetodologiaFase
	on cnfMNTpMetodologiaEntregable.MEFcodigo = cnfMEFpMetodologiaFase.MEFcodigo
	inner join cnfMTDpMetodologia on
	cnfMEFpMetodologiaFase.MTDcodigo = cnfMTDpMetodologia.MTDcodigo where cnfMTDpMetodologia.MTDcodigo 
	in (select cnfMTDpMetodologia.MTDcodigo from cnfMNTpMetodologiaEntregable inner join cnfMEFpMetodologiaFase
	on cnfMNTpMetodologiaEntregable.MEFcodigo = cnfMEFpMetodologiaFase.MEFcodigo where cnfMNTpMetodologiaEntregable.MNTcodigo = @EREparametro)
go


create procedure usp_D_cnfEREpEntregableRelacion_Borrar
(
@MNTcodigo_Origen int,
@MNTcodigo_Relacion int
)
as
    delete from cnfEREpEntregableRelacion where MNTcodigo_Origen = @MNTcodigo_Origen AND MNTcodigo_Relacion = @MNTcodigo_Relacion
go

create procedure usp_I_cnfEREpEntregableRelacion_GuardarDatosSecundario
(
@MNTcodigo_Origen int,
@MNTcodigo_Relacion int
)
as
    insert cnfEREpEntregableRelacion (MNTcodigo_Origen, MNTcodigo_Relacion) values (@MNTcodigo_Origen,@MNTcodigo_Relacion)
go


-----Autor: Percy Rodriguez
-----Version: 1.0
-----Gestionar Usuario

create procedure usp_S_cnfUSUpUsuario_CargarDatos
as
    select * from cnfUSUpUsuario
go

create procedure usp_I_cnfUSUpUsuario_Guardar
(
@USUdni char(8),
@USUnombre varchar(250),
@USUapellido varchar(250),
@USUcorreo varchar(250),
@USUtelefono varchar(250),
@USUusuario varchar(8),
@USUcontrasena varchar(8),
@USUnivel varchar(20),
@USUestado varchar(20)
)
as
    insert into cnfUSUpUsuario (USUdni,USUnombre,USUapellido,USUcorreo,USUtelefono,USUusuario,USUcontrasena,USUnivel,USUestado) 
	values(@USUdni, @USUnombre, @USUapellido,@USUcorreo,@USUtelefono,@USUusuario,@USUcontrasena,@USUnivel,@USUestado)
go

create procedure usp_S_cnfUSUpUsuario_Buscar
(
@USUparametro varchar(250)
)
as
    select * from cnfUSUpUsuario where USUcodigo like @USUparametro OR USUusuario like @USUparametro
go

create procedure usp_U_cnfUSUpUsuario_Modificar
(
@USUcodigo int,
@USUdni char(8),
@USUnombre varchar(250),
@USUapellido varchar(250),
@USUcorreo varchar(250),
@USUtelefono varchar(250),
@USUusuario varchar(8),
@USUcontrasena varchar(8),
@USUnivel varchar(20),
@USUestado varchar(20)
)
as
    update cnfUSUpUsuario set USUdni = @USUdni, USUnombre = @USUnombre, USUapellido = @USUapellido,USUcorreo=@USUcorreo,USUtelefono=@USUtelefono,USUusuario=@USUusuario, USUcontrasena=@USUcontrasena,USUnivel=@USUnivel,USUestado=@USUestado where USUcodigo = @USUcodigo
go

---Iniciar Sesion




-----Autor: Luis Mamani
-----Version: 1.0
-----Gestionar Proyecto
----Proyecto

create procedure usp_S_cnfPRYpProyecto_CargarDatos
(
@USUcodigo int
)
as
    select PRY.PRYcodigo, MTD.MTDcodigo, MTD.MTDnombre, USU.USUcodigo, USU.USUnombre, USU.USUapellido, PRY.PRYnombre, PRY.PRYdescripcion, PRY.PRYfecha_Registro, PRY.PRYestado 
	from cnfPRYpProyecto as PRY
	inner join cnfMTDpMetodologia as MTD on 
	PRY.MTDcodigo = MTD.MTDcodigo inner join
	cnfUSUpUsuario as USU on PRY.USUcodigo = USU.USUcodigo
	where PRY.USUcodigo = @USUcodigo
go

create procedure usp_S_cnfPRYpProyecto_ComboMetodologia
as
    select * from cnfMTDpMetodologia where MTDestado='Activo'
go

create procedure usp_S_cnfPRYpProyecto_Buscar
(
@EREparametro int
)
as
    select PRY.PRYcodigo, MTD.MTDcodigo, MTD.MTDnombre, USU.USUcodigo, USU.USUnombre, USU.USUapellido, PRY.PRYnombre, PRY.PRYdescripcion, PRY.PRYfecha_Registro, PRY.PRYestado 
	from cnfPRYpProyecto as PRY
	inner join cnfMTDpMetodologia as MTD on 
	PRY.MTDcodigo = MTD.MTDcodigo inner join
	cnfUSUpUsuario as USU on PRY.USUcodigo = USU.USUcodigo
	where PRY.PRYcodigo = @EREparametro
go

create procedure usp_S_cnfPRYpProyecto_ObtenerUsuario
(
@EREparametro int,
@EREnombreproyecto varchar(250)
)
as
    select * 
	from cnfUSUpUsuario as USU
	inner join cnfPRYpProyecto as PRY on 
	PRY.USUcodigo = USU.USUcodigo
	where PRY.USUcodigo = @EREparametro AND PRY.PRYnombre = @EREnombreproyecto
go

create procedure usp_S_cnfPRYpProyecto_ObtenerFase
(
@EREparametro int,
@EREnombreproyecto varchar(250)
)
as
    select * 
	from cnfMEFpMetodologiaFase as MEF
	inner join cnfPRYpProyecto as PRY on 
	PRY.MTDcodigo = MEF.MTDcodigo
	where PRY.USUcodigo = @EREparametro AND PRY.PRYnombre = @EREnombreproyecto
go

create procedure usp_I_cnfPRYpProyecto_Guardar
(
@MTDcodigo int,
@USUcodigo int,
@PRYnombre varchar(250),
@PRYdescripcion varchar(250),
@PRYfecha_Registro date,
@PRYestado varchar(250)
)
as
    insert into cnfPRYpProyecto (MTDcodigo,USUcodigo,PRYnombre,PRYdescripcion,PRYfecha_Registro,PRYestado) 
	values(@MTDcodigo, @USUcodigo, @PRYnombre,@PRYdescripcion,@PRYfecha_Registro,@PRYestado)
go

create procedure usp_U_cnfPRYpProyecto_Modificar
(
@PRYcodigo int,
@MTDcodigo int,
@USUcodigo int,
@PRYnombre varchar(250),
@PRYdescripcion varchar(250),
@PRYfecha_Registro date,
@PRYestado varchar(250)
)
as
    update cnfPRYpProyecto set MTDcodigo = @MTDcodigo, USUcodigo = @USUcodigo, PRYnombre = @PRYnombre, PRYdescripcion=@PRYdescripcion,PRYfecha_Registro=@PRYfecha_Registro,PRYestado=@PRYestado where PRYcodigo = @PRYcodigo
go

----Proyecto Entregable

create procedure usp_S_cnfPRYpProyectoEntregable_ComboProyecto
(
@EREparametro int
)
as
    select PRY.PRYcodigo, MTD.MTDcodigo, MTD.MTDnombre, USU.USUcodigo, USU.USUnombre, USU.USUapellido, PRY.PRYnombre, PRY.PRYdescripcion, PRY.PRYfecha_Registro, PRY.PRYestado 
	from cnfPRYpProyecto as PRY
	inner join cnfMTDpMetodologia as MTD on 
	PRY.MTDcodigo = MTD.MTDcodigo inner join
	cnfUSUpUsuario as USU on PRY.USUcodigo = USU.USUcodigo
	where PRY.USUcodigo = @EREparametro AND PRY.PRYestado = 'Activo'
go

create procedure usp_S_cnfPRYpProyectoEntregable_Buscar
(
@EREparametro int
)
as
	select * from cnfPRYpProyecto where PRYcodigo = @EREparametro
go

create procedure usp_S_cnfPRYpProyectoEntregable_CargarDatos
(
@EREparametro int
)
as
    select MTD.MTDcodigo, MTD.MTDnombre, MEF.MEFcodigo, MEF.MEFnombre, MNT.MNTcodigo, MNT.MNTnombre 
	from cnfMNTpMetodologiaEntregable as MNT inner join	
	cnfMEFpMetodologiaFase as MEF on
	MNT.MEFcodigo =  MEF.MEFcodigo
	inner join cnfMTDpMetodologia as MTD on
	MTD.MTDcodigo = MEF.MTDcodigo
	where MTD.MTDestado = 'Activo' AND MEF.MEFestado = 'Activo' AND MNT.MNTestado = 'Activo' AND MTD.MTDcodigo = @EREparametro
go

create procedure usp_S_cnfPRYpProyectoEntregable_CargarDatosRelacion
(
@EREparametro int
)
as
    select * from cnfPYEpProyectoEntregable where PRYcodigo = @EREparametro
go

create procedure usp_S_cnfPRYpProyectoEntregable_ListarFase
(
@EREparametro int
)
as
    select * from cnfMEFpMetodologiaFase where MTDcodigo = @EREparametro AND MEFestado = 'Activo'
go

create procedure usp_D_cnfPRYpProyectoEntregable_Borrar
(
@EREparametro int
)
as
	delete from cnfPYEpProyectoEntregable where PRYcodigo = @EREparametro 
go

create procedure usp_I_cnfPRYpProyectoEntregable_Guardar
(
@MEFcodigo int,
@PRYcodigo int,
@MNTcodigo int,
@PYEfecha_InicioFase date,
@PYEfecha_FinFase date
)
as
    insert into cnfPYEpProyectoEntregable values(@MEFcodigo, @PRYcodigo, @MNTcodigo,@PYEfecha_InicioFase,@PYEfecha_FinFase)
go

----Proyecto Miembro Proyecto

create procedure usp_S_cnfPMIpProyectoMiembro_ComboProyecto
(
@EREparametro int
)
as
    select *
	from cnfPRYpProyecto as PRY
	inner join cnfUSUpUsuario as USU on
	PRY.USUcodigo = USU.USUcodigo
	where PRY.USUcodigo = @EREparametro
go

create procedure usp_S_cnfPMIpProyectoMiembro_CargarDatos
(
@EREparametro int
)
as
    select *
	from cnfPMIpProyectoMiembro as PMI
	inner join cnfPRYpProyecto as PRY on
	PMI.PRYcodigo = PRY.PRYcodigo
	where PRY.PRYcodigo = @EREparametro
go

create procedure usp_S_cnfPMIpProyectoMiembro_CargoMiembro
(
@EREparametro int
)
as
    select *
	from cnfPMCpProyectoMiembroCargo as PMC
	inner join cnfPMIpProyectoMiembro as PMI on
	PMC.PMIcodigo = PMI.PMIcodigo
	inner join cnfPRYpProyecto as PRY on
	PMI.PRYcodigo = PRY.PRYcodigo
	where PRY.PRYcodigo = @EREparametro
go

create procedure usp_S_cnfPMIpProyectoMiembro_CargarUsuario
as
    select *
	from cnfUSUpUsuario
	where USUnivel != 'Jefe de Proyecto' AND USUnivel != 'Administrador'
go

create procedure usp_D_cnfPMIpProyectoMiembro_BorrarPrincipal
(
@EREparametro int
)
as
    delete from cnfPMIpProyectoMiembro where PRYcodigo = @EREparametro 
go

create procedure usp_D_cnfPMIpProyectoMiembro_BorrarSecundario
(
@EREparametro int
)
as
    delete from cnfPMCpProyectoMiembroCargo where PMIcodigo in (select PMIcodigo from cnfPMIpProyectoMiembro where PRYcodigo = @EREparametro) 
go

create procedure usp_I_cnfPMIpProyectoMiembro_GuardarPrincipal
(
@PRYcodigo int,
@USUcodigo int,
@PMIestado varchar(250)
)
as
    insert into cnfPMIpProyectoMiembro values (@PRYcodigo,@USUcodigo,@PMIestado)
go

create procedure usp_S_cnfPMIpProyectoMiembro_ObtenerUltimoGuardadoPrincipal
as
    declare @EREultimo int
	select @EREultimo = max(PMIcodigo) from cnfPMIpProyectoMiembro
	select * from cnfPMIpProyectoMiembro where PMIcodigo = @EREultimo
go

create procedure usp_I_cnfPMIpProyectoMiembro_GuardarSecundario
(
@PMIcodigo int,
@PMCcargo varchar(250)
)
as
    insert into cnfPMCpProyectoMiembroCargo values (@PMIcodigo,@PMCcargo)
go

----Proyecto Linea Base

create procedure usp_S_cnfPLBpProyectoLineaBase_CargarDatos
(
@EREparametro int
)
as
    select PLB.PLBcodigo, PRY.PRYcodigo, PRY.PRYnombre, MEF.MEFcodigo, MEF.MEFnombre, PLB.PLBfecha_LineaBase, PLB.PLBestado
	from cnfPLBpProyectoLineaBase as PLB inner join	
	cnfPRYpProyecto as PRY on
	PLB.PRYcodigo =  PRY.PRYcodigo
	inner join cnfMEFpMetodologiaFase as MEF on
	PLB.MEFcodigo = MEF.MEFcodigo
	inner join cnfUSUpUsuario as USU on
	PRY.USUcodigo = USU.USUcodigo
	where PRY.USUcodigo = @EREparametro
go

create procedure usp_S_cnfPLBpProyectoLineaBase_ComboProyecto
(
@EREparametro int
)
as
    select *
	from cnfPRYpProyecto as PRY
	inner join cnfUSUpUsuario as USU on 
	PRY.USUcodigo = USU.USUcodigo
	where PRY.USUcodigo = @EREparametro AND PRY.PRYestado = 'Activo'
go

create procedure usp_S_cnfPLBpProyectoLineaBase_ComboFase
(
@EREparametro int
)
as
    select * from cnfMEFpMetodologiaFase as MEF
	inner join cnfMTDpMetodologia as MTD on
	MEF.MTDcodigo = MTD.MTDcodigo
	inner join cnfPRYpProyecto as PRY on
	MTD.MTDcodigo = PRY.MTDcodigo where PRY.PRYcodigo = @EREparametro AND MEF.MEFestado = 'Activo'
go

create procedure usp_S_cnfPLBpProyectoLineaBase_Buscar
(
@EREparametro int
)
as
	select * from cnfPLBpProyectoLineaBase where PLBcodigo = @EREparametro
go

create procedure usp_I_cnfPLBpProyectoLineaBase_Guardar
(
@PRYcodigo int,
@MEFcodigo int,
@PLBfecha_LineaBase date,
@PLBestado varchar(20)
)
as
    insert into cnfPLBpProyectoLineaBase values(@PRYcodigo, @MEFcodigo, @PLBfecha_LineaBase,@PLBestado)
go

create procedure usp_U_cnfPLBpProyectoLineaBase_Modificar
(
@PLBcodigo int,
@PRYcodigo int,
@MEFcodigo int,
@PLBfecha_LineaBase date,
@PLBestado varchar(20)
)
as
    update cnfPLBpProyectoLineaBase set PRYcodigo = @PRYcodigo, MEFcodigo = @MEFcodigo, PLBfecha_LineaBase = @PLBfecha_LineaBase, PLBestado=@PLBestado where PLBcodigo = @PLBcodigo
go

----Proyecto Elemento Configuracion

create procedure usp_S_cnfPECpProyectoElementoConfiguracion_CargarDatosPrincipal
(
@EREparametro int
)
as
	select PEC.PECcodigo, MEF.MEFcodigo, MEF.MEFnombre, PRY.PRYcodigo, PRY.PRYnombre, MNT.MNTcodigo, MNT.MNTnombre, PLB.PLBcodigo, PLB.PLBfecha_LineaBase, PEC.PEClocalizacion, PEC.PECnombre, PEC.PECdescripcion, PEC.PECtipo, PEC.PECestado, PEC.PECestado_InOut
	from cnfPECpProyectoElementoConfiguracion as PEC
	inner join cnfMNTpMetodologiaEntregable as MNT on
	PEC.MNTcodigo = MNT.MNTcodigo
	inner join cnfMEFpMetodologiaFase as MEF on
	PEC.MEFcodigo = MEF.MEFcodigo
	inner join cnfPLBpProyectoLineaBase as PLB on
	PEC.PLBcodigo = PLB.PLBcodigo
	inner join cnfPRYpProyecto as PRY on
	PEC.PRYcodigo = PRY.PRYcodigo
	inner join cnfUSUpUsuario as USU on
	PRY.USUcodigo = USU.USUcodigo
	where PRY.USUcodigo = @EREparametro
go

create procedure usp_S_cnfPECpProyectoElementoConfiguracion_ComboProyecto
(
@EREparametro int
)
as
    select * from cnfPRYpProyecto where PRYestado='Activo' AND USUcodigo = @EREparametro
go

create procedure usp_S_cnfPECpProyectoElementoConfiguracion_ComboFase
(
@EREparametro int
)
as
    select * from cnfMEFpMetodologiaFase
	inner join cnfPRYpProyecto on
	cnfMEFpMetodologiaFase.MTDcodigo = cnfPRYpProyecto.MTDcodigo
	where cnfPRYpProyecto.PRYcodigo = @EREparametro
go

create procedure usp_I_cnfPECpProyectoElementoConfiguracion_GuardarPrincipal
(
@MEFcodigo int,
@PRYcodigo int,
@MNTcodigo int,
@PLBcodigo int,
@PEClocalizacion varchar(250),
@PECnombre varchar(250),
@PECdescripcion varchar(250),
@PECtipo varchar(250),
@PECestado varchar(250),
@PECestado_InOut varchar(250)
)
as
    insert into cnfPECpProyectoElementoConfiguracion values(@MEFcodigo, @PRYcodigo, @MNTcodigo,@PLBcodigo,@PEClocalizacion,@PECnombre,@PECdescripcion,@PECtipo,@PECestado,@PECestado_InOut)
go

create procedure usp_S_cnfPECpProyectoElementoConfiguracion_Buscar
(
@EREparametro int
)
as
	select PEC.PECcodigo, MEF.MEFcodigo, MEF.MEFnombre, PRY.PRYcodigo, PRY.PRYnombre, MNT.MNTcodigo, MNT.MNTnombre, PLB.PLBcodigo, PLB.PLBfecha_LineaBase, PEC.PEClocalizacion, PEC.PECnombre, PEC.PECdescripcion, PEC.PECtipo, PEC.PECestado, PEC.PECestado_InOut
	from cnfPECpProyectoElementoConfiguracion as PEC
	inner join cnfMEFpMetodologiaFase as MEF on
	PEC.MEFcodigo = MEF.MEFcodigo
	inner join cnfMNTpMetodologiaEntregable as MNT on
	MEF.MEFcodigo = MNT.MEFcodigo
	inner join cnfPLBpProyectoLineaBase as PLB on
	MEF.MEFcodigo = PLB.MEFcodigo
	inner join cnfPRYpProyecto as PRY on
	PEC.PRYcodigo = PRY.PRYcodigo
	inner join cnfUSUpUsuario as USU on
	PRY.USUcodigo = USU.USUcodigo
	where PEC.PECcodigo = @EREparametro
go

create procedure usp_S_cnfPECpProyectoElementoConfiguracion_ComboLineaBase
(
@EREparametro int
)
as
    select * from cnfPLBpProyectoLineaBase where PLBestado='Activo' AND MEFcodigo = @EREparametro
go

create procedure usp_S_cnfPECpProyectoElementoConfiguracion_ComboEntregable
(
@EREparametro int
)
as
    select * from cnfMNTpMetodologiaEntregable where  MNTestado='Activo' AND MEFcodigo = @EREparametro
go

create procedure usp_U_cnfPECpProyectoElementoConfiguracion_Modificar
(
@PECcodigo int,
@MEFcodigo int,
@PRYcodigo int,
@MNTcodigo int,
@PLBcodigo int,
@PEClocalizacion varchar(250),
@PECnombre varchar(250),
@PECdescripcion varchar(250),
@PECtipo varchar(250),
@PECestado varchar(250),
@PECestado_InOut varchar(250)
)
as
    update cnfPECpProyectoElementoConfiguracion set MEFcodigo = @MEFcodigo, PRYcodigo = @PRYcodigo, MNTcodigo = @MNTcodigo, PLBcodigo = @PLBcodigo, PEClocalizacion = @PEClocalizacion, PECnombre = @PECnombre, PECdescripcion = @PECdescripcion, PECtipo = @PECtipo, PECestado = @PECestado, PECestado_InOut = @PECestado_InOut where PECcodigo = @PECcodigo
go

create procedure usp_S_cnfPERpProyectoElementoRelacion_CargarDatosRelacion
(
@EREparametro int
)
as
    select * from cnfPERpProyectoElementoRelacion inner join cnfPECpProyectoElementoConfiguracion
	on cnfPERpProyectoElementoRelacion.PECcodigo_Origen = cnfPECpProyectoElementoConfiguracion.PECcodigo where PECcodigo_Origen = @EREparametro OR PECcodigo_Relacion = @EREparametro
go

create procedure usp_S_cnfPECpProyectoElementoConfiguracion_CargarDatosSecundario
(
@EREparametro int,
@PRYcodigo int
)
as
	select PEC.PECcodigo, MEF.MEFcodigo, MEF.MEFnombre, PRY.PRYcodigo, PRY.PRYnombre, MNT.MNTcodigo, MNT.MNTnombre, PLB.PLBcodigo, PLB.PLBfecha_LineaBase, PEC.PEClocalizacion, PEC.PECnombre, PEC.PECdescripcion, PEC.PECtipo, PEC.PECestado, PEC.PECestado_InOut
	from cnfPECpProyectoElementoConfiguracion as PEC
	inner join cnfMNTpMetodologiaEntregable as MNT
	on PEC.MNTcodigo = MNT.MNTcodigo
	inner join cnfMEFpMetodologiaFase as MEF
	on MEF.MEFcodigo = MNT.MEFcodigo
	inner join cnfPLBpProyectoLineaBase as PLB
	on PLB.MEFcodigo = MEF.MEFcodigo
	inner join cnfPRYpProyecto as PRY
	on PRY.PRYcodigo = PEC.PRYcodigo
	where PRY.PRYcodigo = @PRYcodigo AND MEF.MEFcodigo 
	in (select cnfPECpProyectoElementoConfiguracion.MEFcodigo from cnfPECpProyectoElementoConfiguracion inner join cnfMEFpMetodologiaFase
	on cnfPECpProyectoElementoConfiguracion.MEFcodigo = cnfMEFpMetodologiaFase.MEFcodigo where cnfPECpProyectoElementoConfiguracion.PECcodigo = @EREparametro)
go

create procedure usp_S_cnfPECpProyectoElementoConfiguracion_ObtenerProyecto
(
@EREparametro int
)
as
	select * from cnfPRYpProyecto inner join cnfPECpProyectoElementoConfiguracion
	on cnfPRYpProyecto.PRYcodigo = cnfPECpProyectoElementoConfiguracion.PRYcodigo
	where cnfPECpProyectoElementoConfiguracion.PECcodigo = @EREparametro
go

create procedure usp_D_cnfPERpProyectoElementoRelacion_Borrar
(
@PECcodigo_Origen int,
@PECcodigo_Relacion int
)
as
    delete from cnfPERpProyectoElementoRelacion where PECcodigo_Origen = @PECcodigo_Origen AND PECcodigo_Relacion = @PECcodigo_Relacion
go

create procedure usp_I_cnfPERpProyectoElementoRelacion_GuardarDatosSecundario
(
@PECcodigo_Origen int,
@PECcodigo_Relacion int
)
as
    insert cnfPERpProyectoElementoRelacion(PECcodigo_Origen, PECcodigo_Relacion) values (@PECcodigo_Origen,@PECcodigo_Relacion)
go

-----Autor: Luis Mamani
-----Version: 1.0
-----Visualizar Proyecto

create procedure usp_S_cnfPRYpProyectoEntregable_ObtenerNivelUsuario
(
@USUcodigo int
)
as
	select * from cnfUSUpUsuario where USUcodigo = @USUcodigo
go

create procedure usp_S_cnfPRYpProyectoEntregable_ListarProyecto
(
@USUcodigo int
)
as
	select PRY.PRYcodigo, MTD.MTDcodigo, MTD.MTDnombre, USU.USUcodigo, USU.USUnombre, USU.USUapellido, PRY.PRYnombre, PRY.PRYdescripcion, PRY.PRYfecha_Registro, PRY.PRYestado 
	from cnfPRYpProyecto as PRY
	inner join cnfMTDpMetodologia as MTD on 
	PRY.MTDcodigo = MTD.MTDcodigo inner join
	cnfUSUpUsuario as USU on PRY.USUcodigo = USU.USUcodigo
	where PRY.USUcodigo = @USUcodigo
go

create procedure usp_S_cnfPRYpProyectoEntregable_ListarTodoProyecto
as
	select PRY.PRYcodigo, MTD.MTDcodigo, MTD.MTDnombre, USU.USUcodigo, USU.USUnombre, USU.USUapellido, PRY.PRYnombre, PRY.PRYdescripcion, PRY.PRYfecha_Registro, PRY.PRYestado 
	from cnfPRYpProyecto as PRY
	inner join cnfMTDpMetodologia as MTD on 
	PRY.MTDcodigo = MTD.MTDcodigo inner join
	cnfUSUpUsuario as USU on PRY.USUcodigo = USU.USUcodigo
go

create procedure usp_S_cnfPRYpProyectoEntregable_ObtenerProyecto
(
@PRYcodigo int
)
as
	select PRY.PRYcodigo, MTD.MTDcodigo, MTD.MTDnombre, USU.USUcodigo, USU.USUnombre, USU.USUapellido, PRY.PRYnombre, PRY.PRYdescripcion, PRY.PRYfecha_Registro, PRY.PRYestado 
	from cnfPRYpProyecto as PRY
	inner join cnfMTDpMetodologia as MTD on 
	PRY.MTDcodigo = MTD.MTDcodigo inner join
	cnfUSUpUsuario as USU on PRY.USUcodigo = USU.USUcodigo
	where PRY.PRYcodigo = @PRYcodigo
go

create procedure usp_S_cnfPRYpProyectoEntregable_ListarMiembrosProyecto
(
	@PRYcodigo int
)
as
	select USU.USUcodigo, USU.USUdni, USU.USUnombre,USU.USUapellido, USU.USUcorreo, USU.USUtelefono, USU.USUusuario, USU.USUcontrasena, USU.USUnivel, USU.USUestado
	from cnfPMIpProyectoMiembro as PMI
	inner join cnfPRYpProyecto as PRY
	on PMI.PRYcodigo = PRY.PRYcodigo
	inner join cnfUSUpUsuario as USU on
	PMI.USUcodigo = USU.USUcodigo
	where PRY.PRYcodigo = @PRYcodigo
go


-----------IniciarSesion--------
-----Percy Rodriguez------------


Create procedure usp_S_cnfUSUpUsuario_IniciarSesion
(
@USUusuario varchar(8),
@USUcontrasena varchar(8)


)
as
select * from cnfUSUpUsuario where USUusuario=@USUusuario AND USUcontrasena=@USUcontrasena
go


create procedure usp_U_cnfUSUpUsuario_IniciarSesion
(
@USUcodigo int
)
as
update cnfUSUpUsuario set USUestado = 'Inactivo' where USUcodigo = @USUcodigo
go


exec usp_S_cnfUSUpUsuario_IniciarSesion 'aaguirre','123';




--update cnfUSUpUsuario set USUestado = 'Inactivo' where USUcodigo = 1


select * from cnfUSUpUsuario

select * from cnfPMIpProyectoMiembro

select * from cnfPMCpProyectoMiembroCargo
delete from cnfPERpProyectoElementoRelacion
delete from cnfPECpProyectoElementoConfiguracion
delete from cnfPYEpProyectoEntregable
select * from cnfPYEpProyectoEntregable

select * from cnfUSUpUsuario
select * from cnfPECpProyectoElementoConfiguracion

select * from cnfPRYpProyecto
select * from cnfMEFpMetodologiaFase
select * from cnfPLBpProyectoLineaBase

exec usp_S_cnfUSUpUsuario_Buscar '2';

