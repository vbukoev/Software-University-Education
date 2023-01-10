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