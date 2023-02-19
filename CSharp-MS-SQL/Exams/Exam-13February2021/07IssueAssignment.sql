SELECT i.Id, u.Username + ' : ' + i.Title AS IssueAssignee
	FROM Issues AS i
JOIN Users AS u 
	ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, u.Username