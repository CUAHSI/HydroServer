IMPORTANT!!!
============

Do not attach this database from the projects folder directly to SQL Server.  This is a clean copy.  Please copy the database and log file to your own computer or server, and attach your copy to SQL Server.

This SQL Server 2008 database is based on ODM 1.1 with these modifications.


Add Taxonomy Table
==================

	Taxonomy table
		TaxaID int (identity)
		TSN int
		Kingdom nvarchar(50)
		Phylum nvarchar(50)
		Class nvarchar(50)
		Order nvarchar(50)
		Suborder nvarchar(50)
		Infraorder nvarchar(50)
		Family nvarchar(50)
		Genus nvarchar(50)
		Species nvarchar(100)
		Subspecies nvarchar(150)
		CommonName nvarchar(500)
		Synonyms nvarchar(MAX)
		TaxaLink nvarchar(500)
		TaxaComments nvarchar(MAX)

	Used this kind of constraint Kingdom, Phylum, Class, Order, Suborder, Infraorder, Family, Genus, Species, Subspecies: 
		(NOT [Address] like ((('%['+char((9)))+char((10)))+char((13)))+']%')


Modify DataValues
=================

Add TaxaID field in DataValues table, relating to Taxonomy table

In indexes/keys, edit the UNIQUE constraint to replace DateTimeUTC with TaxaID. This means we're using TaxaID to uniquely identify a data value.  We don't need DateTimeUTC since data values are also indexed by LocalDateTime and UTCOffset.

Modify Sources
==============

Add SourceFile field (required) in Sources table, nvarchar (500)

	Used this kind of constraint for SourceFile: 
		(NOT [SourceFile] like ((('%['+char((9)))+char((10)))+char((13)))+']%')

Add ValuesAsFlatTable View
==========================
SELECT     TOP (100) PERCENT dbo.Sources.SourceFile, dbo.Sites.SiteCode, dbo.Sites.SiteName, dbo.Variables.VariableName, dbo.Variables.Speciation, 
                      dbo.DataValues.LocalDateTime, dbo.DataValues.DataValue, dbo.DataValues.ValueAccuracy, VariableUnits.UnitsName AS Units, VariableUnits.UnitsAbbreviation, 
                      dbo.DataValues.OffsetValue, OffsetUnits.UnitsName AS OffsetUnits, dbo.OffsetTypes.OffsetDescription, dbo.Variables.SampleMedium, 
                      dbo.Methods.MethodDescription AS Method, dbo.DataValues.CensorCode, dbo.Qualifiers.QualifierDescription, dbo.Taxonomy.TSN, dbo.Taxonomy.Kingdom, 
                      dbo.Taxonomy.Phylum, dbo.Taxonomy.Class, dbo.Taxonomy.[Order], dbo.Taxonomy.Suborder, dbo.Taxonomy.Infraorder, dbo.Taxonomy.Family, 
                      dbo.Taxonomy.Genus, dbo.Taxonomy.Species, dbo.Taxonomy.Subspecies, dbo.Taxonomy.Synonyms, dbo.Taxonomy.CommonName, dbo.Taxonomy.TaxaComments, 
                      dbo.Taxonomy.TaxaLink, dbo.QualityControlLevels.QualityControlLevelCode AS QCLevelCode, dbo.QualityControlLevels.Definition AS QCDefinition, 
                      dbo.QualityControlLevels.Explanation AS QCExplanation, dbo.Variables.NoDataValue, dbo.Sites.Latitude, dbo.Sites.Longitude, dbo.Sites.Comments AS SiteComments, 
                      dbo.Variables.ValueType, dbo.Variables.DataType, dbo.Variables.GeneralCategory, dbo.Sources.ContactName, dbo.Sources.Organization, 
                      dbo.Sources.SourceDescription, dbo.Sources.SourceLink, dbo.Sources.Phone, dbo.Sources.Email, dbo.Sources.Address, dbo.Sources.City, dbo.Sources.State, 
                      dbo.Sources.ZipCode, dbo.Sources.Citation, dbo.DataValues.ValueID, dbo.DataValues.VariableID, dbo.DataValues.SourceID, dbo.DataValues.OffsetTypeID
FROM         dbo.Variables RIGHT OUTER JOIN
                      dbo.DataValues INNER JOIN
                      dbo.Methods ON dbo.DataValues.MethodID = dbo.Methods.MethodID LEFT OUTER JOIN
                      dbo.Qualifiers ON dbo.DataValues.QualifierID = dbo.Qualifiers.QualifierID LEFT OUTER JOIN
                      dbo.QualityControlLevels ON dbo.DataValues.QualityControlLevelID = dbo.QualityControlLevels.QualityControlLevelID LEFT OUTER JOIN
                      dbo.Taxonomy ON dbo.DataValues.TaxaID = dbo.Taxonomy.TaxaID LEFT OUTER JOIN
                      dbo.Sites ON dbo.Sites.SiteID = dbo.DataValues.SiteID ON dbo.Variables.VariableID = dbo.DataValues.VariableID LEFT OUTER JOIN
                      dbo.Units AS VariableUnits ON dbo.Variables.VariableUnitsID = VariableUnits.UnitsID LEFT OUTER JOIN
                      dbo.OffsetTypes ON dbo.DataValues.OffsetTypeID = dbo.OffsetTypes.OffsetTypeID LEFT OUTER JOIN
                      dbo.Units AS OffsetUnits ON dbo.OffsetTypes.OffsetUnitsID = OffsetUnits.UnitsID LEFT OUTER JOIN
                      dbo.Sources ON dbo.DataValues.SourceID = dbo.Sources.SourceID