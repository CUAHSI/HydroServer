using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBLayer
{
    public class Privilege
    {
        private int privilegeId;

        public int GetPrivilegeId(string privilegeName)
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
                string queryString = "select privilegeid as privilegeid from Privilege where Name='" + privilegeName + "'" + ";";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    privilegeId = Convert.ToInt16(row["privilegeid"].ToString());
                }

                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

            return privilegeId;
        }
    }
}
