IF NOT EXISTS (SELECT 1 FROM [dbo].[User])
BEGIN
	EXEC dbo.insertUser 'Alex', 'Adams', '039 329 3334', 'alex.adams@gmail.com', 'M', 1;
	EXEC dbo.insertUser 'Beninjo', 'Chotto', '032 023 1003', 'beninjo.chotto@gmail.com', 'M', 2;
	EXEC dbo.insertUser 'Tim', 'Tom', '000 000 0007', 'tim.tom@gmail.com', 'M', 3;
END
