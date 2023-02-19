--01.DDL
CREATE TABLE Categories
( 
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL UNIQUE,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
	Website NVARCHAR(40),
	Phone NVARCHAR(20)
)

CREATE TABLE PlayersRanges
(
	Id INT PRIMARY KEY IDENTITY,
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating DECIMAL(18,2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL,
	PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL 
)

CREATE TABLE Creators
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL,
)

CREATE TABLE CreatorsBoardgames
(
	CreatorId INT FOREIGN KEY REFERENCES Creators(Id) NOT NULL,
	BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id) NOT NULL
	PRIMARY KEY(CreatorId, BoardgameId)
)



--02.INSERT
INSERT INTO Boardgames
	VALUES
('Deep Blue',	2019,	5.67,	1,	15,	7),
('Paris'	,2016	,9.78,	7,	1	,5),
('Catan: Starfarers',	2021,	9.87,	7,	13	,6),
('Bleeding Kansas',	2020,	3.25,	3,	7,	4),
('One Small Step',	2019,	5.75,	5,	9,	2)

INSERT INTO Publishers
	VALUES

('Agman Games',	5	,'www.agmangames.com',	'+16546135542'),
('Amethyst Games',	7	,'www.amethystgames.com',	'+15558889992'),
('BattleBooks',	13,	'www.battlebooks.com',	'+12345678907')



--03.UPDATE
UPDATE PlayersRanges
SET PlayersMax += 1 WHERE PlayersMax = 2 AND PlayersMin = 2
UPDATE Boardgames
SET [Name] = CONCAT( Name ,'V2')
WHERE YearPublished >= 2020



--04.DELETE
SELECT * FROM Publishers WHERE AddressId = 5
SELECT * FROM Addresses WHERE LEFT(Town,1) = 'L'
SELECT * FROM Boardgames WHERE PublisherId IN (1, 16)
DELETE FROM CreatorsBoardgames WHERE BoardgameId IN (1, 16, 31, 47)
DELETE FROM Boardgames WHERE PublisherId IN (1, 16)
DELETE FROM Publishers WHERE AddressId = 5
DELETE FROM Addresses WHERE LEFT(Town, 1) = 'L'
DELETE FROM Addresses WHERE Town LIKE 'L%'



----05.BOARDGAMES BY YEAR OF PUBLICATION
SELECT [Name], [Rating] FROM Boardgames
ORDER BY YearPublished, [Name] DESC



--06.BOARGAMES BY CATEGORY
SELECT b.[Id], b.[Name], b.YearPublished, c.[Name] AS CategoryName  
	FROM Boardgames AS b
JOIN Categories AS c
	ON b.CategoryId = c.Id
WHERE c.[Name] IN('Wargames','Strategy Games')
ORDER BY b.YearPublished DESC



--07.CREATORS WITHOUT BOARDGAMES
SELECT Id, CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName, c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
WHERE cb.BoardgameId IS NULL
ORDER BY CreatorName



--08.FIRST 5 BOARDGAMES
SELECT TOP(5) BG.[Name], bg.Rating, c.[Name]
FROM Boardgames AS bg
LEFT JOIN PlayersRanges AS pr ON bg.PlayersRangeId = pr.Id
LEFT JOIN Categories AS c ON bg.CategoryId = c.Id
WHERE bg.Rating > 7 AND bg.[Name] LIKE '%a%' OR bg.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5
ORDER BY bg.[Name], bg.Rating DESC



--09.CREATORS WITH EMAILS
SELECT CONCAT (c.FirstName, ' ', c.LastName) AS FullName, c.Email, Max(b.Rating) AS Rating 
	FROM Creators AS c
JOIN CreatorsBoardgames AS cbg
	ON c.Id = cbg.CreatorId
JOIN Boardgames AS b
	ON cbg.BoardGameId = b.Id
WHERE c.Email LIKE '%.com'
GROUP BY c.FirstName, c.LastName, c.Email



--10.CREATORS BY RATING
SELECT c.LastName, CEILING(AVG(b.Rating)) AS AverageRating, p.[Name] FROM Creators AS c
JOIN CreatorsBoardgames AS cbg
	ON c.Id = cbg.CreatorId 
JOIN Boardgames AS b
	ON cbg.BoardgameId = b.Id
JOIN Publishers AS p 
	ON b.PublisherId = p.Id
WHERE p.[Name] = 'Stonemaier Games'
GROUP BY c.LastName, p.[Name]
ORDER BY AVG(b.Rating) DESC



--11.CREATOR WITH BOARDGAMES
CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(30))
RETURNS INT 
AS
BEGIN
DECLARE @cnt INT 
SET @cnt = (SELECT COUNT(*) FROM Creators AS c 
			JOIN CreatorsBoardgames AS cbg
				ON c.Id = cbg.CreatorId
			JOIN Boardgames AS b
				ON cbg.BoardgameId = b.Id
			WHERE FirstName = @name)
RETURN @cnt
END

SELECT dbo.udf_CreatorWithBoardgames('Bruno')



--12.SEARCH FOR BOARDGAME WITH SPECIFIC CATEGORY
CREATE PROC usp_SearchByCategory(@category VARCHAR(30))
AS 
BEGIN 
SELECT b.[Name], b.YearPublished, b.Rating, c.[Name] AS CategoryName, p.[Name] AS PublisherName, CONCAT(plr.PlayersMin, ' people') AS MinPlayers, CONCAT(plr.PlayersMax, ' people') AS MaxPlayers
	FROM Categories AS c
JOIN Boardgames AS b
	ON c.Id = b.CategoryId
JOIN Publishers AS p
	ON b.PublisherId = p.Id
JOIN PlayersRanges AS plr
	ON b.PlayersRangeId = plr.Id
WHERE c.[Name] = @category
ORDER BY p.[Name], b.YearPublished DESC
END
