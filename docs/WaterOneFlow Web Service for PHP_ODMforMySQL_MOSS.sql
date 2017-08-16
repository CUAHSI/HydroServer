-- phpMyAdmin SQL Dump
-- version 3.4.10.2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: May 21, 2012 at 02:17 PM
-- Server version: 5.1.61
-- PHP Version: 5.2.17

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `advenup1_odm`
--

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
CREATE TABLE IF NOT EXISTS `categories` (
  `VariableID` int(11) NOT NULL,
  `DataValue` double NOT NULL,
  `CategoryDescription` text NOT NULL,
  KEY `VariableID` (`VariableID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `censorcodecv`
--

DROP TABLE IF EXISTS `censorcodecv`;
CREATE TABLE IF NOT EXISTS `censorcodecv` (
  `Term` varchar(50) NOT NULL,
  `Definition` text,
  PRIMARY KEY (`Term`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `censorcodecv`
--

INSERT INTO `censorcodecv` (`Term`, `Definition`) VALUES
('gt', 'greater than'),
('lt', 'less than'),
('nc', 'not censored'),
('nd', 'non-detect'),
('pnq', 'present but not quantified');

-- --------------------------------------------------------

--
-- Table structure for table `datatypecv`
--

DROP TABLE IF EXISTS `datatypecv`;
CREATE TABLE IF NOT EXISTS `datatypecv` (
  `Term` varchar(255) NOT NULL,
  `Definition` text,
  PRIMARY KEY (`Term`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `datatypecv`
--

INSERT INTO `datatypecv` (`Term`, `Definition`) VALUES
('Average', 'The values represent the average over a time interval, such as daily mean discharge or daily mean temperature.'),
('Best Easy Systematic Estimator', 'Best Easy Systematic Estimator BES = (Q1 +2Q2 +Q3)/4.  Q1, Q2, and Q3 are first, second, and third quartiles. See Woodcock, F. and Engel, C., 2005: Operational Consensus Forecasts.Weather and Forecasting, 20, 101-111. (http://www.bom.gov.au/nmoc/bulletins/60/article_by_Woodcock_in_Weather_and_Forecasting.pdf) and Wonnacott, T. H., and R. J. Wonnacott, 1972: Introductory Statistics. Wiley, 510 pp.'),
('Categorical', 'The values are categorical rather than continuous valued quantities. Mapping from Value values to categories is through the CategoryDefinitions table.'),
('Constant Over Interval', 'The values are quantities that can be interpreted as constant for all time, or over the time interval to a subsequent measurement of the same variable at the same site.'),
('Continuous', 'A quantity specified at a particular instant in time measured with sufficient frequency (small spacing) to be interpreted as a continuous record of the phenomenon.'),
('Cumulative', 'The values represent the cumulative value of a variable measured or calculated up to a given instant of time, such as cumulative volume of flow or cumulative precipitation.'),
('Incremental', 'The values represent the incremental value of a variable over a time interval, such as the incremental volume of flow or incremental precipitation.'),
('Maximum', 'The values are the maximum values occurring at some time during a time interval, such as annual maximum discharge or a daily maximum air temperature.'),
('Median', 'The values represent the median over a time interval, such as daily median discharge or daily median temperature.'),
('Minimum', 'The values are the minimum values occurring at some time during a time interval, such as 7-day low flow for a year or the daily minimum temperature.'),
('Mode', 'The values are the most frequent values occurring at some time during a time interval, such as annual most frequent wind direction.'),
('Sporadic', 'The phenomenon is sampled at a particular instant in time but with a frequency that is too coarse for interpreting the record as continuous.  This would be the case when the spacing is significantly larger than the support and the time scale of fluctuation of the phenomenon, such as for example infrequent water quality samples.'),
('StandardDeviation', 'The values represent the standard deviation of a set of observations made over a time interval. Standard deviation computed using the unbiased formula SQRT(SUM((Xi-mean)^2)/(n-1)) are preferred. The specific formula used to compute variance can be noted in the methods description.'),
('Unknown', 'The data type is unknown'),
('Variance', 'The values represent the variance of a set of observations made over a time interval.  Variance computed using the unbiased formula SUM((Xi-mean)^2)/(n-1) are preferred.  The specific formula used to compute variance can be noted in the methods description.');

-- --------------------------------------------------------

--
-- Table structure for table `datavalues`
--

DROP TABLE IF EXISTS `datavalues`;
CREATE TABLE IF NOT EXISTS `datavalues` (
  `ValueID` int(11) NOT NULL AUTO_INCREMENT,
  `DataValue` double NOT NULL,
  `ValueAccuracy` double DEFAULT NULL,
  `LocalDateTime` datetime NOT NULL,
  `UTCOffset` double NOT NULL,
  `DateTimeUTC` datetime NOT NULL,
  `SiteID` int(11) NOT NULL,
  `VariableID` int(11) NOT NULL,
  `OffsetValue` double DEFAULT NULL,
  `OffsetTypeID` int(11) DEFAULT NULL,
  `CensorCode` varchar(50) NOT NULL DEFAULT 'nc',
  `QualifierID` int(11) DEFAULT NULL,
  `MethodID` int(11) NOT NULL DEFAULT '0',
  `SourceID` int(11) NOT NULL,
  `SampleID` int(11) DEFAULT NULL,
  `DerivedFromID` int(11) DEFAULT NULL,
  `QualityControlLevelID` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ValueID`),
  UNIQUE KEY `DataValues_UNIQUE_DataValues` (`DataValue`,`ValueAccuracy`,`LocalDateTime`,`UTCOffset`,`DateTimeUTC`,`SiteID`,`VariableID`,`OffsetValue`,`OffsetTypeID`,`CensorCode`,`QualifierID`,`MethodID`,`SourceID`,`SampleID`,`DerivedFromID`,`QualityControlLevelID`),
  KEY `SiteID` (`SiteID`),
  KEY `SourceID` (`SourceID`),
  KEY `QualityControlLevelID` (`QualityControlLevelID`),
  KEY `OffsetTypeID` (`OffsetTypeID`),
  KEY `CensorCode` (`CensorCode`),
  KEY `VariableID` (`VariableID`),
  KEY `MethodID` (`MethodID`),
  KEY `QualifierID` (`QualifierID`),
  KEY `SampleID` (`SampleID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=45 ;

--
-- Dumping data for table `datavalues`
--

INSERT INTO `datavalues` (`ValueID`, `DataValue`, `ValueAccuracy`, `LocalDateTime`, `UTCOffset`, `DateTimeUTC`, `SiteID`, `VariableID`, `OffsetValue`, `OffsetTypeID`, `CensorCode`, `QualifierID`, `MethodID`, `SourceID`, `SampleID`, `DerivedFromID`, `QualityControlLevelID`) VALUES
(44, 0, NULL, '0000-00-00 00:00:00', -7, '0000-00-00 00:00:00', 24, 24, NULL, NULL, 'nc', 1, 4, 6, NULL, 0, 0),
(9, 0.15, NULL, '2011-09-28 12:20:00', -7, '2011-09-28 19:20:00', 24, 8, NULL, NULL, 'nc', 1, 3, 6, NULL, NULL, 0),
(5, 0.3, NULL, '2010-09-15 11:00:00', -7, '2010-09-15 18:00:00', 35, 10, NULL, NULL, 'nc', 1, 4, 6, NULL, NULL, 0),
(4, 6.15, 0.3, '2010-09-15 11:00:00', -7, '2010-09-15 18:00:00', 35, 22, NULL, NULL, 'nc', 1, 7, 6, NULL, NULL, 0),
(3, 6.6, 0.2, '2010-09-15 11:00:00', -7, '2010-09-15 18:00:00', 35, 22, NULL, NULL, 'nc', 1, 4, 6, NULL, NULL, 0),
(2, 9.5, 0.5, '2011-09-22 11:00:00', -7, '2011-09-22 18:00:00', 35, 8, NULL, NULL, 'nc', 1, 3, 6, NULL, NULL, 0),
(6, 9.875, 0.2, '2010-09-15 11:00:00', -7, '2010-09-15 18:00:00', 35, 24, NULL, NULL, 'nc', 1, 4, 6, NULL, NULL, 0),
(7, 9.875, 0.2, '2010-09-22 11:00:00', -7, '2010-09-22 18:00:00', 39, 24, NULL, NULL, 'nc', 1, 4, 6, NULL, NULL, 0),
(1, 11.175, 0.5, '2010-09-15 11:00:00', -7, '2010-09-15 18:00:00', 35, 8, NULL, NULL, 'nc', 1, 3, 6, NULL, NULL, 0),
(8, 12.07, 0.2, '2010-09-22 11:00:00', -7, '2010-09-22 18:00:00', 39, 24, NULL, NULL, 'nc', 1, 4, 6, NULL, NULL, 0),
(13, 16, NULL, '2011-08-16 15:00:00', -7, '2011-08-16 22:00:00', 24, 12, NULL, NULL, 'nc', 1, 4, 6, NULL, NULL, 0),
(10, 16.5, NULL, '2011-09-28 12:20:00', -7, '2011-09-28 19:20:00', 24, 7, NULL, NULL, 'nc', 1, 4, 6, NULL, NULL, 0),
(43, 17.5, NULL, '2012-02-15 10:40:00', -7, '2012-02-15 17:40:00', 24, 7, NULL, NULL, 'nc', 1, 3, 6, NULL, 0, 0),
(11, 58, NULL, '2011-08-16 14:40:00', -7, '2011-08-16 21:40:00', 24, 12, NULL, NULL, 'nc', 1, 4, 6, NULL, NULL, 0),
(12, 58, NULL, '2011-08-16 14:45:00', -7, '2011-08-16 21:45:00', 24, 12, NULL, NULL, 'nc', 1, 4, 6, NULL, NULL, 0),
(17, 343.1, NULL, '2011-09-28 12:20:00', -7, '2011-09-28 19:20:00', 24, 12, NULL, NULL, 'nc', 1, 4, 6, NULL, NULL, 0);

-- --------------------------------------------------------

--
-- Table structure for table `derivedfrom`
--

DROP TABLE IF EXISTS `derivedfrom`;
CREATE TABLE IF NOT EXISTS `derivedfrom` (
  `DerivedFromID` int(11) NOT NULL,
  `ValueID` int(11) NOT NULL,
  KEY `ValueID` (`ValueID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `generalcategorycv`
--

DROP TABLE IF EXISTS `generalcategorycv`;
CREATE TABLE IF NOT EXISTS `generalcategorycv` (
  `Term` varchar(255) NOT NULL,
  `Definition` text,
  PRIMARY KEY (`Term`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `generalcategorycv`
--

INSERT INTO `generalcategorycv` (`Term`, `Definition`) VALUES
('Biota', 'Data associated with biological organisms'),
('Climate', 'Data associated with the climate, weather, or atmospheric processes'),
('Geology', 'Data associated with geology or geological processes'),
('Hydrology', 'Data associated with hydrologic variables or processes'),
('Instrumentation', 'Data associated with instrumentation and instrument properties such as battery voltages, data logger temperatures, often useful for diagnosis.'),
('Unknown', 'The general category is unknown'),
('Water Quality', 'Data associated with water quality variables or processes');

-- --------------------------------------------------------

--
-- Table structure for table `groupdescriptions`
--

DROP TABLE IF EXISTS `groupdescriptions`;
CREATE TABLE IF NOT EXISTS `groupdescriptions` (
  `GroupID` int(11) NOT NULL AUTO_INCREMENT,
  `GroupDescription` text,
  PRIMARY KEY (`GroupID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

DROP TABLE IF EXISTS `groups`;
CREATE TABLE IF NOT EXISTS `groups` (
  `GroupID` int(11) NOT NULL,
  `ValueID` int(11) NOT NULL,
  KEY `GroupID` (`GroupID`),
  KEY `ValueID` (`ValueID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `isometadata`
--

DROP TABLE IF EXISTS `isometadata`;
CREATE TABLE IF NOT EXISTS `isometadata` (
  `MetadataID` int(11) NOT NULL,
  `TopicCategory` varchar(255) NOT NULL DEFAULT 'Unknown',
  `Title` varchar(255) NOT NULL DEFAULT 'Unknown',
  `Abstract` text NOT NULL,
  `ProfileVersion` varchar(255) NOT NULL DEFAULT 'Unknown',
  `MetadataLink` text,
  PRIMARY KEY (`MetadataID`),
  KEY `TopicCategory` (`TopicCategory`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `isometadata`
--

INSERT INTO `isometadata` (`MetadataID`, `TopicCategory`, `Title`, `Abstract`, `ProfileVersion`, `MetadataLink`) VALUES
(0, 'Unknown', 'Unknown', 'Unknown', 'Unknown', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `labmethods`
--

DROP TABLE IF EXISTS `labmethods`;
CREATE TABLE IF NOT EXISTS `labmethods` (
  `LabMethodID` int(11) NOT NULL,
  `LabName` varchar(255) NOT NULL DEFAULT 'Unknown',
  `LabOrganization` varchar(255) NOT NULL DEFAULT 'Unknown',
  `LabMethodName` varchar(255) NOT NULL DEFAULT 'Unknown',
  `LabMethodDescription` text NOT NULL,
  `LabMethodLink` text,
  PRIMARY KEY (`LabMethodID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `labmethods`
--

INSERT INTO `labmethods` (`LabMethodID`, `LabName`, `LabOrganization`, `LabMethodName`, `LabMethodDescription`, `LabMethodLink`) VALUES
(0, 'Unknown', 'Unknown', 'Unknown', 'Unknown', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `methods`
--

DROP TABLE IF EXISTS `methods`;
CREATE TABLE IF NOT EXISTS `methods` (
  `MethodID` int(11) NOT NULL,
  `MethodDescription` text NOT NULL,
  `MethodLink` text,
  PRIMARY KEY (`MethodID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `methods`
--

INSERT INTO `methods` (`MethodID`, `MethodDescription`, `MethodLink`) VALUES
(0, 'No method specified', NULL),
(3, 'YSI DO 200 Meter', 'http://www.ysi.com/productsdetail.php?Pro20-DO-20'),
(4, 'Vernier LabQuest', 'http://www.vernier.com/products/interfaces/labq/'),
(6, 'Turbidity Tube', 'http://www.forestry-suppliers.com/product_pages/view_Catalog_Page.asp?id=5073'),
(7, 'pHydrion ph Strips (1-14)', 'https://www.microessentiallab.com/ProductInfo/F60-WIDRG-000140-VPS.aspx');

-- --------------------------------------------------------

--
-- Table structure for table `moss_users`
--

DROP TABLE IF EXISTS `moss_users`;
CREATE TABLE IF NOT EXISTS `moss_users` (
  `firstname` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `username` varchar(25) NOT NULL,
  `password` varchar(100) NOT NULL,
  `authority` enum('admin','teacher','student') NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `moss_users`
--

INSERT INTO `moss_users` (`firstname`, `lastname`, `username`, `password`, `authority`) VALUES
('Jiri', 'Kadlec', 'jkadlec', '*DE1A522948EED6BFBEC29969FE5C284CEBABCEF2', 'admin'),
('Rex', 'Burch', 'rburch', '*FC7A5AC3234F1BAEE57C0FA662E5BD835B69C82B', 'admin'),
('Jill', 'Burch', 'jburch', '*BB5895458ACA0009C880C7EDE90B73CE9F3FA02D', 'teacher'),
('Tayla', 'Burch', 'tburch', '*CDE134B493035B11B83A9F52ACAC4AE7956EB867', 'student'),
('Dan', 'Ames', 'dames', '*0191E7DE8228D33A7347DBEAFC38B7EDEF9DFF3C', 'admin'),
('Tifani', 'White', 'twhite', '*B5038A738A4EE0E41A92B51968D586EF393A14FF', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `odmversion`
--

DROP TABLE IF EXISTS `odmversion`;
CREATE TABLE IF NOT EXISTS `odmversion` (
  `VersionNumber` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `odmversion`
--

INSERT INTO `odmversion` (`VersionNumber`) VALUES
('1.1.1');

-- --------------------------------------------------------

--
-- Table structure for table `offsettypes`
--

DROP TABLE IF EXISTS `offsettypes`;
CREATE TABLE IF NOT EXISTS `offsettypes` (
  `OffsetTypeID` int(11) NOT NULL AUTO_INCREMENT,
  `OffsetunitsID` int(11) NOT NULL,
  `OffsetDescription` text NOT NULL,
  PRIMARY KEY (`OffsetTypeID`),
  KEY `OffsetunitsID` (`OffsetunitsID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `qualifiers`
--

DROP TABLE IF EXISTS `qualifiers`;
CREATE TABLE IF NOT EXISTS `qualifiers` (
  `QualifierID` int(11) NOT NULL AUTO_INCREMENT,
  `QualifierCode` varchar(50) DEFAULT NULL,
  `QualifierDescription` text NOT NULL,
  PRIMARY KEY (`QualifierID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `qualifiers`
--

INSERT INTO `qualifiers` (`QualifierID`, `QualifierCode`, `QualifierDescription`) VALUES
(1, 'cs', 'Citizen Science');

-- --------------------------------------------------------

--
-- Table structure for table `qualitycontrollevels`
--

DROP TABLE IF EXISTS `qualitycontrollevels`;
CREATE TABLE IF NOT EXISTS `qualitycontrollevels` (
  `QualityControlLevelID` int(11) NOT NULL,
  `QualityControlLevelCode` varchar(50) NOT NULL,
  `Definition` varchar(255) NOT NULL,
  `Explanation` text NOT NULL,
  PRIMARY KEY (`QualityControlLevelID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `qualitycontrollevels`
--

INSERT INTO `qualitycontrollevels` (`QualityControlLevelID`, `QualityControlLevelCode`, `Definition`, `Explanation`) VALUES
(-9999, '-9999', 'Unknown', 'The quality control level is unknown'),
(0, '0', 'Raw data', 'Raw and unprocessed data and data products that have not undergone quality control.  Depending on the variable, data type, and data transmission system, raw data may be available within seconds or minutes after the measurements have been made. Examples include real time precipitation, streamflow and water quality measurements.'),
(1, '1', 'Quality controlled data', 'Quality controlled data that have passed quality assurance procedures such as routine estimation of timing and sensor calibration or visual inspection and removal of obvious errors. An example is USGS published streamflow records following parsing through USGS quality control procedures.'),
(2, '2', 'Derived products', 'Derived products that require scientific and technical interpretation and may include multiple-sensor data. An example is basin average precipitation derived from rain gages using an interpolation procedure.'),
(3, '3', 'Interpreted products', 'Interpreted products that require researcher driven analysis and interpretation, model-based interpretation using other data and/or strong prior assumptions. An example is basin average precipitation derived from the combination of rain gages and radar return data.'),
(4, '4', 'Knowledge products', 'Knowledge products that require researcher driven scientific interpretation and multidisciplinary data integration and include model-based interpretation using other data and/or strong prior assumptions. An example is percentages of old or new water in a hydrograph inferred from an isotope analysis.');

-- --------------------------------------------------------

--
-- Table structure for table `samplemediumcv`
--

DROP TABLE IF EXISTS `samplemediumcv`;
CREATE TABLE IF NOT EXISTS `samplemediumcv` (
  `Term` varchar(255) NOT NULL,
  `Definition` text,
  PRIMARY KEY (`Term`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `samplemediumcv`
--

INSERT INTO `samplemediumcv` (`Term`, `Definition`) VALUES
('Air', 'Sample taken from the atmosphere'),
('Flowback water', 'A mixture of formation water and hydraulic fracturing injectates deriving from oil and gas wells prior to placing wells into production'),
('Groundwater', 'Sample taken from water located below the surface of the ground, such as from a well or spring'),
('Municipal waste water', 'Sample taken from raw municipal waste water stream.'),
('Not Relevant', 'Sample medium not relevant in the context of the measurement'),
('Other', 'Sample medium other than those contained in the CV'),
('Precipitation', 'Sample taken from solid or liquid precipitation'),
('Production water', 'Fluids produced from wells during oil or gas production which may include formation water, injected fluids, oil and gas.'),
('Sediment', 'Sample taken from the sediment beneath the water column'),
('Snow', 'Observation in, of or sample taken from snow'),
('Soil', 'Sample taken from the soil'),
('Soil air', 'Air contained in the soil pores'),
('Soil water', 'the water contained in the soil pores'),
('Surface Water', 'Observation or sample of surface water such as a stream, river, lake, pond, reservoir, ocean, etc.'),
('Tissue', 'Sample taken from the tissue of a biological organism'),
('Unknown', 'The sample medium is unknown');

-- --------------------------------------------------------

--
-- Table structure for table `samples`
--

DROP TABLE IF EXISTS `samples`;
CREATE TABLE IF NOT EXISTS `samples` (
  `SampleID` int(11) NOT NULL AUTO_INCREMENT,
  `SampleType` varchar(255) NOT NULL,
  `LabSampleCode` varchar(50) NOT NULL,
  `LabMethodID` int(11) NOT NULL,
  PRIMARY KEY (`SampleID`),
  KEY `LabMethodID` (`LabMethodID`),
  KEY `SampleType` (`SampleType`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `sampletypecv`
--

DROP TABLE IF EXISTS `sampletypecv`;
CREATE TABLE IF NOT EXISTS `sampletypecv` (
  `Term` varchar(255) NOT NULL DEFAULT 'Unknown',
  `Definition` text,
  PRIMARY KEY (`Term`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sampletypecv`
--

INSERT INTO `sampletypecv` (`Term`, `Definition`) VALUES
('Automated', 'Sample collected using an automated sampler'),
('FD ', ' Foliage Digestion'),
('FF ', ' Forest Floor Digestion'),
('FL ', ' Foliage Leaching'),
('Grab', 'Grab sample'),
('GW ', ' Groundwater'),
('LF ', ' Litter Fall Digestion'),
('meteorological', 'sample type can include a number of measured sample types including temperature, RH, solar radiation, precipitation, wind speed, wind direction.'),
('No Sample', 'There is no lab sample associated with this measurement'),
('PB  ', ' Precipitation Bulk'),
('PD ', ' Petri Dish (Dry Deposition)'),
('PE ', ' Precipitation Event'),
('PI ', ' Precipitation Increment'),
('PW ', ' Precipitation Weekly'),
('RE ', ' Rock Extraction'),
('SE ', ' Stemflow Event'),
('SR ', ' Standard Reference'),
('SS ', 'Streamwater Suspended Sediment'),
('SW ', ' Streamwater'),
('TE ', ' Throughfall Event'),
('TI ', ' Throughfall Increment'),
('TW ', ' Throughfall Weekly'),
('Unknown', 'The sample type is unknown'),
('VE ', ' Vadose Water Event'),
('VI ', ' Vadose Water Increment'),
('VW ', ' Vadose Water Weekly');

-- --------------------------------------------------------

--
-- Table structure for table `seriescatalog`
--

DROP TABLE IF EXISTS `seriescatalog`;
CREATE TABLE IF NOT EXISTS `seriescatalog` (
  `SeriesID` int(11) NOT NULL AUTO_INCREMENT,
  `SiteID` int(11) DEFAULT NULL,
  `SiteCode` varchar(50) DEFAULT NULL,
  `SiteName` varchar(255) DEFAULT NULL,
  `SiteType` varchar(255) DEFAULT NULL,
  `VariableID` int(11) DEFAULT NULL,
  `VariableCode` varchar(50) DEFAULT NULL,
  `VariableName` varchar(255) DEFAULT NULL,
  `Speciation` varchar(255) DEFAULT NULL,
  `VariableunitsID` int(11) DEFAULT NULL,
  `VariableunitsName` varchar(255) DEFAULT NULL,
  `SampleMedium` varchar(255) DEFAULT NULL,
  `ValueType` varchar(255) DEFAULT NULL,
  `TimeSupport` double DEFAULT NULL,
  `TimeunitsID` int(11) DEFAULT NULL,
  `TimeunitsName` varchar(255) DEFAULT NULL,
  `DataType` varchar(255) DEFAULT NULL,
  `GeneralCategory` varchar(255) DEFAULT NULL,
  `MethodID` int(11) DEFAULT NULL,
  `MethodDescription` text,
  `SourceID` int(11) DEFAULT NULL,
  `Organization` varchar(255) DEFAULT NULL,
  `SourceDescription` text,
  `Citation` text,
  `QualityControlLevelID` int(11) DEFAULT NULL,
  `QualityControlLevelCode` varchar(50) DEFAULT NULL,
  `BeginDateTime` datetime DEFAULT NULL,
  `EndDateTime` datetime DEFAULT NULL,
  `BeginDateTimeUTC` datetime DEFAULT NULL,
  `EndDateTimeUTC` datetime DEFAULT NULL,
  `ValueCount` int(11) DEFAULT NULL,
  PRIMARY KEY (`SeriesID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=10 ;

--
-- Dumping data for table `seriescatalog`
--

INSERT INTO `seriescatalog` (`SeriesID`, `SiteID`, `SiteCode`, `SiteName`, `SiteType`, `VariableID`, `VariableCode`, `VariableName`, `Speciation`, `VariableunitsID`, `VariableunitsName`, `SampleMedium`, `ValueType`, `TimeSupport`, `TimeunitsID`, `TimeunitsName`, `DataType`, `GeneralCategory`, `MethodID`, `MethodDescription`, `SourceID`, `Organization`, `SourceDescription`, `Citation`, `QualityControlLevelID`, `QualityControlLevelCode`, `BeginDateTime`, `EndDateTime`, `BeginDateTimeUTC`, `EndDateTimeUTC`, `ValueCount`) VALUES
(1, 24, 'MOSS-PSP-ULM', 'Upper Lily Marsh', 'Wetland', 7, 'IDCS-5', 'Temperature', 'Not Applicable', 96, 'degree celsius', 'Surface Water', 'Field Observation', 0, 100, 'second', 'Sporadic', 'Water Quality', 4, 'Vernier LabQuest', 6, 'McCall Outdoor Science School', 'The mission of the McCall Outdoor Science School is to facilitate place-based, collaborative science inquiry within the context of Idaho''s land, water and communities. We provide experiential learning opportunities among students, educators, scientists and citizens to foster the critical thinking skills necessary to address complex problems.', '', 0, '0', '2011-09-28 12:20:00', '2011-09-28 12:20:00', '2011-09-28 19:20:00', '2011-09-28 19:20:00', 1),
(2, 24, 'MOSS-PSP-ULM', 'Upper Lily Marsh', 'Wetland', 8, 'IDCS-1', 'Oxygen, dissolved', 'Not Applicable', 199, 'milligrams per liter', 'Surface Water', 'Field Observation', 0, 100, 'second', 'Sporadic', 'Water Quality', 3, 'YSI DO 200 Meter', 6, 'McCall Outdoor Science School', 'The mission of the McCall Outdoor Science School is to facilitate place-based, collaborative science inquiry within the context of Idaho''s land, water and communities. We provide experiential learning opportunities among students, educators, scientists and citizens to foster the critical thinking skills necessary to address complex problems.', '', 0, '0', '2011-09-28 12:20:00', '2011-09-28 12:20:00', '2011-09-28 19:20:00', '2011-09-28 19:20:00', 1),
(3, 24, 'MOSS-PSP-ULM', 'Upper Lily Marsh', 'Wetland', 12, 'IDCS-9', 'Electrical conductivity', 'Not Applicable', 192, 'microsiemens per centimeter', 'Surface Water', 'Field Observation', 1, 100, 'second', 'Average', 'Water Quality', 4, 'Vernier LabQuest', 6, 'McCall Outdoor Science School', 'The mission of the McCall Outdoor Science School is to facilitate place-based, collaborative science inquiry within the context of Idaho''s land, water and communities. We provide experiential learning opportunities among students, educators, scientists and citizens to foster the critical thinking skills necessary to address complex problems.', '', 0, '0', '2011-08-16 14:40:00', '2011-09-28 12:20:00', '2011-08-16 21:40:00', '2011-09-28 19:20:00', 4),
(4, 35, 'MOSS-JMR-BC', 'MOSS Boulder Creek at Jug Mountain Ranch', 'Stream', 8, 'IDCS-1', 'Oxygen, dissolved', 'Not Applicable', 199, 'milligrams per liter', 'Surface Water', 'Field Observation', 0, 100, 'second', 'Sporadic', 'Water Quality', 3, 'YSI DO 200 Meter', 6, 'McCall Outdoor Science School', 'The mission of the McCall Outdoor Science School is to facilitate place-based, collaborative science inquiry within the context of Idaho''s land, water and communities. We provide experiential learning opportunities among students, educators, scientists and citizens to foster the critical thinking skills necessary to address complex problems.', '', 0, '0', '2010-09-15 11:00:00', '2011-09-22 11:00:00', '2010-09-15 18:00:00', '2011-09-22 18:00:00', 2),
(5, 35, 'MOSS-JMR-BC', 'MOSS Boulder Creek at Jug Mountain Ranch', 'Stream', 10, 'IDCS-7', 'Nitrogen, nitrate (NO3)', 'NO3', 199, 'milligrams per liter', 'Surface Water', 'Field Observation', 0, 100, 'second', 'Sporadic', 'Water Quality', 4, 'Vernier LabQuest', 6, 'McCall Outdoor Science School', 'The mission of the McCall Outdoor Science School is to facilitate place-based, collaborative science inquiry within the context of Idaho''s land, water and communities. We provide experiential learning opportunities among students, educators, scientists and citizens to foster the critical thinking skills necessary to address complex problems.', '', 0, '0', '2010-09-15 11:00:00', '2010-09-15 11:00:00', '2010-09-15 18:00:00', '2010-09-15 18:00:00', 1),
(6, 35, 'MOSS-JMR-BC', 'MOSS Boulder Creek at Jug Mountain Ranch', 'Stream', 22, 'IDCS-3-Avg', 'pH', 'Not Applicable', 309, 'pH Unit', 'Surface Water', 'Field Observation', 0, 100, 'second', 'Average', 'Unknown', 4, 'Vernier LabQuest', 6, 'McCall Outdoor Science School', 'The mission of the McCall Outdoor Science School is to facilitate place-based, collaborative science inquiry within the context of Idaho''s land, water and communities. We provide experiential learning opportunities among students, educators, scientists and citizens to foster the critical thinking skills necessary to address complex problems.', '', 0, '0', '2010-09-15 11:00:00', '2010-09-15 11:00:00', '2010-09-15 18:00:00', '2010-09-15 18:00:00', 1),
(7, 35, 'MOSS-JMR-BC', 'MOSS Boulder Creek at Jug Mountain Ranch', 'Stream', 22, 'IDCS-3-Avg', 'pH', 'Not Applicable', 309, 'pH Unit', 'Surface Water', 'Field Observation', 0, 100, 'second', 'Average', 'Unknown', 7, 'pHydrion ph Strips (1-14)', 6, 'McCall Outdoor Science School', 'The mission of the McCall Outdoor Science School is to facilitate place-based, collaborative science inquiry within the context of Idaho''s land, water and communities. We provide experiential learning opportunities among students, educators, scientists and citizens to foster the critical thinking skills necessary to address complex problems.', '', 0, '0', '2010-09-15 11:00:00', '2010-09-15 11:00:00', '2010-09-15 18:00:00', '2010-09-15 18:00:00', 1),
(8, 35, 'MOSS-JMR-BC', 'MOSS Boulder Creek at Jug Mountain Ranch', 'Stream', 24, 'IDCS-5-Avg', 'Temperature', 'Not Applicable', 96, 'degree celsius', 'Surface Water', 'Field Observation', 1, 102, 'minute', 'Average', 'Water Quality', 4, 'Vernier LabQuest', 6, 'McCall Outdoor Science School', 'The mission of the McCall Outdoor Science School is to facilitate place-based, collaborative science inquiry within the context of Idaho''s land, water and communities. We provide experiential learning opportunities among students, educators, scientists and citizens to foster the critical thinking skills necessary to address complex problems.', '', 0, '0', '2010-09-15 11:00:00', '2010-09-15 11:00:00', '2010-09-15 18:00:00', '2010-09-15 18:00:00', 1),
(9, 39, 'MOSS-DES-BC', 'MOSS Boulder Creek at Donnelly Elementary', 'Stream', 24, 'IDCS-5-Avg', 'Temperature', 'Not Applicable', 96, 'degree celsius', 'Surface Water', 'Field Observation', 1, 102, 'minute', 'Average', 'Water Quality', 4, 'Vernier LabQuest', 6, 'McCall Outdoor Science School', 'The mission of the McCall Outdoor Science School is to facilitate place-based, collaborative science inquiry within the context of Idaho''s land, water and communities. We provide experiential learning opportunities among students, educators, scientists and citizens to foster the critical thinking skills necessary to address complex problems.', '', 0, '0', '2010-09-22 11:00:00', '2010-09-22 11:00:00', '2010-09-22 18:00:00', '2010-09-22 18:00:00', 2);

-- --------------------------------------------------------

--
-- Table structure for table `sites`
--

DROP TABLE IF EXISTS `sites`;
CREATE TABLE IF NOT EXISTS `sites` (
  `SiteID` int(11) NOT NULL AUTO_INCREMENT,
  `SiteCode` varchar(50) NOT NULL,
  `SiteName` varchar(255) NOT NULL,
  `Latitude` double NOT NULL,
  `Longitude` double NOT NULL,
  `LatLongDatumID` int(11) NOT NULL DEFAULT '0',
  `SiteType` varchar(255) DEFAULT NULL,
  `Elevation_m` double DEFAULT NULL,
  `VerticalDatum` varchar(255) DEFAULT NULL,
  `LocalX` double DEFAULT NULL,
  `LocalY` double DEFAULT NULL,
  `LocalProjectionID` int(11) DEFAULT NULL,
  `PosAccuracy_m` double DEFAULT NULL,
  `State` varchar(255) DEFAULT NULL,
  `County` varchar(255) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`SiteID`),
  UNIQUE KEY `AK_Sites_SiteCode` (`SiteCode`),
  KEY `VerticalDatum` (`VerticalDatum`),
  KEY `LatLongDatumID` (`LatLongDatumID`),
  KEY `LocalProjectionID` (`LocalProjectionID`),
  KEY `SiteType` (`SiteType`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=40 ;

--
-- Dumping data for table `sites`
--

INSERT INTO `sites` (`SiteID`, `SiteCode`, `SiteName`, `Latitude`, `Longitude`, `LatLongDatumID`, `SiteType`, `Elevation_m`, `VerticalDatum`, `LocalX`, `LocalY`, `LocalProjectionID`, `PosAccuracy_m`, `State`, `County`, `Comments`) VALUES
(24, 'MOSS-PSP-ULM', 'Upper Lily Marsh', 44.565721, -116.043787, 63, 'Wetland', NULL, 'MSL', NULL, NULL, NULL, NULL, 'Idaho', 'Valley', NULL),
(26, 'MOSS-PSP-DB', 'Duck Bay', 44.564976, -116.044511, 63, 'Lake, Reservoir, Impoundment', NULL, 'MSL', NULL, NULL, NULL, NULL, 'Idaho', 'Valley', NULL),
(35, 'MOSS-JMR-BC', 'MOSS Boulder Creek at Jug Mountain Ranch', 44.831435, -116.028464, 104, 'Stream', NULL, 'MSL', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(39, 'MOSS-DES-BC', 'MOSS Boulder Creek at Donnelly Elementary', 44.730798, -116.073852, 104, 'Stream', NULL, 'MSL', NULL, NULL, NULL, NULL, 'Idaho', 'Valley', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `sitetypecv`
--

DROP TABLE IF EXISTS `sitetypecv`;
CREATE TABLE IF NOT EXISTS `sitetypecv` (
  `Term` varchar(255) NOT NULL,
  `Definition` text,
  PRIMARY KEY (`Term`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sitetypecv`
--

INSERT INTO `sitetypecv` (`Term`, `Definition`) VALUES
('Aggregate groundwater use', 'An Aggregate Groundwater Withdrawal/Return site represents an aggregate of specific sites whe groundwater is withdrawn or returned which is defined by a geographic area or some other common characteristic. An aggregate groundwatergroundwater site type is used when it is not possible or practical to describe the specific sites as springs or as any type of well including ''multiple wells'', or when water-use information is only available for the aggregate. Aggregate sites that span multiple counties should be coded with 000 as the county code, or an aggregate site can be created for each county.'),
('Aggregate surface-water-use', 'An Aggregate Surface-Water Diversion/Return site represents an aggregate of specific sites where surface water is diverted or returned which is defined by a geographic area or some other common characteristic. An aggregate surface-water site type is used when it is not possible or practical to describe the specific sites as diversions, outfalls, or land application sites, or when water-use information is only available for the aggregate. Aggregate sites that span multiple counties should be coded with 000 as the county code, or an aggregate site can be created for each county.'),
('Aggregate water-use establishment', 'An Aggregate Water-Use Establishment represents an aggregate class of water-using establishments or individuals that are associated with a specific geographic location and water-use category, such as all the industrial users located within a county or all self-supplied domestic users in a county. The aggregate class of water-using establishments is identified using the national water-use category code and optionally classified using the Standard Industrial Classification System Code (SIC code) or North American Classification System Code (NAICS code). An aggregate water-use establishment site type is used when specific information needed to create sites for the individual facilities or users is not available or when it is not desirable to store the site-specific information in the database. Data entry rules that apply to water-use establishments also apply to aggregate water-use establishments. Aggregate sites that span multiple counties should be coded with 000 as the county code, or an aggregate site can be created for each county.'),
('Animal waste lagoon', 'A facility for storage and/or biological treatment of wastes from livestock operations. Animal-waste lagoons are earthen structures ranging from pits to large ponds, and contain manure which has been diluted with building washwater, rainfall, and surface runoff. In treatment lagoons, the waste becomes partially liquefied and stabilized by bacterial action before the waste is disposed of on the land and the water is discharged or re-used.'),
('Atmosphere', 'A site established primarily to measure meteorological properties or atmospheric deposition.'),
('Canal', 'An artificial watercourse designed for navigation, drainage, or irrigation by connecting two or more bodies of water; it is larger than a ditch.'),
('Cave', 'A natural open space within a rock formation large enough to accommodate a human. A cave may have an opening to the outside, is always underground, and sometimes submerged. Caves commonly occur by the dissolution of soluble rocks, generally limestone, but may also be created within the voids of large-rock aggregations, in openings along seismic faults, and in lava formations.'),
('Cistern', 'An artificial, non-pressurized reservoir filled by gravity flow and used for water storage. The reservoir may be located above, at, or below ground level. The water may be supplied from diversion of precipitation, surface, or groundwater sources.'),
('Coastal', 'An oceanic site that is located off-shore beyond the tidal mixing zone (estuary) but close enough to the shore that the investigator considers the presence of the coast to be important. Coastal sites typically are within three nautical miles of the shore.'),
('Collector or Ranney type well', 'An infiltration gallery consisting of one or more underground laterals through which groundwater is collected and a vertical caisson from which groundwater is removed. Also known as a "horizontal well". These wells produce large yield with small drawdown.'),
('Combined sewer', 'An underground conduit created to convey storm drainage and waste products into a wastewater-treatment plant, stream, reservoir, or disposal site.'),
('Ditch', 'An excavation artificially dug in the ground, either lined or unlined, for conveying water for drainage or irrigation; it is smaller than a canal.'),
('Diversion', 'A site where water is withdrawn or diverted from a surface-water body (e.g. the point where the upstream end of a canal intersects a stream, or point where water is withdrawn from a reservoir). Includes sites where water is pumped for use elsewhere.'),
('Estuary', 'A coastal inlet of the sea or ocean; esp. the mouth of a river, where tide water normally mixes with stream water (modified, Webster). Salinity in estuaries typically ranges from 1 to 25 Practical Salinity units (psu), as compared oceanic values around 35-psu. See also: tidal stream and coastal.'),
('Excavation', 'An artificially constructed cavity in the earth that is deeper than the soil (see soil hole), larger than a well bore (see well and test hole), and substantially open to the atmosphere. The diameter of an excavation is typically similar or larger than the depth. Excavations include building-foundation diggings, roadway cuts, and surface mines.'),
('Extensometer well', 'A well equipped to measure small changes in the thickness of the penetrated sediments, such as those caused by groundwater withdrawal or recharge.'),
('Facility', 'A non-ambient location where environmental measurements are expected to be strongly influenced by current or previous activities of humans. *Sites identified with a "facility" primary site type must be further classified with one of the applicable secondary site types.'),
('Field, Pasture, Orchard, or Nursery', 'A water-using facility characterized by an area where plants are grown for transplanting, for use as stocks for budding and grafting, or for sale. Irrigation water may or may not be applied.'),
('Glacier', 'Body of land ice that consists of recrystallized snow accumulated on the surface of the ground and moves slowly downslope (WSP-1541A) over a period of years or centuries. Since glacial sites move, the lat-long precision for these sites is usually coarse.'),
('Golf course', 'A place-of-use, either public or private, where the game of golf is played. A golf course typically uses water for irrigation purposes. Should not be used if the site is a specific hydrologic feature or facility; but can be used especially for the water-use sites.'),
('Groundwater drain', 'An underground pipe or tunnel through which groundwater is artificially diverted to surface water for the purpose of reducing erosion or lowering the water table. A drain is typically open to the atmosphere at the lowest elevation, in contrast to a well which is open at the highest point.'),
('Hydroelectric plant', 'A facility that generates electric power by converting potential energy of water into kinetic energy. Typically, turbine generators are turned by falling water.'),
('Hyporheic-zone well', 'A permanent well, drive point, or other device intended to sample a saturated zone in close proximity to a stream.'),
('Interconnected wells', 'Collector or drainage wells connected by an underground lateral.'),
('Laboratory or sample-preparation area', 'A site where some types of quality-control samples are collected, and where equipment and supplies for environmental sampling are prepared. Equipment blank samples are commonly collected at this site type, as are samples of locally produced deionized water. This site type is typically used when the data are either not associated with a unique environmental data-collection site, or where blank water supplies are designated by Center offices with unique station IDs.'),
('Lake, Reservoir, Impoundment', 'An inland body of standing fresh or saline water that is generally too deep to permit submerged aquatic vegetation to take root across the entire body (cf: wetland). This site type includes an expanded part of a river, a reservoir behind a dam, and a natural or excavated depression containing a water body without surface-water inlet and/or outlet.'),
('Land', 'A location on the surface of the earth that is not normally saturated with water. Land sites are appropriate for sampling vegetation, overland flow of water, or measuring land-surface properties such as temperature. (See also: Wetland).'),
('Landfill', 'A typically dry location on the surface of the land where primarily solid waste products are currently, or previously have been, aggregated and sometimes covered with a veneer of soil. See also: Wastewater disposal and waste-injection well.'),
('Multiple wells', 'A group of wells that are pumped through a single header and for which little or no data about the individual wells are available.'),
('Ocean', 'Site in the open ocean, gulf, or sea. (See also: Coastal, Estuary, and Tidal stream).'),
('Outcrop', 'The part of a rock formation that appears at the surface of the surrounding land.'),
('Outfall', 'A site where water or wastewater is returned to a surface-water body, e.g. the point where wastewater is returned to a stream. Typically, the discharge end of an effluent pipe.'),
('Pavement', 'A surface site where the land surface is covered by a relatively impermeable material, such as concrete or asphalt. Pavement sites are typically part of transportation infrastructure, such as roadways, parking lots, or runways.'),
('Playa', 'A dried-up, vegetation-free, flat-floored area composed of thin, evenly stratified sheets of fine clay, silt or sand, and represents the bottom part of a shallow, completely closed or undrained desert lake basin in which water accumulates and is quickly evaporated, usually leaving deposits of soluble salts.'),
('Septic system', 'A site within or in close proximity to a subsurface sewage disposal system that generally consists of: (1) a septic tank where settling of solid material occurs, (2) a distribution system that transfers fluid from the tank to (3) a leaching system that disperses the effluent into the ground.'),
('Shore', 'The land along the edge of the sea, a lake, or a wide river where the investigator considers the proximity of the water body to be important. Land adjacent to a reservoir, lake, impoundment, or oceanic site type is considered part of the shore when it includes a beach or bank between the high and low water marks.'),
('Sinkhole', 'A crater formed when the roof of a cavern collapses; usually found in limestone areas. Surface water and precipitation that enters a sinkhole usually evaporates or infiltrates into the ground, rather than draining into a stream.'),
('Soil hole', 'A small excavation into soil at the top few meters of earth surface. Soil generally includes some organic matter derived from plants. Soil holes are created to measure soil composition and properties. Sometimes electronic probes are inserted into soil holes to measure physical properties, and (or) the extracted soil is analyzed.'),
('Spring', 'A location at which the water table intersects the land surface, resulting in a natural flow of groundwater to the surface. Springs may be perennial, intermittent, or ephemeral.'),
('Storm sewer', 'An underground conduit created to convey storm drainage into a stream channel or reservoir. If the sewer also conveys liquid waste products, then the "combined sewer" secondary site type should be used.'),
('Stream', 'A body of running water moving under gravity flow in a defined channel. The channel may be entirely natural, or altered by engineering practices through straightening, dredging, and (or) lining. An entirely artificial channel should be qualified with the "canal" or "ditch" secondary site type.'),
('Subsurface', 'A location below the land surface, but not a well, soil hole, or excavation.'),
('Test hole not completed as a well', 'An uncased hole (or one cased only temporarily) that was drilled for water, or for geologic or hydrogeologic testing. It may be equipped temporarily with a pump in order to make a pumping test, but if the hole is destroyed after testing is completed, it is still a test hole. A core hole drilled as a part of mining or quarrying exploration work should be in this class.'),
('Thermoelectric plant', 'A facility that uses water in the generation of electricity from heat. Typically turbine generators are driven by steam. The heat may be caused by various means, including combustion, nuclear reactions, and geothermal processes.'),
('Tidal stream', 'A stream reach where the flow is influenced by the tide, but where the water chemistry is not normally influenced. A site where ocean water typically mixes with stream water should be coded as an estuary.'),
('Tunnel, shaft, or mine', 'A constructed subsurface open space large enough to accommodate a human that is not substantially open to the atmosphere and is not a well. The excavation may have been for minerals, transportation, or other purposes. See also: Excavation.'),
('Unsaturated zone', 'A site equipped to measure conditions in the subsurface deeper than a soil hole, but above the water table or other zone of saturation.'),
('Volcanic vent', 'Vent from which volcanic gases escape to the atmosphere. Also known as fumarole.'),
('Waste injection well', 'A facility used to convey industrial waste, domestic sewage, brine, mine drainage, radioactive waste, or other fluid into an underground zone. An oil-test or deep-water well converted to waste disposal should be in this category. A well where fresh water is injected to artificially recharge thegroundwaterr supply or to pressurize an oil or gas production zone by injecting a fluid should be classified as a well (not an injection-well facility), with additional information recorded under Use of Site.'),
('Wastewater land application', 'A site where the disposal of waste water on land occurs. Use "waste-injection well" for underground waste-disposal sites.'),
('Wastewater sewer', 'An underground conduit created to convey liquid and semisolid domestic, commercial, or industrial waste into a treatment plant, stream, reservoir, or disposal site. If the sewer also conveys storm water, then the "combined sewer" secondary site type should be used.'),
('Wastewater-treatment plant', 'A facility where wastewater is treated to reduce concentrations of dissolved and (or) suspended materials prior to discharge or reuse.'),
('Water-distribution system', 'A site located somewhere on a networked infrastructure that distributes treated or untreated water to multiple domestic, industrial, institutional, and (or) commercial users. May be owned by a municipality or community, a water district, or a private concern.'),
('Water-supply treatment plant', 'A facility where water is treated prior to use for consumption or other purpose.'),
('Water-use establishment', 'A place-of-use (a water using facility that is associated with a specific geographical point location, such as a business or industrial user) that cannot be specified with any other facility secondary type. Water-use place-of-use sites are establishments such as a factory, mill, store, warehouse, farm, ranch, or bank. A place-of-use site is further classified using the national water-use category code (C39) and optionally classified using the Standard Industrial Classification System Code (SIC code) or North American Classification System Code (NAICS code). See also: Aggregate water-use-establishment.'),
('Well', 'A hole or shaft constructed in the earth intended to be used to locate, sample, or develop groundwater, oil, gas, or some other subsurface material. The diameter of a well is typically much smaller than the depth. Wells are also used to artificially recharge groundwater or to pressurize oil and gas production zones. Additional information about specific kinds of wells should be recorded under the secondary site types or the Use of Site field. Underground waste-disposal wells should be classified as waste-injection wells.'),
('Wetland', 'Land where saturation with water is the dominant factor determining the nature of soil development and the types of plant and animal communities living in the soil and on its surface (Cowardin, December 1979). Wetlands are found from the tundra to the tropics and on every continent except Antarctica. Wetlands are areas that are inundated or saturated by surface or groundwater at a frequency and duration sufficient to support, and that under normal circumstances do support, a prevalence of vegetation typically adapted for life in saturated soil conditions. Wetlands generally include swamps, marshes, bogs and similar areas. Wetlands may be forested or unforested, and naturally or artificially created.');

-- --------------------------------------------------------

--
-- Table structure for table `sources`
--

DROP TABLE IF EXISTS `sources`;
CREATE TABLE IF NOT EXISTS `sources` (
  `SourceID` int(11) NOT NULL AUTO_INCREMENT,
  `Organization` varchar(255) NOT NULL,
  `SourceDescription` text NOT NULL,
  `SourceLink` text,
  `ContactName` varchar(255) NOT NULL DEFAULT 'Unknown',
  `Phone` varchar(255) NOT NULL DEFAULT 'Unknown',
  `Email` varchar(255) NOT NULL DEFAULT 'Unknown',
  `Address` varchar(255) NOT NULL DEFAULT 'Unknown',
  `City` varchar(255) NOT NULL DEFAULT 'Unknown',
  `State` varchar(255) NOT NULL DEFAULT 'Unknown',
  `ZipCode` varchar(255) NOT NULL DEFAULT 'Unknown',
  `Citation` text NOT NULL,
  `MetadataID` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`SourceID`),
  KEY `MetadataID` (`MetadataID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `sources`
--

INSERT INTO `sources` (`SourceID`, `Organization`, `SourceDescription`, `SourceLink`, `ContactName`, `Phone`, `Email`, `Address`, `City`, `State`, `ZipCode`, `Citation`, `MetadataID`) VALUES
(6, 'McCall Outdoor Science School', 'The mission of the McCall Outdoor Science School is to facilitate place-based, collaborative science inquiry within the context of Idaho''s land, water and communities. We provide experiential learning opportunities among students, educators, scientists and citizens to foster the critical thinking skills necessary to address complex problems.', 'http://www.mossidaho.org', 'Dr. Karla Eitel', '888-634-3918', 'info@mossidaho.org', '1800 University Lane', 'McCall', 'Idaho', '83638', '', 0);

-- --------------------------------------------------------

--
-- Table structure for table `spatialreferences`
--

DROP TABLE IF EXISTS `spatialreferences`;
CREATE TABLE IF NOT EXISTS `spatialreferences` (
  `SpatialReferenceID` int(11) NOT NULL,
  `SRSID` int(11) DEFAULT NULL,
  `SRSName` varchar(255) NOT NULL,
  `IsGeographic` tinyint(1) DEFAULT NULL,
  `Notes` text,
  PRIMARY KEY (`SpatialReferenceID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `spatialreferences`
--

INSERT INTO `spatialreferences` (`SpatialReferenceID`, `SRSID`, `SRSName`, `IsGeographic`, `Notes`) VALUES
(0, NULL, 'Unknown', 0, 'The spatial reference system is unknown'),
(1, 4267, 'NAD27', 1, NULL),
(2, 4269, 'NAD83', 1, NULL),
(3, 4326, 'WGS84', 1, NULL),
(4, 26703, 'NAD27 / UTM zone 3N', 0, NULL),
(5, 26704, 'NAD27 / UTM zone 4N', 0, NULL),
(6, 26705, 'NAD27 / UTM zone 5N', 0, NULL),
(7, 26706, 'NAD27 / UTM zone 6N', 0, NULL),
(8, 26707, 'NAD27 / UTM zone 7N', 0, NULL),
(9, 26708, 'NAD27 / UTM zone 8N', 0, NULL),
(10, 26709, 'NAD27 / UTM zone 9N', 0, NULL),
(11, 26710, 'NAD27 / UTM zone 10N', 0, NULL),
(12, 26711, 'NAD27 / UTM zone 11N', 0, NULL),
(13, 26712, 'NAD27 / UTM zone 12N', 0, NULL),
(14, 26713, 'NAD27 / UTM zone 13N', 0, NULL),
(15, 26714, 'NAD27 / UTM zone 14N', 0, NULL),
(16, 26715, 'NAD27 / UTM zone 15N', 0, NULL),
(17, 26716, 'NAD27 / UTM zone 16N', 0, NULL),
(18, 26717, 'NAD27 / UTM zone 17N', 0, NULL),
(19, 26718, 'NAD27 / UTM zone 18N', 0, NULL),
(20, 26719, 'NAD27 / UTM zone 19N', 0, NULL),
(21, 26720, 'NAD27 / UTM zone 20N', 0, NULL),
(22, 26721, 'NAD27 / UTM zone 21N', 0, NULL),
(23, 26722, 'NAD27 / UTM zone 22N', 0, NULL),
(24, 26729, 'NAD27 / Alabama East', 0, NULL),
(25, 26730, 'NAD27 / Alabama West', 0, NULL),
(26, 26732, 'NAD27 / Alaska zone 2', 0, NULL),
(27, 26733, 'NAD27 / Alaska zone 3', 0, NULL),
(28, 26734, 'NAD27 / Alaska zone 4', 0, NULL),
(29, 26735, 'NAD27 / Alaska zone 5', 0, NULL),
(30, 26736, 'NAD27 / Alaska zone 6', 0, NULL),
(31, 26737, 'NAD27 / Alaska zone 7', 0, NULL),
(32, 26738, 'NAD27 / Alaska zone 8', 0, NULL),
(33, 26739, 'NAD27 / Alaska zone 9', 0, NULL),
(34, 26740, 'NAD27 / Alaska zone 10', 0, NULL),
(35, 26741, 'NAD27 / California zone I', 0, NULL),
(36, 26742, 'NAD27 / California zone II', 0, NULL),
(37, 26743, 'NAD27 / California zone III', 0, NULL),
(38, 26744, 'NAD27 / California zone IV', 0, NULL),
(39, 26745, 'NAD27 / California zone V', 0, NULL),
(40, 26746, 'NAD27 / California zone VI', 0, NULL),
(41, 26747, 'NAD27 / California zone VII', 0, NULL),
(42, 26748, 'NAD27 / Arizona East', 0, NULL),
(43, 26749, 'NAD27 / Arizona Central', 0, NULL),
(44, 26750, 'NAD27 / Arizona West', 0, NULL),
(45, 26751, 'NAD27 / Arkansas North', 0, NULL),
(46, 26752, 'NAD27 / Arkansas South', 0, NULL),
(47, 26753, 'NAD27 / Colorado North', 0, NULL),
(48, 26754, 'NAD27 / Colorado Central', 0, NULL),
(49, 26755, 'NAD27 / Colorado South', 0, NULL),
(50, 26756, 'NAD27 / Connecticut', 0, NULL),
(51, 26757, 'NAD27 / Delaware', 0, NULL),
(52, 26758, 'NAD27 / Florida East', 0, NULL),
(53, 26759, 'NAD27 / Florida West', 0, NULL),
(54, 26760, 'NAD27 / Florida North', 0, NULL),
(55, 26761, 'NAD27 / Hawaii zone 1', 0, NULL),
(56, 26762, 'NAD27 / Hawaii zone 2', 0, NULL),
(57, 26763, 'NAD27 / Hawaii zone 3', 0, NULL),
(58, 26764, 'NAD27 / Hawaii zone 4', 0, NULL),
(59, 26765, 'NAD27 / Hawaii zone 5', 0, NULL),
(60, 26766, 'NAD27 / Georgia East', 0, NULL),
(61, 26767, 'NAD27 / Georgia West', 0, NULL),
(62, 26768, 'NAD27 / Idaho East', 0, NULL),
(63, 26769, 'NAD27 / Idaho Central', 0, NULL),
(64, 26770, 'NAD27 / Idaho West', 0, NULL),
(65, 26771, 'NAD27 / Illinois East', 0, NULL),
(66, 26772, 'NAD27 / Illinois West', 0, NULL),
(67, 26773, 'NAD27 / Indiana East', 0, NULL),
(68, 26774, 'NAD27 / Indiana West', 0, NULL),
(69, 26775, 'NAD27 / Iowa North', 0, NULL),
(70, 26776, 'NAD27 / Iowa South', 0, NULL),
(71, 26777, 'NAD27 / Kansas North', 0, NULL),
(72, 26778, 'NAD27 / Kansas South', 0, NULL),
(73, 26779, 'NAD27 / Kentucky North', 0, NULL),
(74, 26780, 'NAD27 / Kentucky South', 0, NULL),
(75, 26781, 'NAD27 / Louisiana North', 0, NULL),
(76, 26782, 'NAD27 / Louisiana South', 0, NULL),
(77, 26783, 'NAD27 / Maine East', 0, NULL),
(78, 26784, 'NAD27 / Maine West', 0, NULL),
(79, 26785, 'NAD27 / Maryland', 0, NULL),
(80, 26786, 'NAD27 / Massachusetts Mainland', 0, NULL),
(81, 26787, 'NAD27 / Massachusetts Island', 0, NULL),
(82, 26791, 'NAD27 / Minnesota North', 0, NULL),
(83, 26792, 'NAD27 / Minnesota Central', 0, NULL),
(84, 26793, 'NAD27 / Minnesota South', 0, NULL),
(85, 26794, 'NAD27 / Mississippi East', 0, NULL),
(86, 26795, 'NAD27 / Mississippi West', 0, NULL),
(87, 26796, 'NAD27 / Missouri East', 0, NULL),
(88, 26797, 'NAD27 / Missouri Central', 0, NULL),
(89, 26798, 'NAD27 / Missouri West', 0, NULL),
(90, 26801, 'NAD Michigan / Michigan East', 0, NULL),
(91, 26802, 'NAD Michigan / Michigan Old Central', 0, NULL),
(92, 26803, 'NAD Michigan / Michigan West', 0, NULL),
(93, 26811, 'NAD Michigan / Michigan North', 0, NULL),
(94, 26812, 'NAD Michigan / Michigan Central', 0, NULL),
(95, 26813, 'NAD Michigan / Michigan South', 0, NULL),
(96, 26903, 'NAD83 / UTM zone 3N', 0, NULL),
(97, 26904, 'NAD83 / UTM zone 4N', 0, NULL),
(98, 26905, 'NAD83 / UTM zone 5N', 0, NULL),
(99, 26906, 'NAD83 / UTM zone 6N', 0, NULL),
(100, 26907, 'NAD83 / UTM zone 7N', 0, NULL),
(101, 26908, 'NAD83 / UTM zone 8N', 0, NULL),
(102, 26909, 'NAD83 / UTM zone 9N', 0, NULL),
(103, 26910, 'NAD83 / UTM zone 10N', 0, NULL),
(104, 26911, 'NAD83 / UTM zone 11N', 0, NULL),
(105, 26912, 'NAD83 / UTM zone 12N', 0, NULL),
(106, 26913, 'NAD83 / UTM zone 13N', 0, NULL),
(107, 26914, 'NAD83 / UTM zone 14N', 0, NULL),
(108, 26915, 'NAD83 / UTM zone 15N', 0, NULL),
(109, 26916, 'NAD83 / UTM zone 16N', 0, NULL),
(110, 26917, 'NAD83 / UTM zone 17N', 0, NULL),
(111, 26918, 'NAD83 / UTM zone 18N', 0, NULL),
(112, 26919, 'NAD83 / UTM zone 19N', 0, NULL),
(113, 26920, 'NAD83 / UTM zone 20N', 0, NULL),
(114, 26921, 'NAD83 / UTM zone 21N', 0, NULL),
(115, 26922, 'NAD83 / UTM zone 22N', 0, NULL),
(116, 26923, 'NAD83 / UTM zone 23N', 0, NULL),
(117, 26929, 'NAD83 / Alabama East', 0, NULL),
(118, 26930, 'NAD83 / Alabama West', 0, NULL),
(119, 26932, 'NAD83 / Alaska zone 2', 0, NULL),
(120, 26933, 'NAD83 / Alaska zone 3', 0, NULL),
(121, 26934, 'NAD83 / Alaska zone 4', 0, NULL),
(122, 26935, 'NAD83 / Alaska zone 5', 0, NULL),
(123, 26936, 'NAD83 / Alaska zone 6', 0, NULL),
(124, 26937, 'NAD83 / Alaska zone 7', 0, NULL),
(125, 26938, 'NAD83 / Alaska zone 8', 0, NULL),
(126, 26939, 'NAD83 / Alaska zone 9', 0, NULL),
(127, 26940, 'NAD83 / Alaska zone 10', 0, NULL),
(128, 26941, 'NAD83 / California zone 1', 0, NULL),
(129, 26942, 'NAD83 / California zone 2', 0, NULL),
(130, 26943, 'NAD83 / California zone 3', 0, NULL),
(131, 26944, 'NAD83 / California zone 4', 0, NULL),
(132, 26945, 'NAD83 / California zone 5', 0, NULL),
(133, 26946, 'NAD83 / California zone 6', 0, NULL),
(134, 26948, 'NAD83 / Arizona East', 0, NULL),
(135, 26949, 'NAD83 / Arizona Central', 0, NULL),
(136, 26950, 'NAD83 / Arizona West', 0, NULL),
(137, 26951, 'NAD83 / Arkansas North', 0, NULL),
(138, 26952, 'NAD83 / Arkansas South', 0, NULL),
(139, 26953, 'NAD83 / Colorado North', 0, NULL),
(140, 26954, 'NAD83 / Colorado Central', 0, NULL),
(141, 26955, 'NAD83 / Colorado South', 0, NULL),
(142, 26956, 'NAD83 / Connecticut', 0, NULL),
(143, 26957, 'NAD83 / Delaware', 0, NULL),
(144, 26958, 'NAD83 / Florida East', 0, NULL),
(145, 26959, 'NAD83 / Florida West', 0, NULL),
(146, 26960, 'NAD83 / Florida North', 0, NULL),
(147, 26961, 'NAD83 / Hawaii zone 1', 0, NULL),
(148, 26962, 'NAD83 / Hawaii zone 2', 0, NULL),
(149, 26963, 'NAD83 / Hawaii zone 3', 0, NULL),
(150, 26964, 'NAD83 / Hawaii zone 4', 0, NULL),
(151, 26965, 'NAD83 / Hawaii zone 5', 0, NULL),
(152, 26966, 'NAD83 / Georgia East', 0, NULL),
(153, 26967, 'NAD83 / Georgia West', 0, NULL),
(154, 26968, 'NAD83 / Idaho East', 0, NULL),
(155, 26969, 'NAD83 / Idaho Central', 0, NULL),
(156, 26970, 'NAD83 / Idaho West', 0, NULL),
(157, 26971, 'NAD83 / Illinois East', 0, NULL),
(158, 26972, 'NAD83 / Illinois West', 0, NULL),
(159, 26973, 'NAD83 / Indiana East', 0, NULL),
(160, 26974, 'NAD83 / Indiana West', 0, NULL),
(161, 26975, 'NAD83 / Iowa North', 0, NULL),
(162, 26976, 'NAD83 / Iowa South', 0, NULL),
(163, 26977, 'NAD83 / Kansas North', 0, NULL),
(164, 26978, 'NAD83 / Kansas South', 0, NULL),
(165, 26979, 'NAD83 / Kentucky North', 0, NULL),
(166, 26980, 'NAD83 / Kentucky South', 0, NULL),
(167, 26981, 'NAD83 / Louisiana North', 0, NULL),
(168, 26982, 'NAD83 / Louisiana South', 0, NULL),
(169, 26983, 'NAD83 / Maine East', 0, NULL),
(170, 26984, 'NAD83 / Maine West', 0, NULL),
(171, 26985, 'NAD83 / Maryland', 0, NULL),
(172, 26986, 'NAD83 / Massachusetts Mainland', 0, NULL),
(173, 26987, 'NAD83 / Massachusetts Island', 0, NULL),
(174, 26988, 'NAD83 / Michigan North', 0, NULL),
(175, 26989, 'NAD83 / Michigan Central', 0, NULL),
(176, 26990, 'NAD83 / Michigan South', 0, NULL),
(177, 26991, 'NAD83 / Minnesota North', 0, NULL),
(178, 26992, 'NAD83 / Minnesota Central', 0, NULL),
(179, 26993, 'NAD83 / Minnesota South', 0, NULL),
(180, 26994, 'NAD83 / Mississippi East', 0, NULL),
(181, 26995, 'NAD83 / Mississippi West', 0, NULL),
(182, 26996, 'NAD83 / Missouri East', 0, NULL),
(183, 26997, 'NAD83 / Missouri Central', 0, NULL),
(184, 26998, 'NAD83 / Missouri West  ', 0, NULL),
(185, 4176, 'Australian Antarctic', 1, 'Datum Name: Australian Antarctic Datum 1998    Area of Use: Antarctica - Australian sector.    Datum Origin: No Data Available    Coord System: ellipsoidal    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(186, 4203, 'AGD84', 1, 'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - Queensland (Qld), South Australia (SA), Western Australia (WA).    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: ellipsoidal    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG'),
(187, 4283, 'GDA94', 1, 'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - Australian Capital Territory (ACT); New South Wales (NSW); Northern Territory (NT); Queensland (Qld); South Australia (SA); Tasmania (Tas); Western Australia (WA); Victoria (Vic).    Datum Origin: ITRF92 at epoch 1994.0    Coord System: ellipsoidal    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(188, 5711, 'Australian Height Datum', 0, 'Datum Name: Australian Height Datum    Area of Use: Australia - Australian Capital Territory (ACT); New South Wales (NSW); Northern Territory (NT); Queensland; South Australia (SA); Western Australia (WA); Victoria.    Datum Origin: MSL 1966-68 at 30 gauges around coast.    Coord System: vertical    Ellipsoid Name: No Data Available    Data Source: EPSG'),
(189, 5712, 'Australian Height Datum (Tasmania)', 0, 'Datum Name: Australian Height Datum (Tasmania)    Area of Use: Australia - Tasmania (Tas).    Datum Origin: MSL 1972 at Hobart and Burnie.    Coord System: vertical    Ellipsoid Name: No Data Available    Data Source: EPSG'),
(190, 5714, 'Mean Sea Level Height', 0, 'Datum Name: Mean Sea Level    Area of Use: World.    Datum Origin: No Data Available    Coord System: vertical    Ellipsoid Name: No Data Available    Data Source: EPSG'),
(191, 5715, 'Mean Sea Level Depth', 0, 'Datum Name: Mean Sea Level    Area of Use: World.    Datum Origin: No Data Available    Coord System: vertical    Ellipsoid Name: No Data Available    Data Source: EPSG'),
(192, 20348, 'AGD84 / AMG zone 48', 0, 'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 102 and 108 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG'),
(193, 20349, 'AGD84 / AMG zone 49', 0, 'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 108 and 114 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG'),
(194, 20350, 'AGD84 / AMG zone 50', 0, 'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 114 and 120 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG'),
(195, 20351, 'AGD84 / AMG zone 51', 0, 'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 120 and 126 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG'),
(196, 20352, 'AGD84 / AMG zone 52', 0, 'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 126 and 132 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG'),
(197, 20353, 'AGD84 / AMG zone 53', 0, 'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 132 and 138 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG'),
(198, 20354, 'AGD84 / AMG zone 54', 0, 'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 138 and 144 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG'),
(199, 20355, 'AGD84 / AMG zone 55', 0, 'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 144 and 150 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG'),
(200, 20356, 'AGD84 / AMG zone 56', 0, 'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 150 and 156 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG'),
(201, 20357, 'AGD84 / AMG zone 57', 0, 'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 156 and 162 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG'),
(202, 20358, 'AGD84 / AMG zone 58', 0, 'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 162 and 168 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG'),
(203, 28348, 'GDA94 / MGA zone 48', 0, 'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 102 and 108 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(204, 28349, 'GDA94 / MGA zone 49', 0, 'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 108 and 114 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(205, 28350, 'GDA94 / MGA zone 50', 0, 'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 114 and 120 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(206, 28351, 'GDA94 / MGA zone 51', 0, 'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 120 and 126 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(207, 28352, 'GDA94 / MGA zone 52', 0, 'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 126 and 132 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(208, 28353, 'GDA94 / MGA zone 53', 0, 'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 132 and 138 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(209, 28354, 'GDA94 / MGA zone 54', 0, 'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 138 and 144 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(210, 28355, 'GDA94 / MGA zone 55', 0, 'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 144 and 150 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(211, 28356, 'GDA94 / MGA zone 56', 0, 'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 150 and 156 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(212, 28357, 'GDA94 / MGA zone 57', 0, 'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 156 and 162 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(213, 28358, 'GDA94 / MGA zone 58', 0, 'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 162 and 168 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG'),
(214, 32748, 'WGS 84 / UTM zone 48S', 0, 'Datum Name: World Geodetic System 1984    Area of Use: Between 102 and 108 deg East; southern hemisphere. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG'),
(215, 32749, 'WGS 84 / UTM zone 49S', 0, 'Datum Name: World Geodetic System 1984    Area of Use: Between 108 and 114 deg East; southern hemisphere. Australia. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG'),
(216, 32750, 'WGS 84 / UTM zone 50S', 0, 'Datum Name: World Geodetic System 1984    Area of Use: Between 114 and 120 deg East; southern hemisphere. Australia. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG'),
(217, 32751, 'WGS 84 / UTM zone 51S', 0, 'Datum Name: World Geodetic System 1984    Area of Use: Between 120 and 126 deg East; southern hemisphere. Australia. East Timor. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG'),
(218, 32752, 'WGS 84 / UTM zone 52S', 0, 'Datum Name: World Geodetic System 1984    Area of Use: Between 126 and 132 deg East; southern hemisphere. Australia. East Timor. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG'),
(219, 32753, 'WGS 84 / UTM zone 53S', 0, 'Datum Name: World Geodetic System 1984    Area of Use: Between 132 and 138 deg East; southern hemisphere. Australia.  Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG'),
(220, 32754, 'WGS 84 / UTM zone 54S', 0, 'Datum Name: World Geodetic System 1984    Area of Use: Between 138 and 144 deg East; southern hemisphere. Australia. Indonesia. Papua New Guinea.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG'),
(221, 32755, 'WGS 84 / UTM zone 55S', 0, 'Datum Name: World Geodetic System 1984    Area of Use: Between 144 and 150 deg East; southern hemisphere. Australia. Papua New Guinea.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG'),
(222, 32756, 'WGS 84 / UTM zone 56S', 0, 'Datum Name: World Geodetic System 1984    Area of Use: Between 150 and 156 deg East; southern hemisphere. Australia. Papua New Guinea.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG'),
(223, 32757, 'WGS 84 / UTM zone 57S', 0, 'Datum Name: World Geodetic System 1984    Area of Use: Between 156 and 162 deg East; southern hemisphere.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG'),
(224, 32758, 'WGS 84 / UTM zone 58S', 0, 'Datum Name: World Geodetic System 1984    Area of Use: Between 162 and 168 deg East; southern hemisphere.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG'),
(225, 3308, 'GDA94 / NSW Lambert', 0, 'Datum Name: Geocentric Datum of Australia 1994 Area of Use: Australia - New South Wales (NSW). Datum Origin: ITRF92 at epoch 1994.0  Ellipsoid Name: GRS 1980 Data Source: EPSG'),
(226, 2914, 'NAD_1983_HARN_StatePlane_Oregon_South_FIPS_3602_Feet_Intl', 0, 'I wonder if we can''t just load the entire list at:\nhttp://www.arcwebservices.com/v2006/help/index_Left.htm#StartTopic=support/pcs_name.htm#|SkinName=ArcWeb \ninto the CV??'),
(227, 2276, 'NAD83 / Texas North Central (ftUS)', 0, 'ESRI Name: NAD_1983_StatePlane_Texas_North_Central_FIPS_4202_Feet\nArea of Use: United States (USA) - Texas - counties of: Andrews; Archer; Bailey; Baylor; Borden; Bowie; Callahan; Camp; Cass; Clay; Cochran; Collin; Cooke; Cottle; Crosby; Dallas; Dawson; Delta; Denton; Dickens; Eastland; Ellis; Erath; Fannin; Fisher; Floyd; Foard; Franklin; Gaines; Garza; Grayson; Gregg; Hale; Hardeman; Harrison; Haskell; Henderson; Hill; Hockley; Hood; Hopkins; Howard; Hunt; Jack; Johnson; Jones; Kaufman; Kent; King; Knox; Lamar; Lamb; Lubbock; Lynn; Marion; Martin; Mitchell; Montague; Morris; Motley; Navarro; Nolan; Palo Pinto; Panola; Parker; Rains; Red River; Rockwall; Rusk; Scurry; Shackelford; Smith; Somervell; Stephens; Stonewall; Tarrant; Taylor; Terry; Throckmorton; Titus; Upshur; Van Zandt; Wichita; Wilbarger; Wise; Wood; Yoakum; Young.'),
(228, 0, 'HRAP Grid Coordinate System', 0, 'Datum Name: Hydrologic Rainfall Analysis Project (HRAP) grid coordinate system  Information: a polar stereographic projection true at 60');

-- --------------------------------------------------------

--
-- Table structure for table `speciationcv`
--

DROP TABLE IF EXISTS `speciationcv`;
CREATE TABLE IF NOT EXISTS `speciationcv` (
  `Term` varchar(255) NOT NULL,
  `Definition` text,
  PRIMARY KEY (`Term`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `speciationcv`
--

INSERT INTO `speciationcv` (`Term`, `Definition`) VALUES
('Al', 'Expressed as aluminium'),
('As', 'Expressed as arsenic'),
('B', 'Expressed as boron'),
('Ba', 'Expressed as barium'),
('Br', 'Expressed as bromine'),
('C', 'Expressed as carbon'),
('C2H6', 'Expressed as ethane'),
('Ca', 'Expressed as calcium'),
('CaCO3', 'Expressed as calcium carbonate'),
('Cd', 'Expressed as cadmium'),
('CH4', 'Expressed as methane'),
('Cl', 'Expressed as chlorine'),
('Co', 'Expressed as cobalt'),
('CO2', 'Expressed as carbon dioxide'),
('CO3', 'Expressed as carbonate'),
('Cr', 'Expressed as chromium'),
('Cu', 'Expressed as copper'),
('delta 2H', 'Expressed as deuterium'),
('delta N15', 'Expressed as nitrogen-15'),
('delta O18 ', 'Expressed as oxygen-18'),
('EC', 'Expressed as electrical conductivity'),
('F', 'Expressed as fluorine '),
('Fe', 'Expressed as iron'),
('H2O', 'Expressed as water'),
('HCO3', 'Expressed as hydrogen carbonate'),
('Hg', 'Expressed as mercury'),
('K', 'Expressed as potassium'),
('Mg', 'Expressed as magnesium'),
('Mn', 'Expressed as manganese'),
('Mo', 'Expressed as molybdenum'),
('N', 'Expressed as nitrogen'),
('Na', 'Expressed as sodium'),
('NH4', 'Expressed as ammonium'),
('Ni', 'Expressed as nickel'),
('NO2', 'Expressed as nitrite'),
('NO3', 'Expressed as nitrate'),
('Not Applicable', 'Speciation is not applicable'),
('P', 'Expressed as phosphorus'),
('Pb', 'Expressed as lead'),
('pH', 'Expressed as pH'),
('PO4', 'Expressed as phosphate'),
('S', 'Expressed as Sulfur'),
('Sb', 'Expressed as antimony'),
('Se', 'Expressed as selenium'),
('Si', 'Expressed as silicon'),
('SiO2', 'Expressed as silicate'),
('SN', 'Expressed as tin'),
('SO4', 'Expressed as Sulfate'),
('Sr', 'Expressed as strontium'),
('TA', 'Expressed as total alkalinity'),
('Ti', 'Expressed as titanium'),
('Tl', 'Expressed as thallium'),
('U', 'Expressed as uranium'),
('Unknown', 'Speciation is unknown'),
('V', 'Expressed as vanadium'),
('Zn', 'Expressed as zinc'),
('Zr', 'Expressed as zircon');

-- --------------------------------------------------------

--
-- Table structure for table `topiccategorycv`
--

DROP TABLE IF EXISTS `topiccategorycv`;
CREATE TABLE IF NOT EXISTS `topiccategorycv` (
  `Term` varchar(255) NOT NULL,
  `Definition` text,
  PRIMARY KEY (`Term`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `topiccategorycv`
--

INSERT INTO `topiccategorycv` (`Term`, `Definition`) VALUES
('biota', 'Data associated with biological organisms'),
('boundaries', 'Data associated with boundaries'),
('climatology/meteorology/atmosphere', 'Data associated with climatology, meteorology, or the atmosphere'),
('economy', 'Data associated with the economy'),
('elevation', 'Data associated with elevation'),
('environment', 'Data associated with the environment'),
('farming', 'Data associated with agricultural production'),
('geoscientificInformation', 'Data associated with geoscientific information'),
('health', 'Data associated with health'),
('imageryBaseMapsEarthCover', 'Data associated with imagery, base maps, or earth cover'),
('inlandWaters', 'Data associated with inland waters'),
('intelligenceMilitary', 'Data associated with intelligence or the military'),
('location', 'Data associated with location'),
('oceans', 'Data associated with oceans'),
('planningCadastre', 'Data associated with planning or cadestre'),
('society', 'Data associated with society'),
('structure', 'Data associated with structure'),
('transportation', 'Data associated with transportation'),
('Unknown', 'The topic category is unknown'),
('utilitiesCommunication', 'Data associated with utilities or communication');

-- --------------------------------------------------------

--
-- Table structure for table `units`
--

DROP TABLE IF EXISTS `units`;
CREATE TABLE IF NOT EXISTS `units` (
  `unitsID` int(11) NOT NULL AUTO_INCREMENT,
  `unitsName` varchar(255) NOT NULL,
  `unitsType` varchar(255) NOT NULL,
  `unitsAbbreviation` varchar(255) NOT NULL,
  PRIMARY KEY (`unitsID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=349 ;

--
-- Dumping data for table `units`
--

INSERT INTO `units` (`unitsID`, `unitsName`, `unitsType`, `unitsAbbreviation`) VALUES
(1, 'percent', 'Dimensionless', '%'),
(2, 'degree', 'Angle', 'deg'),
(3, 'grad', 'Angle', 'grad'),
(4, 'radian', 'Angle', 'rad'),
(5, 'degree north', 'Angle', 'degN'),
(6, 'degree south', 'Angle', 'degS'),
(7, 'degree west', 'Angle', 'degW'),
(8, 'degree east', 'Angle', 'degE'),
(9, 'arcminute', 'Angle', 'arcmin'),
(10, 'arcsecond', 'Angle', 'arcsec'),
(11, 'steradian', 'Angle', 'sr'),
(12, 'acre', 'Area', 'ac'),
(13, 'hectare', 'Area', 'ha'),
(14, 'square centimeter', 'Area', 'cm^2'),
(15, 'square foot', 'Area', 'ft^2'),
(16, 'square kilometer', 'Area', 'km^2'),
(17, 'square meter', 'Area', 'm^2'),
(18, 'square mile', 'Area', 'mi^2'),
(19, 'hertz', 'Frequency', 'Hz'),
(20, 'darcy', 'Permeability', 'D'),
(21, 'british thermal unit', 'Energy', 'BTU'),
(22, 'calorie', 'Energy', 'cal'),
(23, 'erg', 'Energy', 'erg'),
(24, 'foot pound force', 'Energy', 'lbf ft'),
(25, 'joule', 'Energy', 'J'),
(26, 'kilowatt hour', 'Energy', 'kW hr'),
(27, 'electronvolt', 'Energy', 'eV'),
(28, 'langleys per day', 'Energy Flux', 'Ly/d'),
(29, 'langleys per minute', 'Energy Flux', 'Ly/min'),
(30, 'langleys per second', 'Energy Flux', 'Ly/s'),
(31, 'megajoules per square meter per day', 'Energy Flux', 'MJ/m^2 d'),
(32, 'watts per square centimeter', 'Energy Flux', 'W/cm^2'),
(33, 'watts per square meter', 'Energy Flux', 'W/m^2'),
(34, 'acre feet per year', 'Flow', 'ac ft/yr'),
(35, 'cubic feet per second', 'Flow', 'cfs'),
(36, 'cubic meters per second', 'Flow', 'm^3/s'),
(37, 'cubic meters per day', 'Flow', 'm^3/d'),
(38, 'gallons per minute', 'Flow', 'gpm'),
(39, 'liters per second', 'Flow', 'L/s'),
(40, 'million gallons per day', 'Flow', 'MGD'),
(41, 'dyne', 'Force', 'dyn'),
(42, 'kilogram force', 'Force', 'kgf'),
(43, 'newton', 'Force', 'N'),
(44, 'pound force', 'Force', 'lbf'),
(45, 'kilo pound force', 'Force', 'kip'),
(46, 'ounce force', 'Force', 'ozf'),
(47, 'centimeter   ', 'Length', 'cm'),
(48, 'international foot', 'Length', 'ft'),
(49, 'international inch', 'Length', 'in'),
(50, 'international yard', 'Length', 'yd'),
(51, 'kilometer', 'Length', 'km'),
(52, 'meter', 'Length', 'm'),
(53, 'international mile', 'Length', 'mi'),
(54, 'millimeter', 'Length', 'mm'),
(55, 'micron', 'Length', 'um'),
(56, 'angstrom', 'Length', ''),
(57, 'femtometer', 'Length', 'fm'),
(58, 'nautical mile', 'Length', 'nmi'),
(59, 'lumen', 'Light', 'lm'),
(60, 'lux', 'Light', 'lx'),
(61, 'lambert', 'Light', 'La'),
(62, 'stilb', 'Light', 'sb'),
(63, 'phot', 'Light', 'ph'),
(64, 'langley', 'Light', 'Ly'),
(65, 'gram', 'Mass', 'g'),
(66, 'kilogram', 'Mass', 'kg'),
(67, 'milligram', 'Mass', 'mg'),
(68, 'microgram', 'Mass', 'ug'),
(69, 'pound mass (avoirdupois)', 'Mass', 'lb'),
(70, 'slug', 'Mass', 'slug'),
(71, 'metric ton', 'Mass', 'tonne'),
(72, 'grain', 'Mass', 'grain'),
(73, 'carat', 'Mass', 'car'),
(74, 'atomic mass unit', 'Mass', 'amu'),
(75, 'short ton', 'Mass', 'ton'),
(76, 'BTU per hour', 'Power', 'BTU/hr'),
(77, 'foot pound force per second', 'Power', 'lbf/s'),
(78, 'horse power (shaft)', 'Power', 'hp'),
(79, 'kilowatt', 'Power', 'kW'),
(80, 'watt', 'Power', 'W'),
(81, 'voltampere', 'Power', 'VA'),
(82, 'atmospheres', 'Pressure/Stress', 'atm'),
(83, 'pascal', 'Pressure/Stress', 'Pa'),
(84, 'inch of mercury', 'Pressure/Stress', 'inch Hg'),
(85, 'inch of water', 'Pressure/Stress', 'inch H2O'),
(86, 'millimeter of mercury', 'Pressure/Stress', 'mm Hg'),
(87, 'millimeter of water', 'Pressure/Stress', 'mm H2O'),
(88, 'centimeter of mercury', 'Pressure/Stress', 'cm Hg'),
(89, 'centimeter of water', 'Pressure/Stress', 'cm H2O'),
(90, 'millibar', 'Pressure/Stress', 'mbar'),
(91, 'pound force per square inch', 'Pressure/Stress', 'psi'),
(92, 'torr', 'Pressure/Stress', 'torr'),
(93, 'barie', 'Pressure/Stress', 'barie'),
(94, 'meters per pixel', 'Resolution', 'meters per pixel'),
(95, 'meters per meter', 'Scale', '-'),
(96, 'degree celsius', 'Temperature', 'degC'),
(97, 'degree fahrenheit', 'Temperature', 'degF'),
(98, 'degree rankine', 'Temperature', 'degR'),
(99, 'degree kelvin', 'Temperature', 'degK'),
(100, 'second', 'Time', 's'),
(101, 'millisecond', 'Time', 'millisec'),
(102, 'minute', 'Time', 'min'),
(103, 'hour', 'Time', 'hr'),
(104, 'day', 'Time', 'd'),
(105, 'week', 'Time', 'week'),
(106, 'month', 'Time', 'month'),
(107, 'common year (365 days)', 'Time', 'yr'),
(108, 'leap year (366 days)', 'Time', 'leap yr'),
(109, 'Julian year (365.25 days)', 'Time', 'jul yr'),
(110, 'Gregorian year (365.2425 days)', 'Time', 'greg yr'),
(111, 'centimeters per hour', 'Velocity', 'cm/hr'),
(112, 'centimeters per second', 'Velocity', 'cm/s'),
(113, 'feet per second', 'Velocity', 'ft/s'),
(114, 'gallons per day per square foot', 'Velocity', 'gpd/ft^2'),
(115, 'inches per hour', 'Velocity', 'in/hr'),
(116, 'kilometers per hour', 'Velocity', 'km/h'),
(117, 'meters per day', 'Velocity', 'm/d'),
(118, 'meters per hour', 'Velocity', 'm/hr'),
(119, 'meters per second', 'Velocity', 'm/s'),
(120, 'miles per hour', 'Velocity', 'mph'),
(121, 'millimeters per hour', 'Velocity', 'mm/hr'),
(122, 'nautical mile per hour', 'Velocity', 'knot'),
(123, 'acre foot', 'Volume', 'ac ft'),
(124, 'cubic centimeter', 'Volume', 'cc'),
(125, 'cubic foot', 'Volume', 'ft^3'),
(126, 'cubic meter', 'Volume', 'm^3'),
(127, 'hectare meter', 'Volume', 'hec m'),
(128, 'liter', 'Volume', 'L'),
(129, 'US gallon', 'Volume', 'gal'),
(130, 'barrel', 'Volume', 'bbl'),
(131, 'pint', 'Volume', 'pt'),
(132, 'bushel', 'Volume', 'bu'),
(133, 'teaspoon', 'Volume', 'tsp'),
(134, 'tablespoon', 'Volume', 'tbsp'),
(135, 'quart', 'Volume', 'qrt'),
(136, 'ounce', 'Volume', 'oz'),
(137, 'dimensionless', 'Dimensionless', '-'),
(138, 'mega joule', 'Energy', 'MJ'),
(139, 'degrees minutes seconds', 'Angle', 'dddmmss'),
(140, 'calories per square centimeter per day', 'Energy Flux', 'cal/cm^2 d'),
(141, 'calories per square centimeter per minute', 'Energy Flux', 'cal/cm^2 min'),
(142, 'milliliters per square centimeter per day', 'Hyporheic flux', 'ml/cm^2 d'),
(144, 'megajoules per square meter', 'Energy per Area', 'MJ/m^2'),
(145, 'gallons per day', 'Flow', 'gpd'),
(146, 'million gallons per month', 'Flow', 'MGM'),
(147, 'million gallons per year', 'Flow', 'MGY'),
(148, 'short tons per day per foot', 'Mass flow per unit width', 'ton/d ft'),
(149, 'lumens per square foot', 'Light Intensity', 'lm/ft^2'),
(150, 'microeinsteins per square meter per second', 'Light Intensity', 'uE/m^2 s'),
(151, 'alphas per meter', 'Light', 'a/m'),
(152, 'microeinsteins per square meter', 'Light', 'uE/m^2'),
(153, 'millimoles of photons per square meter', 'Light', 'mmol/m^2'),
(154, 'absorbance per centimeter', 'Extinction/Absorbance', 'A/cm'),
(155, 'nanogram', 'Mass', 'ng'),
(156, 'picogram', 'Mass', 'pg'),
(157, 'milliequivalents', 'Mass', 'meq'),
(158, 'grams per square meter', 'Areal Density', 'g/m^2'),
(159, 'milligrams per square meter', 'Areal Density', 'mg/m^2'),
(160, 'micrograms per square meter', 'Areal Density', 'ug/m^2'),
(161, 'grams per square meter per day', 'Areal Loading', 'g/m^2 d'),
(162, 'grams per day', 'Loading', 'g/d'),
(163, 'pounds per day', 'Loading', 'lb/d'),
(164, 'pounds per mile', 'Loading', 'lb/mi'),
(165, 'short tons per day', 'Loading', 'ton/d'),
(166, 'milligrams per cubic meter per day', 'Productivity', 'mg/m^3 d'),
(167, 'milligrams per square meter per day', 'Productivity', 'mg/m^2 d'),
(168, 'volts', 'Potential Difference', 'V'),
(169, 'millivolts', 'Potential Difference', 'mV'),
(170, 'kilopascal', 'Pressure/Stress', 'kPa'),
(171, 'megapascal', 'Pressure/Stress', 'MPa'),
(172, 'becquerel', 'Radioactivity', 'Bq'),
(173, 'becquerels per gram', 'Radioactivity', 'Bq/g'),
(174, 'curie', 'Radioactivity', 'Ci'),
(175, 'picocurie', 'Radioactivity', 'pCi'),
(176, 'ohm', 'Resistance', 'ohm'),
(177, 'ohm meter', 'Resistivity', 'ohm m'),
(178, 'picocuries per gram', 'Specific Activity', 'pCi/g'),
(179, 'picocuries per liter', 'Specific Activity', 'pCi/L'),
(180, 'picocuries per milliliter', 'Specific Activity', 'pCi/ml'),
(181, 'hour minute', 'Time', 'hhmm'),
(182, 'year month day', 'Time', 'yymmdd'),
(183, 'year day (Julian)', 'Time', 'yyddd'),
(184, 'inches per day', 'Velocity', 'in/d'),
(185, 'inches per week', 'Velocity', 'in/week'),
(186, 'inches per storm', 'Precipitation', 'in/storm'),
(187, 'thousand acre feet', 'Volume', '10^3 ac ft'),
(188, 'milliliter', 'Volume', 'ml'),
(189, 'cubic feet per second days', 'Volume', 'cfs d'),
(190, 'thousand gallons', 'Volume', '10^3 gal'),
(191, 'million gallons', 'Volume', '10^6 gal'),
(192, 'microsiemens per centimeter', 'Electrical Conductivity', 'uS/cm'),
(193, 'practical salinity units ', 'Salinity', 'psu'),
(194, 'decibel', 'Sound', 'dB'),
(195, 'cubic centimeters per gram', 'Specific Volume', 'cm^3/g'),
(196, 'square meters per gram', 'Specific Surface Area ', 'm^2/g'),
(197, 'short tons per acre foot', 'Concentration', 'ton/ac ft'),
(198, 'grams per cubic centimeter', 'Concentration', 'g/cm^3'),
(199, 'milligrams per liter', 'Concentration', 'mg/L'),
(200, 'nanograms per cubic meter', 'Concentration', 'ng/m^3'),
(201, 'nanograms per liter', 'Concentration', 'ng/L'),
(202, 'grams per liter', 'Concentration', 'g/L'),
(203, 'micrograms per cubic meter', 'Concentration', 'ug/m^3'),
(204, 'micrograms per liter', 'Concentration', 'ug/L'),
(205, 'parts per million', 'Concentration', 'ppm'),
(206, 'parts per billion', 'Concentration', 'ppb'),
(207, 'parts per trillion', 'Concentration', 'ppt'),
(208, 'parts per quintillion', 'Concentration', 'ppqt'),
(209, 'parts per quadrillion', 'Concentration', 'ppq'),
(210, 'per mille', 'Concentration', '%o'),
(211, 'microequivalents per liter', 'Concentration', 'ueq/L'),
(212, 'milliequivalents per liter', 'Concentration', 'meq/L'),
(213, 'milliequivalents per 100 gram', 'Concentration', 'meq/100 g'),
(214, 'milliosmols per kilogram', 'Concentration', 'mOsm/kg'),
(215, 'nanomoles per liter', 'Concentration', 'nmol/L'),
(216, 'picograms per cubic meter', 'Concentration', 'pg/m^3'),
(217, 'picograms per liter', 'Concentration', 'pg/L'),
(218, 'picograms per milliliter', 'Concentration', 'pg/ml'),
(219, 'tritium units', 'Concentration', 'TU'),
(220, 'jackson turbidity units', 'Turbidity', 'JTU'),
(221, 'nephelometric turbidity units', 'Turbidity', 'NTU'),
(222, 'nephelometric turbidity multibeam unit', 'Turbidity', 'NTMU'),
(223, 'nephelometric turbidity ratio unit', 'Turbidity', 'NTRU'),
(224, 'formazin nephelometric multibeam unit', 'Turbidity', 'FNMU'),
(225, 'formazin nephelometric ratio unit', 'Turbidity', 'FNRU'),
(226, 'formazin nephelometric unit', 'Turbidity', 'FNU'),
(227, 'formazin attenuation unit', 'Turbidity', 'FAU'),
(228, 'formazin backscatter unit ', 'Turbidity', 'FBU'),
(229, 'backscatter units', 'Turbidity', 'BU'),
(230, 'attenuation units', 'Turbidity', 'AU'),
(231, 'platinum cobalt units', 'Color', 'PCU'),
(232, 'the ratio between UV absorbance at 254 nm and DOC level', 'Specific UV Absorbance', 'L/(mg DOC/cm)'),
(233, 'billion colonies per day', 'Organism Loading', '10^9 colonies/d'),
(234, 'number of organisms per square meter', 'Organism Concentration', '#/m^2'),
(235, 'number of organisms per liter', 'Organism Concentration', '#/L'),
(236, 'number or organisms per cubic meter', 'Organism Concentration', '#/m^3'),
(237, 'cells per milliliter', 'Organism Concentration', 'cells/ml'),
(238, 'cells per square millimeter', 'Organism Concentration', 'cells/mm^2'),
(239, 'colonies per 100 milliliters', 'Organism Concentration', 'colonies/100 ml'),
(240, 'colonies per milliliter', 'Organism Concentration', 'colonies/ml'),
(241, 'colonies per gram', 'Organism Concentration', 'colonies/g'),
(242, 'colony forming units per milliliter', 'Organism Concentration', 'CFU/ml'),
(243, 'cysts per 10 liters', 'Organism Concentration', 'cysts/10 L'),
(244, 'cysts per 100 liters', 'Organism Concentration', 'cysts/100 L'),
(245, 'oocysts per 10 liters', 'Organism Concentration', 'oocysts/10 L'),
(246, 'oocysts per 100 liters', 'Organism Concentration', 'oocysts/100 L'),
(247, 'most probable number', 'Organism Concentration', 'MPN'),
(248, 'most probable number per 100 liters', 'Organism Concentration', 'MPN/100 L'),
(249, 'most probable number per 100 milliliters', 'Organism Concentration', 'MPN/100 ml'),
(250, 'most probable number per gram', 'Organism Concentration', 'MPN/g'),
(251, 'plaque-forming units per 100 liters', 'Organism Concentration', 'PFU/100 L'),
(252, 'plaques per 100 milliliters', 'Organism Concentration', 'plaques/100 ml'),
(253, 'counts per second', 'Rate', '#/s'),
(254, 'per day', 'Rate', '1/d'),
(255, 'nanograms per square meter per hour', 'Volatilization Rate', 'ng/m^2 hr'),
(256, 'nanograms per square meter per week', 'Volatilization Rate', 'ng/m^2 week'),
(257, 'count', 'Dimensionless', '#'),
(258, 'categorical', 'Dimensionless', 'code'),
(259, 'absorbance per centimeter per mg/L of given acid ', 'Absorbance', '100/cm mg/L'),
(260, 'per liter', 'Concentration Ratio', '1/L'),
(261, 'per mille per hour', 'Sedimentation Rate', '%o/hr'),
(262, 'gallons per batch', 'Flow', 'gpb'),
(263, 'cubic feet per barrel', 'Concentration', 'ft^3/bbl'),
(264, 'per mille by volume', 'Concentration', '%o by vol'),
(265, 'per mille per hour by volume', 'Sedimentation Rate', '%o/hr by vol'),
(266, 'micromoles', 'Amount', 'umol'),
(267, 'tons of calcium carbonate per kiloton', 'Net Neutralization Potential', 'tCaCO3/Kt'),
(268, 'siemens per meter', 'Electrical Conductivity', 'S/m'),
(269, 'millisiemens per centimeter', 'Electrical Conductivity', 'mS/cm'),
(270, 'siemens per centimeter', 'Electrical Conductivity', 'S/cm'),
(271, 'practical salinity scale', 'Salinity', 'pss'),
(272, 'per meter', 'Light Extinction', '1/m'),
(273, 'normal', 'Normality', 'N'),
(274, 'nanomoles per kilogram', 'Concentration', 'nmol/kg'),
(275, 'millimoles per kilogram', 'Concentration', 'mmol/kg'),
(276, 'millimoles per square meter per hour', 'Areal Flux', 'mmol/m^2 hr'),
(277, 'milligrams per cubic meter per hour', 'Productivity', 'mg/m^3 hr'),
(278, 'milligrams per day', 'Loading', 'mg/d'),
(279, 'liters per minute', 'Flow', 'L/min'),
(280, 'liters per day', 'Flow', 'L/d'),
(281, 'jackson candle units ', 'Turbidity', 'JCU'),
(282, 'grains per gallon', 'Concentration', 'gpg'),
(283, 'gallons per second', 'Flow', 'gps'),
(284, 'gallons per hour', 'Flow', 'gph'),
(285, 'foot candle', 'Illuminance', 'ftc'),
(286, 'fibers per liter', 'Concentration', 'fibers/L'),
(287, 'drips per minute', 'Flow', 'drips/min'),
(288, 'cubic centimeters per second', 'Flow', 'cm^3/sec'),
(289, 'colony forming units', 'Organism Concentration', 'CFU'),
(290, 'colony forming units per 100 milliliter', 'Organism Concentration', 'CFU/100 ml'),
(291, 'cubic feet per minute', 'Flow', 'cfm'),
(292, 'ADMI color unit', 'Color', 'ADMI'),
(293, 'percent by volume', 'Concentration', '% by vol'),
(294, 'number of organisms per 500 milliliter', 'Organism Concentration', '#/500 ml'),
(295, 'number of organisms per 100 gallon', 'Organism Concentration', '#/100 gal'),
(296, 'grams per cubic meter per hour', 'Productivity', 'g/m^3 hr'),
(297, 'grams per minute', 'Loading', 'g/min'),
(298, 'grams per second', 'Loading', 'g/s'),
(299, 'million cubic feet', 'Volume', '10^6 ft^3'),
(300, 'month year', 'Time', 'mmyy'),
(301, 'bar', 'Pressure', 'bar'),
(302, 'decisiemens per centimeter', 'Electrical Conductivity', 'dS/cm'),
(303, 'micromoles per liter', 'Concentration', 'umol/L'),
(304, 'Joules per square centimeter', 'Energy per Area', 'J/cm^2'),
(305, 'millimeters per day', 'velocity', 'mm/day'),
(306, 'parts per thousand', 'Concentration', 'ppth'),
(307, 'megaliter', 'Volume', 'ML'),
(308, 'Percent Saturation', 'Concentration', '% Sat'),
(309, 'pH Unit', 'Dimensionless', 'pH'),
(310, 'millimeters per second', 'Velocity', 'mm/s'),
(311, 'liters per hour', 'Flow', 'L/hr'),
(312, 'cubic hecto meter', 'Volume', '(hm)^3'),
(313, 'mols per cubic meter', 'Concentration or organism concentration', 'mol/m^3'),
(314, 'kilo grams per month', 'Loading', 'kg/month'),
(315, 'Hecto Pascal', 'Pressure/Stress', 'hPa'),
(316, 'kilo grams per cubic meter', 'Concentration', 'kg/m^3'),
(317, 'short tons per month', 'Loading', 'ton/month'),
(318, 'micromoles per square meter per second', 'Areal Flux', 'umol/m^2 s'),
(319, 'grams per square meter per hour', 'Areal Flux', 'g/m^2 hr'),
(320, 'milligrams per cubic meter', 'Concentration', 'mg/m^3'),
(321, 'meters squared per second squared', 'Velocity', 'm^2/s^2'),
(322, 'squared degree Celsius', 'Temperature', '(DegC)^2'),
(323, 'milligrams per cubic meter squared', 'Concentration', '(mg/m^3)^2'),
(324, 'meters per second degree Celsius', 'Temperature', 'm/s DegC'),
(325, 'millimoles per square meter per second', 'Areal Flux', 'mmol/m^2 s'),
(326, 'degree Celsius millimoles per cubic meter', 'Concentration', 'DegC mmol/m^3'),
(327, 'millimoles per cubic meter', 'Concentration', 'mmol/m^3'),
(328, 'millimoles per cubic meter squared', 'Concentration', '(mmol/m^3)^2'),
(329, 'Langleys per hour', 'Energy Flux', 'Ly/hr'),
(330, 'hits per square centimeter', 'Precipitation', 'hits/cm^2'),
(331, 'hits per square centimeter per hour', 'Velocity', 'hits/cm^2 hr'),
(332, 'relative fluorescence units', 'Fluorescence', 'RFU'),
(333, 'kilograms per hectare per day', 'Areal Flux', 'kg/ha d'),
(334, 'kilowatts per square meter', 'Energy Flux', 'kW/m^2'),
(335, 'kilograms per square meter', 'Areal Density', 'kg/m^2'),
(336, 'microeinsteins per square meter per day', 'Light Intensity', 'uE/m^2 d'),
(337, 'microgram per milliliter', 'Concentration', 'ug/mL'),
(338, 'Newton per square meter', 'Pressure/Stress', 'Newton/m^2'),
(339, 'micromoles per liter per hour', 'Pressure/Stress', 'umol/L hr'),
(340, 'decisiemens per meter', 'Electrical Conductivity', 'dS/m'),
(341, 'milligrams per kilogram', 'Mass Fraction', 'mg/Kg'),
(342, 'number of organisms per 100 milliliter', 'Organism Concentration', '#/100 mL'),
(343, 'micrograms per kilogram', 'Mass Fraction', 'ug/Kg'),
(344, 'grams per kilogram', 'Mass Fraction', 'g/Kg'),
(345, 'acre feet per month', 'Flow', 'ac ft/mo'),
(346, 'acre feet per half month', 'Flow', 'ac ft/0.5 mo'),
(347, 'cubic meters per minute', 'Flow', 'm^3/min'),
(348, 'count per half cubic foot', 'Concentration', '#/((ft^3)/2)');

-- --------------------------------------------------------

--
-- Table structure for table `valuetypecv`
--

DROP TABLE IF EXISTS `valuetypecv`;
CREATE TABLE IF NOT EXISTS `valuetypecv` (
  `Term` varchar(255) NOT NULL,
  `Definition` text,
  PRIMARY KEY (`Term`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `valuetypecv`
--

INSERT INTO `valuetypecv` (`Term`, `Definition`) VALUES
('Calibration Value', 'A value used as part of the calibration of an instrument at a particular time.'),
('Derived Value', 'Value that is directly derived from an observation or set of observations'),
('Field Observation', 'Observation of a variable using a field instrument'),
('Model Simulation Result', 'Values generated by a simulation model'),
('Sample', 'Observation that is the result of analyzing a sample in a laboratory'),
('Unknown', 'The value type is unknown');

-- --------------------------------------------------------

--
-- Table structure for table `variablenamecv`
--

DROP TABLE IF EXISTS `variablenamecv`;
CREATE TABLE IF NOT EXISTS `variablenamecv` (
  `Term` varchar(255) NOT NULL,
  `Definition` text,
  PRIMARY KEY (`Term`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `variablenamecv`
--

INSERT INTO `variablenamecv` (`Term`, `Definition`) VALUES
('19-Hexanoyloxyfucoxanthin', 'The phytoplankton pigment 19-Hexanoyloxyfucoxanthin'),
('9 cis-Neoxanthin', 'The phytoplankton pigment '),
('Acid neutralizing capacity', 'Acid neutralizing capacity '),
('Agency code', 'Code for the agency which analyzed the sample'),
('Albedo', 'The ratio of reflected to incident light.'),
('Alkalinity, bicarbonate', 'Bicarbonate Alkalinity '),
('Alkalinity, carbonate ', 'Carbonate Alkalinity '),
('Alkalinity, carbonate plus bicarbonate', 'Alkalinity, carbonate plus bicarbonate'),
('Alkalinity, hydroxide ', 'Hydroxide Alkalinity '),
('Alkalinity, total ', 'Total Alkalinity'),
('Alloxanthin', 'The phytoplankton pigment Alloxanthin'),
('Aluminium', 'Aluminium (Al)'),
('Aluminum, dissolved', 'Dissolved Aluminum (Al)'),
('Ammonium flux', 'Ammonium (NH4) flux'),
('Antimony', 'Antimony (Sb)'),
('Area', 'Area of a measurement location'),
('Arsenic', 'Arsenic (As)'),
('Asteridae coverage', 'Areal coverage of the plant Asteridae'),
('Barium, dissolved', 'Dissolved Barium (Ba)'),
('Barium, total', 'Total Barium (Ba)'),
('Barometric pressure', 'Barometric pressure'),
('Baseflow', 'The portion of streamflow (discharge) that is supplied by groundwater sources.'),
('Batis maritima Coverage', 'Areal coverage of the plant Batis maritima'),
('Battery Temperature', 'The battery temperature of a datalogger or sensing system'),
('Battery voltage', 'The battery voltage of a datalogger or sensing system, often recorded as an indicator of data reliability'),
('Benthos', 'Benthic species'),
('Bicarbonate', 'Bicarbonate (HCO3-)'),
('Biogenic silica', 'Hydrated silica (SiO2 nH20)'),
('Biomass, phytoplankton', 'Total mass of phytoplankton, per unit area or volume'),
('Biomass, total', 'Total biomass'),
('Blue-green algae (cyanobacteria), phycocyanin', 'Blue-green algae (cyanobacteria) with phycocyanin pigments'),
('BOD1', '1-day Biochemical Oxygen Demand'),
('BOD2, carbonaceous', '2-day Carbonaceous Biochemical Oxygen Demand'),
('BOD20', '20-day Biochemical Oxygen Demand'),
('BOD20, carbonaceous', '20-day Carbonaceous Biochemical Oxygen Demand'),
('BOD20, nitrogenous', '20-day Nitrogenous Biochemical Oxygen Demand'),
('BOD3, carbonaceous', '3-day Carbonaceous Biochemical Oxygen Demand'),
('BOD4, carbonaceous', '4-day Carbonaceous Biological Oxygen Demand'),
('BOD5', '5-day Biochemical Oxygen Demand'),
('BOD5, carbonaceous', '5-day Carbonaceous Biochemical Oxygen Demand'),
('BOD5, nitrogenous', '5-day Nitrogenous Biochemical Oxygen Demand'),
('BOD6, carbonaceous', '6-day Carbonaceous Biological Oxygen Demand'),
('BOD7, carbonaceous', '7-day Carbonaceous Biochemical Oxygen Demand'),
('BODu', 'Ultimate Biochemical Oxygen Demand'),
('BODu, carbonaceous', 'Carbonaceous Ultimate Biochemical Oxygen Demand'),
('BODu, nitrogenous', 'Nitrogenous Ultimate Biochemical Oxygen Demand'),
('Borehole log material classification', 'Classification of material encountered by a driller at various depths during the drilling of a well and recorded in the borehole log.'),
('Boron', 'Boron (B)'),
('Borrichia frutescens Coverage', 'Areal coverage of the plant Borrichia frutescens'),
('Bromide', 'Bromide'),
('Bromine', 'Bromine (Br)'),
('Bromine, dissolved', 'Dissolved Bromine (Br)'),
('Bulk electrical conductivity', 'Bulk electrical conductivity of a medium measured using a sensor such as time domain reflectometry (TDR), as a raw sensor response in the measurement of a quantity like soil moisture.'),
('Cadmium', 'Cadmium (Cd)'),
('Calcium ', 'Calcium (Ca) '),
('Calcium, dissolved', 'Dissolved Calcium (Ca)'),
('Canthaxanthin', 'The phytoplankton pigment Canthaxanthin'),
('Carbon dioxide', 'Carbon dioxide'),
('Carbon dioxide Flux', 'Carbon dioxide (CO2) flux'),
('Carbon dioxide Storage Flux', 'Carbon dioxide (CO2) storage flux'),
('Carbon dioxide, transducer signal', 'Carbon dioxide (CO2), raw data from sensor'),
('Carbon disulfide', 'Carbon disulfide (CS2)'),
('Carbon tetrachloride', 'Carbon tetrachloride (CCl4)'),
('Carbon to Nitrogen molar ratio', 'C:N (molar)'),
('Carbon, dissolved inorganic', 'Dissolved Inorganic Carbon'),
('Carbon, dissolved organic', 'Dissolved Organic Carbon'),
('Carbon, dissolved total', 'Dissolved Total (Organic+Inorganic) Carbon'),
('Carbon, particulate organic', 'Particulate organic carbon in suspension'),
('Carbon, suspended inorganic', 'Suspended Inorganic Carbon'),
('Carbon, suspended organic', 'DEPRECATED -- The use of this term is discouraged in favor of the use of the synonymous term "Carbon, particulate organic".'),
('Carbon, suspened total', 'Suspended Total (Organic+Inorganic) Carbon'),
('Carbon, total', 'Total (Dissolved+Particulate) Carbon'),
('Carbon, total inorganic', 'Total (Dissolved+Particulate) Inorganic Carbon'),
('Carbon, total organic', 'Total (Dissolved+Particulate) Organic Carbon'),
('Carbon, total solid phase', 'Total solid phase carbon'),
('Carbonate', 'Carbonate ion (CO3-2) concentration'),
('Chloride', 'Chloride (Cl-)'),
('Chloride, total', 'Total Chloride (Cl-)'),
('Chlorine', 'Chlorine (Cl)'),
('Chlorine, dissolved', 'Dissolved Chlorine (Cl)'),
('Chlorophyll (a+b+c)', 'Chlorophyll (a+b+c)'),
('Chlorophyll a', 'Chlorophyll a'),
('Chlorophyll a allomer', 'The phytoplankton pigment Chlorophyll a allomer'),
('Chlorophyll a, corrected for pheophytin', 'Chlorphyll a corrected for pheophytin'),
('Chlorophyll a, uncorrected for pheophytin', 'Chlorophyll a uncorrected for pheophytin'),
('Chlorophyll b', 'Chlorophyll b'),
('Chlorophyll c', 'Chlorophyll c'),
('Chlorophyll c1 and c2', 'Chlorophyll c1 and c2'),
('Chlorophyll Fluorescence', 'Chlorophyll Fluorescence'),
('Chromium (III)', 'Trivalent Chromium'),
('Chromium (VI)', 'Hexavalent Chromium'),
('Chromium, dissolved', 'Dissolved Chromium'),
('Chromium, total', 'Chromium, all forms'),
('Cobalt', 'Cobalt (Co)'),
('Cobalt, dissolved', 'Dissolved Cobalt (Co)'),
('COD', 'Chemical oxygen demand'),
('Coliform, fecal', 'Fecal Coliform'),
('Coliform, total', 'Total Coliform'),
('Color', 'Color in quantified in color units'),
('Colored Dissolved Organic Matter', 'The concentration of colored dissolved organic matter (humic substances)'),
('Container number', 'The identifying number for a water sampler container.'),
('Copper', 'Copper (Cu)'),
('Copper, dissolved', 'Dissolved Copper (Cu)'),
('Cryptophytes', 'The chlorophyll a concentration contributed by cryptophytes'),
('Cuscuta spp. coverage', 'Areal coverage of the plant Cuscuta spp.'),
('Density', 'Density'),
('Deuterium', 'Deuterium (2H), Delta D'),
('Diadinoxanthin', 'The phytoplankton pigment Diadinoxanthin'),
('Diatoxanthin', 'The phytoplankton pigment Diatoxanthin'),
('Dinoflagellates', 'The chlorophyll a concentration contributed by Dinoflagellates'),
('Discharge', 'Discharge'),
('Distance', 'Distance measured from a sensor to a target object such as the surface of a water body or snow surface.'),
('Distichlis spicata Coverage', 'Areal coverage of the plant Distichlis spicata'),
('E-coli', 'Escherichia coli'),
('Electric Energy', 'Electric Energy'),
('Electric Power', 'Electric Power'),
('Electrical conductivity', 'Electrical conductivity'),
('Enterococci', 'Enterococcal bacteria'),
('Ethane, dissolved', 'Dissolved Ethane (C2H6)'),
('Evaporation', 'Evaporation'),
('Evapotranspiration', 'Evapotranspiration'),
('Evapotranspiration, potential', 'The amount of water that could be evaporated and transpired if there was sufficient water available.'),
('Fish detections', 'The number of fish identified by the detection equipment'),
('Flash memory error count', 'A counter which counts the number of '),
('Fluoride', 'Fluoride - F-'),
('Fluorine', 'Fluorine (F-)'),
('Fluorine, dissolved', 'Dissolved Fluorine (Fl)'),
('Friction velocity', 'Friction velocity'),
('Gage height', 'Water level with regard to an arbitrary gage datum (also see Water depth for comparison)'),
('Global Radiation', 'Solar radiation, direct and diffuse, received from a solid angle of 2p steradians on a horizontal surface. \nSource: World Meteorological Organization, Meteoterm'),
('Ground heat flux', 'Ground heat flux'),
('Groundwater Depth', 'Groundwater depth is the distance between the water surface and the ground surface at a specific location specified by the site location and offset.'),
('Hardness, carbonate', 'Carbonate hardness also known as temporary hardness'),
('Hardness, non-carbonate', 'Non-carbonate hardness'),
('Hardness, total', 'Total hardness'),
('Heat index', 'The combination effect of heat and humidity on the temperature felt by people.'),
('Hydrogen sulfide', 'Hydrogen sulfide (H2S)'),
('Hydrogen-2, stable isotope ratio delta', 'Difference in the  2H:1H ratio between the sample and standard'),
('Imaginary dielectric constant', 'Soil reponse of a reflected standing electromagnetic wave of a particular frequency which is related to the dissipation (or loss) of energy within the medium. This is the imaginary portion of the complex dielectric constant.'),
('Iron sulfide', 'Iron sulfide (FeS2)'),
('Iron, dissolved', 'Dissolved Iron (Fe)'),
('Iron, ferric', 'Ferric Iron (Fe+3)'),
('Iron, ferrous', 'Ferrous Iron (Fe+2)'),
('Iva frutescens coverage', 'Areal coverage of the plant Iva frutescens'),
('Latent Heat Flux', 'Latent Heat Flux'),
('Latitude', 'Latitude as a variable measurement or observation (Spatial reference to be designated in methods). '),
('Lead', 'Lead (Pb)'),
('Leaf wetness', 'The effect of moisture settling on the surface of a leaf as a result of either condensation or rainfall.'),
('Light attenuation coefficient', 'Light attenuation coefficient'),
('Limonium nashii Coverage', 'Areal coverage of the plant Limonium nashii'),
('Lithium', 'Lithium (Li)'),
('Longitude', 'Longitude as a variable measurement or observation (Spatial reference to be designated in methods). This is distinct from the longitude of a site which is a site attribute.'),
('Low battery count', 'A counter of the number of times the battery voltage dropped below a minimum threshold'),
('LSI', 'Langelier Saturation Index is an indicator of the degree of saturation of water with respect to calcium carbonate '),
('Lycium carolinianum Coverage', 'Areal coverage of the plant Lycium carolinianum'),
('Magnesium', 'Magnesium (Mg)'),
('Magnesium, dissolved', 'Dissolved Magnesium (Mg)'),
('Manganese', 'Manganese (Mn)'),
('Manganese, dissolved', 'Dissolved Manganese (Mn)'),
('Mercury', 'Mercury (Hg)'),
('Methane, dissolved', 'Dissolved Methane (CH4)'),
('Methylmercury', 'Methylmercury (CH3Hg)'),
('Molybdenum', 'Molybdenum (Mo)'),
('Momentum flux', 'Momentum flux'),
('Monanthochloe littoralis Coverage', 'Areal coverage of the plant Monanthochloe littoralis'),
('N, albuminoid', 'Albuminoid Nitrogen'),
('Net heat flux', 'Outgoing rate of heat energy transfer minus the incoming rate of heat energy transfer through a given area'),
('Nickel', 'Nickel (Ni)'),
('Nickel, dissolved', 'Dissolved Nickel (Ni)'),
('Nitrogen, Dissolved Inorganic', 'Dissolved inorganic nitrogen'),
('Nitrogen, dissolved Kjeldahl', 'Dissolved Kjeldahl (organic nitrogen + ammonia (NH3) + ammonium (NH4))nitrogen'),
('Nitrogen, dissolved nitrate (NO3)', 'Dissolved nitrate (NO3) nitrogen'),
('Nitrogen, dissolved nitrite (NO2)', 'Dissolved nitrite (NO2) nitrogen'),
('Nitrogen, dissolved nitrite (NO2) + nitrate (NO3)', 'Dissolved nitrite (NO2) + nitrate (NO3) nitrogen'),
('Nitrogen, Dissolved Organic', 'Dissolved Organic Nitrogen'),
('Nitrogen, gas', 'Gaseous Nitrogen (N2)'),
('Nitrogen, inorganic', 'Total Inorganic Nitrogen'),
('Nitrogen, NH3', 'Free Ammonia (NH3)'),
('Nitrogen, NH3 + NH4', 'Total (free+ionized) Ammonia'),
('Nitrogen, NH4', 'Ammonium (NH4)'),
('Nitrogen, nitrate (NO3)', 'Nitrate (NO3) Nitrogen'),
('Nitrogen, nitrite (NO2)', 'Nitrite (NO2) Nitrogen'),
('Nitrogen, nitrite (NO2) + nitrate (NO3)', 'Nitrite (NO2) + Nitrate (NO3) Nitrogen'),
('Nitrogen, organic', 'Organic Nitrogen'),
('Nitrogen, organic kjeldahl', 'Organic Kjeldahl (organic nitrogen + ammonia (NH3) + ammonium (NH4)) nitrogen'),
('Nitrogen, particulate organic', 'Particulate Organic Nitrogen'),
('Nitrogen, total', 'Total Nitrogen (NO3+NO2+NH4+NH3+Organic)'),
('Nitrogen, total dissolved', 'Total dissolved nitrogen'),
('Nitrogen, total kjeldahl', 'Total Kjeldahl Nitrogen (Ammonia+Organic) '),
('Nitrogen, total organic', 'Total (dissolved + particulate) organic nitrogen'),
('Nitrogen-15', '15 Nitrogen, Delta Nitrogen'),
('Nitrogen-15, stable isotope ratio delta', 'Difference in the 15N:14N ratio between the sample and standard'),
('No vegetation coverage', 'Areal coverage of no vegetation'),
('Odor', 'Odor'),
('Oxygen flux', 'Oxygen (O2) flux'),
('Oxygen, dissolved', 'Dissolved oxygen'),
('Oxygen, dissolved percent of saturation', 'Dissolved oxygen, percent saturation'),
('Oxygen, dissolved, transducer signal', 'Dissolved oxygen, raw data from sensor'),
('Oxygen-18', '18 O, Delta O'),
('Oxygen-18, stable isotope ratio delta', 'Difference in the 18O:16O ratio between the sample and standard'),
('Ozone', 'Ozone (O3)'),
('Parameter', 'Parameter related to a hydrologic process.  An example usage would be for a starge-discharge relation parameter.'),
('Peridinin', 'The phytoplankton pigment Peridinin'),
('Permittivity', 'Permittivity is a physical quantity that describes how an electric field affects, and is affected by a dielectric medium, and is determined by the ability of a material to polarize in response to the field, and thereby reduce the total electric field inside the material. Thus, permittivity relates to a material''s ability to transmit (or "permit") an electric field.'),
('Petroleum hydrocarbon, total', 'Total petroleum hydrocarbon'),
('pH', 'pH is the measure of the acidity or alkalinity of a solution. pH is formally a measure of the activity of dissolved hydrogen ions (H+).  Solutions in which the concentration of H+ exceeds that of OH- have a pH value lower than 7.0 and are known as acids. '),
('Pheophytin', 'Pheophytin (Chlorophyll which has lost the central Mg ion) is a degradation product of Chlorophyll'),
('Phosphorus, dissolved', 'Dissolved Phosphorus (P)'),
('Phosphorus, dissolved organic', 'Dissolved organic phosphorus'),
('Phosphorus, inorganic ', 'Inorganic Phosphorus'),
('Phosphorus, organic', 'Organic Phosphorus'),
('Phosphorus, orthophosphate', 'Orthophosphate Phosphorus'),
('Phosphorus, orthophosphate dissolved', 'Dissolved orthophosphate phosphorus'),
('Phosphorus, particulate', 'Particulate phosphorus'),
('Phosphorus, particulate organic', 'Particulate organic phosphorus in suspension'),
('Phosphorus, phosphate (PO4)', 'Phosphate Phosphorus'),
('Phosphorus, phosphate flux', 'Phosphate (PO4) flux'),
('Phosphorus, polyphosphate', 'Polyphosphate Phosphorus'),
('Phosphorus, total', 'Total Phosphorus'),
('Phosphorus, total dissolved', 'Total dissolved phosphorus'),
('Phytoplankton', 'Measurement of phytoplankton with no differentiation between species'),
('Position', 'Position of an element that interacts with water such as reservoir gates'),
('Potassium', 'Potassium (K)'),
('Potassium, dissolved', 'Dissolved Potassium (K)'),
('Precipitation', 'Precipitation such as rainfall. Should not be confused with settling.'),
('Pressure, absolute', 'Pressure'),
('Pressure, gauge', 'Pressure relative to the local atmospheric or ambient pressure'),
('Primary Productivity', 'Primary Productivity'),
('Program signature', 'A unique data recorder program identifier which is useful for knowing when the source code in the data recorder has been modified.'),
('Radiation, incoming longwave', 'Incoming Longwave Radiation'),
('Radiation, incoming PAR', 'Incoming Photosynthetically-Active Radiation'),
('Radiation, incoming shortwave', 'Incoming Shortwave Radiation'),
('Radiation, incoming UV-A', 'Incoming Ultraviolet A Radiation'),
('Radiation, incoming UV-B', 'Incoming Ultraviolet B Radiation'),
('Radiation, net', 'Net Radiation'),
('Radiation, net longwave', 'Net Longwave Radiation'),
('Radiation, net PAR', 'Net Photosynthetically-Active Radiation'),
('Radiation, net shortwave', 'Net Shortwave radiation'),
('Radiation, outgoing longwave', 'Outgoing Longwave Radiation'),
('Radiation, outgoing PAR', 'Outgoing Photosynthetically-Active Radiation'),
('Radiation, outgoing shortwave', 'Outgoing Shortwave Radiation'),
('Radiation, total incoming', 'Total amount of incoming radiation from all frequencies'),
('Radiation, total outgoing', 'Total amount of outgoing radiation from all frequencies'),
('Radiation, total shortwave', 'Total Shortwave Radiation'),
('Rainfall rate', 'A measure of the intensity of rainfall, calculated as the depth of water to fall over a given time period if the intensity were to remain constant over that time interval (in/hr, mm/hr, etc)'),
('Real dielectric constant', 'Soil reponse of a reflected standing electromagnetic wave of a particular frequency which is related to the stored energy within the medium.  This is the real portion of the complex dielectric constant.'),
('Recorder code', 'A code used to identifier a data recorder.'),
('Reduction potential', 'Oxidation-reduction potential'),
('Relative humidity', 'Relative humidity'),
('Reservoir storage', 'Reservoir water volume'),
('Respiration, net', 'Net respiration'),
('Salicornia bigelovii coverage', 'Areal coverage of the plant Salicornia bigelovii'),
('Salicornia virginica coverage', 'Areal coverage of the plant Salicornia virginica'),
('Salinity', 'Salinity'),
('Secchi depth', 'Secchi depth'),
('Selenium', 'Selenium (Se)'),
('Sensible Heat Flux', 'Sensible Heat Flux'),
('Sequence number', 'A counter of events in a sequence'),
('Signal-to-noise ratio', 'Signal-to-noise ratio (often abbreviated SNR or S/N) is defined as the ratio of a signal power to the noise power corrupting the signal. The higher the ratio, the less obtrusive the background noise is.'),
('Silica', 'Silica (SiO2)'),
('Silicate', 'Silicate.  Chemical compound containing silicon, oxygen, and one or more metals, e.g., aluminum, barium, beryllium, calcium, iron, magnesium, manganese, potassium, sodium, or zirconium.'),
('Silicic acid', 'Hydrated silica disolved in water'),
('Silicic acid flux', 'Silicate acid (H4SiO4) flux'),
('Silicon', 'Silicon (Si)  '),
('Silicon, dissolved', 'Dissolved Silicon (Si)'),
('Snow depth', 'Snow depth'),
('Snow Water Equivalent', 'The depth of water if a snow cover is completely melted, expressed in units of depth, on a corresponding horizontal surface area.'),
('Sodium', 'Sodium (Na)'),
('Sodium adsorption ratio', 'Sodium adsorption ratio'),
('Sodium plus potassium', 'Sodium plus potassium'),
('Sodium, dissolved', 'Dissolved Sodium (Na)'),
('Sodium, fraction of cations', 'Sodium, fraction of cations'),
('Solids, fixed Dissolved', 'Fixed Dissolved Solids'),
('Solids, fixed Suspended', 'Fixed Suspended Solids'),
('Solids, total', 'Total Solids'),
('Solids, total Dissolved', 'Total Dissolved Solids'),
('Solids, total Fixed', 'Total Fixed Solids'),
('Solids, total Suspended', 'Total Suspended Solids'),
('Solids, total Volatile', 'Total Volatile Solids'),
('Solids, volatile Dissolved', 'Volatile Dissolved Solids'),
('Solids, volatile Suspended', 'Volatile Suspended Solids'),
('Spartina alterniflora coverage', 'Areal coverage of the plant Spartina alterniflora'),
('Spartina spartinea coverage', 'Areal coverage of the plant Spartina spartinea'),
('Specific conductance', 'Specific conductance'),
('Streamflow', 'The volume of water flowing past a fixed point. '),
('Streptococci, fecal', 'Fecal Streptococci'),
('Strontium', 'Strontium (Sr)'),
('Strontium, dissolved', 'Dissolved Strontium (Sr)'),
('Strontium, total', 'Total Strontium (Sr)'),
('Suaeda linearis coverage', 'Areal coverage of the plant Suaeda linearis'),
('Suaeda maritima coverage', 'Areal coverage of the plant Suaeda maritima'),
('Sulfate', 'Sulfate (SO4)'),
('Sulfate, dissolved', 'Dissolved Sulfate (SO4)'),
('Sulfur', 'Sulfur (S)'),
('Sulfur dioxide', 'Sulfur dioxide (SO2)'),
('Sulfur, organic', 'Organic Sulfur'),
('Sulfur, pyritic', 'Pyritic Sulfur'),
('Sunshine duration', 'Sunshine duration'),
('Table overrun error count', 'A counter which counts the number of datalogger table overrun errors'),
('TDR waveform relative length', 'Time domain reflextometry, apparent length divided by probe length. Square root of dielectric'),
('Temperature', 'Temperature'),
('Temperature, dew point', 'Dew point temperature'),
('Temperature, transducer signal', 'Temperature, raw data from sensor'),
('Thallium', 'Thallium (Tl)'),
('THSW Index', 'The THSW Index uses temperature, humidity, solar radiation, and wind speed to calculate an apparent temperature.'),
('THW Index', 'The THW Index uses temperature, humidity, and wind speed to calculate an apparent temperature.'),
('Tide stage', 'Tidal stage'),
('Tin', 'Tin (Sn)'),
('Titanium', 'Titanium (Ti)'),
('Transient species coverage', 'Areal coverage of transient species'),
('Transpiration', 'Transpiration'),
('TSI', 'Carlson Trophic State Index is a measurement of eutrophication based on Secchi depth'),
('Turbidity', 'Turbidity'),
('Uranium', 'Uranium (U)'),
('Urea', 'Urea ((NH2)2CO)'),
('Urea flux', 'Urea ((NH2)2CO) flux'),
('Vanadium', 'Vanadium (V)'),
('Vapor pressure', 'The pressure of a vapor in equilibrium with its non-vapor phases'),
('Vapor pressure deficit', 'The difference between the actual water vapor pressure and the saturation of water vapor pressure at a particular temperature.'),
('Velocity', 'The velocity of a substance, fluid or object'),
('Visibility', 'Visibility'),
('Voltage', 'Voltage or Electrical Potential'),
('Volume', 'Volume. To quantify discharge or hydrograph volume or some other volume measurement.'),
('Volumetric water content', 'Volume of liquid water relative to bulk volume. Used for example to quantify soil moisture'),
('Watchdog error count', 'A counter which counts the number of total datalogger watchdog errors'),
('Water depth', 'Water depth is the distance between the water surface and the bottom of the water body at a specific location specified by the site location and offset.'),
('Water depth, averaged', 'Water depth averaged over a channel cross-section or water body. '),
('Water flux', 'Water Flux'),
('Water level', 'Water level relative to datum. The datum may be local or global such as NGVD 1929 and should be specified in the method description for associated data values.'),
('Water potential', 'Water potential is the potential energy of water relative to pure free water (e.g. deionized water) in reference conditions. It quantifies the tendency of water to move from one area to another due to osmosis, gravity, mechanical pressure, or matrix effects including surface tension.'),
('Water vapor density', 'Water vapor density'),
('Wave height', 'The height of a surface wave, measured as the difference in elevation between the wave crest and an adjacent trough.'),
('Weather conditions', 'Weather conditions'),
('Well flow rate', 'Flow rate from well while pumping'),
('Wellhead pressure', 'The pressure exerted by the fluid at the wellhead or casinghead after the well has been shut off for a period of time, typically 24 hours'),
('Wind chill', 'The effect of wind on the temperature felt on human skin.'),
('Wind direction', 'Wind direction'),
('Wind gust direction', 'Direction of gusts of wind'),
('Wind gust speed', 'Speed of gusts of wind'),
('Wind Run', 'The length of flow of air past a point over a time interval. Windspeed times the interval of time.'),
('Wind speed', 'Wind speed'),
('Wind stress', 'Drag or trangential force per unit area exerted on a surface by the adjacent layer of moving air'),
('Wrack coverage', 'Areal coverage of dead vegetation'),
('Zeaxanthin', 'The phytoplankton pigment Zeaxanthin'),
('Zinc', 'Zinc (Zn)'),
('Zinc, dissolved', 'Dissolved Zinc (Zn)'),
('Zircon, dissolved', 'Dissolved Zircon (Zr)'),
('Zooplankton', 'Zooplanktonic organisms, non-specific');

-- --------------------------------------------------------

--
-- Table structure for table `variables`
--

DROP TABLE IF EXISTS `variables`;
CREATE TABLE IF NOT EXISTS `variables` (
  `VariableID` int(11) NOT NULL AUTO_INCREMENT,
  `VariableCode` varchar(50) NOT NULL,
  `VariableName` varchar(255) NOT NULL,
  `Speciation` varchar(255) NOT NULL DEFAULT 'Not Applicable',
  `VariableunitsID` int(11) NOT NULL,
  `SampleMedium` varchar(255) NOT NULL DEFAULT 'Unknown',
  `ValueType` varchar(255) NOT NULL DEFAULT 'Unknown',
  `IsRegular` tinyint(1) NOT NULL DEFAULT '0',
  `TimeSupport` double NOT NULL DEFAULT '0',
  `TimeunitsID` int(11) NOT NULL DEFAULT '0',
  `DataType` varchar(255) NOT NULL DEFAULT 'Unknown',
  `GeneralCategory` varchar(255) NOT NULL DEFAULT 'Unknown',
  `NoDataValue` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`VariableID`),
  UNIQUE KEY `AK_Variables_VariableCode` (`VariableCode`),
  KEY `VariableunitsID` (`VariableunitsID`),
  KEY `TimeunitsID` (`TimeunitsID`),
  KEY `DataType` (`DataType`),
  KEY `GeneralCategory` (`GeneralCategory`),
  KEY `SampleMedium` (`SampleMedium`),
  KEY `ValueType` (`ValueType`),
  KEY `VariableName` (`VariableName`),
  KEY `Speciation` (`Speciation`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=25 ;

--
-- Dumping data for table `variables`
--

INSERT INTO `variables` (`VariableID`, `VariableCode`, `VariableName`, `Speciation`, `VariableunitsID`, `SampleMedium`, `ValueType`, `IsRegular`, `TimeSupport`, `TimeunitsID`, `DataType`, `GeneralCategory`, `NoDataValue`) VALUES
(7, 'IDCS-5', 'Temperature', 'Not Applicable', 96, 'Surface Water', 'Field Observation', 0, 0, 100, 'Sporadic', 'Water Quality', 0),
(8, 'IDCS-1', 'Oxygen, dissolved', 'Not Applicable', 199, 'Surface Water', 'Field Observation', 0, 0, 100, 'Sporadic', 'Water Quality', -9999),
(9, 'IDCS-8', 'Turbidity', 'Not Applicable', 221, 'Surface Water', 'Field Observation', 0, 0, 100, 'Sporadic', 'Water Quality', 0),
(10, 'IDCS-7', 'Nitrogen, nitrate (NO3)', 'NO3', 199, 'Surface Water', 'Field Observation', 0, 0, 100, 'Sporadic', 'Water Quality', 0),
(12, 'IDCS-9', 'Electrical conductivity', 'Not Applicable', 192, 'Surface Water', 'Field Observation', 0, 1, 100, 'Average', 'Water Quality', 0),
(22, 'IDCS-3-Avg', 'pH', 'Not Applicable', 309, 'Surface Water', 'Field Observation', 0, 0, 100, 'Average', 'Unknown', -9999),
(24, 'IDCS-5-Avg', 'Temperature', 'Not Applicable', 96, 'Surface Water', 'Field Observation', 0, 1, 102, 'Average', 'Water Quality', -9999);

-- --------------------------------------------------------

--
-- Table structure for table `verticaldatumcv`
--

DROP TABLE IF EXISTS `verticaldatumcv`;
CREATE TABLE IF NOT EXISTS `verticaldatumcv` (
  `Term` varchar(255) NOT NULL,
  `Definition` text,
  PRIMARY KEY (`Term`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `verticaldatumcv`
--

INSERT INTO `verticaldatumcv` (`Term`, `Definition`) VALUES
('MSL', 'Mean Sea Level'),
('NAVD88', 'North American Vertical Datum of 1988'),
('NGVD29', 'National Geodetic Vertical Datum of 1929'),
('Unknown', 'The vertical datum is unknown');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `categories`
--
ALTER TABLE `categories`
  ADD CONSTRAINT `FK_Categories_Variables` FOREIGN KEY (`VariableID`) REFERENCES `variables` (`VariableID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `datavalues`
--
ALTER TABLE `datavalues`
  ADD CONSTRAINT `FK_DataValues_censorcodecv` FOREIGN KEY (`CensorCode`) REFERENCES `censorcodecv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_DataValues_methods` FOREIGN KEY (`MethodID`) REFERENCES `methods` (`MethodID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_DataValues_OffsetTypes` FOREIGN KEY (`OffsetTypeID`) REFERENCES `offsettypes` (`OffsetTypeID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_DataValues_Qualifiers` FOREIGN KEY (`QualifierID`) REFERENCES `qualifiers` (`QualifierID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_DataValues_qualitycontrollevels` FOREIGN KEY (`QualityControlLevelID`) REFERENCES `qualitycontrollevels` (`QualityControlLevelID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_DataValues_Samples` FOREIGN KEY (`SampleID`) REFERENCES `samples` (`SampleID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_DataValues_Sites` FOREIGN KEY (`SiteID`) REFERENCES `sites` (`SiteID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_DataValues_Sources` FOREIGN KEY (`SourceID`) REFERENCES `sources` (`SourceID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_DataValues_Variables` FOREIGN KEY (`VariableID`) REFERENCES `variables` (`VariableID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `derivedfrom`
--
ALTER TABLE `derivedfrom`
  ADD CONSTRAINT `FK_DerivedFrom_DataValues` FOREIGN KEY (`ValueID`) REFERENCES `datavalues` (`ValueID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `groups`
--
ALTER TABLE `groups`
  ADD CONSTRAINT `FK_Groups_DataValues` FOREIGN KEY (`ValueID`) REFERENCES `datavalues` (`ValueID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_Groups_GroupDescriptions` FOREIGN KEY (`GroupID`) REFERENCES `groupdescriptions` (`GroupID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `isometadata`
--
ALTER TABLE `isometadata`
  ADD CONSTRAINT `FK_isometadata_topiccategorycv` FOREIGN KEY (`TopicCategory`) REFERENCES `topiccategorycv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `offsettypes`
--
ALTER TABLE `offsettypes`
  ADD CONSTRAINT `FK_OffsetTypes_units` FOREIGN KEY (`OffsetunitsID`) REFERENCES `units` (`unitsID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `samples`
--
ALTER TABLE `samples`
  ADD CONSTRAINT `FK_Samples_labmethods` FOREIGN KEY (`LabMethodID`) REFERENCES `labmethods` (`LabMethodID`),
  ADD CONSTRAINT `FK_Samples_sampletypecv` FOREIGN KEY (`SampleType`) REFERENCES `sampletypecv` (`Term`);

--
-- Constraints for table `sites`
--
ALTER TABLE `sites`
  ADD CONSTRAINT `FK_Sites_sitetypecv` FOREIGN KEY (`SiteType`) REFERENCES `sitetypecv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_Sites_spatialreferences` FOREIGN KEY (`LatLongDatumID`) REFERENCES `spatialreferences` (`SpatialReferenceID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_Sites_spatialreferences1` FOREIGN KEY (`LocalProjectionID`) REFERENCES `spatialreferences` (`SpatialReferenceID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_Sites_verticaldatumcv` FOREIGN KEY (`VerticalDatum`) REFERENCES `verticaldatumcv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `sources`
--
ALTER TABLE `sources`
  ADD CONSTRAINT `FK_Sources_ISOMetaData` FOREIGN KEY (`MetadataID`) REFERENCES `isometadata` (`MetadataID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `variables`
--
ALTER TABLE `variables`
  ADD CONSTRAINT `FK_Variables_datatypecv` FOREIGN KEY (`DataType`) REFERENCES `datatypecv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_Variables_GeneralCategoryCV` FOREIGN KEY (`GeneralCategory`) REFERENCES `generalcategorycv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_Variables_samplemediumcv` FOREIGN KEY (`SampleMedium`) REFERENCES `samplemediumcv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_Variables_speciationcv` FOREIGN KEY (`Speciation`) REFERENCES `speciationcv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_Variables_units` FOREIGN KEY (`VariableunitsID`) REFERENCES `units` (`unitsID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_Variables_units1` FOREIGN KEY (`TimeunitsID`) REFERENCES `units` (`unitsID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_Variables_valuetypecv` FOREIGN KEY (`ValueType`) REFERENCES `valuetypecv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_Variables_variablenamecv` FOREIGN KEY (`VariableName`) REFERENCES `variablenamecv` (`Term`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
