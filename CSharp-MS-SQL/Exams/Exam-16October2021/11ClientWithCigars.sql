--CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
--RETURNS INT 
--	AS 
--		BEGIN 
--			DECLARE @clientId INT = (SELECT Id FROM Clients WHERE FirstName = @name)
--			RETURN(SELECT COUNT(CigarId) FROM ClientsCigars WHERE ClientId = @clientId)
--		END

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT AS
BEGIN 
DECLARE @cigarCount INT
SET @cigarCount = (SELECT COUNT(*) FROM ClientsCigars WHERE ClientId IN (SELECT Id FROM Clients WHERE FirstName = @name))
RETURN @cigarCount;
END