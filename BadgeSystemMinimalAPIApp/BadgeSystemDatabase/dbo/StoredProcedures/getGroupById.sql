CREATE PROCEDURE [dbo].[getGroupById]
	@Id INT
AS

BEGIN
	SELECT name Name
	FROM [Group]
	WHERE [Group].id = @Id;
END