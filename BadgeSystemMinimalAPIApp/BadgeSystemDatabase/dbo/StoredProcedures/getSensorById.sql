CREATE PROCEDURE [dbo].[getSensorById]
	@Id INT
AS
BEGIN
	SELECT id Id, name Name, group_id GroupId, nfc_tag NFCTag
	FROM [Sensor]
	WHERE [Sensor].[id] = @Id;
END