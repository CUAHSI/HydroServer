using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBLayer
{
    public class RequestManagement 
    {
        public Guid resourceId;
        public int requesterId;
        public DateTime  dateRequested;
        public string privilegeType;
        public bool status;


        public void AddRequest(int pType,int userId,List<Guid> resourceGuids)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            foreach (Guid g in resourceGuids)
            {
                try
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = myConnection;
                    string queryString = "insert into datarequest values('" + g + "',2,'10-10-10',"+pType+",0,0)";
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
}
