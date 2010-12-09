using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBLayer
{
    public class TimeSeriesResourcesList
    {
        public List<TimeSeriesResource> timeResourcesLocal = new List<TimeSeriesResource>();

        /* This method loads  timeseries records into TimeSeriesResourcesList object from HydroSecurity Database given the required 5 parameters  */
        public void Load(TimeSeriesResource timeRes)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "SELECT timeseriesresourceid as timeseriesresourceid, timeseriesmetadataid as timeseriesmetadataid, SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,citation as citation,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount, DateCreated as datecreated, DatabaseName as databasename, WaterOneFlowWSDL as wateroneflowwsdl FROM TimeSeriesResource  where " + FormulateQuery(timeRes) + ";";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    TimeSeriesResource timeSeriesResources = new TimeSeriesResource();
                    Guid d = new Guid(row["timeseriesresourceid"].ToString());
                    Guid m = new Guid(row["timeseriesmetadataid"].ToString());
                    timeSeriesResources.dataGuid = d;
                    timeSeriesResources.metadataGuid = m;
                    timeSeriesResources.seriesId = Convert.ToInt16(row["seriesid"].ToString());
                    timeSeriesResources.siteId = Convert.ToInt16(row["siteid"].ToString());
                    timeSeriesResources.siteCode = row["sitecode"].ToString();
                    timeSeriesResources.siteName = row["sitename"].ToString();
                    timeSeriesResources.variableId = Convert.ToInt16(row["variableid"].ToString());
                    timeSeriesResources.variableCode = row["variablecode"].ToString();
                    timeSeriesResources.variableName = row["variablename"].ToString();
                    timeSeriesResources.speciation = row["speciation"].ToString();
                    timeSeriesResources.variableUnitsId = Convert.ToInt16(row["variableunitsid"].ToString());
                    timeSeriesResources.variableUnitsName = row["variableunitsname"].ToString();
                    timeSeriesResources.sampleMedium = row["samplemedium"].ToString();
                    timeSeriesResources.valueType = row["valuetype"].ToString();
                    timeSeriesResources.timeSupport = Convert.ToDouble(row["timesupport"].ToString());
                    timeSeriesResources.timeUnitsId = Convert.ToInt16(row["timeunitsid"].ToString());
                    timeSeriesResources.timeUnitsName = row["timeunitsname"].ToString();
                    timeSeriesResources.dataType = row["datatype"].ToString();
                    timeSeriesResources.generalCategory = row["generalcategory"].ToString();
                    timeSeriesResources.methodId = Convert.ToInt16(row["methodid"].ToString());
                    timeSeriesResources.methodDescription = row["methoddescription"].ToString();
                    timeSeriesResources.sourceId = Convert.ToInt16(row["sourceid"].ToString());
                    timeSeriesResources.organization = row["organization"].ToString();
                    timeSeriesResources.sourceDescription = row["sourcedescription"].ToString();
                    timeSeriesResources.citation = row["citation"].ToString();
                    timeSeriesResources.qualityControLlevelId = Convert.ToInt16(row["qualitycontrollevelid"].ToString());
                    timeSeriesResources.qualityControlLevelCode = row["qualitycontrollevelcode"].ToString();
                    timeSeriesResources.valueCount = Convert.ToInt32(row["valuecount"].ToString());
                    timeSeriesResources.dateCreated = Convert.ToDateTime(row["datecreated"].ToString());
                    timeSeriesResources.databaseName = row["databasename"].ToString();
                    timeSeriesResources.waterOneflowWSDL = row["wateroneflowwsdl"].ToString();
                    this.timeResourcesLocal.Add(timeSeriesResources);
                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

        }

        /* this method loads  timeseries record into TimeSeriesResourcesList object from HydroSecurity database given a guid*/
        public void Load(Guid gn)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "SELECT timeseriesresourceid as timeseriesresourceid, timeseriesmetadataid as timeseriesmetadataid, SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,citation as citation,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount, DateCreated as datecreated, DatabaseName as databasename, WaterOneFlowWSDL as wateroneflowwsdl FROM TimeSeriesResource where timeseriesresourceid ='" + gn + "' ;";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    TimeSeriesResource timeSeriesResources = new TimeSeriesResource();
                    Guid d = new Guid(row["timeseriesresourceid"].ToString());
                    Guid m = new Guid(row["timeseriesmetadataid"].ToString());
                    timeSeriesResources.dataGuid = d;
                    timeSeriesResources.metadataGuid = m;
                    timeSeriesResources.seriesId = Convert.ToInt16(row["seriesid"].ToString());
                    timeSeriesResources.siteId = Convert.ToInt16(row["siteid"].ToString());
                    timeSeriesResources.siteCode = row["sitecode"].ToString();
                    timeSeriesResources.siteName = row["sitename"].ToString();
                    timeSeriesResources.variableId = Convert.ToInt16(row["variableid"].ToString());
                    timeSeriesResources.variableCode = row["variablecode"].ToString();
                    timeSeriesResources.variableName = row["variablename"].ToString();
                    timeSeriesResources.speciation = row["speciation"].ToString();
                    timeSeriesResources.variableUnitsId = Convert.ToInt16(row["variableunitsid"].ToString());
                    timeSeriesResources.variableUnitsName = row["variableunitsname"].ToString();
                    timeSeriesResources.sampleMedium = row["samplemedium"].ToString();
                    timeSeriesResources.valueType = row["valuetype"].ToString();
                    timeSeriesResources.timeSupport = Convert.ToDouble(row["timesupport"].ToString());
                    timeSeriesResources.timeUnitsId = Convert.ToInt16(row["timeunitsid"].ToString());
                    timeSeriesResources.timeUnitsName = row["timeunitsname"].ToString();
                    timeSeriesResources.dataType = row["datatype"].ToString();
                    timeSeriesResources.generalCategory = row["generalcategory"].ToString();
                    timeSeriesResources.methodId = Convert.ToInt16(row["methodid"].ToString());
                    timeSeriesResources.methodDescription = row["methoddescription"].ToString();
                    timeSeriesResources.sourceId = Convert.ToInt16(row["sourceid"].ToString());
                    timeSeriesResources.organization = row["organization"].ToString();
                    timeSeriesResources.sourceDescription = row["sourcedescription"].ToString();
                    timeSeriesResources.citation = row["citation"].ToString();
                    timeSeriesResources.qualityControLlevelId = Convert.ToInt16(row["qualitycontrollevelid"].ToString());
                    timeSeriesResources.qualityControlLevelCode = row["qualitycontrollevelcode"].ToString();
                    timeSeriesResources.valueCount = Convert.ToInt32(row["valuecount"].ToString());
                    timeSeriesResources.dateCreated = Convert.ToDateTime(row["datecreated"].ToString());
                    timeSeriesResources.databaseName = row["databasename"].ToString();
                    timeSeriesResources.waterOneflowWSDL = row["wateroneflowwsdl"].ToString();
                    this.timeResourcesLocal.Add(timeSeriesResources);
                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }


        }

        /* this method load entire records into TimeSeriesResourcesList object from HydroSecurity Database*/
        public void GetEntireByDate()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "SELECT timeseriesresourceid as timeseriesresourceid, timeseriesmetadataid as timeseriesmetadataid, SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,citation as citation,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount, DateCreated as datecreated, DatabaseName as databasename, WaterOneFlowWSDL as wateroneflowwsdl FROM TimeSeriesResource ;";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    TimeSeriesResource timeSeriesResources = new TimeSeriesResource();
                    Guid d = new Guid(row["timeseriesresourceid"].ToString());
                    Guid m = new Guid(row["timeseriesmetadataid"].ToString());
                    timeSeriesResources.dataGuid = d;
                    timeSeriesResources.metadataGuid = m;
                    timeSeriesResources.seriesId = Convert.ToInt16(row["seriesid"].ToString());
                    timeSeriesResources.siteId = Convert.ToInt16(row["siteid"].ToString());
                    timeSeriesResources.siteCode = row["sitecode"].ToString();
                    timeSeriesResources.siteName = row["sitename"].ToString();
                    timeSeriesResources.variableId = Convert.ToInt16(row["variableid"].ToString());
                    timeSeriesResources.variableCode = row["variablecode"].ToString();
                    timeSeriesResources.variableName = row["variablename"].ToString();
                    timeSeriesResources.speciation = row["speciation"].ToString();
                    timeSeriesResources.variableUnitsId = Convert.ToInt16(row["variableunitsid"].ToString());
                    timeSeriesResources.variableUnitsName = row["variableunitsname"].ToString();
                    timeSeriesResources.sampleMedium = row["samplemedium"].ToString();
                    timeSeriesResources.valueType = row["valuetype"].ToString();
                    timeSeriesResources.timeSupport = Convert.ToDouble(row["timesupport"].ToString());
                    timeSeriesResources.timeUnitsId = Convert.ToInt16(row["timeunitsid"].ToString());
                    timeSeriesResources.timeUnitsName = row["timeunitsname"].ToString();
                    timeSeriesResources.dataType = row["datatype"].ToString();
                    timeSeriesResources.generalCategory = row["generalcategory"].ToString();
                    timeSeriesResources.methodId = Convert.ToInt16(row["methodid"].ToString());
                    timeSeriesResources.methodDescription = row["methoddescription"].ToString();
                    timeSeriesResources.sourceId = Convert.ToInt16(row["sourceid"].ToString());
                    timeSeriesResources.organization = row["organization"].ToString();
                    timeSeriesResources.sourceDescription = row["sourcedescription"].ToString();
                    timeSeriesResources.citation = row["citation"].ToString();
                    timeSeriesResources.qualityControLlevelId = Convert.ToInt16(row["qualitycontrollevelid"].ToString());
                    timeSeriesResources.qualityControlLevelCode = row["qualitycontrollevelcode"].ToString();
                    timeSeriesResources.valueCount = Convert.ToInt32(row["valuecount"].ToString());
                    timeSeriesResources.dateCreated = Convert.ToDateTime(row["datecreated"].ToString());
                    timeSeriesResources.databaseName = row["databasename"].ToString();
                    timeSeriesResources.waterOneflowWSDL = row["wateroneflowwsdl"].ToString();
                    this.timeResourcesLocal.Add(timeSeriesResources);
                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }

        /* this method load  records into TimeSeriesResourcesList object from HydroSecurity Database given startDate*/
        public void GetByStartDate(DateTime startDateTime)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "SELECT timeseriesresourceid as timeseriesresourceid, timeseriesmetadataid as timeseriesmetadataid, SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,citation as citation,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount, DateCreated as datecreated, DatabaseName as databasename, WaterOneFlowWSDL as wateroneflowwsdl FROM TimeSeriesResource where datecreated >= ' "+startDateTime+"';";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    TimeSeriesResource timeSeriesResources = new TimeSeriesResource();
                    Guid d = new Guid(row["timeseriesresourceid"].ToString());
                    Guid m = new Guid(row["timeseriesmetadataid"].ToString());
                    timeSeriesResources.dataGuid = d;
                    timeSeriesResources.metadataGuid = m;
                    timeSeriesResources.seriesId = Convert.ToInt16(row["seriesid"].ToString());
                    timeSeriesResources.siteId = Convert.ToInt16(row["siteid"].ToString());
                    timeSeriesResources.siteCode = row["sitecode"].ToString();
                    timeSeriesResources.siteName = row["sitename"].ToString();
                    timeSeriesResources.variableId = Convert.ToInt16(row["variableid"].ToString());
                    timeSeriesResources.variableCode = row["variablecode"].ToString();
                    timeSeriesResources.variableName = row["variablename"].ToString();
                    timeSeriesResources.speciation = row["speciation"].ToString();
                    timeSeriesResources.variableUnitsId = Convert.ToInt16(row["variableunitsid"].ToString());
                    timeSeriesResources.variableUnitsName = row["variableunitsname"].ToString();
                    timeSeriesResources.sampleMedium = row["samplemedium"].ToString();
                    timeSeriesResources.valueType = row["valuetype"].ToString();
                    timeSeriesResources.timeSupport = Convert.ToDouble(row["timesupport"].ToString());
                    timeSeriesResources.timeUnitsId = Convert.ToInt16(row["timeunitsid"].ToString());
                    timeSeriesResources.timeUnitsName = row["timeunitsname"].ToString();
                    timeSeriesResources.dataType = row["datatype"].ToString();
                    timeSeriesResources.generalCategory = row["generalcategory"].ToString();
                    timeSeriesResources.methodId = Convert.ToInt16(row["methodid"].ToString());
                    timeSeriesResources.methodDescription = row["methoddescription"].ToString();
                    timeSeriesResources.sourceId = Convert.ToInt16(row["sourceid"].ToString());
                    timeSeriesResources.organization = row["organization"].ToString();
                    timeSeriesResources.sourceDescription = row["sourcedescription"].ToString();
                    timeSeriesResources.citation = row["citation"].ToString();
                    timeSeriesResources.qualityControLlevelId = Convert.ToInt16(row["qualitycontrollevelid"].ToString());
                    timeSeriesResources.qualityControlLevelCode = row["qualitycontrollevelcode"].ToString();
                    timeSeriesResources.valueCount = Convert.ToInt32(row["valuecount"].ToString());
                    timeSeriesResources.dateCreated = Convert.ToDateTime(row["datecreated"].ToString());
                    timeSeriesResources.databaseName = row["databasename"].ToString();
                    timeSeriesResources.waterOneflowWSDL = row["wateroneflowwsdl"].ToString();
                    this.timeResourcesLocal.Add(timeSeriesResources);
                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

        }

        /* this method load  records into TimeSeriesResourcesList object from HydroSecurity Database given endDateTime*/
        public void GetByEndDate(DateTime endDateTime)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "SELECT timeseriesresourceid as timeseriesresourceid, timeseriesmetadataid as timeseriesmetadataid, SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,citation as citation,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount, DateCreated as datecreated, DatabaseName as databasename, WaterOneFlowWSDL as wateroneflowwsdl FROM TimeSeriesResource where datecreated <= ' " + endDateTime + "';";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    TimeSeriesResource timeSeriesResources = new TimeSeriesResource();
                    Guid d = new Guid(row["timeseriesresourceid"].ToString());
                    Guid m = new Guid(row["timeseriesmetadataid"].ToString());
                    timeSeriesResources.dataGuid = d;
                    timeSeriesResources.metadataGuid = m;
                    timeSeriesResources.seriesId = Convert.ToInt16(row["seriesid"].ToString());
                    timeSeriesResources.siteId = Convert.ToInt16(row["siteid"].ToString());
                    timeSeriesResources.siteCode = row["sitecode"].ToString();
                    timeSeriesResources.siteName = row["sitename"].ToString();
                    timeSeriesResources.variableId = Convert.ToInt16(row["variableid"].ToString());
                    timeSeriesResources.variableCode = row["variablecode"].ToString();
                    timeSeriesResources.variableName = row["variablename"].ToString();
                    timeSeriesResources.speciation = row["speciation"].ToString();
                    timeSeriesResources.variableUnitsId = Convert.ToInt16(row["variableunitsid"].ToString());
                    timeSeriesResources.variableUnitsName = row["variableunitsname"].ToString();
                    timeSeriesResources.sampleMedium = row["samplemedium"].ToString();
                    timeSeriesResources.valueType = row["valuetype"].ToString();
                    timeSeriesResources.timeSupport = Convert.ToDouble(row["timesupport"].ToString());
                    timeSeriesResources.timeUnitsId = Convert.ToInt16(row["timeunitsid"].ToString());
                    timeSeriesResources.timeUnitsName = row["timeunitsname"].ToString();
                    timeSeriesResources.dataType = row["datatype"].ToString();
                    timeSeriesResources.generalCategory = row["generalcategory"].ToString();
                    timeSeriesResources.methodId = Convert.ToInt16(row["methodid"].ToString());
                    timeSeriesResources.methodDescription = row["methoddescription"].ToString();
                    timeSeriesResources.sourceId = Convert.ToInt16(row["sourceid"].ToString());
                    timeSeriesResources.organization = row["organization"].ToString();
                    timeSeriesResources.sourceDescription = row["sourcedescription"].ToString();
                    timeSeriesResources.citation = row["citation"].ToString();
                    timeSeriesResources.qualityControLlevelId = Convert.ToInt16(row["qualitycontrollevelid"].ToString());
                    timeSeriesResources.qualityControlLevelCode = row["qualitycontrollevelcode"].ToString();
                    timeSeriesResources.valueCount = Convert.ToInt32(row["valuecount"].ToString());
                    timeSeriesResources.dateCreated = Convert.ToDateTime(row["datecreated"].ToString());
                    timeSeriesResources.databaseName = row["databasename"].ToString();
                    timeSeriesResources.waterOneflowWSDL = row["wateroneflowwsdl"].ToString();
                    this.timeResourcesLocal.Add(timeSeriesResources);
                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }

        /* this method load  records into TimeSeriesResourcesList object from HydroSecurity Database given startDateTime and endDateTime*/
        public void GetBetweenDates(DateTime startDateTime,DateTime endDateTime)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "SELECT timeseriesresourceid as timeseriesresourceid, timeseriesmetadataid as timeseriesmetadataid, SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,citation as citation,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount, DateCreated as datecreated, DatabaseName as databasename, WaterOneFlowWSDL as wateroneflowwsdl FROM TimeSeriesResource where datecreated >= ' " + startDateTime + "' and datecreated <= '"+endDateTime+"';";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    TimeSeriesResource timeSeriesResources = new TimeSeriesResource();
                    Guid d = new Guid(row["timeseriesresourceid"].ToString());
                    Guid m = new Guid(row["timeseriesmetadataid"].ToString());
                    timeSeriesResources.dataGuid = d;
                    timeSeriesResources.metadataGuid = m;
                    timeSeriesResources.seriesId = Convert.ToInt16(row["seriesid"].ToString());
                    timeSeriesResources.siteId = Convert.ToInt16(row["siteid"].ToString());
                    timeSeriesResources.siteCode = row["sitecode"].ToString();
                    timeSeriesResources.siteName = row["sitename"].ToString();
                    timeSeriesResources.variableId = Convert.ToInt16(row["variableid"].ToString());
                    timeSeriesResources.variableCode = row["variablecode"].ToString();
                    timeSeriesResources.variableName = row["variablename"].ToString();
                    timeSeriesResources.speciation = row["speciation"].ToString();
                    timeSeriesResources.variableUnitsId = Convert.ToInt16(row["variableunitsid"].ToString());
                    timeSeriesResources.variableUnitsName = row["variableunitsname"].ToString();
                    timeSeriesResources.sampleMedium = row["samplemedium"].ToString();
                    timeSeriesResources.valueType = row["valuetype"].ToString();
                    timeSeriesResources.timeSupport = Convert.ToDouble(row["timesupport"].ToString());
                    timeSeriesResources.timeUnitsId = Convert.ToInt16(row["timeunitsid"].ToString());
                    timeSeriesResources.timeUnitsName = row["timeunitsname"].ToString();
                    timeSeriesResources.dataType = row["datatype"].ToString();
                    timeSeriesResources.generalCategory = row["generalcategory"].ToString();
                    timeSeriesResources.methodId = Convert.ToInt16(row["methodid"].ToString());
                    timeSeriesResources.methodDescription = row["methoddescription"].ToString();
                    timeSeriesResources.sourceId = Convert.ToInt16(row["sourceid"].ToString());
                    timeSeriesResources.organization = row["organization"].ToString();
                    timeSeriesResources.sourceDescription = row["sourcedescription"].ToString();
                    timeSeriesResources.citation = row["citation"].ToString();
                    timeSeriesResources.qualityControLlevelId = Convert.ToInt16(row["qualitycontrollevelid"].ToString());
                    timeSeriesResources.qualityControlLevelCode = row["qualitycontrollevelcode"].ToString();
                    timeSeriesResources.valueCount = Convert.ToInt32(row["valuecount"].ToString());
                    timeSeriesResources.dateCreated = Convert.ToDateTime(row["datecreated"].ToString());
                    timeSeriesResources.databaseName = row["databasename"].ToString();
                    timeSeriesResources.waterOneflowWSDL = row["wateroneflowwsdl"].ToString();
                    this.timeResourcesLocal.Add(timeSeriesResources);
                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }

        /* This method saves entire timeseries records from TimeSeriesResourcesList object into HydroSecurity Database */
        //public void save()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
        //    SqlConnection myConnection = new SqlConnection(connectionString);
        //    foreach(TimeSeriesResource tr in this.timeResourcesLocal)
        //    {
        //    try
        //    {
        //        Guid timeSeriesResourceId = System.Guid.NewGuid();
        //        myConnection.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = myConnection;
        //        string queryString = "insert into timeseriesresources values('"+ timeSeriesResourceId +"','" + tr.variableCode + "','" + tr.siteCode + "'," + tr.methodId+ "," + tr.sourceId+ "," + tr.qualityControlId+ ")";
        //        cmd.CommandText = queryString;
        //        cmd.ExecuteNonQuery();
        //        myConnection.Close();

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("this is not successful :" + e.Message.ToString());
        //    }
        //    }
        //}

        /* This method updates entire timeseries records from TimeSeriesResourcesList object into HydroSecurity Database */
        public void Update()
        {
        }

        /* This method deletes entire timeseries records from TimeSeriesResourcesList object into HydroSecurity Database */
        public void Delete()
        {
        }


        /* return back entire TimeSeriesResourcesList object for which is ResourceConsumer is Authorized*/
        public TimeSeriesResourcesList AuthorizedTimeSeriesList(List<Guid> authGuid)
        {
            TimeSeriesResourcesList AuthTimeSeries = new TimeSeriesResourcesList();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            foreach (Guid g in authGuid)
            {
                try
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = myConnection;
                    string queryString = "SELECT timeseriesresourceid as timeseriesresourceid, timeseriesmetadataid as timeseriesmetadataid, SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,citation as citation,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount, DateCreated as datecreated, DatabaseName as databasename, WaterOneFlowWSDL as wateroneflowwsdl FROM TimeSeriesResource where timeseriesresourcesid = '" + g + "';";
                    cmd.CommandText = queryString;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    foreach (DataRow row in dt.Rows)
                    {
                        TimeSeriesResource timeSeriesResources = new TimeSeriesResource();
                        Guid m = new Guid(row["timeseriesmetadataid"].ToString());
                        timeSeriesResources.dataGuid = g;
                        timeSeriesResources.metadataGuid = m;
                        timeSeriesResources.seriesId = Convert.ToInt16(row["seriesid"].ToString());
                        timeSeriesResources.siteId = Convert.ToInt16(row["siteid"].ToString());
                        timeSeriesResources.siteCode = row["sitecode"].ToString();
                        timeSeriesResources.siteName = row["sitename"].ToString();
                        timeSeriesResources.variableId = Convert.ToInt16(row["variableid"].ToString());
                        timeSeriesResources.variableCode = row["variablecode"].ToString();
                        timeSeriesResources.variableName = row["variablename"].ToString();
                        timeSeriesResources.speciation = row["speciation"].ToString();
                        timeSeriesResources.variableUnitsId = Convert.ToInt16(row["variableunitsid"].ToString());
                        timeSeriesResources.variableUnitsName = row["variableunitsname"].ToString();
                        timeSeriesResources.sampleMedium = row["samplemedium"].ToString();
                        timeSeriesResources.valueType = row["valuetype"].ToString();
                        timeSeriesResources.timeSupport = Convert.ToDouble(row["timesupport"].ToString());
                        timeSeriesResources.timeUnitsId = Convert.ToInt16(row["timeunitsid"].ToString());
                        timeSeriesResources.timeUnitsName = row["timeunitsname"].ToString();
                        timeSeriesResources.dataType = row["datatype"].ToString();
                        timeSeriesResources.generalCategory = row["generalcategory"].ToString();
                        timeSeriesResources.methodId = Convert.ToInt16(row["methodid"].ToString());
                        timeSeriesResources.methodDescription = row["methoddescription"].ToString();
                        timeSeriesResources.sourceId = Convert.ToInt16(row["sourceid"].ToString());
                        timeSeriesResources.organization = row["organization"].ToString();
                        timeSeriesResources.sourceDescription = row["sourcedescription"].ToString();
                        timeSeriesResources.citation = row["citation"].ToString();
                        timeSeriesResources.qualityControLlevelId = Convert.ToInt16(row["qualitycontrollevelid"].ToString());
                        timeSeriesResources.qualityControlLevelCode = row["qualitycontrollevelcode"].ToString();
                        timeSeriesResources.valueCount = Convert.ToInt32(row["valuecount"].ToString());
                        timeSeriesResources.dateCreated = Convert.ToDateTime(row["datecreated"].ToString());
                        timeSeriesResources.databaseName = row["databasename"].ToString();
                        timeSeriesResources.waterOneflowWSDL = row["wateroneflowwsdl"].ToString();



                        AuthTimeSeries.timeResourcesLocal.Add(timeSeriesResources);
                    }
                    myConnection.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine("this is not successful :" + e.Message.ToString());
                }

                
            }
            return AuthTimeSeries;
        }

        private string FormulateQuery(TimeSeriesResource timeRes)
        {
            string query = "variablecode ='" + timeRes.variableCode + "' and sitecode = '" + timeRes.siteCode + "'";
            if (timeRes.methodId != null)
            {
                query = query + "and methodid=" + timeRes.methodId + "";
            }
            if (timeRes.qualityControLlevelId != null)
            {
                query = query + "and qualitycontrollevelid=" + timeRes.qualityControLlevelId + "";
            }
            if (timeRes.sourceId != null)
            {
                query = query + "and sourceid=" + timeRes.sourceId + "";
            }

            return query;
        }
    }
}
