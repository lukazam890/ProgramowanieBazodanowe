CREATE PROCEDURE [dbo].[ActivateProduct]
	@id int
AS
	UPDATE Products 
	SET IsActive = 1
	WHERE ID = @id
RETURN 0