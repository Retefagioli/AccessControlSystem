CREATE TABLE [dbo].[User]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [name] NVARCHAR (MAX) NOT NULL,
    [surname] NVARCHAR (MAX) NOT NULL,
    [phone] NVARCHAR (MAX) NOT NULL,
    [email] NVARCHAR (MAX) NOT NULL,
    [gender] NVARCHAR (MAX),
    [group_id] INT NOT NULL
)