CREATE PROCEDURE [dbo].[DeactivateProduct]
	@id int
AS
	UPDATE Products 
	SET IsActive = 0
	WHERE ID = @id
RETURN 0