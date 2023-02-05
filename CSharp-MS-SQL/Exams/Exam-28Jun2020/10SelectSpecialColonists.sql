SELECT JobDuringJourney, FullName, JobRank
	FROM
		(SELECT tc.JobDuringJourney, 
			   CONCAT(FirstName, ' ' + LastName) AS FullName,
			   RANK() OVER (PARTITION BY JobDuringJourney ORDER BY Birthdate) AS JobRank
			FROM Colonists AS c
			JOIN TravelCards AS tc	
				ON c.Id = tc.ColonistId) AS r
	WHERE JobRank = 2