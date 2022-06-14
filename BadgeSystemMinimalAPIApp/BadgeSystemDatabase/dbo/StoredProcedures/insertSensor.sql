CREATE PROCEDURE [dbo].[insertSensor]
	@Name NVARCHAR (MAX),
    @GroupId INT,
	@NFCTag NVARCHAR (MAX)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Sensor([name], [group_id], [nfc_tag])
	VALUES (@Name, @GroupId, @NFCTag)
END
