using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBLayer
{
    public class Document
    {
        public Guid documentId;
        public string documentName;
        public string documentTitle;
        public String documentLocation;
        public DateTime dateCreated;

        public Document GetDocumentById(Guid g)
        {
            Document doc = new Document();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select documentid as documentid,name as name,title as title,location as location,datecreated as datecreated from document where documentid = '"+g+"';";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    Guid id = new Guid(row["documentid"].ToString());
                    doc.documentId = id;
                    doc.documentName = row["name"].ToString();
                    doc.documentTitle = row["title"].ToString();
                    doc.documentLocation = row["location"].ToString();
                    doc.dateCreated = Convert.ToDateTime(row["datecreated"].ToString());
                    
                }
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }

            return doc;
        }

    }
}
