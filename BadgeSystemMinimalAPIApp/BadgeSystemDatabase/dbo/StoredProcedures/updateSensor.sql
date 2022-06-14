CREATE PROCEDURE [dbo].[updateSensor]
    @Id INT,
	@Name NVARCHAR (MAX),
    @NFCTag NVARCHAR (MAX),
    @GroupId INT
AS
BEGIN
	UPDATE dbo.Sensor
	SET
        [name] = @Name,
        [group_id] = @GroupId,
        [nfc_tag] = @NFCTag
    WHERE [id] = @Id;
END
