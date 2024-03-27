CREATE PROCEDURE [dbo].[GenerateOrder]
	@userid int = 0
AS
	DECLARE 
	@productid int,
	@amount int,
	@price float
	SET
	@productid = (SELECT ID FROM BasketPositions WHERE UserID=@userid)
	SET
	@amount = (SELECT Amount FROM BasketPositions WHERE UserID=@userid)
	SET
	@price = (SELECT Price FROM BasketPositions WHERE UserID=@userid)

	INSERT INTO Orders (UserID, Date, isPayed)
	VALUES (@userid, CURRENT_TIMESTAMP, 0);

	DECLARE 
	@lastid int
	SET 
	@lastid = (SELECT MAX(ID) FROM Orders);

	INSERT INTO OrderPositions (ProductID, Amount, Price, OrderID)
	VALUES (@productid, @amount, @price, @lastid);

	SELECT Orders.ID, Date, IsPayed, UserID, OrderPositions.ProductID, OrderPositions.Amount, OrderPositions.Price
	FROM Orders RIGHT JOIN OrderPositions ON Orders.ID = OrderPositions.OrderID 
	WHERE Orders.UserID = @userid;

RETURN 0