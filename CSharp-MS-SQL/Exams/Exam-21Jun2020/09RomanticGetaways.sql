SELECT a.Id, a.Email, c.[Name] AS City, COUNT(*) AS Trips
FROM Accounts AS a
JOIN AccountsTrips AS act 
	ON a.Id = act.AccountId
JOIN Trips AS t
	ON act.TripId = t.Id
JOIN Rooms AS r
	ON t.RoomId = r.Id 
JOIN Hotels AS h
	ON r.HotelId = h.Id
JOIN Cities as c
	ON h.CityId = c.Id
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.[Name]
ORDER BY Trips DESC, Id