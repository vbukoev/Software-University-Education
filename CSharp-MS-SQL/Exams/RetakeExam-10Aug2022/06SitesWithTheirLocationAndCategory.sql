SELECT s.[Name] AS 'Site', l.[Name] AS 'Location', s.Establishment, c.[Name] AS 'Category'
	FROM Sites AS s
JOIN Locations AS l
	ON s.LocationId = l.Id
JOIN Categories AS c
	ON c.Id = s.CategoryId
ORDER BY Category DESC, [Location], s.[Name]