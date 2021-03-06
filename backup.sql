USE [BookDb]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBookRecords_Sp]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DeleteBookRecords_Sp]
@BookId INT
AS
BEGIN
	UPDATE BookDetails SET
		Active = 0
	WHERE BookId=@BookId
END


GO
/****** Object:  StoredProcedure [dbo].[DeletePublishers_Sp]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DeletePublishers_Sp]
@PublisherId INT
AS
BEGIN
	UPDATE Publisher SET
		Active = 0
	WHERE PublisherId=@PublisherId
END


GO
/****** Object:  StoredProcedure [dbo].[FetchBookRecord_Sp]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[FetchBookRecord_Sp]
@BookId INT
AS
BEGIN
	SELECT * 
		FROM BookDetails
		WHERE BookId = @BookId AND Active = 1
END


GO
/****** Object:  StoredProcedure [dbo].[FetchBookRecords_Sp]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[FetchBookRecords_Sp]
AS
BEGIN
	SELECT * 
		FROM BookDetails
		WHERE Active = 1
END


GO
/****** Object:  StoredProcedure [dbo].[FetchPublisher_Sp]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[FetchPublisher_Sp]
@PublisherId INT
AS
BEGIN
	SELECT * 
		FROM Publisher
		WHERE PublisherId = @PublisherId AND Active = 1
END


GO
/****** Object:  StoredProcedure [dbo].[FetchPublisherBooks_Sp]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[FetchPublisherBooks_Sp]
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
/****** Object:  StoredProcedure [dbo].[FetchPublisherBooksIds_Sp]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[FetchPublisherBooksIds_Sp]
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
/****** Object:  StoredProcedure [dbo].[FetchPublishers_Sp]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[FetchPublishers_Sp]
AS
BEGIN
	SELECT * 
		FROM Publisher
		WHERE Active = 1
END


GO
/****** Object:  StoredProcedure [dbo].[InsertBookDetails_SP]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertBookDetails_SP]
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
/****** Object:  StoredProcedure [dbo].[InsertPublisherBook_SP]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[InsertPublisherBook_SP]
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
/****** Object:  StoredProcedure [dbo].[InsertPublishers_SP]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- publisher

CREATE PROC [dbo].[InsertPublishers_SP]
@PublisherName  VARCHAR(100)
AS
BEGIN
	INSERT INTO Publisher (PublisherName)
		VALUES (@PublisherName)

	SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]
END


GO
/****** Object:  StoredProcedure [dbo].[RemovePublisherBook_SP]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[RemovePublisherBook_SP]
@PublisherId INT,
@BookId INT
AS
BEGIN
	DELETE FROM BooksPublishers
		WHERE PublisherId=@PublisherId and BookId=@BookId
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateBookRecord_SP]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[UpdateBookRecord_SP]
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
/****** Object:  StoredProcedure [dbo].[UpdatePublishers_SP]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[UpdatePublishers_SP]
@PublisherId INT,
@PublisherName  VARCHAR(100)
AS
BEGIN
	UPDATE Publisher SET
		PublisherName=@PublisherName
	WHERE PublisherId=@PublisherId
END


GO
/****** Object:  Table [dbo].[BookDetails]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookDetails](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](100) NOT NULL,
	[Author] [varchar](100) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_BookDetails] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BooksPublishers]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksPublishers](
	[BookPublisherId] [int] IDENTITY(1,1) NOT NULL,
	[PublisherId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[PublicationDate] [date] NOT NULL,
 CONSTRAINT [PK_BooksPublishers] PRIMARY KEY CLUSTERED 
(
	[BookPublisherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 21/12/2016 07:32:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Publisher](
	[PublisherId] [int] IDENTITY(1,1) NOT NULL,
	[PublisherName] [varchar](100) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[PublisherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[BookDetails] ADD  CONSTRAINT [DF_BookDetails_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Publisher] ADD  CONSTRAINT [DF_Publisher_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[BooksPublishers]  WITH CHECK ADD  CONSTRAINT [FK_BooksPublishers_BookDetails] FOREIGN KEY([BookId])
REFERENCES [dbo].[BookDetails] ([BookId])
GO
ALTER TABLE [dbo].[BooksPublishers] CHECK CONSTRAINT [FK_BooksPublishers_BookDetails]
GO
ALTER TABLE [dbo].[BooksPublishers]  WITH CHECK ADD  CONSTRAINT [FK_BooksPublishers_Publisher] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publisher] ([PublisherId])
GO
ALTER TABLE [dbo].[BooksPublishers] CHECK CONSTRAINT [FK_BooksPublishers_Publisher]
GO
