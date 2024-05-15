CREATE PROCEDURE [dbo].[RemoveFromBasket]
	@id int
AS
	DELETE FROM BasketPositions WHERE UserID = @id;
RETURN 0