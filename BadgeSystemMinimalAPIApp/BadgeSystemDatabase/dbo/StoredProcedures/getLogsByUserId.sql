CREATE PROCEDURE [dbo].[getLogsByUserId]
	@UserId INT
AS
BEGIN
	SELECT id, user_id userId, sensor_id sensorId, date_time [dateTime]
	FROM [Log]
	WHERE [Log].[user_id] = @UserId;
END