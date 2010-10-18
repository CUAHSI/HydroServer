using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DBLayer
{
    public class Certificate
    {
        public string serialNo;
        public string version;
        public string subjectName;
        public string subjectOrganization;
        public string subjectEmail;
        public string subjectCountry;
        public string issuerName;
        public DateTime validFrom;
        public DateTime ValidTill;

        public void CertificateSave()
        {
            SqlConnection myConnection = new SqlConnection("user id=SHARK/ketan;" +"password=mohinder;server=localhost;" +"Trusted_Connection=yes;" +"database=HydroSecure; " +"connection timeout=30");
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                //string queryString = "insert into consumerCertificate(SerialNo,verson,subjectname,subjectorganization,subjectemailadd,subjectcountry,issuername,validfrom,validtill) values("+ cer.serialNo + ",'" + cer.subjectName + "','" + cer.subjectOrganization + "','" + cer.subjectEmail + "','" + cer.subjectCountry + "','" + cer.issuerName + "'," + cer.validFrom + "," + cer.ValidTill + ")";
                //string queryString = "insert into consumerCertificate values('"+this.serialNo+",'"+"test','"+this.subjectName+"','uwrl','dafd@gmail.com','usa','microsoft',10-10-10,10-10-10)";
                string queryString = "insert into consumercertificate values('"+this.serialNo+"','"+this.version+"','" + this.subjectName + "','" + this.subjectOrganization + "','" + this.subjectEmail + "','" + this.subjectCountry + "','" + this.issuerName + "','" + this.validFrom + "','" + this.ValidTill + "'"+")";
                cmd.CommandText = queryString;
                cmd.ExecuteNonQuery();
                myConnection.Close();

                
                
            }
            catch ( Exception e )
            {
                Console.WriteLine("this is not successful :"+e.Message.ToString());
            }
           
        }
    }
}
