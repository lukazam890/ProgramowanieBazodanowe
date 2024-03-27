CREATE PROCEDURE [dbo].[RemoveProduct]
	@id int
AS
	DELETE FROM Products WHERE ID = @id;
RETURN 0