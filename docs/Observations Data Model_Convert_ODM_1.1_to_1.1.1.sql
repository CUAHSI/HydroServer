----------------------------------------------------------------------------------------------------------
--Script to convert an ODM 1.1 database to ODM 1.1.1
--Created by: Jeff Horsburgh, Utah State University
--Created on: 2/15/2012

--NOTE: You should back up your database before running this script - just in case
--NOTE: When finished, you will have to go into the Sites table and input values for the SiteType field
--NOTE: After you have finished setting your SiteTypes in the Sites table you will want to run the stored
--      procedure to update your SeriesCatalog Table.
--NOTE: When finished you may also want to use ODM Tools to ensure that the SiteTypeCV table is up to date
----------------------------------------------------------------------------------------------------------

--------------------------------------------------
--Create the SiteTypeCV Table and add the CV Terms
--------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteTypeCV](
	[Term] [nvarchar](255) NOT NULL,
	[Definition] [nvarchar](max) NULL,
 CONSTRAINT [PK_SiteTypeCV] PRIMARY KEY CLUSTERED 
(
	[Term] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Aggregate groundwater use', N'An Aggregate Groundwater Withdrawal/Return site represents an aggregate of specific sites whe groundwater is withdrawn or returned which is defined by a geographic area or some other common characteristic. An aggregate groundwatergroundwater site type is used when it is not possible or practical to describe the specific sites as springs or as any type of well including ''multiple wells'', or when water-use information is only available for the aggregate. Aggregate sites that span multiple counties should be coded with 000 as the county code, or an aggregate site can be created for each county.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Aggregate surface-water-use', N'An Aggregate Surface-Water Diversion/Return site represents an aggregate of specific sites where surface water is diverted or returned which is defined by a geographic area or some other common characteristic. An aggregate surface-water site type is used when it is not possible or practical to describe the specific sites as diversions, outfalls, or land application sites, or when water-use information is only available for the aggregate. Aggregate sites that span multiple counties should be coded with 000 as the county code, or an aggregate site can be created for each county.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Aggregate water-use establishment', N'An Aggregate Water-Use Establishment represents an aggregate class of water-using establishments or individuals that are associated with a specific geographic location and water-use category, such as all the industrial users located within a county or all self-supplied domestic users in a county. The aggregate class of water-using establishments is identified using the national water-use category code and optionally classified using the Standard Industrial Classification System Code (SIC code) or North American Classification System Code (NAICS code). An aggregate water-use establishment site type is used when specific information needed to create sites for the individual facilities or users is not available or when it is not desirable to store the site-specific information in the database. Data entry rules that apply to water-use establishments also apply to aggregate water-use establishments. Aggregate sites that span multiple counties should be coded with 000 as the county code, or an aggregate site can be created for each county.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Animal waste lagoon', N'A facility for storage and/or biological treatment of wastes from livestock operations. Animal-waste lagoons are earthen structures ranging from pits to large ponds, and contain manure which has been diluted with building washwater, rainfall, and surface runoff. In treatment lagoons, the waste becomes partially liquefied and stabilized by bacterial action before the waste is disposed of on the land and the water is discharged or re-used.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Atmosphere', N'A site established primarily to measure meteorological properties or atmospheric deposition.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Canal', N'An artificial watercourse designed for navigation, drainage, or irrigation by connecting two or more bodies of water; it is larger than a ditch.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Cave', N'A natural open space within a rock formation large enough to accommodate a human. A cave may have an opening to the outside, is always underground, and sometimes submerged. Caves commonly occur by the dissolution of soluble rocks, generally limestone, but may also be created within the voids of large-rock aggregations, in openings along seismic faults, and in lava formations.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Cistern', N'An artificial, non-pressurized reservoir filled by gravity flow and used for water storage. The reservoir may be located above, at, or below ground level. The water may be supplied from diversion of precipitation, surface, or groundwater sources.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Coastal', N'An oceanic site that is located off-shore beyond the tidal mixing zone (estuary) but close enough to the shore that the investigator considers the presence of the coast to be important. Coastal sites typically are within three nautical miles of the shore.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Collector or Ranney type well', N'An infiltration gallery consisting of one or more underground laterals through which groundwater is collected and a vertical caisson from which groundwater is removed. Also known as a "horizontal well". These wells produce large yield with small drawdown.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Combined sewer', N'An underground conduit created to convey storm drainage and waste products into a wastewater-treatment plant, stream, reservoir, or disposal site.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Ditch', N'An excavation artificially dug in the ground, either lined or unlined, for conveying water for drainage or irrigation; it is smaller than a canal.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Diversion', N'A site where water is withdrawn or diverted from a surface-water body (e.g. the point where the upstream end of a canal intersects a stream, or point where water is withdrawn from a reservoir). Includes sites where water is pumped for use elsewhere.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Estuary', N'A coastal inlet of the sea or ocean; esp. the mouth of a river, where tide water normally mixes with stream water (modified, Webster). Salinity in estuaries typically ranges from 1 to 25 Practical Salinity Units (psu), as compared oceanic values around 35-psu. See also: tidal stream and coastal.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Excavation', N'An artificially constructed cavity in the earth that is deeper than the soil (see soil hole), larger than a well bore (see well and test hole), and substantially open to the atmosphere. The diameter of an excavation is typically similar or larger than the depth. Excavations include building-foundation diggings, roadway cuts, and surface mines.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Extensometer well', N'A well equipped to measure small changes in the thickness of the penetrated sediments, such as those caused by groundwater withdrawal or recharge.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Facility', N'A non-ambient location where environmental measurements are expected to be strongly influenced by current or previous activities of humans. *Sites identified with a "facility" primary site type must be further classified with one of the applicable secondary site types.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Field, Pasture, Orchard, or Nursery', N'A water-using facility characterized by an area where plants are grown for transplanting, for use as stocks for budding and grafting, or for sale. Irrigation water may or may not be applied.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Glacier', N'Body of land ice that consists of recrystallized snow accumulated on the surface of the ground and moves slowly downslope (WSP-1541A) over a period of years or centuries. Since glacial sites move, the lat-long precision for these sites is usually coarse.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Golf course', N'A place-of-use, either public or private, where the game of golf is played. A golf course typically uses water for irrigation purposes. Should not be used if the site is a specific hydrologic feature or facility; but can be used especially for the water-use sites.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Groundwater drain', N'An underground pipe or tunnel through which groundwater is artificially diverted to surface water for the purpose of reducing erosion or lowering the water table. A drain is typically open to the atmosphere at the lowest elevation, in contrast to a well which is open at the highest point.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Hydroelectric plant', N'A facility that generates electric power by converting potential energy of water into kinetic energy. Typically, turbine generators are turned by falling water.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Hyporheic-zone well', N'A permanent well, drive point, or other device intended to sample a saturated zone in close proximity to a stream.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Interconnected wells', N'Collector or drainage wells connected by an underground lateral.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Laboratory or sample-preparation area', N'A site where some types of quality-control samples are collected, and where equipment and supplies for environmental sampling are prepared. Equipment blank samples are commonly collected at this site type, as are samples of locally produced deionized water. This site type is typically used when the data are either not associated with a unique environmental data-collection site, or where blank water supplies are designated by Center offices with unique station IDs.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Lake, Reservoir, Impoundment', N'An inland body of standing fresh or saline water that is generally too deep to permit submerged aquatic vegetation to take root across the entire body (cf: wetland). This site type includes an expanded part of a river, a reservoir behind a dam, and a natural or excavated depression containing a water body without surface-water inlet and/or outlet.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Land', N'A location on the surface of the earth that is not normally saturated with water. Land sites are appropriate for sampling vegetation, overland flow of water, or measuring land-surface properties such as temperature. (See also: Wetland).')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Landfill', N'A typically dry location on the surface of the land where primarily solid waste products are currently, or previously have been, aggregated and sometimes covered with a veneer of soil. See also: Wastewater disposal and waste-injection well.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Multiple wells', N'A group of wells that are pumped through a single header and for which little or no data about the individual wells are available.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Ocean', N'Site in the open ocean, gulf, or sea. (See also: Coastal, Estuary, and Tidal stream).')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Outcrop', N'The part of a rock formation that appears at the surface of the surrounding land.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Outfall', N'A site where water or wastewater is returned to a surface-water body, e.g. the point where wastewater is returned to a stream. Typically, the discharge end of an effluent pipe.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Pavement', N'A surface site where the land surface is covered by a relatively impermeable material, such as concrete or asphalt. Pavement sites are typically part of transportation infrastructure, such as roadways, parking lots, or runways.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Playa', N'A dried-up, vegetation-free, flat-floored area composed of thin, evenly stratified sheets of fine clay, silt or sand, and represents the bottom part of a shallow, completely closed or undrained desert lake basin in which water accumulates and is quickly evaporated, usually leaving deposits of soluble salts.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Septic system', N'A site within or in close proximity to a subsurface sewage disposal system that generally consists of: (1) a septic tank where settling of solid material occurs, (2) a distribution system that transfers fluid from the tank to (3) a leaching system that disperses the effluent into the ground.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Shore', N'The land along the edge of the sea, a lake, or a wide river where the investigator considers the proximity of the water body to be important. Land adjacent to a reservoir, lake, impoundment, or oceanic site type is considered part of the shore when it includes a beach or bank between the high and low water marks.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Sinkhole', N'A crater formed when the roof of a cavern collapses; usually found in limestone areas. Surface water and precipitation that enters a sinkhole usually evaporates or infiltrates into the ground, rather than draining into a stream.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Soil hole', N'A small excavation into soil at the top few meters of earth surface. Soil generally includes some organic matter derived from plants. Soil holes are created to measure soil composition and properties. Sometimes electronic probes are inserted into soil holes to measure physical properties, and (or) the extracted soil is analyzed.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Spring', N'A location at which the water table intersects the land surface, resulting in a natural flow of groundwater to the surface. Springs may be perennial, intermittent, or ephemeral.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Storm sewer', N'An underground conduit created to convey storm drainage into a stream channel or reservoir. If the sewer also conveys liquid waste products, then the "combined sewer" secondary site type should be used.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Stream', N'A body of running water moving under gravity flow in a defined channel. The channel may be entirely natural, or altered by engineering practices through straightening, dredging, and (or) lining. An entirely artificial channel should be qualified with the "canal" or "ditch" secondary site type.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Subsurface', N'A location below the land surface, but not a well, soil hole, or excavation.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Test hole not completed as a well', N'An uncased hole (or one cased only temporarily) that was drilled for water, or for geologic or hydrogeologic testing. It may be equipped temporarily with a pump in order to make a pumping test, but if the hole is destroyed after testing is completed, it is still a test hole. A core hole drilled as a part of mining or quarrying exploration work should be in this class.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Thermoelectric plant', N'A facility that uses water in the generation of electricity from heat. Typically turbine generators are driven by steam. The heat may be caused by various means, including combustion, nuclear reactions, and geothermal processes.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Tidal stream', N'A stream reach where the flow is influenced by the tide, but where the water chemistry is not normally influenced. A site where ocean water typically mixes with stream water should be coded as an estuary.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Tunnel, shaft, or mine', N'A constructed subsurface open space large enough to accommodate a human that is not substantially open to the atmosphere and is not a well. The excavation may have been for minerals, transportation, or other purposes. See also: Excavation.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Unsaturated zone', N'A site equipped to measure conditions in the subsurface deeper than a soil hole, but above the water table or other zone of saturation.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Volcanic vent', N'Vent from which volcanic gases escape to the atmosphere. Also known as fumarole.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Waste injection well', N'A facility used to convey industrial waste, domestic sewage, brine, mine drainage, radioactive waste, or other fluid into an underground zone. An oil-test or deep-water well converted to waste disposal should be in this category. A well where fresh water is injected to artificially recharge thegroundwaterr supply or to pressurize an oil or gas production zone by injecting a fluid should be classified as a well (not an injection-well facility), with additional information recorded under Use of Site.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Wastewater land application', N'A site where the disposal of waste water on land occurs. Use "waste-injection well" for underground waste-disposal sites.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Wastewater sewer', N'An underground conduit created to convey liquid and semisolid domestic, commercial, or industrial waste into a treatment plant, stream, reservoir, or disposal site. If the sewer also conveys storm water, then the "combined sewer" secondary site type should be used.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Wastewater-treatment plant', N'A facility where wastewater is treated to reduce concentrations of dissolved and (or) suspended materials prior to discharge or reuse.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Water-distribution system', N'A site located somewhere on a networked infrastructure that distributes treated or untreated water to multiple domestic, industrial, institutional, and (or) commercial users. May be owned by a municipality or community, a water district, or a private concern.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Water-supply treatment plant', N'A facility where water is treated prior to use for consumption or other purpose.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Water-use establishment', N'A place-of-use (a water using facility that is associated with a specific geographical point location, such as a business or industrial user) that cannot be specified with any other facility secondary type. Water-use place-of-use sites are establishments such as a factory, mill, store, warehouse, farm, ranch, or bank. A place-of-use site is further classified using the national water-use category code (C39) and optionally classified using the Standard Industrial Classification System Code (SIC code) or North American Classification System Code (NAICS code). See also: Aggregate water-use-establishment.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Well', N'A hole or shaft constructed in the earth intended to be used to locate, sample, or develop groundwater, oil, gas, or some other subsurface material. The diameter of a well is typically much smaller than the depth. Wells are also used to artificially recharge groundwater or to pressurize oil and gas production zones. Additional information about specific kinds of wells should be recorded under the secondary site types or the Use of Site field. Underground waste-disposal wells should be classified as waste-injection wells.')
INSERT [dbo].[SiteTypeCV] ([Term], [Definition]) VALUES (N'Wetland', N'Land where saturation with water is the dominant factor determining the nature of soil development and the types of plant and animal communities living in the soil and on its surface (Cowardin, December 1979). Wetlands are found from the tundra to the tropics and on every continent except Antarctica. Wetlands are areas that are inundated or saturated by surface or groundwater at a frequency and duration sufficient to support, and that under normal circumstances do support, a prevalence of vegetation typically adapted for life in saturated soil conditions. Wetlands generally include swamps, marshes, bogs and similar areas. Wetlands may be forested or unforested, and naturally or artificially created.')

----------------------------------------------------------------
--Add check constraint on the "Term" field of the SiteType table
----------------------------------------------------------------
ALTER TABLE [dbo].[SiteTypeCV]  WITH CHECK ADD  CONSTRAINT [CK_SiteTypeCV_Term] CHECK  ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))
GO
ALTER TABLE [dbo].[SiteTypeCV] CHECK CONSTRAINT [CK_SiteTypeCV_Term]
GO

--------------------------------------------------
--Modify the Sites table to add the SiteType field
--------------------------------------------------
ALTER TABLE [dbo].[Sites]
ADD [SiteType] NVARCHAR(255) NULL 
GO

----------------------------------------------------------
--DELETE the SeriesCatalog table and recreate it
----------------------------------------------------------
DROP TABLE [dbo].[SeriesCatalog]
GO

CREATE TABLE [dbo].[SeriesCatalog](
	[SeriesID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NULL,
	[SiteCode] [nvarchar](50) NULL,
	[SiteName] [nvarchar](255) NULL,
	[SiteType] [nvarchar](255) NULL,
	[VariableID] [int] NULL,
	[VariableCode] [nvarchar](50) NULL,
	[VariableName] [nvarchar](255) NULL,
	[Speciation] [nvarchar](255) NULL,
	[VariableUnitsID] [int] NULL,
	[VariableUnitsName] [nvarchar](255) NULL,
	[SampleMedium] [nvarchar](255) NULL,
	[ValueType] [nvarchar](255) NULL,
	[TimeSupport] [float] NULL,
	[TimeUnitsID] [int] NULL,
	[TimeUnitsName] [nvarchar](255) NULL,
	[DataType] [nvarchar](255) NULL,
	[GeneralCategory] [nvarchar](255) NULL,
	[MethodID] [int] NULL,
	[MethodDescription] [nvarchar](max) NULL,
	[SourceID] [int] NULL,
	[Organization] [nvarchar](255) NULL,
	[SourceDescription] [nvarchar](max) NULL,
	[Citation] [nvarchar](max) NULL,
	[QualityControlLevelID] [int] NULL,
	[QualityControlLevelCode] [nvarchar](50) NULL,
	[BeginDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[BeginDateTimeUTC] [datetime] NULL,
	[EndDateTimeUTC] [datetime] NULL,
	[ValueCount] [int] NULL,
 CONSTRAINT [PK_SeriesCatalog_SeriesID] PRIMARY KEY CLUSTERED 
(
	[SeriesID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

------------------------------------------------------------------
--Add foreign key constraint for SiteType field in the Sites table
------------------------------------------------------------------
ALTER TABLE [dbo].[Sites]  WITH CHECK ADD  CONSTRAINT [FK_Sites_SiteTypeCV] FOREIGN KEY([SiteType])
REFERENCES [dbo].[SiteTypeCV] ([Term])
GO
ALTER TABLE [dbo].[Sites] CHECK CONSTRAINT [FK_Sites_SiteTypeCV]
GO

----------------------------------------------------------------------------------
--Modify the stored procedure to update the SeriesCatalogTable so it adds SiteType
----------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[spUpdateSeriesCatalog] AS

--Clear out the entire SeriesCatalog Table
DELETE FROM  [SeriesCatalog]

--Reset the primary key field
DBCC CHECKIDENT (SeriesCatalog, RESEED, 0)

--Recreate the records in the SeriesCatalog Table
INSERT INTO [SeriesCatalog]
SELECT     dv.SiteID, s.SiteCode, s.SiteName, s.SiteType, dv.VariableID, v.VariableCode, 
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
GROUP BY   dv.SiteID, s.SiteCode, s.SiteName, s.SiteType, dv.VariableID, v.VariableCode, v.VariableName, v.Speciation,
           v.VariableUnitsID, u.UnitsName, v.SampleMedium, v.ValueType, v.TimeSupport, v.TimeUnitsID, u1.UnitsName, 
		   v.DataType, v.GeneralCategory, dv.MethodID, m.MethodDescription, dv.SourceID, so.Organization, 
		   so.SourceDescription, so.Citation, dv.QualityControlLevelID, qc.QualityControlLevelCode, dv.BeginDateTime,
		   dv.EndDateTime, dv.BeginDateTimeUTC, dv.EndDateTimeUTC, dv.ValueCount
ORDER BY   dv.SiteID, dv.VariableID, v.VariableUnitsID
GO

----------------------------------------------------------------
--Execute the stored procedure to update the SeriesCatalog Table
----------------------------------------------------------------
EXEC [dbo].[spUpdateSeriesCatalog]
GO

--------------------------
--Update ODM Version Table
--------------------------
UPDATE [dbo].[ODMVersion]
SET [dbo].[ODMVersion].[VersionNumber] = '1.1.1'
GO


