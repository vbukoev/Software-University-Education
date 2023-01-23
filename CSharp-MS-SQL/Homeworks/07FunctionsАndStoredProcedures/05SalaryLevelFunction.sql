CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
	RETURNS VARCHAR(7)
		BEGIN
			RETURN 
				CASE 
					WHEN @salary < 30000 THEN 'Low'
					WHEN @salary <= 50000 THEN 'Average'
					ELSE 'High'
			END	
		END