/****** Object:  Database [svr-logs]    Script Date: 14/10/2023 23:38:33 ******/
CREATE DATABASE [svr-logs]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [svr-logs] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [svr-logs] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [svr-logs] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [svr-logs] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [svr-logs] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [svr-logs] SET ARITHABORT OFF 
GO
ALTER DATABASE [svr-logs] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [svr-logs] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [svr-logs] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [svr-logs] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [svr-logs] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [svr-logs] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [svr-logs] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [svr-logs] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [svr-logs] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [svr-logs] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [svr-logs] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [svr-logs] SET  MULTI_USER 
GO
ALTER DATABASE [svr-logs] SET ENCRYPTION ON
GO
ALTER DATABASE [svr-logs] SET QUERY_STORE = ON
GO
ALTER DATABASE [svr-logs] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[Asegurado]    Script Date: 14/10/2023 23:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asegurado](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Cedula] [varchar](10) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Edad] [varchar](2) NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Fecha] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Asegurado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialMigraciones]    Script Date: 14/10/2023 23:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialMigraciones](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_HistorialMigraciones] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguro]    Script Date: 14/10/2023 23:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguro](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[SumaAsegurada] [decimal](8, 2) NOT NULL,
	[Prima] [decimal](8, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Fecha] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Seguro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeguroAsegurado]    Script Date: 14/10/2023 23:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeguroAsegurado](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AseguradoId] [bigint] NOT NULL,
	[SeguroId] [bigint] NOT NULL,
	[Estado] [bit] NOT NULL,
	[Fecha] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_SeguroAsegurado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_SeguroAsegurado_AseguradoId]    Script Date: 14/10/2023 23:38:34 ******/
CREATE NONCLUSTERED INDEX [IX_SeguroAsegurado_AseguradoId] ON [dbo].[SeguroAsegurado]
(
	[AseguradoId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SeguroAsegurado_SeguroId]    Script Date: 14/10/2023 23:38:34 ******/
CREATE NONCLUSTERED INDEX [IX_SeguroAsegurado_SeguroId] ON [dbo].[SeguroAsegurado]
(
	[SeguroId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SeguroAsegurado]  WITH CHECK ADD  CONSTRAINT [FK_SeguroAsegurado_Asegurado_AseguradoId] FOREIGN KEY([AseguradoId])
REFERENCES [dbo].[Asegurado] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SeguroAsegurado] CHECK CONSTRAINT [FK_SeguroAsegurado_Asegurado_AseguradoId]
GO
ALTER TABLE [dbo].[SeguroAsegurado]  WITH CHECK ADD  CONSTRAINT [FK_SeguroAsegurado_Seguro_SeguroId] FOREIGN KEY([SeguroId])
REFERENCES [dbo].[Seguro] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SeguroAsegurado] CHECK CONSTRAINT [FK_SeguroAsegurado_Seguro_SeguroId]
GO
ALTER DATABASE [svr-logs] SET  READ_WRITE 
GO
