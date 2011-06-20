using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBLayer
{
    public class TimeSeriesResources
    {
        
        public List<string> GetODMList()
        {
            DataTable dt = new DataTable();
            List<string> odmList = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select distinct databasename from TimeSeriesResource;";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {

                    odmList.Add(row["databasename"].ToString());

                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

            return odmList;
            //return odmList;
        }

        public DataTable GetTimeSeriesResources(string odmName)
        {
            DataTable dt = new DataTable();
            List<string> odmList = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "SELECT timeseriesresourceid as timeseriesresourceid, timeseriesmetadataid as timeseriesmetadataid, SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,citation as citation,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount, DateCreated as datecreated, DatabaseName as databasename, WaterOneFlowWSDL as wateroneflowwsdl FROM TimeSeriesResource where databasename ='" + odmName + "'" + ";";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

            return dt;
        }

        public void DeleteTimeSeriesResources(string odmName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "delete from timeSeriesResource where databasename ='" + odmName + "'" + ";";
                cmd.CommandText = queryString;
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }

        public DataTable GetTimeSeriesInfo(string timeSeriesId)
        {
            DataTable dt = new DataTable();
            List<string> odmList = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "SELECT timeseriesresourceid as timeseriesresourceid, timeseriesmetadataid as timeseriesmetadataid, SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,citation as citation,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount, DateCreated as datecreated, DatabaseName as databasename, WaterOneFlowWSDL as wateroneflowwsdl FROM TimeSeriesResource where timeseriesresourceid ='" + timeSeriesId + "'" + ";";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

            return dt;
        }
    }
}
