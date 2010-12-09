using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DBLayer
{
    public class ResourceCatalog
    {
        public List<TimeSeriesResource> timeSeriesCatalog = new List<TimeSeriesResource>();
        public List<Document> documentCatalog = new List<Document>();

        public DataTable GetEntireByDate()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select resourceid as resourceid , resourcetype as resourcetype from resources ;";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();
            }
            catch (Exception e)
            {
            }

            return dt;
        }

        public DataTable GetByStartDate(DateTime startDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select resourceid as resourceid , resourcetype as resourcetype from resources where datecreated >= ' " + startDate + "';";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();
            }
            catch (Exception e)
            {
            }

            return dt;

        }

        public DataTable GetByEndDate(DateTime endDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select resourceid as resourceid , resourcetype as resourcetype from resources  where datecreated <= ' " + endDate + "';";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();
            }
            catch (Exception e)
            {
            }

            return dt;

        }

        public DataTable GetBetweenDates(DateTime startDate, DateTime endDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select resourceid as resourceid , resourcetype as resourcetype from resources where datecreated >= ' " + startDate + "' and datecreated <= '" + endDate + "';";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();
            }
            catch (Exception e)
            {
            }

            return dt;
        }
    }
}
