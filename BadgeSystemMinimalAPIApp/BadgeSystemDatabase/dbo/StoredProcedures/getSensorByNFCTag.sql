CREATE PROCEDURE [dbo].[getSensorByNFCTag]
	@NFCTag NVARCHAR(MAX)
AS
BEGIN
	SELECT id Id, name Name, group_id GroupId, nfc_tag NFCTag
	FROM [Sensor]
	WHERE [Sensor].[nfc_tag] = @NFCTag;
END
