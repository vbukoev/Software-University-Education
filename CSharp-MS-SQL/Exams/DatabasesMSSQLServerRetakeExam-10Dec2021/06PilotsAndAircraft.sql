SELECT p.FirstName, p.LastName, p.Manufacturer, p.Model, p.FlightHours
	FROM Pilots AS p

FULL JOIN PilotsAircraft AS pa 
	ON pa.PilotId = p.Id
JOIN Aircraft AS a 
	ON a.Id = pa.AircraftId
WHERE a.FlightHours <= 304
ORDER BY FlightHours DESC, p.FirstName 