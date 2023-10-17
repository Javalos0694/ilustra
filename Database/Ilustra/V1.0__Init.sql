CREATE TABLE DocumentType 
(
	idDocumentType INT NOT NULL IDENTITY(100001, 1),
	documentName VARCHAR(50) NOT NULL,
	description VARCHAR(200),
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_documentType PRIMARY KEY (idDocumentType)
)

CREATE TABLE Person 
(
	idPerson INT IDENTITY(100001,1) NOT NULL,
	firstName VARCHAR(100) NOT NULL,
	lastName VARCHAR(100) NOT NULL,
	phoneNumber VARCHAR(10) NOT NULL,
	idDocumentType INT NOT NULL,
	documentNumber VARCHAR(10) NOT NULL,
	email VARCHAR(100) NOT NULL,
	bornDate DATE NOT NULL,
	address VARCHAR(200),
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idPerson PRIMARY KEY (idPerson),
	CONSTRAINT FK_documentType_person FOREIGN KEY  (idDocumentType) REFERENCES DocumentType
)

CREATE TABLE UserType
(
	idUserType INT IDENTITY(100001,1) NOT NULL,
	userType VARCHAR(10) NOT NULL,
	description VARCHAR(200),
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idUserType PRIMARY KEY (idUserType)
)

CREATE TABLE [User]
(
	idUser INT IDENTITY(100001,1) NOT NULL,
	idPerson INT NOT NULL,
	username VARCHAR(50) NOT NULL,
	password VARCHAR(200) NOT NULL,
	idUserType INT NOT NULL,
	recoveryPasswordCode VARCHAR(200),
	lastPassword VARCHAR(200),
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idUser PRIMARY KEY (idUser),
	CONSTRAINT FK_userType_User FOREIGN KEY (idUserType) REFERENCES UserType,
	CONSTRAINT FK_Person_User FOREIGN KEY (idPerson) REFERENCES Person
)

CREATE TABLE Ally
(
	idAlly INT IDENTITY(100001,1) NOT NULL,
	idUser INT NOT NULL,
	comercialName VARCHAR(100),
	bussinessName VARCHAR(100),
	bussinessDescription VARCHAR(500),
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idAlly PRIMARY KEY (idAlly),
	CONSTRAINT FK_User_Ally FOREIGN KEY (idUser) REFERENCES [User]
)

CREATE TABLE ProductCategory
(
	idProductCategory INT IDENTITY(100001,1) NOT NULL,
	category VARCHAR(100) NOT NULL,
	description VARCHAR(200),
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_IdProductCategory PRIMARY KEY (idProductCategory)
)

CREATE TABLE Design
(
	idDesign INT IDENTITY(100001, 1) NOT NULL,
	idAlly INT NOT NULL,
	idProductCategory INT NOT NULL,
	designName VARCHAR(100) NOT NULL,
	designDescription VARCHAR(200),
	designPresentation VARCHAR(1000),
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idDesign PRIMARY KEY (idDesign),
	CONSTRAINT FK_Ally_Design FOREIGN KEY (idAlly) REFERENCES Ally,
	CONSTRAINT FK_Design_ProductCategory FOREIGN KEY (idProductCategory) REFERENCES ProductCategory
)

CREATE TABLE FileDesign
(
	idFileDesign INT IDENTITY(100001, 1) NOT NULL,
	idDesign INT NOT NULL,
	fileName VARCHAR(100) NOT NULL,
	codeFile VARCHAR(100) NOT NULL,
	designFImage VARBINARY(MAX) NOT NULL,
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idFileDesign PRIMARY KEY (idFileDesign),
	CONSTRAINT FK_FileDesign_Design FOREIGN KEY (idDesign) REFERENCES Design
)

CREATE TABLE DesignProduct
(
	idDesignProduct INT IDENTITY(100001,1) NOT NULL,
	idDesign INT NOT NULL,
	idProductCategory INT NOT NULL,
	basePrice DECIMAL(9,2) NOT NULL,
	isAvailable BIT NOT NULL DEFAULT 1,
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idDesignProduct PRIMARY KEY (idDesignProduct),
	CONSTRAINT FK_Design_DesignProduct FOREIGN KEY (idDesign) REFERENCES Design,
	CONSTRAINT FK_ProductCategory_DesignProduct FOREIGN KEY (idProductCategory) REFERENCES ProductCategory
)

CREATE TABLE Product
(
	idProduct INT IDENTITY(100001, 1) NOT NULL,
	idProductCategory INT NOT NULL,
	productName VARCHAR(100) NOT NULL,
	description VARCHAR(200),
	basePrice DECIMAL(9,2) NOT NULL,
	isAvailable BIT NOT NULL DEFAULT 1,
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_IdProduct PRIMARY KEY (idProduct),
	CONSTRAINT FK_Product_ProductCategory FOREIGN KEY (idProductCategory) REFERENCES Product
)

CREATE TABLE FileProduct
(
	idFileProduct INT IDENTITY(100001, 1) NOT NULL,
	idProduct INT NOT NULL,
	fileName VARCHAR(100) NOT NULL,
	productImage VARBINARY(MAX) NOT NULL,
	codeFile VARCHAR(100) NOT NULL,
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idFileProduct PRIMARY KEY (idFileProduct),
	CONSTRAINT FK_Product_FileProduct FOREIGN KEY (idProduct) REFERENCES Product
)

CREATE TABLE Color
(
	idColor INT IDENTITY(100001,1) NOT NULL,
	colorName VARCHAR(50) NOT NULL,
	colorCode VARCHAR(15) NOT NULL,
	basePrice DECIMAL(9,2) NOT NULL,
	imageColor VARBINARY(MAX) NOT NULL,
	isAvailable BIT NOT NULL DEFAULT 1,
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_IdColor PRIMARY KEY (idColor)
)

CREATE TABLE ColorXProduct
(
	idColor INT NOT NULL,
	idProduct INT NOT NULL,
	CONSTRAINT FK_Color_Product FOREIGN KEY (idColor) REFERENCES Color,
	CONSTRAINT FK_Product_Color FOREIGN KEY (idProduct) REFERENCES Product,
)

CREATE TABLE Dimension
(
	idDimension INT IDENTITY(100001,1) NOT NULL,
	dimensionName VARCHAR(10) NOT NULL,
	dimensionCoode VARCHAR(10) NOT NULL,
	basePrice DECIMAL(9,2) NOT NULL,
	isAvailable BIT NOT NULL DEFAULT 1,
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idDimension PRIMARY KEY (idDimension)
)

CREATE TABLE DimensionXProduct
(
	idDimension INT NOT NULL,
	idProduct INT NOT NULL,
	CONSTRAINT FK_Dimension_Product FOREIGN KEY (idDimension) REFERENCES Dimension,
	CONSTRAINT FK_Product_Dimension FOREIGN KEY (idProduct) REFERENCES Product,
)

CREATE TABLE ShoppingCart
(
	idShoppingCart INT IDENTITY(100001, 1) NOT NULL,
	idUser INT NOT NULL,
	shoppingCartCode VARCHAR(100) NOT NULL,
	totalMount DECIMAL(9,2) NOT NULL,
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idShoppingCart PRIMARY KEY (idShoppingCart),
	CONSTRAINT FK_ShoppingCart_User FOREIGN KEY (idUser) REFERENCES [User]
)

CREATE TABLE ShoppingCartItem
(
	idShoppingCartItem INT IDENTITY(100001, 1) NOT NULL,
	idShoppingCart INT NOT NULL,
	idProduct INT,
	idDesign INT,
	idColor INT,
	idDimension INT,
	quantity INT NOT NULL,
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idShoppingCartItem PRIMARY KEY (idShoppingCartItem),
	CONSTRAINT FK_ShoppingCartItem_ShoppingCart FOREIGN KEY (idShoppingCart) REFERENCES ShoppingCart,
	CONSTRAINT FK_Product_ShoppingCartItem FOREIGN KEY (idProduct) REFERENCES Product,
	CONSTRAINT FK_Design_ShoppingCartItem FOREIGN KEY (idDesign) REFERENCES Design,
	CONSTRAINT FK_Color_ShoppingCartItem FOREIGN KEY (idColor) REFERENCES Color,
	CONSTRAINT FK_Dimension_ShoppingCartItem FOREIGN KEY (idDimension) REFERENCES Dimension
)


CREATE TABLE StatusSale 
(
	idStatusSale INT IDENTITY(100001, 1) NOT NULL,
	nameStatus VARCHAR(10) NOT NULL,
	description VARCHAR(200),
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idStatusSale PRIMARY KEY (idStatusSale),
)

CREATE TABLE PayMethod
(
	idPayMethod INT IDENTITY(100001,1) NOT NULL,
	nameMethod VARCHAR(10) NOT NULL,
	descriptionMethod VARCHAR(200),
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	updatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idPayMethod PRIMARY KEY (idPayMethod)
)

CREATE TABLE Sale 
(
	idSale INT IDENTITY(100001, 1) NOT NULL,
	idShoppingCart INT NOT NULL,
	codeSale VARCHAR(100) NOT NULL,
	idStatusSale INT NOT NULL,
	idPayMethod INT NOT NULL,
	createdAt DATETIME NOT NULL DEFAULT GETDATE(),
	deleted BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_idSale PRIMARY KEY (idSale),
	CONSTRAINT FK_ShoppingCart_Sale FOREIGN KEY (idShoppingCart) REFERENCES ShoppingCart,
	CONSTRAINT FK_StatusSale_Sale FOREIGN KEY (idStatusSale) REFERENCES StatusSale,
	CONSTRAINT FK_PayMethod_Sale FOREIGN KEY (idPayMethod) REFERENCES PayMethod
)