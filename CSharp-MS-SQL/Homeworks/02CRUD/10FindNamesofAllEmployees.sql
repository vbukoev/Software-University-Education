SELECT CONCAT([FirstName],' ', [MiddleName],' ', [LastName])
	FROM [Employees]
 WHERE [Salary] IN (25000, 14000, 12500, 23600) 