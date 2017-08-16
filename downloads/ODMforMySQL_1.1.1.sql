-- MySQL Dump Script for Creating an ODM 1.1.1 Blank Schema within a MySQL Database
-- Created by: Jeff Horsburgh, Utah State University
-- Modified by: Jiri Kadlec, Aalto University (changed table names to lower-case for better Linux support)
-- Created on: 1-3-2012
-- Modified on: 04-29-2013
-- Note:  Check to make sure the collation of your database schema is set to utf8_unicode_ci when you create it

-- Ensure that tables with existing primay key values of zero are created successfully
SET sql_mode='NO_AUTO_VALUE_ON_ZERO';

--
-- Table structure for table `generalcategorycv`
--

CREATE TABLE `generalcategorycv` (
  `Term` VARCHAR(255) NOT NULL,
  `Definition` TEXT NULL,
  PRIMARY KEY (`Term` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `samplemediumcv`
--

CREATE TABLE `samplemediumcv` (
  `Term` VARCHAR(255) NOT NULL,
  `Definition` TEXT NULL,
  PRIMARY KEY (`Term` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `censorcodecv`
--

CREATE TABLE `censorcodecv` (
  `Term` VARCHAR(50) NOT NULL,
  `Definition` TEXT NULL,
  PRIMARY KEY (`Term` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `topiccategorycv`
--

CREATE TABLE `topiccategorycv` (
  `Term` VARCHAR(255) NOT NULL,
  `Definition` TEXT NULL,
  PRIMARY KEY (`Term` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `speciationcv`
--

CREATE TABLE `speciationcv` (
  `Term` VARCHAR(255) NOT NULL,
  `Definition` TEXT NULL,
  PRIMARY KEY (`Term` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `groupdescriptions`
--

CREATE TABLE `groupdescriptions` (
  `GroupID` INT NOT NULL  AUTO_INCREMENT,
  `GroupDescription` TEXT NULL,
  PRIMARY KEY (`GroupID` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `labmethods`
--

CREATE TABLE `labmethods` (
  `LabMethodID` INT NOT NULL  AUTO_INCREMENT,
  `LabName` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `LabOrganization` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `LabMethodName` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `LabMethodDescription` TEXT NOT NULL,
  `LabMethodLink` TEXT NULL,
  PRIMARY KEY (`LabMethodID` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `methods`
--

CREATE TABLE `methods` (
  `MethodID` INT NOT NULL  AUTO_INCREMENT,
  `MethodDescription` TEXT NOT NULL,
  `MethodLink` TEXT NULL,
  PRIMARY KEY (`MethodID` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `units`
--

CREATE TABLE `units` (
  `UnitsID` INT NOT NULL  AUTO_INCREMENT,
  `UnitsName` VARCHAR(255) NOT NULL,
  `UnitsType` VARCHAR(255) NOT NULL,
  `UnitsAbbreviation` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`UnitsID` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `qualifiers`
--

CREATE TABLE `qualifiers` (
  `QualifierID` INT NOT NULL  AUTO_INCREMENT,
  `QualifierCode` VARCHAR(50) NULL DEFAULT NULL,
  `QualifierDescription` TEXT NOT NULL,
  PRIMARY KEY (`QualifierID` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `qualitycontrollevels`
--

CREATE TABLE `qualitycontrollevels` (
  `QualityControlLevelID` INT NOT NULL  AUTO_INCREMENT,
  `QualityControlLevelCode` VARCHAR(50) NOT NULL,
  `Definition` VARCHAR(255) NOT NULL,
  `Explanation` TEXT NOT NULL,
  PRIMARY KEY (`QualityControlLevelID` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `ODMVersion`
--

CREATE TABLE `odmversion` (
  `VersionNumber` VARCHAR(50) NOT NULL
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `sampletypecv`
--

CREATE TABLE `sampletypecv` (
  `Term` VARCHAR(255) NOT NULL,
  `Definition` TEXT NULL,
  PRIMARY KEY (`Term` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `samples`
--

 CREATE TABLE `samples` (
   `SampleID` INT NOT NULL  AUTO_INCREMENT,
   `SampleType` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
   `LabSampleCode` VARCHAR(50) NOT NULL,
   `LabMethodID` INT NOT NULL DEFAULT 0,
   PRIMARY KEY (`SampleID` ASC),
   CONSTRAINT `FK_Samples_LabMethods` FOREIGN KEY (`LabMethodID`) REFERENCES `labmethods` (`LabMethodID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
   CONSTRAINT `FK_Samples_SampleTypeCV` FOREIGN KEY (`SampleType`) REFERENCES `sampletypecv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `sitetypecv`
--

CREATE TABLE `sitetypecv` (
  `Term` VARCHAR(255) NOT NULL,
  `Definition` TEXT NULL,
  PRIMARY KEY (`Term` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `valuetypecv`
--

CREATE TABLE `valuetypecv` (
  `Term` VARCHAR(255) NOT NULL,
  `Definition` TEXT NULL,
  PRIMARY KEY (`Term` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `spatialreferences`
--

CREATE TABLE `spatialreferences` (
  `SpatialReferenceID` INT NOT NULL  AUTO_INCREMENT,
  `SRSID` INT NULL DEFAULT NULL,
  `SRSName` VARCHAR(255) NOT NULL,
  `IsGeographic` BOOL NULL DEFAULT NULL,
  `Notes` TEXT NULL,
  PRIMARY KEY (`SpatialReferenceID` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `isometadata`
--

CREATE TABLE `isometadata` (
  `MetadataID` INT NOT NULL  AUTO_INCREMENT,
  `TopicCategory` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `Title` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `Abstract` TEXT NOT NULL,
  `ProfileVersion` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `MetadataLink` TEXT NULL,
  PRIMARY KEY (`MetadataID` ASC),
  CONSTRAINT `FK_ISOMetadata_TopicCategoryCV` FOREIGN KEY (`TopicCategory`) REFERENCES `topiccategorycv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `SeriesCatalog`
--

CREATE TABLE `seriescatalog` (
  `SeriesID` INT NOT NULL  AUTO_INCREMENT,
  `SiteID` INT NULL DEFAULT NULL,
  `SiteCode` VARCHAR(50) NULL DEFAULT NULL,
  `SiteName` VARCHAR(255) NULL DEFAULT NULL,
  `SiteType` VARCHAR(255) NULL DEFAULT NULL,
  `VariableID` INT NULL DEFAULT NULL,
  `VariableCode` VARCHAR(50) NULL DEFAULT NULL,
  `VariableName` VARCHAR(255) NULL DEFAULT NULL,
  `Speciation` VARCHAR(255) NULL DEFAULT NULL,
  `VariableUnitsID` INT NULL DEFAULT NULL,
  `VariableUnitsName` VARCHAR(255) NULL DEFAULT NULL,
  `SampleMedium` VARCHAR(255) NULL DEFAULT NULL,
  `ValueType` VARCHAR(255) NULL DEFAULT NULL,
  `TimeSupport` DOUBLE NULL DEFAULT NULL,
  `TimeUnitsID` INT NULL DEFAULT NULL,
  `TimeUnitsName` VARCHAR(255) NULL DEFAULT NULL,
  `DataType` VARCHAR(255) NULL DEFAULT NULL,
  `GeneralCategory` VARCHAR(255) NULL DEFAULT NULL,
  `MethodID` INT NULL DEFAULT NULL,
  `MethodDescription` TEXT NULL,
  `SourceID` INT NULL DEFAULT NULL,
  `Organization` VARCHAR(255) NULL DEFAULT NULL,
  `SourceDescription` TEXT NULL,
  `Citation` TEXT NULL,
  `QualityControlLevelID` INT NULL DEFAULT NULL,
  `QualityControlLevelCode` VARCHAR(50) NULL DEFAULT NULL,
  `BeginDateTime` DATETIME NULL DEFAULT NULL,
  `EndDateTime` DATETIME NULL DEFAULT NULL,
  `BeginDateTimeUTC` DATETIME NULL DEFAULT NULL,
  `EndDateTimeUTC` DATETIME NULL DEFAULT NULL,
  `ValueCount` INT NULL DEFAULT NULL,
  PRIMARY KEY (`SeriesID` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `verticaldatumcv`
--

CREATE TABLE `verticaldatumcv` (
  `Term` VARCHAR(255) NOT NULL,
  `Definition` TEXT NULL,
  PRIMARY KEY (`Term` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `sources`
--

CREATE TABLE `sources` (
  `SourceID` INT NOT NULL  AUTO_INCREMENT,
  `Organization` VARCHAR(255) NOT NULL,
  `SourceDescription` TEXT NOT NULL,
  `SourceLink` TEXT NULL,
  `ContactName` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `Phone` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `Email` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `Address` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `City` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `State` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `ZipCode` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `Citation` TEXT NOT NULL,
  `MetadataID` INT NOT NULL DEFAULT 0,
  PRIMARY KEY (`SourceID` ASC),
  CONSTRAINT `FK_Sources_ISOMetaData` FOREIGN KEY (`MetadataID`) REFERENCES `isometadata` (`MetadataID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `OffsetTypes`
--

CREATE TABLE `offsettypes` (
  `OffsetTypeID` INT NOT NULL  AUTO_INCREMENT,
  `OffsetUnitsID` INT NOT NULL,
  `OffsetDescription` TEXT NOT NULL,
  PRIMARY KEY (`OffsetTypeID` ASC),
  CONSTRAINT `FK_OffsetTypes_Units` FOREIGN KEY (`OffsetUnitsID`) REFERENCES `units` (`UnitsID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `variablenamecv`
--

CREATE TABLE `variablenamecv` (
  `Term` VARCHAR(255) NOT NULL,
  `Definition` TEXT NULL,
  PRIMARY KEY (`Term` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `datatypecv`
--

CREATE TABLE `datatypecv` (
  `Term` VARCHAR(255) NOT NULL,
  `Definition` TEXT NULL,
  PRIMARY KEY (`Term` ASC)
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `variables`
--

CREATE TABLE `variables` (
  `VariableID` INT NOT NULL  AUTO_INCREMENT,
  `VariableCode` VARCHAR(50) NOT NULL,
  `VariableName` VARCHAR(255) NOT NULL,
  `Speciation` VARCHAR(255) NOT NULL DEFAULT 'Not Applicable',
  `VariableUnitsID` INT NOT NULL,
  `SampleMedium` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `ValueType` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `IsRegular` BOOL NOT NULL DEFAULT 0,
  `TimeSupport` DOUBLE NOT NULL DEFAULT 0,
  `TimeUnitsID` INT NOT NULL DEFAULT 0,
  `DataType` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `GeneralCategory` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `NoDataValue` DOUBLE NOT NULL DEFAULT 0,
  UNIQUE KEY `AK_Variables_VariableCode` (`VariableCode`(50) ASC),
  PRIMARY KEY (`VariableID` ASC),
  CONSTRAINT `FK_Variables_Units` FOREIGN KEY (`VariableUnitsID`) REFERENCES `units` (`UnitsID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `FK_Variables_Units1` FOREIGN KEY (`TimeUnitsID`) REFERENCES `units` (`UnitsID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Variables_DataTypeCV` FOREIGN KEY (`DataType`) REFERENCES `datatypecv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Variables_GeneralCategoryCV` FOREIGN KEY (`GeneralCategory`) REFERENCES `generalcategorycv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Variables_SampleMediumCV` FOREIGN KEY (`SampleMedium`) REFERENCES `samplemediumcv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Variables_ValueTypeCV` FOREIGN KEY (`ValueType`) REFERENCES `valuetypecv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Variables_VariableNameCV` FOREIGN KEY (`VariableName`) REFERENCES `variablenamecv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Variables_SpeciationCV` FOREIGN KEY (`Speciation`) REFERENCES `speciationcv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `sites`
--

CREATE TABLE `sites` (
  `SiteID` INT NOT NULL  AUTO_INCREMENT,
  `SiteCode` VARCHAR(50) NOT NULL,
  `SiteName` VARCHAR(255) NOT NULL,
  `Latitude` DOUBLE NOT NULL,
  `Longitude` DOUBLE NOT NULL,
  `LatLongDatumID` INT NOT NULL DEFAULT 0,
  `SiteType` VARCHAR(255) NULL DEFAULT NULL,
  `Elevation_m` DOUBLE NULL DEFAULT NULL,
  `VerticalDatum` VARCHAR(255) NULL DEFAULT NULL,
  `LocalX` DOUBLE NULL DEFAULT NULL,
  `LocalY` DOUBLE NULL DEFAULT NULL,
  `LocalProjectionID` INT NULL DEFAULT NULL,
  `PosAccuracy_m` DOUBLE NULL DEFAULT NULL,
  `State` VARCHAR(255) NULL DEFAULT NULL,
  `County` VARCHAR(255) NULL DEFAULT NULL,
  `Comments` TEXT NULL,
  UNIQUE KEY `AK_Sites_SiteCode` (`SiteCode`(50) ASC),
  PRIMARY KEY (`SiteID` ASC),
  CONSTRAINT `FK_Sites_VerticalDatumCV` FOREIGN KEY (`VerticalDatum`) REFERENCES `verticaldatumcv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Sites_SpatialReferences` FOREIGN KEY (`LatLongDatumID`) REFERENCES `spatialreferences` (`SpatialReferenceID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Sites_SpatialReferences1` FOREIGN KEY (`LocalProjectionID`) REFERENCES `spatialreferences` (`SpatialReferenceID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Sites_SiteTypeCV` FOREIGN KEY (`SiteType`) REFERENCES `sitetypecv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `datavalues`
--

CREATE TABLE `datavalues` (
  `ValueID` INT NOT NULL  AUTO_INCREMENT,
  `DataValue` DOUBLE NOT NULL,
  `ValueAccuracy` DOUBLE NULL DEFAULT NULL,
  `LocalDateTime` DATETIME NOT NULL,
  `UTCOffset` DOUBLE NOT NULL,
  `DateTimeUTC` DATETIME NOT NULL,
  `SiteID` INT NOT NULL,
  `VariableID` INT NOT NULL,
  `OffsetValue` DOUBLE NULL DEFAULT NULL,
  `OffsetTypeID` INT NULL DEFAULT NULL,
  `CensorCode` VARCHAR(50) NOT NULL DEFAULT 'nc',
  `QualifierID` INT NULL DEFAULT NULL,
  `MethodID` INT NOT NULL DEFAULT 0,
  `SourceID` INT NOT NULL,
  `SampleID` INT NULL DEFAULT NULL,
  `DerivedFromID` INT NULL DEFAULT NULL,
  `QualityControlLevelID` INT NOT NULL DEFAULT 0,
  PRIMARY KEY (`ValueID` ASC),
  UNIQUE KEY `DataValues_UNIQUE_DataValues` (`DataValue` ASC,`ValueAccuracy` ASC,`LocalDateTime` ASC,`UTCOffset` ASC,`DateTimeUTC` ASC,`SiteID` ASC,`VariableID` ASC,`OffsetValue` ASC,`OffsetTypeID` ASC,`CensorCode`(50) ASC,`QualifierID` ASC,`MethodID` ASC,`SourceID` ASC,`SampleID` ASC,`DerivedFromID` ASC,`QualityControlLevelID` ASC),
  CONSTRAINT `FK_DataValues_Sites` FOREIGN KEY (`SiteID`) REFERENCES `sites` (`SiteID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `FK_DataValues_Sources` FOREIGN KEY (`SourceID`) REFERENCES `sources` (`SourceID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_DataValues_QualityControlLevels` FOREIGN KEY (`QualityControlLevelID`) REFERENCES `qualitycontrollevels` (`QualityControlLevelID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_DataValues_OffsetTypes` FOREIGN KEY (`OffsetTypeID`) REFERENCES `offsettypes` (`OffsetTypeID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_DataValues_CensorCodeCV` FOREIGN KEY (`CensorCode`) REFERENCES `censorcodecv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_DataValues_Variables` FOREIGN KEY (`VariableID`) REFERENCES `variables` (`VariableID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_DataValues_Methods` FOREIGN KEY (`MethodID`) REFERENCES `methods` (`MethodID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_DataValues_Qualifiers` FOREIGN KEY (`QualifierID`) REFERENCES `qualifiers` (`QualifierID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_DataValues_Samples` FOREIGN KEY (`SampleID`) REFERENCES `samples` (`SampleID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `VariableID` INT NOT NULL,
  `DataValue` DOUBLE NOT NULL,
  `CategoryDescription` TEXT NOT NULL,
  CONSTRAINT `FK_Categories_Variables` FOREIGN KEY (`VariableID`) REFERENCES `variables` (`VariableID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `DerivedFrom`
--

CREATE TABLE `derivedfrom` (
  `DerivedFromID` INT NOT NULL,
  `ValueID` INT NOT NULL,
  CONSTRAINT `FK_DerivedFrom_DataValues` FOREIGN KEY (`ValueID`) REFERENCES `datavalues` (`ValueID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Table structure for table `Groups`
--

CREATE TABLE `groups` (
  `GroupID` INT NOT NULL,
  `ValueID` INT NOT NULL,
  CONSTRAINT `FK_Groups_GroupDescriptions` FOREIGN KEY (`GroupID`) REFERENCES `groupdescriptions` (`GroupID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Groups_DataValues` FOREIGN KEY (`ValueID`) REFERENCES `datavalues` (`ValueID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB;

--
-- Dumping data for table `generalcategorycv`
--

INSERT INTO `generalcategorycv` (`Term`,`Definition`) VALUES ('Biota','Data associated with biological organisms');
INSERT INTO `generalcategorycv` (`Term`,`Definition`) VALUES ('Climate','Data associated with the climate, weather, or atmospheric processes');
INSERT INTO `generalcategorycv` (`Term`,`Definition`) VALUES ('Geology','Data associated with geology or geological processes');
INSERT INTO `generalcategorycv` (`Term`,`Definition`) VALUES ('Hydrology','Data associated with hydrologic variables or processes');
INSERT INTO `generalcategorycv` (`Term`,`Definition`) VALUES ('Instrumentation','Data associated with instrumentation and instrument properties such as battery voltages, data logger temperatures, often useful for diagnosis.');
INSERT INTO `generalcategorycv` (`Term`,`Definition`) VALUES ('Unknown','The general category is unknown');
INSERT INTO `generalcategorycv` (`Term`,`Definition`) VALUES ('Water Quality','Data associated with water quality variables or processes');

--
-- Dumping data for table `samplemediumcv`
--

INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Air','Sample taken from the atmosphere');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Flowback water','A mixture of formation water and hydraulic fracturing injectates deriving from oil and gas wells prior to placing wells into production');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Groundwater','Sample taken from water located below the surface of the ground, such as from a well or spring');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Municipal waste water','Sample taken from raw municipal waste water stream.');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Not Relevant','Sample medium not relevant in the context of the measurement');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Other','Sample medium other than those contained in the CV');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Precipitation','Sample taken from solid or liquid precipitation');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Production water','Fluids produced from wells during oil or gas production which may include formation water, injected fluids, oil and gas.');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Sediment','Sample taken from the sediment beneath the water column');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Snow','Observation in, of or sample taken from snow');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Soil','Sample taken from the soil');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Soil air','Air contained in the soil pores');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Soil water','the water contained in the soil pores');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Surface Water','Observation or sample of surface water such as a stream, river, lake, pond, reservoir, ocean, etc.');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Tissue','Sample taken from the tissue of a biological organism');
INSERT INTO `samplemediumcv` (`Term`,`Definition`) VALUES ('Unknown','The sample medium is unknown');

--
-- Dumping data for table `censorcodecv`
--

INSERT INTO `censorcodecv` (`Term`,`Definition`) VALUES ('gt','greater than');
INSERT INTO `censorcodecv` (`Term`,`Definition`) VALUES ('lt','less than');
INSERT INTO `censorcodecv` (`Term`,`Definition`) VALUES ('nc','not censored');
INSERT INTO `censorcodecv` (`Term`,`Definition`) VALUES ('nd','non-detect');
INSERT INTO `censorcodecv` (`Term`,`Definition`) VALUES ('pnq','present but not quantified');

--
-- Dumping data for table `topiccategorycv`
--

INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('biota','Data associated with biological organisms');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('boundaries','Data associated with boundaries');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('climatology/meteorology/atmosphere','Data associated with climatology, meteorology, or the atmosphere');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('economy','Data associated with the economy');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('elevation','Data associated with elevation');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('environment','Data associated with the environment');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('farming','Data associated with agricultural production');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('geoscientificInformation','Data associated with geoscientific information');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('health','Data associated with health');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('imageryBaseMapsEarthCover','Data associated with imagery, base maps, or earth cover');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('inlandWaters','Data associated with inland waters');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('intelligenceMilitary','Data associated with intelligence or the military');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('location','Data associated with location');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('oceans','Data associated with oceans');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('planningCadastre','Data associated with planning or cadestre');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('society','Data associated with society');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('structure','Data associated with structure');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('transportation','Data associated with transportation');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('Unknown','The topic category is unknown');
INSERT INTO `topiccategorycv` (`Term`,`Definition`) VALUES ('utilitiesCommunication','Data associated with utilities or communication');

--
-- Dumping data for table `speciationcv`
--

INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Al','Expressed as aluminium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('As','Expressed as arsenic');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('B','Expressed as boron');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Ba','Expressed as barium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Br','Expressed as bromine');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('C','Expressed as carbon');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('C2H6','Expressed as ethane');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Ca','Expressed as calcium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('CaCO3','Expressed as calcium carbonate');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Cd','Expressed as cadmium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('CH4','Expressed as methane');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Cl','Expressed as chlorine');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Co','Expressed as cobalt');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('CO2','Expressed as carbon dioxide');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('CO3','Expressed as carbonate');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Cr','Expressed as chromium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Cu','Expressed as copper');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('delta 2H','Expressed as deuterium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('delta N15','Expressed as nitrogen-15');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('delta O18 ','Expressed as oxygen-18');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('EC','Expressed as electrical conductivity');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('F','Expressed as fluorine ');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Fe','Expressed as iron');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('H2O','Expressed as water');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('HCO3','Expressed as hydrogen carbonate');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Hg','Expressed as mercury');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('K','Expressed as potassium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Mg','Expressed as magnesium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Mn','Expressed as manganese');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Mo','Expressed as molybdenum');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('N','Expressed as nitrogen');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Na','Expressed as sodium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('NH4','Expressed as ammonium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Ni','Expressed as nickel');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('NO2','Expressed as nitrite');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('NO3','Expressed as nitrate');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Not Applicable','Speciation is not applicable');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('P','Expressed as phosphorus');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Pb','Expressed as lead');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('pH','Expressed as pH');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('PO4','Expressed as phosphate');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('S','Expressed as Sulfur');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Sb','Expressed as antimony');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Se','Expressed as selenium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Si','Expressed as silicon');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('SiO2','Expressed as silicate');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('SN','Expressed as tin');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('SO4','Expressed as Sulfate');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Sr','Expressed as strontium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('TA','Expressed as total alkalinity');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Ti','Expressed as titanium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Tl','Expressed as thallium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('U','Expressed as uranium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Unknown','Speciation is unknown');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('V','Expressed as vanadium');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Zn','Expressed as zinc');
INSERT INTO `speciationcv` (`Term`,`Definition`) VALUES ('Zr','Expressed as zircon');

--
-- Dumping data for table `labmethods`
--

INSERT INTO `labmethods` (`LabMethodID`,`LabName`,`LabOrganization`,`LabMethodName`,`LabMethodDescription`,`LabMethodLink`) VALUES (0,'Unknown','Unknown','Unknown','Unknown',NULL);

--
-- Dumping data for table `methods`
--

INSERT INTO `methods` (`MethodID`,`MethodDescription`,`MethodLink`) VALUES (0,'No method specified',NULL);

--
-- Dumping data for table `units`
--

INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (1,'percent','Dimensionless','%');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (2,'degree','Angle','deg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (3,'grad','Angle','grad');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (4,'radian','Angle','rad');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (5,'degree north','Angle','degN');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (6,'degree south','Angle','degS');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (7,'degree west','Angle','degW');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (8,'degree east','Angle','degE');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (9,'arcminute','Angle','arcmin');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (10,'arcsecond','Angle','arcsec');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (11,'steradian','Angle','sr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (12,'acre','Area','ac');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (13,'hectare','Area','ha');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (14,'square centimeter','Area','cm^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (15,'square foot','Area','ft^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (16,'square kilometer','Area','km^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (17,'square meter','Area','m^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (18,'square mile','Area','mi^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (19,'hertz','Frequency','Hz');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (20,'darcy','Permeability','D');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (21,'british thermal unit','Energy','BTU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (22,'calorie','Energy','cal');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (23,'erg','Energy','erg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (24,'foot pound force','Energy','lbf ft');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (25,'joule','Energy','J');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (26,'kilowatt hour','Energy','kW hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (27,'electronvolt','Energy','eV');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (28,'langleys per day','Energy Flux','Ly/d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (29,'langleys per minute','Energy Flux','Ly/min');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (30,'langleys per second','Energy Flux','Ly/s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (31,'megajoules per square meter per day','Energy Flux','MJ/m^2 d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (32,'watts per square centimeter','Energy Flux','W/cm^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (33,'watts per square meter','Energy Flux','W/m^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (34,'acre feet per year','Flow','ac ft/yr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (35,'cubic feet per second','Flow','cfs');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (36,'cubic meters per second','Flow','m^3/s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (37,'cubic meters per day','Flow','m^3/d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (38,'gallons per minute','Flow','gpm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (39,'liters per second','Flow','L/s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (40,'million gallons per day','Flow','MGD');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (41,'dyne','Force','dyn');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (42,'kilogram force','Force','kgf');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (43,'newton','Force','N');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (44,'pound force','Force','lbf');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (45,'kilo pound force','Force','kip');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (46,'ounce force','Force','ozf');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (47,'centimeter   ','Length','cm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (48,'international foot','Length','ft');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (49,'international inch','Length','in');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (50,'international yard','Length','yd');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (51,'kilometer','Length','km');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (52,'meter','Length','m');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (53,'international mile','Length','mi');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (54,'millimeter','Length','mm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (55,'micron','Length','um');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (56,'angstrom','Length','Å');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (57,'femtometer','Length','fm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (58,'nautical mile','Length','nmi');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (59,'lumen','Light','lm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (60,'lux','Light','lx');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (61,'lambert','Light','La');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (62,'stilb','Light','sb');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (63,'phot','Light','ph');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (64,'langley','Light','Ly');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (65,'gram','Mass','g');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (66,'kilogram','Mass','kg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (67,'milligram','Mass','mg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (68,'microgram','Mass','ug');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (69,'pound mass (avoirdupois)','Mass','lb');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (70,'slug','Mass','slug');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (71,'metric ton','Mass','tonne');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (72,'grain','Mass','grain');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (73,'carat','Mass','car');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (74,'atomic mass unit','Mass','amu');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (75,'short ton','Mass','ton');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (76,'BTU per hour','Power','BTU/hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (77,'foot pound force per second','Power','lbf/s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (78,'horse power (shaft)','Power','hp');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (79,'kilowatt','Power','kW');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (80,'watt','Power','W');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (81,'voltampere','Power','VA');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (82,'atmospheres','Pressure/Stress','atm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (83,'pascal','Pressure/Stress','Pa');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (84,'inch of mercury','Pressure/Stress','inch Hg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (85,'inch of water','Pressure/Stress','inch H2O');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (86,'millimeter of mercury','Pressure/Stress','mm Hg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (87,'millimeter of water','Pressure/Stress','mm H2O');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (88,'centimeter of mercury','Pressure/Stress','cm Hg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (89,'centimeter of water','Pressure/Stress','cm H2O');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (90,'millibar','Pressure/Stress','mbar');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (91,'pound force per square inch','Pressure/Stress','psi');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (92,'torr','Pressure/Stress','torr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (93,'barie','Pressure/Stress','barie');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (94,'meters per pixel','Resolution','meters per pixel');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (95,'meters per meter','Scale','-');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (96,'degree celsius','Temperature','degC');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (97,'degree fahrenheit','Temperature','degF');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (98,'degree rankine','Temperature','degR');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (99,'degree kelvin','Temperature','degK');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (100,'second','Time','s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (101,'millisecond','Time','millisec');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (102,'minute','Time','min');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (103,'hour','Time','hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (104,'day','Time','d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (105,'week','Time','week');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (106,'month','Time','month');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (107,'common year (365 days)','Time','yr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (108,'leap year (366 days)','Time','leap yr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (109,'Julian year (365.25 days)','Time','jul yr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (110,'Gregorian year (365.2425 days)','Time','greg yr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (111,'centimeters per hour','Velocity','cm/hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (112,'centimeters per second','Velocity','cm/s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (113,'feet per second','Velocity','ft/s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (114,'gallons per day per square foot','Velocity','gpd/ft^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (115,'inches per hour','Velocity','in/hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (116,'kilometers per hour','Velocity','km/h');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (117,'meters per day','Velocity','m/d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (118,'meters per hour','Velocity','m/hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (119,'meters per second','Velocity','m/s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (120,'miles per hour','Velocity','mph');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (121,'millimeters per hour','Velocity','mm/hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (122,'nautical mile per hour','Velocity','knot');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (123,'acre foot','Volume','ac ft');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (124,'cubic centimeter','Volume','cc');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (125,'cubic foot','Volume','ft^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (126,'cubic meter','Volume','m^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (127,'hectare meter','Volume','hec m');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (128,'liter','Volume','L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (129,'US gallon','Volume','gal');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (130,'barrel','Volume','bbl');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (131,'pint','Volume','pt');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (132,'bushel','Volume','bu');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (133,'teaspoon','Volume','tsp');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (134,'tablespoon','Volume','tbsp');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (135,'quart','Volume','qrt');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (136,'ounce','Volume','oz');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (137,'dimensionless','Dimensionless','-');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (138,'mega joule','Energy','MJ');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (139,'degrees minutes seconds','Angle','dddmmss');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (140,'calories per square centimeter per day','Energy Flux','cal/cm^2 d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (141,'calories per square centimeter per minute','Energy Flux','cal/cm^2 min');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (142,'milliliters per square centimeter per day','Hyporheic flux','ml/cm^2 d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (144,'megajoules per square meter','Energy per Area','MJ/m^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (145,'gallons per day','Flow','gpd');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (146,'million gallons per month','Flow','MGM');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (147,'million gallons per year','Flow','MGY');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (148,'short tons per day per foot','Mass flow per unit width','ton/d ft');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (149,'lumens per square foot','Light Intensity','lm/ft^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (150,'microeinsteins per square meter per second','Light Intensity','uE/m^2 s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (151,'alphas per meter','Light','a/m');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (152,'microeinsteins per square meter','Light','uE/m^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (153,'millimoles of photons per square meter','Light','mmol/m^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (154,'absorbance per centimeter','Extinction/Absorbance','A/cm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (155,'nanogram','Mass','ng');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (156,'picogram','Mass','pg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (157,'milliequivalents','Mass','meq');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (158,'grams per square meter','Areal Density','g/m^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (159,'milligrams per square meter','Areal Density','mg/m^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (160,'micrograms per square meter','Areal Density','ug/m^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (161,'grams per square meter per day','Areal Loading','g/m^2 d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (162,'grams per day','Loading','g/d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (163,'pounds per day','Loading','lb/d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (164,'pounds per mile','Loading','lb/mi');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (165,'short tons per day','Loading','ton/d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (166,'milligrams per cubic meter per day','Productivity','mg/m^3 d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (167,'milligrams per square meter per day','Productivity','mg/m^2 d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (168,'volts','Potential Difference','V');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (169,'millivolts','Potential Difference','mV');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (170,'kilopascal','Pressure/Stress','kPa');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (171,'megapascal','Pressure/Stress','MPa');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (172,'becquerel','Radioactivity','Bq');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (173,'becquerels per gram','Radioactivity','Bq/g');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (174,'curie','Radioactivity','Ci');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (175,'picocurie','Radioactivity','pCi');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (176,'ohm','Resistance','ohm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (177,'ohm meter','Resistivity','ohm m');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (178,'picocuries per gram','Specific Activity','pCi/g');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (179,'picocuries per liter','Specific Activity','pCi/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (180,'picocuries per milliliter','Specific Activity','pCi/ml');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (181,'hour minute','Time','hhmm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (182,'year month day','Time','yymmdd');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (183,'year day (Julian)','Time','yyddd');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (184,'inches per day','Velocity','in/d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (185,'inches per week','Velocity','in/week');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (186,'inches per storm','Precipitation','in/storm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (187,'thousand acre feet','Volume','10^3 ac ft');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (188,'milliliter','Volume','ml');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (189,'cubic feet per second days','Volume','cfs d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (190,'thousand gallons','Volume','10^3 gal');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (191,'million gallons','Volume','10^6 gal');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (192,'microsiemens per centimeter','Electrical Conductivity','uS/cm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (193,'practical salinity units ','Salinity','psu');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (194,'decibel','Sound','dB');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (195,'cubic centimeters per gram','Specific Volume','cm^3/g');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (196,'square meters per gram','Specific Surface Area ','m^2/g');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (197,'short tons per acre foot','Concentration','ton/ac ft');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (198,'grams per cubic centimeter','Concentration','g/cm^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (199,'milligrams per liter','Concentration','mg/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (200,'nanograms per cubic meter','Concentration','ng/m^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (201,'nanograms per liter','Concentration','ng/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (202,'grams per liter','Concentration','g/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (203,'micrograms per cubic meter','Concentration','ug/m^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (204,'micrograms per liter','Concentration','ug/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (205,'parts per million','Concentration','ppm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (206,'parts per billion','Concentration','ppb');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (207,'parts per trillion','Concentration','ppt');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (208,'parts per quintillion','Concentration','ppqt');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (209,'parts per quadrillion','Concentration','ppq');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (210,'per mille','Concentration','%o');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (211,'microequivalents per liter','Concentration','ueq/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (212,'milliequivalents per liter','Concentration','meq/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (213,'milliequivalents per 100 gram','Concentration','meq/100 g');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (214,'milliosmols per kilogram','Concentration','mOsm/kg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (215,'nanomoles per liter','Concentration','nmol/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (216,'picograms per cubic meter','Concentration','pg/m^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (217,'picograms per liter','Concentration','pg/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (218,'picograms per milliliter','Concentration','pg/ml');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (219,'tritium units','Concentration','TU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (220,'jackson turbidity units','Turbidity','JTU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (221,'nephelometric turbidity units','Turbidity','NTU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (222,'nephelometric turbidity multibeam unit','Turbidity','NTMU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (223,'nephelometric turbidity ratio unit','Turbidity','NTRU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (224,'formazin nephelometric multibeam unit','Turbidity','FNMU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (225,'formazin nephelometric ratio unit','Turbidity','FNRU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (226,'formazin nephelometric unit','Turbidity','FNU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (227,'formazin attenuation unit','Turbidity','FAU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (228,'formazin backscatter unit ','Turbidity','FBU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (229,'backscatter units','Turbidity','BU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (230,'attenuation units','Turbidity','AU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (231,'platinum cobalt units','Color','PCU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (232,'the ratio between UV absorbance at 254 nm and DOC level','Specific UV Absorbance','L/(mg DOC/cm)');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (233,'billion colonies per day','Organism Loading','10^9 colonies/d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (234,'number of organisms per square meter','Organism Concentration','#/m^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (235,'number of organisms per liter','Organism Concentration','#/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (236,'number or organisms per cubic meter','Organism Concentration','#/m^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (237,'cells per milliliter','Organism Concentration','cells/ml');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (238,'cells per square millimeter','Organism Concentration','cells/mm^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (239,'colonies per 100 milliliters','Organism Concentration','colonies/100 ml');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (240,'colonies per milliliter','Organism Concentration','colonies/ml');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (241,'colonies per gram','Organism Concentration','colonies/g');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (242,'colony forming units per milliliter','Organism Concentration','CFU/ml');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (243,'cysts per 10 liters','Organism Concentration','cysts/10 L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (244,'cysts per 100 liters','Organism Concentration','cysts/100 L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (245,'oocysts per 10 liters','Organism Concentration','oocysts/10 L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (246,'oocysts per 100 liters','Organism Concentration','oocysts/100 L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (247,'most probable number','Organism Concentration','MPN');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (248,'most probable number per 100 liters','Organism Concentration','MPN/100 L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (249,'most probable number per 100 milliliters','Organism Concentration','MPN/100 ml');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (250,'most probable number per gram','Organism Concentration','MPN/g');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (251,'plaque-forming units per 100 liters','Organism Concentration','PFU/100 L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (252,'plaques per 100 milliliters','Organism Concentration','plaques/100 ml');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (253,'counts per second','Rate','#/s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (254,'per day','Rate','1/d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (255,'nanograms per square meter per hour','Volatilization Rate','ng/m^2 hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (256,'nanograms per square meter per week','Volatilization Rate','ng/m^2 week');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (257,'count','Dimensionless','#');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (258,'categorical','Dimensionless','code');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (259,'absorbance per centimeter per mg/L of given acid ','Absorbance','100/cm mg/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (260,'per liter','Concentration Ratio','1/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (261,'per mille per hour','Sedimentation Rate','%o/hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (262,'gallons per batch','Flow','gpb');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (263,'cubic feet per barrel','Concentration','ft^3/bbl');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (264,'per mille by volume','Concentration','%o by vol');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (265,'per mille per hour by volume','Sedimentation Rate','%o/hr by vol');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (266,'micromoles','Amount','umol');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (267,'tons of calcium carbonate per kiloton','Net Neutralization Potential','tCaCO3/Kt');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (268,'siemens per meter','Electrical Conductivity','S/m');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (269,'millisiemens per centimeter','Electrical Conductivity','mS/cm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (270,'siemens per centimeter','Electrical Conductivity','S/cm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (271,'practical salinity scale','Salinity','pss');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (272,'per meter','Light Extinction','1/m');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (273,'normal','Normality','N');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (274,'nanomoles per kilogram','Concentration','nmol/kg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (275,'millimoles per kilogram','Concentration','mmol/kg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (276,'millimoles per square meter per hour','Areal Flux','mmol/m^2 hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (277,'milligrams per cubic meter per hour','Productivity','mg/m^3 hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (278,'milligrams per day','Loading','mg/d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (279,'liters per minute','Flow','L/min');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (280,'liters per day','Flow','L/d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (281,'jackson candle units ','Turbidity','JCU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (282,'grains per gallon','Concentration','gpg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (283,'gallons per second','Flow','gps');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (284,'gallons per hour','Flow','gph');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (285,'foot candle','Illuminance','ftc');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (286,'fibers per liter','Concentration','fibers/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (287,'drips per minute','Flow','drips/min');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (288,'cubic centimeters per second','Flow','cm^3/sec');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (289,'colony forming units','Organism Concentration','CFU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (290,'colony forming units per 100 milliliter','Organism Concentration','CFU/100 ml');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (291,'cubic feet per minute','Flow','cfm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (292,'ADMI color unit','Color','ADMI');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (293,'percent by volume','Concentration','% by vol');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (294,'number of organisms per 500 milliliter','Organism Concentration','#/500 ml');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (295,'number of organisms per 100 gallon','Organism Concentration','#/100 gal');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (296,'grams per cubic meter per hour','Productivity','g/m^3 hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (297,'grams per minute','Loading','g/min');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (298,'grams per second','Loading','g/s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (299,'million cubic feet','Volume','10^6 ft^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (300,'month year','Time','mmyy');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (301,'bar','Pressure','bar');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (302,'decisiemens per centimeter','Electrical Conductivity','dS/cm');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (303,'micromoles per liter','Concentration','umol/L');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (304,'Joules per square centimeter','Energy per Area','J/cm^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (305,'millimeters per day','velocity','mm/day');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (306,'parts per thousand','Concentration','ppth');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (307,'megaliter','Volume','ML');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (308,'Percent Saturation','Concentration','% Sat');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (309,'pH Unit','Dimensionless','pH');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (310,'millimeters per second','Velocity','mm/s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (311,'liters per hour','Flow','L/hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (312,'cubic hecto meter','Volume','(hm)^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (313,'mols per cubic meter','Concentration or organism concentration','mol/m^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (314,'kilo grams per month','Loading','kg/month');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (315,'Hecto Pascal','Pressure/Stress','hPa');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (316,'kilo grams per cubic meter','Concentration','kg/m^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (317,'short tons per month','Loading','ton/month');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (318,'micromoles per square meter per second','Areal Flux','umol/m^2 s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (319,'grams per square meter per hour','Areal Flux','g/m^2 hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (320,'milligrams per cubic meter','Concentration','mg/m^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (321,'meters squared per second squared','Velocity','m^2/s^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (322,'squared degree Celsius','Temperature','(DegC)^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (323,'milligrams per cubic meter squared','Concentration','(mg/m^3)^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (324,'meters per second degree Celsius','Temperature','m/s DegC');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (325,'millimoles per square meter per second','Areal Flux','mmol/m^2 s');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (326,'degree Celsius millimoles per cubic meter','Concentration','DegC mmol/m^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (327,'millimoles per cubic meter','Concentration','mmol/m^3');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (328,'millimoles per cubic meter squared','Concentration','(mmol/m^3)^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (329,'Langleys per hour','Energy Flux','Ly/hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (330,'hits per square centimeter','Precipitation','hits/cm^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (331,'hits per square centimeter per hour','Velocity','hits/cm^2 hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (332,'relative fluorescence units','Fluorescence','RFU');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (333,'kilograms per hectare per day','Areal Flux','kg/ha d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (334,'kilowatts per square meter','Energy Flux','kW/m^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (335,'kilograms per square meter','Areal Density','kg/m^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (336,'microeinsteins per square meter per day','Light Intensity','uE/m^2 d');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (337,'microgram per milliliter','Concentration','ug/mL');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (338,'Newton per square meter','Pressure/Stress','Newton/m^2');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (339,'micromoles per liter per hour','Pressure/Stress','umol/L hr');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (340,'decisiemens per meter','Electrical Conductivity','dS/m');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (341,'milligrams per kilogram','Mass Fraction','mg/Kg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (342,'number of organisms per 100 milliliter','Organism Concentration','#/100 mL');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (343,'micrograms per kilogram','Mass Fraction','ug/Kg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (344,'grams per kilogram','Mass Fraction','g/Kg');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (345,'acre feet per month','Flow','ac ft/mo');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (346,'acre feet per half month','Flow','ac ft/0.5 mo');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (347,'cubic meters per minute','Flow','m^3/min');
INSERT INTO `units` (`UnitsID`,`UnitsName`,`UnitsType`,`UnitsAbbreviation`) VALUES (348,'count per half cubic foot','Concentration','#/((ft^3)/2)');

--
-- Dumping data for table `qualitycontrollevels`
--

INSERT INTO `qualitycontrollevels` (`QualityControlLevelID`,`QualityControlLevelCode`,`Definition`,`Explanation`) VALUES (-9999,'-9999','Unknown','The quality control level is unknown');
INSERT INTO `qualitycontrollevels` (`QualityControlLevelID`,`QualityControlLevelCode`,`Definition`,`Explanation`) VALUES (0,'0','Raw data','Raw and unprocessed data and data products that have not undergone quality control.  Depending on the variable, data type, and data transmission system, raw data may be available within seconds or minutes after the measurements have been made. Examples include real time precipitation, streamflow and water quality measurements.');
INSERT INTO `qualitycontrollevels` (`QualityControlLevelID`,`QualityControlLevelCode`,`Definition`,`Explanation`) VALUES (1,'1','Quality controlled data','Quality controlled data that have passed quality assurance procedures such as routine estimation of timing and sensor calibration or visual inspection and removal of obvious errors. An example is USGS published streamflow records following parsing through USGS quality control procedures.');
INSERT INTO `qualitycontrollevels` (`QualityControlLevelID`,`QualityControlLevelCode`,`Definition`,`Explanation`) VALUES (2,'2','Derived products','Derived products that require scientific and technical interpretation and may include multiple-sensor data. An example is basin average precipitation derived from rain gages using an interpolation procedure.');
INSERT INTO `qualitycontrollevels` (`QualityControlLevelID`,`QualityControlLevelCode`,`Definition`,`Explanation`) VALUES (3,'3','Interpreted products','Interpreted products that require researcher driven analysis and interpretation, model-based interpretation using other data and/or strong prior assumptions. An example is basin average precipitation derived from the combination of rain gages and radar return data.');
INSERT INTO `qualitycontrollevels` (`QualityControlLevelID`,`QualityControlLevelCode`,`Definition`,`Explanation`) VALUES (4,'4','Knowledge products','Knowledge products that require researcher driven scientific interpretation and multidisciplinary data integration and include model-based interpretation using other data and/or strong prior assumptions. An example is percentages of old or new water in a hydrograph inferred from an isotope analysis.');

--
-- Dumping data for table `odmversion`
--

INSERT INTO `odmversion` (`VersionNumber`) VALUES ('1.1.1');

--
-- Dumping data for table `sampletypecv`
--

INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('Automated','Sample collected using an automated sampler');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('FD ',' Foliage Digestion');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('FF ',' Forest Floor Digestion');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('FL ',' Foliage Leaching');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('Grab','Grab sample');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('GW ',' Groundwater');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('LF ',' Litter Fall Digestion');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('meteorological','sample type can include a number of measured sample types including temperature, RH, solar radiation, precipitation, wind speed, wind direction.');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('No Sample','There is no lab sample associated with this measurement');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('PB  ',' Precipitation Bulk');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('PD ',' Petri Dish (Dry Deposition)');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('PE ',' Precipitation Event');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('PI ',' Precipitation Increment');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('PW ',' Precipitation Weekly');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('RE ',' Rock Extraction');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('SE ',' Stemflow Event');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('SR ',' Standard Reference');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('SS ','Streamwater Suspended Sediment');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('SW ',' Streamwater');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('TE ',' Throughfall Event');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('TI ',' Throughfall Increment');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('TW ',' Throughfall Weekly');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('Unknown','The sample type is unknown');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('VE ',' Vadose Water Event');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('VI ',' Vadose Water Increment');
INSERT INTO `sampletypecv` (`Term`,`Definition`) VALUES ('VW ',' Vadose Water Weekly');

--
-- Dumping data for table `sitetypecv`
--

INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Aggregate groundwater use','An Aggregate Groundwater Withdrawal/Return site represents an aggregate of specific sites whe groundwater is withdrawn or returned which is defined by a geographic area or some other common characteristic. An aggregate groundwatergroundwater site type is used when it is not possible or practical to describe the specific sites as springs or as any type of well including \'multiple wells\', or when water-use information is only available for the aggregate. Aggregate sites that span multiple counties should be coded with 000 as the county code, or an aggregate site can be created for each county.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Aggregate surface-water-use','An Aggregate Surface-Water Diversion/Return site represents an aggregate of specific sites where surface water is diverted or returned which is defined by a geographic area or some other common characteristic. An aggregate surface-water site type is used when it is not possible or practical to describe the specific sites as diversions, outfalls, or land application sites, or when water-use information is only available for the aggregate. Aggregate sites that span multiple counties should be coded with 000 as the county code, or an aggregate site can be created for each county.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Aggregate water-use establishment','An Aggregate Water-Use Establishment represents an aggregate class of water-using establishments or individuals that are associated with a specific geographic location and water-use category, such as all the industrial users located within a county or all self-supplied domestic users in a county. The aggregate class of water-using establishments is identified using the national water-use category code and optionally classified using the Standard Industrial Classification System Code (SIC code) or North American Classification System Code (NAICS code). An aggregate water-use establishment site type is used when specific information needed to create sites for the individual facilities or users is not available or when it is not desirable to store the site-specific information in the database. Data entry rules that apply to water-use establishments also apply to aggregate water-use establishments. Aggregate sites that span multiple counties should be coded with 000 as the county code, or an aggregate site can be created for each county.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Animal waste lagoon','A facility for storage and/or biological treatment of wastes from livestock operations. Animal-waste lagoons are earthen structures ranging from pits to large ponds, and contain manure which has been diluted with building washwater, rainfall, and surface runoff. In treatment lagoons, the waste becomes partially liquefied and stabilized by bacterial action before the waste is disposed of on the land and the water is discharged or re-used.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Atmosphere','A site established primarily to measure meteorological properties or atmospheric deposition.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Canal','An artificial watercourse designed for navigation, drainage, or irrigation by connecting two or more bodies of water; it is larger than a ditch.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Cave','A natural open space within a rock formation large enough to accommodate a human. A cave may have an opening to the outside, is always underground, and sometimes submerged. Caves commonly occur by the dissolution of soluble rocks, generally limestone, but may also be created within the voids of large-rock aggregations, in openings along seismic faults, and in lava formations.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Cistern','An artificial, non-pressurized reservoir filled by gravity flow and used for water storage. The reservoir may be located above, at, or below ground level. The water may be supplied from diversion of precipitation, surface, or groundwater sources.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Coastal','An oceanic site that is located off-shore beyond the tidal mixing zone (estuary) but close enough to the shore that the investigator considers the presence of the coast to be important. Coastal sites typically are within three nautical miles of the shore.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Collector or Ranney type well','An infiltration gallery consisting of one or more underground laterals through which groundwater is collected and a vertical caisson from which groundwater is removed. Also known as a \"horizontal well\". These wells produce large yield with small drawdown.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Combined sewer','An underground conduit created to convey storm drainage and waste products into a wastewater-treatment plant, stream, reservoir, or disposal site.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Ditch','An excavation artificially dug in the ground, either lined or unlined, for conveying water for drainage or irrigation; it is smaller than a canal.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Diversion','A site where water is withdrawn or diverted from a surface-water body (e.g. the point where the upstream end of a canal intersects a stream, or point where water is withdrawn from a reservoir). Includes sites where water is pumped for use elsewhere.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Estuary','A coastal inlet of the sea or ocean; esp. the mouth of a river, where tide water normally mixes with stream water (modified, Webster). Salinity in estuaries typically ranges from 1 to 25 Practical Salinity Units (psu), as compared oceanic values around 35-psu. See also: tidal stream and coastal.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Excavation','An artificially constructed cavity in the earth that is deeper than the soil (see soil hole), larger than a well bore (see well and test hole), and substantially open to the atmosphere. The diameter of an excavation is typically similar or larger than the depth. Excavations include building-foundation diggings, roadway cuts, and surface mines.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Extensometer well','A well equipped to measure small changes in the thickness of the penetrated sediments, such as those caused by groundwater withdrawal or recharge.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Facility','A non-ambient location where environmental measurements are expected to be strongly influenced by current or previous activities of humans. *Sites identified with a \"facility\" primary site type must be further classified with one of the applicable secondary site types.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Field, Pasture, Orchard, or Nursery','A water-using facility characterized by an area where plants are grown for transplanting, for use as stocks for budding and grafting, or for sale. Irrigation water may or may not be applied.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Glacier','Body of land ice that consists of recrystallized snow accumulated on the surface of the ground and moves slowly downslope (WSP-1541A) over a period of years or centuries. Since glacial sites move, the lat-long precision for these sites is usually coarse.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Golf course','A place-of-use, either public or private, where the game of golf is played. A golf course typically uses water for irrigation purposes. Should not be used if the site is a specific hydrologic feature or facility; but can be used especially for the water-use sites.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Groundwater drain','An underground pipe or tunnel through which groundwater is artificially diverted to surface water for the purpose of reducing erosion or lowering the water table. A drain is typically open to the atmosphere at the lowest elevation, in contrast to a well which is open at the highest point.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Hydroelectric plant','A facility that generates electric power by converting potential energy of water into kinetic energy. Typically, turbine generators are turned by falling water.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Hyporheic-zone well','A permanent well, drive point, or other device intended to sample a saturated zone in close proximity to a stream.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Interconnected wells','Collector or drainage wells connected by an underground lateral.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Laboratory or sample-preparation area','A site where some types of quality-control samples are collected, and where equipment and supplies for environmental sampling are prepared. Equipment blank samples are commonly collected at this site type, as are samples of locally produced deionized water. This site type is typically used when the data are either not associated with a unique environmental data-collection site, or where blank water supplies are designated by Center offices with unique station IDs.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Lake, Reservoir, Impoundment','An inland body of standing fresh or saline water that is generally too deep to permit submerged aquatic vegetation to take root across the entire body (cf: wetland). This site type includes an expanded part of a river, a reservoir behind a dam, and a natural or excavated depression containing a water body without surface-water inlet and/or outlet.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Land','A location on the surface of the earth that is not normally saturated with water. Land sites are appropriate for sampling vegetation, overland flow of water, or measuring land-surface properties such as temperature. (See also: Wetland).');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Landfill','A typically dry location on the surface of the land where primarily solid waste products are currently, or previously have been, aggregated and sometimes covered with a veneer of soil. See also: Wastewater disposal and waste-injection well.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Multiple wells','A group of wells that are pumped through a single header and for which little or no data about the individual wells are available.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Ocean','Site in the open ocean, gulf, or sea. (See also: Coastal, Estuary, and Tidal stream).');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Outcrop','The part of a rock formation that appears at the surface of the surrounding land.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Outfall','A site where water or wastewater is returned to a surface-water body, e.g. the point where wastewater is returned to a stream. Typically, the discharge end of an effluent pipe.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Pavement','A surface site where the land surface is covered by a relatively impermeable material, such as concrete or asphalt. Pavement sites are typically part of transportation infrastructure, such as roadways, parking lots, or runways.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Playa','A dried-up, vegetation-free, flat-floored area composed of thin, evenly stratified sheets of fine clay, silt or sand, and represents the bottom part of a shallow, completely closed or undrained desert lake basin in which water accumulates and is quickly evaporated, usually leaving deposits of soluble salts.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Septic system','A site within or in close proximity to a subsurface sewage disposal system that generally consists of: (1) a septic tank where settling of solid material occurs, (2) a distribution system that transfers fluid from the tank to (3) a leaching system that disperses the effluent into the ground.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Shore','The land along the edge of the sea, a lake, or a wide river where the investigator considers the proximity of the water body to be important. Land adjacent to a reservoir, lake, impoundment, or oceanic site type is considered part of the shore when it includes a beach or bank between the high and low water marks.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Sinkhole','A crater formed when the roof of a cavern collapses; usually found in limestone areas. Surface water and precipitation that enters a sinkhole usually evaporates or infiltrates into the ground, rather than draining into a stream.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Soil hole','A small excavation into soil at the top few meters of earth surface. Soil generally includes some organic matter derived from plants. Soil holes are created to measure soil composition and properties. Sometimes electronic probes are inserted into soil holes to measure physical properties, and (or) the extracted soil is analyzed.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Spring','A location at which the water table intersects the land surface, resulting in a natural flow of groundwater to the surface. Springs may be perennial, intermittent, or ephemeral.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Storm sewer','An underground conduit created to convey storm drainage into a stream channel or reservoir. If the sewer also conveys liquid waste products, then the \"combined sewer\" secondary site type should be used.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Stream','A body of running water moving under gravity flow in a defined channel. The channel may be entirely natural, or altered by engineering practices through straightening, dredging, and (or) lining. An entirely artificial channel should be qualified with the \"canal\" or \"ditch\" secondary site type.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Subsurface','A location below the land surface, but not a well, soil hole, or excavation.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Test hole not completed as a well','An uncased hole (or one cased only temporarily) that was drilled for water, or for geologic or hydrogeologic testing. It may be equipped temporarily with a pump in order to make a pumping test, but if the hole is destroyed after testing is completed, it is still a test hole. A core hole drilled as a part of mining or quarrying exploration work should be in this class.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Thermoelectric plant','A facility that uses water in the generation of electricity from heat. Typically turbine generators are driven by steam. The heat may be caused by various means, including combustion, nuclear reactions, and geothermal processes.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Tidal stream','A stream reach where the flow is influenced by the tide, but where the water chemistry is not normally influenced. A site where ocean water typically mixes with stream water should be coded as an estuary.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Tunnel, shaft, or mine','A constructed subsurface open space large enough to accommodate a human that is not substantially open to the atmosphere and is not a well. The excavation may have been for minerals, transportation, or other purposes. See also: Excavation.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Unsaturated zone','A site equipped to measure conditions in the subsurface deeper than a soil hole, but above the water table or other zone of saturation.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Volcanic vent','Vent from which volcanic gases escape to the atmosphere. Also known as fumarole.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Waste injection well','A facility used to convey industrial waste, domestic sewage, brine, mine drainage, radioactive waste, or other fluid into an underground zone. An oil-test or deep-water well converted to waste disposal should be in this category. A well where fresh water is injected to artificially recharge thegroundwaterr supply or to pressurize an oil or gas production zone by injecting a fluid should be classified as a well (not an injection-well facility), with additional information recorded under Use of Site.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Wastewater land application','A site where the disposal of waste water on land occurs. Use \"waste-injection well\" for underground waste-disposal sites.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Wastewater sewer','An underground conduit created to convey liquid and semisolid domestic, commercial, or industrial waste into a treatment plant, stream, reservoir, or disposal site. If the sewer also conveys storm water, then the \"combined sewer\" secondary site type should be used.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Wastewater-treatment plant','A facility where wastewater is treated to reduce concentrations of dissolved and (or) suspended materials prior to discharge or reuse.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Water-distribution system','A site located somewhere on a networked infrastructure that distributes treated or untreated water to multiple domestic, industrial, institutional, and (or) commercial users. May be owned by a municipality or community, a water district, or a private concern.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Water-supply treatment plant','A facility where water is treated prior to use for consumption or other purpose.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Water-use establishment','A place-of-use (a water using facility that is associated with a specific geographical point location, such as a business or industrial user) that cannot be specified with any other facility secondary type. Water-use place-of-use sites are establishments such as a factory, mill, store, warehouse, farm, ranch, or bank. A place-of-use site is further classified using the national water-use category code (C39) and optionally classified using the Standard Industrial Classification System Code (SIC code) or North American Classification System Code (NAICS code). See also: Aggregate water-use-establishment.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Well','A hole or shaft constructed in the earth intended to be used to locate, sample, or develop groundwater, oil, gas, or some other subsurface material. The diameter of a well is typically much smaller than the depth. Wells are also used to artificially recharge groundwater or to pressurize oil and gas production zones. Additional information about specific kinds of wells should be recorded under the secondary site types or the Use of Site field. Underground waste-disposal wells should be classified as waste-injection wells.');
INSERT INTO `sitetypecv` (`Term`,`Definition`) VALUES ('Wetland','Land where saturation with water is the dominant factor determining the nature of soil development and the types of plant and animal communities living in the soil and on its surface (Cowardin, December 1979). Wetlands are found from the tundra to the tropics and on every continent except Antarctica. Wetlands are areas that are inundated or saturated by surface or groundwater at a frequency and duration sufficient to support, and that under normal circumstances do support, a prevalence of vegetation typically adapted for life in saturated soil conditions. Wetlands generally include swamps, marshes, bogs and similar areas. Wetlands may be forested or unforested, and naturally or artificially created.');

--
-- Dumping data for table `valuetypecv`
--

INSERT INTO `valuetypecv` (`Term`,`Definition`) VALUES ('Calibration Value','A value used as part of the calibration of an instrument at a particular time.');
INSERT INTO `valuetypecv` (`Term`,`Definition`) VALUES ('Derived Value','Value that is directly derived from an observation or set of observations');
INSERT INTO `valuetypecv` (`Term`,`Definition`) VALUES ('Field Observation','Observation of a variable using a field instrument');
INSERT INTO `valuetypecv` (`Term`,`Definition`) VALUES ('Model Simulation Result','Values generated by a simulation model');
INSERT INTO `valuetypecv` (`Term`,`Definition`) VALUES ('Sample','Observation that is the result of analyzing a sample in a laboratory');
INSERT INTO `valuetypecv` (`Term`,`Definition`) VALUES ('Unknown','The value type is unknown');

--
-- Dumping data for table `spatialreferences`
--

INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (0,NULL,'Unknown',0,'The spatial reference system is unknown');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (1,4267,'NAD27',1,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (2,4269,'NAD83',1,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (3,4326,'WGS84',1,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (4,26703,'NAD27 / UTM zone 3N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (5,26704,'NAD27 / UTM zone 4N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (6,26705,'NAD27 / UTM zone 5N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (7,26706,'NAD27 / UTM zone 6N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (8,26707,'NAD27 / UTM zone 7N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (9,26708,'NAD27 / UTM zone 8N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (10,26709,'NAD27 / UTM zone 9N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (11,26710,'NAD27 / UTM zone 10N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (12,26711,'NAD27 / UTM zone 11N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (13,26712,'NAD27 / UTM zone 12N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (14,26713,'NAD27 / UTM zone 13N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (15,26714,'NAD27 / UTM zone 14N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (16,26715,'NAD27 / UTM zone 15N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (17,26716,'NAD27 / UTM zone 16N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (18,26717,'NAD27 / UTM zone 17N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (19,26718,'NAD27 / UTM zone 18N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (20,26719,'NAD27 / UTM zone 19N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (21,26720,'NAD27 / UTM zone 20N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (22,26721,'NAD27 / UTM zone 21N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (23,26722,'NAD27 / UTM zone 22N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (24,26729,'NAD27 / Alabama East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (25,26730,'NAD27 / Alabama West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (26,26732,'NAD27 / Alaska zone 2',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (27,26733,'NAD27 / Alaska zone 3',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (28,26734,'NAD27 / Alaska zone 4',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (29,26735,'NAD27 / Alaska zone 5',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (30,26736,'NAD27 / Alaska zone 6',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (31,26737,'NAD27 / Alaska zone 7',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (32,26738,'NAD27 / Alaska zone 8',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (33,26739,'NAD27 / Alaska zone 9',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (34,26740,'NAD27 / Alaska zone 10',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (35,26741,'NAD27 / California zone I',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (36,26742,'NAD27 / California zone II',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (37,26743,'NAD27 / California zone III',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (38,26744,'NAD27 / California zone IV',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (39,26745,'NAD27 / California zone V',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (40,26746,'NAD27 / California zone VI',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (41,26747,'NAD27 / California zone VII',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (42,26748,'NAD27 / Arizona East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (43,26749,'NAD27 / Arizona Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (44,26750,'NAD27 / Arizona West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (45,26751,'NAD27 / Arkansas North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (46,26752,'NAD27 / Arkansas South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (47,26753,'NAD27 / Colorado North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (48,26754,'NAD27 / Colorado Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (49,26755,'NAD27 / Colorado South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (50,26756,'NAD27 / Connecticut',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (51,26757,'NAD27 / Delaware',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (52,26758,'NAD27 / Florida East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (53,26759,'NAD27 / Florida West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (54,26760,'NAD27 / Florida North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (55,26761,'NAD27 / Hawaii zone 1',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (56,26762,'NAD27 / Hawaii zone 2',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (57,26763,'NAD27 / Hawaii zone 3',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (58,26764,'NAD27 / Hawaii zone 4',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (59,26765,'NAD27 / Hawaii zone 5',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (60,26766,'NAD27 / Georgia East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (61,26767,'NAD27 / Georgia West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (62,26768,'NAD27 / Idaho East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (63,26769,'NAD27 / Idaho Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (64,26770,'NAD27 / Idaho West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (65,26771,'NAD27 / Illinois East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (66,26772,'NAD27 / Illinois West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (67,26773,'NAD27 / Indiana East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (68,26774,'NAD27 / Indiana West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (69,26775,'NAD27 / Iowa North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (70,26776,'NAD27 / Iowa South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (71,26777,'NAD27 / Kansas North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (72,26778,'NAD27 / Kansas South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (73,26779,'NAD27 / Kentucky North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (74,26780,'NAD27 / Kentucky South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (75,26781,'NAD27 / Louisiana North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (76,26782,'NAD27 / Louisiana South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (77,26783,'NAD27 / Maine East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (78,26784,'NAD27 / Maine West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (79,26785,'NAD27 / Maryland',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (80,26786,'NAD27 / Massachusetts Mainland',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (81,26787,'NAD27 / Massachusetts Island',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (82,26791,'NAD27 / Minnesota North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (83,26792,'NAD27 / Minnesota Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (84,26793,'NAD27 / Minnesota South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (85,26794,'NAD27 / Mississippi East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (86,26795,'NAD27 / Mississippi West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (87,26796,'NAD27 / Missouri East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (88,26797,'NAD27 / Missouri Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (89,26798,'NAD27 / Missouri West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (90,26801,'NAD Michigan / Michigan East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (91,26802,'NAD Michigan / Michigan Old Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (92,26803,'NAD Michigan / Michigan West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (93,26811,'NAD Michigan / Michigan North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (94,26812,'NAD Michigan / Michigan Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (95,26813,'NAD Michigan / Michigan South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (96,26903,'NAD83 / UTM zone 3N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (97,26904,'NAD83 / UTM zone 4N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (98,26905,'NAD83 / UTM zone 5N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (99,26906,'NAD83 / UTM zone 6N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (100,26907,'NAD83 / UTM zone 7N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (101,26908,'NAD83 / UTM zone 8N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (102,26909,'NAD83 / UTM zone 9N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (103,26910,'NAD83 / UTM zone 10N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (104,26911,'NAD83 / UTM zone 11N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (105,26912,'NAD83 / UTM zone 12N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (106,26913,'NAD83 / UTM zone 13N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (107,26914,'NAD83 / UTM zone 14N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (108,26915,'NAD83 / UTM zone 15N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (109,26916,'NAD83 / UTM zone 16N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (110,26917,'NAD83 / UTM zone 17N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (111,26918,'NAD83 / UTM zone 18N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (112,26919,'NAD83 / UTM zone 19N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (113,26920,'NAD83 / UTM zone 20N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (114,26921,'NAD83 / UTM zone 21N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (115,26922,'NAD83 / UTM zone 22N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (116,26923,'NAD83 / UTM zone 23N',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (117,26929,'NAD83 / Alabama East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (118,26930,'NAD83 / Alabama West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (119,26932,'NAD83 / Alaska zone 2',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (120,26933,'NAD83 / Alaska zone 3',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (121,26934,'NAD83 / Alaska zone 4',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (122,26935,'NAD83 / Alaska zone 5',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (123,26936,'NAD83 / Alaska zone 6',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (124,26937,'NAD83 / Alaska zone 7',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (125,26938,'NAD83 / Alaska zone 8',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (126,26939,'NAD83 / Alaska zone 9',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (127,26940,'NAD83 / Alaska zone 10',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (128,26941,'NAD83 / California zone 1',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (129,26942,'NAD83 / California zone 2',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (130,26943,'NAD83 / California zone 3',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (131,26944,'NAD83 / California zone 4',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (132,26945,'NAD83 / California zone 5',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (133,26946,'NAD83 / California zone 6',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (134,26948,'NAD83 / Arizona East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (135,26949,'NAD83 / Arizona Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (136,26950,'NAD83 / Arizona West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (137,26951,'NAD83 / Arkansas North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (138,26952,'NAD83 / Arkansas South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (139,26953,'NAD83 / Colorado North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (140,26954,'NAD83 / Colorado Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (141,26955,'NAD83 / Colorado South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (142,26956,'NAD83 / Connecticut',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (143,26957,'NAD83 / Delaware',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (144,26958,'NAD83 / Florida East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (145,26959,'NAD83 / Florida West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (146,26960,'NAD83 / Florida North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (147,26961,'NAD83 / Hawaii zone 1',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (148,26962,'NAD83 / Hawaii zone 2',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (149,26963,'NAD83 / Hawaii zone 3',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (150,26964,'NAD83 / Hawaii zone 4',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (151,26965,'NAD83 / Hawaii zone 5',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (152,26966,'NAD83 / Georgia East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (153,26967,'NAD83 / Georgia West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (154,26968,'NAD83 / Idaho East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (155,26969,'NAD83 / Idaho Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (156,26970,'NAD83 / Idaho West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (157,26971,'NAD83 / Illinois East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (158,26972,'NAD83 / Illinois West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (159,26973,'NAD83 / Indiana East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (160,26974,'NAD83 / Indiana West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (161,26975,'NAD83 / Iowa North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (162,26976,'NAD83 / Iowa South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (163,26977,'NAD83 / Kansas North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (164,26978,'NAD83 / Kansas South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (165,26979,'NAD83 / Kentucky North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (166,26980,'NAD83 / Kentucky South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (167,26981,'NAD83 / Louisiana North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (168,26982,'NAD83 / Louisiana South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (169,26983,'NAD83 / Maine East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (170,26984,'NAD83 / Maine West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (171,26985,'NAD83 / Maryland',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (172,26986,'NAD83 / Massachusetts Mainland',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (173,26987,'NAD83 / Massachusetts Island',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (174,26988,'NAD83 / Michigan North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (175,26989,'NAD83 / Michigan Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (176,26990,'NAD83 / Michigan South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (177,26991,'NAD83 / Minnesota North',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (178,26992,'NAD83 / Minnesota Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (179,26993,'NAD83 / Minnesota South',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (180,26994,'NAD83 / Mississippi East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (181,26995,'NAD83 / Mississippi West',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (182,26996,'NAD83 / Missouri East',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (183,26997,'NAD83 / Missouri Central',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (184,26998,'NAD83 / Missouri West  ',0,NULL);
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (185,4176,'Australian Antarctic',1,'Datum Name: Australian Antarctic Datum 1998    Area of Use: Antarctica - Australian sector.    Datum Origin: No Data Available    Coord System: ellipsoidal    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (186,4203,'AGD84',1,'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - Queensland (Qld), South Australia (SA), Western Australia (WA).    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: ellipsoidal    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (187,4283,'GDA94',1,'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - Australian Capital Territory (ACT); New South Wales (NSW); Northern Territory (NT); Queensland (Qld); South Australia (SA); Tasmania (Tas); Western Australia (WA); Victoria (Vic).    Datum Origin: ITRF92 at epoch 1994.0    Coord System: ellipsoidal    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (188,5711,'Australian Height Datum',0,'Datum Name: Australian Height Datum    Area of Use: Australia - Australian Capital Territory (ACT); New South Wales (NSW); Northern Territory (NT); Queensland; South Australia (SA); Western Australia (WA); Victoria.    Datum Origin: MSL 1966-68 at 30 gauges around coast.    Coord System: vertical    Ellipsoid Name: No Data Available    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (189,5712,'Australian Height Datum (Tasmania)',0,'Datum Name: Australian Height Datum (Tasmania)    Area of Use: Australia - Tasmania (Tas).    Datum Origin: MSL 1972 at Hobart and Burnie.    Coord System: vertical    Ellipsoid Name: No Data Available    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (190,5714,'Mean Sea Level Height',0,'Datum Name: Mean Sea Level    Area of Use: World.    Datum Origin: No Data Available    Coord System: vertical    Ellipsoid Name: No Data Available    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (191,5715,'Mean Sea Level Depth',0,'Datum Name: Mean Sea Level    Area of Use: World.    Datum Origin: No Data Available    Coord System: vertical    Ellipsoid Name: No Data Available    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (192,20348,'AGD84 / AMG zone 48',0,'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 102 and 108 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (193,20349,'AGD84 / AMG zone 49',0,'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 108 and 114 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (194,20350,'AGD84 / AMG zone 50',0,'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 114 and 120 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (195,20351,'AGD84 / AMG zone 51',0,'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 120 and 126 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (196,20352,'AGD84 / AMG zone 52',0,'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 126 and 132 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (197,20353,'AGD84 / AMG zone 53',0,'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 132 and 138 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (198,20354,'AGD84 / AMG zone 54',0,'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 138 and 144 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (199,20355,'AGD84 / AMG zone 55',0,'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 144 and 150 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (200,20356,'AGD84 / AMG zone 56',0,'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 150 and 156 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (201,20357,'AGD84 / AMG zone 57',0,'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 156 and 162 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (202,20358,'AGD84 / AMG zone 58',0,'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 162 and 168 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (203,28348,'GDA94 / MGA zone 48',0,'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 102 and 108 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (204,28349,'GDA94 / MGA zone 49',0,'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 108 and 114 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (205,28350,'GDA94 / MGA zone 50',0,'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 114 and 120 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (206,28351,'GDA94 / MGA zone 51',0,'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 120 and 126 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (207,28352,'GDA94 / MGA zone 52',0,'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 126 and 132 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (208,28353,'GDA94 / MGA zone 53',0,'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 132 and 138 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (209,28354,'GDA94 / MGA zone 54',0,'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 138 and 144 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (210,28355,'GDA94 / MGA zone 55',0,'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 144 and 150 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (211,28356,'GDA94 / MGA zone 56',0,'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 150 and 156 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (212,28357,'GDA94 / MGA zone 57',0,'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 156 and 162 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (213,28358,'GDA94 / MGA zone 58',0,'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 162 and 168 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (214,32748,'WGS 84 / UTM zone 48S',0,'Datum Name: World Geodetic System 1984    Area of Use: Between 102 and 108 deg East; southern hemisphere. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (215,32749,'WGS 84 / UTM zone 49S',0,'Datum Name: World Geodetic System 1984    Area of Use: Between 108 and 114 deg East; southern hemisphere. Australia. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (216,32750,'WGS 84 / UTM zone 50S',0,'Datum Name: World Geodetic System 1984    Area of Use: Between 114 and 120 deg East; southern hemisphere. Australia. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (217,32751,'WGS 84 / UTM zone 51S',0,'Datum Name: World Geodetic System 1984    Area of Use: Between 120 and 126 deg East; southern hemisphere. Australia. East Timor. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (218,32752,'WGS 84 / UTM zone 52S',0,'Datum Name: World Geodetic System 1984    Area of Use: Between 126 and 132 deg East; southern hemisphere. Australia. East Timor. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (219,32753,'WGS 84 / UTM zone 53S',0,'Datum Name: World Geodetic System 1984    Area of Use: Between 132 and 138 deg East; southern hemisphere. Australia.  Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (220,32754,'WGS 84 / UTM zone 54S',0,'Datum Name: World Geodetic System 1984    Area of Use: Between 138 and 144 deg East; southern hemisphere. Australia. Indonesia. Papua New Guinea.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (221,32755,'WGS 84 / UTM zone 55S',0,'Datum Name: World Geodetic System 1984    Area of Use: Between 144 and 150 deg East; southern hemisphere. Australia. Papua New Guinea.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (222,32756,'WGS 84 / UTM zone 56S',0,'Datum Name: World Geodetic System 1984    Area of Use: Between 150 and 156 deg East; southern hemisphere. Australia. Papua New Guinea.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (223,32757,'WGS 84 / UTM zone 57S',0,'Datum Name: World Geodetic System 1984    Area of Use: Between 156 and 162 deg East; southern hemisphere.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (224,32758,'WGS 84 / UTM zone 58S',0,'Datum Name: World Geodetic System 1984    Area of Use: Between 162 and 168 deg East; southern hemisphere.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (225,3308,'GDA94 / NSW Lambert',0,'Datum Name: Geocentric Datum of Australia 1994 Area of Use: Australia - New South Wales (NSW). Datum Origin: ITRF92 at epoch 1994.0  Ellipsoid Name: GRS 1980 Data Source: EPSG');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (226,2914,'NAD_1983_HARN_StatePlane_Oregon_South_FIPS_3602_Feet_Intl',0,'I wonder if we can\'t just load the entire list at:\nhttp://www.arcwebservices.com/v2006/help/index_Left.htm#StartTopic=support/pcs_name.htm#|SkinName=ArcWeb \ninto the CV??');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (227,2276,'NAD83 / Texas North Central (ftUS)',0,'ESRI Name: NAD_1983_StatePlane_Texas_North_Central_FIPS_4202_Feet\nArea of Use: United States (USA) - Texas - counties of: Andrews; Archer; Bailey; Baylor; Borden; Bowie; Callahan; Camp; Cass; Clay; Cochran; Collin; Cooke; Cottle; Crosby; Dallas; Dawson; Delta; Denton; Dickens; Eastland; Ellis; Erath; Fannin; Fisher; Floyd; Foard; Franklin; Gaines; Garza; Grayson; Gregg; Hale; Hardeman; Harrison; Haskell; Henderson; Hill; Hockley; Hood; Hopkins; Howard; Hunt; Jack; Johnson; Jones; Kaufman; Kent; King; Knox; Lamar; Lamb; Lubbock; Lynn; Marion; Martin; Mitchell; Montague; Morris; Motley; Navarro; Nolan; Palo Pinto; Panola; Parker; Rains; Red River; Rockwall; Rusk; Scurry; Shackelford; Smith; Somervell; Stephens; Stonewall; Tarrant; Taylor; Terry; Throckmorton; Titus; Upshur; Van Zandt; Wichita; Wilbarger; Wise; Wood; Yoakum; Young.');
INSERT INTO `spatialreferences` (`SpatialReferenceID`,`SRSID`,`SRSName`,`IsGeographic`,`Notes`) VALUES (228,0,'HRAP Grid Coordinate System',0,'Datum Name: Hydrologic Rainfall Analysis Project (HRAP) grid coordinate system  Information: a polar stereographic projection true at 60°N / 105°W  Link:  http://www.nws.noaa.gov/oh/hrl/distmodel/hrap.htm#background');

--
-- Dumping data for table `isometadata`
--

INSERT INTO `isometadata` (`MetadataID`,`TopicCategory`,`Title`,`Abstract`,`ProfileVersion`,`MetadataLink`) VALUES (0,'Unknown','Unknown','Unknown','Unknown',NULL);

--
-- Dumping data for table `verticaldatumcv`
--

INSERT INTO `verticaldatumcv` (`Term`,`Definition`) VALUES ('MSL','Mean Sea Level');
INSERT INTO `verticaldatumcv` (`Term`,`Definition`) VALUES ('NAVD88','North American Vertical Datum of 1988');
INSERT INTO `verticaldatumcv` (`Term`,`Definition`) VALUES ('NGVD29','National Geodetic Vertical Datum of 1929');
INSERT INTO `verticaldatumcv` (`Term`,`Definition`) VALUES ('Unknown','The vertical datum is unknown');

--
-- Dumping data for table `variablenamecv`
--

INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('19-Hexanoyloxyfucoxanthin','The phytoplankton pigment 19-Hexanoyloxyfucoxanthin');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('9 cis-Neoxanthin','The phytoplankton pigment  9 cis-Neoxanthin');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Acid neutralizing capacity','Acid neutralizing capacity ');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Agency code','Code for the agency which analyzed the sample');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Albedo','The ratio of reflected to incident light.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Alkalinity, bicarbonate','Bicarbonate Alkalinity ');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Alkalinity, carbonate ','Carbonate Alkalinity ');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Alkalinity, carbonate plus bicarbonate','Alkalinity, carbonate plus bicarbonate');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Alkalinity, hydroxide ','Hydroxide Alkalinity ');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Alkalinity, total ','Total Alkalinity');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Alloxanthin','The phytoplankton pigment Alloxanthin');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Aluminium','Aluminium (Al)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Aluminum, dissolved','Dissolved Aluminum (Al)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Ammonium flux','Ammonium (NH4) flux');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Antimony','Antimony (Sb)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Area','Area of a measurement location');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Arsenic','Arsenic (As)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Asteridae coverage','Areal coverage of the plant Asteridae');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Barium, dissolved','Dissolved Barium (Ba)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Barium, total','Total Barium (Ba)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Barometric pressure','Barometric pressure');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Baseflow','The portion of streamflow (discharge) that is supplied by groundwater sources.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Batis maritima Coverage','Areal coverage of the plant Batis maritima');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Battery Temperature','The battery temperature of a datalogger or sensing system');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Battery voltage','The battery voltage of a datalogger or sensing system, often recorded as an indicator of data reliability');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Benthos','Benthic species');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Bicarbonate','Bicarbonate (HCO3-)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Biogenic silica','Hydrated silica (SiO2 nH20)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Biomass, phytoplankton','Total mass of phytoplankton, per unit area or volume');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Biomass, total','Total biomass');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Blue-green algae (cyanobacteria), phycocyanin','Blue-green algae (cyanobacteria) with phycocyanin pigments');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BOD1','1-day Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BOD2, carbonaceous','2-day Carbonaceous Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BOD20','20-day Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BOD20, carbonaceous','20-day Carbonaceous Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BOD20, nitrogenous','20-day Nitrogenous Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BOD3, carbonaceous','3-day Carbonaceous Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BOD4, carbonaceous','4-day Carbonaceous Biological Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BOD5','5-day Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BOD5, carbonaceous','5-day Carbonaceous Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BOD5, nitrogenous','5-day Nitrogenous Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BOD6, carbonaceous','6-day Carbonaceous Biological Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BOD7, carbonaceous','7-day Carbonaceous Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BODu','Ultimate Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BODu, carbonaceous','Carbonaceous Ultimate Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('BODu, nitrogenous','Nitrogenous Ultimate Biochemical Oxygen Demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Borehole log material classification','Classification of material encountered by a driller at various depths during the drilling of a well and recorded in the borehole log.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Boron','Boron (B)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Borrichia frutescens Coverage','Areal coverage of the plant Borrichia frutescens');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Bromide','Bromide');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Bromine','Bromine (Br)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Bromine, dissolved','Dissolved Bromine (Br)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Bulk electrical conductivity','Bulk electrical conductivity of a medium measured using a sensor such as time domain reflectometry (TDR), as a raw sensor response in the measurement of a quantity like soil moisture.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Cadmium','Cadmium (Cd)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Calcium ','Calcium (Ca) ');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Calcium, dissolved','Dissolved Calcium (Ca)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Canthaxanthin','The phytoplankton pigment Canthaxanthin');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon dioxide','Carbon dioxide');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon dioxide Flux','Carbon dioxide (CO2) flux');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon dioxide Storage Flux','Carbon dioxide (CO2) storage flux');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon dioxide, transducer signal','Carbon dioxide (CO2), raw data from sensor');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon disulfide','Carbon disulfide (CS2)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon tetrachloride','Carbon tetrachloride (CCl4)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon to Nitrogen molar ratio','C:N (molar)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon, dissolved inorganic','Dissolved Inorganic Carbon');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon, dissolved organic','Dissolved Organic Carbon');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon, dissolved total','Dissolved Total (Organic+Inorganic) Carbon');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon, particulate organic','Particulate organic carbon in suspension');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon, suspended inorganic','Suspended Inorganic Carbon');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon, suspended organic','DEPRECATED -- The use of this term is discouraged in favor of the use of the synonymous term \"Carbon, particulate organic\".');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon, suspened total','Suspended Total (Organic+Inorganic) Carbon');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon, total','Total (Dissolved+Particulate) Carbon');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon, total inorganic','Total (Dissolved+Particulate) Inorganic Carbon');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon, total organic','Total (Dissolved+Particulate) Organic Carbon');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbon, total solid phase','Total solid phase carbon');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Carbonate','Carbonate ion (CO3-2) concentration');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chloride','Chloride (Cl-)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chloride, total','Total Chloride (Cl-)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chlorine','Chlorine (Cl)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chlorine, dissolved','Dissolved Chlorine (Cl)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chlorophyll (a+b+c)','Chlorophyll (a+b+c)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chlorophyll a','Chlorophyll a');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chlorophyll a allomer','The phytoplankton pigment Chlorophyll a allomer');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chlorophyll a, corrected for pheophytin','Chlorphyll a corrected for pheophytin');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chlorophyll a, uncorrected for pheophytin','Chlorophyll a uncorrected for pheophytin');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chlorophyll b','Chlorophyll b');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chlorophyll c','Chlorophyll c');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chlorophyll c1 and c2','Chlorophyll c1 and c2');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chlorophyll Fluorescence','Chlorophyll Fluorescence');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chromium (III)','Trivalent Chromium');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chromium (VI)','Hexavalent Chromium');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chromium, dissolved','Dissolved Chromium');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Chromium, total','Chromium, all forms');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Cobalt','Cobalt (Co)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Cobalt, dissolved','Dissolved Cobalt (Co)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('COD','Chemical oxygen demand');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Coliform, fecal','Fecal Coliform');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Coliform, total','Total Coliform');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Color','Color in quantified in color units');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Colored Dissolved Organic Matter','The concentration of colored dissolved organic matter (humic substances)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Container number','The identifying number for a water sampler container.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Copper','Copper (Cu)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Copper, dissolved','Dissolved Copper (Cu)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Cryptophytes','The chlorophyll a concentration contributed by cryptophytes');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Cuscuta spp. coverage','Areal coverage of the plant Cuscuta spp.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Density','Density');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Deuterium','Deuterium (2H), Delta D');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Diadinoxanthin','The phytoplankton pigment Diadinoxanthin');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Diatoxanthin','The phytoplankton pigment Diatoxanthin');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Dinoflagellates','The chlorophyll a concentration contributed by Dinoflagellates');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Discharge','Discharge');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Distance','Distance measured from a sensor to a target object such as the surface of a water body or snow surface.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Distichlis spicata Coverage','Areal coverage of the plant Distichlis spicata');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('E-coli','Escherichia coli');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Electric Energy','Electric Energy');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Electric Power','Electric Power');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Electrical conductivity','Electrical conductivity');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Enterococci','Enterococcal bacteria');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Ethane, dissolved','Dissolved Ethane (C2H6)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Evaporation','Evaporation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Evapotranspiration','Evapotranspiration');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Evapotranspiration, potential','The amount of water that could be evaporated and transpired if there was sufficient water available.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Fish detections','The number of fish identified by the detection equipment');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Flash memory error count','A counter which counts the number of  datalogger flash memory errors');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Fluoride','Fluoride - F-');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Fluorine','Fluorine (F-)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Fluorine, dissolved','Dissolved Fluorine (Fl)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Friction velocity','Friction velocity');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Gage height','Water level with regard to an arbitrary gage datum (also see Water depth for comparison)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Global Radiation','Solar radiation, direct and diffuse, received from a solid angle of 2p steradians on a horizontal surface. \nSource: World Meteorological Organization, Meteoterm');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Ground heat flux','Ground heat flux');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Groundwater Depth','Groundwater depth is the distance between the water surface and the ground surface at a specific location specified by the site location and offset.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Hardness, carbonate','Carbonate hardness also known as temporary hardness');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Hardness, non-carbonate','Non-carbonate hardness');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Hardness, total','Total hardness');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Heat index','The combination effect of heat and humidity on the temperature felt by people.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Hydrogen sulfide','Hydrogen sulfide (H2S)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Hydrogen-2, stable isotope ratio delta','Difference in the  2H:1H ratio between the sample and standard');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Imaginary dielectric constant','Soil reponse of a reflected standing electromagnetic wave of a particular frequency which is related to the dissipation (or loss) of energy within the medium. This is the imaginary portion of the complex dielectric constant.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Iron sulfide','Iron sulfide (FeS2)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Iron, dissolved','Dissolved Iron (Fe)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Iron, ferric','Ferric Iron (Fe+3)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Iron, ferrous','Ferrous Iron (Fe+2)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Iva frutescens coverage','Areal coverage of the plant Iva frutescens');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Latent Heat Flux','Latent Heat Flux');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Latitude','Latitude as a variable measurement or observation (Spatial reference to be designated in methods).  This is distinct from the latitude of a site which is a site attribute.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Lead','Lead (Pb)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Leaf wetness','The effect of moisture settling on the surface of a leaf as a result of either condensation or rainfall.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Light attenuation coefficient','Light attenuation coefficient');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Limonium nashii Coverage','Areal coverage of the plant Limonium nashii');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Lithium','Lithium (Li)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Longitude','Longitude as a variable measurement or observation (Spatial reference to be designated in methods). This is distinct from the longitude of a site which is a site attribute.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Low battery count','A counter of the number of times the battery voltage dropped below a minimum threshold');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('LSI','Langelier Saturation Index is an indicator of the degree of saturation of water with respect to calcium carbonate ');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Lycium carolinianum Coverage','Areal coverage of the plant Lycium carolinianum');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Magnesium','Magnesium (Mg)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Magnesium, dissolved','Dissolved Magnesium (Mg)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Manganese','Manganese (Mn)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Manganese, dissolved','Dissolved Manganese (Mn)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Mercury','Mercury (Hg)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Methane, dissolved','Dissolved Methane (CH4)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Methylmercury','Methylmercury (CH3Hg)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Molybdenum','Molybdenum (Mo)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Momentum flux','Momentum flux');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Monanthochloe littoralis Coverage','Areal coverage of the plant Monanthochloe littoralis');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('N, albuminoid','Albuminoid Nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Net heat flux','Outgoing rate of heat energy transfer minus the incoming rate of heat energy transfer through a given area');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nickel','Nickel (Ni)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nickel, dissolved','Dissolved Nickel (Ni)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, Dissolved Inorganic','Dissolved inorganic nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, dissolved Kjeldahl','Dissolved Kjeldahl (organic nitrogen + ammonia (NH3) + ammonium (NH4))nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, dissolved nitrate (NO3)','Dissolved nitrate (NO3) nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, dissolved nitrite (NO2)','Dissolved nitrite (NO2) nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, dissolved nitrite (NO2) + nitrate (NO3)','Dissolved nitrite (NO2) + nitrate (NO3) nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, Dissolved Organic','Dissolved Organic Nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, gas','Gaseous Nitrogen (N2)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, inorganic','Total Inorganic Nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, NH3','Free Ammonia (NH3)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, NH3 + NH4','Total (free+ionized) Ammonia');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, NH4','Ammonium (NH4)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, nitrate (NO3)','Nitrate (NO3) Nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, nitrite (NO2)','Nitrite (NO2) Nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, nitrite (NO2) + nitrate (NO3)','Nitrite (NO2) + Nitrate (NO3) Nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, organic','Organic Nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, organic kjeldahl','Organic Kjeldahl (organic nitrogen + ammonia (NH3) + ammonium (NH4)) nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, particulate organic','Particulate Organic Nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, total','Total Nitrogen (NO3+NO2+NH4+NH3+Organic)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, total dissolved','Total dissolved nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, total kjeldahl','Total Kjeldahl Nitrogen (Ammonia+Organic) ');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen, total organic','Total (dissolved + particulate) organic nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen-15','15 Nitrogen, Delta Nitrogen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Nitrogen-15, stable isotope ratio delta','Difference in the 15N:14N ratio between the sample and standard');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('No vegetation coverage','Areal coverage of no vegetation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Odor','Odor');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Oxygen flux','Oxygen (O2) flux');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Oxygen, dissolved','Dissolved oxygen');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Oxygen, dissolved percent of saturation','Dissolved oxygen, percent saturation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Oxygen, dissolved, transducer signal','Dissolved oxygen, raw data from sensor');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Oxygen-18','18 O, Delta O');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Oxygen-18, stable isotope ratio delta','Difference in the 18O:16O ratio between the sample and standard');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Ozone','Ozone (O3)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Parameter','Parameter related to a hydrologic process.  An example usage would be for a starge-discharge relation parameter.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Peridinin','The phytoplankton pigment Peridinin');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Permittivity','Permittivity is a physical quantity that describes how an electric field affects, and is affected by a dielectric medium, and is determined by the ability of a material to polarize in response to the field, and thereby reduce the total electric field inside the material. Thus, permittivity relates to a material\'s ability to transmit (or \"permit\") an electric field.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Petroleum hydrocarbon, total','Total petroleum hydrocarbon');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('pH','pH is the measure of the acidity or alkalinity of a solution. pH is formally a measure of the activity of dissolved hydrogen ions (H+).  Solutions in which the concentration of H+ exceeds that of OH- have a pH value lower than 7.0 and are known as acids. ');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Pheophytin','Pheophytin (Chlorophyll which has lost the central Mg ion) is a degradation product of Chlorophyll');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, dissolved','Dissolved Phosphorus (P)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, dissolved organic','Dissolved organic phosphorus');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, inorganic ','Inorganic Phosphorus');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, organic','Organic Phosphorus');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, orthophosphate','Orthophosphate Phosphorus');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, orthophosphate dissolved','Dissolved orthophosphate phosphorus');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, particulate','Particulate phosphorus');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, particulate organic','Particulate organic phosphorus in suspension');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, phosphate (PO4)','Phosphate Phosphorus');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, phosphate flux','Phosphate (PO4) flux');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, polyphosphate','Polyphosphate Phosphorus');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, total','Total Phosphorus');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phosphorus, total dissolved','Total dissolved phosphorus');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Phytoplankton','Measurement of phytoplankton with no differentiation between species');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Position','Position of an element that interacts with water such as reservoir gates');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Potassium','Potassium (K)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Potassium, dissolved','Dissolved Potassium (K)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Precipitation','Precipitation such as rainfall. Should not be confused with settling.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Pressure, absolute','Pressure');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Pressure, gauge','Pressure relative to the local atmospheric or ambient pressure');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Primary Productivity','Primary Productivity');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Program signature','A unique data recorder program identifier which is useful for knowing when the source code in the data recorder has been modified.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, incoming longwave','Incoming Longwave Radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, incoming PAR','Incoming Photosynthetically-Active Radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, incoming shortwave','Incoming Shortwave Radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, incoming UV-A','Incoming Ultraviolet A Radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, incoming UV-B','Incoming Ultraviolet B Radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, net','Net Radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, net longwave','Net Longwave Radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, net PAR','Net Photosynthetically-Active Radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, net shortwave','Net Shortwave radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, outgoing longwave','Outgoing Longwave Radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, outgoing PAR','Outgoing Photosynthetically-Active Radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, outgoing shortwave','Outgoing Shortwave Radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, total incoming','Total amount of incoming radiation from all frequencies');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, total outgoing','Total amount of outgoing radiation from all frequencies');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Radiation, total shortwave','Total Shortwave Radiation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Rainfall rate','A measure of the intensity of rainfall, calculated as the depth of water to fall over a given time period if the intensity were to remain constant over that time interval (in/hr, mm/hr, etc)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Real dielectric constant','Soil reponse of a reflected standing electromagnetic wave of a particular frequency which is related to the stored energy within the medium.  This is the real portion of the complex dielectric constant.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Recorder code','A code used to identifier a data recorder.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Reduction potential','Oxidation-reduction potential');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Relative humidity','Relative humidity');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Reservoir storage','Reservoir water volume');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Respiration, net','Net respiration');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Salicornia bigelovii coverage','Areal coverage of the plant Salicornia bigelovii');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Salicornia virginica coverage','Areal coverage of the plant Salicornia virginica');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Salinity','Salinity');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Secchi depth','Secchi depth');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Selenium','Selenium (Se)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sensible Heat Flux','Sensible Heat Flux');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sequence number','A counter of events in a sequence');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Signal-to-noise ratio','Signal-to-noise ratio (often abbreviated SNR or S/N) is defined as the ratio of a signal power to the noise power corrupting the signal. The higher the ratio, the less obtrusive the background noise is.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Silica','Silica (SiO2)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Silicate','Silicate.  Chemical compound containing silicon, oxygen, and one or more metals, e.g., aluminum, barium, beryllium, calcium, iron, magnesium, manganese, potassium, sodium, or zirconium.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Silicic acid','Hydrated silica disolved in water');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Silicic acid flux','Silicate acid (H4SiO4) flux');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Silicon','Silicon (Si)  ');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Silicon, dissolved','Dissolved Silicon (Si)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Snow depth','Snow depth');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Snow Water Equivalent','The depth of water if a snow cover is completely melted, expressed in units of depth, on a corresponding horizontal surface area.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sodium','Sodium (Na)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sodium adsorption ratio','Sodium adsorption ratio');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sodium plus potassium','Sodium plus potassium');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sodium, dissolved','Dissolved Sodium (Na)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sodium, fraction of cations','Sodium, fraction of cations');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Solids, fixed Dissolved','Fixed Dissolved Solids');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Solids, fixed Suspended','Fixed Suspended Solids');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Solids, total','Total Solids');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Solids, total Dissolved','Total Dissolved Solids');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Solids, total Fixed','Total Fixed Solids');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Solids, total Suspended','Total Suspended Solids');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Solids, total Volatile','Total Volatile Solids');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Solids, volatile Dissolved','Volatile Dissolved Solids');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Solids, volatile Suspended','Volatile Suspended Solids');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Spartina alterniflora coverage','Areal coverage of the plant Spartina alterniflora');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Spartina spartinea coverage','Areal coverage of the plant Spartina spartinea');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Specific conductance','Specific conductance');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Streamflow','The volume of water flowing past a fixed point.  Equivalent to discharge');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Streptococci, fecal','Fecal Streptococci');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Strontium','Strontium (Sr)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Strontium, dissolved','Dissolved Strontium (Sr)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Strontium, total','Total Strontium (Sr)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Suaeda linearis coverage','Areal coverage of the plant Suaeda linearis');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Suaeda maritima coverage','Areal coverage of the plant Suaeda maritima');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sulfate','Sulfate (SO4)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sulfate, dissolved','Dissolved Sulfate (SO4)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sulfur','Sulfur (S)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sulfur dioxide','Sulfur dioxide (SO2)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sulfur, organic','Organic Sulfur');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sulfur, pyritic','Pyritic Sulfur');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Sunshine duration','Sunshine duration');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Table overrun error count','A counter which counts the number of datalogger table overrun errors');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('TDR waveform relative length','Time domain reflextometry, apparent length divided by probe length. Square root of dielectric');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Temperature','Temperature');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Temperature, dew point','Dew point temperature');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Temperature, transducer signal','Temperature, raw data from sensor');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Thallium','Thallium (Tl)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('THSW Index','The THSW Index uses temperature, humidity, solar radiation, and wind speed to calculate an apparent temperature.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('THW Index','The THW Index uses temperature, humidity, and wind speed to calculate an apparent temperature.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Tide stage','Tidal stage');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Tin','Tin (Sn)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Titanium','Titanium (Ti)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Transient species coverage','Areal coverage of transient species');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Transpiration','Transpiration');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('TSI','Carlson Trophic State Index is a measurement of eutrophication based on Secchi depth');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Turbidity','Turbidity');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Uranium','Uranium (U)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Urea','Urea ((NH2)2CO)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Urea flux','Urea ((NH2)2CO) flux');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Vanadium','Vanadium (V)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Vapor pressure','The pressure of a vapor in equilibrium with its non-vapor phases');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Vapor pressure deficit','The difference between the actual water vapor pressure and the saturation of water vapor pressure at a particular temperature.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Velocity','The velocity of a substance, fluid or object');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Visibility','Visibility');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Voltage','Voltage or Electrical Potential');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Volume','Volume. To quantify discharge or hydrograph volume or some other volume measurement.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Volumetric water content','Volume of liquid water relative to bulk volume. Used for example to quantify soil moisture');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Watchdog error count','A counter which counts the number of total datalogger watchdog errors');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Water depth','Water depth is the distance between the water surface and the bottom of the water body at a specific location specified by the site location and offset.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Water depth, averaged','Water depth averaged over a channel cross-section or water body.  Averaging method to be specified in methods.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Water flux','Water Flux');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Water level','Water level relative to datum. The datum may be local or global such as NGVD 1929 and should be specified in the method description for associated data values.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Water potential','Water potential is the potential energy of water relative to pure free water (e.g. deionized water) in reference conditions. It quantifies the tendency of water to move from one area to another due to osmosis, gravity, mechanical pressure, or matrix effects including surface tension.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Water vapor density','Water vapor density');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Wave height','The height of a surface wave, measured as the difference in elevation between the wave crest and an adjacent trough.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Weather conditions','Weather conditions');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Well flow rate','Flow rate from well while pumping');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Wellhead pressure','The pressure exerted by the fluid at the wellhead or casinghead after the well has been shut off for a period of time, typically 24 hours');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Wind chill','The effect of wind on the temperature felt on human skin.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Wind direction','Wind direction');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Wind gust direction','Direction of gusts of wind');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Wind gust speed','Speed of gusts of wind');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Wind Run','The length of flow of air past a point over a time interval. Windspeed times the interval of time.');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Wind speed','Wind speed');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Wind stress','Drag or trangential force per unit area exerted on a surface by the adjacent layer of moving air');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Wrack coverage','Areal coverage of dead vegetation');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Zeaxanthin','The phytoplankton pigment Zeaxanthin');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Zinc','Zinc (Zn)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Zinc, dissolved','Dissolved Zinc (Zn)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Zircon, dissolved','Dissolved Zircon (Zr)');
INSERT INTO `variablenamecv` (`Term`,`Definition`) VALUES ('Zooplankton','Zooplanktonic organisms, non-specific');

--
-- Dumping data for table `datatypecv`
--

INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Average','The values represent the average over a time interval, such as daily mean discharge or daily mean temperature.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Best Easy Systematic Estimator','Best Easy Systematic Estimator BES = (Q1 +2Q2 +Q3)/4.  Q1, Q2, and Q3 are first, second, and third quartiles. See Woodcock, F. and Engel, C., 2005: Operational Consensus Forecasts.Weather and Forecasting, 20, 101-111. (http://www.bom.gov.au/nmoc/bulletins/60/article_by_Woodcock_in_Weather_and_Forecasting.pdf) and Wonnacott, T. H., and R. J. Wonnacott, 1972: Introductory Statistics. Wiley, 510 pp.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Categorical','The values are categorical rather than continuous valued quantities. Mapping from Value values to categories is through the CategoryDefinitions table.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Constant Over Interval','The values are quantities that can be interpreted as constant for all time, or over the time interval to a subsequent measurement of the same variable at the same site.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Continuous','A quantity specified at a particular instant in time measured with sufficient frequency (small spacing) to be interpreted as a continuous record of the phenomenon.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Cumulative','The values represent the cumulative value of a variable measured or calculated up to a given instant of time, such as cumulative volume of flow or cumulative precipitation.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Incremental','The values represent the incremental value of a variable over a time interval, such as the incremental volume of flow or incremental precipitation.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Maximum','The values are the maximum values occurring at some time during a time interval, such as annual maximum discharge or a daily maximum air temperature.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Median','The values represent the median over a time interval, such as daily median discharge or daily median temperature.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Minimum','The values are the minimum values occurring at some time during a time interval, such as 7-day low flow for a year or the daily minimum temperature.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Mode','The values are the most frequent values occurring at some time during a time interval, such as annual most frequent wind direction.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Sporadic','The phenomenon is sampled at a particular instant in time but with a frequency that is too coarse for interpreting the record as continuous.  This would be the case when the spacing is significantly larger than the support and the time scale of fluctuation of the phenomenon, such as for example infrequent water quality samples.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('StandardDeviation','The values represent the standard deviation of a set of observations made over a time interval. Standard deviation computed using the unbiased formula SQRT(SUM((Xi-mean)^2)/(n-1)) are preferred. The specific formula used to compute variance can be noted in the methods description.');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Unknown','The data type is unknown');
INSERT INTO `datatypecv` (`Term`,`Definition`) VALUES ('Variance','The values represent the variance of a set of observations made over a time interval.  Variance computed using the unbiased formula SUM((Xi-mean)^2)/(n-1) are preferred.  The specific formula used to compute variance can be noted in the methods description.');
