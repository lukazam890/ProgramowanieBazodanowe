CREATE PROCEDURE [dbo].[RemoveFromBasket]
	@id int
AS
	DELETE FROM BasketPositions WHERE ID = @id;
RETURN 0