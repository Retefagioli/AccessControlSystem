CREATE PROCEDURE [dbo].[getGroupByName]
	@Name NVARCHAR(MAX)
AS

BEGIN
	SELECT name Name
	FROM [Group]
	WHERE [Group].name = @Name
END