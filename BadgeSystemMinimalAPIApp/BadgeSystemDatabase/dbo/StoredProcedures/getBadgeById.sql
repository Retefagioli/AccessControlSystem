CREATE PROCEDURE [dbo].[getBadgeById]
	@Id INT
AS
BEGIN 
	SELECT user_id UserId, nfc_tag NFCTag
	FROM [Badge]
	WHERE [id] = @Id;
END