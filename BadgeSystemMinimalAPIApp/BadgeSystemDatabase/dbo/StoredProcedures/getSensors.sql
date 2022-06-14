CREATE PROCEDURE [dbo].[getSensors]
AS
BEGIN
	SELECT id Id, name Name, group_id GroupId, nfc_tag NFCTag
	FROM [Sensor]
END