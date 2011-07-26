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

        public DataTable GetUserGroupParticipation(int userGroupId)
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select rc.ResourceConsumerId as Id, rc.ResourceConsumerName as name, rc.ResourceConsumerEmailAdd as email,cc.SubjectCountry as country, cc.SubjectOrganization as organization from ResourceConsumer rc inner join ConsumerCertificate cc on rc.ResourceConsumerCertificate = cc.CertificateId where rc.ResourceConsumerId in (select ugrc.ResourceConsumerId from UserGroupResourceConsumer ugrc where ugrc.UserGroupId = "+userGroupId+") ;";
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

        public DataTable GetUserGroupNotParticipation(int userGroupId)
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select rc.ResourceConsumerId as Id, rc.ResourceConsumerName as name, rc.ResourceConsumerEmailAdd as email,cc.SubjectCountry as country, cc.SubjectOrganization as organization from ResourceConsumer rc inner join ConsumerCertificate cc on rc.ResourceConsumerCertificate = cc.CertificateId where rc.ResourceConsumerId not in (select ugrc.ResourceConsumerId from UserGroupResourceConsumer ugrc where ugrc.UserGroupId = " + userGroupId + ") ;";
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

        public void ReleaseUserRows(int groupId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "delete from UserGroupResourceConsumer where UserGroupId =" + groupId + ";";
                cmd.CommandText = queryString;
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }

        public void GroupUserAdd(int userId, int userGroupId)
        {
            string connectionStringin = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnectionin = new SqlConnection(connectionStringin);
            myConnectionin.Open();
            SqlCommand cmdin = new SqlCommand();
            cmdin.Connection = myConnectionin;
            try
            {
                string queryStringin = "insert into usergroupresourceconsumer values('" + userGroupId + "'," + userId + ",1,'12-12-2011');";
                cmdin.CommandText = queryStringin;
                cmdin.ExecuteNonQuery();


            }
            catch (Exception em)
            {
            }
            myConnectionin.Close();
        }
    }
}
