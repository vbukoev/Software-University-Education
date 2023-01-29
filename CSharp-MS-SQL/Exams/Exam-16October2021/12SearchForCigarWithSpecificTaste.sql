CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS 
SELECT 
	c.CigarName, 
	'$' + CAST(c.PriceForSingleCigar AS VARCHAR) AS Price,
	@taste AS TasteType,
	b.BrandName,
	CAST(s.Length AS VARCHAR) + ' cm' AS CigarLength,
	CAST(s.RingRange AS VARCHAR) + ' cm' AS CigarRingRange
FROM Cigars AS c
JOIN Brands AS b 
	ON c.BrandId = b.Id
JOIN Sizes AS s
	ON c.SizeId = s.Id
WHERE c.TastId = (SELECT Id FROM Tastes WHERE TasteType = @taste)
ORDER BY CigarLength, CigarRingRange DESC