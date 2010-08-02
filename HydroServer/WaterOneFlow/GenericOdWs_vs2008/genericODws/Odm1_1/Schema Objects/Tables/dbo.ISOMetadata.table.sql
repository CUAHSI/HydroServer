CREATE TABLE [dbo].[ISOMetadata]
(
[MetadataID] [int] NOT NULL IDENTITY(1, 1),
[TopicCategory] [nvarchar] (255) NOT NULL,
[Title] [nvarchar] (255) NOT NULL,
[Abstract] [nvarchar] (max) NOT NULL,
[ProfileVersion] [nvarchar] (255) NOT NULL,
[MetadataLink] [nvarchar] (500) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


