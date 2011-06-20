using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBLayer
{
    public class DataRequest
    {

        public DataTable GetAllDataRequest()
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
                string queryString = "select dr.ResourceId as ResourceId,rc.ResourceConsumerName as RequesterName,rc.ResourceConsumerId as resourceconsumerid, dr.DateRequested as DateRequested , pv.Name as Privilege , pv.PrivilegeId as privilegeid,dr.DataRequestId as datarequestid from Privilege pv inner join (  DataRequest as dr inner join ResourceConsumer as rc on dr.RequesterId = rc.ResourceConsumerId ) on pv.PrivilegeId = dr.Priviledge;";
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

        public void ReleaseDataRequestRow(int rowId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "delete from DataRequest where DataRequestId = " + rowId + ";";
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
}
