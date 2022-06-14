CREATE PROCEDURE [dbo].[updateGroup]
    @Id INT,
	@Name NVARCHAR(MAX)
AS
BEGIN
	UPDATE dbo.[Group]
	SET 
		[name] = @Name
	WHERE [id] = @Id;
END
RETURN 0
