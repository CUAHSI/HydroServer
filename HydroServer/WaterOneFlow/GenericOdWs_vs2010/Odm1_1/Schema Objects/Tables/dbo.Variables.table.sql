CREATE TABLE [dbo].[Variables]
(
[VariableID] [int] NOT NULL IDENTITY(1, 1),
[VariableCode] [nvarchar] (50) NOT NULL,
[VariableName] [nvarchar] (255) NOT NULL,
[Speciation] [nvarchar] (255) NOT NULL,
[VariableUnitsID] [int] NOT NULL,
[SampleMedium] [nvarchar] (255) NOT NULL,
[ValueType] [nvarchar] (255) NOT NULL,
[IsRegular] [bit] NOT NULL,
[TimeSupport] [float] NOT NULL,
[TimeUnitsID] [int] NOT NULL,
[DataType] [nvarchar] (255) NOT NULL,
[GeneralCategory] [nvarchar] (255) NOT NULL,
[NoDataValue] [float] NOT NULL
) ON [PRIMARY]


