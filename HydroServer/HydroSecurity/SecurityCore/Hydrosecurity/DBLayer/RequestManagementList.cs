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
    public class RequestManagementList
    {
        public List<RequestManagement> resourceManagementLocal = new List<RequestManagement>();

        public void Load(List<Guid> resourceGuids,bool status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            List<Guid> returnResourceList = new List<Guid>();
            foreach (Guid g in resourceGuids)
            {
                try
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = myConnection;
                    string queryString = "select ResourceId as resourceid,RequesterId as requesterid,DateRequested as daterequested,Priviledge as priviledgetype,IsGranted as status from DataRequest where resourceid='"+g+"' and isgranted =0;";
                    cmd.CommandText = queryString;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    foreach (DataRow row in dt.Rows)
                    {
                        RequestManagement rm = new RequestManagement();
                        Guid gd = new Guid(row["resourceid"].ToString());
                        rm.resourceId = gd;
                        rm.requesterId = Convert.ToInt16(row["requesterid"].ToString());
                        rm.dateRequested = Convert.ToDateTime(row["daterequested"].ToString());
                        if (!Convert.ToBoolean( row["status"].ToString()))
                        {
                            rm.status = false;
                        }
                        else
                        {
                            rm.status = true;
                        }

                        this.resourceManagementLocal.Add(rm);
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
}
