using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using log4net;
using WaterOneFlow.Schema.v1_1;
using WaterOneFlowImpl.v1_1;
using WaterOneFlowImpl.geom;
using WaterOneFlowImpl;


/// <summary>
/// Summary description for GetSiteInfoOD
/// </summary>
namespace WaterOneFlow.odws
{
    using WaterOneFlow.odm.v1_1;
    using locationParam = WaterOneFlowImpl.locationParam;
    using WSUtils = WaterOneFlowImpl.WSUtils;

    namespace v1_1
    {

        public class GetSiteInfoOD
        {
            private static VariablesDataset variablesDs;
            private static ControlledVocabularyDataset vocabulariesDs;
            private static readonly ILog log = LogManager.GetLogger(typeof(GetSiteInfoOD));

            public GetSiteInfoOD()
            {
                variablesDs = ODvariables.GetVariableDataSet();
                vocabulariesDs = ODvocabularies.GetVocabularyDataset();
            }

            public SiteInfoResponseType GetSiteInfoResponse(locationParam locationParameter)
            {
                string Network;
                string SiteCode;

                SiteInfoResponseType result = createSiteInfoResponse(new locationParam[] { locationParameter }, true);
                // put a no result check here
               
                //result.queryInfo.criteria.locationParam = locationParameter.ToString(); // to string returns orignal string
                result.queryInfo = CuahsiBuilder.CreateQueryInfoType("GetSiteInfo", new string[] { locationParameter.ToString() }, null, null, null, null);
                if (result.site[0].siteInfo != null)
                {
                    result.site[0].siteInfo.siteCode[0].network =
                        System.Configuration.ConfigurationManager.AppSettings["network"];
                }
                else
                {
                    // we only have one site... so throw the exception
                    //  result.queryInfo.note = CuahsiBuilder.addNote(result.queryInfo.note,CuahsiBuilder.createNote("Site not found"));
                    throw new WaterOneFlowException("Site '" + locationParameter.ToString() + "' Not Found");

                }
                return result;
            }
            public SiteInfoResponseType GetSiteInfoResponse(locationParam[] LocationParameters, Boolean IncludeSeries)
            {
                SiteInfoResponseType result = createSiteInfoResponse(LocationParameters, IncludeSeries);
                string[] lps = Array.ConvertAll<locationParam, string>(LocationParameters, Convert.ToString);
                //result.queryInfo = CreateQueryInfo(lps);
                result.queryInfo = CuahsiBuilder.CreateQueryInfoType("GetSiteInfo", lps, null, null, null, null);

                return result;
            }


            private SiteInfoResponseType createSiteInfoResponse(locationParam[] LocationParameters, Boolean IncludeSeries)
            {
                // WSUtils.removeEmptyStrings(LocationParameters);
                /* for each site code, add a siteInfo type with a period of record
                // for each site
                 *     createSitInfoType
                 *     add to response
                 *     createPeriodOfRecord
                 *     add to response
                 * return response
                 * */
                SiteInfoResponseType response = CuahsiBuilder.CreateASetOfSiteResponses(LocationParameters.Length, 1);
                List<locationParam> lpList = new List<locationParam>(LocationParameters);

                foreach (locationParam lp in lpList)
                {
                    if (lp == null) lpList.Remove(lp);
                }
                List<SiteInfoResponseTypeSite> sitesList = new List<SiteInfoResponseTypeSite>(lpList.Count);

                foreach (SiteInfoType sit in getSiteInfoType(lpList))
                {
                    SiteInfoResponseTypeSite site = CreateSite(sit, IncludeSeries);
                    if (site != null) sitesList.Add(site);
                }

                response.site = sitesList.ToArray();

                return response;
            }

            public static SiteInfoResponseTypeSite CreateSite(SiteInfoType sit, Boolean addSeriesCatalog)
            {
                SiteInfoResponseTypeSite site = new SiteInfoResponseTypeSite();
                if (sit != null)
                {
                    site.siteInfo = sit;
                    if (addSeriesCatalog)
                    {
                        int? aSiteID = null;

                        Nullable<int> siteIDint = null;
                        try
                        {
                            aSiteID = sit.siteCode[0].siteID;
                        }
                        catch (NullReferenceException e)
                        {
                            String error = " no site code returned for sitecode" + sit.siteCode[0].network + ":" + sit.siteCode[0].Value;
                            log.Warn(error);
                            site.seriesCatalog = CreateSeriesCatalogRecord(null);
                        }

                        try
                        {
                            siteIDint = Convert.ToInt32(aSiteID);
                        }
                        catch (InvalidCastException e)
                        {
                            String error = " siteID was not an integer" + sit.siteCode[0].network + ":" + sit.siteCode[0].Value;
                            log.Warn(error);
                            site.seriesCatalog = CreateSeriesCatalogRecord(null);
                        }
                        try
                        {
                            site.seriesCatalog = CreateSeriesCatalogRecord(siteIDint);
                        }
                        catch (InvalidCastException e)
                        {
                            String error = " Error creating series record for " + sit.siteCode[0].network + ":" + sit.siteCode[0].Value;
                            log.Warn(error);
                            site.seriesCatalog = CreateSeriesCatalogRecord(null);
                        }
                    }
                }
                else
                {
                    String error = " no site code returned for sitecode" + sit.siteCode[0].network + ":" + sit.siteCode[0].Value; ;
                    log.Warn(error);

                }
                return site;
            }
            private static SiteInfoType getSiteInfoType(locationParam LocationParameter)
            {
                SiteInfoType sit;

                //   look in memory
                //           sit = (SiteInfoType)appCache[sitCache + siteCode];
                //         if (sit != null) return sit;

                //ok, try the database
                SiteInfoType[] sites = ODSiteInfo.GetSitesByLocationParameters(new locationParam[] { LocationParameter });
                if (sites == null || sites.Length == 0)
                {
                    return null;
                }
                else

                    if (sites != null && sites.Length == 1)
                    {
                        return sites[0];
                    }
                    else
                    {
                        // had better be only one
                        String error = "More than one site with SiteCode '" + LocationParameter + "'";
                        log.Error(error);
                        throw new WaterOneFlowException(error);
                    }



                return sit;

            }


            private IEnumerable<SiteInfoType> getSiteInfoType(List<locationParam> LocationParameter)
            {
                SiteInfoType sit;

                //   look in memory
                //           sit = (SiteInfoType)appCache[sitCache + siteCode];
                //         if (sit != null) return sit;

                //ok, try the database
                SiteInfoType[] sites = ODSiteInfo.GetSitesByLocationParameters(LocationParameter.ToArray());
                if (sites == null || sites.Length == 0)
                {
                    yield return null;
                }
                foreach (SiteInfoType type in sites)
                {
                    yield return type;
                }
            }

            #region Period of record
            // create period of record
            private static seriesCatalogType[] CreateSeriesCatalogRecord(int? siteID)
            {

                // need the siteID for the DB sites, and the siteCode for retrival from the service

                if (siteID.HasValue)
                {
                    seriesCatalogDataSet seriesDataset = ODSeriesCatalog.GetSeriesCatalogDataSet(siteID.Value);
                    if (seriesDataset != null && seriesDataset.SeriesCatalog.Rows.Count > 0)
                        if (seriesDataset.SeriesCatalog.Rows.Count > 0)
                        {
                            seriesCatalogType[] seriesFromDB =
                                ODSeriesCatalog.dataSet2SeriesCatalog(seriesDataset, variablesDs, vocabulariesDs);
                            if (seriesFromDB != null && seriesFromDB.Length > 0)
                            {
                                return seriesFromDB;
                            }
                        }
                }


                // send back empty catalog
                List<seriesCatalogType> seriesList = new List<seriesCatalogType>();
                seriesList.Add(new seriesCatalogType());
                return seriesList.ToArray();


            }

            #endregion

            public SiteInfoResponseType GetSites(string[] locationParameters, Boolean includeSeries)
            {


                locationParameters = WSUtils.removeEmptyStrings(locationParameters);

                List<locationParam> siteCodes = new List<locationParam>(locationParameters.Length);
                foreach (String s in locationParameters)
                {
                    locationParam lp = new locationParam(s);
                    siteCodes.Add(lp);
                }
                SiteInfoType[] sites = ODSiteInfo.GetSitesByLocationParameters(siteCodes.ToArray());
                SiteInfoResponseType result = CreateSitesResponse(sites, includeSeries);

                if (locationParameters.Length == 0)
                {
                    result.queryInfo = CuahsiBuilder.CreateQueryInfoType("GetSites");
                    NoteType note = CuahsiBuilder.createNote("ALL Sites(empty request)");
                    result.queryInfo.note = CuahsiBuilder.addNote(null, note);
                    
                }
                else
                {
                    result.queryInfo = CuahsiBuilder.CreateQueryInfoType("GetSites", locationParameters, null, null, null, null);
                }
                return result;
            }

            public SiteInfoResponseType GetSitesByBox(box queryBox, Boolean includeSeries)
            {



                IEnumerable<SiteInfoType> sites = ODSiteInfo.GetSitesByBox(queryBox);
                SiteInfoResponseType result = CreateSitesResponse(sites, includeSeries);

               // result.queryInfo = CreateQueryInfo(new string[] { queryBox.ToString() });
                result.queryInfo = CuahsiBuilder.CreateQueryInfoType("GetSitesByBox");
              CuahsiBuilder.AddQueryInfoParameter(result.queryInfo, "north", queryBox.North.ToString());
                CuahsiBuilder.AddQueryInfoParameter(result.queryInfo,"south", queryBox.South.ToString());
                CuahsiBuilder.AddQueryInfoParameter(result.queryInfo,"east", queryBox.East.ToString());
               CuahsiBuilder.AddQueryInfoParameter(result.queryInfo,"west", queryBox.West.ToString());
                CuahsiBuilder.AddQueryInfoParameter(result.queryInfo,"includeSeries", includeSeries.ToString());
              
                return result;
            }

            /// <summary>
            /// createSiteInfoResponse populates a SiteInfoResponseType.
            /// It is used the webmethod getSiteInfo.
            /// designed for multiple site codes
            /// This method will be slow if the information has never been cached.
            /// </summary>
            /// <param name="sites"></param>
            /// <param name="includeSeries"></param>
            private SiteInfoResponseType CreateSitesResponse(IEnumerable<SiteInfoType> sites, Boolean includeSeries)
            {
                /* for each site code, add a siteInfo type with a period of record
                // for each site
                 *     createSitInfoType
                 *     add to response
                 *     createPeriodOfRecord
                 *     add to response
                 * return response
                 * */
                SiteInfoResponseType response;

                response = CuahsiBuilder.CreateASetOfSiteResponses(1, 1);
                List<SiteInfoResponseTypeSite> sitesList =
                    new List<SiteInfoResponseTypeSite>();
                foreach (SiteInfoType site in sites)
                {
                    sitesList.Add(GetSiteInfoOD.CreateSite(site, includeSeries));

                }
                if (sitesList.Count > 0)
                {
                    response.site = sitesList.ToArray();
                }
                else
                {
                    throw new WaterOneFlowException("No Sites found in specified region: ");
                }

                return response;
            }



            private static string Array2String(Object[] array)
            {
                if (array != null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (object o in array)
                    {
                        sb.AppendFormat("{0},", o.ToString());
                    }
                    return sb.ToString();
                }
                return String.Empty;
            }
        }
    }
}