CREATE TABLE [Logs]
(
	[LogId] INT IDENTITY,
	[AccountId] INT FOREIGN KEY REFERENCES Accounts(Id),
	[OldSum] DECIMAL(18,4),
	[NewSum] DECIMAL(18,4)
)
GO

CREATE TRIGGER tr_AddToTable
ON [Accounts] FOR UPDATE
AS
INSERT INTO [Logs] VALUES
(
	(SELECT [Id] FROM inserted),
	(SELECT [Balance] FROM deleted),
	(SELECT [Balance] FROM inserted)
)