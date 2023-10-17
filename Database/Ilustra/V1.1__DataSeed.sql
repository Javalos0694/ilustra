INSERT INTO DocumentType (documentName, description) VALUES ('DNI', 'Documento Nacional de Identidad');
INSERT INTO DocumentType (documentName, description) VALUES ('CE', 'Carnet de Extranjeria');

INSERT INTO Person (firstName, lastName, phoneNumber, idDocumentType, documentNumber, email, bornDate)
VALUES ('Joseph','Avalos','994402514',100001, '75516473','joseph.avalos0694@gmail.com',CONVERT(DATE, '06-12-1994'));

INSERT INTO UserType (userType,description) VALUES ('ADMIN', 'Usuario administrativo');
INSERT INTO UserType (userType,description) VALUES ('CLIENT', 'Usuario cliente');
INSERT INTO UserType (userType,description) VALUES ('ALLY', 'Usuario aliado');

INSERT INTO [User] (idPerson,username,password,idUserType) VALUES (100001,'joavalos','123456',100001);