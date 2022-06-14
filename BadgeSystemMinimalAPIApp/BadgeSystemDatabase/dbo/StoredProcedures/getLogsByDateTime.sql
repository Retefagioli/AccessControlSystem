CREATE PROCEDURE [dbo].[getLogsByDateTime]
	@DateTime DATETIME
AS
BEGIN
	SELECT id, user_id userId, sensor_id sensorId, date_time [dateTime]
	FROM [Log]
	WHERE [Log].[date_time] = @DateTime;
END