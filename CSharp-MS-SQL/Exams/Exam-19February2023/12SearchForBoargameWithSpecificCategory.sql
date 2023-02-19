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