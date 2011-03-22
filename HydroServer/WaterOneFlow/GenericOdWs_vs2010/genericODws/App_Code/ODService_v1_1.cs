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
using WaterOneFlow.Schema.v1_1;
using WaterOneFlowImpl;

using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Addressing;
using Microsoft.Web.Services3.Messaging;

using log4net;
using WaterOneFlowImpl.geom;

namespace WaterOneFlow.odws
{
    using WaterOneFlow.odm.v1_1;
    namespace v1_1
    {
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
                                                + "/" + ConfigurationManager.AppSettings["asmxPage_1_1"] + "?WSDL";

                }
                else
                {
                    serviceUrl = ConfigurationManager.AppSettings["externalGetValuesService"];
                }

            }

            #region Site Information
            public SiteInfoResponseType GetSiteInfo(string locationParameter)
            {
                return GetSiteInfo(new string[] { locationParameter }, true)
                ;
            }

            public SiteInfoResponseType GetSiteInfo(string[] locationParameter, Boolean IncludeSeries)
            {
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                 if (locationParameter != null)
                {
                    queryLog2.LogStart(Logging.Methods.GetSiteInfo, locationParameter.ToString(),
                                       appContext.Request.UserHostName);
                }
                else
                {
                    queryLog2.LogStart(Logging.Methods.GetSiteInfo, "NULL",
                                       appContext.Request.UserHostName);

                }
                List<locationParam> lpList = new List<locationParam>();
                try
                {
                    foreach (string s in locationParameter)
                    {
                        locationParam l = new locationParam(s);

                        if (l.isGeometry)
                        {
                            String error = "Location by Geometry not accepted: " + locationParameter;
                            log.Debug(error);
                            throw new WaterOneFlowException(error);
                        }
                        else
                        {
                            lpList.Add(l);
                        }
                    }
                }
                catch (WaterOneFlowException we)
                {
                    log.Error(we.Message);
                    throw;
                }
                catch (Exception e)
                {
                    String error =
                        "Sorry. Your submitted site ID for this getSiteInfo request caused an problem that we failed to catch programmatically: " +
                        e.Message;
                    log.Error(error);
                    throw new WaterOneFlowException(error);
                }
                GetSiteInfoOD getSiteInfo = new GetSiteInfoOD();
                SiteInfoResponseType resp = null;
                resp = getSiteInfo.GetSiteInfoResponse(lpList.ToArray(), true);
                foreach (SiteInfoResponseTypeSite site in resp.site)
                {
                    foreach (seriesCatalogType catalog in site.seriesCatalog)
                    {
                        catalog.menuGroupName = serviceName;
                        catalog.serviceWsdl = serviceUrl;
                    }
                }

                if (locationParameter != null)
                {

                    queryLog2.LogEnd(Logging.Methods.GetSiteInfo,
                                     locationParameter.ToString(),
                                     timer.ElapsedMilliseconds.ToString(),
                                     resp.site.Length.ToString(),
                                     appContext.Request.UserHostName);
                }
                else
                {
                    queryLog2.LogEnd(Logging.Methods.GetSiteInfo,
                                   "NULL",
                                   timer.ElapsedMilliseconds.ToString(),
                                   resp.site.Length.ToString(),
                                   appContext.Request.UserHostName);
                }
 
                return resp;
            }


            public SiteInfoResponseType GetSites(string[] locationIDs)
            {
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                GetSiteInfoOD obj = new GetSiteInfoOD();


                queryLog2.LogStart(Logging.Methods.GetSites, locationIDs.ToString(),
                    appContext.Request.UserHostName);

                SiteInfoResponseType resp = obj.GetSites(locationIDs, false);

                queryLog2.LogEnd(Logging.Methods.GetSites,
                    locationIDs.ToString(),
                    timer.ElapsedMilliseconds.ToString(),
                    resp.site.Length.ToString(),
                    appContext.Request.UserHostName);

                return resp;
            }

            public SiteInfoResponseType GetSitesInBox(
                float west, float south, float east, float north,
                Boolean IncludeSeries
                )
            {
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                GetSiteInfoOD obj = new GetSiteInfoOD();

                box queryBox = new box(west, south, east, north);

                queryLog2.LogStart(Logging.Methods.GetSitesInBoxObject, queryBox.ToString(),
                     appContext.Request.UserHostName);

                SiteInfoResponseType resp = obj.GetSitesByBox(queryBox, IncludeSeries);

                queryLog2.LogEnd(Logging.Methods.GetSitesInBoxObject,
                      queryBox.ToString(),
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

                queryLog2.LogStart(Logging.Methods.GetVariables, VariableParameter,
                      appContext.Request.UserHostName);

                VariablesResponseType resp = obj.GetVariableInfo(VariableParameter);

                queryLog2.LogEnd(Logging.Methods.GetVariables,
                    VariableParameter,
                    timer.ElapsedMilliseconds.ToString(),
                    resp.variables.Length.ToString(),
                      appContext.Request.UserHostName);

 
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
                // queryLog.Info("GetValues|" + SiteNumber + "|" + Variable + "|" + StartDate + "|" + EndDate);
                //String network,method,location, variable, start, end, , processing time,count
                queryLog2.LogValuesStart(Logging.Methods.GetValues, // method
                                 SiteNumber, //locaiton
           Variable, //variable
           StartDate, // startdate
           EndDate, //enddate
           appContext.Request.UserHostName);

                TimeSeriesResponseType resp = obj.getValues(SiteNumber, Variable, StartDate, EndDate);

                queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                 SiteNumber, //locaiton
           Variable, //variable
           StartDate, // startdate
           EndDate, //enddate
           timer.ElapsedMilliseconds, // processing time
                    // assume one for now 
           resp.timeSeries[0].values[0].value.Length, // count 
                    appContext.Request.UserHostName);

                return resp;

            }

            public TimeSeriesResponseType GetValuesForASite(string site, string startDate, string endDate)
            {
                {
                    Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                    GetValuesOD obj = new GetValuesOD();

                    //String network,method,location, variable, start, end, , processing time,count
                    queryLog2.LogValuesStart(Logging.Methods.GetValuesForSiteObject, // method
                                     site, //locaiton
                                   "ALL", //variable
                                   startDate, // startdate
                                   endDate, //enddate
                                   appContext.Request.UserHostName);

                    TimeSeriesResponseType resp = obj.GetValuesForSiteVariable(site, startDate, endDate);

                    //     //String network,method,location, variable, start, end, , processing time,count
                    //     queryLog.InfoFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}",
                    //System.Configuration.ConfigurationManager.AppSettings["network"], // network
                    //"GetValues", // method
                    //SiteNumber, //locaiton
                    //Variable, //variable
                    //StartDate, // startdate
                    //StartDate, //enddate
                    //timer.ElapsedMilliseconds, // processing time
                    //resp.timeSeries.values.value.Length // count 
                    //,
                    //         appContext.Request.UserHostName);
                    queryLog2.LogValuesEnd(Logging.Methods.GetValuesForSiteObject,
                                   site, //locaiton
                                   "ALL", //variable
                                   startDate, // startdate
                                   endDate, //enddate
                                   timer.ElapsedMilliseconds, // processing time
                                            // assume one for now 
                                   -9999, // May need to count all. 
                                   appContext.Request.UserHostName);

                    return resp;

                }
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
}
