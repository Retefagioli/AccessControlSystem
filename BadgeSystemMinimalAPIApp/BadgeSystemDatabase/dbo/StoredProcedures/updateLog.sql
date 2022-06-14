CREATE PROCEDURE [dbo].[updateLog]
    @Id INT,
	@UserId INT,
    @SensorId INT,
    @DateTime DATETIME
AS
BEGIN
	UPDATE dbo.Log
	SET
        [user_id] = @UserId,
        [sensor_id] = @SensorId,
        [date_time] = @DateTime
    WHERE [id] = @Id;
END