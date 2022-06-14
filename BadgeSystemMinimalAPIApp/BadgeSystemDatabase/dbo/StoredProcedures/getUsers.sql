CREATE PROCEDURE [dbo].[getUsers]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT id Id, name Name, surname Surname, phone Phone, email Email, gender Gender, group_id GroupId
	FROM [User]
END