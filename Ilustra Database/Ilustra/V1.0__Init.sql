CREATE TABLE Persona
(
	IdPersona INT IDENTITY(1,1),
	Nombre NVARCHAR(200) NOT NULL,
	Apellido NVARCHAR(200) NOT NULL,
	TipoDocumento NVARCHAR(50) NOT NULL,
	NumeroDocumento NVARCHAR(10) NOT NULL,
	FechaNacimiento DATETIME,
	CorreoElectronico NVARCHAR(50),
	Telefono NVARCHAR(15),
	Direccion NVARCHAR(100),
	Departamento NVARCHAR(100),
	Provincia NVARCHAR(100),
	DIstrito NVARCHAR(100),
	FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
	FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	Eliminado BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Persona PRIMARY KEY (IdPersona)
)

--Cliente, Administrador y Aliado
CREATE TABLE Perfil
(
	IdPerfil INT IDENTITY(1,1),
	Descripcion VARCHAR(50) NOT NULL,
	FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
	FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	Eliminado BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Perfil PRIMARY KEY (IdPerfil)
)

CREATE TABLE Usuario
(
	IdUsuario INT IDENTITY(1,1),
	Persona INT,
	Perfil INT NOT NULL,
	Username NVARCHAR(200) NOT NULL,
	Password NVARCHAR(200) NOT NULL,
	PasswordAnterior NVARCHAR(200),
	CodigoVerificacion NVARCHAR(200),
	Activo BIT DEFAULT 1 NOT NULL,
	FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
	FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	Eliminado BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Usuario PRIMARY KEY (IdUsuario),
	CONSTRAINT FK_PerfilUsuario FOREIGN KEY (Perfil) REFERENCES Perfil(IdPerfil),
	CONSTRAINT FK_UsuarioPersona FOREIGN KEY (Persona) REFERENCES Persona(IdPersona)
)

--SE ARMA CUANDO EL ALIADO CONFIGURE SU USUARIO
CREATE TABLE Aliado
(
	IdAliado INT IDENTITY(1,1),
	Persona INT,
	NombreComercial NVARCHAR(200) NOT NULL,
	CodigoArchivoLogo NVARCHAR(MAX), --GUID,
	DecripcionComercial NVARCHAR(500),
	FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
	FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	Eliminado BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Aliado PRIMARY KEY (IdAliado),
	CONSTRAINT FK_AliadoPersona FOREIGN KEY (Persona) REFERENCES Persona(IdPersona)
)

CREATE TABLE Disenio
(
	IdDisenio INT IDENTITY(1,1),
	Aliado INT,
	CodigoImagen NVARCHAR(MAX), -- GUID
	NombrePrincipal NVARCHAR(200) NOT NULL,
	Descripcion NVARCHAR(500),
	FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
	FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	Eliminado BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Disenio PRIMARY KEY (IdDisenio),
	CONSTRAINT FK_DisenioAliado FOREIGN KEY (Aliado) REFERENCES Aliado(IdAliado)
) 

--TIPOS DE PRODUCTOS
CREATE TABLE Categoria 
(
	IdCategoria INT IDENTITY(1,1),
	NombreCategoria NVARCHAR(200) NOT NULL,
	FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
	FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	CONSTRAINT PK_Categoria PRIMARY KEY (IdCategoria)
)

CREATE TABLE Dimension
(
	IdDimension INT IDENTITY(1,1),
	NombreDimension NVARCHAR(50) NOT NULL,
	FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
	FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	CONSTRAINT PK_Dimension PRIMARY KEY (IdDimension)
)

CREATE TABLE Producto
(
	IdProducto INT IDENTITY(1,1),
	Categoria INT,
	Dimension INT,
	CodigoImagen NVARCHAR(MAX), --GUID
	NombreProducto NVARCHAR(200) NOT NULL,
	Colores NVARCHAR(200),
	Descripcion NVARCHAR(200),
	PrecioBase DECIMAL(9,2) NOT NULL,
	FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
	FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	Eliminado BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Producto PRIMARY KEY (IdProducto),
	CONSTRAINT FK_CategoriaProducto FOREIGN KEY (Categoria) REFERENCES Categoria(IdCategoria),
	CONSTRAINT FK_DimensionProducto FOREIGN KEY (Dimension) REFERENCES Dimension(IdDimension)
)

--CONTROL DE DISENIOS POR PRODUCTO
CREATE TABLE DisenioProducto
(
	IdDisenioProducto INT IDENTITY(1,1),
	Disenio INT NOT NULL,
	Producto INT NOT NULL,
	PrecioVentaComercial DECIMAL(9,2) NOT NULL,
	CONSTRAINT PK_DisenioProducto PRIMARY KEY (IdDisenioProducto),
	CONSTRAINT FK_DisenioXProducto FOREIGN KEY (Disenio) REFERENCES Disenio(IdDisenio),
	CONSTRAINT FK_ProductoXDisenio FOREIGN KEY (Producto) REFERENCES Producto(IdProducto),
)

--Almacena colores creados para los productos
CREATE TABLE Color
(
	IdColor INT IDENTITY(1,1),
	CodigoColor NVARCHAR(MAX) NOT NULL, -- GUID
	Descripcion NVARCHAR(200) NOT NULL,
	FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
	FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	Eliminado BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Color PRIMARY KEY (IdColor)
)

--Table de archivos en general --> Base64 encode
CREATE TABLE Archivo
(
	IdArchivo INT IDENTITY(1,1),
	CodigoEntidad NVARCHAR(MAX) NOT NULL, -- GUID
	NombreArchivo NVARCHAR(200),
	TipoArchivo NVARCHAR(50),
	Content VARBINARY(MAX), 
	FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
	FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	Eliminado BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Archivo PRIMARY KEY (IdArchivo)
)


CREATE TABLE CarritoCompra
(
	IdCarritoCompra INT IDENTITY(1,1),
	SubTotal DECIMAL(9,2) NOT NULL,
	CodigoCupon NVARCHAR(MAX), --GUID
	DescuentoCupon DECIMAL(9,2),
	PrecitoTotal DECIMAL(9,2) NOT NULL,
	CONSTRAINT PK_CarritoCompra PRIMARY KEY (IdCarritoCompra)
)

CREATE TABLE ItemCarrito
(
	IdItemCarrito INT IDENTITY(1,1),
	CarritoCompra INT,
	DisenioProducto INT NOT NULL,
	Color INT NOT NULL,
	PrecioFinal DECIMAL(9,2),
	CONSTRAINT PK_ItemCarrito PRIMARY KEY (IdItemCarrito),
	CONSTRAINT FK_ItemCarritoProducto FOREIGN KEY (DisenioProducto) REFERENCES DisenioProducto(IdDisenioProducto),
	CONSTRAINT FK_ItemCarritoColor FOREIGN KEY (Color) REFERENCES Color(IdColor),
	CONSTRAINT FK_ItemCarritoCompra FOREIGN KEY (CarritoCompra) REFERENCES CarritoCompra(IdCarritoCompra)
)

--Tipo GENERAL Y PARTICULAR
CREATE TABLE Cupon
(
	IdCupon INT IDENTITY(1,1),
	Usuario INT,
	CodigoCupon NVARCHAR(MAX), -- GUID
	Activo BIT DEFAULT 1,
	FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
	FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	Eliminado BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Cupon PRIMARY KEY (IdCupon),
	CONSTRAINT FK_UsuarioCupon FOREIGN KEY (Usuario) REFERENCES Usuario(IdUsuario)
)

--INTERMEDIAS
CREATE TABLE ProductoXColor
(
	Producto INT NOT NULL,
	Color INT NOT NULL,
	CONSTRAINT FK_ProductoXColor FOREIGN KEY (Producto) REFERENCES Producto(IdProducto),
	CONSTRAINT FK_ColorXProducto FOREIGN KEY (Color) REFERENCES Color(IdColor)
)


