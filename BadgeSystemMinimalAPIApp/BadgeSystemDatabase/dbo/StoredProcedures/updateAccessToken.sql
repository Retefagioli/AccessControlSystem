CREATE PROCEDURE [dbo].[updateAccessToken]
    @Id INT,
    @Token NVARCHAR (MAX),
    @UserId INT
AS
BEGIN
	UPDATE [dbo].[AccessToken]
	SET
        token = @Token,
        userId = @UserId
    WHERE id = @Id;
END