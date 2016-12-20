CREATE TABLE [dbo].[Publisher]
(
	[PublisherId] [int] IDENTITY(1,1) NOT NULL,
	[PublisherName] [varchar](100),
	[Active][bit]
)