using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBLayer
{
    public class UserGroup
    {
        public DataTable GetUserGroupInfoList()
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select ug.usergroupid,ug.name,ug.datecreated,ur.ResourceConsumerName as Owner from UserGroup as ug inner join ResourceConsumer as ur on ug.OwnerId=ur.ResourceConsumerId;";
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

        public DataTable GetUserGroupList(int userId)
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select ug.UserGroupId, ug.name,ug.datecreated,ugo.ResourceConsumerName as GroupOwner from UserGroup ug inner join ResourceConsumer ugo on ugo.ResourceConsumerId=ug.OwnerId where ug.UserGroupId in(  select ugb.UserGroupId from UserGroupResourceConsumer ugb where ugb.ResourceConsumerId ="+userId+");";
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

        public DataTable GetUserGroupNotSelectedList(int userId)
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select ug.UserGroupId, ug.name,ug.datecreated,ugo.ResourceConsumerName as GroupOwner from UserGroup ug inner join ResourceConsumer ugo on ugo.ResourceConsumerId=ug.OwnerId where ug.UserGroupId not in(  select ugb.UserGroupId from UserGroupResourceConsumer ugb where ugb.ResourceConsumerId =" + userId + ");";
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

        public void UserGroupAdd(int userId,int userGroupId)
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

        public void ReleaseGroupRows(int userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "delete from UserGroupResourceConsumer where ResourceConsumerId =" + userId + ";";
                cmd.CommandText = queryString;
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }

        public List<string> GetAllGroupsList()
        {
            List<string> allGroups = new List<string>();
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select name from UserGroup;";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach(DataRow row in dt.Rows)
                {
                    allGroups.Add(row["name"].ToString());
                }
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
            return allGroups;

        }

        public DataTable GetGroupInfo(string groupName)
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select ug.UserGroupId as id, ug.name as name,rc.ResourceConsumerName as owner,DateCreated as datecreated from UserGroup ug inner join ResourceConsumer rc on ug.OwnerId=rc.ResourceConsumerId  where Name='" + groupName + "';";
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

        public void AddGroup(string GroupName, int ownerId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "insert into UserGroup values('"+GroupName+"','"+System.DateTime.UtcNow.ToString()+"',"+ownerId+");";
                cmd.CommandText = queryString;
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }

        public void DeleteGroup(int GroupId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlConnection myConnectionGroup = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                myConnectionGroup.Open();
                SqlCommand cmd = new SqlCommand();
                SqlCommand cmdGroup = new SqlCommand();
                cmd.Connection = myConnection;
                cmdGroup.Connection = myConnectionGroup;
                string queryString = "delete from UserGroupResourceConsumer where UserGroupId = " + GroupId + ";";
                string queryStringGroup = "delete from UserGroup where UserGroupId= " + GroupId + ";";
                cmd.CommandText = queryString;
                cmdGroup.CommandText = queryStringGroup;
                cmd.ExecuteNonQuery();
                cmdGroup.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }
     }

}

