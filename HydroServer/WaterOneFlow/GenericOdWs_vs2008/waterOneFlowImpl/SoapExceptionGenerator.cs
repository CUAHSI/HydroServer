using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services.Protocols;
using System.Xml;
using log4net;

namespace WaterOneFlowImpl
{
    public class SoapExceptionGenerator : SoapException
    {
        private static string clientError = "client";

        public static string ClientError
        {
            get { return SoapExceptionGenerator.clientError; }
            
        }
        private static string serverError = "server";

        public static string ServerError
        {
            get { return SoapExceptionGenerator.serverError; }
            
        }
        private static string externalError = "external";

        public static string ExternalError
        {
            get { return SoapExceptionGenerator.externalError; }
            
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(WaterOneFlowException));

        public static SoapException WOFExceptionToSoapException (Exception ex)
        {
            Type eType = ex.GetType();
            SoapException se;
            String actor = null;
            String detailText = null;
            string message = null;
            if (eType == typeof (WaterOneFlowException))
            {
                XmlQualifiedName soapCode = ClientFaultCode;
                se = new SoapException(ex.Message, soapCode);
                if (log.IsDebugEnabled) log.Debug(ex.Message);
            }
            else if (eType == typeof (WaterOneFlowSourceException))
            {
                XmlQualifiedName soapCode = ServerFaultCode;
                se = new SoapException(ex.Message, soapCode);
                if (log.IsErrorEnabled) log.Error(ex.Message);
            }
            else if (eType == typeof (WaterOneFlowServerException))
            {
                // create a soap fault with a subcode, external
                XmlQualifiedName soapCode = ServerFaultCode;
                XmlQualifiedName subCodeName = new XmlQualifiedName("external",Constants.XML_SCHEMA_NAMSPACE);
                SoapFaultSubCode subCode = new SoapFaultSubCode(subCodeName);

                se = new SoapException(ex.Message, soapCode, subCode);
                if (log.IsErrorEnabled) log.Error(ex.Message);

            }
         else if (eType == typeof(ArgumentException))
         {
             XmlQualifiedName soapCode = ClientFaultCode;
             se = new SoapException(ex.Message, soapCode);
             if (log.IsDebugEnabled) log.Debug(ex.Message);
         } else if (eType == typeof(OverflowException))
         {
             XmlQualifiedName soapCode = ServerFaultCode;
             se = new SoapException(ex.Message, soapCode);
             if (log.IsErrorEnabled) log.Error(ex.Message);
         }

    else
           {
               XmlQualifiedName soapCode = ServerFaultCode;
               se = new SoapException(ex.Message, soapCode);
               if (log.IsErrorEnabled) log.Error(ex.Message);
           }
            return se;
        }
    }
}
