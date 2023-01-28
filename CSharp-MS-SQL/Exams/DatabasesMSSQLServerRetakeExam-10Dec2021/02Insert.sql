INSERT INTO Passengers(FullName, Email)
SELECT FirstName + ' ' + LastName,
	FirstName + LastName + '@gmail.com'
	FROM Pilots AS p
	WHERE p.Id BETWEEN 5 AND 15