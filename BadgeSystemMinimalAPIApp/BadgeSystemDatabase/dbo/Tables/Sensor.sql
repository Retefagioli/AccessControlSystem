CREATE TABLE [dbo].[Sensor]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [name] NVARCHAR (MAX) NOT NULL,
    [group_id] INT NOT NULL,
    [nfc_tag] NVARCHAR (MAX) NOT NULL
)

