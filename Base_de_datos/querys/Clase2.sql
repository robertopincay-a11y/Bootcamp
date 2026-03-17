USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'LeaderboardBootcamp')
    CREATE DATABASE LeaderboardBootcamp;
GO

USE LeaderboardBootcamp;
GO

CREATE TABLE UsuarioTipos(
UsuarioTipoId       INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Descripcion         Varchar(20) NOT NULL,
CreatedAt           DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME() 
);
GO

CREATE TABLE Usuarios(
UsuarioId           UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
UsuarioTipoId       INT NOT NULL REFERENCES UsuarioTipos(UsuarioTipoId),
Nombre              NVARCHAR(50) NOT NULL,
Edad                INT NOT NULL,
Correo              VARCHAR(200) NOT NULL,
NumeroTelefono      NVARCHAR(32) NOT NULL,
Cedula              NVARCHAR(10) NOT NULL,
FechadeCreacion     DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME() 
);
GO


CREATE TABLE Modulotipos(
ModuloTipoId        INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Especificidad       VARCHAR(45) NOT NULL,
Tecnologia          VARCHAR(45) NOT NULL,
CreatedAt           DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
Go

CREATE TABLE Modulos(
ModuloId            INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
ProfesorId          UNIQUEIDENTIFIER NOT NULL REFERENCES Usuarios(UsuarioId),
TipoId              INT NOT NULL REFERENCES Modulotipos(ModuloTipoId),
CreatedAt           DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
GO

CREATE TABLE Participaciones(
ParticipacionId     INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
EstudianteId        UNIQUEIDENTIFIER NOT NULL REFERENCES Usuarios(UsuarioId),
ModuloId            INT NOT NULL REFERENCES Modulos(ModuloId),
Puntos              DECIMAL NOT NULL,
FechaParticipacion  DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
GO

INSERT INTO UsuarioTipos(Descripcion)
VALUES
('Profesor'),
('Estudiante');
GO

INSERT INTO Modulotipos(Especificidad, Tecnologia)
VALUES
('Motor de base de datos','SQL SERVER'),
('Framework','Angular'),
('Framework','.NET'),
('Entorno de ejecucion','NodeJS');
GO

DECLARE @johnDoeUserId UNIQUEIDENTIFIER = NEWID();
DECLARE @johnDoeSegundoUserId UNIQUEIDENTIFIER = NEWID();
DECLARE @johnDoeTercerUserId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Usuarios(UsuarioId,UsuarioTipoId,Nombre,Edad,Correo,NumeroTelefono,Cedula)
VALUES
(@johnDoeUserId,1,'John Doe',78,'john@doe.com', '012323423432','012341334'),
(@johnDoeSegundoUserId,1,'John Doe2',78,'john@doe1.com', '012323423432','012341334'),
(@johnDoeTercerUserId,1,'John Doe3',78,'john@doe2.com', '012323423432','012341334');

DECLARE @SQLServerModuloTipo INT = (SELECT ModuloTipoId from Modulotipos where Tecnologia = 'SQL SERVER');
DECLARE @AngularModuloTipo INT = (SELECT ModuloTipoId from Modulotipos where Tecnologia = 'Angular');
DECLARE @DotNetModuloTipo INT = (SELECT ModuloTipoId from Modulotipos where Tecnologia = '.NET');
DECLARE @NodeJs INT = (SELECT ModuloTipoId from Modulotipos where Tecnologia = 'NodeJS');

INSERT INTO Modulos(TipoId,ProfesorId)
VALUES
(@SQLServerModuloTipo, @johnDoeUserId),
(@AngularModuloTipo,@johnDoeSegundoUserId),
(@DotNetModuloTipo,@johnDoeTercerUserId),
(@NodeJs,@johnDoeUserId)
GO

ALTER TABLE Usuarios
ADD CONSTRAINT UQ_Usuario_CorreoElectronico UNIQUE (Correo);
Go

ALTER TABLE Usuarios
ADD CONSTRAINT UQ_Usuario_Cedula UNIQUE (Cedula);
GO

ALTER TABLE Usuarios
ADD CONSTRAINT UQ_Usuario_Telefono UNIQUE (NumeroTelefono);
GO

Select * from Usuarios
where UsuarioId !='661b4912-cd1e-471b-b022-41bdaf7d96ef';

UPDATE Usuarios
SET Correo ='john1@doe.com'
WHERE UsuarioId = '661b4912-cd1e-471b-b022-41bdaf7d96ef';