ALTER PROC [dbo].[InsertBookDetails_SP]
@BookName  VARCHAR(100),
@Author    VARCHAR(100),
@Publisher  VARCHAR(200),
@Price      DECIMAL(18,2)
AS
BEGIN
INSERT INTO BookDetails
(
	BookName,Author,Publisher,Price
)
VALUES
(
	@BookName,@Author,@Publisher,@Price
)
END

GO

ALTER PROC [dbo].[UpdateBookRecord_SP]
@BookId                            INT,
@BookName                    VARCHAR(100),
@Author                             VARCHAR(100),
@Publisher                        VARCHAR(200),
@Price                                 DECIMAL(18,2)
AS
BEGIN
UPDATE BookDetails SET
                BookName=@BookName,
                Author=@Author,
                Publisher=@Publisher,
                Price=@Price
WHERE BookId=@BookId
END

GO

ALTER PROC [dbo].[DeleteBookRecords_Sp]
                @BookId            INT
AS
BEGIN
                DELETE FROM BookDetails WHERE BookId=@BookId
END

GO

ALTER PROC [dbo].[FetchBookRecords_Sp]
AS
BEGIN
                SELECT * FROM BookDetails
END

