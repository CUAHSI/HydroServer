using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using DBLayer;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Web.Services.Protocols;
//using System.IdentityModel.Tokens;
namespace Hydrosecurity
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
      

        [WebMethod]
        public string RegisterUser()
        {
            X509Certificate2 cer = GetCertificate();
            ResourceConsumer resCon = new ResourceConsumer();
            bool exist;
            exist = resCon.UserExist(cer);
            return "fun";
        }

        [WebMethod]
        public XmlDocument GetResourceInfo()
        {
            XmlDocument doc = new XmlDocument();
            //Priviledge pr = new Priviledge();
            //pr.Load("read");
            TimeSeriesResourcesList tm = new TimeSeriesResourcesList();
            tm.Load();

            XmlSerializer ser = new XmlSerializer(tm.GetType());
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(sb);
            ser.Serialize(writer, tm);
            doc.LoadXml(sb.ToString());

            return doc;
          
        }

        private static X509Certificate2 GetCertificate()
        {
            X509Certificate2 cert = new X509Certificate2();
            X509Store store = new X509Store("testCertStore" , StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certCol = (X509Certificate2Collection)store.Certificates;
            foreach (X509Certificate2 x509 in certCol)
            {
                if (x509.SerialNumber == "23D91CD7E7114ABE4EEA208FB4868138")
                {
                    cert = x509;
                }
            }
            return cert;
        }

        public bool IsValidate(X509Certificate2 certificate)
        {
            bool flag = false;
            X509ChainPolicy myChainPolicy = new X509ChainPolicy();
            myChainPolicy.RevocationMode = X509RevocationMode.Online;
            myChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
            // set additional properties if required as per the scenario need. 
            X509Chain chain = new X509Chain();
            chain.ChainPolicy = myChainPolicy;

            if (chain.Build(certificate))
            {
                flag = true;
            }

            return flag;

        }
    }
}
