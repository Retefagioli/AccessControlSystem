CREATE PROCEDURE [dbo].[getAccessTokenById]
	@Id INT
AS
BEGIN
	SELECT *
	FROM AccessToken
	WHERE AccessToken.id = @Id;
END
