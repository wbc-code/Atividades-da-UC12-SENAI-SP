CREATE DATABASE Senai 
GO

USE Senai 
GO

CREATE TABLE Usuarios(
    Id INT PRIMARY KEY IDENTITY,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Senha VARCHAR(50) NOT NULL
)
GO

INSERT INTO Usuarios VALUES('email1@email.com', 1234)
INSERT INTO Usuarios VALUES('email2@email.com', 1234)

SELECT Email, HASHBYTES('MD2', Senha) AS 'Senha HASH' FROM Usuarios WHERE Id = 1
SELECT Email, HASHBYTES('MD4', Senha) AS 'Senha HASH' FROM Usuarios WHERE Id = 1
SELECT Email, HASHBYTES('MD5', Senha) AS 'Senha HASH' FROM Usuarios WHERE Id = 1
SELECT Email, HASHBYTES('SHA1', Senha) AS 'Senha HASH' FROM Usuarios WHERE Id = 1
SELECT Email, HASHBYTES('SHA2_256', Senha) AS 'Senha HASH' FROM Usuarios WHERE Id = 1
SELECT Email, HASHBYTES('SHA2_512', Senha) AS 'Senha HASH' FROM Usuarios WHERE Id = 1
