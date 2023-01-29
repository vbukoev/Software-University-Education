SELECT c.LastName, AVG(s.[Length]) AS CigarLength, CEILING(AVG(s.RingRange)) AS CigarRingRange
	FROM Clients AS c
JOIN ClientsCigars AS cc 
	ON c.Id = cc.ClientId
JOIN Cigars AS cg 
	ON cc.CigarId = cg.Id
JOIN Sizes AS s
	ON cg.SizeId = s.Id
GROUP BY c.LastName
ORDER BY CigarLength DESC