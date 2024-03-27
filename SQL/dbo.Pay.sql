CREATE PROCEDURE [dbo].[Pay]
	@userid int,
	@value float
AS
	DECLARE
	@orderid int
	SET @orderid = (SELECT MIN(ID) FROM Orders WHERE UserID = @userid);

	SELECT SUM(Price) FROM OrderPositions WHERE OrderID = @orderid;
RETURN 0