CREATE TABLE [dbo].[Sites]
(
[SiteID] [int] NOT NULL IDENTITY(1, 1),
[SiteCode] [nvarchar] (50) NOT NULL,
[SiteName] [nvarchar] (255) NOT NULL,
[Latitude] [float] NOT NULL,
[Longitude] [float] NOT NULL,
[LatLongDatumID] [int] NOT NULL,
[Elevation_m] [float] NULL,
[VerticalDatum] [nvarchar] (255) NULL,
[LocalX] [float] NULL,
[LocalY] [float] NULL,
[LocalProjectionID] [int] NULL,
[PosAccuracy_m] [float] NULL,
[State] [nvarchar] (255) NULL,
[County] [nvarchar] (255) NULL,
[Comments] [nvarchar] (max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


