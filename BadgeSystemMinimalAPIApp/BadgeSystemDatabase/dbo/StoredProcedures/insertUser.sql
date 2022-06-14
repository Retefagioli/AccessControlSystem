CREATE PROCEDURE [dbo].[insertUser]
	@Name NVARCHAR (MAX),
	@Surname NVARCHAR (MAX),
	@Phone NVARCHAR (MAX),
	@Email NVARCHAR (MAX),
	@Gender NVARCHAR (MAX),
	@GroupId INT
AS
BEGIN
	INSERT INTO [User]
	([name], [surname], [phone], [email], [gender], [group_id])
	VALUES 
	(@Name, @Surname, @Phone, @Email, @Gender, @GroupId);
END
