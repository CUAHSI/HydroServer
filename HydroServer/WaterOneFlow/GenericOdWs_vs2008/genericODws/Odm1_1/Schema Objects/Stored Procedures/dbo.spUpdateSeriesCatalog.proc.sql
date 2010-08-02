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


