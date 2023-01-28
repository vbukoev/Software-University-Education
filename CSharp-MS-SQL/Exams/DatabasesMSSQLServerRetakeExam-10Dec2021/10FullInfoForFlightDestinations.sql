SELECT a.AirportName, fd.[Start] AS DayTime, fd.TicketPrice, p.FullName, arc.Manufacturer, arc.Model
FROM
(SELECT *
	FROM FlightDestinations AS fd
	WHERE DATEPART(HOUR, fd.Start) BETWEEN 6 AND 20 ) AS fd
JOIN Airports AS a
	ON a.Id = fd.AirportId
JOIN Passengers AS p
	ON p.Id = fd.PassengerId
JOIN Aircraft As arc
	ON arc.Id = fd.AircraftId
	WHERE fd.TicketPrice > 2500
	ORDER BY arc.Model 