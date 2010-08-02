using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using GenericGrabSampleFiles.wof11;

namespace GenericGrabSampleFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLValidator validator = new XMLValidator();
            Stream sr;

            DirectoryInfo dir;
            DirectoryInfo dirv11;
            DirectoryInfo dirv10;
            string path = Properties.Settings.Default.outputDir+System.DateTime.Now.ToString("yyyyMMdd");
            if (!System.IO.Directory.Exists(Properties.Settings.Default.outputDir))
            {
                dir = System.IO.Directory.CreateDirectory(path);
            }
            else
            {
                dir = new DirectoryInfo(path);
            }
            string pathv11 = path + System.IO.Path.DirectorySeparatorChar + "v11";
            if (!System.IO.Directory.Exists(pathv11))
            {
                dirv11 = System.IO.Directory.CreateDirectory(pathv11);
            }
            else
            {
                dirv11 = new DirectoryInfo(pathv11);
            }
            string pathv10 = path + System.IO.Path.DirectorySeparatorChar + "v10";
            if (!System.IO.Directory.Exists(pathv10))
            {
                dirv10 = System.IO.Directory.CreateDirectory(pathv10);
            }
            else
            {
                dirv10 = new DirectoryInfo(pathv10);
            }

            wof11.WaterOneFlow svc11 = new wof11.WaterOneFlow();
            svc11.EnableDecompression = true;

            wof10.WaterOneFlow svc10 = new wof10.WaterOneFlow();
            svc10.EnableDecompression = true;

            // Create Root Elements
            XmlRootAttribute tsr10 = new XmlRootAttribute();
            tsr10.ElementName = "timeSeriesResponse";
            tsr10.Namespace = "http://www.cuahsi.org/waterML/1.0/";
            tsr10.IsNullable = false; 

            XmlRootAttribute tsr11 = new XmlRootAttribute();
            tsr11.ElementName = "timeSeriesResponse";
            tsr11.Namespace = "http://www.cuahsi.org/waterML/1.1/";
            tsr11.IsNullable = false;

            XmlRootAttribute sr10 = new XmlRootAttribute();
            sr10.ElementName = "sitesResponse";
            sr10.Namespace = "http://www.cuahsi.org/waterML/1.0/";
            sr10.IsNullable = false;

            XmlRootAttribute sr11 = new XmlRootAttribute();
            sr11.ElementName = "sitesResponse";
            sr11.Namespace = "http://www.cuahsi.org/waterML/1.1/";
            sr11.IsNullable = false;

            XmlRootAttribute vr10 = new XmlRootAttribute();
            vr10.ElementName = "variablesResponse";
            vr10.Namespace = "http://www.cuahsi.org/waterML/1.0/";
            vr10.IsNullable = false;

            XmlRootAttribute vr11 = new XmlRootAttribute();
            vr11.ElementName = "variablesResponse";
            vr11.Namespace = "http://www.cuahsi.org/waterML/1.1/";
            vr11.IsNullable = false;


            // getVaraibleInfo ALL

            string filePath = FileAndPath(pathv11, "GetVariableInfo_All");
            using (Stream outputStream = File.Create(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(wof11.VariablesResponseType),
                    vr11);

                wof11.VariablesResponseType tsr = svc11.GetVariableInfoObject(
                  null, null);
                serializer.Serialize(outputStream, tsr);
            }
            using (sr = File.OpenRead(filePath))
            {
                validator.Validate(sr);
            }

            filePath = FileAndPath(pathv10, "GetVariableInfo_All");
            using (Stream outputStream = File.Create(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(wof10.VariablesResponseType),vr10);

                wof10.VariablesResponseType tsr = svc10.GetVariableInfoObject(
                  null, null);
                serializer.Serialize(outputStream, tsr);
            }
            using (sr = File.OpenRead(filePath))
            {
                validator.Validate(sr);
            }

            // GetSites

            filePath = FileAndPath(pathv11, "GetSites_All");
            using (Stream outputStream = File.Create(filePath))
            {
             XmlSerializer sitesSerializer = new XmlSerializer(typeof(wof11.SiteInfoResponseType),sr11);
              wof11.SiteInfoResponseType srt = svc11.GetSitesObject(
                  new string[] { }, null);
                sitesSerializer.Serialize(outputStream, srt);
            }
            using (sr = File.OpenRead(filePath))
            {
                validator.Validate(sr);
            }

            filePath = FileAndPath(pathv10, "GetSites_All");
            using (Stream outputStream = File.Create(filePath))
            {
                XmlSerializer sitesSerializer = new XmlSerializer(typeof(wof10.SiteInfoResponseType),sr10);
                wof10.SiteInfoResponseType srt = svc10.GetSites(
                    new string[] { }, null);
                sitesSerializer.Serialize(outputStream, srt);
            }
            using (sr = File.OpenRead(filePath))
            {
                validator.Validate(sr);
            }

            using (StreamReader gvFile = System.IO.File.OpenText("SampleSites.txt"))
            {
                List<string> siteCodes = new List<string>();

                while (!gvFile.EndOfStream)
                {
                    SampleDataRow r = new SampleDataRow(
                        gvFile.ReadLine().Split(new string[] { "," }, 7, StringSplitOptions.None)
                        );
                    if (r.name.StartsWith("#")) continue;
                    siteCodes.Add(r.network + ":" + r.sitecode);

                    filePath = FileAndPath(pathv11, r.name);
                    using (Stream outputStream = File.Create(filePath))
                    {
                        XmlSerializer sitesSerializer = 
                            new XmlSerializer(typeof(wof11.SiteInfoResponseType),sr11);
                        wof11.SiteInfoResponseType responseType = svc11.GetSiteInfoObject(
                          r.network + ":" + r.sitecode, r.auth);
                        sitesSerializer.Serialize(outputStream, responseType);
                    }
                    using (sr = File.OpenRead(filePath)) {
                    validator.Validate(sr);
}
                    filePath = FileAndPath(pathv10, r.name);
                    using (Stream outputStream = File.Create(filePath))
                    {
                        XmlSerializer sitesSerializer = 
                            new XmlSerializer(typeof(wof10.SiteInfoResponseType),sr10);
                        wof10.SiteInfoResponseType responseType = svc10.GetSiteInfoObject(
                          r.network + ":" + r.sitecode, r.auth);
                        sitesSerializer.Serialize(outputStream, responseType);
                    }
                    using (sr = File.OpenRead(filePath))
                    {
                        validator.Validate(sr);
                    }
                }

                filePath = FileAndPath(pathv11, "GetSiteInfoMultiple");
                using (Stream outputStream = File.Create(filePath))
                {
                    XmlSerializer sitesSerializer = 
                        new XmlSerializer(typeof(wof11.SiteInfoResponseType),sr11);

                    wof11.SiteInfoResponseType response = svc11.GetSiteInfoMultpleObject(
      siteCodes.ToArray(), null);
                    sitesSerializer.Serialize(outputStream, response);
                }
                using (sr = File.OpenRead(filePath))
                {
                    validator.Validate(sr);
                }

                filePath = FileAndPath(pathv11, "GetSitesInBox");
                using (Stream outputStream = File.Create(filePath))
                {
                    XmlSerializer sitesSerializer = 
                        new XmlSerializer(typeof(wof11.SiteInfoResponseType),sr11);
                    wof11.SiteInfoResponseType response = svc11.GetSitesByBoxObject(
                              (float)(-180.0), (float)(-90.0), (float)180.0, (float)90.0, true, null);
                    sitesSerializer.Serialize(outputStream, response);
                }
                using (sr = File.OpenRead(filePath))
                {
                    validator.Validate(sr);
                }
            }

            //GetValues
             
            using (StreamReader gvFile = System.IO.File.OpenText("SampleGetValues.txt"))
            {
                while (!gvFile.EndOfStream)
                {
                    SampleDataRow r = new SampleDataRow(
                        gvFile.ReadLine().Split(new string[] { "," }, 7, StringSplitOptions.None)
                        );
                    if (r.name.StartsWith("#")) continue;


                    filePath = FileAndPath(pathv11, r.name);
                    using (Stream outputStream = File.Create(filePath))
                    {
                        XmlSerializer tsrSerializer = 
                            new XmlSerializer(typeof(wof11.TimeSeriesResponseType),tsr11);

                        wof11.TimeSeriesResponseType tsr = svc11.GetValuesObject(
                            r.network + ":" + r.sitecode, r.network + ":" + r.variableCode, r.begindate,
                            r.endDate, r.auth);
                        tsrSerializer.Serialize(outputStream, tsr);
                    }
                    using (sr = File.OpenRead(filePath))
                    {
                        validator.Validate(sr);
                    }

                    filePath = FileAndPath(pathv10, r.name);
                    using (Stream outputStream = File.Create(filePath))
                    {
                        XmlSerializer tsrSerializer = 
                            new XmlSerializer(typeof(wof10.TimeSeriesResponseType),tsr10);

                        wof10.TimeSeriesResponseType tsr = svc10.GetValuesObject(
                            r.network + ":" + r.sitecode, r.network + ":" + r.variableCode, r.begindate,
                            r.endDate, r.auth);
                        tsrSerializer.Serialize(outputStream, tsr);
                    }
                    using (sr = File.OpenRead(filePath))
                    {
                        validator.Validate(sr);
                    }
                }
            }

            using (StreamReader gvFile = System.IO.File.OpenText("SampleMultiValues.txt"))
            {

                while (!gvFile.EndOfStream)
                {
                    SampleDataRow r = new SampleDataRow(
                        gvFile.ReadLine().Split(new string[] { "," }, 7, StringSplitOptions.None)
                        );
                    if (r.name.StartsWith("#")) continue;

                    filePath = FileAndPath(pathv11, r.name);
                    using (Stream outputStream = File.Create(FileAndPath(pathv11, r.name)))
                    {
                        XmlSerializer tsrSerializer = 
                            new XmlSerializer(typeof(wof11.TimeSeriesResponseType),tsr11);

                        wof11.TimeSeriesResponseType tsr = svc11.GetValuesForASiteObject(
                           r.network + ":" + r.sitecode, r.begindate, r.endDate, r.auth);
                        tsrSerializer.Serialize(outputStream, tsr);
                    }
                    using (sr = File.OpenRead(filePath))
                    {
                        validator.Validate(sr);
                    }
                }

            }



        }
        static string FileAndPath(string path, string filename)
        {
            return path + System.IO.Path.DirectorySeparatorChar + filename + ".xml";
        }

        class SampleDataRow
        {
            public string name;
            public string network;
            public string sitecode;
            public string variableCode;
            public string begindate;
            public string endDate;
            public string auth;

            public SampleDataRow(string[] line)
            {
                name = line[0];
                network = line[1];
                sitecode = line[2];
                variableCode = line[3];
                begindate = line[4];
                endDate = line[5];
                auth = line[6];
            }
        }

    }
}
