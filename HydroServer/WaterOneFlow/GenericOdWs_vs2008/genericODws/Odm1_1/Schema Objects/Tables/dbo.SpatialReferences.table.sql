CREATE TABLE [dbo].[SpatialReferences]
(
[SpatialReferenceID] [int] NOT NULL IDENTITY(1, 1),
[SRSID] [int] NULL,
[SRSName] [nvarchar] (255) NOT NULL,
[IsGeographic] [bit] NULL,
[Notes] [nvarchar] (max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


