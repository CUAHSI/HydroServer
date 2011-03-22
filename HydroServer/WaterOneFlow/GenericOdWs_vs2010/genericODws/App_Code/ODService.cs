using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using WaterOneFlow.Schema.v1;
using WaterOneFlowImpl;

using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Addressing;
using Microsoft.Web.Services3.Messaging;

using log4net;

namespace WaterOneFlow.odws
{
    using WaterOneFlow.odm.v1_0;
    public class ODService : IDisposable
    {
        private Cache appCache;

        private HttpContext appContext;

        private VariablesDataset vds;
        /* This is now done in the global.asax file
        // this got cached, which cause the name to be localhost        
       */
        private string serviceUrl;
        private string serviceName;


        private static readonly ILog log = LogManager.GetLogger(typeof(ODService));
        private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");
        private static readonly Logging queryLog2 = new Logging();

        public ODService(HttpContext aContext)
        {

            log.Debug("Starting " + System.Configuration.ConfigurationManager.AppSettings["network"]);
            appContext = aContext;
            // This is now done in the global.asax file
            // this got cached, which cause the name to be localhost
            serviceName = ConfigurationManager.AppSettings["GetValuesName"];
            Boolean odValues = Boolean.Parse(ConfigurationManager.AppSettings["UseODForValues"]);
            if (odValues)
            {
                string Port = aContext.Request.ServerVariables["SERVER_PORT"];

                if (Port == null || Port == "80" || Port == "443")
                    Port = "";
                else
                    Port = ":" + Port;



                string Protocol = aContext.Request.ServerVariables["SERVER_PORT_SECURE"];
                if (Protocol == null || Protocol == "0")
                    Protocol = "http://";
                else
                 Protocol = "https://";

                // *** Figure out the base Url which points at the application's root

                serviceUrl = Protocol + aContext.Request.ServerVariables["SERVER_NAME"] +
                                            Port +
                                            aContext.Request.ApplicationPath
                                            + "/" + ConfigurationManager.AppSettings["asmxPage"];

            }
            else
            {
                serviceUrl = ConfigurationManager.AppSettings["externalGetValuesService"];
            }

 

        }

        #region Site Information

        public SiteInfoResponseType GetSiteInfo(string locationParameter)
        {
            Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
 
            queryLog2.LogStart(Logging.Methods.GetSiteInfo, locationParameter,
                appContext.Request.UserHostName);
            locationParam lp = null;
            try
            {
                lp = new locationParam(locationParameter);
                if (lp.isGeometry)
                {
                    String error = "Location by Geometry not accepted: " + locationParameter;
                    log.Debug(error);
                    throw new WaterOneFlowException(error);
                }
            }
            catch (WaterOneFlowException we)
            {
                //waterLog.WriteEntry("Bad SiteID:" + siteId, EventLogEntryType.Information);
                log.Error(we.Message);
                throw;
            }
            catch (Exception e)
            {
                // waterLog.WriteEntry("Uncaught exception:" + e.Message, EventLogEntryType.Error);
                String error =
                    "Sorry. Your submitted site ID for this getSiteInfo request caused an problem that we failed to catch programmatically: " +
                    e.Message;
                log.Error(error);
                throw new WaterOneFlowException(error);
            }
            GetSiteInfoOD getSiteInfo = new GetSiteInfoOD();

            SiteInfoResponseType resp = getSiteInfo.GetSiteInfo(lp);

            // add service location using the app context
            // for ODM, we one only seriesCatalog
            // String serviceName = (String) appContext.Session["serviceName"];
            // String serviceUrl = (String) appContext.Session["serviceUrl"];
            if (resp.site[0].seriesCatalog.Length > 0)
            {
                resp.site[0].seriesCatalog[0].menuGroupName = serviceName;
                resp.site[0].seriesCatalog[0].serviceWsdl = serviceUrl;
            }
            queryLog2.LogEnd(Logging.Methods.GetSiteInfo,
                locationParameter,
                timer.ElapsedMilliseconds.ToString(),
                resp.site.Length.ToString(),
                    appContext.Request.UserHostName);

            return resp;
        }


        public SiteInfoResponseType GetSites(string[] locationIDs)
        {
            Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
            GetSitesOD obj = new GetSitesOD();

            string location = null;
            if (locationIDs != null)
            {
                location = locationIDs.ToString();
            }
            queryLog2.LogStart(Logging.Methods.GetSites, location,
                appContext.Request.UserHostName);

            SiteInfoResponseType resp = obj.GetSites(locationIDs);

            queryLog2.LogEnd(Logging.Methods.GetSites,
                locationIDs.ToString(),
                timer.ElapsedMilliseconds.ToString(),
                resp.site.Length.ToString(),
                appContext.Request.UserHostName);

            return resp;
        }

        #endregion


        #region variable


        public VariablesResponseType GetVariableInfo(String VariableParameter)
        {
            Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
            GetVariablesOD obj = new GetVariablesOD();
            //queryLog.InfoFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}",
            //   System.Configuration.ConfigurationManager.AppSettings["network"], // network
            //   "GetVariableInfo", // method
            //   null, //locaiton
            //   VariableParameter, //variable
            //   null, // startdate
            //   null, //enddate
            //  String.Empty, // processing time
            //   String.Empty // count 
            //   );
            queryLog2.LogStart(Logging.Methods.GetVariables, VariableParameter,
                  appContext.Request.UserHostName);

            VariablesResponseType resp = obj.GetVariableInfo(VariableParameter);

            queryLog2.LogEnd(Logging.Methods.GetVariables,
                VariableParameter,
                timer.ElapsedMilliseconds.ToString(),
                resp.variables.Length.ToString(),
                  appContext.Request.UserHostName);

            //           queryLog.InfoFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}",
            //System.Configuration.ConfigurationManager.AppSettings["network"], // network
            //"GetValues", // method
            //null, //locaiton
            //VariableParameter, //variable
            //null, // startdate
            //null, //enddate
            //timer.ElapsedMilliseconds, // processing time
            //resp.variables.Length // count 
            //);

            return resp;
        }

        #endregion

        #region values
        public TimeSeriesResponseType GetValues(string SiteNumber,
                                                string Variable,
                                                string StartDate,
                                                string EndDate)
        {
            Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
            GetValuesOD obj = new GetValuesOD();
            queryLog2.LogValuesStart(Logging.Methods.GetValues, // method
                             SiteNumber, //locaiton
                           Variable, //variable
                           StartDate, // startdate
                           StartDate, //enddate
                           appContext.Request.UserHostName
                           );

            TimeSeriesResponseType resp = obj.getValues(SiteNumber, Variable, StartDate, EndDate);

    
            queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                   SiteNumber, //locaiton
                   Variable, //variable
                   StartDate, // startdate
                   StartDate, //enddate
                   timer.ElapsedMilliseconds, // processing time
                   resp.timeSeries.values.value.Length, // count 
                   appContext.Request.UserHostName
                   );

            return resp;

        }

        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposeOf)
        {
            // waterLog.Dispose();
        }

        #endregion
    }
}
