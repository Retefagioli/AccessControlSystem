CREATE PROCEDURE [dbo].[deleteAccessToken]
	@Id INT
AS
BEGIN
	DELETE FROM AccessToken
	WHERE id = @Id;
END