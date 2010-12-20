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
    public class ResourcesList 
    {
        public List<Resources> resourcesLocal = new List<Resources>();

        public void Load()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select timeseriesresourceid as resourceid from timeseriesresource";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {

                    Resources rs = new Resources();
                    Guid g = new Guid(row["resourceid"].ToString());
                    rs.resourceId = g;
                    rs.resourceTypeId = 1;
                    this.resourcesLocal.Add(rs);

                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }

        /* Return Back list of ResourceGuids which mataches the appropriate sitecode. This is performs resource resolving. 
         * This methods needed to be re written or needs one more overloaded method which will also take in consideration VariableCode
         */
        public List<Guid> load(string siteCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            List<Guid> returnResourceList = new List<Guid>();
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select timeseriesresourceid as resourceid from timeseriesresource where sitecode='" + siteCode + "'";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {


                    Guid g = new Guid(row["resourceid"].ToString());
                    returnResourceList.Add(g);

                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

            return returnResourceList;
        }

        public void Save()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            foreach (Resources rs in this.resourcesLocal)
            {
                try
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = myConnection;
                    string queryString = "insert into resources values('" + rs.resourceId + "'," + rs.resourceTypeId + ")";
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
