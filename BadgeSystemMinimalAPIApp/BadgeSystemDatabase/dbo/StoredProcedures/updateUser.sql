CREATE PROCEDURE [dbo].[updateUser]
	@Id INT,
	@Name NVARCHAR (MAX),
	@Surname NVARCHAR (MAX),
	@Phone NVARCHAR (MAX),
	@Email NVARCHAR (MAX),
	@Gender NVARCHAR (MAX),
	@GroupId INT
AS
BEGIN
	UPDATE dbo.[User]
	SET 
		[name] = @Name, 
        [surname] = @Surname,
        [phone] = @Phone, 
        [email] =  @Email, 
        [gender] = @Gender, 
        [group_id] = @GroupId
	WHERE [id] = @Id;
END

