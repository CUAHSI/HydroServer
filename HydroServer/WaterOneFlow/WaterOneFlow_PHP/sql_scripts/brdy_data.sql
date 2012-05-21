-- phpMyAdmin SQL Dump
-- version 3.4.10.2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: May 20, 2012 at 02:09 PM
-- Server version: 5.1.61
-- PHP Version: 5.2.17

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `advenup1_odm2`
--

--
-- Dumping data for table `DataValues`
--

INSERT INTO `DataValues` (`ValueID`, `DataValue`, `ValueAccuracy`, `LocalDateTime`, `UTCOffset`, `DateTimeUTC`, `SiteID`, `VariableID`, `OffsetValue`, `OffsetTypeID`, `CensorCode`, `QualifierID`, `MethodID`, `SourceID`, `SampleID`, `DerivedFromID`, `QualityControlLevelID`) VALUES
(48, -6, 1, '2012-01-28 13:00:00', 1, '2012-01-28 12:00:00', 3, 2, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(5, -4, 1, '2011-12-21 15:00:00', 1, '2011-12-21 14:00:00', 3, 2, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(6, -4, 1, '2011-12-22 13:00:00', 1, '2011-12-22 12:00:00', 3, 2, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(12, -3, 1, '2011-12-31 23:45:00', 1, '2011-12-31 22:45:00', 3, 2, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(21, -3, 1, '2012-01-13 15:15:00', 1, '2012-01-13 14:15:00', 2, 2, NULL, NULL, 'nc', NULL, 2, 1, NULL, NULL, 0),
(28, -2, 1, '2012-01-17 11:30:00', 1, '2012-01-17 10:30:00', 2, 2, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(32, -2, 1, '2012-01-20 11:00:00', 1, '2012-01-20 10:00:00', 2, 2, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(43, -2, 1, '2012-01-24 11:00:00', 1, '2012-01-24 10:00:00', 2, 2, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(45, -2, 1, '2012-01-25 14:00:00', 1, '2012-01-25 13:00:00', 2, 2, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(16, -1, 1, '2012-01-10 16:15:00', 1, '2012-01-10 15:15:00', 2, 2, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(38, -1, 1, '2012-01-22 11:00:00', 1, '2012-01-22 10:00:00', 2, 2, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(9, 0, 1, '2011-12-24 12:00:00', 1, '2011-12-24 11:00:00', 3, 2, NULL, NULL, 'nc', NULL, 2, 1, NULL, NULL, 0),
(14, 1, 1, '2012-01-02 10:00:00', 1, '2012-01-02 10:00:00', 3, 1, NULL, NULL, 'lt', NULL, 1, 1, NULL, NULL, 0),
(3, 2, 1, '2011-12-16 16:00:00', 1, '2011-12-16 15:00:00', 4, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(13, 3, 1, '2012-01-02 10:00:00', 1, '2012-01-02 10:00:00', 3, 2, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(1, 4, 2, '2011-12-16 16:00:00', 1, '2011-12-16 15:00:00', 4, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(4, 7, 1, '2011-12-21 15:00:00', 1, '2011-12-21 14:00:00', 3, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(8, 7, 1, '2011-12-24 12:00:00', 1, '2011-12-24 11:00:00', 3, 1, NULL, NULL, 'nc', NULL, 2, 1, NULL, NULL, 0),
(10, 7, 3, '2011-12-25 12:00:00', 1, '2011-12-25 11:00:00', 3, 1, NULL, NULL, 'lt', NULL, 1, 1, NULL, NULL, 0),
(7, 10, 1, '2011-12-22 13:00:00', 1, '2011-12-22 12:00:00', 3, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(15, 10, 1, '2012-01-10 16:15:00', 1, '2012-01-10 15:15:00', 2, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(11, 10, 3, '2011-12-31 23:45:00', 1, '2011-12-31 22:45:00', 3, 1, NULL, NULL, 'lt', NULL, 1, 1, NULL, NULL, 0),
(24, 11, 1, '2012-01-14 12:00:00', 1, '2012-01-14 11:00:00', 4, 1, NULL, NULL, 'lt', NULL, 1, 1, NULL, NULL, 0),
(19, 14, 1, '2012-01-13 15:15:00', 1, '2012-01-13 14:15:00', 2, 1, NULL, NULL, 'lt', NULL, 1, 1, NULL, NULL, 0),
(34, 14, 2, '2012-01-21 11:00:00', 1, '2012-01-21 10:00:00', 4, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(20, 15, 1, '2012-01-13 15:00:00', 1, '2012-01-13 14:00:00', 3, 1, NULL, NULL, 'lt', NULL, 2, 1, NULL, NULL, 0),
(25, 15, 1, '2012-01-17 11:00:00', 1, '2012-01-17 10:00:00', 4, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(22, 18, 1, '2012-01-14 12:30:00', 1, '2012-01-14 11:30:00', 2, 1, NULL, NULL, 'nc', NULL, 2, 1, NULL, NULL, 0),
(23, 18, 1, '2012-01-14 12:30:00', 1, '2012-01-14 11:30:00', 3, 1, NULL, NULL, 'nc', NULL, 2, 1, NULL, NULL, 0),
(36, 18, 2, '2012-01-22 11:00:00', 1, '2012-01-22 10:00:00', 4, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(30, 19, 4, '2012-01-19 11:30:00', 1, '2012-01-19 10:30:00', 4, 1, NULL, NULL, 'lt', NULL, 1, 1, NULL, NULL, 0),
(26, 20, 1, '2012-01-17 11:30:00', 1, '2012-01-17 10:30:00', 2, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(41, 20, 1, '2012-01-24 11:00:00', 1, '2012-01-24 10:00:00', 4, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(27, 21, 1, '2012-01-17 11:00:00', 1, '2012-01-17 10:00:00', 3, 1, NULL, NULL, 'nc', NULL, 2, 1, NULL, NULL, 0),
(35, 23, 2, '2012-01-21 13:00:00', 1, '2012-01-21 12:00:00', 2, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(31, 23, 5, '2012-01-20 11:00:00', 1, '2012-01-20 10:00:00', 2, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(46, 24, 1, '2012-01-25 14:00:00', 1, '2012-01-25 13:00:00', 4, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(37, 25, 2, '2012-01-22 11:00:00', 1, '2012-01-22 10:00:00', 2, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(29, 25, 5, '2012-01-19 12:00:00', 1, '2012-01-19 11:00:00', 2, 1, NULL, NULL, 'lt', NULL, 1, 1, NULL, NULL, 0),
(40, 31, 1, '2012-01-24 11:00:00', 1, '2012-01-24 10:00:00', 2, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0),
(47, 35, 1, '2012-01-28 13:00:00', 1, '2012-01-28 12:00:00', 3, 1, NULL, NULL, 'lt', NULL, 1, 1, NULL, NULL, 0),
(44, 37, 1, '2012-01-25 14:00:00', 1, '2012-01-25 13:00:00', 2, 1, NULL, NULL, 'nc', NULL, 1, 1, NULL, NULL, 0);

--
-- Dumping data for table `Methods`
--

INSERT INTO `Methods` (`MethodID`, `MethodDescription`, `MethodLink`) VALUES
(0, 'No method specified', NULL),
(1, 'Measured by volunteers from Brdy', 'http://www.brdskastopa.cz'),
(2, 'Calculated estimate from snow depth at nearest sites', 'http://www.brdskastopa.cz');

--
-- Dumping data for table `SeriesCatalog`
--

INSERT INTO `SeriesCatalog` (`SeriesID`, `SiteID`, `SiteCode`, `SiteName`, `SiteType`, `VariableID`, `VariableCode`, `VariableName`, `Speciation`, `VariableUnitsID`, `VariableUnitsName`, `SampleMedium`, `ValueType`, `TimeSupport`, `TimeUnitsID`, `TimeUnitsName`, `DataType`, `GeneralCategory`, `MethodID`, `MethodDescription`, `SourceID`, `Organization`, `SourceDescription`, `Citation`, `QualityControlLevelID`, `QualityControlLevelCode`, `BeginDateTime`, `EndDateTime`, `BeginDateTimeUTC`, `EndDateTimeUTC`, `ValueCount`) VALUES
(45, 2, 'PRA', 'Praha', 'Land', 1, 'SN', 'Snow depth', 'Not Applicable', 47, 'centimeter   ', 'Snow', 'Field Observation', 0, 104, 'day', 'Sporadic', 'Climate', 1, 'Measured by volunteers from Brdy', 1, 'Brdská stopa', 'Volunteers from tbe Brdy mountain guard (HS Brdy) and other cross-skiers measure snow depth in Brdy mountains.', 'http://www.brdskastopa.cz', 0, '0', '2012-01-10 16:15:00', '2012-01-25 14:00:00', '2012-01-10 15:15:00', '2012-01-25 13:00:00', 9),
(46, 2, 'PRA', 'Praha', 'Land', 1, 'SN', 'Snow depth', 'Not Applicable', 47, 'centimeter   ', 'Snow', 'Field Observation', 0, 104, 'day', 'Sporadic', 'Climate', 2, 'Calculated estimate from snow depth at nearest sites', 1, 'Brdská stopa', 'Volunteers from tbe Brdy mountain guard (HS Brdy) and other cross-skiers measure snow depth in Brdy mountains.', 'http://www.brdskastopa.cz', 0, '0', '2012-01-14 12:30:00', '2012-01-14 12:30:00', '2012-01-14 11:30:00', '2012-01-14 11:30:00', 1),
(47, 2, 'PRA', 'Praha', 'Land', 2, 'TE', 'Temperature', 'Not Applicable', 96, 'degree celsius', 'Air', 'Field Observation', 0, 104, 'day', 'Sporadic', 'Climate', 1, 'Measured by volunteers from Brdy', 1, 'Brdská stopa', 'Volunteers from tbe Brdy mountain guard (HS Brdy) and other cross-skiers measure snow depth in Brdy mountains.', 'http://www.brdskastopa.cz', 0, '0', '2012-01-10 16:15:00', '2012-01-25 14:00:00', '2012-01-10 15:15:00', '2012-01-25 13:00:00', 6),
(48, 2, 'PRA', 'Praha', 'Land', 2, 'TE', 'Temperature', 'Not Applicable', 96, 'degree celsius', 'Air', 'Field Observation', 0, 104, 'day', 'Sporadic', 'Climate', 2, 'Calculated estimate from snow depth at nearest sites', 1, 'Brdská stopa', 'Volunteers from tbe Brdy mountain guard (HS Brdy) and other cross-skiers measure snow depth in Brdy mountains.', 'http://www.brdskastopa.cz', 0, '0', '2012-01-13 15:15:00', '2012-01-13 15:15:00', '2012-01-13 14:15:00', '2012-01-13 14:15:00', 1),
(49, 3, 'TOK', 'Tok', 'Land', 1, 'SN', 'Snow depth', 'Not Applicable', 47, 'centimeter   ', 'Snow', 'Field Observation', 0, 104, 'day', 'Sporadic', 'Climate', 1, 'Measured by volunteers from Brdy', 1, 'Brdská stopa', 'Volunteers from tbe Brdy mountain guard (HS Brdy) and other cross-skiers measure snow depth in Brdy mountains.', 'http://www.brdskastopa.cz', 0, '0', '2011-12-21 15:00:00', '2012-01-28 13:00:00', '2011-12-21 14:00:00', '2012-01-28 12:00:00', 6),
(50, 3, 'TOK', 'Tok', 'Land', 1, 'SN', 'Snow depth', 'Not Applicable', 47, 'centimeter   ', 'Snow', 'Field Observation', 0, 104, 'day', 'Sporadic', 'Climate', 2, 'Calculated estimate from snow depth at nearest sites', 1, 'Brdská stopa', 'Volunteers from tbe Brdy mountain guard (HS Brdy) and other cross-skiers measure snow depth in Brdy mountains.', 'http://www.brdskastopa.cz', 0, '0', '2011-12-24 12:00:00', '2012-01-17 11:00:00', '2011-12-24 11:00:00', '2012-01-17 10:00:00', 4),
(51, 3, 'TOK', 'Tok', 'Land', 2, 'TE', 'Temperature', 'Not Applicable', 96, 'degree celsius', 'Air', 'Field Observation', 0, 104, 'day', 'Sporadic', 'Climate', 1, 'Measured by volunteers from Brdy', 1, 'Brdská stopa', 'Volunteers from tbe Brdy mountain guard (HS Brdy) and other cross-skiers measure snow depth in Brdy mountains.', 'http://www.brdskastopa.cz', 0, '0', '2011-12-21 15:00:00', '2012-01-28 13:00:00', '2011-12-21 14:00:00', '2012-01-28 12:00:00', 5),
(52, 3, 'TOK', 'Tok', 'Land', 2, 'TE', 'Temperature', 'Not Applicable', 96, 'degree celsius', 'Air', 'Field Observation', 0, 104, 'day', 'Sporadic', 'Climate', 2, 'Calculated estimate from snow depth at nearest sites', 1, 'Brdská stopa', 'Volunteers from tbe Brdy mountain guard (HS Brdy) and other cross-skiers measure snow depth in Brdy mountains.', 'http://www.brdskastopa.cz', 0, '0', '2011-12-24 12:00:00', '2011-12-24 12:00:00', '2011-12-24 11:00:00', '2011-12-24 11:00:00', 1),
(53, 4, 'NEP', 'Nepomuk - u Nepálu', 'Land', 1, 'SN', 'Snow depth', 'Not Applicable', 47, 'centimeter   ', 'Snow', 'Field Observation', 0, 104, 'day', 'Sporadic', 'Climate', 1, 'Measured by volunteers from Brdy', 1, 'Brdská stopa', 'Volunteers from tbe Brdy mountain guard (HS Brdy) and other cross-skiers measure snow depth in Brdy mountains.', 'http://www.brdskastopa.cz', 0, '0', '2011-12-16 16:00:00', '2012-01-25 14:00:00', '2011-12-16 15:00:00', '2012-01-25 13:00:00', 9);

--
-- Dumping data for table `Sites`
--

INSERT INTO `Sites` (`SiteID`, `SiteCode`, `SiteName`, `Latitude`, `Longitude`, `LatLongDatumID`, `SiteType`, `Elevation_m`, `VerticalDatum`, `LocalX`, `LocalY`, `LocalProjectionID`, `PosAccuracy_m`, `State`, `County`, `Comments`) VALUES
(2, 'PRA', 'Praha', 49.658056, 13.818889, 3, 'Land', 862, 'MSL', 414755, 5501283, 229, 100, 'Czech Republic', 'Středočeský kraj', NULL),
(3, 'TOK', 'Tok', 49.704722, 13.876944, 3, 'Land', 865, 'MSL', 419002, 5506376, 229, 100, 'Czech Republic', 'Středočeský kraj', NULL),
(4, 'NEP', 'Nepomuk - u Nepálu', 49.640278, 13.843611, 3, 'Land', 690, 'MSL', 416489, 5499279, 229, 500, 'Czech Republic', 'Středočeský kraj', NULL),
(5, 'ORL', 'Orlov', 49.687361, 13.950556, 3, 'Land', 650, 'MSL', 424303, 5504384, 229, 100, 'Czech Republic', 'Středočeský kraj', NULL);

--
-- Dumping data for table `Sources`
--

INSERT INTO `Sources` (`SourceID`, `Organization`, `SourceDescription`, `SourceLink`, `ContactName`, `Phone`, `Email`, `Address`, `City`, `State`, `ZipCode`, `Citation`, `MetadataID`) VALUES
(1, 'Brdská stopa', 'Volunteers from tbe Brdy mountain guard (HS Brdy) and other cross-skiers measure snow depth in Brdy mountains.', 'http://www.brdskastopa.cz', 'Brdská Stopa', 'Unknown', 'brdskastopa@hsbrdy.com', 'Unknown', 'Unknown', 'Unknown', 'Unknown', 'http://www.brdskastopa.cz', 0);

--
-- Dumping data for table `SpatialReferences`
--

INSERT INTO `SpatialReferences` (`SpatialReferenceID`, `SRSID`, `SRSName`, `IsGeographic`, `Notes`) VALUES
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
(228, 0, 'HRAP Grid Coordinate System', 0, 'Datum Name: Hydrologic Rainfall Analysis Project (HRAP) grid coordinate system  Information: a polar stereographic projection true at 60'),
(229, 32633, 'WGS 84 / UTM zone 33N', NULL, 'Datum Name: World Geodetic System 1984    Area of Use: Between 12 and 18 deg East; northern hemisphere. Australia. Papua New Guinea.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG');

--
-- Dumping data for table `Variables`
--

INSERT INTO `Variables` (`VariableID`, `VariableCode`, `VariableName`, `Speciation`, `VariableUnitsID`, `SampleMedium`, `ValueType`, `IsRegular`, `TimeSupport`, `TimeUnitsID`, `DataType`, `GeneralCategory`, `NoDataValue`) VALUES
(1, 'SN', 'Snow depth', 'Not Applicable', 47, 'Snow', 'Field Observation', 0, 0, 104, 'Sporadic', 'Climate', -9999),
(2, 'TE', 'Temperature', 'Not Applicable', 96, 'Air', 'Field Observation', 0, 0, 104, 'Sporadic', 'Climate', -9999);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
