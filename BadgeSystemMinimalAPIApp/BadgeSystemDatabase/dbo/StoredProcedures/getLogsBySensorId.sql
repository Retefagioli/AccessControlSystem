CREATE PROCEDURE [dbo].[getLogsBySensorId]
	@SensorId INT
AS
BEGIN
	SELECT id, user_id userId, sensor_id sensorId, date_time [dateTime]
	FROM [Log]
	WHERE [Log].[sensor_id] = @SensorId;
END
