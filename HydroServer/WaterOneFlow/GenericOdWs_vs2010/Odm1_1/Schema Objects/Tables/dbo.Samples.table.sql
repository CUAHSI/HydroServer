CREATE TABLE [dbo].[Samples]
(
[SampleID] [int] NOT NULL IDENTITY(1, 1),
[SampleType] [nvarchar] (255) NOT NULL,
[LabSampleCode] [nvarchar] (50) NOT NULL,
[LabMethodID] [int] NOT NULL
) ON [PRIMARY]


