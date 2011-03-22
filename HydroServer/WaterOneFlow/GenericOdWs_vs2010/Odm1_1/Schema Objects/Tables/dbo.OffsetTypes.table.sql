CREATE TABLE [dbo].[OffsetTypes]
(
[OffsetTypeID] [int] NOT NULL IDENTITY(1, 1),
[OffsetUnitsID] [int] NOT NULL,
[OffsetDescription] [nvarchar] (max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


