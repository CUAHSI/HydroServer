using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DBLayer
{
    public class ResourceConsumer
    {
        public int resourceConsumerId;
        public int resourceConsumerCertificateId;
        public string resourceConsumerName;
        public string resourceConsumerEmail;

        public void Load()
        {
            
        }

        public bool UserExist(X509Certificate2 cer)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            resourceConsumerName = cer.Subject;
            string finalConsumer = resourceConsumerName.Replace("'", "");
            bool exist = true;
            try
            {
                
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select resourceconsumername  from resourceconsumer  where ResourceConsumerName = 'Ra\'vi';";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                if (dt.Rows.Count == 0)
                {
                    exist = false;
                }
                else
                {
                    exist = true;
                }

                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

            return exist;
        }


    }
}
