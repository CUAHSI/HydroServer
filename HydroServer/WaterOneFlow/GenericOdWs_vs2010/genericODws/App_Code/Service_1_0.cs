using System;
using System.Configuration;
using System.Text;
using log4net;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Services.Protocols;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Addressing;
using Microsoft.Web.Services3.Messaging;
using WaterOneFlowImpl;
using WaterOneFlow;

// Load the configuration from the 'wateroneflow.logging.log4net' file

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "wateroneflow.logging.log4net", Watch = true)]

namespace WaterOneFlow.odws
{
    using WaterOneFlow.Schema.v1;

    public class Config
    {
        public static string ODDB()
        {
            if (ConfigurationManager.ConnectionStrings["ODDB"] != null)
            {
                return ConfigurationManager.ConnectionStrings["ODDB"].ConnectionString;
            }
            else
            {
                return null;
            }
        }
    }

    [WebService(Name = WsDescriptions.WsDefaultName,
        Namespace = Constants.WS_NAMSPACE,
        Description = WsDescriptions.SvcDevelopementalWarning + WsDescriptions.WsDefaultDescription)]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [SoapActor("*")]
    public class Service_1_0 : WebService, IService_1_0
    {
        protected ODService ODws;
        //private StandardServices aStandard;
        private Boolean useODForValues;
        private Boolean requireAuthToken;

        private static readonly ILog log = LogManager.GetLogger(typeof (Service_1_0));
        private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");

        public Service_1_0()
        {
            //log4net.Util.LogLog.InternalDebugging = true; 

            ODws = new ODService(this.Context); //INFO we can extend this for other service types
            // aStandard = new StandardServices();

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

        public string GetSitesXml(string[] SiteNumbers, String authToken)
        {
            SiteInfoResponseType aSite = GetSites(SiteNumbers, null);
            string xml = WSUtils.ConvertToXml(aSite, typeof (SiteInfoResponseType));
            return xml;
        }

        public virtual string GetSiteInfo(string SiteNumber, String authToken)
        {
            SiteInfoResponseType aSite = GetSiteInfoObject(SiteNumber, null);
            string xml = WSUtils.ConvertToXml(aSite, typeof (SiteInfoResponseType));
            return xml;
        }

        public string GetVariableInfo(string Variable, String authToken)
        {
            VariablesResponseType aVType = GetVariableInfoObject(Variable, null);
            string xml = WSUtils.ConvertToXml(aVType, typeof (VariablesResponseType));
            return xml;
        }


        public SiteInfoResponseType GetSites(string[] SiteNumbers, String authToken)
        {
            GlobalClass.WaterAuth.SitesServiceAllowed(Context, authToken);

            try
            {
                return ODws.GetSites(SiteNumbers);
            }
            catch (Exception we)
            {
                log.Warn(we.Message);
                throw SoapExceptionGenerator.WOFExceptionToSoapException(we);
            }
        }

        public virtual SiteInfoResponseType GetSiteInfoObject(string SiteNumber, String authToken)
        {
            GlobalClass.WaterAuth.SiteInfoServiceAllowed(Context, authToken);

            try
            {
                return ODws.GetSiteInfo(SiteNumber);
            }
            catch (Exception we)
            {
                log.Warn(we.Message);
                throw SoapExceptionGenerator.WOFExceptionToSoapException(we);
            }

   
        }

        public VariablesResponseType GetVariableInfoObject(string Variable, String authToken)
        {
            GlobalClass.WaterAuth.VariableInfoServiceAllowed(Context, authToken);

            try
            {
                return ODws.GetVariableInfo(Variable);
            }
            catch (Exception we)
            {
                log.Warn(we.Message);
                throw SoapExceptionGenerator.WOFExceptionToSoapException(we);
            }
 
        }

        public virtual string GetValues(string locationParam, string VariableCode, string StartDate, string EndDate,
                                        String authToken)
        {
            TimeSeriesResponseType aSite = GetValuesObject(locationParam, VariableCode, StartDate, EndDate, null);
            return WSUtils.ConvertToXml(aSite, typeof (TimeSeriesResponseType));
        }

        public virtual TimeSeriesResponseType GetValuesObject(string locationParam, string VariableCode,
                                                              string StartDate, string EndDate, String authToken)
        {
            GlobalClass.WaterAuth.DataValuesServiceAllowed(Context, authToken);

            if (!useODForValues)
                throw new SoapException(
                    "GetValues implemented external to this service. Call GetSiteInfo, and SeriesCatalog includes the service Wsdl for GetValues. Attribute:serviceWsdl on Element:seriesCatalog XPath://seriesCatalog/[@serviceWsdl]",
                    new XmlQualifiedName("ServiceException"));

            try
            {
                return ODws.GetValues(locationParam, VariableCode, StartDate, EndDate);
            }
            catch (Exception we)
            {
                log.Warn(we.Message);
                throw SoapExceptionGenerator.WOFExceptionToSoapException(we);
            }
 
        }

        #endregion
    }
}