 IF NOT EXISTS (SELECT 1 FROM dbo.[Books])
BEGIN
	INSERT INTO dbo.Books (Title, [Author], [PublicationYear])
	VALUES 
	('Book1', 'Author1', 2003),
	('Book2', 'Author2', 2013),
	('Book3', 'Author3', 2023)
END