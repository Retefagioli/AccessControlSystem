CREATE PROCEDURE [dbo].[insertLog]
    @UserId INT,
    @SensorId INT,
    @DateTime DATETIME
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [Log]([user_id], [sensor_id], [date_time])
	VALUES (@UserId, @SensorId, @DateTime);
END