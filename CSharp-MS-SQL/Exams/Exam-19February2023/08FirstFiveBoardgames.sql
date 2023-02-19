SELECT TOP(5) BG.[Name], bg.Rating, c.[Name]
FROM Boardgames AS bg
LEFT JOIN PlayersRanges AS pr ON bg.PlayersRangeId = pr.Id
LEFT JOIN Categories AS c ON bg.CategoryId = c.Id
WHERE bg.Rating > 7 AND bg.[Name] LIKE '%a%' OR bg.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5
ORDER BY bg.[Name], bg.Rating DESC