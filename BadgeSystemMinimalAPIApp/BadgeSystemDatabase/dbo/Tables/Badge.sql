CREATE TABLE [dbo].[Badge] (
    [id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [user_id] INT NOT NULL,
    [nfc_tag] NVARCHAR(MAX) NOT NULL
);