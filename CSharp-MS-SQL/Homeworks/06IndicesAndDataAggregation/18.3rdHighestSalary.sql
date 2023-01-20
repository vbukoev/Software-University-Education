SELECT DISTINCT
	[DepartmentID], MAX([Salary]) AS [ThirdHighestSalary]
	FROM(
		SELECT [DepartmentID],
			   [Salary],
				DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [SalaryRank]
				FROM [Employees]
		)
		AS [SalaryRankQuery]
		WHERE [SalaryRank] = 3
		GROUP BY [DepartmentID]