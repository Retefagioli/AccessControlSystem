CREATE PROCEDURE [dbo].[getBadges]
AS
BEGIN 
	SELECT id Id, user_id UserId, nfc_tag NFCTag
	FROM [Badge]
END
