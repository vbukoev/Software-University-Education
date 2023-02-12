SELECT SUBSTRING(t.[Name], CHARINDEX(' ',t.[Name]) + 1, LEN(t.[Name])) AS 'LastName', t.Nationality, t.Age, t.PhoneNumber
	FROM Tourists AS t 
JOIN SitesTourists AS st
	ON st.TouristId = t.Id 
JOIN Sites AS s
	ON st.SiteId = s.Id
JOIN Categories AS c
	ON s.CategoryId = c.Id
WHERE c.[Name] = 'History and archaeology'
GROUP BY t.[Name], t.Nationality, t.Age, t.PhoneNumber
ORDER BY LastName