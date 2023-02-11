CREATE DATABASE [Minions2023]

USE [Minions2023]

GO

CREATE TABLE[Minions](
     [Id] INT PRIMARY KEY, --PRIMARY KEY MAKES IT NOT NULL
	 [Name] NVARCHAR(50) NOT NULL,
	 [Age] INT NOT NULL
)

GO

CREATE TABLE [Towns](
     [Id] INT PRIMARY KEY,
	 [Name] NVARCHAR(70) NOT NULL,
)

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL 

ALTER TABLE [Minions]
ALTER COLUMN [AGE] INT

GO

INSERT INTO [Towns]([Id], [Name])
	VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
	VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)


SELECT*FROM [Towns]
SELECT*FROM [Minions]

GO

CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

GO 

CREATE TABLE [Users](
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] BIT,
	[LastLoginTime] DATETIME,
	[IsDeleted] BIT DEFAULT 'false'
)

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES	    ('Hristo Stefanov', '1234124',1,'1989-05-20', 0),
	    ('Begoniq Mushkatova', '1234124',2, '1969-02-21', 0),
	    ('Stanyo Peshov', '1234124', 2, '1999-05-16', 1),
	    ('Trifon Biserov', '1234124', 2, '1976-02-09', 1),
	    ('Galileo Galilei', '1234124', 1, '1999-05-05', 1)

GO
--
CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(30) UNIQUE NOT NULL,
	[Notes] NVARCHAR(MAX)
)
CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(30) UNIQUE NOT NULL,
	[Notes] NVARCHAR(MAX)
)
CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(30) UNIQUE NOT NULL,
	[Notes] NVARCHAR(MAX)
)
CREATE TABLE [MOVIES](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(30) UNIQUE NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES Directors(Id),
	[CopyrightYear] DATE,
	[Length] TIME NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES Genres(Id),
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
	[Rating] DECIMAL(2,1) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors([DirectorName], [Notes])
VALUES			('Pesho', NULL),
				('Goshko', NULL),
				('Mani', NULL),
				('Jeff', 'Hello'),
				('MrNoBody', 'Horraaah')
INSERT INTO Genres([GenreName], [Notes])
VALUES			('Romantichen', NULL),
				('Komedia', NULL),
				('Drama', NULL),
				('Horror', NULL),
				('Ekshun', NULL)
INSERT INTO Categories([CategoryName], [Notes])
VALUES			('Category1', Null),
				('Category2', Null),
				('Category3', Null),
				('Category4', Null),
				('Category5', Null)
INSERT INTO Movies ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES			('film1', 1, '1972', '02:30:00', 1, 1, 9.5, NULL),
				('film12', 2, '2010', '02:30:00', 2, 2, 6.8, NULL),
				('film13', 3, '2012', '02:30:00', 3, 3, 5.2, NULL),
				('film14', 4, '2001', '02:30:00', 4, 4, 7.8, NULL),
				('film145', 5, '1984', '02:30:00', 5, 5, 8.4, NULL)