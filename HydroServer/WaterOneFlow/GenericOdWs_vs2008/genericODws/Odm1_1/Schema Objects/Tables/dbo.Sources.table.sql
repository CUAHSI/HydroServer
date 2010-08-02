CREATE TABLE [dbo].[Sources]
(
[SourceID] [int] NOT NULL IDENTITY(1, 1),
[Organization] [nvarchar] (255) NOT NULL,
[SourceDescription] [nvarchar] (max) NOT NULL,
[SourceLink] [nvarchar] (500) NULL,
[ContactName] [nvarchar] (255) NOT NULL,
[Phone] [nvarchar] (255) NOT NULL,
[Email] [nvarchar] (255) NOT NULL,
[Address] [nvarchar] (255) NOT NULL,
[City] [nvarchar] (255) NOT NULL,
[State] [nvarchar] (255) NOT NULL,
[ZipCode] [nvarchar] (255) NOT NULL,
[Citation] [nvarchar] (max) NOT NULL,
[MetadataID] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


