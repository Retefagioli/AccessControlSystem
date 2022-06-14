CREATE PROCEDURE [dbo].[getLogById]
	@Id INT
AS
BEGIN
	SELECT user_id userId, sensor_id sensorId, date_time [dateTime]
	FROM [Log]
	WHERE [Log].[id] = @Id;
END