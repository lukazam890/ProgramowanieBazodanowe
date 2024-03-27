CREATE PROCEDURE [dbo].[ListOfProducts]
	@sort int = 0,
	@onlyactive int = 0,
	@byname nvarchar(100) = '',
	@bygroupname nvarchar(100) = '',
	@byidgroup nvarchar(100) = ''
AS
	Declare
	@where nvarchar(100) ='',
	@order nvarchar(100) ='',
	@isFil int = 0
		
	IF @onlyactive=1
		SET @where = 'WHERE isActive=1 ';
	ELSE
		SET @where = 'WHERE (isActive=1 OR isActive=0) '

	IF @byname != ''
		SET @where += 'AND Products.Name = ''' + @byname + '''';
	ELSE IF @bygroupname != ''
		SET @where += 'AND ProductGroups.Name = ''' + @bygroupname + '''';
	ELSE IF @byidgroup != ''
		SET @where += 'AND ProductGroups.Id = ' + @byidgroup;


	IF @sort = 0
		SET @order = 'ORDER BY Products.Name ASC';
	ELSE IF @sort = 1
		SET @order = 'ORDER BY Products.Name DESC';
	ELSE IF @sort = 2
		SET @order = 'ORDER BY Products.Price ASC';
	ELSE IF @sort = 3
		SET @order = 'ORDER BY Products.Price DESC';
	ELSE IF @sort = 4
		SET @order = 'ORDER BY ProductGroups.Name ASC';
	ELSE IF @sort = 5
		SET @order = 'ORDER BY ProductGroups.Name DESC';

	DECLARE
	@query nvarchar(MAX);
	SET
	@query = 'SELECT * FROM Products INNER JOIN ProductGroups ON Products.GroupId = ProductGroups.Id ' + @where + @order;

	EXEC sp_executesql @query;
		
RETURN 0