SELECT o.[Name] + '-' + a.[Name],
	   o.PhoneNumber,
	   ac.CageId
	FROM Owners AS o
JOIN Animals AS a
	ON o.Id = a.OwnerId
JOIN AnimalsCages AS ac
	ON a.Id = ac.AnimalId
WHERE AnimalTypeId = (SELECT Id FROM AnimalTypes WHERE AnimalType = 'Mammals')
ORDER BY o.[Name], a.[Name] DESC 