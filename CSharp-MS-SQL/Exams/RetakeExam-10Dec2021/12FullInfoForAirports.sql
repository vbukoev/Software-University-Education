CREATE PROC usp_SearchByAirportName (@airportName NVARCHAR(70))
AS
SELECT a.AirportName, p.FullName,
	CASE 
		WHEN fd.TicketPrice <=400 THEN 'Low'
		WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
		WHEN fd.TicketPrice > 1500 THEN 'High'
	END AS LevelOfTicketPrice,
		arc.Manufacturer, arc.Condition, arct.TypeName
FROM Airports AS a
JOIN FlightDestinations AS fd
	ON fd.AirportId = a.Id
JOIN Passengers AS p
	ON p.Id = fd.PassengerId
JOIN Aircraft AS arc
	ON arc.Id = fd.AircraftId
JOIN AircraftTypes AS arct
	ON arct.Id = arc.TypeId
WHERE a.AirportName = @airportName
GROUP BY a.AirportName, p.FullName, fd.TicketPrice, arc.Manufacturer, arc.Condition, arct.TypeName
ORDER BY arc.Manufacturer, p.FullName 