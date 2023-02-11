CREATE PROC usp_GetEmployeesSalaryAboveNumber (@minimumSalary DECIMAL(18,4))
AS
		SELECT
			[FirstName], [LastName]
				FROM [Employees]
				WHERE [Salary] >= @minimumSalary