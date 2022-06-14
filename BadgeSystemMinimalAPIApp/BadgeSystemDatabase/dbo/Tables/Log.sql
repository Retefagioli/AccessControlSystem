CREATE TABLE [dbo].[Log]
(
    [id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [user_id] INT NOT NULL,
    [sensor_id] INT NOT NULL,
    [date_time] DATETIME NOT NULL
)
