SELECT s.[Name] AS 'Site', l.[Name] AS 'Location', l.Municipality, l.Province, s.Establishment 
	FROM Sites AS s
JOIN Locations AS l 
	ON s.LocationId = l.Id	
WHERE LEFT(l.[Name], 1) NOT LIKE '[B,M,D]'
AND s.Establishment LIKE '%BC'
ORDER BY s.[Name]