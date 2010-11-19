using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBLayer
{
    public class TimeSeriesResources
    {
        public Guid timeSeriesResourceId ;
        public string variableCode;
        public string siteCode;
        public int? methodId =null ;
        public int? sourceId = null ;
        public int? qualityControlId = null ;
        

        
        
        
        
        

        /* This method loads a single record into TimeSeriesResources object from HydroSecurity Database when its VariableCode is set*/
        public void Load()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select  VariableCode as variablecode, SiteCode as sitecode, MethodID as methodid, SourceID as sourceid, QualityControlLevelID as qualitycontrolid from SeriesCatalog where variablecode ='"+this.variableCode+"';";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    this.variableCode = row["variablecode"].ToString();
                    this.siteCode = row["sitecode"].ToString();
                    this.methodId = Convert.ToInt16(row["methodid"].ToString());
                    this.sourceId = Convert.ToInt16(row["sourceid"].ToString());
                    this.qualityControlId = Convert.ToInt16(row["qualitycontrolid"].ToString());
                    
                }
                myConnection.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

         
        }

        /* This method saves a single record from TimeSeriesResources object into HydroSecurity Database*/
        public void Save()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                Guid timeSeriesResourceId = System.Guid.NewGuid();
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "insert into timeseriesresources values('" + this.timeSeriesResourceId + "','" + this.variableCode + "','" + this.siteCode + "'," + this.methodId + "," + this.sourceId + "," + this.qualityControlId + ")";
                cmd.CommandText = queryString;
                cmd.ExecuteNonQuery();
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }

        /* This method updates a single record from TimeSeriesResources object into HydroSecurity Database */
        public void Update()
        {
        }

        /* This method deletes a single record from  HydroSecurity Database */
        public void Delete()
        {
        }
    }
}
