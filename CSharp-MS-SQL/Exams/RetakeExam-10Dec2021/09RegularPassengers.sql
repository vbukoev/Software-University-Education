SELECT p.FullName, COUNT(fd.PassengerId) AS CountOfAircraft, SUM(TicketPrice) AS TotalPayed
	FROM Passengers AS p
JOIN FlightDestinations AS fd 
	ON fd.PassengerId = p.Id
GROUP BY p.FullName
HAVING p.FullName LIKE '_a%' AND COUNT(fd.PassengerId) >= 2
ORDER BY p.FullName