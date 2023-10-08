USE [Animales]
GO

/****** Object:  Table [dbo].[animalesCautiverio]    Script Date: 08/10/2023 12:44:48 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[animalesCautiverio](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Especie] [varchar](50) NOT NULL,
	[Edad] [varchar](50) NOT NULL,
	[RasgosUnicos] [varchar](50) NULL,
	[LugarOrigen] [varchar](50) NULL,
	[TipoHabitat] [varchar](50) NULL,
	[Sexo] [varchar](50) NULL,
 CONSTRAINT [PK_animalesCautiverio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[animalesCautiverio] ADD  CONSTRAINT [DF_animalesCautiverio_Id]  DEFAULT (newid()) FOR [Id]
GO

