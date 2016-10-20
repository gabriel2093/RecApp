USE [master]
GO
/****** Object:  Database [RecApp]    Script Date: 10/20/2016 12:44:54 AM ******/
CREATE DATABASE [RecApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RecApp', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\RecApp.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RecApp_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\RecApp_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RecApp] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RecApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RecApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RecApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RecApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RecApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RecApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [RecApp] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [RecApp] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [RecApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RecApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RecApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RecApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RecApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RecApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RecApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RecApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RecApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RecApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RecApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RecApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RecApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RecApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RecApp] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [RecApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RecApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RecApp] SET  MULTI_USER 
GO
ALTER DATABASE [RecApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RecApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RecApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RecApp] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [RecApp]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10/20/2016 12:44:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AppointmentDiary]    Script Date: 10/20/2016 12:44:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentDiary](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[SomeImportantKey] [int] NOT NULL,
	[DateTimeScheduled] [datetime] NOT NULL,
	[AppointmentLength] [int] NOT NULL,
	[StatusENUM] [int] NOT NULL,
 CONSTRAINT [PK_ConsultantBookings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10/20/2016 12:44:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10/20/2016 12:44:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10/20/2016 12:44:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10/20/2016 12:44:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/20/2016 12:44:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CivilStatus]    Script Date: 10/20/2016 12:44:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CivilStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CivilStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Events]    Script Date: 10/20/2016 12:44:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Events](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Start_Date] [datetime] NOT NULL,
	[End_Date] [datetime] NOT NULL,
	[Text] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Records]    Script Date: 10/20/2016 12:44:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Records](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Apellido1] [nvarchar](100) NULL,
	[Apellido2] [nvarchar](100) NULL,
	[Cedula] [int] NULL,
	[FechaNacimiento] [datetime] NULL,
	[NombreEncargado] [nvarchar](100) NULL,
	[Apellido1Encargado] [nvarchar](100) NULL,
	[Apellido2Encargado] [nvarchar](100) NULL,
	[IdEstadoCivil] [int] NULL,
	[Domicilio] [nvarchar](500) NULL,
	[Telefono1] [nvarchar](50) NULL,
	[Telefono2] [nvarchar](50) NULL,
	[Profesion] [nvarchar](150) NULL,
	[Email] [nvarchar](150) NULL,
	[ContactoEmergencia] [nvarchar](500) NULL,
	[TratamientoMedico] [bit] NULL,
	[Medicamento] [bit] NULL,
	[Diabetes] [bit] NULL,
	[Artritis] [bit] NULL,
	[EnfermedadCardiaca] [bit] NULL,
	[Hepatitis] [bit] NULL,
	[FiebreReumatica] [bit] NULL,
	[Ulcera] [bit] NULL,
	[PresionAlta] [bit] NULL,
	[PresionBaja] [bit] NULL,
	[EnfermedadesNerviosas] [bit] NULL,
	[OtrasEnfermedades] [bit] NULL,
	[SangradoProlongado] [bit] NULL,
	[Desmayos] [bit] NULL,
	[IntervencionQuirurgica] [bit] NULL,
	[Aspirina] [bit] NULL,
	[Sulfas] [bit] NULL,
	[Penicilina] [bit] NULL,
	[AnomaliasAnestesia] [bit] NULL,
	[Embarazo] [bit] NULL,
	[Lactancia] [bit] NULL,
	[Otros] [nvarchar](500) NULL,
 CONSTRAINT [PK_Record] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tratamientoes]    Script Date: 10/20/2016 12:44:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tratamientoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NULL,
	[Descripcion] [nvarchar](250) NULL,
	[PrecioBase] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TratamientoPacientes]    Script Date: 10/20/2016 12:44:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TratamientoPacientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTratamiento] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[IdDiente] [int] NOT NULL,
	[Cara] [nvarchar](50) NULL,
	[Observaciones] [nvarchar](250) NULL,
	[FechaTratamiento] [datetime] NULL
) ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3d90ecca-2eaa-4729-8bcb-eaafb306e3c7', N'Administrador')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'234d0b25-2156-485a-be59-3e8940362d18', N'Empleado')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b56eb6a7-eae6-43bf-89f2-3dcf8ecf36b8', N'Manager')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'11a0b0a5-3847-46cf-b54c-dfda6127fd4e', N'3d90ecca-2eaa-4729-8bcb-eaafb306e3c7')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'11a0b0a5-3847-46cf-b54c-dfda6127fd4e', N'gjimenez.com@gmail.com', 0, N'AMTpi1Gr9LDyDmbnKkWRaoWPFMhN3+OnXHwhgSQLPPYt0BwugacmeS4coScjqpDXTw==', N'da6478a4-c875-4c0c-8722-787936f05bf0', NULL, 0, 0, NULL, 0, 0, N'gjimenez.com@gmail.com')
SET IDENTITY_INSERT [dbo].[CivilStatus] ON 

INSERT [dbo].[CivilStatus] ([Id], [Descripcion]) VALUES (1, N'Soltero(a)')
INSERT [dbo].[CivilStatus] ([Id], [Descripcion]) VALUES (2, N'Casado(a)')
SET IDENTITY_INSERT [dbo].[CivilStatus] OFF
SET IDENTITY_INSERT [dbo].[Records] ON 

INSERT [dbo].[Records] ([Id], [Nombre], [Apellido1], [Apellido2], [Cedula], [FechaNacimiento], [NombreEncargado], [Apellido1Encargado], [Apellido2Encargado], [IdEstadoCivil], [Domicilio], [Telefono1], [Telefono2], [Profesion], [Email], [ContactoEmergencia], [TratamientoMedico], [Medicamento], [Diabetes], [Artritis], [EnfermedadCardiaca], [Hepatitis], [FiebreReumatica], [Ulcera], [PresionAlta], [PresionBaja], [EnfermedadesNerviosas], [OtrasEnfermedades], [SangradoProlongado], [Desmayos], [IntervencionQuirurgica], [Aspirina], [Sulfas], [Penicilina], [AnomaliasAnestesia], [Embarazo], [Lactancia], [Otros]) VALUES (1, N'Gabriel', N'Jimenez', N'Umañ', 115330025, CAST(0x000084FE00000000 AS DateTime), NULL, NULL, NULL, 1, N'3054369224', N'3054369224', N'3054369224', N'2121', N'gjimenez.com@gmail.com', N'asdasdsa', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, NULL)
INSERT [dbo].[Records] ([Id], [Nombre], [Apellido1], [Apellido2], [Cedula], [FechaNacimiento], [NombreEncargado], [Apellido1Encargado], [Apellido2Encargado], [IdEstadoCivil], [Domicilio], [Telefono1], [Telefono2], [Profesion], [Email], [ContactoEmergencia], [TratamientoMedico], [Medicamento], [Diabetes], [Artritis], [EnfermedadCardiaca], [Hepatitis], [FiebreReumatica], [Ulcera], [PresionAlta], [PresionBaja], [EnfermedadesNerviosas], [OtrasEnfermedades], [SangradoProlongado], [Desmayos], [IntervencionQuirurgica], [Aspirina], [Sulfas], [Penicilina], [AnomaliasAnestesia], [Embarazo], [Lactancia], [Otros]) VALUES (2, N'Roberto', N'Umaña', N'Umaña', 111600780, CAST(0x000084FE00000000 AS DateTime), NULL, NULL, NULL, 1, N'aqwqwqd1212121', N'3055927754', N'3055927754', N'2121', N'gjimenez@pts.cr', N'asdasdsa', 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[Records] OFF
SET IDENTITY_INSERT [dbo].[Tratamientoes] ON 

INSERT [dbo].[Tratamientoes] ([Id], [Nombre], [Descripcion], [PrecioBase]) VALUES (1, N'Tratamiento 1', N'Uno', 15000.0000)
INSERT [dbo].[Tratamientoes] ([Id], [Nombre], [Descripcion], [PrecioBase]) VALUES (2, N'Tratamiento 2', N'Dos', 30000.0000)
SET IDENTITY_INSERT [dbo].[Tratamientoes] OFF
SET IDENTITY_INSERT [dbo].[TratamientoPacientes] ON 

INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (1, 1, 1, 17, N'Vestibular', N'123', CAST(0x0000A6A300000000 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (9, 1, 1, 16, N'Lingual', N'123', CAST(0x0000A6A401227A6B AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (10, 2, 1, 17, N'Incisal', N'CARA 1233323232', CAST(0x0000A6A4017D2EE7 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (11, 2, 1, 16, N'Lingual', N'trre', CAST(0x0000A6A4017FACAD AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (12, 2, 1, 16, N'Lingual', N'yy', CAST(0x0000A6A4017FF5BC AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (13, 1, 1, 14, N'Distal', N'y', CAST(0x0000A6A40180149A AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (14, 1, 1, 17, N'Lingual', N'rrr', CAST(0x0000A6A40180841E AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (15, 2, 1, 15, N'Lingual', N'yy', CAST(0x0000A6A40182F944 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (16, 2, 1, 16, N'Lingual', N'tt', CAST(0x0000A6A40184106C AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (20, 1, 1, 16, N'Lingual', N'tttf', CAST(0x0000A6A40188A600 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (25, 2, 1, 13, N'Distal', N'uuu', CAST(0x0000A6A500013347 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (26, 1, 1, 13, N'Distal', N'adasd', CAST(0x0000A6A5000150FD AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (27, 1, 1, 14, N'Vestibular', N'123', CAST(0x0000A6A5000171B3 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (28, 1, 1, 12, N'Vestibular', N'123', CAST(0x0000A6A5000193CC AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (29, 1, 1, 15, N'Vestibular', N'uu', CAST(0x0000A6A500020D49 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (30, 1, 1, 12, N'Vestibular', N'123', CAST(0x0000A6A5000252CE AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (31, 1, 1, 14, N'Vestibular', NULL, CAST(0x0000A6A500029CA1 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (32, 2, 1, 15, N'Vestibular', N'123', CAST(0x0000A6A500030BB1 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (33, 1, 1, 15, N'Lingual', N'rrr', CAST(0x0000A6A500034955 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (34, 1, 1, 13, N'Vestibular', N'123', CAST(0x0000A6A50003729B AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (35, 2, 1, 13, N'Lingual', N'u', CAST(0x0000A6A500044512 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (36, 2, 1, 16, N'Vestibular', N'1', CAST(0x0000A6A50004B77E AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (37, 1, 1, 14, N'Vestibular', N'123', CAST(0x0000A6A50005560A AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (38, 1, 1, 13, N'Vestibular', NULL, CAST(0x0000A6A500062E70 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (39, 2, 1, 15, N'Vestibular', NULL, CAST(0x0000A6A50006C449 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (40, 1, 1, 16, N'Vestibular', N'123', CAST(0x0000A6A5000761C6 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (41, 1, 1, 13, N'Lingual', N'rrr', CAST(0x0000A6A500078944 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (42, 1, 1, 17, N'Vestibular', N'123', CAST(0x0000A6A50007BC5D AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (43, 1, 1, 16, N'Lingual', N'yyyy', CAST(0x0000A6A500080302 AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (44, 2, 1, 15, N'Distal', N'u', CAST(0x0000A6A50008209A AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (45, 1, 2, 16, N'Vestibular', N'123', CAST(0x0000A6A5000B93DB AS DateTime))
SET IDENTITY_INSERT [dbo].[TratamientoPacientes] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10/20/2016 12:44:55 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 10/20/2016 12:44:55 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 10/20/2016 12:44:55 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 10/20/2016 12:44:55 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 10/20/2016 12:44:55 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 10/20/2016 12:44:55 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Records__B4ADFE382FCB84D6]    Script Date: 10/20/2016 12:44:55 AM ******/
ALTER TABLE [dbo].[Records] ADD UNIQUE NONCLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AppointmentDiary] ADD  CONSTRAINT [DF_ConsultantBookings_Status]  DEFAULT ((0)) FOR [StatusENUM]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Records]  WITH CHECK ADD  CONSTRAINT [FK_Records_CivilStatus] FOREIGN KEY([IdEstadoCivil])
REFERENCES [dbo].[CivilStatus] ([Id])
GO
ALTER TABLE [dbo].[Records] CHECK CONSTRAINT [FK_Records_CivilStatus]
GO
ALTER TABLE [dbo].[TratamientoPacientes]  WITH CHECK ADD  CONSTRAINT [FK_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Records] ([Id])
GO
ALTER TABLE [dbo].[TratamientoPacientes] CHECK CONSTRAINT [FK_Paciente]
GO
ALTER TABLE [dbo].[TratamientoPacientes]  WITH CHECK ADD  CONSTRAINT [FK_Tratamiento] FOREIGN KEY([IdTratamiento])
REFERENCES [dbo].[Tratamientoes] ([Id])
GO
ALTER TABLE [dbo].[TratamientoPacientes] CHECK CONSTRAINT [FK_Tratamiento]
GO
USE [master]
GO
ALTER DATABASE [RecApp] SET  READ_WRITE 
GO
