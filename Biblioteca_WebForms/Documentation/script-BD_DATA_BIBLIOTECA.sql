USE [PFBiblioteca]
GO
/****** Object:  Table [dbo].[Alquiler]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alquiler](
	[IdAlquiler] [int] IDENTITY(1,1) NOT NULL,
	[FechaAlquiler] [datetime] NOT NULL,
	[FechaDevProbable] [date] NOT NULL,
	[FKSocio] [int] NOT NULL,
	[FKBibliotecario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAlquiler] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlquilerEjemplar]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlquilerEjemplar](
	[IdAlquilerEjemplar] [int] IDENTITY(1,1) NOT NULL,
	[FKAlquiler] [int] NOT NULL,
	[FKEjemplar] [int] NOT NULL,
	[FechaDevReal] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAlquilerEjemplar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[IdAutor] [int] IDENTITY(1,1) NOT NULL,
	[Apellido1] [varchar](40) NOT NULL,
	[Apellido2] [varchar](40) NULL,
	[Nombre] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AutorObra]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutorObra](
	[IdAutorObra] [int] IDENTITY(1,1) NOT NULL,
	[FKObra] [int] NOT NULL,
	[FKAutor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAutorObra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bibliotecario]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bibliotecario](
	[IdBibliotecario] [int] IDENTITY(1,1) NOT NULL,
	[Apellido] [varchar](40) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Email] [varchar](60) NOT NULL,
	[Contrasenia] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdBibliotecario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Editorial]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editorial](
	[IdEditorial] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEditorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ejemplar]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ejemplar](
	[IdEjemplar] [int] IDENTITY(1,1) NOT NULL,
	[CodigoBarras] [char](13) NULL,
	[ISBN] [varchar](13) NULL,
	[AnioPublicacion] [smallint] NULL,
	[EstaBuenEstado] [bit] NOT NULL,
	[NumPaginas] [int] NULL,
	[EstaAlquilado] [bit] NOT NULL,
	[FKEditorial] [int] NOT NULL,
	[FKObra] [int] NOT NULL,
	[FkUbicacion] [int] NULL,
	[FkIdioma] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEjemplar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[IdGenero] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[IdIdioma] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Obra]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Obra](
	[IdObra] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](80) NOT NULL,
	[Sinopsis] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdObra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ObraGenero]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ObraGenero](
	[IdObraGenero] [int] IDENTITY(1,1) NOT NULL,
	[FKObra] [int] NOT NULL,
	[FKGenero] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdObraGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Socio]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Socio](
	[IdSocio] [int] IDENTITY(1,1) NOT NULL,
	[Apellido] [varchar](40) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Email] [varchar](60) NOT NULL,
	[Domicilio] [varchar](80) NULL,
	[Telefono] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubicacion]    Script Date: 26/11/2024 18:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubicacion](
	[IdUbicacion] [int] IDENTITY(1,1) NOT NULL,
	[Estanteria] [int] NOT NULL,
	[Fila] [char](3) NOT NULL,
	[Columna] [char](3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUbicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alquiler] ON 
GO
INSERT [dbo].[Alquiler] ([IdAlquiler], [FechaAlquiler], [FechaDevProbable], [FKSocio], [FKBibliotecario]) VALUES (1, CAST(N'2024-11-26T18:36:31.193' AS DateTime), CAST(N'2024-12-11' AS Date), 1, 1)
GO
INSERT [dbo].[Alquiler] ([IdAlquiler], [FechaAlquiler], [FechaDevProbable], [FKSocio], [FKBibliotecario]) VALUES (2, CAST(N'2024-11-26T18:36:31.193' AS DateTime), CAST(N'2024-12-11' AS Date), 2, 2)
GO
INSERT [dbo].[Alquiler] ([IdAlquiler], [FechaAlquiler], [FechaDevProbable], [FKSocio], [FKBibliotecario]) VALUES (3, CAST(N'2024-11-26T18:36:31.193' AS DateTime), CAST(N'2024-12-11' AS Date), 3, 3)
GO
INSERT [dbo].[Alquiler] ([IdAlquiler], [FechaAlquiler], [FechaDevProbable], [FKSocio], [FKBibliotecario]) VALUES (4, CAST(N'2024-11-26T18:36:31.193' AS DateTime), CAST(N'2024-12-11' AS Date), 4, 4)
GO
INSERT [dbo].[Alquiler] ([IdAlquiler], [FechaAlquiler], [FechaDevProbable], [FKSocio], [FKBibliotecario]) VALUES (5, CAST(N'2024-11-26T18:36:31.193' AS DateTime), CAST(N'2024-12-11' AS Date), 5, 5)
GO
SET IDENTITY_INSERT [dbo].[Alquiler] OFF
GO
SET IDENTITY_INSERT [dbo].[AlquilerEjemplar] ON 
GO
INSERT [dbo].[AlquilerEjemplar] ([IdAlquilerEjemplar], [FKAlquiler], [FKEjemplar], [FechaDevReal]) VALUES (1, 1, 1, NULL)
GO
INSERT [dbo].[AlquilerEjemplar] ([IdAlquilerEjemplar], [FKAlquiler], [FKEjemplar], [FechaDevReal]) VALUES (2, 2, 2, NULL)
GO
INSERT [dbo].[AlquilerEjemplar] ([IdAlquilerEjemplar], [FKAlquiler], [FKEjemplar], [FechaDevReal]) VALUES (3, 3, 3, NULL)
GO
INSERT [dbo].[AlquilerEjemplar] ([IdAlquilerEjemplar], [FKAlquiler], [FKEjemplar], [FechaDevReal]) VALUES (4, 4, 4, NULL)
GO
INSERT [dbo].[AlquilerEjemplar] ([IdAlquilerEjemplar], [FKAlquiler], [FKEjemplar], [FechaDevReal]) VALUES (5, 5, 5, NULL)
GO
SET IDENTITY_INSERT [dbo].[AlquilerEjemplar] OFF
GO
SET IDENTITY_INSERT [dbo].[Autor] ON 
GO
INSERT [dbo].[Autor] ([IdAutor], [Apellido1], [Apellido2], [Nombre]) VALUES (1, N'García', N'López', N'Miguel')
GO
INSERT [dbo].[Autor] ([IdAutor], [Apellido1], [Apellido2], [Nombre]) VALUES (2, N'Borges', NULL, N'Jorge Luis')
GO
INSERT [dbo].[Autor] ([IdAutor], [Apellido1], [Apellido2], [Nombre]) VALUES (3, N'Shakespeare', NULL, N'William')
GO
INSERT [dbo].[Autor] ([IdAutor], [Apellido1], [Apellido2], [Nombre]) VALUES (4, N'Poe', NULL, N'Edgar Allan')
GO
INSERT [dbo].[Autor] ([IdAutor], [Apellido1], [Apellido2], [Nombre]) VALUES (5, N'Cervantes', NULL, N'Miguel de')
GO
SET IDENTITY_INSERT [dbo].[Autor] OFF
GO
SET IDENTITY_INSERT [dbo].[AutorObra] ON 
GO
INSERT [dbo].[AutorObra] ([IdAutorObra], [FKObra], [FKAutor]) VALUES (1, 1, 1)
GO
INSERT [dbo].[AutorObra] ([IdAutorObra], [FKObra], [FKAutor]) VALUES (2, 2, 2)
GO
INSERT [dbo].[AutorObra] ([IdAutorObra], [FKObra], [FKAutor]) VALUES (3, 3, 3)
GO
INSERT [dbo].[AutorObra] ([IdAutorObra], [FKObra], [FKAutor]) VALUES (4, 4, 4)
GO
INSERT [dbo].[AutorObra] ([IdAutorObra], [FKObra], [FKAutor]) VALUES (5, 5, 5)
GO
SET IDENTITY_INSERT [dbo].[AutorObra] OFF
GO
SET IDENTITY_INSERT [dbo].[Bibliotecario] ON 
GO
INSERT [dbo].[Bibliotecario] ([IdBibliotecario], [Apellido], [Nombre], [Email], [Contrasenia]) VALUES (1, N'Pérez', N'Juan', N'juan.perez@biblioteca.com', N'12345')
GO
INSERT [dbo].[Bibliotecario] ([IdBibliotecario], [Apellido], [Nombre], [Email], [Contrasenia]) VALUES (2, N'González', N'Ana', N'ana.gonzalez@biblioteca.com', N'67890')
GO
INSERT [dbo].[Bibliotecario] ([IdBibliotecario], [Apellido], [Nombre], [Email], [Contrasenia]) VALUES (3, N'Lopez', N'Carlos', N'carlos.lopez@biblioteca.com', N'abc123')
GO
INSERT [dbo].[Bibliotecario] ([IdBibliotecario], [Apellido], [Nombre], [Email], [Contrasenia]) VALUES (4, N'Martínez', N'Laura', N'laura.martinez@biblioteca.com', N'qwerty')
GO
INSERT [dbo].[Bibliotecario] ([IdBibliotecario], [Apellido], [Nombre], [Email], [Contrasenia]) VALUES (5, N'Rodríguez', N'Marta', N'marta.rodriguez@biblioteca.com', N'pass123')
GO
SET IDENTITY_INSERT [dbo].[Bibliotecario] OFF
GO
SET IDENTITY_INSERT [dbo].[Editorial] ON 
GO
INSERT [dbo].[Editorial] ([IdEditorial], [Descripcion]) VALUES (1, N'Planeta')
GO
INSERT [dbo].[Editorial] ([IdEditorial], [Descripcion]) VALUES (2, N'Penguin')
GO
INSERT [dbo].[Editorial] ([IdEditorial], [Descripcion]) VALUES (3, N'Alianza')
GO
INSERT [dbo].[Editorial] ([IdEditorial], [Descripcion]) VALUES (4, N'Santillana')
GO
INSERT [dbo].[Editorial] ([IdEditorial], [Descripcion]) VALUES (5, N'Tusquets')
GO
SET IDENTITY_INSERT [dbo].[Editorial] OFF
GO
SET IDENTITY_INSERT [dbo].[Ejemplar] ON 
GO
INSERT [dbo].[Ejemplar] ([IdEjemplar], [CodigoBarras], [ISBN], [AnioPublicacion], [EstaBuenEstado], [NumPaginas], [EstaAlquilado], [FKEditorial], [FKObra], [FkUbicacion], [FkIdioma]) VALUES (1, N'1234567890123', N'9781234567890', 2001, 1, 300, 0, 1, 1, 1, 5)
GO
INSERT [dbo].[Ejemplar] ([IdEjemplar], [CodigoBarras], [ISBN], [AnioPublicacion], [EstaBuenEstado], [NumPaginas], [EstaAlquilado], [FKEditorial], [FKObra], [FkUbicacion], [FkIdioma]) VALUES (2, N'2345678901234', N'9782345678901', 1995, 1, 250, 0, 2, 2, 2, 4)
GO
INSERT [dbo].[Ejemplar] ([IdEjemplar], [CodigoBarras], [ISBN], [AnioPublicacion], [EstaBuenEstado], [NumPaginas], [EstaAlquilado], [FKEditorial], [FKObra], [FkUbicacion], [FkIdioma]) VALUES (3, N'3456789012345', N'9783456789012', 2003, 1, 350, 1, 3, 3, 3, 3)
GO
INSERT [dbo].[Ejemplar] ([IdEjemplar], [CodigoBarras], [ISBN], [AnioPublicacion], [EstaBuenEstado], [NumPaginas], [EstaAlquilado], [FKEditorial], [FKObra], [FkUbicacion], [FkIdioma]) VALUES (4, N'4567890123456', N'9784567890123', 2010, 1, 150, 0, 4, 4, 4, 2)
GO
INSERT [dbo].[Ejemplar] ([IdEjemplar], [CodigoBarras], [ISBN], [AnioPublicacion], [EstaBuenEstado], [NumPaginas], [EstaAlquilado], [FKEditorial], [FKObra], [FkUbicacion], [FkIdioma]) VALUES (5, N'5678901234567', N'9785678901234', 2020, 1, 400, 1, 5, 5, 5, 1)
GO
SET IDENTITY_INSERT [dbo].[Ejemplar] OFF
GO
SET IDENTITY_INSERT [dbo].[Genero] ON 
GO
INSERT [dbo].[Genero] ([IdGenero], [Descripcion]) VALUES (1, N'Ficción')
GO
INSERT [dbo].[Genero] ([IdGenero], [Descripcion]) VALUES (2, N'No Ficción')
GO
INSERT [dbo].[Genero] ([IdGenero], [Descripcion]) VALUES (3, N'Ciencia Ficción')
GO
INSERT [dbo].[Genero] ([IdGenero], [Descripcion]) VALUES (4, N'Historia')
GO
INSERT [dbo].[Genero] ([IdGenero], [Descripcion]) VALUES (5, N'Romántico')
GO
SET IDENTITY_INSERT [dbo].[Genero] OFF
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 
GO
INSERT [dbo].[Idioma] ([IdIdioma], [Descripcion]) VALUES (1, N'Español')
GO
INSERT [dbo].[Idioma] ([IdIdioma], [Descripcion]) VALUES (2, N'Inglés')
GO
INSERT [dbo].[Idioma] ([IdIdioma], [Descripcion]) VALUES (3, N'Francés')
GO
INSERT [dbo].[Idioma] ([IdIdioma], [Descripcion]) VALUES (4, N'Alemán')
GO
INSERT [dbo].[Idioma] ([IdIdioma], [Descripcion]) VALUES (5, N'Italiano')
GO
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[Obra] ON 
GO
INSERT [dbo].[Obra] ([IdObra], [Titulo], [Sinopsis]) VALUES (1, N'Don Quijote de la Mancha', N'Historia de un caballero que lucha contra molinos de viento.')
GO
INSERT [dbo].[Obra] ([IdObra], [Titulo], [Sinopsis]) VALUES (2, N'1984', N'Una novela distópica sobre un régimen totalitario.')
GO
INSERT [dbo].[Obra] ([IdObra], [Titulo], [Sinopsis]) VALUES (3, N'Cien años de soledad', N'La saga de la familia Buendía en Macondo.')
GO
INSERT [dbo].[Obra] ([IdObra], [Titulo], [Sinopsis]) VALUES (4, N'El Aleph', N'Una colección de relatos de lo fantástico y lo misterioso.')
GO
INSERT [dbo].[Obra] ([IdObra], [Titulo], [Sinopsis]) VALUES (5, N'El Hobbit', N'Aventura de un hobbit que viaja con un grupo de enanos.')
GO
SET IDENTITY_INSERT [dbo].[Obra] OFF
GO
SET IDENTITY_INSERT [dbo].[ObraGenero] ON 
GO
INSERT [dbo].[ObraGenero] ([IdObraGenero], [FKObra], [FKGenero]) VALUES (1, 1, 1)
GO
INSERT [dbo].[ObraGenero] ([IdObraGenero], [FKObra], [FKGenero]) VALUES (2, 2, 2)
GO
INSERT [dbo].[ObraGenero] ([IdObraGenero], [FKObra], [FKGenero]) VALUES (3, 3, 3)
GO
INSERT [dbo].[ObraGenero] ([IdObraGenero], [FKObra], [FKGenero]) VALUES (4, 4, 1)
GO
INSERT [dbo].[ObraGenero] ([IdObraGenero], [FKObra], [FKGenero]) VALUES (5, 5, 4)
GO
SET IDENTITY_INSERT [dbo].[ObraGenero] OFF
GO
SET IDENTITY_INSERT [dbo].[Socio] ON 
GO
INSERT [dbo].[Socio] ([IdSocio], [Apellido], [Nombre], [Email], [Domicilio], [Telefono]) VALUES (1, N'Ramírez', N'Pedro', N'pedro.ramirez@socio.com', N'Av. Siempre Viva 123', N'555-1234')
GO
INSERT [dbo].[Socio] ([IdSocio], [Apellido], [Nombre], [Email], [Domicilio], [Telefono]) VALUES (2, N'Sánchez', N'Lucía', N'lucia.sanchez@socio.com', N'Calle Falsa 456', N'555-5678')
GO
INSERT [dbo].[Socio] ([IdSocio], [Apellido], [Nombre], [Email], [Domicilio], [Telefono]) VALUES (3, N'Martínez', N'Julio', N'julio.martinez@socio.com', N'Calle Real 789', N'555-8765')
GO
INSERT [dbo].[Socio] ([IdSocio], [Apellido], [Nombre], [Email], [Domicilio], [Telefono]) VALUES (4, N'Fernández', N'Elena', N'elena.fernandez@socio.com', N'Calle Sol 101', N'555-3456')
GO
INSERT [dbo].[Socio] ([IdSocio], [Apellido], [Nombre], [Email], [Domicilio], [Telefono]) VALUES (5, N'Díaz', N'Esteban', N'esteban.diaz@socio.com', N'Avenida del Mar 202', N'555-6543')
GO
SET IDENTITY_INSERT [dbo].[Socio] OFF
GO
SET IDENTITY_INSERT [dbo].[Ubicacion] ON 
GO
INSERT [dbo].[Ubicacion] ([IdUbicacion], [Estanteria], [Fila], [Columna]) VALUES (1, 1, N'A01', N'B02')
GO
INSERT [dbo].[Ubicacion] ([IdUbicacion], [Estanteria], [Fila], [Columna]) VALUES (2, 2, N'B02', N'C03')
GO
INSERT [dbo].[Ubicacion] ([IdUbicacion], [Estanteria], [Fila], [Columna]) VALUES (3, 3, N'C03', N'D01')
GO
INSERT [dbo].[Ubicacion] ([IdUbicacion], [Estanteria], [Fila], [Columna]) VALUES (4, 4, N'A01', N'E01')
GO
INSERT [dbo].[Ubicacion] ([IdUbicacion], [Estanteria], [Fila], [Columna]) VALUES (5, 5, N'D02', N'A02')
GO
SET IDENTITY_INSERT [dbo].[Ubicacion] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Bibliote__A9D1053426FDB6EF]    Script Date: 26/11/2024 18:56:34 ******/
ALTER TABLE [dbo].[Bibliotecario] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Socio__A9D10534BAA568CC]    Script Date: 26/11/2024 18:56:34 ******/
ALTER TABLE [dbo].[Socio] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alquiler] ADD  DEFAULT (getdate()) FOR [FechaAlquiler]
GO
ALTER TABLE [dbo].[Alquiler] ADD  DEFAULT (dateadd(day,(15),getdate())) FOR [FechaDevProbable]
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD  CONSTRAINT [FKBibliotecario] FOREIGN KEY([FKBibliotecario])
REFERENCES [dbo].[Bibliotecario] ([IdBibliotecario])
GO
ALTER TABLE [dbo].[Alquiler] CHECK CONSTRAINT [FKBibliotecario]
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD  CONSTRAINT [FKSocio] FOREIGN KEY([FKSocio])
REFERENCES [dbo].[Socio] ([IdSocio])
GO
ALTER TABLE [dbo].[Alquiler] CHECK CONSTRAINT [FKSocio]
GO
ALTER TABLE [dbo].[AlquilerEjemplar]  WITH CHECK ADD  CONSTRAINT [FKAlquiler] FOREIGN KEY([FKAlquiler])
REFERENCES [dbo].[Alquiler] ([IdAlquiler])
GO
ALTER TABLE [dbo].[AlquilerEjemplar] CHECK CONSTRAINT [FKAlquiler]
GO
ALTER TABLE [dbo].[AlquilerEjemplar]  WITH CHECK ADD  CONSTRAINT [FKEjemplar] FOREIGN KEY([FKEjemplar])
REFERENCES [dbo].[Ejemplar] ([IdEjemplar])
GO
ALTER TABLE [dbo].[AlquilerEjemplar] CHECK CONSTRAINT [FKEjemplar]
GO
ALTER TABLE [dbo].[AutorObra]  WITH CHECK ADD  CONSTRAINT [FKAutor] FOREIGN KEY([FKAutor])
REFERENCES [dbo].[Autor] ([IdAutor])
GO
ALTER TABLE [dbo].[AutorObra] CHECK CONSTRAINT [FKAutor]
GO
ALTER TABLE [dbo].[AutorObra]  WITH CHECK ADD  CONSTRAINT [FKObraAutor] FOREIGN KEY([FKObra])
REFERENCES [dbo].[Obra] ([IdObra])
GO
ALTER TABLE [dbo].[AutorObra] CHECK CONSTRAINT [FKObraAutor]
GO
ALTER TABLE [dbo].[Ejemplar]  WITH CHECK ADD  CONSTRAINT [FKEditorial] FOREIGN KEY([FKEditorial])
REFERENCES [dbo].[Editorial] ([IdEditorial])
GO
ALTER TABLE [dbo].[Ejemplar] CHECK CONSTRAINT [FKEditorial]
GO
ALTER TABLE [dbo].[Ejemplar]  WITH CHECK ADD  CONSTRAINT [FkIdioma] FOREIGN KEY([FkIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[Ejemplar] CHECK CONSTRAINT [FkIdioma]
GO
ALTER TABLE [dbo].[Ejemplar]  WITH CHECK ADD  CONSTRAINT [FKObra] FOREIGN KEY([FKObra])
REFERENCES [dbo].[Obra] ([IdObra])
GO
ALTER TABLE [dbo].[Ejemplar] CHECK CONSTRAINT [FKObra]
GO
ALTER TABLE [dbo].[Ejemplar]  WITH CHECK ADD  CONSTRAINT [FkUbicacion] FOREIGN KEY([FkUbicacion])
REFERENCES [dbo].[Ubicacion] ([IdUbicacion])
GO
ALTER TABLE [dbo].[Ejemplar] CHECK CONSTRAINT [FkUbicacion]
GO
ALTER TABLE [dbo].[ObraGenero]  WITH CHECK ADD  CONSTRAINT [FKGenero] FOREIGN KEY([FKGenero])
REFERENCES [dbo].[Genero] ([IdGenero])
GO
ALTER TABLE [dbo].[ObraGenero] CHECK CONSTRAINT [FKGenero]
GO
ALTER TABLE [dbo].[ObraGenero]  WITH CHECK ADD  CONSTRAINT [FKObraGenero] FOREIGN KEY([FKObra])
REFERENCES [dbo].[Obra] ([IdObra])
GO
ALTER TABLE [dbo].[ObraGenero] CHECK CONSTRAINT [FKObraGenero]
GO
ALTER TABLE [dbo].[Ejemplar]  WITH CHECK ADD  CONSTRAINT [CHKAnioPublicacion] CHECK  (([AnioPublicacion]>=(1500) AND [AnioPublicacion]<=datepart(year,getdate())))
GO
ALTER TABLE [dbo].[Ejemplar] CHECK CONSTRAINT [CHKAnioPublicacion]
GO
