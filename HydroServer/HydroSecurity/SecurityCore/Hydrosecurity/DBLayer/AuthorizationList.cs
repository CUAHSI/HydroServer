using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBLayer
{
    public class AuthorizationList
    {
        public List<Authorization> authList = new List<Authorization>();
        public void Load(List<Guid> resourceGuids)
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
                    string queryString = "select PersonResourcesId as personresourceid,ResourcesId as resourceid,PersonId as personid,PrivilegesGivenBy as authorizerid,PrivilegeId as privilegeid, DateCreated as datecreated, DateValidTill as datevalidtill from PersonResources where resourcesid='" + g + "';";
                    cmd.CommandText = queryString;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    foreach (DataRow row in dt.Rows)
                    {
                        Authorization auth = new Authorization();
                        Guid gd = new Guid(row["resourceid"].ToString());
                        auth.personResourceId = Convert.ToInt16(row["personresourceid"].ToString());
                        TimeSeriesResource tm = new TimeSeriesResource();
                        auth.timeResources = tm.GetTimeSeriesObject(gd);
                        ResourceConsumer resCon = new ResourceConsumer();
                        auth.person =   resCon.Load( Convert.ToInt16(row["personid"].ToString()));
                        auth.authorizer = resCon.Load( Convert.ToInt16(row["authorizerid"].ToString()));
                        auth.priviledgeId = Convert.ToInt16(row["privilegeid"].ToString());
                        auth.dateCreated = Convert.ToDateTime(row["datecreated"].ToString());
                        auth.dateValidTill = Convert.ToDateTime(row["datevalidtill"].ToString());
                        this.authList.Add(auth);

                        
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
