SELECT TOP(20) fd.Id AS DestinationId, fd.[Start], p.FullName, a.AirportName, fd.TicketPrice
	FROM FlightDestinations AS fd
JOIN Airports AS a
	ON fd.AirportId = a.Id
JOIN Passengers AS p
	ON p.Id = fd.PassengerId
WHERE DAY(fd.Start) % 2 = 0
ORDER BY TicketPrice DESC, a.AirportName 