CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN TRANSACTION
DECLARE @cnt INT = 
(	
	SELECT COUNT([ProjectID]) FROM [EmployeesProjects]
		WHERE [EmployeeID] = @emloyeeId
)
IF (@projectID > 3)
	BEGIN RAISERROR ('The employee has too many projects!', 16,1)
	ROLLBACK
END
INSERT INTO [EmployeesProjects] VALUES (@emloyeeId, @projectID)
COMMIT TRANSACTION