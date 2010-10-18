using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBLayer
{
    public class PersonResouces
    {
        /* Returns back list of ResourcesGuid for which the person is Authorized with specified priviledge*/
        public List<Guid> PersonAuthorized(int resourceConsumerId,int priviledgeId)
        {
            List<Guid> authorizedResourcesGuidList = new List<Guid>();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select resourcesid as resourcesid from personresources where personid = " + resourceConsumerId + " and privilegeid = " + priviledgeId + ";";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    Guid g = new Guid(row["resourcesid"].ToString());
                    authorizedResourcesGuidList.Add(g);
                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
            return authorizedResourcesGuidList;

        }
    }
}
