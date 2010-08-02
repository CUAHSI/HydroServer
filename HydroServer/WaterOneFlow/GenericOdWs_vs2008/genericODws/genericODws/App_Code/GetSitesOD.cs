using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using log4net;

using WaterOneFlowImpl;
using WaterOneFlowImpl.v1_0;

/// <summary>
/// Summary description for GetSitesOD
/// </summary>
namespace WaterOneFlow.odws
{
    using WaterOneFlow.Schema.v1;
    
    using WaterOneFlow.odm.v1_1;
    using CuahsiBuilder = WaterOneFlowImpl.v1_0.CuahsiBuilder;

    public class GetSitesOD
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GetSitesOD));

        /* this will handle the getSites web service call.
         * It is responsible for managing the DB connection and sitesInfo object
         * */
        private siteInfoDataSet siteInfoDs;
        
        public GetSitesOD()
        {
            //
            // TODO: Add constructor logic here
            //
            
            
        }
         
         public SiteInfoResponseType GetSites(string[] locationParameters)
        {
            XmlDocument XMLResponse = new XmlDocument();

            locationParameters = WSUtils.removeEmptyStrings(locationParameters);
            //string[] siteCodes = Array.ConvertAll(locationParameters, new Converter<string, string>(locationParam.getSiteCode));
            List<locationParam> siteCodes = new List<locationParam>(locationParameters.Length);
             foreach(String s in locationParameters)
             {
                 locationParam lp = new locationParam(s);
                 siteCodes.Add(lp);
             }    
          
             SiteInfoResponseType result = CreateSitesResponse(siteCodes.ToArray());


            return result;
        }

        /// <summary>
        /// createSiteInfoResponse populates a SiteInfoResponseType.
        /// It is used the webmethod getSiteInfo.
        /// designed for multiple site codes
        /// This method will be slow if the information has never been cached.
        /// </summary>
        /// <param name="LocationParams"></param>
        private SiteInfoResponseType CreateSitesResponse(locationParam[] LocationParams)
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
           
          
            SiteInfoType[] sites = ODSiteInfo.GetSitesByLocationParameters(LocationParams);
            if (sites.Length == 0)
            {
                throw new WaterOneFlowException("No Sites found");
            }
            response = CuahsiBuilder.CreateASetOfSiteResponses(sites.Length, 1);
                for (int i = 0; i < sites.Length; i++)
            {
                response.site[i].siteInfo = sites[i];
                String aSiteID = response.site[i].siteInfo.siteCode[0].siteID;
               
                // no period of record
            }
       
            return response;
        }
        
  
    }
    
}