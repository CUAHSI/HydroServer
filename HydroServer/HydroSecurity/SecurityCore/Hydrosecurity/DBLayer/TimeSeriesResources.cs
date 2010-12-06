using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBLayer
{
    public class TimeSeriesResource
    {
        public Guid dataGuid;
        public Guid metadataGuid;
        public int seriesId;
        public int siteId;
        public string siteCode;
        public string siteName;
        public int variableId;
        public string variableCode;
        public string variableName;
        public string speciation;
        public int variableUnitsId;
        public string variableUnitsName;
        public string sampleMedium;
        public string valueType;
        public double timeSupport;
        public int timeUnitsId;
        public string timeUnitsName;
        public string dataType;
        public string generalCategory;
        public int? methodId = null;
        public string methodDescription;
        public int? sourceId = null;
        public string organization;
        public string sourceDescription;
        public string citation;
        public int? qualityControLlevelId = null;
        public string qualityControlLevelCode;
        public int valueCount;
        public DateTime dateCreated;
        public string databaseName;
        public string waterOneflowWSDL;


        public TimeSeriesResource GetTimeSeriesObject(Guid timeSeriesGuid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "SELECT timeseriesresourceid as timeseriesresourceid, timeseriesmetadataid as timeseriesmetadataid, SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount, DateCreated as datecreated, DatabaseName as databasename, WaterOneFlowWSDL as wateroneflowwsdl FROM TimeSeriesResource where timeseriesresourceid = '" + timeSeriesGuid + "';";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    Guid d = new Guid(row["timeseriesresourceid"].ToString());
                    Guid m = new Guid(row["timeseriesmetadataid"].ToString());
                    dataGuid = d;
                    metadataGuid = m;
                    seriesId = Convert.ToInt16(row["seriesid"].ToString());
                    siteId = Convert.ToInt16(row["siteid"].ToString());
                    siteCode = row["sitecode"].ToString();
                    siteName = row["sitename"].ToString();
                    variableId = Convert.ToInt16(row["variableid"].ToString());
                    variableCode = row["variablecode"].ToString();
                    variableName = row["variablename"].ToString();
                    speciation = row["speciation"].ToString();
                    variableUnitsId = Convert.ToInt16(row["variableunitsid"].ToString());
                    variableUnitsName = row["variableunitsname"].ToString();
                    sampleMedium = row["samplemedium"].ToString();
                    valueType = row["valuetype"].ToString();
                    timeSupport = Convert.ToDouble(row["timesupport"].ToString());
                    timeUnitsId = Convert.ToInt16(row["timeunitsid"].ToString());
                    timeUnitsName = row["timeunitsname"].ToString();
                    dataType = row["datatype"].ToString();
                    generalCategory = row["generalcategory"].ToString();
                    methodId = Convert.ToInt16(row["methodid"].ToString());
                    methodDescription = row["methoddescription"].ToString();
                    sourceId = Convert.ToInt16(row["sourceid"].ToString());
                    organization = row["organization"].ToString();
                    sourceDescription = row["sourcedescription"].ToString();
                    citation = row["citation"].ToString();
                    qualityControLlevelId = Convert.ToInt16(row["qualitycontrollevelid"].ToString());
                    qualityControlLevelCode = row["qualitycontrollevelcode"].ToString();
                    valueCount = Convert.ToInt32(row["valuecount"].ToString());
                    dateCreated = Convert.ToDateTime(row["datecreated"].ToString());
                    databaseName = row["databasename"].ToString();
                    waterOneflowWSDL = row["wateroneflowwsdl"].ToString();

                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

            return this;

        }
        
        
        
        
        

        /* This method loads a single record into TimeSeriesResources object from HydroSecurity Database when its VariableCode is set*/
        public void Load()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "SELECT timeseriesresourceid as timeseriesresourceid, timeseriesmetadataid as timeseriesmetadataid, SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount, DateCreated as datecreated, DatabaseName as databasename, WaterOneFlowWSDL as wateroneflowwsdl FROM TimeSeriesResource where timeseriesresourceid = '" + this.dataGuid + "';";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    Guid d = new Guid(row["timeseriesresourceid"].ToString());
                    Guid m = new Guid(row["timeseriesmetadataid"].ToString());
                    this.dataGuid = d;
                    this.metadataGuid = m;
                    this.seriesId = Convert.ToInt16(row["seriesid"].ToString());
                    this.siteId = Convert.ToInt16(row["siteid"].ToString());
                    this.siteCode = row["sitecode"].ToString();
                    this.siteName = row["sitename"].ToString();
                    this.variableId = Convert.ToInt16(row["variableid"].ToString());
                    this.variableCode = row["variablecode"].ToString();
                    this.variableName = row["variablename"].ToString();
                    this.speciation = row["speciation"].ToString();
                    this.variableUnitsId = Convert.ToInt16(row["variableunitsid"].ToString());
                    this.variableUnitsName = row["variableunitsname"].ToString();
                    this.sampleMedium = row["samplemedium"].ToString();
                    this.valueType = row["valuetype"].ToString();
                    this.timeSupport = Convert.ToDouble(row["timesupport"].ToString());
                    this.timeUnitsId = Convert.ToInt16(row["timeunitsid"].ToString());
                    this.timeUnitsName = row["timeunitsname"].ToString();
                    this.dataType = row["datatype"].ToString();
                    this.generalCategory = row["generalcategory"].ToString();
                    this.methodId = Convert.ToInt16(row["methodid"].ToString());
                    this.methodDescription = row["methoddescription"].ToString();
                    this.sourceId = Convert.ToInt16(row["sourceid"].ToString());
                    this.organization = row["organization"].ToString();
                    this.sourceDescription = row["sourcedescription"].ToString();
                    this.citation = row["citation"].ToString();
                    this.qualityControLlevelId = Convert.ToInt16(row["qualitycontrollevelid"].ToString());
                    this.qualityControlLevelCode = row["qualitycontrollevelcode"].ToString();
                    this.valueCount = Convert.ToInt32(row["valuecount"].ToString());
                    this.dateCreated = Convert.ToDateTime(row["datecreated"].ToString());
                    this.databaseName = row["databasename"].ToString();
                    this.waterOneflowWSDL = row["wateroneflowwsdl"].ToString();

                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

         
        }

        /* This method saves a single record from TimeSeriesResources object into HydroSecurity Database*/
        //public void Save()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
        //    SqlConnection myConnection = new SqlConnection(connectionString);
        //    try
        //    {
        //        Guid timeSeriesResourceId = System.Guid.NewGuid();
        //        myConnection.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = myConnection;
        //        string queryString = "insert into timeseriesresources values('" + this.timeSeriesResourceId + "','" + this.variableCode + "','" + this.siteCode + "'," + this.methodId + "," + this.sourceId + "," + this.qualityControlId + ")";
        //        cmd.CommandText = queryString;
        //        cmd.ExecuteNonQuery();
        //        myConnection.Close();

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("this is not successful :" + e.Message.ToString());
        //    }
        //}

        /* This method updates a single record from TimeSeriesResources object into HydroSecurity Database */
        public void Update()
        {
        }

        /* This method deletes a single record from  HydroSecurity Database */
        public void Delete()
        {
        }
    }
}
