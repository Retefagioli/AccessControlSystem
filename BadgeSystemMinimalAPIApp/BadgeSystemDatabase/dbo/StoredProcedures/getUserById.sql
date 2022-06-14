CREATE PROCEDURE [dbo].[getUserById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT name Name, surname Surname, phone Phone, email Email, gender Gender, group_id GroupId
	FROM [User]
	WHERE [User].[id] = @Id;
END
