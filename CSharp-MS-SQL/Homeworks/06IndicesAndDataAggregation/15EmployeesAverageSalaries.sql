SELECT * INTO [Newt]
	FROM [Employees]
	WHERE [Salary] > 30000 
DELETE FROM [Newt] 
	WHERE [ManagerID] = 42
UPDATE [Newt]
	SET [Salary] += 5000
	WHERE [DepartmentID] = 1
SELECT [DepartmentID], AVG([Salary]) AS [AverageSalary]
	FROM [Newt]
GROUP BY [DepartmentID]