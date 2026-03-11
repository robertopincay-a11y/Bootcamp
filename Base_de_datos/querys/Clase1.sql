Create DATABASE Discord;
GO

Use Discord;
Go

Create table Roles(
RoleId INT Identity(1,1) Not Null,
Code Nvarchar(10) Not null,
ShowName NVARCHAR(100) NOT NULL,
CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
GO

CREATE TABLE UserStatusType(
UserStatusTypeId Int,
Code NVARCHAR(23),
ShowName NVARCHAR(50),
CreateAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
Go


INSERT INTO UserStatusType(Code, ShowName)
Values
('online',			'En línea'),
('not_disturb',		'No molestar'),
('idle',			'Ausente'),
('ghost',			'Invisible');
GO

CREATE TABLE Users(
UserId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
Username NVARCHAR(32) NOT NULL,
DisplayName NVARCHAR(100) NOT NULL,
Description NVARCHAR(255) NULL,
StatusType INT NOT NULL REFERENCES UserStatusType(UserStatusTypeId) DEFAULT(1),
StatusTime INT NULL,
BannerURL NVARCHAR(255) NULL,
--RoleId INT NOT NULL REFERENCES Roles(RoleId),
CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
--CONSTRAINT FK_Roles_RoleId FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);
GO

CREATE TABLE UsersRoles(
UserId UNIQUEIDENTIFIER NOT NULL,
RoleId INT NOT NULL,
CONSTRAINT PK_UserRoles_UserId_RoleId PRIMARY KEY (UserId, RoleId)

);
GO

CREATE TABLE Collections(
CollectionId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
Name NVARCHAR(50) NOT NULL,
Description NVARCHAR(100) NOT NULL DEFAULT('This is my collection!'),
CreateAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
Go

CREATE TABLE Items(
ItemId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Name NVARCHAR(50) NOT NULL,
CreateAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
Go

INSERT INTO Items(Name)
VALUES
('Hollow Knight'), --Me pago 10$
('osu!'); --Este tambien me pago 10$


CREATE TABLE CollectionsItems(
CollectionId UNIQUEIDENTIFIER NOT NULL REFERENCES Collections(CollectionId),
ItemId INT NOT NULL REFERENCES Items(ItemId),
CONSTRAINT PK_CollectionsItems_CollectionId_ItemId PRIMARY KEY(CollectionId, ItemId)
);



