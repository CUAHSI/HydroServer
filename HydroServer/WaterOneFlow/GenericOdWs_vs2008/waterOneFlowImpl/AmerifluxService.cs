using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;

namespace waterOneFlowImpl
{
    public class AmerifluxService
    {

        private bool UseLocalSitesDatabase = true;
        private WSUtils utils;

        #region Public Methods / Constructors

        public AmerifluxService()
        {
            utils = new WSUtils();
            GetSites(true, true, true);
        }

        public string GetSites(bool IncludeSiteDetails, bool IncludeVariables, bool IncludeVariableDetails)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                if (IncludeSiteDetails | IncludeVariables)
                {
                    xmlDoc.LoadXml(GetSitesDatabase(true));
                }
                else
                {
                    xmlDoc.LoadXml(GetSitesDatabase(false));
                }
                XmlElement element = xmlDoc.DocumentElement.SelectSingleNode("ErrorDescription") as XmlElement;
                if (element.InnerText != "")
                {
                    return xmlDoc.InnerXml;
                }
            }
            catch (Exception ex)
            {
                xmlDoc = utils.BuildGetSitesSchema("AmeriFlux");
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not read AmeriFlux site information. " + ex.Message);
                return xmlDoc.InnerXml;
            }
            XmlNodeList nodes = xmlDoc.SelectNodes("//Site");
            foreach (XmlElement element in nodes)
            {
                XmlElement child = element.SelectSingleNode("SiteCodeTS") as XmlElement;
                if (!(child == null))
                {
                    element.RemoveChild(child);
                }
                if (!(IncludeSiteDetails))
                {
                    child = element.SelectSingleNode("SiteName") as XmlElement;
                    if (!(child == null))
                    {
                        element.RemoveChild(child);
                    }
                    child = element.SelectSingleNode("State") as XmlElement;
                    if (!(child == null))
                    {
                        element.RemoveChild(child);
                    }
                    child = element.SelectSingleNode("Latitude") as XmlElement;
                    if (!(child == null))
                    {
                        element.RemoveChild(child);
                    }
                    child = element.SelectSingleNode("Longitude") as XmlElement;
                    if (!(child == null))
                    {
                        element.RemoveChild(child);
                    }
                    child = element.SelectSingleNode("StartTSDate") as XmlElement;
                    if (!(child == null))
                    {
                        element.RemoveChild(child);
                    }
                    child = element.SelectSingleNode("EndTSDate") as XmlElement;
                    if (!(child == null))
                    {
                        element.RemoveChild(child);
                    }
                    child = element.SelectSingleNode("QueryURL") as XmlElement;
                    if (!(child == null))
                    {
                        element.RemoveChild(child);
                    }
                }
                XmlElement vars = element.SelectSingleNode("Variables") as XmlElement;
                if (!(IncludeVariables))
                {
                    if (!(vars == null))
                    {
                        element.RemoveChild(vars);
                    }
                }
                else
                {
                    XmlNodeList varNodes = vars.SelectNodes("Variable");
                    foreach (XmlElement var in varNodes)
                    {
                        if (var.GetAttribute("static") == "True")
                        {
                            vars.RemoveChild(var);
                        }
                        else
                        {
                            if (!(IncludeVariableDetails))
                            {
                                child = var.SelectSingleNode("VariableName") as XmlElement;
                                if (!(child == null))
                                {
                                    var.RemoveChild(child);
                                }
                                child = var.SelectSingleNode("Units") as XmlElement;
                                if (!(child == null))
                                {
                                    var.RemoveChild(child);
                                }
                                child = var.SelectSingleNode("VariableDescription") as XmlElement;
                                if (!(child == null))
                                {
                                    var.RemoveChild(child);
                                }
                                child = var.SelectSingleNode("StartTSDate") as XmlElement;
                                if (!(child == null))
                                {
                                    var.RemoveChild(child);
                                }
                                child = var.SelectSingleNode("EndTSDate") as XmlElement;
                                if (!(child == null))
                                {
                                    var.RemoveChild(child);
                                }
                            }
                        }
                    }
                }
            }
            return xmlDoc.InnerXml;
        }

        public string GetSiteInfo(string SiteCode)
        {
            bool IncludeVariables = true;
            bool IncludeVariableDetails = true;
            XmlDocument xmlDoc = utils.BuildGetSiteInfoSchema("AmeriFlux", SiteCode, IncludeVariables);
            try
            {
                XmlDocument doc = ParseSitesPageForSite(SiteCode);
                XmlElement element = doc.SelectSingleNode("//ErrorDescription") as XmlElement;
                if (element.InnerText != "")
                {
                    utils.SetElementText(xmlDoc, "ErrorDescription", element.InnerText);
                    return xmlDoc.InnerXml;
                }
                utils.SetElementText(xmlDoc, "State", doc.SelectSingleNode("//State").InnerText);
                utils.SetElementText(xmlDoc, "Latitude", doc.SelectSingleNode("//Latitude").InnerText);
                utils.SetElementText(xmlDoc, "Longitude", doc.SelectSingleNode("//Longitude").InnerText);
                element = utils.AddChildElement(xmlDoc.DocumentElement, "QueryURL", doc.SelectSingleNode("//QueryURL").InnerText, xmlDoc.SelectSingleNode("//ErrorDescription") as XmlElement);
                element.SetAttribute("returns", "Site location");
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not parse main sites page for site info. " + ex.Message);
                return xmlDoc.InnerXml;
            }
            try
            {
                XmlDocument doc = ParseSitePage(SiteCode);
                XmlElement element;
                utils.SetElementText(xmlDoc, "SiteName", doc.SelectSingleNode("//SiteName").InnerText);
                utils.SetElementText(xmlDoc, "StartTSDate", doc.SelectSingleNode("//StartTSDate").InnerText);
                utils.SetElementText(xmlDoc, "EndTSDate", doc.SelectSingleNode("//EndTSDate").InnerText);
                element = utils.AddChildElement(xmlDoc.DocumentElement, "QueryURL", doc.SelectSingleNode("//QueryURL").InnerText, xmlDoc.SelectSingleNode("//ErrorDescription") as XmlElement);
                element.SetAttribute("returns", "SiteName, Variables, and Period of Record");
                if (IncludeVariables)
                {
                    XmlElement vars = xmlDoc.SelectSingleNode("//Variables") as XmlElement;
                    vars.InnerXml = doc.SelectSingleNode("//Variables").InnerXml;
                    vars.SetAttribute("count", vars.SelectNodes("Variable").Count.ToString());
                    XmlNodeList varNodes = vars.SelectNodes("Variable");
                    foreach (XmlElement var in varNodes)
                    {
                        if (var.GetAttribute("static") == "True")
                        {
                            vars.RemoveChild(var);
                        }
                        else
                        {
                            if (!(IncludeVariableDetails))
                            {
                                element = var.SelectSingleNode("VariableName") as XmlElement;
                                if (!(element == null))
                                {
                                    var.RemoveChild(element);
                                }
                                element = var.SelectSingleNode("Units") as XmlElement;
                                if (!(element == null))
                                {
                                    var.RemoveChild(element);
                                }
                                element = var.SelectSingleNode("VariableDescription") as XmlElement;
                                if (!(element == null))
                                {
                                    var.RemoveChild(element);
                                }
                                element = var.SelectSingleNode("StartTSDate") as XmlElement;
                                if (!(element == null))
                                {
                                    var.RemoveChild(element);
                                }
                                element = var.SelectSingleNode("EndTSDate") as XmlElement;
                                if (!(element == null))
                                {
                                    var.RemoveChild(element);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not parse site page for site info. " + ex.Message);
                return xmlDoc.InnerXml;
            }
            return xmlDoc.InnerXml;
        }

        public string GetVariables(bool IncludeVariableDetails, bool IncludeSites, bool IncludeSiteDetails)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement parent = xmlDoc.CreateElement("AmeriFlux.GetVariables");
            xmlDoc.AppendChild(parent);
            utils.AddChildElement(parent, "ErrorDescription");
            XmlDocument siteDoc = new XmlDocument();
            try
            {
                siteDoc.LoadXml(GetSitesDatabase(true));
                XmlElement element = siteDoc.DocumentElement.SelectSingleNode("ErrorDescription") as XmlElement;
                if (!(element == null))
                {
                    if (element.InnerText != "")
                    {
                        utils.SetElementText(xmlDoc, "ErrorDescription", "Could not read AmeriFlux site information. " + element.InnerText);
                        return xmlDoc.InnerXml;
                    }
                }
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not read AmeriFlux site information. " + ex.Message);
                return xmlDoc.InnerXml;
            }
            XmlElement var;
            SortedList slCodes = new SortedList();
            XmlNodeList nodes = siteDoc.SelectNodes("//Variable");

            foreach (XmlNode var2 in nodes)
            {
                string txt = var2.SelectSingleNode("VariableCode").InnerText;
                if (txt.Length > 0)
                {
                    if (!(slCodes.ContainsKey(txt)))
                    {
                        slCodes.Add(txt, txt);
                    }
                }
            }
            for (int i = 0; i <= slCodes.Count - 1; i++)
            {
                string varCode = slCodes.GetByIndex(i).ToString();
                try
                {
                    var = BuildVariableElement(varCode, siteDoc, xmlDoc, IncludeVariableDetails, IncludeSites, IncludeSiteDetails);
                    parent.AppendChild(var);
                }
                catch (Exception ex)
                {
                    utils.SetElementText(xmlDoc, "ErrorDescription", "Could not read variable information. " + ex.Message);
                    return xmlDoc.InnerXml;
                }
            }
            parent.SetAttribute("count", parent.SelectNodes("Variable").Count.ToString());
            return xmlDoc.InnerXml;
        }

        public string GetVariableInfo(string VariableCode)
        {
            bool IncludeSites = true;
            bool IncludeSiteDetails = true;
            XmlDocument xmlDoc = utils.BuildGetVariableInfoSchema("AmeriFlux", VariableCode);
            XmlDocument siteDoc = new XmlDocument();
            try
            {
                siteDoc.LoadXml(GetSitesDatabase(true));
                XmlElement element = siteDoc.DocumentElement.SelectSingleNode("ErrorDescription") as XmlElement;
                if (!(element == null))
                {
                    if (element.InnerText != "")
                    {
                        utils.SetElementText(xmlDoc, "ErrorDescription", "Could not read AmeriFlux site information. " + element.InnerText);
                        return xmlDoc.InnerXml;
                    }
                }
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not read AmeriFlux site information. " + ex.Message);
                return xmlDoc.InnerXml;
            }
            XmlElement var;
            try
            {
                var = BuildVariableElement(VariableCode, siteDoc, xmlDoc, true, IncludeSites, IncludeSiteDetails);
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not read variable information. " + ex.Message);
                return xmlDoc.InnerXml;
            }
            xmlDoc.RemoveAll();
            xmlDoc.AppendChild(xmlDoc.CreateElement("AmeriFlux.GetVariableInfo"));
            xmlDoc.DocumentElement.InnerXml = var.InnerXml;
            utils.AddChildElement(xmlDoc.DocumentElement, "ErrorDescription", xmlDoc.SelectSingleNode("//VariableDescription") as XmlElement);
            return xmlDoc.InnerXml;
        }

        public string GetValues(string SiteCode, string VariableCode, string StartDate, string EndDate)
        {
            XmlDocument xmlDoc = utils.BuildGetValuesSchema("AmeriFlux", SiteCode, VariableCode);
            utils.AddFlag(xmlDoc, ".", "Missing value");
            utils.AddChildElement((XmlElement)xmlDoc.SelectSingleNode("//VariableInfo"), "Units");
            utils.AddChildElement((XmlElement)xmlDoc.SelectSingleNode("//SiteInfo"), "SiteName");
            utils.AddChildElement((XmlElement)xmlDoc.SelectSingleNode("//Header"), "GmtOffsetHours");
            try
            {
                XmlDocument siteDoc = ParseSitePage(SiteCode);
                try
                {
                    SiteCode = siteDoc.SelectSingleNode("//SiteCodeTS").InnerText;
                }
                catch (Exception ex)
                {
                    utils.SetElementText(xmlDoc, "ErrorDescription", "Unable to read SiteCodeTS for this site. " + ex.Message);
                    return xmlDoc.InnerXml;
                }
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Unable to read site information for this site. " + ex.Message);
                return xmlDoc.InnerXml;
            }
            System.DateTime dtStart;
            System.DateTime dtEnd;
            try
            {
                dtStart = Convert.ToDateTime(StartDate);
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not convert StartDate (" + StartDate + ") to a date." + Environment.NewLine + ex.Message);
                return xmlDoc.InnerXml;
            }
            try
            {
                dtEnd = Convert.ToDateTime(EndDate);
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not convert EndDate (" + EndDate + ") to a date." + Environment.NewLine + ex.Message);
                return xmlDoc.InnerXml;
            }
            if (dtStart.ToOADate() > dtEnd.ToOADate())
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Start date (" + dtStart.ToShortDateString() + ") must not occur after end date (" + dtEnd.ToShortDateString() + ")");
                return xmlDoc.InnerXml;
            }
            System.DateTime dtCompare;
            dtCompare = DateTime.Parse("1/1/1989");
            if (dtStart.ToOADate() < dtCompare.ToOADate())
            {
                dtStart = dtCompare;
            }
            if (dtEnd.ToOADate() < dtCompare.ToOADate())
            {
                dtEnd = dtCompare;
            }
            dtCompare = DateTime.Now.AddDays(1);
            if (dtStart.ToOADate() > dtCompare.ToOADate())
            {
                dtStart = dtCompare;
            }
            if (dtEnd.ToOADate() > dtCompare.ToOADate())
            {
                dtEnd = dtCompare;
            }
            System.DateTime dtTmp;
            XmlDocument xmlChunk;
            XmlElement records = (XmlElement)xmlDoc.SelectSingleNode("//Records");
            int counter = 0;
            XmlElement element;
            string[] VariableCodes = new string[0];
            VariableCodes[0] = VariableCode;
            while (!(dtStart > dtEnd))
            {
                dtTmp = dtStart.AddDays(99);
                if (dtTmp > dtEnd)
                {
                    dtTmp = dtEnd;
                }
                try
                {
                    xmlChunk = DownloadAmeriFluxTS(SiteCode, VariableCodes, dtStart.ToString(), dtTmp.ToString());
                    if (counter == 0)
                    {
                        try
                        {
                            element = (XmlElement)xmlChunk.SelectSingleNode("//SiteName");
                            utils.SetElementText(xmlDoc, "SiteName", element.InnerText);
                        }
                        catch
                        {
                        }
                        try
                        {
                            element = (XmlElement)xmlChunk.SelectSingleNode("//GmtOffsetHours");
                            utils.SetElementText(xmlDoc, "GmtOffsetHours", element.InnerText);
                        }
                        catch
                        {
                        }
                        try
                        {
                            element = (XmlElement)xmlChunk.SelectSingleNode("//Units");
                            utils.SetElementText(xmlDoc, "Units", element.InnerText);
                        }
                        catch
                        {
                        }
                        counter += 1;
                    }
                    records.InnerXml = records.InnerXml + xmlChunk.SelectSingleNode("//Records").InnerXml;
                    counter += 1;
                }
                catch (Exception ex)
                {
                    if (ex.Message.IndexOf("No time series values returned for site") != -1)
                    {
                    }
                    else
                    {
                        utils.SetElementText(xmlDoc, "ErrorDescription", ex.Message);
                        goto exitDoLoopStatement0;
                    }
                }
                dtStart = dtStart.AddDays(100);
            }
        exitDoLoopStatement0: ;
            XmlNodeList elements = xmlDoc.SelectNodes("//Record");
            records.SetAttribute("count", elements.Count.ToString());
            return xmlDoc.InnerXml;
        }

        #endregion

        private XmlDocument DownloadAmeriFluxTS(string SiteCodeTS, string[] VariableCodes, string StartDate, string EndDate)
        {
            if (VariableCodes.Length == 0)
            {
                throw new Exception("No variable codes provided");
            }
            XmlDocument found = null;
            System.DateTime dtStart;
            System.DateTime dtEnd;
            dtStart = Convert.ToDateTime(StartDate);
            dtEnd = Convert.ToDateTime(EndDate);
            string sURL;
            sURL = BuildAmeriFluxTSURL(SiteCodeTS, VariableCodes, dtStart, dtEnd);
            string sTxt;
            sTxt = utils.DownloadASCII(sURL);
            int i;
            int j;
            i = sTxt.IndexOf(".csv");
            if (i == 0)
            {
                throw new Exception("URL did not return link to csv file: " + Environment.NewLine + sURL);
            }
            sTxt = sTxt.Substring(i + 5);
            i = sTxt.IndexOf(".csv");
            sTxt = sTxt.Substring(0, i + 4);
            sTxt = utils.DownloadASCII(sTxt);
            string[] sLines;
            string[] sParts;
            string sPart;
            sLines = sTxt.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            System.Collections.SortedList slFields = new System.Collections.SortedList();
            System.Collections.SortedList slUnits = new System.Collections.SortedList();
            string sUnits;
            string sField;
            sParts = sLines[0].Split(',');
            for (int k = 0; k <= sParts.Length - 1; k++)
            {
                sPart = sParts[k].Trim();
                i = sPart.IndexOf("(");
                if (i > -1)
                {
                    sField = sPart.Substring(0, i).Trim();
                    j = sPart.IndexOf(")", i);
                    if (j == -1)
                    {
                        j = sPart.Length - 1;
                    }
                    sUnits = sPart.Substring(i + 1, j - i - 1).Trim();
                }
                else
                {
                    sField = sPart;
                    sUnits = "";
                }
                if (sPart.Length > 0)
                {
                    slFields.Add(k, sField);
                    slUnits.Add(k, sUnits);
                }
            }
            if (sLines.Length < 2)
            {
                throw new Exception("No time series values returned for site " + SiteCodeTS);
            }
            XmlElement root;
            XmlElement parent;
            XmlElement row;
            XmlElement element;
            XmlDocument xmlDoc = new XmlDocument();
            root = xmlDoc.CreateElement("AmeriFluxTimeSeries");
            xmlDoc.AppendChild(root);
            XmlElement metadata;
            metadata = xmlDoc.CreateElement("Metadata");
            element = xmlDoc.CreateElement("SiteCode");
            element.InnerText = SiteCodeTS;
            metadata.AppendChild(element);
            element = xmlDoc.CreateElement("SiteName");
            i = slFields.IndexOfValue("Site");
            sParts = sLines[1].Split(',');
            element.InnerText = sParts[i].Replace("'", "");
            metadata.AppendChild(element);
            parent = xmlDoc.CreateElement("Flags");
            metadata.AppendChild(parent);
            row = xmlDoc.CreateElement("Flag");
            parent.AppendChild(row);
            element = xmlDoc.CreateElement("FlagValue");
            element.InnerText = ".";
            row.AppendChild(element);
            element = xmlDoc.CreateElement("FlagMeaning");
            element.InnerText = "Missing value";
            row.AppendChild(element);
            System.DateTime dtGMT;
            System.DateTime dtSite;
            sParts = sLines[1].Split(',');
            i = slFields.IndexOfValue("Year");
            dtSite = DateTime.Parse("1/1/" + sParts[i]);
            i = slFields.IndexOfValue("JD");
            dtSite = dtSite.AddDays(Convert.ToDouble(sParts[i]) - 1);
            i = slFields.IndexOfValue("Hour");
            dtSite = dtSite.AddHours(Convert.ToDouble(sParts[i]));
            i = slFields.IndexOfValue("Minute");
            dtSite = dtSite.AddMinutes(Convert.ToDouble(sParts[i]));
            i = slFields.IndexOfValue("GMT_year");
            dtGMT = DateTime.Parse("1/1/" + sParts[i]);
            i = slFields.IndexOfValue("GMT_jd");
            dtGMT = dtGMT.AddDays(Convert.ToDouble(sParts[i]) - 1);
            i = slFields.IndexOfValue("GMT_hour");
            dtGMT = dtGMT.AddHours(Convert.ToDouble(sParts[i]));
            i = slFields.IndexOfValue("GMT_min");
            dtGMT = dtGMT.AddMinutes(Convert.ToDouble(sParts[i]));
            element = xmlDoc.CreateElement("GmtOffsetHours");
            element.InnerText = Convert.ToString(dtSite.Subtract(dtGMT).TotalHours);
            metadata.AppendChild(element);
            element = xmlDoc.CreateElement("ErrorDescription");
            metadata.AppendChild(element);
            for (int i2 = 0; i2 <= VariableCodes.Length - 1; i2++)
            {
                for (int k = 0; k <= slFields.Count - 1; k++)
                {
                    if (Convert.ToString(slFields.GetByIndex(k)) == Convert.ToString(VariableCodes[i2]))
                    {
                        found = xmlDoc;
                    }
                }
                if (found == null)
                {
                    throw new Exception("Variable " + VariableCodes[i2] + " not recorded at this site");
                }
            }
            int paramCount = VariableCodes.Length;
            int recordCount = 0;
            for (int k = sLines.Length - 1; k >= 1; k--)
            {
                sParts = sLines[k].Split(',');
                if (sParts.Length > 1)
                {
                    recordCount = k;
                    break;
                }
            }
            if (recordCount == 0)
            {
                throw new Exception("No time series values returned for site " + SiteCodeTS);
            }
            string[,] sValues = new string[paramCount, recordCount];
            string[] sTimes = new string[recordCount];
            for (int k = 1; k <= recordCount; k++)
            {
                sParts = sLines[k].Split(',');
                i = slFields.IndexOfValue("Year");
                dtSite = DateTime.Parse("1/1/" + sParts[i]);
                i = slFields.IndexOfValue("JD");
                dtSite = dtSite.AddDays(Convert.ToDouble(sParts[i]) - 1);
                i = slFields.IndexOfValue("Hour");
                dtSite = dtSite.AddHours(Convert.ToDouble(sParts[i]));
                i = slFields.IndexOfValue("Minute");
                dtSite = dtSite.AddMinutes(Convert.ToDouble(sParts[i]));
                sTimes[k - 1] = dtSite.ToShortDateString() + " " + dtSite.ToShortTimeString();
                for (int l = 0; l <= paramCount - 1; l++)
                {
                    i = slFields.IndexOfValue(VariableCodes[l]);
                    sValues[l, k - 1] = sParts[i].Trim();
                }
            }
            XmlElement timeseries;
            for (int l = 0; l <= paramCount - 1; l++)
            {
                timeseries = xmlDoc.CreateElement("TimeSeries");
                root.AppendChild(timeseries);
                timeseries.InnerXml = metadata.InnerXml;
                element = xmlDoc.CreateElement("VariableCode");
                element.InnerText = VariableCodes[l];
                timeseries.AppendChild(element);
                element = xmlDoc.CreateElement("Units");
                i = slFields.IndexOfValue(VariableCodes[l].Trim());
                element.InnerText = slUnits.GetByIndex(i).ToString();
                timeseries.AppendChild(element);
                parent = xmlDoc.CreateElement("Records");
                timeseries.AppendChild(parent);
                for (int k = 0; k <= recordCount - 1; k++)
                {
                    row = xmlDoc.CreateElement("Record");
                    parent.AppendChild(row);
                    element = xmlDoc.CreateElement("DateTime");
                    element.InnerText = sTimes[k];
                    row.AppendChild(element);
                    element = xmlDoc.CreateElement("Value");
                    element.InnerText = sValues[l, k];
                    row.AppendChild(element);
                }
            }
            return xmlDoc;
        }

        private string BuildAmeriFluxTSURL(string SiteCode, string[] VariableCodes, System.DateTime MinDate, System.DateTime MaxDate)
        {
            System.Text.StringBuilder urlBuilder = new System.Text.StringBuilder(200);
            urlBuilder.Append("http://cdiac.esd.ornl.gov/cgi-bin/broker?_PROGRAM=prog.write_somevars_amersite.sas&_SERVICE=default");
            for (long i = 0; i <= VariableCodes.Length - 1; i++)
            {
                if (VariableCodes[i] != "")
                {
                    urlBuilder.Append("&param=" + VariableCodes[i]);
                }
            }
            urlBuilder.Append("&dataset=" + SiteCode);
            urlBuilder.Append("&libname=DATA3");
            urlBuilder.Append("&mindate=" + MinDate.ToShortDateString());
            urlBuilder.Append("&maxdate=" + MaxDate.ToShortDateString());
            urlBuilder.Append("&csvfile=download");
            return urlBuilder.ToString();
        }

        private XmlDocument ParseSitesPageForSite(string SiteCode)
        {
            const string SITES_URL = "http://cdiac.esd.ornl.gov/programs/ameriflux/data_system/aamer.html";
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Site");
            xmlDoc.AppendChild(root);
            utils.AddChildElement(root, "Latitude");
            utils.AddChildElement(root, "Longitude");
            utils.AddChildElement(root, "State");
            utils.AddChildElement(root, "QueryURL", SITES_URL);
            utils.AddChildElement(root, "ErrorDescription");
            string page;
            try
            {
                page = utils.DownloadASCII(SITES_URL);
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not access AmeriFlux sites page. " + ex.Message);
                return xmlDoc;
            }
            int i = page.IndexOf("aa" + SiteCode + "_pf.html");
            if (i == -1)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not locate info for the given SiteCode");
                return xmlDoc;
            }
            try
            {
                page = page.Substring(0, i);
                i = page.LastIndexOf("name=");
                page = page.Substring(i);
                page = page.Substring(0, page.IndexOf("<"));
                utils.SetElementText(xmlDoc, "State", GetState(page));
                i = page.LastIndexOf("(");
                page = page.Substring(i + 1, page.LastIndexOf(")") - i - 1);
                i = page.IndexOf(",");
                string lat = page.Substring(0, i);
                string lon = page.Substring(i + 1, page.Length - i - 1);
                if (WSUtils.IsNumeric(lat) & WSUtils.IsNumeric(lon))
                {
                    utils.SetElementText(xmlDoc, "Latitude", lat);
                    utils.SetElementText(xmlDoc, "Longitude", lon);
                }
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not parse sites page. " + ex.Message);
                return xmlDoc;
            }
            return xmlDoc;
        }

        private XmlElement BuildVariableElement(string VariableCode, XmlDocument SiteDoc, XmlDocument TargetDoc, bool IncludeVariableDetails, bool IncludeSites, bool IncludeSiteDetails)
        {
            XmlElement variable;
            variable = TargetDoc.CreateElement("Variable");
            utils.AddChildElement(variable, "VariableCode", VariableCode);
            if (!(IncludeVariableDetails) & !(IncludeSites))
            {
                return variable;
            }
            if (IncludeVariableDetails)
            {
                utils.AddChildElement(variable, "VariableName");
                utils.AddChildElement(variable, "Units");
                utils.AddChildElement(variable, "VariableDescription", SiteDoc.SelectSingleNode("//VariableDescription").InnerText);
            }
            XmlElement sites;
            string query;
            query = "//Variable[VariableCode='" + VariableCode + "']";
            XmlNodeList nodes = SiteDoc.SelectNodes(query);
            if (nodes.Count == 0)
            {
                throw new Exception("No variables found for the given variable code");
            }
            SortedList slNames = new SortedList();
            SortedList slUnits = new SortedList();
            string units;
            string name;
            XmlElement element;
            XmlElement parent;
            foreach (XmlElement var in nodes)
            {
                element = var.SelectSingleNode("VariableName") as XmlElement;
                name = "";
                if (!(element == null))
                {
                    name = element.InnerText;
                    if (name != "")
                    {
                        if (!(slNames.ContainsKey(name)))
                        {
                            slNames.Add(name, name);
                        }
                    }
                }
                element = var.SelectSingleNode("Units") as XmlElement;
                units = "";
                if (!(element == null))
                {
                    units = element.InnerText;
                    if (units != "")
                    {
                        if (!(slUnits.ContainsKey(units)))
                        {
                            slUnits.Add(units, units);
                        }
                    }
                }
                if (IncludeSites)
                {
                    sites = TargetDoc.CreateElement("Sites");
                    variable.AppendChild(sites);
                    XmlElement site = TargetDoc.CreateElement("Site");
                    sites.AppendChild(site);
                    parent = var.ParentNode.ParentNode as XmlElement;
                    utils.AddChildElement(site, "SiteCode", parent.SelectSingleNode("SiteCode").InnerText);
                    if (IncludeSiteDetails)
                    {
                        element = parent.SelectSingleNode("SiteName") as XmlElement;
                        if (!(element == null))
                        {
                            utils.AddChildElement(site, "SiteName", element.InnerText);
                        }
                        else
                        {
                            utils.AddChildElement(site, "SiteName", "");
                        }
                        element = parent.SelectSingleNode("State") as XmlElement;
                        if (!(element == null))
                        {
                            utils.AddChildElement(site, "State", element.InnerText);
                        }
                        else
                        {
                            utils.AddChildElement(site, "State", "");
                        }
                        element = parent.SelectSingleNode("Latitude") as XmlElement;
                        if (!(element == null))
                        {
                            utils.AddChildElement(site, "Latitude", element.InnerText);
                        }
                        else
                        {
                            utils.AddChildElement(site, "Latitude", "");
                        }
                        element = parent.SelectSingleNode("Longitude") as XmlElement;
                        if (!(element == null))
                        {
                            utils.AddChildElement(site, "Longitude", element.InnerText);
                        }
                        else
                        {
                            utils.AddChildElement(site, "Longitude", "");
                        }
                        element = parent.SelectSingleNode("StartTSDate") as XmlElement;
                        if (!(element == null))
                        {
                            utils.AddChildElement(site, "StartTSDate", element.InnerText);
                        }
                        else
                        {
                            utils.AddChildElement(site, "StartTSDate", "");
                        }
                        element = parent.SelectSingleNode("EndTSDate") as XmlElement;
                        if (!(element == null))
                        {
                            utils.AddChildElement(site, "EndTSDate", element.InnerText);
                        }
                        else
                        {
                            utils.AddChildElement(site, "EndTSDate", "");
                        }
                        utils.AddChildElement(site, "VariableName", name);
                        utils.AddChildElement(site, "Units", units);
                    }
                    sites.SetAttribute("count", sites.SelectNodes("Site").Count.ToString());
                }
            }
            if (IncludeVariableDetails)
            {
                units = "";
                for (int i = 0; i <= slUnits.Count - 1; i++)
                {
                    if (units.Length == 0)
                    {
                        units = slUnits.GetKey(i).ToString();
                    }
                    else
                    {
                        units += "; " + slUnits.GetKey(i);
                    }
                }
                variable.SelectSingleNode("Units").InnerText = units;
                name = "";
                for (int i = 0; i <= slNames.Count - 1; i++)
                {
                    if (name.Length == 0)
                    {
                        name = slNames.GetKey(i).ToString();
                    }
                    else
                    {
                        name += "; " + slNames.GetKey(i);
                    }
                }
                variable.SelectSingleNode("VariableName").InnerText = name;
            }
            return variable;
        }

        private string GetSitesDatabase(bool QuerySitePages)
        {
            bool bReload = false;
            if (UseLocalSitesDatabase)
            {
                string sPath = System.AppDomain.CurrentDomain.BaseDirectory + "SiteFile.xml";
                if (!(System.IO.File.Exists(sPath)))
                {
                    bReload = true;
                }
                else
                {
                    if (DateTime.Now.Subtract(System.IO.File.GetLastWriteTime(sPath)).Days > 7)
                    {
                        bReload = true;
                    }
                }
                if (bReload)
                {
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(sPath);
                    string txt = BuildSitesInfo(true);
                    writer.Write(txt);
                    writer.Close();
                    writer = null;
                    return txt;
                }
                else
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(sPath);
                    string txt = reader.ReadToEnd();
                    reader.Close();
                    reader = null;
                    return txt;
                }
            }
            else
            {
                return BuildSitesInfo(QuerySitePages);
            }
        }

        //TODO change this to use a private table in OD
        private string BuildSitesInfo(bool QuerySitePages)
        {
            const string SITES_URL = "http://cdiac.esd.ornl.gov/programs/ameriflux/data_system/aamer.html";
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root;
            XmlElement element;
            root = xmlDoc.CreateElement("AmeriFlux.GetSites");
            xmlDoc.AppendChild(root);
            element = xmlDoc.CreateElement("ErrorDescription");
            root.AppendChild(element);
            element = utils.AddChildElement(root, "QueryURL", SITES_URL);
            element.SetAttribute("returns", "Locations and SiteCodes of sites");
            string page;
            try
            {
                page = utils.DownloadASCII(SITES_URL);
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not access AmeriFlux sites page. " + ex.Message);
                return xmlDoc.InnerXml;
            }
            SortedList slLinks = new SortedList();
            try
            {
                int i = page.IndexOf("Brazil:");
                string chunk = page.Substring(i, page.IndexOf("#Combined") - i);
                i = chunk.IndexOf("#");
                while (!(i == -1))
                {
                    chunk = chunk.Substring(i + 1);
                    i = chunk.IndexOf(">");
                    string txt = chunk.Substring(0, i);
                    if (txt.Substring(txt.Length - 1, 1) == "\"" | txt.Substring(txt.Length - 1, 1) == "'")
                    {
                        txt = txt.Substring(0, txt.Length - 1);
                    }
                    if (txt.Length > 0)
                    {
                        slLinks.Add(txt, txt);
                    }
                    chunk = chunk.Substring(i + 1);
                    i = chunk.IndexOf("#");
                }
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Could not parse AmeriFlux sites page to obtain named anchor site links. " + ex.Message);
                return xmlDoc.InnerXml;
            }
            if (slLinks.Count == 0)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "No site links found on AmeriFlux sites page");
                return xmlDoc.InnerXml;
            }
            page = page.Substring(page.IndexOf("#Combined"));
            XmlElement site;
            string link;
            try
            {
                for (int k = 0; k <= slLinks.Count - 1; k++)
                {
                    link = slLinks.GetByIndex(k).ToString();
                    int i = page.ToLower().IndexOf("name=" + link.ToLower() + ">");
                    if (i > -1)
                    {
                        string chunk = page.Substring(i);
                        chunk = chunk.Substring(chunk.IndexOf(">") + 1);
                        chunk = chunk.Substring(0, chunk.IndexOf("Create a download file"));
                        string header = chunk.Substring(0, chunk.IndexOf("<"));
                        site = xmlDoc.CreateElement("Site");
                        root.AppendChild(site);
                        utils.AddChildElement(site, "SiteCode", link);
                        utils.AddChildElement(site, "State", GetState(header));
                        utils.AddChildElement(site, "Country", GetCountry(header));
                        i = header.LastIndexOf("(");
                        header = header.Substring(i + 1, header.LastIndexOf(")") - i - 1);
                        i = header.IndexOf(",");
                        string lat = header.Substring(0, i);
                        string lon = header.Substring(i + 1, header.Length - i - 1);
                        if (WSUtils.IsNumeric(lat) & WSUtils.IsNumeric(lon))
                        {
                            utils.AddChildElement(site, "Latitude", lat);
                            utils.AddChildElement(site, "Longitude", lon);
                        }
                        else
                        {
                            utils.AddChildElement(site, "Latitude", "");
                            utils.AddChildElement(site, "Longitude", "");
                        }
                        i = chunk.IndexOf("_pf.html");
                        int j = chunk.LastIndexOf('=', i) + 1;
                        chunk = chunk.Substring(j, i - j);
                        if (chunk.Substring(0, 1) == "\"" | chunk.Substring(0, 1) == "'")
                        {
                            chunk = chunk.Substring(1, chunk.Length - 1);
                        }
                        link = chunk.Substring(2, chunk.Length - 2);
                        if (link.Length > 0)
                        {
                            site.SelectSingleNode("SiteCode").InnerText = link;
                            if (QuerySitePages)
                            {
                                XmlDocument siteDoc;
                                try
                                {
                                    siteDoc = ParseSitePage(link);
                                    utils.AddChildElement(site, "SiteName", siteDoc.SelectSingleNode("//SiteName").InnerText, site.SelectSingleNode("SiteCode") as XmlElement);
                                    utils.AddChildElement(site, "SiteCodeTS", siteDoc.SelectSingleNode("//SiteCodeTS").InnerText, site.SelectSingleNode("SiteCode") as XmlElement);
                                    utils.AddChildElement(site, "StartTSDate", siteDoc.SelectSingleNode("//StartTSDate").InnerText);
                                    utils.AddChildElement(site, "EndTSDate", siteDoc.SelectSingleNode("//EndTSDate").InnerText);
                                    element = utils.AddChildElement(site, "QueryURL", siteDoc.SelectSingleNode("//QueryURL").InnerText);
                                    element.SetAttribute("returns", "SiteName, Variables and Period of Record");
                                    XmlElement vars = xmlDoc.CreateElement("Variables");
                                    site.AppendChild(vars);
                                    vars.InnerXml = siteDoc.SelectSingleNode("//Variables").InnerXml;
                                    vars.SetAttribute("count", vars.SelectNodes("Variable").Count.ToString());
                                }
                                catch (Exception)
                                {
                                    root.RemoveChild(site);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                utils.SetElementText(xmlDoc, "ErrorDescription", "Error parsing site information on AmeriFlux sites page. " + ex.Message);
                return xmlDoc.InnerXml;
            }
            root.SetAttribute("count", xmlDoc.SelectNodes("//Site").Count.ToString());
            return xmlDoc.InnerXml;
        }

        private string GetCountry(string header)
        {
            if (header.ToLower().IndexOf("usa") > 0)
                return "USA";
            else if (header.ToLower().IndexOf("canada")>0)
                return "Canada";
            else if (header.ToLower().IndexOf("brazil")>0)
                return "Brazil";
            else if(header.ToLower().IndexOf("costa rica")>0)
                return "Costa Rica";

            return string.Empty;   
        }

        private string GetState(string txt)
        {
            if (txt.IndexOf("Alabama") > 0)
            {
                return "Alabama";
            }
            else if (txt.IndexOf("Alaska") > 0)
            {
                return "Alaska";
            }
            else if (txt.IndexOf("Arizona") > 0)
            {
                return "Arizona";
            }
            else if (txt.IndexOf("Arkansas") > 0)
            {
                return "Arkansas";
            }
            else if (txt.IndexOf("California") > 0)
            {
                return "California";
            }
            else if (txt.IndexOf("Colorado") > 0)
            {
                return "Colorado";
            }
            else if (txt.IndexOf("Connecticut") > 0)
            {
                return "Connecticut";
            }
            else if (txt.IndexOf("Delaware") > 0)
            {
                return "Delaware";
            }
            else if (txt.IndexOf("Florida") > 0)
            {
                return "Florida";
            }
            else if (txt.IndexOf("Georgia") > 0)
            {
                return "Georgia";
            }
            else if (txt.IndexOf("Hawaii") > 0)
            {
                return "Hawaii";
            }
            else if (txt.IndexOf("Idaho") > 0)
            {
                return "Idaho";
            }
            else if (txt.IndexOf("Illinois") > 0)
            {
                return "Illinois";
            }
            else if (txt.IndexOf("Indiana") > 0)
            {
                return "Indiana";
            }
            else if (txt.IndexOf("Iowa") > 0)
            {
                return "Iowa";
            }
            else if (txt.IndexOf("Kansas") > 0)
            {
                return "Kansas";
            }
            else if (txt.IndexOf("Kentucky") > 0)
            {
                return "Kentucky";
            }
            else if (txt.IndexOf("Louisiana") > 0)
            {
                return "Louisiana";
            }
            else if (txt.IndexOf("Maine") > 0)
            {
                return "Maine";
            }
            else if (txt.IndexOf("Maryland") > 0)
            {
                return "Maryland";
            }
            else if (txt.IndexOf("Massachusetts") > 0)
            {
                return "Massachusetts";
            }
            else if (txt.IndexOf("Michigan") > 0)
            {
                return "Michigan";
            }
            else if (txt.IndexOf("Minnesota") > 0)
            {
                return "Minnesota";
            }
            else if (txt.IndexOf("Mississippi") > 0)
            {
                return "Mississippi";
            }
            else if (txt.IndexOf("Missouri") > 0)
            {
                return "Missouri";
            }
            else if (txt.IndexOf("Montana") > 0)
            {
                return "Montana";
            }
            else if (txt.IndexOf("Nebraska") > 0)
            {
                return "Nebraska";
            }
            else if (txt.IndexOf("Nevada") > 0)
            {
                return "Nevada";
            }
            else if (txt.IndexOf("New Hampshire") > 0)
            {
                return "New Hampshire";
            }
            else if (txt.IndexOf("New Jersey") > 0)
            {
                return "New Jersey";
            }
            else if (txt.IndexOf("New Mexico") > 0)
            {
                return "New Mexico";
            }
            else if (txt.IndexOf("New York") > 0)
            {
                return "New York";
            }
            else if (txt.IndexOf("North Carolina") > 0)
            {
                return "North Carolina";
            }
            else if (txt.IndexOf("North Dakota") > 0)
            {
                return "North Dakota";
            }
            else if (txt.IndexOf("Ohio") > 0)
            {
                return "Ohio";
            }
            else if (txt.IndexOf("Oklahoma") > 0)
            {
                return "Oklahoma";
            }
            else if (txt.IndexOf("Oregon") > 0)
            {
                return "Oregon";
            }
            else if (txt.IndexOf("Pennsylvania") > 0)
            {
                return "Pennsylvania";
            }
            else if (txt.IndexOf("Rhode Island") > 0)
            {
                return "Rhode Island";
            }
            else if (txt.IndexOf("South Carolina") > 0)
            {
                return "South Carolina";
            }
            else if (txt.IndexOf("South Dakota") > 0)
            {
                return "South Dakota";
            }
            else if (txt.IndexOf("Tennessee") > 0)
            {
                return "Tennessee";
            }
            else if (txt.IndexOf("Texas") > 0)
            {
                return "Texas";
            }
            else if (txt.IndexOf("Utah") > 0)
            {
                return "Utah";
            }
            else if (txt.IndexOf("Vermont") > 0)
            {
                return "Vermont";
            }
            else if (txt.IndexOf("Virginia") > 0)
            {
                return "Virginia";
            }
            else if (txt.IndexOf("Washington") > 0)
            {
                return "Washington";
            }
            else if (txt.IndexOf("West Virginia") > 0)
            {
                return "West Virginia";
            }
            else if (txt.IndexOf("Wisconsin") > 0)
            {
                return "Wisconsin";
            }
            else if (txt.IndexOf("Wyoming") > 0)
            {
                return "Wyoming";
            }
            else
            {
                return "";
            }
        }

        private XmlDocument ParseSitePage(string SiteCode)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Site");
            xmlDoc.AppendChild(root);
            utils.AddChildElement(root, "SiteName");
            utils.AddChildElement(root, "SiteCodeTS");
            root = utils.AddChildElement(root, "Variables");
            string sURL = "http://cdiac.esd.ornl.gov/programs/ameriflux/data_system/aa" + SiteCode + "_pf.html";
            XmlElement element;
            element = utils.AddChildElement(xmlDoc.DocumentElement, "QueryURL", sURL);
            element.SetAttribute("returns", "Variables and Period of Record");
            string sTxt;
            sTxt = utils.DownloadASCII(sURL);
            int i;
            int j;
            XmlElement variable;
            string startDate;
            string endDate;
            i = sTxt.IndexOf("<b>") + 3;
            string txt = sTxt.Substring(i, sTxt.IndexOf("</b>") - i).Trim();
            utils.SetElementText(xmlDoc, "SiteName", txt);
            i = sTxt.IndexOf("NAME='dataset'") + 14;
            txt = sTxt.Substring(i);
            i = txt.IndexOf("VALUE='") + 7;
            txt = txt.Substring(i);
            i = txt.IndexOf("'");
            txt = txt.Substring(0, i);
            utils.SetElementText(xmlDoc, "SiteCodeTS", txt);
            i = sTxt.IndexOf("mindate' VALUE='") + 16;
            j = sTxt.IndexOf("'>", i);
            startDate = sTxt.Substring(i, j - i);
            i = sTxt.IndexOf("maxdate' VALUE='") + 16;
            j = sTxt.IndexOf("'>", i);
            endDate = sTxt.Substring(i, j - i);
            i = sTxt.IndexOf("<OPTION");
            j = sTxt.IndexOf("</SELECT>");
            string sSelect = sTxt.Substring(i, j - i - 1);
            string[] sParts;
            string sLine;
            string sName;
            string sUnits;
            sParts = sSelect.Split('\n');
            for (int k = 0; k <= sParts.Length - 1; k++)
            {
                sLine = sParts[k];
                if (sLine.Substring(0, 7) == "<OPTION")
                {
                    variable = xmlDoc.CreateElement("Variable");
                    i = sLine.IndexOf("VALUE=") + 7;
                    j = sLine.IndexOf(">", i);
                    sName = sLine.Substring(i, j - i - 1).Trim();
                    element = xmlDoc.CreateElement("VariableCode");
                    element.InnerText = sName;
                    variable.AppendChild(element);
                    sLine = sLine.Substring(j + 2 + sName.Length);
                    if (!string.IsNullOrEmpty(sLine) && sLine.LastIndexOf(")") == sLine.Length - 1)
                    {
                        i = sLine.LastIndexOf("(");
                        sUnits = sLine.Substring(i + 1, sLine.Length - i - 2);
                        sLine = sLine.Substring(0, i);
                    }
                    else
                    {
                        sUnits = "";
                    }
                    element = xmlDoc.CreateElement("VariableName");
                    element.InnerText = sLine.Trim();
                    variable.AppendChild(element);
                    element = xmlDoc.CreateElement("Units");
                    element.InnerText = sUnits.Trim();
                    variable.AppendChild(element);
                    element = xmlDoc.CreateElement("StartTSDate");
                    element.InnerText = startDate;
                    variable.AppendChild(element);
                    element = xmlDoc.CreateElement("EndTSDate");
                    element.InnerText = endDate;
                    variable.AppendChild(element);
                    element = xmlDoc.CreateElement("VariableDescription");
                    element.InnerText = "http://public.ornl.gov/ameriflux/standards-core.shtml";
                    variable.AppendChild(element);
                    root.AppendChild(variable);
                    if (sName.ToUpper() == "ELEVATION" || sName.ToUpper() == "LONGITUDE" || sName.ToUpper() == "LATITUDE" || sName.ToUpper() == "DAY" || sName.ToUpper() == "GMT_DAY" || sName.ToUpper() == "GMT_MONTH" || sName.ToUpper() == "MONTH" || sName.ToUpper() == "SITEDESC" || sName.ToUpper() == "SITENAME")
                    {
                        variable.SetAttribute("static", "True");
                    }
                }
            }
            return xmlDoc;
        }

        private string BuildAmeriFluxParamsURL(string SiteCode)
        {
            System.Text.StringBuilder urlBuilder = new System.Text.StringBuilder(100);
            urlBuilder.Append("http://cdiac.esd.ornl.gov/programs/ameriflux/data_system/aa");
            urlBuilder.Append(SiteCode);
            urlBuilder.Append("_pf.html");
            return urlBuilder.ToString();
        }

        private string GetStringBetweenChars(string strText, string char1, string char2)
        {
            int pos;
            pos = strText.IndexOf(char1);
            if (pos != -1)
            {
                strText = strText.Substring(pos);
                strText = strText.Substring(char1.Length);
                pos = strText.IndexOf(char2);
            }
            else
            {
                return "Error";
            }
            return strText.Substring(0, pos).Trim();
        }

        private int UpdateCursorPosition(string strText, string char1)
        {
            int pos;
            pos = strText.IndexOf(char1) + char1.Length;
            return pos;
        }

        private string DownloadAmeriFluxSiteFile(string webCode)
        {
            string sURL;
            sURL = BuildAmeriFluxSiteURL(webCode);
            string strText;
            strText = utils.DownloadASCII(sURL);
            string strTemp;
            int cPos;
            cPos = strText.IndexOf("USA");
            strText = strText.Substring(cPos);
            string siteCode;
            string shortName;
            string longName = string.Empty;
            string stateName = string.Empty;
            string latLong;
            string strLat;
            string strLong;
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root;
            XmlElement element;
            XmlElement sElement;
            XmlElement sParameter;
            string[] urlCodeTxt;
            string urlCode;
            root = xmlDoc.CreateElement("AmeriFlux.DownloadAmeriFluxSiteFile");
            xmlDoc.AppendChild(root);
            element = xmlDoc.CreateElement("USA_Sites");
            root.AppendChild(element);
            while (cPos != -1)
            {
                siteCode = GetStringBetweenChars(strText, "#", ">");
                siteCode = siteCode.Substring(0, siteCode.Length - 1);
                if (siteCode == "Ok_tg")
                {
                    stateName = "Oklahoma";
                    longName = "Oklahoma tall grass prairie";
                    urlCode = "oktg";
                }
                if (siteCode == "ARM")
                {
                    stateName = "Oklahoma";
                    longName = "ARM Oklahoma";
                    urlCode = "arm";
                }
                if (siteCode == "Ok_wt")
                {
                    urlCode = "okwt";
                    stateName = "Oklahoma";
                    longName = "Oklahoma winter wheat";
                }
                if (siteCode == "Combined")
                {
                    cPos = UpdateCursorPosition(strText, siteCode);
                    strText = strText.Substring(cPos);
                }
                else
                {
                    cPos = UpdateCursorPosition(strText, siteCode);
                    strText = strText.Substring(cPos);
                    shortName = GetStringBetweenChars(strText, "darkgreen>", "</");
                    cPos = UpdateCursorPosition(strText, shortName);
                    strText = strText.Substring(cPos);
                    cPos = UpdateCursorPosition(strText, siteCode + ">");
                    strTemp = strText.Substring(cPos - 1);
                    urlCodeTxt = GetStringBetweenChars(strTemp, "<a href=", "_pf").Split('=');
                    urlCode = urlCodeTxt[urlCodeTxt.GetUpperBound(0)].Substring(3);
                    cPos = UpdateCursorPosition(strTemp, "</");
                    strTemp = strTemp.Substring(0, cPos);
                    if (stateName == "")
                    {
                        stateName = GetStringBetweenChars(strTemp, ",", ", USA");
                        while ((stateName.Split(',').GetUpperBound(0)) > 0)
                        {
                            cPos = UpdateCursorPosition(stateName, ",");
                            stateName = stateName.Substring(cPos + 1);
                        }
                    }
                    if (longName == "")
                    {
                        longName = GetStringBetweenChars(strTemp, ">", ", " + stateName);
                    }
                    cPos = UpdateCursorPosition(strTemp, ", USA");
                    strTemp = strTemp.Substring(cPos);
                    latLong = GetStringBetweenChars(strTemp, "(", ")");
                    strLat = latLong.Split(',').GetValue(0).ToString();
                    strLong = latLong.Split(',').GetValue(1).ToString();
                    sElement = xmlDoc.CreateElement("Site");
                    element.AppendChild(sElement);
                    sParameter = xmlDoc.CreateElement("SiteCodeParam");
                    sParameter.InnerText = urlCode;
                    sElement.AppendChild(sParameter);
                    sParameter = xmlDoc.CreateElement("Name");
                    sParameter.InnerText = shortName;
                    sElement.AppendChild(sParameter);
                    sParameter = xmlDoc.CreateElement("LongName");
                    sParameter.InnerText = longName;
                    sElement.AppendChild(sParameter);
                    sParameter = xmlDoc.CreateElement("State");
                    sParameter.InnerText = stateName;
                    sElement.AppendChild(sParameter);
                    sParameter = xmlDoc.CreateElement("Latitude");
                    sParameter.InnerText = strLat;
                    sElement.AppendChild(sParameter);
                    sParameter = xmlDoc.CreateElement("Longitude");
                    sParameter.InnerText = strLong;
                    sElement.AppendChild(sParameter);
                }
                cPos = strText.IndexOf("#");
                stateName = "";
                longName = "";
            }
            return xmlDoc.InnerXml.ToString();
        }

        private string BuildAmeriFluxSiteURL(string SiteCode)
        {
            System.Text.StringBuilder urlBuilder = new System.Text.StringBuilder(100);
            urlBuilder.Append("http://cdiac.esd.ornl.gov/programs/ameriflux/data_system/");
            urlBuilder.Append(SiteCode);
            urlBuilder.Append(".html");
            return urlBuilder.ToString();
        }

    }
}