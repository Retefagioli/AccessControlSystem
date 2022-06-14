CREATE PROCEDURE [dbo].[updateBadge]
	@Id INT,
	@UserId INT,
    @NFCTag NVARCHAR(MAX)
AS
BEGIN
	UPDATE dbo.Badge
	SET
        [user_id] = @UserId,
        [nfc_tag] = @NFCTag
 	WHERE id = @Id;
END