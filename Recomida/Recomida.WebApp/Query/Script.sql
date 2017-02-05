USE [master] 
GO
/****** Object:  Database [Recomida]    Script Date: 2/5/17 2:33:50 PM ******/
CREATE DATABASE [Recomida]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Recomida', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Recomida.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Recomida_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Recomida_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Recomida] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Recomida].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Recomida] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Recomida] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Recomida] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Recomida] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Recomida] SET ARITHABORT OFF 
GO
ALTER DATABASE [Recomida] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Recomida] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Recomida] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Recomida] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Recomida] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Recomida] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Recomida] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Recomida] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Recomida] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Recomida] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Recomida] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Recomida] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Recomida] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Recomida] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Recomida] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Recomida] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Recomida] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Recomida] SET RECOVERY FULL 
GO
ALTER DATABASE [Recomida] SET  MULTI_USER 
GO
ALTER DATABASE [Recomida] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Recomida] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Recomida] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Recomida] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Recomida] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Recomida]
GO
/****** Object:  Schema [Comida]    Script Date: 2/5/17 2:33:50 PM ******/
CREATE SCHEMA [Comida]
GO
/****** Object:  Schema [Perfil]    Script Date: 2/5/17 2:33:50 PM ******/
CREATE SCHEMA [Perfil]
GO
/****** Object:  Table [Comida].[Restaurantes]    Script Date: 2/5/17 2:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Comida].[Restaurantes](
	[RestauranteID] [int] IDENTITY(1,1) NOT NULL,
	[TipoRestauranteID] [int] NOT NULL,
	[TipoComidaID] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RestauranteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Comida].[TipoComida]    Script Date: 2/5/17 2:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Comida].[TipoComida](
	[TipoComidaID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoComidaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Comida].[TipoRestaurante]    Script Date: 2/5/17 2:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Comida].[TipoRestaurante](
	[TipoRestauranteID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoRestauranteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Comida].[Valoracion]    Script Date: 2/5/17 2:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Comida].[Valoracion](
	[ValoracionID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RestauranteID] [int] NOT NULL,
	[Puntuaje] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ValoracionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 2/5/17 2:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](56) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 2/5/17 2:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 2/5/17 2:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 2/5/17 2:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 2/5/17 2:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Perfil].[Persona]    Script Date: 2/5/17 2:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Perfil].[Persona](
	[UserId] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Perfil].[Ubicacion]    Script Date: 2/5/17 2:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Perfil].[Ubicacion](
	[RestauranteID] [int] NOT NULL,
	[Pais] [varchar](100) NOT NULL,
	[Ciudad] [varchar](100) NOT NULL,
	[Direccion] [varchar](255) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
ALTER TABLE [Comida].[Restaurantes]  WITH CHECK ADD FOREIGN KEY([TipoComidaID])
REFERENCES [Comida].[TipoComida] ([TipoComidaID])
GO
ALTER TABLE [Comida].[Restaurantes]  WITH CHECK ADD FOREIGN KEY([TipoRestauranteID])
REFERENCES [Comida].[TipoRestaurante] ([TipoRestauranteID])
GO
ALTER TABLE [Comida].[Valoracion]  WITH CHECK ADD FOREIGN KEY([RestauranteID])
REFERENCES [Comida].[Restaurantes] ([RestauranteID])
GO
ALTER TABLE [Comida].[Valoracion]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
ALTER TABLE [Perfil].[Persona]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [Perfil].[Ubicacion]  WITH CHECK ADD FOREIGN KEY([RestauranteID])
REFERENCES [Comida].[Restaurantes] ([RestauranteID])
GO
USE [master]
GO
ALTER DATABASE [Recomida] SET  READ_WRITE 
GO
