using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace HydroServer.Framework.Models
{
    public class DataQueryRepository
    {
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
            foreach (Region item in db.Regions)
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
        public static DataQueryModel AddSitesSourcesVars(DataQueryModel dataQueryModel, ODMDbDataContext db2, string odmDb)
        {
            foreach (var item in db2.Sites)
            { dataQueryModel.Sites.Add(new SiteModel() { Site = item, OdmDb = odmDb }); }
            foreach (var item in db2.Sources)
            { dataQueryModel.Sources.Add(new SourceModel() { Source = item, OdmDb = odmDb }); }
            foreach (var item in db2.Variables)
            { dataQueryModel.Variables.Add(new VariableModel() { Variable = item, OdmDb = odmDb }); }
            return dataQueryModel;
        }

        /// <summary>
        /// Converts a string of the format id@odmdb into a DbID.
        /// </summary>
        /// <param name="item">The string to be converted.</param>
        /// <returns></returns>
        public static DbID ParsedDbID(string item)
        {
            string[] parts = item.Split('@');

            return new DbID { ID = Convert.ToInt32(parts[0]), OdmDb = parts[1] };
        }

        /// <summary>
        /// Converts a list of unparsed DbID strings into DbIDs.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <returns></returns>
        public static DataQueryFormModel ParsedDataQueryForm(UnparsedDataQueryFormModel form)
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

            foreach (var item in form.RegionIDs) { dataQueryForm.RegionIDs.Add(ParsedDbID(item)); }

            if (form.VariableIDs != null)
            {
                foreach (var item in form.VariableIDs)
                {
                    if (item.Equals("None") != true)
                    {
                        dataQueryForm.VariableIDs.Add(ParsedDbID(item));
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

                string newLine = "Time,Value";

                string[] vars = { "Unit", "Variable", "Site", "Source", "Method", "Sample", "QualityControlLevel" };

                foreach (var thisVar in vars)
                {
                    if (IsChecked(form, "select" + thisVar)) { newLine = newLine + "," + thisVar; }
                }
                try
                {
                    HttpContext.Current.Response.Write(newLine);                    
                }
                catch 
                { 

                }


                foreach (var data in dataList)
                {
                    var varDictionary = new Dictionary<string, string>()
                    {
                        { "Unit", data.Variable.Unit.UnitsName != null ? data.Variable.Unit.UnitsName : "" },
                        { "Variable", data.Variable != null ? data.Variable.VariableName + "(" + data.Variable.DataType + ")" : ""  },
                        { "Site", data.Site != null ? data.Site.SiteName : "" },
                        { "Source", data.Source != null ? data.Source.Organization : ""  },
                        { "Method", data.Method != null ? data.Method.MethodDescription : ""  },
                        { "Sample", data.Sample != null ? data.Sample.SampleType : ""  },
                        { "QualityControlLevel", data.QualityControlLevel != null ? data.QualityControlLevel.Definition : ""  }
                    };

                    newLine = @"""" + data.LocalDateTime + @""",""" +
                        data.DataValue1 + @"""";

                    foreach (var thisVar in varDictionary)
                    {
                        if (IsChecked(form, "select" + thisVar.Key))
                        {
                            newLine = newLine + @",""" + thisVar.Value + @"""";
                        }
                    }

                    HttpContext.Current.Response.Write(Environment.NewLine + newLine);
                    HttpContext.Current.Response.Flush();
                }

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

            dataQueryModel = DataQueryRepository.AddRegions(dataQueryModel, db);

            foreach (var odmDb in items)
            {
                ODMDbDataContext db2 = DataQueryRepository.GetODMDbDataContext(odmDb);

                dataQueryModel = DataQueryRepository.AddSitesSourcesVars(dataQueryModel, db2, odmDb.Title);

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
                                    dataQueryForm.VariableIDs.Any(s => (s.ID == item.VariableID) & (s.OdmDb == odmDb.Title)) ||
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
            foreach (var item in dataQueryModel.Variables) { allVarIDs.Add(new DbID() { ID = item.Variable.VariableID, OdmDb = item.OdmDb }); }

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
