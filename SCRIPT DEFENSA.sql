USE [master]
GO
/****** Object:  Database [RecApp]    Script Date: 05/12/2016 10:00:20 p.m. ******/
CREATE DATABASE [RecApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RecApp', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\RecApp.mdf' , SIZE = 5056KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
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
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 05/12/2016 10:00:20 p.m. ******/
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
/****** Object:  Table [dbo].[AppointmentDiary]    Script Date: 05/12/2016 10:00:20 p.m. ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 05/12/2016 10:00:20 p.m. ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 05/12/2016 10:00:20 p.m. ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 05/12/2016 10:00:20 p.m. ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 05/12/2016 10:00:20 p.m. ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 05/12/2016 10:00:20 p.m. ******/
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
/****** Object:  Table [dbo].[CivilStatus]    Script Date: 05/12/2016 10:00:20 p.m. ******/
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
/****** Object:  Table [dbo].[Events]    Script Date: 05/12/2016 10:00:20 p.m. ******/
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
/****** Object:  Table [dbo].[PaymentDetails]    Script Date: 05/12/2016 10:00:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPayment] [int] NOT NULL,
	[FechaAbono] [datetime] NOT NULL,
	[Estado] [int] NOT NULL,
	[Abono] [money] NOT NULL,
 CONSTRAINT [PK_CobroDetalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payments]    Script Date: 05/12/2016 10:00:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRecord] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[Estado] [int] NOT NULL,
	[MontoAdicional] [money] NULL,
	[TotalPagar] [money] NOT NULL,
	[Saldo] [money] NULL,
 CONSTRAINT [PK_Cobro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Records]    Script Date: 05/12/2016 10:00:20 p.m. ******/
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
/****** Object:  Table [dbo].[Tratamientoes]    Script Date: 05/12/2016 10:00:20 p.m. ******/
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
/****** Object:  Table [dbo].[TratamientoPacientes]    Script Date: 05/12/2016 10:00:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TratamientoPacientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPayment] [int] NOT NULL,
	[IdTratamiento] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[IdDiente] [int] NOT NULL,
	[Cara] [nvarchar](50) NULL,
	[Observaciones] [nvarchar](250) NULL,
	[FechaTratamiento] [datetime] NULL,
 CONSTRAINT [PK_TratamientoPacientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AppointmentDiary] ON 

INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (1, N'Andrés Sancho', 0, CAST(0x0000A6B300A4CB80 AS DateTime), 30, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (14, N'Annia Lopez', 0, CAST(0x0000A6F0009450C0 AS DateTime), 60, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (15, N'Enid Fonseca', 0, CAST(0x0000A6DA00E6B680 AS DateTime), 30, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (16, N'Robert González', 0, CAST(0x0000A6DB0083D600 AS DateTime), 60, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (17, N'Erick Serrano', 0, CAST(0x0000A6DA00F73140 AS DateTime), 30, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (18, N'Andrés Sancho', 0, CAST(0x0000A6DE00CDFE60 AS DateTime), 30, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (19, N'Carolina López', 0, CAST(0x0000A6EB00FF6EA0 AS DateTime), 30, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (20, N'Loreana Campos', 0, CAST(0x0000A6E900D63BC0 AS DateTime), 30, 0)
SET IDENTITY_INSERT [dbo].[AppointmentDiary] OFF
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3170e10c-3a14-4d9f-a370-01491ea5f6ff', N'Administrador')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'93c2c198-8eda-42e0-a00f-91031305f682', N'Empleado')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'be5e6448-7762-4560-9141-535a1ef23eff', N'Manager')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'86dfc1b5-67e6-423e-9e2d-c91fab903d47', N'be5e6448-7762-4560-9141-535a1ef23eff')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'95cf672e-e84b-4557-9d50-84b17a39ae6f', N'93c2c198-8eda-42e0-a00f-91031305f682')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'98de58fc-b545-4806-81ee-7b080a570d28', N'3170e10c-3a14-4d9f-a370-01491ea5f6ff')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'86dfc1b5-67e6-423e-9e2d-c91fab903d47', N'hilda@drahildavilchez.com', 0, N'AIvPzj3l9408iQup4r8CJHkUSgg5f6NscEYO1uInuAdK8KtdqyKd9McuvAcp9ywsMw==', N'6703e5ed-be80-464b-848b-c92b686eefb7', NULL, 0, 0, CAST(0x0000A6CD00652D17 AS DateTime), 0, 0, N'hilda@drahildavilchez.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'95cf672e-e84b-4557-9d50-84b17a39ae6f', N'oficina@drahildavilchez.com', 0, N'ACTf9Ec4IRPbDcwbqMsgvfpLRLtXOQ+8XC+XxwjHApayg1YISooiIbVBeD0BuFWWqw==', N'977ac1c0-3aef-42d8-99f6-3bd024bd3252', NULL, 0, 0, CAST(0x0000A6CD00652E63 AS DateTime), 0, 0, N'oficina@drahildavilchez.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'98de58fc-b545-4806-81ee-7b080a570d28', N'gjimenez.com@gmail.com', 0, N'ALLoUnc3MXIcjQlNc/4WkY13KBK4SK8e2T98FOb3IOQ1LCxPQTCgs2zil5oPMUT5PQ==', N'59d6e36a-b31d-4c4a-abcd-c56b121941a7', NULL, 0, 0, NULL, 0, 0, N'gjimenez.com@gmail.com')
SET IDENTITY_INSERT [dbo].[CivilStatus] ON 

INSERT [dbo].[CivilStatus] ([Id], [Descripcion]) VALUES (1, N'Soltero(a)')
INSERT [dbo].[CivilStatus] ([Id], [Descripcion]) VALUES (2, N'Casado(a)')
INSERT [dbo].[CivilStatus] ([Id], [Descripcion]) VALUES (3, N'Divorciado(a)')
INSERT [dbo].[CivilStatus] ([Id], [Descripcion]) VALUES (4, N'Viudo(a)')
INSERT [dbo].[CivilStatus] ([Id], [Descripcion]) VALUES (5, N'Unión Libre')
INSERT [dbo].[CivilStatus] ([Id], [Descripcion]) VALUES (6, N'Otro')
SET IDENTITY_INSERT [dbo].[CivilStatus] OFF
SET IDENTITY_INSERT [dbo].[PaymentDetails] ON 

INSERT [dbo].[PaymentDetails] ([Id], [IdPayment], [FechaAbono], [Estado], [Abono]) VALUES (2, 3, CAST(0x0000A6CC01792479 AS DateTime), 1, 10000.0000)
INSERT [dbo].[PaymentDetails] ([Id], [IdPayment], [FechaAbono], [Estado], [Abono]) VALUES (3, 3, CAST(0x0000A6CC017A9CBC AS DateTime), 1, 20000.0000)
INSERT [dbo].[PaymentDetails] ([Id], [IdPayment], [FechaAbono], [Estado], [Abono]) VALUES (4, 3, CAST(0x0000A6CC017AF43A AS DateTime), 1, 37000.0000)
SET IDENTITY_INSERT [dbo].[PaymentDetails] OFF
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([Id], [IdRecord], [FechaRegistro], [Estado], [MontoAdicional], [TotalPagar], [Saldo]) VALUES (3, 3, CAST(0x0000A6CC0177D06A AS DateTime), 3, 7000.0000, 67000.0000, 0.0000)
INSERT [dbo].[Payments] ([Id], [IdRecord], [FechaRegistro], [Estado], [MontoAdicional], [TotalPagar], [Saldo]) VALUES (4, 3, CAST(0x0000A6CC017B5E33 AS DateTime), 1, 0.0000, 25000.0000, 25000.0000)
INSERT [dbo].[Payments] ([Id], [IdRecord], [FechaRegistro], [Estado], [MontoAdicional], [TotalPagar], [Saldo]) VALUES (5, 1, CAST(0x0000A6CC017BA0E0 AS DateTime), 2, 0.0000, 105000.0000, 105000.0000)
SET IDENTITY_INSERT [dbo].[Payments] OFF
SET IDENTITY_INSERT [dbo].[Records] ON 

INSERT [dbo].[Records] ([Id], [Nombre], [Apellido1], [Apellido2], [Cedula], [FechaNacimiento], [NombreEncargado], [Apellido1Encargado], [Apellido2Encargado], [IdEstadoCivil], [Domicilio], [Telefono1], [Telefono2], [Profesion], [Email], [ContactoEmergencia], [TratamientoMedico], [Medicamento], [Diabetes], [Artritis], [EnfermedadCardiaca], [Hepatitis], [FiebreReumatica], [Ulcera], [PresionAlta], [PresionBaja], [EnfermedadesNerviosas], [OtrasEnfermedades], [SangradoProlongado], [Desmayos], [IntervencionQuirurgica], [Aspirina], [Sulfas], [Penicilina], [AnomaliasAnestesia], [Embarazo], [Lactancia], [Otros]) VALUES (1, N'Andrés', N'Sancho', N'Solano', 401920755, CAST(0x00007BDB00000000 AS DateTime), NULL, NULL, NULL, 1, N'San Pedro, Barva. Heredia.', N'2269-6638', N'8878-8925', N'Informático', N'asansola@gmail.com', N'Dennia Solano. tel:2222-2222', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, NULL)
INSERT [dbo].[Records] ([Id], [Nombre], [Apellido1], [Apellido2], [Cedula], [FechaNacimiento], [NombreEncargado], [Apellido1Encargado], [Apellido2Encargado], [IdEstadoCivil], [Domicilio], [Telefono1], [Telefono2], [Profesion], [Email], [ContactoEmergencia], [TratamientoMedico], [Medicamento], [Diabetes], [Artritis], [EnfermedadCardiaca], [Hepatitis], [FiebreReumatica], [Ulcera], [PresionAlta], [PresionBaja], [EnfermedadesNerviosas], [OtrasEnfermedades], [SangradoProlongado], [Desmayos], [IntervencionQuirurgica], [Aspirina], [Sulfas], [Penicilina], [AnomaliasAnestesia], [Embarazo], [Lactancia], [Otros]) VALUES (3, N'Annia', N'Lopez', N'Gonzalez', 113180268, CAST(0x00007CB400000000 AS DateTime), NULL, NULL, NULL, 2, N'Heredia', N'2410-2203', N'8877-1200', N'Project Manager', N'annialogon@gmail.com', N'Andrés Sancho/Tel 88788925.', 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, N'medicamento:alevian duo.')
INSERT [dbo].[Records] ([Id], [Nombre], [Apellido1], [Apellido2], [Cedula], [FechaNacimiento], [NombreEncargado], [Apellido1Encargado], [Apellido2Encargado], [IdEstadoCivil], [Domicilio], [Telefono1], [Telefono2], [Profesion], [Email], [ContactoEmergencia], [TratamientoMedico], [Medicamento], [Diabetes], [Artritis], [EnfermedadCardiaca], [Hepatitis], [FiebreReumatica], [Ulcera], [PresionAlta], [PresionBaja], [EnfermedadesNerviosas], [OtrasEnfermedades], [SangradoProlongado], [Desmayos], [IntervencionQuirurgica], [Aspirina], [Sulfas], [Penicilina], [AnomaliasAnestesia], [Embarazo], [Lactancia], [Otros]) VALUES (4, N'Roberto', N'Pazos ', N'Romero', 120620201, CAST(0x00009C5600000000 AS DateTime), N'Annia', N'	López', N'González', 1, N'Heredia. Mercedes Norte', N'2222-2222', N'2222-2222', N'Estudiante', N'silrom7623@yahoo.com', N'Silvia Romero. Tel:784140', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[Records] OFF
SET IDENTITY_INSERT [dbo].[Tratamientoes] ON 

INSERT [dbo].[Tratamientoes] ([Id], [Nombre], [Descripcion], [PrecioBase]) VALUES (1, N'Amalgama', N'Incisal', 25000.0000)
INSERT [dbo].[Tratamientoes] ([Id], [Nombre], [Descripcion], [PrecioBase]) VALUES (2, N'Implante Dental', N'Porcelana', 55000.0000)
INSERT [dbo].[Tratamientoes] ([Id], [Nombre], [Descripcion], [PrecioBase]) VALUES (4, N'Prótesis Dental', N'Prótesis dental permanente', 80000.0000)
INSERT [dbo].[Tratamientoes] ([Id], [Nombre], [Descripcion], [PrecioBase]) VALUES (6, N'Limpieza Dental', N'Limpieza', 35000.0000)
SET IDENTITY_INSERT [dbo].[Tratamientoes] OFF
SET IDENTITY_INSERT [dbo].[TratamientoPacientes] ON 

INSERT [dbo].[TratamientoPacientes] ([Id], [IdPayment], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (4, 3, 6, 3, 16, N'Dentadura Completa', N'todos los dientes', CAST(0x0000A6CC0178B35A AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdPayment], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (5, 4, 1, 3, 34, N'Vestibular', N'calza de resina', CAST(0x0000A6CC017B5E2D AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdPayment], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (6, 5, 4, 1, 15, N'Vestibular', N'De titanio', CAST(0x0000A6CC017BA0DB AS DateTime))
INSERT [dbo].[TratamientoPacientes] ([Id], [IdPayment], [IdTratamiento], [IdPaciente], [IdDiente], [Cara], [Observaciones], [FechaTratamiento]) VALUES (7, 5, 1, 1, 15, N'Vestibular', N'lateral', CAST(0x0000A6CC017BB6A4 AS DateTime))
SET IDENTITY_INSERT [dbo].[TratamientoPacientes] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 05/12/2016 10:00:20 p.m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 05/12/2016 10:00:20 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 05/12/2016 10:00:20 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 05/12/2016 10:00:20 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 05/12/2016 10:00:20 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 05/12/2016 10:00:20 p.m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Records__B4ADFE384D74A0F5]    Script Date: 05/12/2016 10:00:20 p.m. ******/
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
ALTER TABLE [dbo].[PaymentDetails]  WITH CHECK ADD  CONSTRAINT [FK_Payment] FOREIGN KEY([IdPayment])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[PaymentDetails] CHECK CONSTRAINT [FK_Payment]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Record] FOREIGN KEY([IdRecord])
REFERENCES [dbo].[Records] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Record]
GO
ALTER TABLE [dbo].[Records]  WITH CHECK ADD  CONSTRAINT [FK_Records_CivilStatus] FOREIGN KEY([IdEstadoCivil])
REFERENCES [dbo].[CivilStatus] ([Id])
GO
ALTER TABLE [dbo].[Records] CHECK CONSTRAINT [FK_Records_CivilStatus]
GO
ALTER TABLE [dbo].[TratamientoPacientes]  WITH CHECK ADD  CONSTRAINT [FK_Records] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Records] ([Id])
GO
ALTER TABLE [dbo].[TratamientoPacientes] CHECK CONSTRAINT [FK_Records]
GO
ALTER TABLE [dbo].[TratamientoPacientes]  WITH CHECK ADD  CONSTRAINT [FK_TPaymentT] FOREIGN KEY([IdPayment])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[TratamientoPacientes] CHECK CONSTRAINT [FK_TPaymentT]
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
