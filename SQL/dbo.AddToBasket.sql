CREATE PROCEDURE [dbo].[AddToBasket]
	@userid int,
	@productid int,
	@amount int,
	@price int
AS
	INSERT INTO BasketPositions (UserID, ProductID, Amount, Price) 
	VALUES (@userid, @productid, @amount, @price);
RETURN 0