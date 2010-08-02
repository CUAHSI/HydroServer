using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using log4net;

using WaterOneFlowImpl;

/// <summary>
/// Summary description for GetSiteInfoOD
/// </summary>
namespace WaterOneFlow.odws
{
    using CuahsiBuilder = WaterOneFlowImpl.v1_0.CuahsiBuilder;
    using WaterOneFlow.Schema.v1;


    using WaterOneFlow.odm.v1_1;


    public class GetSiteInfoOD
    {
        private static VariablesDataset variablesDs;
        private static readonly ILog log = LogManager.GetLogger(typeof(GetSiteInfoOD));

        public GetSiteInfoOD()
        {
            variablesDs = ODvariables.GetVariableDataSet();
        }

        public SiteInfoResponseType GetSiteInfo(locationParam locationParameter)
        {
            string Network;
            string SiteCode;

            SiteInfoResponseType result = createSiteInfoResponse(new locationParam[] { locationParameter });
            // put a no result check here
            result.queryInfo.criteria.locationParam = locationParameter.ToString(); // to string returns orignal string
            if (result.site[0].siteInfo != null)
            {
                result.site[0].siteInfo.siteCode[0].network =
                    System.Configuration.ConfigurationManager.AppSettings["network"];
            }
            else
            {
                // we only have one site... so throw the exception
                throw new WaterOneFlowException("Site '" + locationParameter.ToString() + "' Not Found");

            }
            return result;
        }

        private SiteInfoResponseType createSiteInfoResponse(locationParam[] LocationParameters)
        {
            /* for each site code, add a siteInfo type with a period of record
          * for each site
           *     createSitInfoType
           *     add to response
           *     createPeriodOfRecord
           *     add to response
           * return response
           * */
            SiteInfoResponseType response = CuahsiBuilder.CreateASetOfSiteResponses(LocationParameters.Length, 1);

            for (int i = 0; i < LocationParameters.Length; i++)
            {
                if (LocationParameters[i] == null) continue;

                response.site[i].siteInfo = getSiteInfoType(LocationParameters[i]);
                if (response.site[i].siteInfo != null)
                {
                    String aSiteID = null;

                    Nullable<int> siteIDint = null;
                    try
                    {
                        aSiteID = response.site[i].siteInfo.siteCode[0].siteID;
                    }
                    catch (NullReferenceException e)
                    {
                        String error = " no site code returned for sitecode" + LocationParameters[i];
                        log.Warn(error);
                        response.site[i].seriesCatalog = CreateSeriesCatalogRecord(LocationParameters[i], null);
                    }

                    try
                    {
                        siteIDint = Convert.ToInt32(aSiteID);
                        response.site[i].seriesCatalog = CreateSeriesCatalogRecord(LocationParameters[i], siteIDint);
                    }
                    catch (InvalidCastException e)
                    {
                        String error = " siteID was not an integer" + LocationParameters[i];
                        log.Warn(error);
                        response.site[i].seriesCatalog = CreateSeriesCatalogRecord(LocationParameters[i], null);
                    }

                }
                else
                {
                    String error = " no site code returned for sitecode" + LocationParameters[i];
                    log.Warn(error);

                }
            }

            return response;
        }

        private SiteInfoType getSiteInfoType(locationParam LocationParameter)
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
        #region Period of record
        // create period of record
        private seriesCatalogType[] CreateSeriesCatalogRecord(locationParam LocationParameter, int? siteID)
        {

            // need the siteID for the DB sites, and the siteCode for retrival from the service

            if (siteID.HasValue)
            {
                seriesCatalogDataSet seriesDataset = ODSeriesCatalog.GetSeriesCatalogDataSet(siteID.Value);
                if (seriesDataset != null && seriesDataset.SeriesCatalog.Rows.Count > 0)
                    if (seriesDataset.SeriesCatalog.Rows.Count > 0)
                    {
                        seriesCatalogType[] seriesFromDB =
                            ODSeriesCatalog.dataSet2SeriesCatalog(seriesDataset, variablesDs);
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

    }

}