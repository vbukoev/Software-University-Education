SELECT [mc].[CountryCode], [m].[MountainRange], [p].[PeakName], [p].[Elevation]
	FROM [Peaks] AS [p]
INNER JOIN [Mountains] AS [m]
	ON [p].[MountainId] = [m].[Id]
INNER JOIN [MountainsCountries] AS [mc]
	ON [m].[Id] = [mc].[MountainId]
WHERE [mc].[CountryCode] = 'BG' AND [p].[Elevation] > 2835
ORDER BY [p].[Elevation] DESC