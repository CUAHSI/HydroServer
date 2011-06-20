using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBLayer
{
    public class AccessControl
    {

        public void SetUserAccess(string resourceId, int userId, int PrivilegeId)
        {
            string connectionStringin = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnectionin = new SqlConnection(connectionStringin);
            myConnectionin.Open();
            SqlCommand cmdin = new SqlCommand();
            cmdin.Connection = myConnectionin;
            try
            {
                string queryStringin = "insert into PersonResources values('"+resourceId+"',"+userId+",1,"+PrivilegeId+",'12-12-2011','12-12-2020');";
                cmdin.CommandText = queryStringin;
                cmdin.ExecuteNonQuery();


            }
            catch (Exception em)
            {
            }
            myConnectionin.Close();

        }

        public void ReleaseUserRows(int userId,string dbName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "delete ps from personresources as ps inner join timeseriesresource as tm on ps.resourcesid=tm.timeseriesresourceid  where  ps.personid =" + userId + "and tm.databasename='" + dbName + "';";
                cmd.CommandText = queryString;
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }

        public DataTable AccessData(int userId)
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
                string queryString = "select resourcesid,personid,privilegeid from PersonResources where PersonId =" + userId +";";
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
