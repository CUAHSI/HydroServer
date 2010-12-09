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
        /*webmethod for checking is Services alive*/
        [WebMethod]
        public bool IsAlive()
        {
           
            return true;
        }
      
        /*webmethod for registering the user*/

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
        public bool Test(ResourceTypeList resTypeList)
        {
            return true;
            
            
        }

        [WebMethod]
        public string GetResourceType()
        {
            XmlDocument doc = new XmlDocument();
            HydroSecurityInternal hydroInternal = new HydroSecurityInternal();
            ResourceTypeList resTypeList = new ResourceTypeList();
            resTypeList = hydroInternal.GetResourceTypes();
            XmlSerializer ser = new XmlSerializer(resTypeList.GetType());
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(sb);
            ser.Serialize(writer, resTypeList);
            doc.LoadXml(sb.ToString());

            string xmlString = doc.InnerXml.ToString();

            ResourceTypeList resTypeList1 = new ResourceTypeList();
            XmlSerializer serializer = new XmlSerializer(resTypeList1.GetType());
            StringReader stringread = new StringReader(doc.InnerXml);
            XmlReader read1 = new XmlTextReader(stringread);
            resTypeList1 = (ResourceTypeList)serializer.Deserialize(read1);
            //TimeSeriesResourcesList test = new TimeSeriesResourcesList();
            //StringReader stringread = new StringReader(doc.InnerXml);
            //XmlReader read1 = new XmlTextReader(stringread);
            //test = (TimeSeriesResourcesList)ser.Deserialize(read1);


            return xmlString;
        }

        /*give back a xml document containing information of the resources*/
        [WebMethod]
        public XmlDocument GetResourceInfo(TimeSeriesResource tmObj)
        {
            XmlDocument doc = new XmlDocument();
            TimeSeriesResourcesList tm = new TimeSeriesResourcesList();
            HydroSecurityInternal hydroInternal = new HydroSecurityInternal();
            tm = hydroInternal.ResolveResources(tmObj);

            XmlSerializer ser = new XmlSerializer(tm.GetType());
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(sb);
            ser.Serialize(writer, tm);
            doc.LoadXml(sb.ToString());

            return doc;
          
        }

        /*give back a xml document containing information of the resources when passed a resource guid*/
        [WebMethod]
        public XmlDocument GetResourceInfoById(string resId)
        {
            XmlDocument doc = new XmlDocument();
            TimeSeriesResourcesList tm = new TimeSeriesResourcesList();
            HydroSecurityInternal hydroInternal = new HydroSecurityInternal();
            Guid g = new Guid(resId);
            tm = hydroInternal.GetResourceByGuid(g);

            XmlSerializer ser = new XmlSerializer(tm.GetType());
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(sb);
            ser.Serialize(writer, tm);
            doc.LoadXml(sb.ToString());

            //TimeSeriesResourcesList test = new TimeSeriesResourcesList();
            //StringReader stringread = new StringReader(doc.InnerXml);
            //XmlReader read1 = new XmlTextReader(stringread);
            //test = (TimeSeriesResourcesList)ser.Deserialize(read1);

            return doc;
        }

        [WebMethod]
        public XmlDocument GetResourceInfoByDate()
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            XmlDocument doc = new XmlDocument();
            ResourceCatalog resCat = new ResourceCatalog();
            HydroSecurityInternal hydroInternal = new HydroSecurityInternal();
            resCat = hydroInternal.GetByDate(startDate,endDate);
            XmlSerializer ser = new XmlSerializer(resCat.GetType());
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(sb);
            ser.Serialize(writer, resCat);
            doc.LoadXml(sb.ToString());

            return doc;
        }


        /*give back a xml document containing information of the users*/
        [WebMethod]
        public XmlDocument GetUserInfo(List<string> userEmailAddList)
        {
            XmlDocument doc = new XmlDocument();
            ResourceConsumerList rs = new ResourceConsumerList();
            HydroSecurityInternal hydroInternal = new HydroSecurityInternal();
            rs = hydroInternal.ResolveUserInfo(userEmailAddList);
            XmlSerializer ser = new XmlSerializer(rs.GetType());
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(sb);
            ser.Serialize(writer, rs);
            doc.LoadXml(sb.ToString());
            return doc;
        }

        /*sets priviledge on a resources for a user. generally used by admins*/
        [WebMethod]
        public void SetAccess(int userId, string resourceGuid, string accessLevel)
        {
            Guid g = new Guid(resourceGuid);
            HydroSecurityInternal hydroInternal = new HydroSecurityInternal();
            hydroInternal.SetAccess(userId, g, accessLevel);
        }

        /*used to queue a authorization request for particular resources by specifiying priviledge type.
         * This request will be only authorized further by admines*/
        [WebMethod]
        public void RequestAuthorization(string operationType, string resourceType, string siteCode)
        {
            ResourcesList rs = new ResourcesList();
            List<Guid> rsGuids = new List<Guid>();
            rsGuids = rs.load(siteCode);
            HydroSecurityInternal HydroInternal = new HydroSecurityInternal();
            HydroInternal.QueueAuthorizationRequest(operationType, 2, rsGuids);

        }

        [WebMethod]
        public XmlDocument GetAuthorizationInfo(string siteCode, bool statusApproved)
        {
            XmlDocument doc = new XmlDocument();
            if (statusApproved == false)
            {
                RequestManagementList rmList = new RequestManagementList();
                HydroSecurityInternal hydroInternal = new HydroSecurityInternal();
                rmList = hydroInternal.GetPendingAuthorizationInfo(siteCode);
                XmlSerializer ser = new XmlSerializer(rmList.GetType());
                System.Text.StringBuilder sb = new StringBuilder();
                System.IO.StringWriter writer = new StringWriter(sb);
                ser.Serialize(writer, rmList);
                doc.LoadXml(sb.ToString());
            }
            else
            {
                AuthorizationList authList = new AuthorizationList();
                HydroSecurityInternal hydroInternal = new HydroSecurityInternal();
                authList = hydroInternal.GetApprovedAuthorizationInfo(siteCode);
                XmlSerializer ser = new XmlSerializer(authList.GetType());
                System.Text.StringBuilder sb = new StringBuilder();
                System.IO.StringWriter writer = new StringWriter(sb);
                ser.Serialize(writer, authList);
                doc.LoadXml(sb.ToString());

            }
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
