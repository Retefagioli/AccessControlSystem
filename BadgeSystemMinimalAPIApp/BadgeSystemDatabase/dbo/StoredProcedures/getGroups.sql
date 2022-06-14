CREATE PROCEDURE [dbo].[getGroups]
AS
BEGIN
	SELECT id Id, name Name
	FROM [Group]
END