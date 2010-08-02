
using System;
using System.Configuration;
using System.Text;
using log4net;
using WaterOneFlowImpl;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Services.Protocols;
using WaterOneFlow.Schema.v1_1;
using WaterOneFlow;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Addressing;
using Microsoft.Web.Services3.Messaging;
using WaterOneFlowImpl.geom;


namespace WaterOneFlow.odws
{
    namespace v1_1
    {
        using ConstantsNamespace = WaterOneFlowImpl.v1_1.Constants;

        using IService = WaterOneFlow.v1_1.IService;

       public class Config 

    {
        public static string ODDB()
        {
            if (ConfigurationManager.ConnectionStrings["ODDB"]!= null)
            {
                return ConfigurationManager.ConnectionStrings["ODDB"].ConnectionString;
            } else
            {
                return null;
            }
        }
    }

        [WebService(Name = WsDescriptions.WsDefaultName,
   Namespace = ConstantsNamespace.WS_NAMSPACE,
    Description = WsDescriptions.SvcDevelopementalWarning + WsDescriptions.WsDefaultDescription)]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [SoapActor("*")]
        public class Service : WebService, IService
        {
            

            protected ODService ODws;

            private Boolean useODForValues;
            private Boolean requireAuthToken;

            private static readonly ILog log = LogManager.GetLogger(typeof(Service));
            private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");

            public Service()
            {
                //log4net.Util.LogLog.InternalDebugging = true; 

                ODws = new ODService(this.Context);//INFO we can extend this for other service types


                try
                {
                    useODForValues = Boolean.Parse(ConfigurationManager.AppSettings["UseODForValues"]);
                }
                catch (Exception e)
                {
                    String error = "Missing or invalid value for UseODForValues. Must be true or false";
                    log.Fatal(error);

                    throw new SoapException("Invalid Server Configuration. " + error,
                                         new XmlQualifiedName(SoapExceptionGenerator.ServerError));
                }

                try
                {
                    requireAuthToken = Boolean.Parse(ConfigurationManager.AppSettings["requireAuthToken"]);
                }
                catch (Exception e)
                {
                    String error = "Missing or invalid value for requireAuthToken. Must be true or false";
                    log.Fatal(error);
                    throw new SoapException(error,
                                            new XmlQualifiedName(SoapExceptionGenerator.ServerError));

                }

            }


            #region IService Members

            public string GetSites(string[] SiteNumbers, String authToken)
            {
                SiteInfoResponseType aSite = GetSitesObject(SiteNumbers, authToken);
                string xml = WSUtils.ConvertToXml(aSite, typeof(SiteInfoResponseType));
                return xml;

            }

            public virtual string GetSiteInfo(string SiteNumber, String authToken)
            {
                SiteInfoResponseType aSite = GetSiteInfoObject(SiteNumber, authToken);
                string xml = WSUtils.ConvertToXml(aSite, typeof(SiteInfoResponseType));
                return xml;
            }

            public string GetVariableInfo(string variable, String authToken)
            {
                VariablesResponseType aVType = GetVariableInfoObject(variable, authToken);
                string xml = WSUtils.ConvertToXml(aVType, typeof(VariablesResponseType));
                return xml;
            }

 
            public SiteInfoResponseType GetSitesObject(string[] site, String authToken)
            {
                GlobalClass.WaterAuth.SitesServiceAllowed(Context, authToken);
                
                try
                {
                    return ODws.GetSites(site);
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }
            }

            public virtual SiteInfoResponseType GetSiteInfoObject(string site, String authToken)
            {
                GlobalClass.WaterAuth.SiteInfoServiceAllowed(Context, authToken);
                
                try
                {
                    return ODws.GetSiteInfo(site);
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }


            }

            public VariablesResponseType GetVariableInfoObject(string variable, String authToken)
            {
                GlobalClass.WaterAuth.VariableInfoServiceAllowed(Context, authToken);
                
                try
                {
                    return ODws.GetVariableInfo(variable);
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }

            }

            public virtual string GetValues( string location, string variable,  string startDate, string endDate, String authToken)
            {
                TimeSeriesResponseType aSite = GetValuesObject(location, variable, startDate, endDate, null);
                return WSUtils.ConvertToXml(aSite, typeof(TimeSeriesResponseType));
            }

            public virtual TimeSeriesResponseType GetValuesObject( string location, string variable, string startDate,  string endDate, String authToken)
            {
                GlobalClass.WaterAuth.DataValuesServiceAllowed(Context, authToken);
                
                if (!useODForValues) throw new SoapException("GetValues implemented external to this service. Call GetSiteInfo, and SeriesCatalog includes the service Wsdl for GetValues. Attribute:serviceWsdl on Element:seriesCatalog XPath://seriesCatalog/[@serviceWsdl]", new XmlQualifiedName("ServiceException"));

                try
                {
                    return ODws.GetValues(location, variable, startDate, endDate);
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }
 

            }

            public SiteInfoResponseType GetSiteInfoMultpleObject(string[] site, string authToken)
            {
                GlobalClass.WaterAuth.SiteInfoServiceAllowed(Context, authToken);

                try
                {
                    return ODws.GetSiteInfo(site, true);
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }
            }

            public SiteInfoResponseType GetSitesByBoxObject(float west, float south, float east, float north, bool IncludeSeries, string authToken)
            {
                GlobalClass.WaterAuth.SiteInfoServiceAllowed(Context, authToken);
               return ODws.GetSitesInBox( west,south,east, north, IncludeSeries );
            }

            public TimeSeriesResponseType GetValuesForASiteObject(string site, string StartDate, string EndDate, string authToken)
            {
                GlobalClass.WaterAuth.DataValuesServiceAllowed(Context, authToken); 
                return ODws.GetValuesForASite(site, StartDate, EndDate);
            }

            public TimeSeriesResponseType GetValuesByBoxObject(string variable, string StartDate, string EndDate, float west, float south, float east, float north, string authToken)
            {
                throw new NotImplementedException();
            }

            public string GetVariables(String authToken)
            {
                VariablesResponseType aVType = GetVariableInfoObject(null, authToken);
                string xml = WSUtils.ConvertToXml(aVType, typeof(VariablesResponseType));
                return xml;
            }

            public VariablesResponseType GetVariablesObject(String authToken)
            {
                return GetVariableInfoObject(null, authToken);

            }

            #endregion


        }
    }
}