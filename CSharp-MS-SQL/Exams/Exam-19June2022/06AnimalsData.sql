SELECT [Name], [at].AnimalType, FORMAT(a.BirthDate, 'dd.MM.yyyy') AS BirthDate
	FROM Animals AS a
JOIN AnimalTypes AS [at]
	ON a.AnimalTypeId = [at].Id
ORDER BY [Name]