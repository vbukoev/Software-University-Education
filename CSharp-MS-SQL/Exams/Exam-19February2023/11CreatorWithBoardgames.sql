CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(30))
RETURNS INT 
AS
BEGIN
DECLARE @cnt INT 
SET @cnt = (SELECT COUNT(*) FROM Creators AS c 
			JOIN CreatorsBoardgames AS cbg
				ON c.Id = cbg.CreatorId
			JOIN Boardgames AS b
				ON cbg.BoardgameId = b.Id
			WHERE FirstName = @name)
RETURN @cnt
END