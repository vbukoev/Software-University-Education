----02.
--INSERT INTO Boardgames
--	VALUES
--('Deep Blue',	2019,	5.67,	1,	15,	7),
--('Paris'	,2016	,9.78,	7,	1	,5),
--('Catan: Starfarers',	2021,	9.87,	7,	13	,6),
--('Bleeding Kansas',	2020,	3.25,	3,	7,	4),
--('One Small Step',	2019,	5.75,	5,	9,	2)

--INSERT INTO Publishers
--	VALUES

--('Agman Games',	5	,'www.agmangames.com',	'+16546135542'),
--('Amethyst Games',	7	,'www.amethystgames.com',	'+15558889992'),
--('BattleBooks',	13,	'www.battlebooks.com',	'+12345678907')


--03.
UPDATE PlayersRanges
SET PlayersMax = (SELECT Id FROM PlayersRanges WHERE PlayersMin = 2 AND PlayersMax = 2) + 1;

UPDATE Boardgames
SET [Name] = CONCAT( (SELECT TOP 1 [Name] FROM Boardgames WHERE YearPublished >= 2020) ,'v2')


--04.
DELETE FROM Boardgames
	WHERE PublisherId IN (SELECT Id FROM Addresses WHERE Town LIKE 'L%')

DELETE FROM Addresses
	WHERE Town LIKE 'L%'
----05.
--SELECT [Name], [Rating] FROM Boardgames
--ORDER BY YearPublished, [Name] DESC
--06.
SELECT b.[Id], b.[Name], b.YearPublished, c.[Name] AS CategoryName  
	FROM Boardgames AS b
JOIN Categories AS c
	ON b.CategoryId = c.Id
WHERE c.[Name] IN('Wargames','Strategy Games')
ORDER BY b.YearPublished DESC
--07.

SELECT Id, CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName, c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
WHERE cb.BoardgameId IS NULL
ORDER BY CreatorName
--08.

SELECT TOP(5) BG.[Name], bg.Rating, c.[Name]
FROM Boardgames AS bg
LEFT JOIN PlayersRanges AS pr ON bg.PlayersRangeId = pr.Id
LEFT JOIN Categories AS c ON bg.CategoryId = c.Id
WHERE bg.Rating > 7 AND bg.[Name] LIKE '%a%' OR bg.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5
ORDER BY bg.[Name], bg.Rating DESC

--09.

SELECT CONCAT (FirstName, ' ', LastName) AS FullName, c.Email, b.Rating FROM Creators AS c
JOIN Boardgames AS b 
	ON b.PublisherId = c.Id
WHERE c.Email LIKE '%.com'
ORDER BY b.Rating DESC, FullName
--10.

--11.

--12.
