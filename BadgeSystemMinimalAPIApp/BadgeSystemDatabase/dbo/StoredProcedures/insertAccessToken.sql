CREATE PROCEDURE [dbo].[insertAccessToken]
    @Token NVARCHAR (MAX),
    @UserId INT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO AccessToken(token, userId)
	VALUES (@Token, @UserId)
END