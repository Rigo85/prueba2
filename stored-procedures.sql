ALTER PROC [dbo].[InsertBookDetails_SP]
@BookName  VARCHAR(100),
@Author    VARCHAR(100),
@Price     DECIMAL(18,2)
AS
BEGIN
	INSERT INTO BookDetails	(BookName,Author,Price)
		VALUES (@BookName,@Author,@Price)

	SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]
END

GO

ALTER PROC [dbo].[UpdateBookRecord_SP]
@BookId    INT,
@BookName  VARCHAR(100),
@Author    VARCHAR(100),
@Price     DECIMAL(18,2)
AS
BEGIN
	UPDATE BookDetails SET
		BookName=@BookName,
		Author=@Author,
		Price=@Price
	WHERE BookId=@BookId
END

GO

ALTER PROC [dbo].[DeleteBookRecords_Sp]
@BookId INT
AS
BEGIN
	UPDATE BookDetails SET
		Active = 0
	WHERE BookId=@BookId
END

GO

ALTER PROC [dbo].[FetchBookRecord_Sp]
@BookId INT
AS
BEGIN
	SELECT * 
		FROM BookDetails
		WHERE BookId = @BookId AND Active = 1
END

GO

ALTER PROC [dbo].[FetchBookRecords_Sp]
AS
BEGIN
	SELECT * 
		FROM BookDetails
		WHERE Active = 1
END

GO

-- publisher

ALTER PROC [dbo].[InsertPublishers_SP]
@PublisherName  VARCHAR(100)
AS
BEGIN
	INSERT INTO Publisher (PublisherName)
		VALUES (@PublisherName)

	SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]
END

GO

ALTER PROC [dbo].[UpdatePublishers_SP]
@PublisherId INT,
@PublisherName  VARCHAR(100)
AS
BEGIN
	UPDATE Publisher SET
		PublisherName=@PublisherName
	WHERE PublisherId=@PublisherId
END

GO

ALTER PROC [dbo].[DeletePublishers_Sp]
@PublisherId INT
AS
BEGIN
	UPDATE Publisher SET
		Active = 0
	WHERE PublisherId=@PublisherId
END

GO

ALTER PROC [dbo].[FetchPublishers_Sp]
AS
BEGIN
	SELECT * 
		FROM Publisher
		WHERE Active = 1
END

GO

ALTER PROC [dbo].[FetchPublisher_Sp]
@PublisherId INT
AS
BEGIN
	SELECT * 
		FROM Publisher
		WHERE PublisherId = @PublisherId AND Active = 1
END

GO

ALTER PROC [dbo].[FetchPublisherBooks_Sp]
@PublisherId INT
AS
BEGIN
	SELECT BookDetails.*
		FROM Publisher 
			INNER JOIN BooksPublishers ON Publisher.PublisherId = BooksPublishers.PublisherId 
			INNER JOIN BookDetails ON BooksPublishers.BookId = BookDetails.BookId
		WHERE Publisher.PublisherId = @PublisherId and BookDetails.Active = 1
END

GO

ALTER PROC [dbo].[FetchPublisherBooksIds_Sp]
@PublisherId INT
AS
BEGIN
	SELECT BookDetails.BookId
		FROM Publisher 
			INNER JOIN BooksPublishers ON Publisher.PublisherId = BooksPublishers.PublisherId 
			INNER JOIN BookDetails ON BooksPublishers.BookId = BookDetails.BookId
		WHERE Publisher.PublisherId = @PublisherId and BookDetails.Active = 1
END

GO

ALTER PROC [dbo].[InsertPublisherBook_SP]
@PublisherId INT,
@BookId INT
AS
BEGIN
	DECLARE @Exist INT

	SET @Exist = (SELECT COUNT(*) FROM BooksPublishers
		WHERE PublisherId=@PublisherId AND BookId=@BookId)

	IF @Exist = 0
	BEGIN
		INSERT INTO BooksPublishers (PublisherId, BookId, PublicationDate)
			VALUES (@PublisherId, @BookId, GETDATE())

		SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]
	END
END

GO

ALTER PROC [dbo].[RemovePublisherBook_SP]
@PublisherId INT,
@BookId INT
AS
BEGIN
	DELETE FROM BooksPublishers
		WHERE PublisherId=@PublisherId and BookId=@BookId
END

GO