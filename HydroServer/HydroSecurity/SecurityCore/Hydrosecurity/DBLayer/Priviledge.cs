using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Serialization;

namespace DBLayer
{
    [Serializable()]
    public class Priviledge
    {
        public int priviledgeId;
        public string priviledgeType;
        public string priviledgeDescription;

        public void Load(string pType)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select privilegeid as privilegeid,name as name,description as description from privilege where name = '" + pType + "';";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    this.priviledgeId = Convert.ToInt16(row["privilegeid"].ToString());
                    this.priviledgeType = row["name"].ToString();
                    this.priviledgeDescription = row["description"].ToString();

                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }

        public void Load(int privId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select privilegeid as privilegeid,name as name,description as description from privilege where privilegeid = " + privId + ";";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    this.priviledgeId = Convert.ToInt16(row["privilegeid"].ToString());
                    this.priviledgeType = row["name"].ToString();
                    this.priviledgeDescription = row["description"].ToString();

                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }
    }
}
