CREATE FUNCTION ufn_CalculateFutureValue 
(@sum DECIMAL(18,4), @yearlyInterestRate FLOAT, @numOfYears INT)
RETURNS DECIMAL(18,4)
AS 
	BEGIN
		RETURN @sum*POWER(1+@yearlyInterestRate, @numOfYears)
	END