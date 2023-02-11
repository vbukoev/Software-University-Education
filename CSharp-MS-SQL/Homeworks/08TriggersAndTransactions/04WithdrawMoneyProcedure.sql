CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(18,4)) 
AS
	IF (@moneyAmount < 0) THROW 50001, 'Invalid amount', 1
	UPDATE [Accounts] 
	SET [Balance] -= @moneyAmount
	WHERE [Id] = @accountId