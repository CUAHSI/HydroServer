using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Services;

namespace WaterOneFlow.Services.Gatekeeper
{
   public  interface IWofAuthenticationService
    {
        Boolean TestConfiguration();

        Boolean DataValuesServiceAllowed(HttpContext Context, String token);

        Boolean SitesServiceAllowed(HttpContext Context, String token);

        Boolean SiteInfoServiceAllowed(HttpContext Context, String token);

        Boolean VariableInfoServiceAllowed(HttpContext Context, String token);

    }


}
