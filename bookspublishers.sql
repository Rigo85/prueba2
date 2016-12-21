insert into BooksPublishers(PublisherId, BookId, PublicationDate) 
values(4, 2, GETDATE())

select * from BookDetails
	inner join Publisher on Publisher.PublisherId = BooksPublishers.PublisherId
where Publisher.PublisherId = 1

SELECT BookDetails.*
	FROM Publisher 
		INNER JOIN BooksPublishers ON Publisher.PublisherId = BooksPublishers.PublisherId 
		INNER JOIN BookDetails ON BooksPublishers.BookId = BookDetails.BookId
	WHERE Publisher.PublisherId = 1 and BookDetails.Active = 1



select BookId from BooksPublishers where PublisherId = 1

select * from BooksPublishers

exec InsertPublisherBook_SP @PublisherId = 1, @BookId = 2