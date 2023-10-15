--DATA SEED PERSONA
INSERT INTO Persona (Nombre,Apellido,TipoDocumento,NumeroDocumento) VALUES ('Administrador','General','DNI','XXXXXXXX');

--DATA SEED PERFIL
INSERT INTO Perfil (Descripcion) VALUES ('ADMINISTRADOR');
INSERT INTO Perfil (Descripcion) VALUES ('ALIADO');
INSERT INTO Perfil (Descripcion) VALUES ('CLIENTE');

--DATA SEED USUARIO
INSERT INTO Usuario (Username, Password, Persona, Perfil) VALUES ('joseph.avalos0694@gmail.com', 'e536151eb259672188aaf3a5b6d89f0f0d07165ace04e4d5c21d83c50c27c971', 1, 1);

--CREATE STRING ARRAY TYPE
CREATE TYPE StringArray AS TABLE
(
	[Value] VARCHAR(100)
);