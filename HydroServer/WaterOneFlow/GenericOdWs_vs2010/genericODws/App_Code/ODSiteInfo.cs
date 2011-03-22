using System;
using System.Collections.Generic;
using System.Configuration;
using log4net;

using WaterOneFlowImpl;
using WaterOneFlowImpl.geom;

using tableSpace = WaterOneFlow.odm.v1_1.siteInfoDataSetTableAdapters;

namespace WaterOneFlow.odws
{
    using CuahsiBuilder = WaterOneFlowImpl.v1_0.CuahsiBuilder;
    using WaterOneFlow.Schema.v1;

    using WaterOneFlow.odm.v1_1;

    using SpatialReferencesTableAdapter = tableSpace.SpatialReferencesTableAdapter;
    using sitesTableAdapter = tableSpace.sitesTableAdapter;

    /// <summary>
    /// Summary description for ODSiteInfo
    /// </summary>
    public class ODSiteInfo
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ODSiteInfo));

        public ODSiteInfo()
        {

        }



        public static siteInfoDataSet GetSiteInfoDataSet()
        {
            siteInfoDataSet ds = new siteInfoDataSet();

            SpatialReferencesTableAdapter spatialTableAdapter =
                 new SpatialReferencesTableAdapter();
            sitesTableAdapter sitesTableAdapter = new sitesTableAdapter();

            spatialTableAdapter.Connection.ConnectionString = Config.ODDB();
            sitesTableAdapter.Connection.ConnectionString = Config.ODDB();

            try
            {
                spatialTableAdapter.Fill(ds.SpatialReferences);
                sitesTableAdapter.Fill(ds.sites);
            }
            catch (Exception e)
            {
                log.Fatal("Cannot retrieve information from connection " + e.Message);//+ spatialTableAdapter.Connection.DataSource
                throw new WaterOneFlowServerException("Database error", e);
            }

            return ds;

        }


        public static siteInfoDataSet GetSiteInfoDataSet(int siteID)
        {
            siteInfoDataSet ds = new siteInfoDataSet();

            SpatialReferencesTableAdapter spatialTableAdapter =
                new SpatialReferencesTableAdapter();
            sitesTableAdapter sitesTableAdapter = new sitesTableAdapter();
            spatialTableAdapter.Connection.ConnectionString = Config.ODDB();
            sitesTableAdapter.Connection.ConnectionString = Config.ODDB();

            spatialTableAdapter.Fill(ds.SpatialReferences);
            sitesTableAdapter.FillBySiteID(ds.sites, siteID);

            return ds;

        }

        public static siteInfoDataSet GetSiteInfoDataSet(locationParam LocationParam)
        {
            return GetSiteInfoDataSet(new locationParam[] { LocationParam });
        }

        public static siteInfoDataSet GetSiteInfoDataSet(locationParam[] LocationParameters)
        {

            siteInfoDataSet ds = new siteInfoDataSet();

            SpatialReferencesTableAdapter spatialTableAdapter =
                 new SpatialReferencesTableAdapter();
            sitesTableAdapter sitesTableAdapter = new sitesTableAdapter();
            spatialTableAdapter.Connection.ConnectionString = Config.ODDB();
            sitesTableAdapter.Connection.ConnectionString = Config.ODDB();

            try
            {
                spatialTableAdapter.Fill(ds.SpatialReferences);
            }
            catch (Exception e)
            {
                log.Fatal("Cannot connect to database " + e.Message); //+ spatialTableAdapter.Connection.DataSource
                throw new WaterOneFlowServerException(e.Message);
            }
            if (LocationParameters[0].isGeometry)
            {
                if (LocationParameters[0].Geometry.GetType().Equals(typeof(box)))
                {
                    box queryBox = (box)LocationParameters[0].Geometry;
                    sitesTableAdapter.FillByBox(ds.sites,
                        queryBox.South, queryBox.North, queryBox.West, queryBox.East);
                }
            }
            else
            {
                siteInfoDataSet.sitesDataTable aSitetable = new siteInfoDataSet.sitesDataTable();

                foreach (locationParam s in LocationParameters)
                {
                    try
                    {
                        if (s.IsId)
                        {
                            int siteID = int.Parse(s.SiteCode);
                            sitesTableAdapter.FillBySiteID(aSitetable, siteID);
                        }
                        else
                        {
                            sitesTableAdapter.FillBySiteCode(aSitetable, s.SiteCode);
                        }
                        ds.sites.Merge(aSitetable);
                    }
                    catch (Exception e)
                    {
                        log.Fatal("Cannot connect to database " + e.Message); //+ sitesTableAdapter.Connection.DataSource
                        throw new WaterOneFlowServerException(e.Message);
                    }
                }
            }

            return ds;
        }


        public static SiteInfoType[] GetSitesByLocationParameters(locationParam[] locationParameters)
        {

            siteInfoDataSet sDS;
            if (locationParameters.Length > 0)
            {
                sDS = GetSiteInfoDataSet(locationParameters);

            }
            else
            {
                sDS = GetSiteInfoDataSet();
            }
            List<SiteInfoType> sites = new List<SiteInfoType>(locationParameters.Length);

            foreach (siteInfoDataSet.sitesRow s in sDS.sites)
            {
                SiteInfoType sit = row2SiteInfoElement(s, sDS);
                sites.Add(sit);
            }

            return sites.ToArray();
        }


        public static SiteInfoType row2SiteInfoElement(siteInfoDataSet.sitesRow row, siteInfoDataSet ds)
        {
            SiteInfoType sit = CuahsiBuilder.CreateASiteInfoTypeWithLatLongPoint();

            sit.siteName = !String.IsNullOrEmpty(row.SiteName) ? row.SiteName : null;

            // sit created with a single siteCode
            sit.siteCode[0].siteID = row.SiteID.ToString();
            sit.siteCode[0].Value = !String.IsNullOrEmpty(row.SiteCode) ? row.SiteCode : null;
            string siteNetwork = System.Configuration.ConfigurationManager.AppSettings["network"];
            sit.siteCode[0].network = siteNetwork;

            // we have a point
            ((LatLonPointType)sit.geoLocation.geogLocation).latitude = row.Latitude;
            ((LatLonPointType)sit.geoLocation.geogLocation).longitude = row.Longitude;
            if (row.LatLongDatumID == 0)
            {
                ((LatLonPointType)sit.geoLocation.geogLocation).srs =
                    ConfigurationManager.AppSettings["defaultSpatialReferenceSystemSRS"];
            }
            else
            {

                siteInfoDataSet.SpatialReferencesRow[] datum =
                    (siteInfoDataSet.SpatialReferencesRow[])ds.SpatialReferences.Select("SpatialReferenceID = " + row.LatLongDatumID);
                if (datum.Length > 0 && !datum[0].IsSRSIDNull())
                {
                    ((LatLonPointType)sit.geoLocation.geogLocation).srs =
                        ConfigurationManager.AppSettings["SRSPrefix"] + datum[0].SRSID;
                }
            }

            if (!row.IsElevation_mNull())
            {

                sit.elevation_m = row.Elevation_m;
                sit.elevation_mSpecified = true;

                if (!row.IsVerticalDatumNull())
                {
                    sit.verticalDatum = row.VerticalDatum;
                }
            }


            if (!row.IsLocalXNull() && !row.IsLocalYNull() && !row.IsLocalProjectionIDNull())
            {
                sit.geoLocation.localSiteXY = new SiteInfoTypeGeoLocationLocalSiteXY[1];
                SiteInfoTypeGeoLocationLocalSiteXY xy = new SiteInfoTypeGeoLocationLocalSiteXY();
                xy.X = row.LocalX;
                xy.Y = row.LocalY;
                //@TODO local XY
                siteInfoDataSet.SpatialReferencesRow[] datum =
     (siteInfoDataSet.SpatialReferencesRow[])ds.SpatialReferences.Select("SpatialReferenceID = " + row.LocalProjectionID);
                if (datum.Length > 0)
                {
                    if (!String.IsNullOrEmpty(datum[0].SRSName))
                    {
                        xy.projectionInformation = datum[0].SRSName;
                    }
                    else
                    {
                        xy.projectionInformation = ConfigurationManager.AppSettings["SRSPrefix"] + datum[0].SRSID;
                    }
                }

                sit.geoLocation.localSiteXY[0] = xy;
            }
            if (!row.IsCountyNull())
            {
                NoteType aNote =
                    CuahsiBuilder.createNote(row.County, "County", null);
                sit.note = CuahsiBuilder.addNote(sit.note, aNote);
            }
            if (!row.IsStateNull())
            {
                NoteType aNote =
                    CuahsiBuilder.createNote(row.State, "State", null);
                sit.note = CuahsiBuilder.addNote(sit.note, aNote);
            }
            if (!row.IsCommentsNull())
            {
                NoteType aNote =
                    CuahsiBuilder.createNote(row.Comments, "Site Comments", null);
                sit.note = CuahsiBuilder.addNote(sit.note, aNote);
            }
            return sit;
        }
    }
}
