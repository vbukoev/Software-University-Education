SELECT c.Id, c.FirstName + ' ' + c.LastName AS full_name
	FROM Colonists AS c
JOIN TravelCards AS tc
	ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id