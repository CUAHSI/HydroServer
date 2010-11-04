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
        public List<TimeSeriesResources> timeResourcesLocal = new List<TimeSeriesResources>();

        /* This method loads entire timeseries records into TimeSeriesResourcesList object from HydroSecurity Database */
        public void Load()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select TimeSeriesResourcesId as guid,VariableCode as variablecode,SiteCode as sitecode,MethodId as methodid,SourceId as sourceid,QualityControlLevelId as qualitycontrolid from TimeSeriesResources;";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    TimeSeriesResources timeSeriesResources = new TimeSeriesResources();
                    Guid g = new Guid(row["guid"].ToString());
                    timeSeriesResources.timeSeriesResourceId = g;
                    timeSeriesResources.variableCode = row["variablecode"].ToString();
                    timeSeriesResources.siteCode = row["sitecode"].ToString();
                    timeSeriesResources.methodId = Convert.ToInt16(row["methodid"].ToString());
                    timeSeriesResources.sourceId = Convert.ToInt16(row["sourceid"].ToString());
                    timeSeriesResources.qualityControlId = Convert.ToInt16(row["qualitycontrolid"].ToString());
                    this.timeResourcesLocal.Add(timeSeriesResources);
                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

        }

        public void load(string variableCode, string siteCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select TimeSeriesResourcesId as guid,VariableCode as variablecode,SiteCode as sitecode,MethodId as methodid,SourceId as sourceid,QualityControlLevelId as qualitycontrolid from TimeSeriesResources";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    TimeSeriesResources timeSeriesResources = new TimeSeriesResources();
                    Guid g = new Guid(row["guid"].ToString());
                    timeSeriesResources.timeSeriesResourceId = g;
                    timeSeriesResources.variableCode = row["variablecode"].ToString();
                    timeSeriesResources.siteCode = row["sitecode"].ToString();
                    timeSeriesResources.methodId = Convert.ToInt16(row["methodid"].ToString());
                    timeSeriesResources.sourceId = Convert.ToInt16(row["sourceid"].ToString());
                    timeSeriesResources.qualityControlId = Convert.ToInt16(row["qualitycontrolid"].ToString());
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
        public void save()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            foreach(TimeSeriesResources tr in this.timeResourcesLocal)
            {
            try
            {
                Guid timeSeriesResourceId = System.Guid.NewGuid();
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "insert into timeseriesresources values('"+ timeSeriesResourceId +"','" + tr.variableCode + "','" + tr.siteCode + "'," + tr.methodId+ "," + tr.sourceId+ "," + tr.qualityControlId+ ")";
                cmd.CommandText = queryString;
                cmd.ExecuteNonQuery();
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
            }
        }

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
                    string queryString = "select VariableCode as variablecode, SiteCode as sitecode, MethodID as methodid, SourceID as sourceid, QualityControlLevelID as qualitycontrolid from timeseriesresources where timeseriesresourcesid = '"+g+"';";
                    cmd.CommandText = queryString;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    foreach (DataRow row in dt.Rows)
                    {
                        TimeSeriesResources timeSeriesResources = new TimeSeriesResources();
                        timeSeriesResources.timeSeriesResourceId = g;
                        timeSeriesResources.variableCode = row["variablecode"].ToString();
                        timeSeriesResources.siteCode = row["sitecode"].ToString();
                        timeSeriesResources.methodId = Convert.ToInt16(row["methodid"].ToString());
                        timeSeriesResources.sourceId = Convert.ToInt16(row["sourceid"].ToString());
                        timeSeriesResources.qualityControlId = Convert.ToInt16(row["qualitycontrolid"].ToString());
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
    }
}
