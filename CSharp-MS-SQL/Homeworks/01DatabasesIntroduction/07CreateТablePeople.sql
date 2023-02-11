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

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES	    ('Hristo Stefanov', 2, 1.85, 35.5, 'm', '1989-05-20', 'KAk si'),
	    ('Begoniq Mushkatova', 1, NULL, 40.0, 'f', '1969-02-21', 'hi'),
	    ('Stanyo Peshov', 2, 2.10, NULL, 'm', '1999-05-16', NULL),
	    ('Trifon Biserov', 1, 1.93, 81.0, 'm', '1976-02-09', 'lud'),
	    ('Galileo Galilei', 1, 1.71, 75.8, 'm', '1999-05-05', 'yes')