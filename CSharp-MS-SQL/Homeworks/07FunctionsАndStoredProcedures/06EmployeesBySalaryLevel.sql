CREATE PROC usp_EmployeesBySalaryLevel (@SalaryLevel VARCHAR (7))
AS 
	SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel