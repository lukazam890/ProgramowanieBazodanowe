CREATE PROCEDURE [dbo].[RemoveFromBasket]
	@id int
AS
	DELETE FROM Products WHERE ID = @id;
RETURN 0