USE [master]
GO
/****** Object:  Database [TpIS]    Script Date: 27/4/2023 20:11:33 ******/
CREATE DATABASE [TpIS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TpIS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TpIS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TpIS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TpIS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TpIS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TpIS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TpIS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TpIS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TpIS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TpIS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TpIS] SET ARITHABORT OFF 
GO
ALTER DATABASE [TpIS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TpIS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TpIS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TpIS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TpIS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TpIS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TpIS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TpIS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TpIS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TpIS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TpIS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TpIS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TpIS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TpIS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TpIS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TpIS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TpIS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TpIS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TpIS] SET  MULTI_USER 
GO
ALTER DATABASE [TpIS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TpIS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TpIS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TpIS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TpIS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TpIS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TpIS] SET QUERY_STORE = OFF
GO
USE [TpIS]
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 27/4/2023 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bitacora](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[action] [nvarchar](50) NULL,
	[time] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
 CONSTRAINT [PK_bitacora] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/4/2023 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [numeric](18, 0) NOT NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[admin] [bit] NULL,
	[active] [bit] NULL,
	[birthdate] [nvarchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Username] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[s_bitacora_crear]    Script Date: 27/4/2023 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[s_bitacora_crear](
	@user nvarchar(50),
	@time nvarchar(50),
	@action nvarchar(50)
	)

AS SET NOCOUNT ON

	INSERT INTO dbo.bitacora(username, time, action) values (@user, @time, @action)
GO
/****** Object:  StoredProcedure [dbo].[s_Usuario_cambiar_contrasena]    Script Date: 27/4/2023 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[s_Usuario_cambiar_contrasena](
	@id int,
	@password nvarchar(50)
	)

AS SET NOCOUNT ON

	UPDATE Usuario SET password = @password where id=@id
GO
/****** Object:  StoredProcedure [dbo].[s_Usuario_crear]    Script Date: 27/4/2023 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[s_Usuario_crear](
	@id numeric(18,0),
	@user nvarchar(50),
	@password nvarchar(50),
	@admin bit,
	@active bit,
	@birthdate nvarchar(50)
	)

AS SET NOCOUNT ON

	INSERT INTO dbo.Usuario(id, username, password, admin, active, birthdate) values (@id, @user, @password, @admin, @active, @birthdate)
GO
/****** Object:  StoredProcedure [dbo].[s_Usuario_dar_admin]    Script Date: 27/4/2023 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[s_Usuario_dar_admin](
	@id numeric(18,0)
	)

AS SET NOCOUNT ON

	UPDATE Usuario SET admin = 1 where id=@id
GO
/****** Object:  StoredProcedure [dbo].[s_Usuario_eliminar]    Script Date: 27/4/2023 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[s_Usuario_eliminar](
	@id numeric(18,0)
	)

AS SET NOCOUNT ON

	UPDATE Usuario SET active = 0 where id=@id
GO
/****** Object:  StoredProcedure [dbo].[s_Usuario_listar]    Script Date: 27/4/2023 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[s_Usuario_listar]

AS SET NOCOUNT ON

	SELECT
	Usuario.id,
	Usuario.username,
	Usuario.password,
	Usuario.admin,
	usuario.active,
	usuario.birthdate
	from dbo.Usuario
GO
USE [master]
GO
ALTER DATABASE [TpIS] SET  READ_WRITE 
GO
