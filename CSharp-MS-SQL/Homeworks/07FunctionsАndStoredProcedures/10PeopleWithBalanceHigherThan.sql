CREATE PROC usp_GetHoldersWithBalanceHigherThan(@num DECIMAL(18,4))
AS 
	SELECT [a].[FirstName], [a].[LastName]
		FROM [AccountHolders] AS [a]
	JOIN
	(
			SELECT [AccountHolderID], 
				   SUM([Balance]) AS [total]
			FROM [Accounts]
			GROUP BY [AccountHolderId]
	)
	AS [account] ON [a].[Id] = [account].[AccountHolderId]
	WHERE [account].[total] > @num
	ORDER BY [a].[FirstName], [a].[LastName]