
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/04/2015 11:26:57
-- Generated from EDMX file: C:\Users\luciana.cavalieri\Downloads\WebApplicationTURMAR\WebApplicationTUR\DAL\TurismoReceptivoModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TurismoReceptivo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Ciudades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ciudades];
GO
IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[Cuenta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuenta];
GO
IF OBJECT_ID(N'[dbo].[Divisas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Divisas];
GO
IF OBJECT_ID(N'[dbo].[Hotel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hotel];
GO
IF OBJECT_ID(N'[dbo].[Operador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operador];
GO
IF OBJECT_ID(N'[dbo].[PrecioHotelDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrecioHotelDetail];
GO
IF OBJECT_ID(N'[dbo].[ProgramaDetallePrecio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProgramaDetallePrecio];
GO
IF OBJECT_ID(N'[dbo].[Programas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Programas];
GO
IF OBJECT_ID(N'[dbo].[Servicio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servicio];
GO
IF OBJECT_ID(N'[dbo].[ServicioDetalleIdiomas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServicioDetalleIdiomas];
GO
IF OBJECT_ID(N'[dbo].[ServicioPrecio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServicioPrecio];
GO
IF OBJECT_ID(N'[dbo].[Imagenes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Imagenes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Ciudades'
CREATE TABLE [dbo].[Ciudades] (
    [Id] int  NOT NULL,
    [Pais] nvarchar(50)  NULL,
    [Codigo] nvarchar(50)  NULL,
    [Nombre] nvarchar(50)  NULL,
    [CodInt] nvarchar(50)  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'Cliente'
CREATE TABLE [dbo].[Cliente] (
    [Id] int  NOT NULL,
    [Apellido] nvarchar(50)  NULL,
    [Nombre] nvarchar(50)  NULL,
    [Passport] nvarchar(50)  NULL,
    [Lenguaje] nvarchar(50)  NULL,
    [Direccion] nvarchar(50)  NULL,
    [Ciudad] nvarchar(50)  NULL,
    [Pais] nvarchar(50)  NULL,
    [Telefono] nvarchar(50)  NULL,
    [Email1] nvarchar(50)  NULL,
    [Email2] nvarchar(50)  NULL,
    [Contacto] nvarchar(50)  NULL,
    [Fechaarribo] datetime  NULL,
    [Ticketaereo] nvarchar(50)  NULL,
    [Fecharegreso] datetime  NULL,
    [Observaciones] nvarchar(50)  NULL,
    [PAX] nvarchar(50)  NULL,
    [Paquete] int  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'Cuenta'
CREATE TABLE [dbo].[Cuenta] (
    [Id] int  NOT NULL,
    [Nombre] nvarchar(10)  NULL,
    [Pass] nvarchar(10)  NULL,
    [DNI] nvarchar(10)  NULL,
    [Email] nvarchar(50)  NULL,
    [CodigoVendedor] nvarchar(10)  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'Divisas'
CREATE TABLE [dbo].[Divisas] (
    [Id] int  NOT NULL,
    [Nombre] nvarchar(50)  NULL,
    [Codigo] nvarchar(10)  NULL,
    [Cambio] decimal(18,2)  NULL,
    [Simbolo] nvarchar(10)  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'Hotel'
CREATE TABLE [dbo].[Hotel] (
    [Id] int  NOT NULL,
    [Categoria] nvarchar(10)  NULL,
    [Nombre] nvarchar(50)  NULL,
    [Observacion] nvarchar(max)  NULL,
    [Direccion] nvarchar(50)  NULL,
    [Contacto] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [NombreBco] nvarchar(50)  NULL,
    [NroCuenta] nvarchar(50)  NULL,
    [DireccionBco] nvarchar(50)  NULL,
    [Cuit] nvarchar(50)  NULL,
    [CBU] nvarchar(50)  NULL,
    [Checkin] nvarchar(10)  NULL,
    [Checkout] nvarchar(10)  NULL,
    [Ciudad] int  NULL,
    [ObservacionBco] nvarchar(50)  NULL,
    [Telefono] nvarchar(50)  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'Operador'
CREATE TABLE [dbo].[Operador] (
    [Id] int  NOT NULL,
    [Nombre] nvarchar(50)  NULL,
    [Ciudad] int  NULL,
    [Direccion] nvarchar(50)  NULL,
    [CodPostal] nvarchar(50)  NULL,
    [Telefono] nvarchar(50)  NULL,
    [Fax] nvarchar(50)  NULL,
    [Contacto] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [NombreBco] nvarchar(50)  NULL,
    [NroCuenta] nvarchar(50)  NULL,
    [DireccionBco] nvarchar(50)  NULL,
    [CUIT] nvarchar(50)  NULL,
    [CBU] nvarchar(50)  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'PrecioHotelDetail'
CREATE TABLE [dbo].[PrecioHotelDetail] (
    [Id] int  NOT NULL,
    [IdHotel] int  NULL,
    [PrecioDolar] decimal(18,2)  NULL,
    [PrecioPeso] decimal(18,2)  NULL,
    [TipoHabitacion] nvarchar(50)  NULL,
    [FechaDesde] datetime  NULL,
    [FechaHasta] datetime  NULL,
    [Nombre] nvarchar(50)  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'ProgramaDetallePrecio'
CREATE TABLE [dbo].[ProgramaDetallePrecio] (
    [Id] int  NOT NULL,
    [IdPrograma] int  NOT NULL,
    [fechaDesde] datetime  NULL,
    [fechaHasta] datetime  NULL,
    [idHotel] int  NULL,
    [TipoHab] nvarchar(50)  NULL,
    [noches] int  NULL,
    [cantHabitaciones] int  NULL,
    [tiposervicio] nvarchar(50)  NULL,
    [cantPasajeros] int  NULL,
    [tipoAereo] nvarchar(50)  NULL,
    [costoUnit] decimal(18,2)  NULL,
    [costoTotal] decimal(18,2)  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'Programas'
CREATE TABLE [dbo].[Programas] (
    [Id] int  NOT NULL,
    [TituloPrograma] nvarchar(50)  NULL,
    [FechaStarte] datetime  NULL,
    [FechaEnd] datetime  NULL,
    [CantDias] int  NULL,
    [Categoria] nvarchar(50)  NULL,
    [FechaValidez] datetime  NULL,
    [Dolar] decimal(18,2)  NULL,
    [Euro] decimal(18,2)  NULL,
    [Margen] decimal(18,2)  NULL,
    [Descuento] decimal(18,2)  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'Servicio'
CREATE TABLE [dbo].[Servicio] (
    [Id] int  NOT NULL,
    [Actividad] nvarchar(50)  NULL,
    [DiasCant] int  NULL,
    [Nombre] nvarchar(50)  NULL,
    [TipoTranfer] nvarchar(50)  NULL,
    [Operador] int  NULL,
    [Ciudad] int  NULL,
    [CiudadOrigen] int  NULL,
    [CiudadDestino] int  NULL,
    [HoraSalida] nvarchar(10)  NULL,
    [HoraLlegada] nvarchar(10)  NULL,
    [Deleted] bit  NULL,
    [Image] int  NULL,
    [Observacion] nvarchar(50)  NULL
);
GO

-- Creating table 'ServicioDetalleIdiomas'
CREATE TABLE [dbo].[ServicioDetalleIdiomas] (
    [Id] int  NOT NULL,
    [IdServicio] int  NULL,
    [NombreES] nvarchar(50)  NULL,
    [DescripcionEs] nvarchar(max)  NULL,
    [NombreEN] nvarchar(50)  NULL,
    [DescripcionEN] nvarchar(max)  NULL,
    [NombrePT] nvarchar(50)  NULL,
    [DescripcionPT] nvarchar(max)  NULL,
    [NombreIT] nvarchar(50)  NULL,
    [DetalleIT] nvarchar(max)  NULL,
    [NumeroDia] int  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'ServicioPrecio'
CREATE TABLE [dbo].[ServicioPrecio] (
    [Id] int  NOT NULL,
    [IdOperador] int  NULL,
    [FechaDesde] datetime  NULL,
    [FechaHasta] datetime  NULL,
    [Moneda] nvarchar(50)  NULL,
    [IdServicio] int  NULL,
    [Precio] decimal(18,2)  NULL,
    [TipoServicio] nvarchar(50)  NULL,
    [Deleted] bit  NULL,
    [Unit] bit  NULL
);
GO

-- Creating table 'Imagenes'
CREATE TABLE [dbo].[Imagenes] (
    [ID] int  NOT NULL,
    [Imagen] varbinary(max)  NULL,
    [NombreImagen] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Ciudades'
ALTER TABLE [dbo].[Ciudades]
ADD CONSTRAINT [PK_Ciudades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cuenta'
ALTER TABLE [dbo].[Cuenta]
ADD CONSTRAINT [PK_Cuenta]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Divisas'
ALTER TABLE [dbo].[Divisas]
ADD CONSTRAINT [PK_Divisas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Hotel'
ALTER TABLE [dbo].[Hotel]
ADD CONSTRAINT [PK_Hotel]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operador'
ALTER TABLE [dbo].[Operador]
ADD CONSTRAINT [PK_Operador]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PrecioHotelDetail'
ALTER TABLE [dbo].[PrecioHotelDetail]
ADD CONSTRAINT [PK_PrecioHotelDetail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProgramaDetallePrecio'
ALTER TABLE [dbo].[ProgramaDetallePrecio]
ADD CONSTRAINT [PK_ProgramaDetallePrecio]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Programas'
ALTER TABLE [dbo].[Programas]
ADD CONSTRAINT [PK_Programas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Servicio'
ALTER TABLE [dbo].[Servicio]
ADD CONSTRAINT [PK_Servicio]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServicioDetalleIdiomas'
ALTER TABLE [dbo].[ServicioDetalleIdiomas]
ADD CONSTRAINT [PK_ServicioDetalleIdiomas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServicioPrecio'
ALTER TABLE [dbo].[ServicioPrecio]
ADD CONSTRAINT [PK_ServicioPrecio]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'Imagenes'
ALTER TABLE [dbo].[Imagenes]
ADD CONSTRAINT [PK_Imagenes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------