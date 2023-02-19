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