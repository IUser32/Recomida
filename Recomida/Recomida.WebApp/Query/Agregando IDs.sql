USE [Recomida]
GO

DROP TABLE Perfil.Ubicacion;

GO

DROP TABLE Perfil.Persona;

/****** Object:  Table [Perfil].[Ubicacion]    Script Date: 2/7/2017 3:27:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Perfil].[Ubicacion](
	[UbicacionID] [int] IDENTITY(1,1) NOT NULL,
	[RestauranteID] [int] NOT NULL,
	[Pais] [varchar](100) NOT NULL,
	[Ciudad] [varchar](100) NOT NULL,
	[Direccion] [varchar](255) NOT NULL,
	[Longitud] [float] NOT NULL,
	[Latitud] [float] NOT NULL,
 CONSTRAINT [PK_Ubicacion] PRIMARY KEY CLUSTERED 
(
	[UbicacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [Perfil].[Ubicacion]  WITH CHECK ADD  CONSTRAINT [FK__Ubicacion__Resta__2C3393D0] FOREIGN KEY([RestauranteID])
REFERENCES [Comida].[Restaurantes] ([RestauranteID])
GO

ALTER TABLE [Perfil].[Ubicacion] CHECK CONSTRAINT [FK__Ubicacion__Resta__2C3393D0]
GO


CREATE TABLE [Perfil].[Persona](
	[PersonaID] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[PersonaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [Perfil].[Persona]  WITH CHECK ADD  CONSTRAINT [FK__Persona__UserId__2B3F6F97] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO

ALTER TABLE [Perfil].[Persona] CHECK CONSTRAINT [FK__Persona__UserId__2B3F6F97]
GO
