CREATE PROCEDURE [dbo].[getBadgeByNFCTag]
	@NFCTag NVARCHAR(MAX)
AS
BEGIN 
	SELECT id, user_id UserId, nfc_tag NFCTag
	FROM [Badge]
	WHERE [nfc_tag] = @NFCTag;
END