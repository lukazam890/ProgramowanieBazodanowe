CREATE PROCEDURE [dbo].[ChangeNumber]
	@id int,
	@number int
AS
	UPDATE BasketPositions 
	SET Amount = @number
	WHERE ID = @id;
RETURN 0