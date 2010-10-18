using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using DBLayer;
using System.IdentityModel.Tokens;
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
        public bool CreateUser()
        {
            try
            {
                X509Certificate cer = new X509Certificate(Context.Request.ClientCertificate.Certificate);
                string sub = cer.Subject;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            string machine =       Context.Server.MachineName;
            X509Certificate2 cer2 = GetCertificate();
            bool flag = IsValidate(cer2);
            return true;
        }

        private static X509Certificate2 GetCertificate()
        {
            X509Certificate cert = X509Certificate.CreateFromCertFile(@"C:\Documents and Settings\Ketan\Desktop\test3.cer");
            return new X509Certificate2(cert);
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
