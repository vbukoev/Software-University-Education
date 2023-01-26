CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(18,4))
AS
	BEGIN TRANSACTION 
	BEGIN TRY 
		EXEC usp_DepositMoney @receiverId, @amount
		EXEC usp_WithdrawMoney @senderId, @amount
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION
	END CATCH
	COMMIT TRANSACTION