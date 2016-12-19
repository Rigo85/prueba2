CREATE TABLE [dbo].[BookDetails]
(
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](100),
	[Author] [varchar](100),
	[Publisher] [varchar](200),
	[Price] [decimal](18, 2) NOT NULL
)
