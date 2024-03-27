CREATE PROCEDURE [dbo].[IsActive]
	@id int = 0
AS
	SELECT ID FROM Products WHERE ID=@id AND IsActive=1;
RETURN 0