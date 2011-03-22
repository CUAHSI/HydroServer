CREATE TABLE [dbo].[QualityControlLevels]
(
[QualityControlLevelID] [int] NOT NULL IDENTITY(1, 1),
[QualityControlLevelCode] [nvarchar] (50) NOT NULL,
[Definition] [nvarchar] (255) NOT NULL,
[Explanation] [nvarchar] (max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


