using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Web;

namespace WaterOneFlow.Services.Gatekeeper
{
    public class SingleTokenGatekeeper : WofAuthenticationImpl
    {
        // internal only
        private static string serviceAuthToken;

#region IWofAuthenticationService Members

        public override bool TestConfiguration()
        {
            // does this have a token
           if(GatekeeperPropertiesSection != null )
           {
               foreach (GateKeeperPropertiesConfigElement e in   GatekeeperPropertiesSection.GatekeeperPropertiesSection)
               {
                   if(e.property.Equals("token",StringComparison.CurrentCultureIgnoreCase))
                   {
                       serviceAuthToken = e.value;
                       return true;
                   }
               }
           }

            return false;
           
        }

        public override bool DataValuesServiceAllowed(HttpContext Context, string token)
        {
            return tokenCheck(token);
        }

        public override bool SitesServiceAllowed(HttpContext Context, string token)
        {
           return tokenCheck(token);
        }

        public override bool SiteInfoServiceAllowed(HttpContext Context, string token)
        {
            return tokenCheck(token);
        }

        public override bool VariableInfoServiceAllowed(HttpContext Context, string token)
        {
            return tokenCheck(token);
        }

        #endregion

        private static Boolean tokenCheck(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new AuthenticationException("Authentication token is required.");
            }
            if (serviceAuthToken.Equals(token))
            {
                return true;
            } else
            {
                throw new AuthenticationException("Authentication token is not correct. Please submit a correct authentication token.");
            }
        }
    }
}
