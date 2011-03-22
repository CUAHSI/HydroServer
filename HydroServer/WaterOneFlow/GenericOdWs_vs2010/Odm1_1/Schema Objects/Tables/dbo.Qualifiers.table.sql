CREATE TABLE [dbo].[Qualifiers]
(
[QualifierID] [int] NOT NULL IDENTITY(1, 1),
[QualifierCode] [nvarchar] (50) NULL,
[QualifierDescription] [nvarchar] (max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


