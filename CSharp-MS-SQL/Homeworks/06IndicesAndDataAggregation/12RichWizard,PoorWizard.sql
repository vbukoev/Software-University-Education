SELECT SUM([wd].[DepositAmount] - [wd2].[DepositAmount]) AS [SumDifference] 
	FROM [WizzardDeposits] AS [wd]
LEFT JOIN [WizzardDeposits] AS [wd2]
	ON [wd].[Id] = [wd2].[Id] - 1 