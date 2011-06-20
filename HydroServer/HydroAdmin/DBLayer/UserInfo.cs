using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace DBLayer
{
    public class UserInfo
    {

        public List<string> GetUserList()
        {
            DataTable dt = new DataTable();
            List<string> userList = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select distinct resourceconsumername from ResourceConsumer;";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {

                    userList.Add(row["resourceconsumername"].ToString());

                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

            return userList;
        }

        public DataTable GetUserInfo(string userName)
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select rc.ResourceConsumerId as Id, rc.ResourceConsumerName as name,rc.ResourceConsumerEmailAdd as emailid, cn.SubjectOrganization as organization,cn.SubjectCountry as country  from ResourceConsumer as rc inner join ConsumerCertificate as cn on rc.ResourceConsumerCertificate=cn.CertificateId where rc.ResourceConsumerName ='" + userName + "'" + ";";
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

        public DataTable GetUserInfoList()
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select rc.ResourceConsumerId as Id, rc.ResourceConsumerName as name,rc.ResourceConsumerEmailAdd as emailid, cn.SubjectOrganization as organization,cn.SubjectCountry as country  from ResourceConsumer as rc inner join ConsumerCertificate as cn on rc.ResourceConsumerCertificate=cn.CertificateId;";
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
