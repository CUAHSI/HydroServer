using System;
using System.Collections.Generic;
using System.Configuration;
using log4net;

using WaterOneFlow.Schema.v1_1;
using WaterOneFlowImpl;
using WaterOneFlowImpl.geom;
using WaterOneFlowImpl.v1_1;

using tableSpace = WaterOneFlow.odm.v1_1.siteInfoDataSetTableAdapters;

namespace WaterOneFlow.odws
{
    using WaterOneFlow.odm.v1_1;

    using SpatialReferencesTableAdapter = tableSpace.SpatialReferencesTableAdapter;
    using sitesTableAdapter = tableSpace.sitesTableAdapter;

    namespace v1_1
    {
        /// <summary>
        /// Summary description for ODSiteInfo
        /// </summary>
        public class ODSiteInfo
        {
            private static readonly ILog log = LogManager.GetLogger(typeof(ODSiteInfo));

            public ODSiteInfo()
            {
                //
                // TODO: Add constructor logic here
                //
            }



            public static siteInfoDataSet GetSiteInfoDataSet()
            {
                siteInfoDataSet ds = new siteInfoDataSet();

                SpatialReferencesTableAdapter spatialTableAdapter =
                    new SpatialReferencesTableAdapter();
                sitesTableAdapter sitesTableAdapter = new sitesTableAdapter();

                spatialTableAdapter.Connection.ConnectionString = odws.Config.ODDB();
                sitesTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

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
                spatialTableAdapter.Connection.ConnectionString = odws.Config.ODDB();
                sitesTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

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
                siteInfoDataSet ds = CreateBaseSiteInfoDataset();


                if (LocationParameters[0].isGeometry)
                {
                    if (LocationParameters[0].Geometry.GetType().Equals(typeof(box)))
                    {
                        box queryBox = (box)LocationParameters[0].Geometry;
                        GetSiteInfoDataSet(queryBox, ds);
                    }
                }
                else
                {
                    sitesTableAdapter sitesTableAdapter = CreateSitesTableAdapter();
                    foreach (locationParam s in LocationParameters)
                    {
                        try
                        {
                            siteInfoDataSet.sitesDataTable aSitetable = new siteInfoDataSet.sitesDataTable();

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
                            log.Fatal("Cannot connect to database " + e.Message);
                            //+ sitesTableAdapter.Connection.DataSource
                            throw new WaterOneFlowServerException(e.Message);
                        }
                    }
                }
                return ds;
            }

            public static siteInfoDataSet GetSiteInfoDataSet(box geomBox)
            {
                siteInfoDataSet ds = CreateBaseSiteInfoDataset();
                GetSiteInfoDataSet(geomBox, ds);
                return ds;
            }

            private static void GetSiteInfoDataSet(box geomBox, siteInfoDataSet ds)
            {
                sitesTableAdapter sitesTableAdapter = CreateSitesTableAdapter();
                try
                {
                    sitesTableAdapter.FillByBox(ds.sites,
                                            geomBox.South, geomBox.North, geomBox.West, geomBox.East);
                }
                catch (Exception e)
                {
                    log.Fatal("Cannot connect to database " + e.Message);
                    //+ sitesTableAdapter.Connection.DataSource
                    throw new WaterOneFlowServerException(e.Message);
                }
            }

            private static sitesTableAdapter CreateSitesTableAdapter()
            {
                sitesTableAdapter sitesTableAdapter = new sitesTableAdapter();
                sitesTableAdapter.Connection.ConnectionString = odws.Config.ODDB();
                return sitesTableAdapter;
            }

            private static siteInfoDataSet CreateBaseSiteInfoDataset()
            {
                siteInfoDataSet ds = new siteInfoDataSet();
                SpatialReferencesTableAdapter spatialTableAdapter =
                     new SpatialReferencesTableAdapter();
                sitesTableAdapter sitesTableAdapter = new sitesTableAdapter();
                spatialTableAdapter.Connection.ConnectionString = odws.Config.ODDB();
                sitesTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                try
                {
                    spatialTableAdapter.Fill(ds.SpatialReferences);
                }
                catch (Exception e)
                {
                    log.Fatal("Cannot connect to database " + e.Message); // + spatialTableAdapter.Connection.DataSource
                    throw new WaterOneFlowServerException(e.Message);
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
            public static IEnumerable<SiteInfoType> GetSitesByBox(box queryBox)
            {

                siteInfoDataSet sDS;

                sDS = GetSiteInfoDataSet(queryBox);
                if (sDS.sites.Count == 0)
                {
                    throw new WaterOneFlowException("No Sites found in specified region: " + queryBox.ToString());
                }
                else
                {
                    List<SiteInfoType> sites = new List<SiteInfoType>(sDS.sites.Count);

                    foreach (siteInfoDataSet.sitesRow s in sDS.sites)
                    {
                        SiteInfoType sit = row2SiteInfoElement(s, sDS);
                        yield return sit;
                    }
                }

            }


            public static SiteInfoType row2SiteInfoElement(siteInfoDataSet.sitesRow row, siteInfoDataSet ds)
            {
                SiteInfoType sit = CuahsiBuilder.CreateASiteInfoTypeWithLatLongPoint();

                sit.siteName = row.SiteName;

                // sit created with a single siteCode
                sit.siteCode[0].siteID = row.SiteID;
                sit.siteCode[0].siteIDSpecified = true;
                sit.siteCode[0].Value = row.SiteCode;
                string siteNetwork = System.Configuration.ConfigurationManager.AppSettings["network"];
                sit.siteCode[0].network = siteNetwork;

                // we ALWAYS have a point in ODM 1.1
                /* just check to make sure that they are not the defaults
                 * Should validate thet they are inwithin +-180/+-90
                 * */
                if (!row.Longitude.Equals(0) && !row.Latitude.Equals(0))
                {
                    ((LatLonPointType)sit.geoLocation.geogLocation).latitude = row.Latitude;
                    ((LatLonPointType)sit.geoLocation.geogLocation).longitude = row.Longitude;
                    if (row.LatLongDatumID.Equals(0))
                    {
                        ((LatLonPointType)sit.geoLocation.geogLocation).srs =
                            ConfigurationManager.AppSettings["defaultSpatialReferenceSystemSRS"];
                    }
                    else
                    {

                        siteInfoDataSet.SpatialReferencesRow[] datum =
                            (siteInfoDataSet.SpatialReferencesRow[])ds.SpatialReferences.Select("SpatialReferenceID = " + row.LatLongDatumID);
                        if (datum.Length > 0 )
                        { if (!datum[0].IsSRSIDNull() ) {
                            ((LatLonPointType)sit.geoLocation.geogLocation).srs =
                                ConfigurationManager.AppSettings["SRSPrefix"] + datum[0].SRSID;
                        } else if (!string.IsNullOrEmpty(datum[0].SRSName))
                        {
                            ((LatLonPointType) sit.geoLocation.geogLocation).srs = datum[0].SRSName;
                        }
                        } 
                    }
                }
                else
                {
                    sit.geoLocation.geogLocation = null;
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
                          
                            xy.projectionInformation = "Not Specified";
                        }
                    }

                    sit.geoLocation.localSiteXY[0] = xy;
                }
                if (!row.IsCountyNull())
                {

                    PropertyType aNote =
                        CuahsiBuilder.createProperty(row.County, "County", null);
                    sit.siteProperty = CuahsiBuilder.addProperty(sit.siteProperty, aNote);
                }
                if (!row.IsStateNull())
                {
                    PropertyType aNote =
                        CuahsiBuilder.createProperty(row.State, "State", null);
                    sit.siteProperty = CuahsiBuilder.addProperty(sit.siteProperty, aNote);
                }
                if (!row.IsCommentsNull())
                {
                    PropertyType aNote =
                        CuahsiBuilder.createProperty(row.Comments, "Site Comments", null);
                    sit.siteProperty = CuahsiBuilder.addProperty(sit.siteProperty, aNote);
                }
                if (!row.IsPosAccuracy_mNull())
                {
                    PropertyType aNote =
                        CuahsiBuilder.createProperty(row.PosAccuracy_m.ToString(), "PosAccuracy_m", null);
                    sit.siteProperty = CuahsiBuilder.addProperty(sit.siteProperty, aNote);
                }
                return sit;
            }
        }
    }
}
