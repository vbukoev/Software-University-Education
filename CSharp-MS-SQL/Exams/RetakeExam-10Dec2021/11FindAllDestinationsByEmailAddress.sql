CREATE FUNCTION dbo.udf_FlightDestinationsByEmail (@email VARCHAR(100))
RETURNS INT
	AS
		BEGIN 
			DECLARE @exit INT
			SET @exit = 
			(
				SELECT COUNT (fd.Id)
					FROM FlightDestinations AS fd
					JOIN Passengers AS p
						ON p.Id = fd.PassengerId
						WHERE p.Email = @email
			)
			RETURN @exit
		END