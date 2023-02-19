SELECT * FROM Publishers WHERE AddressId = 5
SELECT * FROM Addresses WHERE LEFT(Town,1) = 'L'
SELECT * FROM Boardgames WHERE PublisherId IN (1, 16)
DELETE FROM CreatorsBoardgames WHERE BoardgameId IN (1, 16, 31, 47)
DELETE FROM Boardgames WHERE PublisherId IN (1, 16)
DELETE FROM Publishers WHERE AddressId = 5
DELETE FROM Addresses WHERE LEFT(Town, 1) = 'L'

DELETE FROM Addresses WHERE Town LIKE 'L%'