SELECT c.FirstName + ' ' + LastName AS FullName, a.Country, a.ZIP, '$' + CAST(MAX(cg.PriceForSingleCigar) AS VARCHAR) AS CigarPrice
	FROM Clients AS c
JOIN Addresses AS a
	ON c.AddressId = a.Id
JOIN ClientsCigars AS cc
	ON c.Id = cc.ClientId
JOIN Cigars AS cg
	ON cc.CigarId = cg.Id
WHERE a.Zip NOT LIKE '%[A-Z]%'
GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP
ORDER BY FullName