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

SELECT*FROM [Minions]
SELECT*FROM [Towns]