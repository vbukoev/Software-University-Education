SELECT CONCAT (c.FirstName, ' ', c.LastName) AS FullName, c.Email, Max(b.Rating) AS Rating 
	FROM Creators AS c
JOIN CreatorsBoardgames AS cbg
	ON c.Id = cbg.CreatorId
JOIN Boardgames AS b
	ON cbg.BoardGameId = b.Id
WHERE c.Email LIKE '%.com'
GROUP BY c.FirstName, c.LastName, c.Email