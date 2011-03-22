using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;


namespace WaterOneFlowImpl
{
    public  class WSUtils
    {
        static string isoDateMatch = "([0-9]{4})(-([0-9]{2})(-([0-9]{2})" +
        "(T([0-9]{2}):([0-9]{2})(:([0-9]{2})(\\.([0-9]+))?)?" +
        "(Z|(([-+])([0-9]{2}):([0-9]{2})))?)?)?)?";

       
        public static string DownLoadAscii(string address)
        {
            /*
             * System.Net.WebClient wc = new System.Net.WebClient();
            return System.Text.Encoding.ASCII.GetString(wc.DownloadData(address));
            */
            StreamReader reader = null;
            Stream dataStream = null;
            HttpWebResponse response = null;
            WebRequest request = null;

            try
            {
                request = WebRequest.Create(address);
                response = (HttpWebResponse)request.GetResponse();
                // Display the status.
                if (response.ContentType.Equals("text/plain"))
                {
                    dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.
                    reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    return responseFromServer;

                }
                else
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new WaterOneFlowException("Unexpected response from server for URL:'" + address + "' " + response.StatusDescription);
                    }
                    else
                    {
                        throw new WaterOneFlowException("Probable Parameter Error. Try different Time period. URL:'" + address + "' " + response.StatusDescription);
                    }
                }
            }
            catch (WebException e)
            {
                throw new WaterOneFlowException("Error occured reading from '" + address + "' "
                    + ((HttpWebResponse)e.Response).StatusDescription);
            }
            catch (WaterOneFlowException we)
            {
                throw;
            }
            finally
            {
                // Cleanup the streams and the response.
                if (reader != null) reader.Close();
                if (dataStream != null) dataStream.Close();
                if (response != null) response.Close();
            }
        }

    

        public static bool IsNumeric(object expression)
        {
            double number;
            bool flag = false;
            if (expression != null)
            {
                if (Double.TryParse(expression.ToString().Trim(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out number))
                {
                    flag = true;
                }
            }
            return flag;
        }

 

        public static string SqlEncode(string input)
        {
            return input.Replace("'", "''");
        }

        #region String hacks
        public static String[] removeEmptyStrings(String[] stringArray)
        {

            List<String> al = new List<String>();
            foreach (string s in stringArray)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    al.Add(s);
                }
            }
            return al.ToArray();
        }

        #endregion
        #region Date Hacks


        public static Nullable<DateTime> unspecifiedDate(Nullable<DateTime> dt)
        {
            try
            {
                // remove UTC
                //dt = dt.Value.Add(TimeZone.CurrentTimeZone.GetUtcOffset(dt.Value));
                int year = dt.Value.Year;
                int month = dt.Value.Month;
                int day = dt.Value.Day;
                return new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Unspecified);

            }
            catch
            {
                return null;
            }

        }

        #endregion Date hacks

        #region Configuration
        public static String checkConfiguration(String configKey)
        {
            String aKey = ConfigurationManager.AppSettings[configKey];
            if (aKey == null) return "Missing Key:'" + configKey + "' add key to web.config." ;
            if (aKey == String.Empty) return "Empty Key:'" + configKey + "' edit value in web.config.";
            return null;
        }
        
        #endregion

        public static string ConvertToXml(object toSerialize, Type objectType)
        {
            // create a string wrtiter to hold the xml string
            // the a xml writer with the proper settings.
            // use that writer to serialize the document.
            // use an  namespace to create a fully qualified odcument.
            StringWriter aWriter = new StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.ConformanceLevel = ConformanceLevel.Document; // Fragment fails
            settings.Indent = false;
            settings.Encoding = System.Text.Encoding.UTF8;

            XmlWriter xWriter = XmlWriter.Create(aWriter, settings);

            new XmlSerializerNamespaces();
            XmlSerializerNamespaces myNamespaces = new XmlSerializerNamespaces();
            myNamespaces.Add("wtr", "http://www.cuahsi.org/waterML/");
            myNamespaces.Add("xsd", "http://www.w3.org/2001/XMLSchema");
            myNamespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            myNamespaces.Add("gml", "http://www.opengis.net/gml");
            myNamespaces.Add("xlink", "http://www.w3.org/1999/xlink");
            myNamespaces.Add("xml", "http://www.w3.org/XML/1998/namespace");

            XmlSerializer aSerializer = new XmlSerializer(objectType);
            //aSerialize(xWriter, toSerialize);
            aSerializer.Serialize(xWriter, toSerialize, myNamespaces);
            string xml = aWriter.ToString();
            aWriter.Flush();
            aWriter.Close();
            return xml;
        }

    }
    namespace v1_1
    {
        public sealed class WSUtils : WaterOneFlowImpl.WSUtils
        {
            public static string ConvertToXml(object toSerialize, Type objectType)
            {
                // create a string wrtiter to hold the xml string
                // the a xml writer with the proper settings.
                // use that writer to serialize the document.
                // use an  namespace to create a fully qualified odcument.
                StringWriter aWriter = new StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.ConformanceLevel = ConformanceLevel.Document; // Fragment fails
                settings.Indent = false;
                settings.Encoding = System.Text.Encoding.UTF8;

                XmlWriter xWriter = XmlWriter.Create(aWriter, settings);

                new XmlSerializerNamespaces();
                XmlSerializerNamespaces myNamespaces = new XmlSerializerNamespaces();
                myNamespaces.Add("wtr", "http://www.cuahsi.org/waterML/1_1/");
                myNamespaces.Add("xsd", "http://www.w3.org/2001/XMLSchema");
                myNamespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                myNamespaces.Add("gml", "http://www.opengis.net/gml");
                myNamespaces.Add("xlink", "http://www.w3.org/1999/xlink");
                myNamespaces.Add("xml", "http://www.w3.org/XML/1998/namespace");

                XmlSerializer aSerializer = new XmlSerializer(objectType);
                //aSerialize(xWriter, toSerialize);
                aSerializer.Serialize(xWriter, toSerialize, myNamespaces);
                string xml = aWriter.ToString();
                aWriter.Flush();
                aWriter.Close();
                return xml;
            }
        }
    }
    
}
