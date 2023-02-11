CREATE PROC usp_GetTownsStartingWith 
(@substring VARCHAR(50))
AS
	SELECT
		[Name] AS [Town]
	FROM
	[Towns]
	WHERE SUBSTRING([Name], 1, LEN(@substring)) = @substring