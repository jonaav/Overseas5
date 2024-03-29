
USE [DB_Overseas5]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/02/2020 6:11:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ambiente]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ambiente](
	[IdAmbiente] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [int] NOT NULL,
	[Aula] [nvarchar](max) NULL,
	[DescripcionAmbiente] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Ambiente] PRIMARY KEY CLUSTERED 
(
	[IdAmbiente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Apoderado]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apoderado](
	[IdApoderado] [int] IDENTITY(1,1) NOT NULL,
	[NombresApoderado] [nvarchar](max) NULL,
	[ApellidosApoderado] [nvarchar](max) NULL,
	[CorreoApoderado] [nvarchar](max) NULL,
 CONSTRAINT [PK_Apoderado] PRIMARY KEY CLUSTERED 
(
	[IdApoderado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asistencia]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistencia](
	[IdAsistencia] [int] IDENTITY(1,1) NOT NULL,
	[AsistenciaEstudiante] [int] NOT NULL,
	[IdEstudiante] [int] NOT NULL,
	[IdSesion] [int] NOT NULL,
 CONSTRAINT [PK_Asistencia] PRIMARY KEY CLUSTERED 
(
	[IdAsistencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[StatusUser] [int] NOT NULL,
	[IdPersona] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[IdCurso] [int] IDENTITY(1,1) NOT NULL,
	[FechaFin] [datetime2](7) NOT NULL,
	[FechaInicio] [datetime2](7) NOT NULL,
	[Idioma] [nvarchar](max) NULL,
	[Nivel] [nvarchar](max) NULL,
	[Programa] [nvarchar](max) NULL,
	[Estado] [int] NOT NULL,
	[Ciclo] [int] NOT NULL,
	[ModalidadEstudiantes] [nvarchar](max) NULL,
	[Detalle] [nvarchar](max) NULL,
	[IdTipoCurso] [int] NOT NULL,
	[IdDocente] [int] NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleApoderadoEstudiante]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleApoderadoEstudiante](
	[IdDetalleApodEst] [int] IDENTITY(1,1) NOT NULL,
	[IdEstudiante] [int] NOT NULL,
	[IdApoderado] [int] NOT NULL,
 CONSTRAINT [PK_DetalleApoderadoEstudiante] PRIMARY KEY CLUSTERED 
(
	[IdDetalleApodEst] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleDocenteEspecialidad]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleDocenteEspecialidad](
	[IdDetalleDocenteEspecialidad] [int] IDENTITY(1,1) NOT NULL,
	[IdDocente] [int] NOT NULL,
	[IdEspecialidad] [int] NOT NULL,
 CONSTRAINT [PK_DetalleDocenteEspecialidad] PRIMARY KEY CLUSTERED 
(
	[IdDetalleDocenteEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docente]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docente](
	[IdDocente] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [int] NOT NULL,
	[IdPersona] [int] NOT NULL,
 CONSTRAINT [PK_Docente] PRIMARY KEY CLUSTERED 
(
	[IdDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especialidad]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidad](
	[IdEspecialidad] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionEspecialidad] [nvarchar](max) NULL,
 CONSTRAINT [PK_Especialidad] PRIMARY KEY CLUSTERED 
(
	[IdEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[IdEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[ReferenciaEstudiante] [nvarchar](max) NULL,
	[PoseeApoderado] [int] NOT NULL,
	[IdPersona] [int] NOT NULL,
 CONSTRAINT [PK_Estudiante] PRIMARY KEY CLUSTERED 
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluacion]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluacion](
	[IdEvaluacion] [int] IDENTITY(1,1) NOT NULL,
	[CalificacionEvaluacion] [int] NOT NULL,
	[IdHistorialEvaluacion] [int] NOT NULL,
	[IdTipoEvaluacion] [int] NOT NULL,
 CONSTRAINT [PK_Evaluacion] PRIMARY KEY CLUSTERED 
(
	[IdEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialEvaluacion]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialEvaluacion](
	[IdHistorialEvaluacion] [int] IDENTITY(1,1) NOT NULL,
	[FeedbackHistorialEvaluacion] [nvarchar](max) NULL,
	[IdEstudiante] [int] NOT NULL,
	[IdCurso] [int] NOT NULL,
 CONSTRAINT [PK_HistorialEvaluacion] PRIMARY KEY CLUSTERED 
(
	[IdHistorialEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[IdHorario] [int] IDENTITY(1,1) NOT NULL,
	[Dia] [nvarchar](max) NULL,
	[HoraFin] [time](7) NOT NULL,
	[HoraInicio] [time](7) NOT NULL,
	[IdCurso] [int] NOT NULL,
	[IdAmbiente] [int] NOT NULL,
 CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED 
(
	[IdHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inscripcion]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscripcion](
	[IdInscripcion] [int] IDENTITY(1,1) NOT NULL,
	[EstadoInscripcion] [int] NOT NULL,
	[FechaInscripcion] [datetime2](7) NOT NULL,
	[IdEstudiante] [int] NOT NULL,
	[IdCurso] [int] NOT NULL,
 CONSTRAINT [PK_Inscripcion] PRIMARY KEY CLUSTERED 
(
	[IdInscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[DniPersona] [nvarchar](max) NULL,
	[NombresPersona] [nvarchar](max) NULL,
	[ApellidosPersona] [nvarchar](max) NULL,
	[CorreoPersona] [nvarchar](max) NULL,
	[FechaNacimientoPersona] [datetime2](7) NOT NULL,
	[TelefonoPersona] [nvarchar](max) NULL,
	[DireccionPersona] [nvarchar](max) NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sesion]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sesion](
	[IdSesion] [int] IDENTITY(1,1) NOT NULL,
	[AsistenciaDocente] [int] NOT NULL,
	[FechaSesion] [datetime2](7) NOT NULL,
	[NumeroSesion] [int] NOT NULL,
	[IdHorario] [int] NOT NULL,
 CONSTRAINT [PK_Sesion] PRIMARY KEY CLUSTERED 
(
	[IdSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCurso]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCurso](
	[IdTipoCurso] [int] IDENTITY(1,1) NOT NULL,
	[NombreCurso] [nvarchar](max) NULL,
 CONSTRAINT [PK_TipoCurso] PRIMARY KEY CLUSTERED 
(
	[IdTipoCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCursoTipoEvaluacion]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCursoTipoEvaluacion](
	[idTipoCursoTipoEvaluacion] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoCurso] [int] NOT NULL,
	[IdTipoEvaluacion] [int] NOT NULL,
 CONSTRAINT [PK_TipoCursoTipoEvaluacion] PRIMARY KEY CLUSTERED 
(
	[idTipoCursoTipoEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEvaluacion]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEvaluacion](
	[IdTipoEvaluacion] [int] IDENTITY(1,1) NOT NULL,
	[NombreEvaluacion] [nvarchar](max) NULL,
 CONSTRAINT [PK_TipoEvaluacion] PRIMARY KEY CLUSTERED 
(
	[IdTipoEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Traduccion]    Script Date: 3/02/2020 6:11:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traduccion](
	[IdTraduccion] [int] IDENTITY(1,1) NOT NULL,
	[ClienteTraduccion] [nvarchar](max) NULL,
	[TipoTraduccion] [nvarchar](max) NULL,
	[DetalleTraduccion] [nvarchar](max) NULL,
	[IdiomaOrigenTraduccion] [nvarchar](max) NULL,
	[IdiomaDestinoTraduccion] [nvarchar](max) NULL,
	[FechaTraduccion] [datetime2](7) NOT NULL,
	[EstadoTraduccion] [int] NOT NULL,
	[IdDocente] [int] NOT NULL,
 CONSTRAINT [PK_Traduccion] PRIMARY KEY CLUSTERED 
(
	[IdTraduccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Asistencia_IdEstudiante]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Asistencia_IdEstudiante] ON [dbo].[Asistencia]
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Asistencia_IdSesion]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Asistencia_IdSesion] ON [dbo].[Asistencia]
(
	[IdSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_IdPersona]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_IdPersona] ON [dbo].[AspNetUsers]
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Curso_IdDocente]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Curso_IdDocente] ON [dbo].[Curso]
(
	[IdDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Curso_IdTipoCurso]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Curso_IdTipoCurso] ON [dbo].[Curso]
(
	[IdTipoCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleApoderadoEstudiante_IdApoderado]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DetalleApoderadoEstudiante_IdApoderado] ON [dbo].[DetalleApoderadoEstudiante]
(
	[IdApoderado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleApoderadoEstudiante_IdEstudiante]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_DetalleApoderadoEstudiante_IdEstudiante] ON [dbo].[DetalleApoderadoEstudiante]
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleDocenteEspecialidad_IdDocente]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_DetalleDocenteEspecialidad_IdDocente] ON [dbo].[DetalleDocenteEspecialidad]
(
	[IdDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleDocenteEspecialidad_IdEspecialidad]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_DetalleDocenteEspecialidad_IdEspecialidad] ON [dbo].[DetalleDocenteEspecialidad]
(
	[IdEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Docente_IdPersona]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Docente_IdPersona] ON [dbo].[Docente]
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Estudiante_IdPersona]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Estudiante_IdPersona] ON [dbo].[Estudiante]
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Evaluacion_IdHistorialEvaluacion]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Evaluacion_IdHistorialEvaluacion] ON [dbo].[Evaluacion]
(
	[IdHistorialEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Evaluacion_IdTipoEvaluacion]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Evaluacion_IdTipoEvaluacion] ON [dbo].[Evaluacion]
(
	[IdTipoEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistorialEvaluacion_IdCurso]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_HistorialEvaluacion_IdCurso] ON [dbo].[HistorialEvaluacion]
(
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistorialEvaluacion_IdEstudiante]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_HistorialEvaluacion_IdEstudiante] ON [dbo].[HistorialEvaluacion]
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Horario_IdAmbiente]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Horario_IdAmbiente] ON [dbo].[Horario]
(
	[IdAmbiente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Horario_IdCurso]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Horario_IdCurso] ON [dbo].[Horario]
(
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Inscripcion_IdCurso]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Inscripcion_IdCurso] ON [dbo].[Inscripcion]
(
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Inscripcion_IdEstudiante]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Inscripcion_IdEstudiante] ON [dbo].[Inscripcion]
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Sesion_IdHorario]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Sesion_IdHorario] ON [dbo].[Sesion]
(
	[IdHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoCursoTipoEvaluacion_IdTipoCurso]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_TipoCursoTipoEvaluacion_IdTipoCurso] ON [dbo].[TipoCursoTipoEvaluacion]
(
	[IdTipoCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoCursoTipoEvaluacion_IdTipoEvaluacion]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_TipoCursoTipoEvaluacion_IdTipoEvaluacion] ON [dbo].[TipoCursoTipoEvaluacion]
(
	[IdTipoEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Traduccion_IdDocente]    Script Date: 3/02/2020 6:11:36 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Traduccion_IdDocente] ON [dbo].[Traduccion]
(
	[IdDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asistencia]  WITH CHECK ADD  CONSTRAINT [FK_Asistencia_Estudiante_IdEstudiante] FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiante] ([IdEstudiante])
GO
ALTER TABLE [dbo].[Asistencia] CHECK CONSTRAINT [FK_Asistencia_Estudiante_IdEstudiante]
GO
ALTER TABLE [dbo].[Asistencia]  WITH CHECK ADD  CONSTRAINT [FK_Asistencia_Sesion_IdSesion] FOREIGN KEY([IdSesion])
REFERENCES [dbo].[Sesion] ([IdSesion])
GO
ALTER TABLE [dbo].[Asistencia] CHECK CONSTRAINT [FK_Asistencia_Sesion_IdSesion]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Persona_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Persona_IdPersona]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Docente_IdDocente] FOREIGN KEY([IdDocente])
REFERENCES [dbo].[Docente] ([IdDocente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_Docente_IdDocente]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_TipoCurso_IdTipoCurso] FOREIGN KEY([IdTipoCurso])
REFERENCES [dbo].[TipoCurso] ([IdTipoCurso])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_TipoCurso_IdTipoCurso]
GO
ALTER TABLE [dbo].[DetalleApoderadoEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_DetalleApoderadoEstudiante_Apoderado_IdApoderado] FOREIGN KEY([IdApoderado])
REFERENCES [dbo].[Apoderado] ([IdApoderado])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleApoderadoEstudiante] CHECK CONSTRAINT [FK_DetalleApoderadoEstudiante_Apoderado_IdApoderado]
GO
ALTER TABLE [dbo].[DetalleApoderadoEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_DetalleApoderadoEstudiante_Estudiante_IdEstudiante] FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiante] ([IdEstudiante])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleApoderadoEstudiante] CHECK CONSTRAINT [FK_DetalleApoderadoEstudiante_Estudiante_IdEstudiante]
GO
ALTER TABLE [dbo].[DetalleDocenteEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK_DetalleDocenteEspecialidad_Docente_IdDocente] FOREIGN KEY([IdDocente])
REFERENCES [dbo].[Docente] ([IdDocente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleDocenteEspecialidad] CHECK CONSTRAINT [FK_DetalleDocenteEspecialidad_Docente_IdDocente]
GO
ALTER TABLE [dbo].[DetalleDocenteEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK_DetalleDocenteEspecialidad_Especialidad_IdEspecialidad] FOREIGN KEY([IdEspecialidad])
REFERENCES [dbo].[Especialidad] ([IdEspecialidad])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleDocenteEspecialidad] CHECK CONSTRAINT [FK_DetalleDocenteEspecialidad_Especialidad_IdEspecialidad]
GO
ALTER TABLE [dbo].[Docente]  WITH CHECK ADD  CONSTRAINT [FK_Docente_Persona_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Docente] CHECK CONSTRAINT [FK_Docente_Persona_IdPersona]
GO
ALTER TABLE [dbo].[Estudiante]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante_Persona_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Estudiante] CHECK CONSTRAINT [FK_Estudiante_Persona_IdPersona]
GO
ALTER TABLE [dbo].[Evaluacion]  WITH CHECK ADD  CONSTRAINT [FK_Evaluacion_HistorialEvaluacion_IdHistorialEvaluacion] FOREIGN KEY([IdHistorialEvaluacion])
REFERENCES [dbo].[HistorialEvaluacion] ([IdHistorialEvaluacion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Evaluacion] CHECK CONSTRAINT [FK_Evaluacion_HistorialEvaluacion_IdHistorialEvaluacion]
GO
ALTER TABLE [dbo].[Evaluacion]  WITH CHECK ADD  CONSTRAINT [FK_Evaluacion_TipoEvaluacion_IdTipoEvaluacion] FOREIGN KEY([IdTipoEvaluacion])
REFERENCES [dbo].[TipoEvaluacion] ([IdTipoEvaluacion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Evaluacion] CHECK CONSTRAINT [FK_Evaluacion_TipoEvaluacion_IdTipoEvaluacion]
GO
ALTER TABLE [dbo].[HistorialEvaluacion]  WITH CHECK ADD  CONSTRAINT [FK_HistorialEvaluacion_Curso_IdCurso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([IdCurso])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HistorialEvaluacion] CHECK CONSTRAINT [FK_HistorialEvaluacion_Curso_IdCurso]
GO
ALTER TABLE [dbo].[HistorialEvaluacion]  WITH CHECK ADD  CONSTRAINT [FK_HistorialEvaluacion_Estudiante_IdEstudiante] FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiante] ([IdEstudiante])
GO
ALTER TABLE [dbo].[HistorialEvaluacion] CHECK CONSTRAINT [FK_HistorialEvaluacion_Estudiante_IdEstudiante]
GO
ALTER TABLE [dbo].[Horario]  WITH CHECK ADD  CONSTRAINT [FK_Horario_Ambiente_IdAmbiente] FOREIGN KEY([IdAmbiente])
REFERENCES [dbo].[Ambiente] ([IdAmbiente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Horario] CHECK CONSTRAINT [FK_Horario_Ambiente_IdAmbiente]
GO
ALTER TABLE [dbo].[Horario]  WITH CHECK ADD  CONSTRAINT [FK_Horario_Curso_IdCurso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([IdCurso])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Horario] CHECK CONSTRAINT [FK_Horario_Curso_IdCurso]
GO
ALTER TABLE [dbo].[Inscripcion]  WITH CHECK ADD  CONSTRAINT [FK_Inscripcion_Curso_IdCurso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([IdCurso])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inscripcion] CHECK CONSTRAINT [FK_Inscripcion_Curso_IdCurso]
GO
ALTER TABLE [dbo].[Inscripcion]  WITH CHECK ADD  CONSTRAINT [FK_Inscripcion_Estudiante_IdEstudiante] FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiante] ([IdEstudiante])
GO
ALTER TABLE [dbo].[Inscripcion] CHECK CONSTRAINT [FK_Inscripcion_Estudiante_IdEstudiante]
GO
ALTER TABLE [dbo].[Sesion]  WITH CHECK ADD  CONSTRAINT [FK_Sesion_Horario_IdHorario] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([IdHorario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sesion] CHECK CONSTRAINT [FK_Sesion_Horario_IdHorario]
GO
ALTER TABLE [dbo].[TipoCursoTipoEvaluacion]  WITH CHECK ADD  CONSTRAINT [FK_TipoCursoTipoEvaluacion_TipoCurso_IdTipoCurso] FOREIGN KEY([IdTipoCurso])
REFERENCES [dbo].[TipoCurso] ([IdTipoCurso])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TipoCursoTipoEvaluacion] CHECK CONSTRAINT [FK_TipoCursoTipoEvaluacion_TipoCurso_IdTipoCurso]
GO
ALTER TABLE [dbo].[TipoCursoTipoEvaluacion]  WITH CHECK ADD  CONSTRAINT [FK_TipoCursoTipoEvaluacion_TipoEvaluacion_IdTipoEvaluacion] FOREIGN KEY([IdTipoEvaluacion])
REFERENCES [dbo].[TipoEvaluacion] ([IdTipoEvaluacion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TipoCursoTipoEvaluacion] CHECK CONSTRAINT [FK_TipoCursoTipoEvaluacion_TipoEvaluacion_IdTipoEvaluacion]
GO
ALTER TABLE [dbo].[Traduccion]  WITH CHECK ADD  CONSTRAINT [FK_Traduccion_Docente_IdDocente] FOREIGN KEY([IdDocente])
REFERENCES [dbo].[Docente] ([IdDocente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Traduccion] CHECK CONSTRAINT [FK_Traduccion_Docente_IdDocente]
GO
USE [master]
GO
ALTER DATABASE [DB_Overseas5] SET  READ_WRITE 
GO
