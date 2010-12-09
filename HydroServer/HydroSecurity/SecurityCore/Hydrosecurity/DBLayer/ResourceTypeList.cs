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
    public class ResourceTypeList
    {
        public List<ResourceType> resourceTypeCatalog = new List<ResourceType>();

        public ResourceTypeList GetResourceType()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select resourcetypeid as resourcetypeid,name as name,description as description from resourcetype;";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    ResourceType resType = new ResourceType();
                    resType.resourceTypeId = Convert.ToInt16(row["resourcetypeid"].ToString());
                    resType.resourceType = row["name"].ToString();
                    resType.resourceDescription = row["description"].ToString();
                    this.resourceTypeCatalog.Add(resType);
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
            }
            return this;
        }
    }
}
