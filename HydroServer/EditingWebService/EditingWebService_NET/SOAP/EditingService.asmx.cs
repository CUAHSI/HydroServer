using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace SoapService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://his.cuahsi.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class EditingService : System.Web.Services.WebService
    {
        [WebMethod]
        public TokenInfo GetToken(string UserName, string Password)
        {
            if (UserName == "jirka" && Password == "kadlec")
            {
                Guid token = new Guid();
                TokenInfo resp = new TokenInfo();
                resp.Expires = DateTime.Now.AddHours(1.0);
                resp.UserName = UserName;
                resp.UserRole = "admin";
                resp.Status = "OK";
                return new TokenInfo();
            }
            else
            {
                TokenInfo resp = new TokenInfo();
                resp.Status = "Error - Bad User name or Password";
                throw new UnauthorizedAccessException("Bad User name or password");
            }
        }
        
        
        [WebMethod]
        public string CreateSite(string authToken, Site site)
        {
            return "Site Created";
        }
        [WebMethod]
        public string CreateSites(string authToken, Site[] sites)
        {
            return "Sites Created";
        }

        [WebMethod]
        public string UpdateSite(string authToken, Site site)
        {
            return site.Code;
        }

        [WebMethod]
        public string DeleteSite(string authToken, Site site)
        {
            return "Site Deleted";
        }

        [WebMethod]
        public string CreateVariable(string authToken, Site site)
        {
            return "Site Created";
        }

        [WebMethod]
        public string UpdateVariable(string authToken, Site site)
        {
            return site.Code;
        }

        [WebMethod]
        public string DeleteVariable(string authToken, Site site)
        {
            return "Site Deleted";
        }

        [WebMethod]
        public Method[] GetMethods(string authToken)
        {
            return new Method[]{ new Method() };
        }

        [WebMethod]
        public string CreateMethod(string authToken, Method method)
        {
            return "Site Created";
        }

        [WebMethod]
        public string UpdateMethod(string authToken, Method method)
        {
            return "Method Updated";
        }

        [WebMethod]
        public string DeleteMethod(string authToken, long methodID)
        {
            return "method Deleted";
        }

        [WebMethod]
        public string CreateSource(string authToken, Source source)
        {
            return "source Created";
        }

        [WebMethod]
        public long UpdateSource(string authToken, Source source)
        {
            return source.Id;
        }

        [WebMethod]
        public string DeleteSource(string authToken, long sourceID)
        {
            return "source Deleted";
        }

        [WebMethod]
        public string CreateValue(string authToken, string siteCode, string variableCode, DataValue dataValue)
        {
            return "Value Created";
        }

        [WebMethod]
        public string CreateValues(string authToken, string siteCode, string variableCode, DataValue[] dataValues)
        {
            return "Values Created";
        }

        [WebMethod]
        public string UpdateValue(string authToken, string siteCode, string variableCode, DataValue dataValue)
        {
            return "Values Updated";
        }

        [WebMethod]
        public string CreateOrUpdateValues(string authToken, string siteCode, string variableCode, DataValue[] dataValues)
        {
            return "Value Deleted";
        }

        [WebMethod]
        public string DeleteValue(string authToken, string siteCode, string variableCode, DateTime dateTimeUTC)
        {
            return "Value Deleted";
        }

        [WebMethod]
        public string DeleteValues(string authToken, string siteCode, string variableCode, DateTime beginDateTimeUTC, DateTime endDateTimeUTC)
        {
            return "Site Deleted";
        }
        
    }
}