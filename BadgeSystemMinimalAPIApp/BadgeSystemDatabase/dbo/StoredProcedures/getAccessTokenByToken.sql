CREATE PROCEDURE [dbo].[getAccessTokenByToken]
	@Token NVARCHAR (MAX)
AS
BEGIN
	SELECT *
	FROM AccessToken
	WHERE AccessToken.token = @Token;
END
