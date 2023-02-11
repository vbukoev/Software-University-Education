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