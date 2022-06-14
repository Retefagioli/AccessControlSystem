CREATE PROCEDURE [dbo].[insertBadge]
	@UserId INT,
    @NFCTag NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO Badge([user_id], [nfc_tag])
	VALUES (@UserId, @NFCTag);
END