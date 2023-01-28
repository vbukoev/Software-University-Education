UPDATE Aircraft
SET Condition = 'A'
WHERE (Condition = 'C' OR Condition = 'B')
AND (FlightHours IS NULL OR FlightHours <= 100)
AND [Year] >= 2013