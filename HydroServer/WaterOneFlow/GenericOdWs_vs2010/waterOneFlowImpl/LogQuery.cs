using System;
using System.Collections.Generic;
using System.Text;
using log4net;

/* a permission object is goint to be needed to make 
 * this with the ability to access the DNS
 * http://msdn.microsoft.com/en-us/library/system.security.codeaccesspermission.aspx
 * http://www.eggheadcafe.com/community/aspnet/12/10007688/request-for-the-permission-of-type-systemnetdnspermission-system-version2000-cultureneutral-publickeytokenb77a5c561934e089.aspx
 * http://social.msdn.microsoft.com/forums/en-US/csharpgeneral/thread/d4a58414-cc38-43ba-b7ef-1578767a823d
 */

// Load the configuration from the 'wateroneflow.logging.log4net' file
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "wateroneflow.logging.log4net", Watch = true)]
namespace WaterOneFlowImpl
{
    ///
    /// 
    /// 
    /// 
    public class Logging
    {
        private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");
        private String networkField;

        public String Network
        {
            get
            {
                return networkField;
            }
            set { networkField = value; }
        }


        public enum Methods
        {
            GetValues,
            GetValuesObject,
            GetVariables,
            GetVariablesObject,
            GetSiteInfo,
            GetSiteInfoObject,
            GetSites,
            GetSitesObject,
            GetSitesInBoxObject,
            GetValuesForSiteObject
        }
        public Logging(String network)
        {
            Network = network;
        }
        public Logging()
        {
            if (String.IsNullOrEmpty(networkField))
                networkField = System.Configuration.ConfigurationManager.AppSettings["network"];
        }

        public void LogStart(Methods Method, String parameter)
        {
            LogStart(Method, parameter, String.Empty);
        }

        public void LogStart(Methods Method, string parameter, string UserHost)
        {
            switch (Method)
            {
                case Methods.GetVariables:
                case Methods.GetVariablesObject:
                    LogQueryFormatted(
                        Method.ToString(),
                        null,
                        parameter,
                        null,
                        null,
                        null,
                        null, UserHost);
                    break;
                case Methods.GetSites:
                case Methods.GetSitesObject:
                case Methods.GetSiteInfo:
                case Methods.GetSiteInfoObject:
                    LogQueryFormatted(
                        Method.ToString(),
                        parameter,
                        null,
                        null,
                        null,
                        null,
                        null, UserHost);
                    break;
                default:
                    LogQueryUnformatted(
                        Method.ToString(),
                        parameter
                        );
                    break;

            }
        }

        public void LogEnd(Methods Method, String parameter, String processingTime, String Count)
        {
            LogEnd(Method, parameter, processingTime, Count, String.Empty);
        }

        public void LogEnd(Methods Method, string parameter, string processingTime, string Count, string UserHost)
        {
            switch (Method)
            {
                case Methods.GetVariables:
                case Methods.GetVariablesObject:
                    LogQueryFormatted(
                        Method.ToString(),
                        null,
                        parameter,
                        null,
                        null,
                        processingTime,
                        Count, UserHost);
                    break;
                case Methods.GetSites:
                case Methods.GetSitesObject:
                case Methods.GetSiteInfo:
                case Methods.GetSiteInfoObject:
                    LogQueryFormatted(
                        Method.ToString(),
                        parameter,
                        null,
                        null,
                        null,
                        processingTime,
                        Count, UserHost);
                    break;
                default:
                    LogQueryUnformatted(
                        Method.ToString(),
                        parameter
                        );
                    break;

            }
        }

        public void LogValuesStart(Methods Method,
                                   String Location,
                                   String Variable,
                                   String start,
                                   String end
            )
        {
            LogValuesStart(Method, Location, Variable, start, end, String.Empty);
        }

        public void LogValuesStart(Methods Method, string Location, string Variable, string start, string end, string UserHost)
        {
            LogQueryFormatted(
                Method.ToString(),
                Location,
                Variable,
                start,
                end,
                null,
                null, UserHost);

        }

        public void LogValuesEnd(Methods Method,
                                 String Location,
                                 String Variable,
                                 String start,
                                 String end,
                                 long ProcessingTime,
                                 int Count

            )
        {
            LogValuesEnd(Method, Location, Variable, start, end, ProcessingTime, Count, String.Empty);
        }

        public void LogValuesEnd(Methods Method, string Location, string Variable, string start, string end, long ProcessingTime, int Count, string UserHost)
        {
            LogQueryFormatted(
                Method.ToString(),
                Location,
                Variable,
                start,
                end,
                ProcessingTime.ToString(),
                Count.ToString(), UserHost);

        }


        public void LogQueryUnformatted(
            String Method,
            string message
            )
        {
            LogQueryUnformatted(Method, message, String.Empty);
        }

        public void LogQueryUnformatted(string Method, string message, string UserHost)
        {
            //String network,method,location, variable, start, end, , processing time,count
            queryLog.InfoFormat("{0}|{1}|{2}|{3}",
                                Network, // network
                                Method, // method
                                message, //location
                                UserHost
                );
        }

        //String network,method,location, variable, start, end, , processing time,count
        /* I don't pass in Network, or SystemTime
         */
        public void LogQueryFormatted(string Method, 
            string Location, string Variable, 
            string start, string end,
            string ProcessingTime, string Count,
            string userHost)
        {
            //String network,method,location, variable, start, end, , processing time,count, user host
            queryLog.InfoFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                 Network, // network
                 Method, // method
                 Location, //locaiton
                 Variable, //variable
                 start, // startdate
                 end, //enddate
                ProcessingTime, // processing time
                 Count, // count 
                 userHost);

        }
    }
}
