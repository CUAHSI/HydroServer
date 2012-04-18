using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Hydroserver.Models
{
    public class DataQueryRepository
    {

 #region " const string "
    //Variables
    
    private static string db_fld_VarCode  = "VariableCode"; //O String: 50 -> Code used by the organization that collects the data
    private static string db_fld_VarName  = "VariableName"; //M String: 255 -> CV. Name of the variable that was measured/observed/modeled

    private static string db_fld_SRSRSName  = "SRSName"; //M String: 255 -> Name of spatial reference system

    private static string db_fld_ValID  = "ValueID"; //M Integer: Primary Key ->Unique ID for each Values entry
    private static string db_fld_ValValue  = "DataValue"; //M Double -> The numeric value.  Holds the CategoryID for categorical data
    private static string db_fld_ValAccuracyStdDev  = "ValueAccuracy"; //O Double -> Estimated standard deviation
    private static string db_fld_ValDateTime  = "LocalDateTime"; //M Local date and time of the measurement
    private static string db_fld_ValUTCOffset  = "UTCOffset"; //M Offset in hours from UTC time
    private static string db_fld_ValUTCDateTime  = "DateTimeUTC"; //M UTC date and time of the measurement
    private static string db_fld_ValOffsetTypeID  = "OffsetTypeID"; //O Integer -> Linked to OffsetTypes.OffsetTypeID
    private static string db_fld_ValCensorCode  = "CensorCode"; //O String: 50 -> CV.  Whether the data is censored
    private static string db_fld_ValQualifierID  = "QualifierID"; //O Integer -> Linked to Qualifiers.QualifierID
    private static string db_fld_ValOffsetValue = "OffsetValue"; //O Double -> distance from a datum/control point at which the value was observed

    private static string db_fld_MethID  = "MethodID"; //M Integer: Primary Key -> Unique ID for each Methods entry
    private static string db_fld_MethDesc  = "MethodDescription"; //M String: 255 -> Text descriptionof each method including Quality Assurance and Quality Control procedures

    private static string db_fld_QlfyCode  = "QualifierCode"; //O String: 50 -> Text code used by organization that collects the data
    private static string db_fld_QlfyDesc  = "QualifierDescription"; //M String: 255 -> Text of the data qualifying comment

    private static string db_fld_QCLQCLevel  = "QualityControlLevelID"; //M Integer: Primary Key -> Pre-defined ID from 0 to 5
    private static string db_fld_QCLDefinition  = "Definition"; //M String: 255 -> Definition of Quality Control Level
    private static string db_fld_QCLExplanation  = "Explanation"; //M String: 500 -> Explanation of Quality Control Level

    private static string db_fld_SampleType  = "SampleType"; //M String: 50 -> CV specifying the sample type
    
    private static string db_fld_SiteCode  = "SiteCode"; //O String: 50 -> Code used by organization that collects the data
    private static string db_fld_SiteName  = "SiteName"; //O String: 255 -> Full name of sampling location
    private static string db_fld_SiteLat  = "Latitude"; //M Double -> Latitude in degrees w/ Decimals
    private static string db_fld_SiteLong  = "Longitude"; //M Double -> Longitude in degrees w/ Decimals 
   
    private static string db_fld_SrcOrg  = "Organization"; //M String: 50 -> Name of organization that collected the data itself.  not who held it
    private static string db_fld_SrcDesc  = "SourceDescription"; //M String: 255 -> Full text description of the source of the data

    private static string db_expr_VarUnits_Name = "VariableUnitsName";    
    private static string db_expr_VarUnits_Abbr = "VariableUnitsAbbreviation";
    

 #endregion
    /// <summary>
        /// Gets an ODMDbDataContext from the specified ODM database, containin all Sites, Sources,
        /// Variables, Time Series, Data Values, etc.
        /// </summary>
        /// <param name="odmDb">The odm db.</param>
        /// <returns></returns>
        public static ODMDbDataContext GetODMDbDataContext(ODMDatabase odmDb)
        {
            ConfigurationManager.AppSettings["OdmDbConnection"] = "server=" + odmDb.ServerAddress + ";Integrated Security=SSPI;database=" + odmDb.DatabaseName + ";user=" + odmDb.ODMUser + ";password=" + odmDb.ODMPassword + ";Trusted_Connection=false;";

            return new ODMDbDataContext();
        }

        /// <summary>
        /// Adds the regions to the DataQueryModel.
        /// </summary>
        /// <param name="dataQueryModel">The data query model.</param>
        /// <param name="db">The DB.</param>
        /// <param name="odmDb">The odm db.</param>
        /// <returns></returns>
        public static DataQueryModel AddRegions(DataQueryModel dataQueryModel, HISDataContext db)
        {
            var regionsList = from rg in db.Regions
                              orderby rg.RegionName
                              select rg;
            foreach (Region item in regionsList)
            {
                dataQueryModel.Regions.Add(new RegionModel() { Region = item });
            }
            return dataQueryModel;
        }

        /// <summary>
        /// Adds the sites, sources, and variables from an ODM database to the DataQueryModel.
        /// </summary>
        /// <param name="dataQueryModel">The data query model.</param>
        /// <param name="db2">The DB2.</param>
        /// <param name="odmDb">The odm db.</param>
        /// <returns></returns>
        //public static DataQueryModel AddSitesSourcesVars(DataQueryModel dataQueryModel, ODMDbDataContext db2, string odmDb)
        public static DataQueryModel AddSitesSourcesVars(DataQueryModel dataQueryModel, ODMDbDataContext db2, ODMDatabase odmDb)
        {
            //RegionIDs;

            foreach (var item in db2.Sites)
            { dataQueryModel.Sites.Add(new SiteModel() { Site = item, OdmDb = odmDb }); }
            foreach (var item in db2.Sources)
            { dataQueryModel.Sources.Add(new SourceModel() { Source = item, OdmDb = odmDb }); }
            var variableList = from vars in db2.Variables
                               orderby vars.VariableName
                               select vars;
            foreach (var item in variableList)
            { dataQueryModel.Variables.Add(new VariableModel() { Variable = item, OdmDb = odmDb }); }
            return dataQueryModel;
        }

        /// <summary>
        /// Converts a string of the format id@odmdb into a DbID.
        /// </summary>
        /// <param name="item">The string to be converted.</param>
        /// <returns></returns>
        public static DbID ParsedDbID(string item, HISDataContext db)
        {
            string[] parts = item.Split('@');
            List<ODMDatabase> dbList = (from dbs in db.ODMDatabases                         
                         where dbs.DatabaseID.ToString() == parts[1]
                         select dbs).ToList<ODMDatabase>();
            if (dbList.Count > 0)
            {
                return new DbID { ID = Convert.ToInt32(parts[0]), OdmDb = dbList.First() };
            }
            else
            {
                return new DbID { ID = Convert.ToInt32(parts[0]), OdmDb = new ODMDatabase() };
            }
        }

        /// <summary>
        /// Converts a list of unparsed DbID strings into DbIDs.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <returns></returns>
        public static DataQueryFormModel ParsedDataQueryForm(UnparsedDataQueryFormModel form, HISDataContext db)
        {
            DataQueryFormModel dataQueryForm = new DataQueryFormModel()
            {
                RegionIDs = new List<DbID>(),
                VariableIDs = new List<DbID>(),
                CustomVariable = form.CustomVariable
            };
               
            if (form.StartTime != null) { dataQueryForm.StartTime = Convert.ToDateTime(form.StartTime); }
                else { dataQueryForm.StartTime = null; }
            if (form.EndTime != null) { dataQueryForm.EndTime = Convert.ToDateTime(form.EndTime); }
                else { dataQueryForm.EndTime = null; }

            foreach (var item in form.RegionIDs) { dataQueryForm.RegionIDs.Add(ParsedDbID(item, db)); }

            if (form.VariableIDs != null)
            {
                foreach (var item in form.VariableIDs)
                {
                    if (item.Equals("None") != true)
                    {
                        dataQueryForm.VariableIDs.Add(ParsedDbID(item, db));
                    }
                }
            }

            return dataQueryForm;
        }

        /// <summary>
        /// Creates a StringWriter containing all specified data values to download in CSV format
        /// </summary>
        /// <param name="db">The original HISDataContext, containing a list of ODM databases.</param>
        /// <param name="dataQueryForm">The data query form.</param>
        /// <param name="form">The form.</param>
        /// <returns></returns>
        public static void Download(HISDataContext db, DataQueryFormModel dataQueryForm, FormCollection form)
        {
            var dataQueryModel = NewDataQueryModel(db, dataQueryForm);

            foreach (TimeSeriesModel item in dataQueryModel.SeriesCatalog)
            {
                if (IsChecked(form, (item.TimeSeries.SeriesID + "@" + item.OdmDb).ToString()))
                {
                    DownloadTimeSeries(db, dataQueryForm, form, item);
                }
            }

        }

        /// <summary>
        /// Downloads the time series.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="Downloader">The downloader.</param>
        /// <param name="item">The item.</param>
        public static void DownloadTimeSeries(HISDataContext db, DataQueryFormModel dataQueryForm, FormCollection form, TimeSeriesModel item)
        {
            var odmDb = db.ODMDatabases.SingleOrDefault(d => d.Title == item.OdmDb);

            using (ODMDbDataContext db2 = GetODMDbDataContext(odmDb))
            {
                var dataList = (from data in db2.DataValues
                                where (data.SiteID == item.TimeSeries.SiteID) &
                                      (data.SourceID == item.TimeSeries.SourceID) &
                                      (data.VariableID == item.TimeSeries.VariableID) &
                                      (dataQueryForm.StartTime != null ? (data.LocalDateTime.CompareTo(dataQueryForm.StartTime) >= 0) : true) &
                                      (dataQueryForm.EndTime != null ? (data.LocalDateTime.CompareTo(dataQueryForm.EndTime) <= 0) : true)
                                orderby data.LocalDateTime
                                select data).ToList();
                ExportMyDbData(dataList, ",", dataQueryForm, form, item);
            }
        }

       

        public static void WriteResponseLine (string newLine)
        {
            //HttpContext.Current.Response.Write(Environment.NewLine + newLine);
            HttpContext.Current.Response.Write(newLine);
        }
        private static void ExportMyDbData(List<DataValue> queryTable, string delimiter, DataQueryFormModel dataQueryForm, FormCollection form, TimeSeriesModel item)
        {
            //'Takes the MyDB QueryTable data and stores it in the selected .csv file
            //'Inputs:  QueryTable-> A table containing all the data to export
            //'         FullFileName->The filename and path to export to (including extension)
            //'Outputs: Returns true if successful
            ////         Saves the QueryTable to a comma/tab delimited table
                        
            string newLine = string.Empty;
            try
            {
                //'If using Comma Delimited Format
                //'write the headers
                //newLine += db_fld_SCSeriesID + delimiter);
                newLine += db_fld_ValID + delimiter;
                newLine += db_fld_ValValue + delimiter;
                newLine += db_fld_ValAccuracyStdDev + delimiter;
                newLine += db_fld_ValDateTime + delimiter;
                if (IsChecked(form, "selectTime"))
                { //OPTIONAL
                    newLine += db_fld_ValUTCDateTime + delimiter;
                    newLine += db_fld_ValUTCOffset + delimiter;
                }
                newLine += db_fld_SiteCode + delimiter;
                if (IsChecked(form, "selectSite"))
                { //OPTIONAL
                    newLine += db_fld_SiteName + delimiter;

                    newLine += db_fld_SiteLat + delimiter;
                    newLine += db_fld_SiteLong + delimiter;
                    newLine += db_fld_SRSRSName + delimiter;
                }
                newLine += db_fld_VarCode + delimiter;
                if (IsChecked(form, "selectVariable"))
                { //OPTIONAL
                    newLine += db_fld_VarName + delimiter;
                    //newLine += db_fld_VarSpeciation + delimiter;
                    newLine += db_expr_VarUnits_Name + delimiter;
                    newLine += db_expr_VarUnits_Abbr + delimiter;
                    //newLine += db_fld_VarSampleMed + delimiter;
                }
                newLine += db_fld_MethID + delimiter;
                if (IsChecked(form, "selectMethod"))
                { //OPTIONAL
                    newLine += db_fld_MethDesc + delimiter;
                }
                newLine += db_fld_ValOffsetValue + delimiter;
                newLine += db_fld_ValOffsetTypeID + delimiter;
                //if (IsChecked(form, "selectOffset"))
                //{ //OPTIONAL
                //    newLine += db_fld_OTDesc + delimiter;
                //    newLine += db_expr_OffsetUnits_Name + delimiter;
                //}
                newLine += db_fld_ValCensorCode + delimiter;
                newLine += db_fld_ValQualifierID + delimiter;
                if (IsChecked(form, "selectQualifier"))
                { //OPTIONAL
                    newLine += db_fld_QlfyCode + delimiter;
                    newLine += db_fld_QlfyDesc + delimiter;
                }
                if (IsChecked(form, "selectSource"))
                { //OPTIONAL
                    newLine += db_fld_SrcOrg + delimiter;
                    newLine += db_fld_SrcDesc + delimiter;
                    //newLine += db_fld_SrcCitation + delimiter;
                }
                if (IsChecked(form, "selectQualityControlLevels"))
                {
                    newLine += db_fld_QCLQCLevel + delimiter;
                    newLine += db_fld_QCLDefinition + delimiter;
                    newLine += db_fld_QCLExplanation + delimiter;
                }

                if (IsChecked(form, "selectSample"))
                { //OPTIONAL
                    newLine += db_fld_SampleType;
                }
                WriteResponseLine(newLine + Environment.NewLine);

                for (int i = 0; i < queryTable.Count - 1; i++)
                {

                    //Write each line of data, placing commas in between each value in the same row
                    //newLine += queryTable[i].serItem(db_fld_SCSeriesID) + delimiter;
                    newLine = queryTable[i].ValueID.ToString() + delimiter;
                    newLine += queryTable[i].DataValue1 + delimiter;
                    newLine += (queryTable[i].ValueAccuracy != null ? queryTable[i].ValueAccuracy.ToString() : "") + delimiter;
                    newLine += queryTable[i].LocalDateTime.ToString() + delimiter;
                    if (IsChecked(form, "selectTime"))
                    { //OPTIONAL
                        newLine += queryTable[i].DateTimeUTC.ToString() + delimiter;
                        newLine += queryTable[i].UTCOffset + delimiter;
                    }
                    newLine += "\"" + queryTable[i].Site.SiteCode.ToString() + "\"" + delimiter;
                    if (IsChecked(form, "selectSite")) 
                        if (queryTable[i].Site != null)
                        { //OPTIONAL
                            newLine += "\"" + queryTable[i].Site.SiteName + "\"" + delimiter;
                            newLine += queryTable[i].Site.Latitude + delimiter;
                            newLine += queryTable[i].Site.Longitude + delimiter;
                            newLine += queryTable[i].Site.VerticalDatum + delimiter;
                        }
                        else
                        {
                            newLine += delimiter;
                            newLine += delimiter;
                            newLine += delimiter;
                            newLine += delimiter;
                        }
                    newLine += queryTable[i].Variable.VariableCode + delimiter;
                    if (IsChecked(form, "selectVariable") )
                        if (queryTable[i].Variable != null)
                        { //OPTIONAL
                            newLine += "\"" + queryTable[i].Variable.VariableName + "\"" + delimiter;
                            //newLine +=  queryTable[i].Variable.Item(db_fld_VarSpeciation) +  delimiter;
                            newLine += queryTable[i].Variable.Unit.UnitsName + delimiter;
                            newLine += queryTable[i].Variable.Unit.UnitsAbbreviation + delimiter;
                            //newLine +=  queryTable[i].Variable.Item(db_fld_VarSampleMed) +  delimiter;
                        }
                        else
                        {
                            newLine += delimiter;
                            newLine += delimiter;
                            newLine += delimiter;
                        }

                    newLine += queryTable[i].MethodID + delimiter;
                    if (IsChecked(form, "selectMethod")) 
                        if (queryTable[i].Method != null)
                        { //OPTIONAL
                            newLine += "\"" + queryTable[i].Method.MethodDescription + "\"" + delimiter;
                        }
                        else
                        {
                            newLine += delimiter;
                        }

                    newLine += queryTable[i].OffsetValue + delimiter;
                    newLine += queryTable[i].OffsetTypeID + delimiter;
                    //if (IsChecked(form, "selectOffset"))
                    //{ //OPTIONAL
                    //    newLine +=  queryTable[i].Item(db_fld_OTDesc) +  delimiter;
                    //    newLine +=  queryTable[i].Item(db_expr_OffsetUnits_Name) +  delimiter;
                    //}

                    newLine += queryTable[i].CensorCode + delimiter;
                    newLine += queryTable[i].QualifierID + delimiter;
                    if (IsChecked(form, "selectQualifier")) 
                        if (queryTable[i].Qualifier != null)
                        { //OPTIONAL
                            newLine += "\"" + queryTable[i].Qualifier.QualifierCode + "\"" + delimiter;
                            newLine += "\"" + queryTable[i].Qualifier.QualifierDescription + "\"" + delimiter;
                        }
                        else
                        {
                            newLine += delimiter;
                            newLine += delimiter;
                        }
                    if (IsChecked(form, "selectSource")) 
                        if (queryTable[i].Source != null)
                        { //OPTIONAL;
                            newLine += "\"" + queryTable[i].Source.Organization + "\"" + delimiter;
                            newLine += "\"" + queryTable[i].Source.SourceDescription + "\"" + delimiter;
                            //newLine +=  queryTable[i].Source.Item(db_fld_SrcCitation) +  delimiter;
                        }
                        else
                        {
                            newLine += delimiter;
                            newLine += delimiter;
                        }
                    if (IsChecked(form, "selectQualityControlLevels"))
                        if (queryTable[i].QualityControlLevel != null)
                        { //OPTIONAL
                            newLine += queryTable[i].QualityControlLevelID + delimiter;
                            newLine += "\"" + queryTable[i].QualityControlLevel.Definition + "\"" + delimiter;
                            newLine += "\"" + queryTable[i].QualityControlLevel.Explanation + "\"" + delimiter;
                        }
                        else
                        {
                            newLine += delimiter;
                            newLine += delimiter;
                            newLine += delimiter;
                        }
                    newLine += queryTable[i].SampleID + "\n";
                    if (IsChecked(form, "selectSample"))
                        if (queryTable[i].Sample != null)
                        { //OPTIONAL
                            newLine += queryTable[i].Sample.SampleType;
                        }

                    WriteResponseLine(newLine);
                    if (i % 100 == 0)
                    {
                        HttpContext.Current.Response.Flush();

                    }

                }
            }

            catch (Exception ex)
            {
                //return false;
            }
        }


        /// <summary>
        /// Get a new DataQuerymodel.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public static DataQueryModel NewDataQueryModel(HISDataContext db)
        {
            return NewDataQueryModel(db, null);
        }

        /// <summary>
        /// Determines whether the specified form item is checked.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>true</c> if the specified form is checked; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsChecked(FormCollection form, string key)
        {
            return (form[key] == "on");
        }

        /// <summary>
        /// Get a new DataQueryModel from submitted information.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="dataQueryForm">The data query form.</param>
        /// <returns></returns>
        public static DataQueryModel NewDataQueryModel(HISDataContext db, DataQueryFormModel dataQueryForm)
        {
            var dataQueryModel = new DataQueryModel()
            {
                Regions = new List<RegionModel>(),
                Sites = new List<SiteModel>(),
                Sources = new List<SourceModel>(),
                Variables = new List<VariableModel>(),
                SeriesCatalog = new List<TimeSeriesModel>(),
                DataQueryForm = dataQueryForm
            };

            var items = db.ODMDatabases;
            //need to select databases that are in the regions that have been selected
            //get list of selected regions
            //loop through regions and get list of all databases in the regions


            dataQueryModel = DataQueryRepository.AddRegions(dataQueryModel, db);

            foreach (var odmDb in items)
            {
                ODMDbDataContext db2 = DataQueryRepository.GetODMDbDataContext(odmDb);

                dataQueryModel = DataQueryRepository.AddSitesSourcesVars(dataQueryModel, db2, odmDb);

                if (dataQueryForm != null)
                {
                    List<RegionDatabase> matches = (from rd in db.RegionDatabases
                                                    where (rd.DatabaseID == odmDb.DatabaseID)
                                                    select rd).ToList<RegionDatabase>();

                    var isInRegion = false;

                    if (matches != null)
                    {
                        foreach (var match in matches)
                        {
                            if (dataQueryForm.RegionIDs.Any(s => s.ID == match.RegionID))
                            {
                                isInRegion = true;
                            }
                        }
                    }

                    if (isInRegion)
                    {
                        foreach (var item in db2.TimeSeries)
                        {
                            if (dataQueryForm.VariableIDs.Count > 0)
                            {
                                if (
                                    dataQueryForm.VariableIDs.Any(s => (s.ID == item.VariableID) & (s.OdmDb == odmDb)) ||
                                    (
                                        (dataQueryForm.CustomVariable != null) &&
                                        db2.Variables.SingleOrDefault(v => v.VariableID == item.VariableID).VariableName.ToUpper().Contains(dataQueryForm.CustomVariable.ToUpper())
                                    )
                                    )
                                {
                                    dataQueryModel.SeriesCatalog.Add(new TimeSeriesModel() { TimeSeries = item, OdmDb = odmDb.Title });
                                }
                            }
                            else
                            {
                                if ((dataQueryForm.CustomVariable != null) &&
                                    db2.Variables.SingleOrDefault(v => v.VariableID == item.VariableID).VariableName.ToUpper().Contains(dataQueryForm.CustomVariable.ToUpper()))
                                {
                                    dataQueryModel.SeriesCatalog.Add(new TimeSeriesModel() { TimeSeries = item, OdmDb = odmDb.Title });
                                }
                            }
                        }
                    }
                }
            }
        

            var allRegionIDs = new List<DbID>();
            var allVarIDs = new List<DbID>();            


            foreach (var item in dataQueryModel.Regions) { allRegionIDs.Add(new DbID() { ID = item.Region.RegionID, OdmDb = item.OdmDb }); }
            foreach (var item in dataQueryModel.Variables) { allVarIDs.Add(new DbID() { ID = item.Variable.VariableID, OdmDb = item.OdmDb });  }

            //how can i tell what regions are selected
            foreach (var item in dataQueryModel.Variables)
            {
                List<RegionDatabase> matches2 = (from rd in db.RegionDatabases
                                                 where (rd.DatabaseID == item.OdmDb.DatabaseID)
                                                 select rd).ToList<RegionDatabase>();
                if (matches2.Count > 0)
                {
                    if (dataQueryForm != null)
                    {
                        if (dataQueryForm.RegionIDs.Any(s => s.ID == matches2.First().RegionID))
                            allVarIDs.Add(new DbID() { ID = item.Variable.VariableID, OdmDb = item.OdmDb });
                    }
                }
            }

            if (dataQueryModel.DataQueryForm == null)
            {
                dataQueryModel.DataQueryForm = new DataQueryFormModel()
                {
                    RegionIDs = allRegionIDs,
                    VariableIDs = allVarIDs
                };
            }

            return dataQueryModel;
        }
    }
}
