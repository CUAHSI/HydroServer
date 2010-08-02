SET  ARITHABORT, NUMERIC_ROUNDABORT, CONCAT_NULL_YIELDS_NULL, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, QUOTED_IDENTIFIER OFF
GO
:setvar databasename "Odm1_1"

USE [master]

GO

:on error exit

IF  (   DB_ID(N'$(databasename)') IS NOT NULL
    AND DATABASEPROPERTYEX(N'$(databasename)','Status') <> N'ONLINE')
BEGIN
    RAISERROR(N'The state of the target database, %s, is not set to ONLINE. To deploy to this database, its state must be set to ONLINE.', 16, 127,N'$(databasename)') WITH NOWAIT
    RETURN
END
GO

:on error resume
     
CREATE DATABASE [$(databasename)] COLLATE SQL_Latin1_General_CP1_CI_AS 

GO

EXEC sp_dbcmptlevel N'$(databasename)', 90

GO

IF EXISTS (SELECT 1 FROM [sys].[databases] WHERE [name] = N'$(databasename)') 
    ALTER DATABASE [$(databasename)] SET  
	ALLOW_SNAPSHOT_ISOLATION OFF
GO

IF EXISTS (SELECT 1 FROM [sys].[databases] WHERE [name] = N'$(databasename)') 
    ALTER DATABASE [$(databasename)] SET  
	READ_COMMITTED_SNAPSHOT OFF
GO

IF EXISTS (SELECT 1 FROM [sys].[databases] WHERE [name] = N'$(databasename)') 
    ALTER DATABASE [$(databasename)] SET  
	MULTI_USER,
	CURSOR_CLOSE_ON_COMMIT OFF,
	CURSOR_DEFAULT LOCAL,
	AUTO_CLOSE OFF,
	AUTO_CREATE_STATISTICS ON,
	AUTO_SHRINK OFF,
	AUTO_UPDATE_STATISTICS ON,
	AUTO_UPDATE_STATISTICS_ASYNC ON,
	ANSI_NULL_DEFAULT ON,
	ANSI_NULLS OFF,
	ANSI_PADDING OFF,
	ANSI_WARNINGS OFF,
	ARITHABORT OFF,
	CONCAT_NULL_YIELDS_NULL OFF,
	NUMERIC_ROUNDABORT OFF,
	QUOTED_IDENTIFIER OFF,
	RECURSIVE_TRIGGERS OFF,
	RECOVERY FULL,
	PAGE_VERIFY NONE,
	DISABLE_BROKER,
	PARAMETERIZATION SIMPLE
	WITH ROLLBACK IMMEDIATE
GO

IF IS_SRVROLEMEMBER ('sysadmin') = 1
BEGIN

IF EXISTS (SELECT 1 FROM [sys].[databases] WHERE [name] = N'$(databasename)') 
    EXEC sp_executesql N'
    ALTER DATABASE [$(databasename)] SET  
	DB_CHAINING OFF,
	TRUSTWORTHY OFF'

END
ELSE
BEGIN
    RAISERROR(N'Unable to modify the database settings for DB_CHAINING or TRUSTWORTHY. You must be a SysAdmin in order to apply these settings.',0,1)
END

GO

USE [$(databasename)]

GO
-- Pre-Deployment Script Template							
----------------------------------------------------------------------------------------
-- This file contains SQL statements that will be executed before the build script	
-- Use SQLCMD syntax to include a file into the pre-deployment script			
-- Example:      :r .\filename.sql								
-- Use SQLCMD syntax to reference a variable in the pre-deployment script		
-- Example:      :setvar $TableName MyTable							
--               SELECT * FROM [$(TableName)]					
----------------------------------------------------------------------------------------








GO
PRINT N'Creating [dbo].[SpeciationCV]'
GO
CREATE TABLE [dbo].[SpeciationCV]
(
[Term] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Definition] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_SpeciationCV_Term] on [dbo].[SpeciationCV]'
GO
ALTER TABLE [dbo].[SpeciationCV] ADD CONSTRAINT [PK_SpeciationCV_Term] PRIMARY KEY CLUSTERED  ([Term]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[SampleTypeCV]'
GO
CREATE TABLE [dbo].[SampleTypeCV]
(
[Term] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Definition] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_SampleTypeCV_Term] on [dbo].[SampleTypeCV]'
GO
ALTER TABLE [dbo].[SampleTypeCV] ADD CONSTRAINT [PK_SampleTypeCV_Term] PRIMARY KEY CLUSTERED  ([Term]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Units]'
GO
CREATE TABLE [dbo].[Units]
(
[UnitsID] [int] NOT NULL IDENTITY(1, 1),
[UnitsName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[UnitsType] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[UnitsAbbreviation] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Units_UnitsID] on [dbo].[Units]'
GO
ALTER TABLE [dbo].[Units] ADD CONSTRAINT [PK_Units_UnitsID] PRIMARY KEY CLUSTERED  ([UnitsID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[OffsetTypes]'
GO
CREATE TABLE [dbo].[OffsetTypes]
(
[OffsetTypeID] [int] NOT NULL IDENTITY(1, 1),
[OffsetUnitsID] [int] NOT NULL,
[OffsetDescription] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_OffsetTypes_OffsetTypeID] on [dbo].[OffsetTypes]'
GO
ALTER TABLE [dbo].[OffsetTypes] ADD CONSTRAINT [PK_OffsetTypes_OffsetTypeID] PRIMARY KEY CLUSTERED  ([OffsetTypeID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[VerticalDatumCV]'
GO
CREATE TABLE [dbo].[VerticalDatumCV]
(
[Term] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Definition] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_VerticalDatumCV_Term] on [dbo].[VerticalDatumCV]'
GO
ALTER TABLE [dbo].[VerticalDatumCV] ADD CONSTRAINT [PK_VerticalDatumCV_Term] PRIMARY KEY CLUSTERED  ([Term]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[GeneralCategoryCV]'
GO
CREATE TABLE [dbo].[GeneralCategoryCV]
(
[Term] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Definition] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_GeneralCategoryCV_Term] on [dbo].[GeneralCategoryCV]'
GO
ALTER TABLE [dbo].[GeneralCategoryCV] ADD CONSTRAINT [PK_GeneralCategoryCV_Term] PRIMARY KEY CLUSTERED  ([Term]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[SeriesCatalog]'
GO
CREATE TABLE [dbo].[SeriesCatalog]
(
[SeriesID] [int] NOT NULL IDENTITY(1, 1),
[SiteID] [int] NULL,
[SiteCode] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SiteName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[VariableID] [int] NULL,
[VariableCode] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[VariableName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Speciation] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[VariableUnitsID] [int] NULL,
[VariableUnitsName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SampleMedium] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ValueType] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TimeSupport] [float] NULL,
[TimeUnitsID] [int] NULL,
[TimeUnitsName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DataType] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GeneralCategory] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MethodID] [int] NULL,
[MethodDescription] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SourceID] [int] NULL,
[Organization] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SourceDescription] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Citation] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[QualityControlLevelID] [int] NULL,
[QualityControlLevelCode] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[BeginDateTime] [datetime] NULL,
[EndDateTime] [datetime] NULL,
[BeginDateTimeUTC] [datetime] NULL,
[EndDateTimeUTC] [datetime] NULL,
[ValueCount] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_SeriesCatalog_SeriesID] on [dbo].[SeriesCatalog]'
GO
ALTER TABLE [dbo].[SeriesCatalog] ADD CONSTRAINT [PK_SeriesCatalog_SeriesID] PRIMARY KEY CLUSTERED  ([SeriesID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[QualityControlLevels]'
GO
CREATE TABLE [dbo].[QualityControlLevels]
(
[QualityControlLevelID] [int] NOT NULL IDENTITY(1, 1),
[QualityControlLevelCode] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Definition] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Explanation] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_QualityControlLevels_QualityControlLevelID] on [dbo].[QualityControlLevels]'
GO
ALTER TABLE [dbo].[QualityControlLevels] ADD CONSTRAINT [PK_QualityControlLevels_QualityControlLevelID] PRIMARY KEY CLUSTERED  ([QualityControlLevelID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Groups]'
GO
CREATE TABLE [dbo].[Groups]
(
[GroupID] [int] NOT NULL,
[ValueID] [int] NOT NULL
) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[CensorCodeCV]'
GO
CREATE TABLE [dbo].[CensorCodeCV]
(
[Term] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Definition] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_CensorCodeCV_Term] on [dbo].[CensorCodeCV]'
GO
ALTER TABLE [dbo].[CensorCodeCV] ADD CONSTRAINT [PK_CensorCodeCV_Term] PRIMARY KEY CLUSTERED  ([Term]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[ValueTypeCV]'
GO
CREATE TABLE [dbo].[ValueTypeCV]
(
[Term] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Definition] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_ValueTypeCV_Term] on [dbo].[ValueTypeCV]'
GO
ALTER TABLE [dbo].[ValueTypeCV] ADD CONSTRAINT [PK_ValueTypeCV_Term] PRIMARY KEY CLUSTERED  ([Term]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Categories]'
GO
CREATE TABLE [dbo].[Categories]
(
[VariableID] [int] NOT NULL,
[DataValue] [float] NOT NULL,
[CategoryDescription] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating [dbo].[VariableNameCV]'
GO
CREATE TABLE [dbo].[VariableNameCV]
(
[Term] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Definition] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_VariableNameCV_Term] on [dbo].[VariableNameCV]'
GO
ALTER TABLE [dbo].[VariableNameCV] ADD CONSTRAINT [PK_VariableNameCV_Term] PRIMARY KEY CLUSTERED  ([Term]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Methods]'
GO
CREATE TABLE [dbo].[Methods]
(
[MethodID] [int] NOT NULL IDENTITY(1, 1),
[MethodDescription] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MethodLink] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Methods_MethodID] on [dbo].[Methods]'
GO
ALTER TABLE [dbo].[Methods] ADD CONSTRAINT [PK_Methods_MethodID] PRIMARY KEY CLUSTERED  ([MethodID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[SampleMediumCV]'
GO
CREATE TABLE [dbo].[SampleMediumCV]
(
[Term] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Definition] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_SampleMediumCV_Term] on [dbo].[SampleMediumCV]'
GO
ALTER TABLE [dbo].[SampleMediumCV] ADD CONSTRAINT [PK_SampleMediumCV_Term] PRIMARY KEY CLUSTERED  ([Term]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[SpatialReferences]'
GO
CREATE TABLE [dbo].[SpatialReferences]
(
[SpatialReferenceID] [int] NOT NULL IDENTITY(1, 1),
[SRSID] [int] NULL,
[SRSName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsGeographic] [bit] NULL,
[Notes] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_SpatialReferences_SpatialReferenceID] on [dbo].[SpatialReferences]'
GO
ALTER TABLE [dbo].[SpatialReferences] ADD CONSTRAINT [PK_SpatialReferences_SpatialReferenceID] PRIMARY KEY CLUSTERED  ([SpatialReferenceID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[DataTypeCV]'
GO
CREATE TABLE [dbo].[DataTypeCV]
(
[Term] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Definition] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_DataTypeCV_Term] on [dbo].[DataTypeCV]'
GO
ALTER TABLE [dbo].[DataTypeCV] ADD CONSTRAINT [PK_DataTypeCV_Term] PRIMARY KEY CLUSTERED  ([Term]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[GroupDescriptions]'
GO
CREATE TABLE [dbo].[GroupDescriptions]
(
[GroupID] [int] NOT NULL IDENTITY(1, 1),
[GroupDescription] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_GroupDescriptions_GroupID] on [dbo].[GroupDescriptions]'
GO
ALTER TABLE [dbo].[GroupDescriptions] ADD CONSTRAINT [PK_GroupDescriptions_GroupID] PRIMARY KEY CLUSTERED  ([GroupID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[DerivedFrom]'
GO
CREATE TABLE [dbo].[DerivedFrom]
(
[DerivedFromID] [int] NOT NULL,
[ValueID] [int] NOT NULL
) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[TopicCategoryCV]'
GO
CREATE TABLE [dbo].[TopicCategoryCV]
(
[Term] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Definition] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_TopicCategoryCV_Term] on [dbo].[TopicCategoryCV]'
GO
ALTER TABLE [dbo].[TopicCategoryCV] ADD CONSTRAINT [PK_TopicCategoryCV_Term] PRIMARY KEY CLUSTERED  ([Term]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Qualifiers]'
GO
CREATE TABLE [dbo].[Qualifiers]
(
[QualifierID] [int] NOT NULL IDENTITY(1, 1),
[QualifierCode] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[QualifierDescription] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Qualifiers_QualifierID] on [dbo].[Qualifiers]'
GO
ALTER TABLE [dbo].[Qualifiers] ADD CONSTRAINT [PK_Qualifiers_QualifierID] PRIMARY KEY CLUSTERED  ([QualifierID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Variables]'
GO
CREATE TABLE [dbo].[Variables]
(
[VariableID] [int] NOT NULL IDENTITY(1, 1),
[VariableCode] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[VariableName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Speciation] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Variables_Speciation] DEFAULT ('Not Applicable'),
[VariableUnitsID] [int] NOT NULL,
[SampleMedium] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Variables_SampleMedium] DEFAULT ('Unknown'),
[ValueType] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Variables_ValueType] DEFAULT ('Unknown'),
[IsRegular] [bit] NOT NULL CONSTRAINT [DF_Variables_IsRegular] DEFAULT ((0)),
[TimeSupport] [float] NOT NULL CONSTRAINT [DF_Variables_TimeSupport] DEFAULT ((0)),
[TimeUnitsID] [int] NOT NULL CONSTRAINT [DF_Variables_TimeUnitsID] DEFAULT ((103)),
[DataType] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Variables_DataType] DEFAULT ('Unknown'),
[GeneralCategory] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Variables_GeneralCategory] DEFAULT ('Unknown'),
[NoDataValue] [float] NOT NULL CONSTRAINT [DF_Variables_NoDataValue] DEFAULT ((-9999))
) ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Variables_VariableID] on [dbo].[Variables]'
GO
ALTER TABLE [dbo].[Variables] ADD CONSTRAINT [PK_Variables_VariableID] PRIMARY KEY CLUSTERED  ([VariableID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Samples]'
GO
CREATE TABLE [dbo].[Samples]
(
[SampleID] [int] NOT NULL IDENTITY(1, 1),
[SampleType] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Samples_SampleType] DEFAULT ('Unknown'),
[LabSampleCode] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LabMethodID] [int] NOT NULL CONSTRAINT [DF_Samples_LabMethodID] DEFAULT ((0))
) ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Samples_SampleID] on [dbo].[Samples]'
GO
ALTER TABLE [dbo].[Samples] ADD CONSTRAINT [PK_Samples_SampleID] PRIMARY KEY CLUSTERED  ([SampleID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[LabMethods]'
GO
CREATE TABLE [dbo].[LabMethods]
(
[LabMethodID] [int] NOT NULL IDENTITY(1, 1),
[LabName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_LabMethods_LabName] DEFAULT ('Unknown'),
[LabOrganization] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_LabMethods_LabOrganization] DEFAULT ('Unknown'),
[LabMethodName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_LabMethods_LabMethodName] DEFAULT ('Unknown'),
[LabMethodDescription] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_LabMethods_LabMethodDescription] DEFAULT ('Unknown'),
[LabMethodLink] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_LabMethods_LabMethodID] on [dbo].[LabMethods]'
GO
ALTER TABLE [dbo].[LabMethods] ADD CONSTRAINT [PK_LabMethods_LabMethodID] PRIMARY KEY CLUSTERED  ([LabMethodID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[ISOMetadata]'
GO
CREATE TABLE [dbo].[ISOMetadata]
(
[MetadataID] [int] NOT NULL IDENTITY(1, 1),
[TopicCategory] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_ISOMetadata_TopicCategory] DEFAULT ('Unknown'),
[Title] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_ISOMetadata_Title] DEFAULT ('Unknown'),
[Abstract] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_ISOMetadata_Abstract] DEFAULT ('Unknown'),
[ProfileVersion] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_ISOMetadata_ProfileVersion] DEFAULT ('Unknown'),
[MetadataLink] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_ISOMetadata_MetadataID] on [dbo].[ISOMetadata]'
GO
ALTER TABLE [dbo].[ISOMetadata] ADD CONSTRAINT [PK_ISOMetadata_MetadataID] PRIMARY KEY CLUSTERED  ([MetadataID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[DataValues]'
GO
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
[CensorCode] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_DataValues_CensorCode] DEFAULT ('nc'),
[QualifierID] [int] NULL,
[MethodID] [int] NOT NULL CONSTRAINT [DF_DataValues_MethodID] DEFAULT ((0)),
[SourceID] [int] NOT NULL,
[SampleID] [int] NULL,
[DerivedFromID] [int] NULL,
[QualityControlLevelID] [int] NOT NULL CONSTRAINT [DF_DataValues_QualityControlLevelID] DEFAULT ((-9999))
) ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_DataValues_ValueID] on [dbo].[DataValues]'
GO
ALTER TABLE [dbo].[DataValues] ADD CONSTRAINT [PK_DataValues_ValueID] PRIMARY KEY CLUSTERED  ([ValueID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Sources]'
GO
CREATE TABLE [dbo].[Sources]
(
[SourceID] [int] NOT NULL IDENTITY(1, 1),
[Organization] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SourceDescription] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SourceLink] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ContactName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Sources_ContactName] DEFAULT ('Unknown'),
[Phone] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Sources_Phone] DEFAULT ('Unknown'),
[Email] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Sources_Email] DEFAULT ('Unknown'),
[Address] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Sources_Address] DEFAULT ('Unknown'),
[City] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Sources_City] DEFAULT ('Unknown'),
[State] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Sources_State] DEFAULT ('Unknown'),
[ZipCode] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Sources_ZipCode] DEFAULT ('Unknown'),
[Citation] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Sources_Citation] DEFAULT ('Unknown'),
[MetadataID] [int] NOT NULL CONSTRAINT [DF_Sources_MetadataID] DEFAULT ((0))
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Sources_SourceID] on [dbo].[Sources]'
GO
ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [PK_Sources_SourceID] PRIMARY KEY CLUSTERED  ([SourceID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Sites]'
GO
CREATE TABLE [dbo].[Sites]
(
[SiteID] [int] NOT NULL IDENTITY(1, 1),
[SiteCode] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SiteName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Latitude] [float] NOT NULL,
[Longitude] [float] NOT NULL,
[LatLongDatumID] [int] NOT NULL CONSTRAINT [DF_Sites_LatLongDatumID] DEFAULT ((0)),
[Elevation_m] [float] NULL,
[VerticalDatum] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LocalX] [float] NULL,
[LocalY] [float] NULL,
[LocalProjectionID] [int] NULL,
[PosAccuracy_m] [float] NULL,
[State] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[County] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Comments] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Sites_SiteID] on [dbo].[Sites]'
GO
ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [PK_Sites_SiteID] PRIMARY KEY CLUSTERED  ([SiteID]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[spUpdateSeriesCatalog]'
GO
-- =============================================
-- Author:		Jeff Horsburgh
-- Create date: 10-5-2006
-- Modified:  1-31-2007
-- Description:	Clears the SeriesCatalog table
-- and regenerates it from scratch.
-- =============================================

CREATE PROCEDURE [dbo].[spUpdateSeriesCatalog] AS

--Clear out the entire SeriesCatalog Table
DELETE FROM  [SeriesCatalog]

--Reset the primary key field
DBCC CHECKIDENT (SeriesCatalog, RESEED, 0)

--Recreate the records in the SeriesCatalog Table
INSERT INTO [SeriesCatalog]
SELECT     dv.SiteID, s.SiteCode, s.SiteName, dv.VariableID, v.VariableCode, 
           v.VariableName, v.Speciation, v.VariableUnitsID, u.UnitsName AS VariableUnitsName, v.SampleMedium, 
           v.ValueType, v.TimeSupport, v.TimeUnitsID, u1.UnitsName AS TimeUnitsName, v.DataType, 
           v.GeneralCategory, dv.MethodID, m.MethodDescription, dv.SourceID, so.Organization, 
           so.SourceDescription, so.Citation, dv.QualityControlLevelID, qc.QualityControlLevelCode, dv.BeginDateTime, 
           dv.EndDateTime, dv.BeginDateTimeUTC, dv.EndDateTimeUTC, dv.ValueCount 
FROM  (
SELECT SiteID, VariableID, MethodID, QualityControlLevelID, SourceID, MIN(LocalDateTime) AS BeginDateTime, 
           MAX(LocalDateTime) AS EndDateTime, MIN(DateTimeUTC) AS BeginDateTimeUTC, MAX(DateTimeUTC) AS EndDateTimeUTC, 
		   COUNT(DataValue) AS ValueCount
FROM DataValues
GROUP BY SiteID, VariableID, MethodID, QualityControlLevelID, SourceID) dv
           INNER JOIN dbo.Sites s ON dv.SiteID = s.SiteID 
		   INNER JOIN dbo.Variables v ON dv.VariableID = v.VariableID 
		   INNER JOIN dbo.Units u ON v.VariableUnitsID = u.UnitsID 
		   INNER JOIN dbo.Methods m ON dv.MethodID = m.MethodID 
		   INNER JOIN dbo.Units u1 ON v.TimeUnitsID = u1.UnitsID 
		   INNER JOIN dbo.Sources so ON dv.SourceID = so.SourceID 
		   INNER JOIN dbo.QualityControlLevels qc ON dv.QualityControlLevelID = qc.QualityControlLevelID
GROUP BY   dv.SiteID, s.SiteCode, s.SiteName, dv.VariableID, v.VariableCode, v.VariableName, v.Speciation,
           v.VariableUnitsID, u.UnitsName, v.SampleMedium, v.ValueType, v.TimeSupport, v.TimeUnitsID, u1.UnitsName, 
		   v.DataType, v.GeneralCategory, dv.MethodID, m.MethodDescription, dv.SourceID, so.Organization, 
		   so.SourceDescription, so.Citation, dv.QualityControlLevelID, qc.QualityControlLevelCode, dv.BeginDateTime,
		   dv.EndDateTime, dv.BeginDateTimeUTC, dv.EndDateTimeUTC, dv.ValueCount
ORDER BY   dv.SiteID, dv.VariableID, v.VariableUnitsID
GO
PRINT N'Creating [dbo].[ODMVersion]'
GO
CREATE TABLE [dbo].[ODMVersion]
(
[VersionNumber] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
PRINT N'Adding constraints to [dbo].[QualityControlLevels]'
GO
ALTER TABLE [dbo].[QualityControlLevels] ADD CONSTRAINT [CK_QualityControlLevels_QualityControlLevelCode] CHECK ((NOT [QualityControlLevelCode] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[QualityControlLevels] ADD CONSTRAINT [CK_QualityControlLevels_Definition] CHECK ((NOT [Definition] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[ODMVersion]'
GO
ALTER TABLE [dbo].[ODMVersion] ADD CONSTRAINT [CK_ODMVersion_VersionNumber] CHECK ((NOT [VersionNumber] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[VariableNameCV]'
GO
ALTER TABLE [dbo].[VariableNameCV] ADD CONSTRAINT [CK_VariableNameCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[LabMethods]'
GO
ALTER TABLE [dbo].[LabMethods] ADD CONSTRAINT [CK_LabMethods_LabName] CHECK ((NOT [LabName] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[LabMethods] ADD CONSTRAINT [CK_LabMethods_LabOrganization] CHECK ((NOT [LabOrganization] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[LabMethods] ADD CONSTRAINT [CK_LabMethods_LabMethodName] CHECK ((NOT [LabMethodName] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[Sources]'
GO
ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_Organization] CHECK ((NOT [Organization] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_ContactName] CHECK ((NOT [ContactName] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_Phone] CHECK ((NOT [Phone] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_Email] CHECK ((NOT [Email] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_Address] CHECK ((NOT [Address] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_City] CHECK ((NOT [City] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_State] CHECK ((NOT [State] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_ZipCode] CHECK ((NOT [ZipCode] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[SpeciationCV]'
GO
ALTER TABLE [dbo].[SpeciationCV] ADD CONSTRAINT [CK_SpeciationCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[ValueTypeCV]'
GO
ALTER TABLE [dbo].[ValueTypeCV] ADD CONSTRAINT [CK_ValueTypeCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[CensorCodeCV]'
GO
ALTER TABLE [dbo].[CensorCodeCV] ADD CONSTRAINT [CK_CensorCodeCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[Qualifiers]'
GO
ALTER TABLE [dbo].[Qualifiers] ADD CONSTRAINT [CK_Qualifiers_QualifierCode] CHECK ((NOT [QualifierCode] like (((('%['+char((9)))+char((10)))+char((13)))+char((32)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[SampleTypeCV]'
GO
ALTER TABLE [dbo].[SampleTypeCV] ADD CONSTRAINT [CK_SampleTypeCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[Sites]'
GO
ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [CK_Sites_SiteCode] CHECK ((NOT [SiteCode] like '%[^-.A-Z0-9/_]%' escape '/' ))
GO
ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [CK_Sites_SiteName] CHECK ((NOT [SiteName] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [CK_Sites_Latitude] CHECK (([Latitude]>=(-90) AND [Latitude]<=(90)))
GO
ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [CK_Sites_Longitude] CHECK (([Longitude]>=(-180) AND [Longitude]<=(360)))
GO
ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [CK_Sites_State] CHECK ((NOT [State] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [CK_Sites_County] CHECK ((NOT [County] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [AK_Sites_SiteCode] UNIQUE NONCLUSTERED  ([SiteCode]) ON [PRIMARY]
GO
PRINT N'Adding constraints to [dbo].[Variables]'
GO
ALTER TABLE [dbo].[Variables] ADD CONSTRAINT [CK_Variables_VariableCode] CHECK ((NOT [VariableCode] like '%[^-.A-Z0-9/_]%' escape '/' ))
GO
ALTER TABLE [dbo].[Variables] ADD CONSTRAINT [AK_Variables_VariableCode] UNIQUE NONCLUSTERED  ([VariableCode]) ON [PRIMARY]
GO
PRINT N'Adding constraints to [dbo].[TopicCategoryCV]'
GO
ALTER TABLE [dbo].[TopicCategoryCV] ADD CONSTRAINT [CK_TopicCategoryCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[GeneralCategoryCV]'
GO
ALTER TABLE [dbo].[GeneralCategoryCV] ADD CONSTRAINT [CK_GeneralCategoryCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[DataTypeCV]'
GO
ALTER TABLE [dbo].[DataTypeCV] ADD CONSTRAINT [CK_DataTypeCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[ISOMetadata]'
GO
ALTER TABLE [dbo].[ISOMetadata] ADD CONSTRAINT [CK_ISOMetadata_Title] CHECK ((NOT [Title] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[ISOMetadata] ADD CONSTRAINT [CK_ISOMetadata_ProfileVersion] CHECK ((NOT [ProfileVersion] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[VerticalDatumCV]'
GO
ALTER TABLE [dbo].[VerticalDatumCV] ADD CONSTRAINT [CK_VerticalDatumCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[Samples]'
GO
ALTER TABLE [dbo].[Samples] ADD CONSTRAINT [CK_Samples_LabSampleCode] CHECK ((NOT [LabSampleCode] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[Units]'
GO
ALTER TABLE [dbo].[Units] ADD CONSTRAINT [CK_Units_UnitsName] CHECK ((NOT [UnitsName] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[Units] ADD CONSTRAINT [CK_Units_UnitsType] CHECK ((NOT [UnitsType] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[Units] ADD CONSTRAINT [CK_Units_UnitsAbbreviation] CHECK ((NOT [UnitsAbbreviation] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[SampleMediumCV]'
GO
ALTER TABLE [dbo].[SampleMediumCV] ADD CONSTRAINT [CK_SampleMediumCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding constraints to [dbo].[SpatialReferences]'
GO
ALTER TABLE [dbo].[SpatialReferences] ADD CONSTRAINT [CK_SpatialReferences_SRSName] CHECK ((NOT [SRSName] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
PRINT N'Adding foreign keys to [dbo].[Categories]'
GO
ALTER TABLE [dbo].[Categories] WITH NOCHECK ADD
CONSTRAINT [FK_Categories_Variables] FOREIGN KEY ([VariableID]) REFERENCES [dbo].[Variables] ([VariableID])
GO
PRINT N'Adding foreign keys to [dbo].[DerivedFrom]'
GO
ALTER TABLE [dbo].[DerivedFrom] WITH NOCHECK ADD
CONSTRAINT [FK_DerivedFrom_DataValues] FOREIGN KEY ([ValueID]) REFERENCES [dbo].[DataValues] ([ValueID])
GO
PRINT N'Adding foreign keys to [dbo].[Groups]'
GO
ALTER TABLE [dbo].[Groups] WITH NOCHECK ADD
CONSTRAINT [FK_Groups_DataValues] FOREIGN KEY ([ValueID]) REFERENCES [dbo].[DataValues] ([ValueID])
GO
PRINT N'Adding foreign keys to [dbo].[DataValues]'
GO
ALTER TABLE [dbo].[DataValues] WITH NOCHECK ADD
CONSTRAINT [FK_DataValues_Sites] FOREIGN KEY ([SiteID]) REFERENCES [dbo].[Sites] ([SiteID]) ON UPDATE CASCADE,
CONSTRAINT [FK_DataValues_Variables] FOREIGN KEY ([VariableID]) REFERENCES [dbo].[Variables] ([VariableID]),
CONSTRAINT [FK_DataValues_OffsetTypes] FOREIGN KEY ([OffsetTypeID]) REFERENCES [dbo].[OffsetTypes] ([OffsetTypeID]),
CONSTRAINT [FK_DataValues_Qualifiers] FOREIGN KEY ([QualifierID]) REFERENCES [dbo].[Qualifiers] ([QualifierID]),
CONSTRAINT [FK_DataValues_Methods] FOREIGN KEY ([MethodID]) REFERENCES [dbo].[Methods] ([MethodID]),
CONSTRAINT [FK_DataValues_Sources] FOREIGN KEY ([SourceID]) REFERENCES [dbo].[Sources] ([SourceID]),
CONSTRAINT [FK_DataValues_Samples] FOREIGN KEY ([SampleID]) REFERENCES [dbo].[Samples] ([SampleID]),
CONSTRAINT [FK_DataValues_QualityControlLevels] FOREIGN KEY ([QualityControlLevelID]) REFERENCES [dbo].[QualityControlLevels] ([QualityControlLevelID])
GO
PRINT N'Adding foreign keys to [dbo].[Samples]'
GO
ALTER TABLE [dbo].[Samples] WITH NOCHECK ADD
CONSTRAINT [FK_Samples_LabMethods] FOREIGN KEY ([LabMethodID]) REFERENCES [dbo].[LabMethods] ([LabMethodID])
GO
PRINT N'Adding foreign keys to [dbo].[Variables]'
GO
ALTER TABLE [dbo].[Variables] WITH NOCHECK ADD
CONSTRAINT [FK_Variables_Units] FOREIGN KEY ([VariableUnitsID]) REFERENCES [dbo].[Units] ([UnitsID]) ON UPDATE CASCADE
GO
PRINT N'Adding foreign keys to [dbo].[DataValues]'
GO
ALTER TABLE [dbo].[DataValues] ADD
CONSTRAINT [FK_DataValues_CensorCodeCV] FOREIGN KEY ([CensorCode]) REFERENCES [dbo].[CensorCodeCV] ([Term])
GO
PRINT N'Adding foreign keys to [dbo].[Variables]'
GO
ALTER TABLE [dbo].[Variables] ADD
CONSTRAINT [FK_Variables_DataTypeCV] FOREIGN KEY ([DataType]) REFERENCES [dbo].[DataTypeCV] ([Term]),
CONSTRAINT [FK_Variables_GeneralCategoryCV] FOREIGN KEY ([GeneralCategory]) REFERENCES [dbo].[GeneralCategoryCV] ([Term]),
CONSTRAINT [FK_Variables_SampleMediumCV] FOREIGN KEY ([SampleMedium]) REFERENCES [dbo].[SampleMediumCV] ([Term]),
CONSTRAINT [FK_Variables_SpeciationCV] FOREIGN KEY ([Speciation]) REFERENCES [dbo].[SpeciationCV] ([Term]),
CONSTRAINT [FK_Variables_Units1] FOREIGN KEY ([TimeUnitsID]) REFERENCES [dbo].[Units] ([UnitsID]),
CONSTRAINT [FK_Variables_ValueTypeCV] FOREIGN KEY ([ValueType]) REFERENCES [dbo].[ValueTypeCV] ([Term]),
CONSTRAINT [FK_Variables_VariableNameCV] FOREIGN KEY ([VariableName]) REFERENCES [dbo].[VariableNameCV] ([Term])
GO
PRINT N'Adding foreign keys to [dbo].[Groups]'
GO
ALTER TABLE [dbo].[Groups] ADD
CONSTRAINT [FK_Groups_GroupDescriptions] FOREIGN KEY ([GroupID]) REFERENCES [dbo].[GroupDescriptions] ([GroupID])
GO
PRINT N'Adding foreign keys to [dbo].[Sources]'
GO
ALTER TABLE [dbo].[Sources] ADD
CONSTRAINT [FK_Sources_ISOMetaData] FOREIGN KEY ([MetadataID]) REFERENCES [dbo].[ISOMetadata] ([MetadataID])
GO
PRINT N'Adding foreign keys to [dbo].[ISOMetadata]'
GO
ALTER TABLE [dbo].[ISOMetadata] ADD
CONSTRAINT [FK_ISOMetadata_TopicCategoryCV] FOREIGN KEY ([TopicCategory]) REFERENCES [dbo].[TopicCategoryCV] ([Term])
GO
PRINT N'Adding foreign keys to [dbo].[OffsetTypes]'
GO
ALTER TABLE [dbo].[OffsetTypes] ADD
CONSTRAINT [FK_OffsetTypes_Units] FOREIGN KEY ([OffsetUnitsID]) REFERENCES [dbo].[Units] ([UnitsID])
GO
PRINT N'Adding foreign keys to [dbo].[Samples]'
GO
ALTER TABLE [dbo].[Samples] ADD
CONSTRAINT [FK_Samples_SampleTypeCV] FOREIGN KEY ([SampleType]) REFERENCES [dbo].[SampleTypeCV] ([Term])
GO
PRINT N'Adding foreign keys to [dbo].[Sites]'
GO
ALTER TABLE [dbo].[Sites] ADD
CONSTRAINT [FK_Sites_SpatialReferences] FOREIGN KEY ([LatLongDatumID]) REFERENCES [dbo].[SpatialReferences] ([SpatialReferenceID]),
CONSTRAINT [FK_Sites_VerticalDatumCV] FOREIGN KEY ([VerticalDatum]) REFERENCES [dbo].[VerticalDatumCV] ([Term]),
CONSTRAINT [FK_Sites_SpatialReferences1] FOREIGN KEY ([LocalProjectionID]) REFERENCES [dbo].[SpatialReferences] ([SpatialReferenceID])
GO
PRINT N'Creating extended properties'
GO
EXEC sp_addextendedproperty N'Attributes', N'0', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'DateCreated', N'6/14/2006 9:57:00 PM', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'LastUpdated', N'6/14/2006 9:57:00 PM', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DefaultView', N'2', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderByOn', N'False', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Orientation', N'0', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Name', N'CensorCodeCV', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'RecordCount', N'4', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Updatable', N'True', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Name', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'0', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceField', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceTable', N'CensorCodeCV', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Name', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'1', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceField', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceTable', N'CensorCodeCV', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'CensorCodeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'0', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'DateCreated', N'6/14/2006 10:31:20 PM', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'LastUpdated', N'6/14/2006 10:31:20 PM', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DefaultView', N'2', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderByOn', N'False', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Orientation', N'0', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Name', N'DataTypeCV', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'RecordCount', N'0', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Updatable', N'True', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'GUID', N'觹洌乧쮻峯㹭鷰', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Name', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'0', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceField', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceTable', N'DataTypeCV', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'GUID', N'萌冘킱䤬ඞ繓ꖬꓜ', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Name', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'1', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceField', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceTable', N'DataTypeCV', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'DataTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'DateCreated', N'6/14/2006 10:31:54 PM', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'LastUpdated', N'6/15/2006 1:59:39 PM', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DefaultView', N'2', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderByOn', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Orientation', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Name', N'GeneralCategoryCV', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'RecordCount', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Updatable', N'True', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'GUID', N'鹰퓬⻃䤱⒑劶踏꫸', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Name', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceField', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceTable', N'GeneralCategoryCV', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'GUID', N'춤༑ᗍ䦳㖇綆᧏㍣', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Name', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'1', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceField', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceTable', N'GeneralCategoryCV', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'DateCreated', N'6/14/2006 10:28:35 PM', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'LastUpdated', N'6/14/2006 10:28:35 PM', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DefaultView', N'2', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderByOn', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Orientation', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Name', N'SampleMediumCV', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'RecordCount', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Updatable', N'True', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Name', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceField', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceTable', N'SampleMediumCV', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Name', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'1', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceField', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceTable', N'SampleMediumCV', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'SampleMediumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'DateCreated', N'6/14/2006 10:40:20 PM', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'LastUpdated', N'6/14/2006 10:40:20 PM', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DefaultView', N'2', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderByOn', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Orientation', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Name', N'SampleTypeCV', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'RecordCount', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Updatable', N'True', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Name', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceField', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceTable', N'SampleTypeCV', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Name', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'1', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceField', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceTable', N'SampleTypeCV', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'SampleTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'0', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'DateCreated', N'6/15/2006 2:03:32 PM', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'LastUpdated', N'6/15/2006 2:03:32 PM', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DefaultView', N'2', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderByOn', N'False', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Orientation', N'0', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Name', N'TopicCategoryCV', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'RecordCount', N'0', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Updatable', N'True', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Name', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'0', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceField', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceTable', N'TopicCategoryCV', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Name', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'1', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceField', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceTable', N'TopicCategoryCV', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'TopicCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'0', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'DateCreated', N'6/14/2006 10:29:10 PM', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'LastUpdated', N'6/14/2006 10:29:31 PM', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DefaultView', N'2', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderByOn', N'False', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Orientation', N'0', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Name', N'ValueTypeCV', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'RecordCount', N'0', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Updatable', N'True', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Name', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'1', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceField', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceTable', N'ValueTypeCV', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Name', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'2', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceField', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceTable', N'ValueTypeCV', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'ValueTypeCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'DateCreated', N'6/14/2006 10:00:56 PM', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'LastUpdated', N'6/14/2006 10:01:17 PM', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DefaultView', N'2', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderByOn', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Orientation', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Name', N'VariableCV', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'RecordCount', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Updatable', N'True', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Name', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceField', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceTable', N'VariableCV', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Name', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'1', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceField', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceTable', N'VariableCV', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'VariableNameCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'DateCreated', N'6/14/2006 11:21:53 PM', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'LastUpdated', N'6/14/2006 11:21:53 PM', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DefaultView', N'2', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderByOn', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Orientation', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Name', N'VerticalDatumCV', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'RecordCount', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Updatable', N'True', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Name', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceField', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceTable', N'VerticalDatumCV', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Name', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'1', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceField', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceTable', N'VerticalDatumCV', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'VerticalDatumCV', 'COLUMN', N'Definition'
GO

GO
-- Post-Deployment Script Template							
----------------------------------------------------------------------------------------
-- This file contains SQL statements that will be appended to the build script		
-- Use SQLCMD syntax to include a file into the post-deployment script			
-- Example:      :r .\filename.sql								
-- Use SQLCMD syntax to reference a variable in the post-deployment script		
-- Example:      :setvar $TableName MyTable							
--               SELECT * FROM [$(TableName)]					
----------------------------------------------------------------------------------------











