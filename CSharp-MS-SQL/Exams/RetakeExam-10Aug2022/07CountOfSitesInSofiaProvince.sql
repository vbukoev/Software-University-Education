SELECT l.Province, l.Municipality, l.[Name] AS 'Location', COUNT(s.[Name]) AS 'CountOfSites'
	FROM Locations AS l
JOIN Sites AS s 
	ON s.LocationId = l.Id	
WHERE l.Province = 'Sofia'
GROUP BY l.[Name], l.Municipality, l.Province
ORDER BY CountOfSites DESC, [Location]