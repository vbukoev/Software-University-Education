CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS 
BEGIN
	DECLARE @cnt INT = 1
	WHILE (@cnt <= LEN(@word))
		BEGIN 
			IF @setOfLetters NOT LIKE '%' + SUBSTRING(@word, @cnt,1) + '%' RETURN 0
			SET @cnt = @cnt + 1
		END
		RETURN 1
END
