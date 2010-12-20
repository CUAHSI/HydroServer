using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBLayer
{
    [Serializable]
    public class ResourceConsumerList
    {
        public List<ResourceConsumer> resourceConsumerLocal = new List<ResourceConsumer>();

        public void Load(List<string> userEmailAddList)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            foreach (string userEmailAdd in userEmailAddList)
            {
                try
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = myConnection;
                    string queryString = "select ResourceConsumerId as resourceconsumerid,ResourceConsumerName as resourceconsumername,ResourceConsumerEmailAdd as resourceconsumeremailadd from ResourceConsumer where resourceconsumeremailadd = '"+userEmailAdd+"';";
                    cmd.CommandText = queryString;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    foreach (DataRow row in dt.Rows)
                    {
                        ResourceConsumer resourceConsumer = new ResourceConsumer();

                        resourceConsumer.resourceConsumerId = Convert.ToInt16(row["resourceconsumerid"].ToString());
                        resourceConsumer.resourceConsumerName = row["resourceconsumername"].ToString();
                        resourceConsumer.resourceConsumerEmail = row["resourceconsumeremailadd"].ToString();
                        this.resourceConsumerLocal.Add(resourceConsumer);
                    }
                    myConnection.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine("this is not successful :" + e.Message.ToString());
                }
            }
        }


        public List<string> GetUserList()
        {
            List<string> userEmailList = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
           
                try
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = myConnection;
                    string queryString = "select ResourceConsumerEmailAdd as resourceconsumeremailadd from ResourceConsumer ";
                    cmd.CommandText = queryString;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    foreach (DataRow row in dt.Rows)
                    {
                        userEmailList.Add(row["resourceconsumeremailadd"].ToString());
                    }
                    myConnection.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine("this is not successful :" + e.Message.ToString());
                }
            
            return userEmailList;
        }

    }
}
