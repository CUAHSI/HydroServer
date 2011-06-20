using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBLayer
{
    public class ODM
    {
        public string databaseNameIce;
        public string wsdlIce;

        public DataTable GetODMInfo(string ODMName)
        {
            DataTable dt = new DataTable();
            List<string> odmList = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["icewater"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select title,serveraddress,topiccategory,abstract,citation,wateroneflowwsdl from USUICEWATERNode.dbo.ODMDatabases where databasename ='" + ODMName + "'" + ";";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

            return dt;
        }

        public List<string> GetODMList()
        {
            DataTable dt = new DataTable();
            List<string> odmList = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["icewater"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select distinct databasename from USUICEWATERNode.dbo.ODMDatabases ;";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    odmList.Add(row["databasename"].ToString());
                }


                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

            return odmList;

        }

        public void LoadODM(string ODMName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["icewater"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            string connectionStringin = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnectionin = new SqlConnection(connectionStringin);
            string connectionStringIceWater = ConfigurationManager.ConnectionStrings["icewater"].ConnectionString;
            SqlConnection myConnectionIceWater = new SqlConnection(connectionStringIceWater);


            try
            {
                
                myConnectionIceWater.Open();
                SqlCommand cmdIceWater = new SqlCommand();
                cmdIceWater.Connection = myConnectionIceWater;

                string queryStringIce = "select distinct databasename,wateroneflowwsdl from USUICEWATERNode.dbo.ODMDatabases where databasename ='" + ODMName + "'" + ";";
                cmdIceWater.CommandText = queryStringIce;
                SqlDataReader readerIce = cmdIceWater.ExecuteReader();
                DataTable dtIce = new DataTable();
                dtIce.Load(readerIce);
                foreach(DataRow row in dtIce.Rows)
                {
                    databaseNameIce = row["databasename"].ToString();
                    wsdlIce = row["wateroneflowwsdl"].ToString();
                }

                myConnectionin.Open();
                SqlCommand cmdin = new SqlCommand();
                cmdin.Connection = myConnectionin;

                SqlCommand cmdRes = new SqlCommand();
                cmdRes.Connection = myConnectionin;

                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = " SELECT SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,Citation as citation,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount,BeginDateTime,EndDateTime,BeginDateTimeUTC,EndDateTimeUTC FROM "+ODMName+".dbo.SeriesCatalog ;";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    Guid d = new Guid();
                    d = System.Guid.NewGuid();
                    Guid m = new Guid();
                    m = System.Guid.NewGuid();
                    Guid dataGuid = d;
                    Guid metadataGuid = m;
                    int seriesid = Convert.ToInt16(row["seriesid"].ToString());
                    int siteid = Convert.ToInt16(row["siteid"].ToString());
                    string sitecode = row["sitecode"].ToString();
                    string sitename = row["sitename"].ToString();
                    int variableid = Convert.ToInt16(row["variableid"].ToString());
                    string variablecode = row["variablecode"].ToString();
                    string variablename = row["variablename"].ToString();
                    string speciation = row["speciation"].ToString();
                    int variableunitsid = Convert.ToInt16(row["variableunitsid"].ToString());
                    string variableunitsname = row["variableunitsname"].ToString();
                    string samplemedium = row["samplemedium"].ToString();
                    string valuetype = row["valuetype"].ToString();
                    double timesupport = Convert.ToDouble(row["timesupport"].ToString());
                    int timeunitsid = Convert.ToInt16(row["timeunitsid"].ToString());
                    string timeunitsname = row["timeunitsname"].ToString();
                    string datatype = row["datatype"].ToString();
                    string generalcategory = row["generalcategory"].ToString();
                    int methodid = Convert.ToInt16(row["methodid"].ToString());
                    string methoddescription = row["methoddescription"].ToString();
                    int sourceid = Convert.ToInt16(row["sourceid"].ToString());
                    string organization = row["organization"].ToString();
                    string sourcedescription = row["sourcedescription"].ToString();
                    string citation = row["citation"].ToString();
                    int qualitycontrollevelid = Convert.ToInt16(row["qualitycontrollevelid"].ToString());
                    string qualitycontrollevelcode = row["qualitycontrollevelcode"].ToString();
                    DateTime beginDateTime = Convert.ToDateTime(row["BeginDateTime"].ToString());
                    DateTime endDateTime = Convert.ToDateTime(row["EndDateTime"].ToString());
                    DateTime beginDateTimeUTC = Convert.ToDateTime(row["BeginDateTimeUTC"].ToString());
                    DateTime endDateTimeUTC = Convert.ToDateTime(row["EndDateTimeUTC"].ToString());
                    int valuecount = Convert.ToInt32(row["valuecount"].ToString());
                    DateTime datecreated = System.DateTime.Now;
                    string databasename = databaseNameIce;
                    string wateroneflowwsdl = wsdlIce;

                    try
                    {
                        string queryStringRes = "insert into resources values('" + dataGuid + "',1,'" + datecreated + "');";
                        cmdRes.CommandText = queryStringRes;
                        cmdRes.ExecuteNonQuery();

                        string queryStringin = "insert into timeseriesresource values('" + dataGuid + "','" + metadataGuid + "'," + seriesid + "," + siteid + ",'" + sitecode + "','" + sitename + " '," + variableid + ",'" + variablecode + " ','" + variablename + "','" + speciation + "'," + variableunitsid + ",'" + variableunitsname + "','" + samplemedium + "','" + valuetype + "'," + timesupport + "," + timeunitsid + ",'" + timeunitsname + "','" + datatype + "','" + generalcategory + "'," + methodid + ",'" + methoddescription + "'," + sourceid + ",'" + organization + "','" + sourcedescription + "','" + citation + "'," + qualitycontrollevelid + ",'" + qualitycontrollevelcode + "','" + beginDateTime + "','" + endDateTime + "','" + beginDateTimeUTC + "','" + endDateTime + "'," + valuecount + ",'" + datecreated + "','" + databasename + "','" + wateroneflowwsdl + "');";
                        cmdin.CommandText = queryStringin;
                        cmdin.ExecuteNonQuery();


                    }
                    catch (Exception em)
                    {
                    }




                }
                myConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("this is not successful :" + ex.Message.ToString());
            }
        }

        public DataTable GetUploadODMInfo(string ODMName)
        {
            DataTable dt = new DataTable();
            List<string> odmList = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["icewater"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = " SELECT SeriesID as seriesid,SiteID as siteid,SiteCode as sitecode, SiteName as sitename, VariableID as variableid, VariableCode as variablecode, VariableName as variablename, Speciation as speciation, VariableUnitsID as variableunitsid, VariableUnitsName as variableunitsname, SampleMedium as samplemedium, ValueType as valuetype, TimeSupport as timesupport, TimeUnitsID as timeunitsid, TimeUnitsName as timeunitsname, DataType as datatype, GeneralCategory as generalcategory, MethodID as methodid, MethodDescription as methoddescription, SourceID as sourceid, Organization as organization, SourceDescription as sourcedescription,Citation as citation,  QualityControlLevelID as qualitycontrollevelid, QualityControlLevelCode as qualitycontrollevelcode, ValueCount as valuecount,BeginDateTime,EndDateTime,BeginDateTimeUTC,EndDateTimeUTC FROM " + ODMName + ".dbo.SeriesCatalog ;";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

            return dt;
        }
    }
}
