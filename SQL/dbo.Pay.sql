CREATE PROCEDURE [dbo].[Pay]
	@userid int,
	@value float
AS
	DECLARE
	@orderid int,
	@sum int

	SET @orderid = (SELECT MIN(ID) FROM Orders WHERE UserID = @userid);

	SET @sum = (SELECT SUM(Price) FROM OrderPositions WHERE OrderID = @orderid);

	IF ABS(@sum - @value) < 0.001 
		UPDATE Orders SET isPayed = 1 WHERE UserID = @userid 
		
RETURN 0