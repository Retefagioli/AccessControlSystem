CREATE PROCEDURE [dbo].[getLogs]
AS
BEGIN
	SELECT id, user_id userId, sensor_id sensorId, date_time [dateTime]
	FROM [Log]
END
