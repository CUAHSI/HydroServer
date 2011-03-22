CREATE TABLE [dbo].[LabMethods]
(
[LabMethodID] [int] NOT NULL IDENTITY(1, 1),
[LabName] [nvarchar] (255) NOT NULL,
[LabOrganization] [nvarchar] (255) NOT NULL,
[LabMethodName] [nvarchar] (255) NOT NULL,
[LabMethodDescription] [nvarchar] (max) NOT NULL,
[LabMethodLink] [nvarchar] (500) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


