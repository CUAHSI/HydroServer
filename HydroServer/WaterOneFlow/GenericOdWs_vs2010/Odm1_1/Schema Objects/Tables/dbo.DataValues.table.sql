CREATE TABLE [dbo].[DataValues]
(
[ValueID] [int] NOT NULL IDENTITY(1, 1),
[DataValue] [float] NOT NULL,
[ValueAccuracy] [float] NULL,
[LocalDateTime] [datetime] NOT NULL,
[UTCOffset] [float] NOT NULL,
[DateTimeUTC] [datetime] NOT NULL,
[SiteID] [int] NOT NULL,
[VariableID] [int] NOT NULL,
[OffsetValue] [float] NULL,
[OffsetTypeID] [int] NULL,
[CensorCode] [nvarchar] (50) NOT NULL,
[QualifierID] [int] NULL,
[MethodID] [int] NOT NULL,
[SourceID] [int] NOT NULL,
[SampleID] [int] NULL,
[DerivedFromID] [int] NULL,
[QualityControlLevelID] [int] NOT NULL
) ON [PRIMARY]


