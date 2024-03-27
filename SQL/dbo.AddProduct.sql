CREATE PROCEDURE [dbo].[AddProduct]
	@name nvarchar(100),
	@image nvarchar(100),
	@price int,
	@groupId int
AS
	INSERT INTO Products (Name, Image, Price, GroupID, IsActive) 
	VALUES (@name, @image, @price, @groupId, 1);
RETURN 0