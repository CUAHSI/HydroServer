using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using HydroServer.Framework;

namespace HydroServer.Framework
{
    public class HydroServerFramework
    {
        public static void ConfigureFramework()
        {
            ConfigureViewEngines();
            RegisterRoutes(RouteTable.Routes);
        }

        public static void ConfigureViewEngines() 
        {
            System.Web.Mvc.ViewEngines.Engines.Clear();
            System.Web.Mvc.ViewEngines.Engines.Add(new VersatileViewEngine());
            System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(new AssemblyResourceProvider());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            string[] routenamespaces = {"HydroServer.Framework.Controllers"} ;

            routes.MapRoute("HydroServer.Framework.ObservationalDataService",
                "Observational-Data/{id}",
                new { controller = "Data", action = "ObservationalDataService", id = 0 },
                null, routenamespaces);

            routes.MapRoute("HydroServer.Framework.GISDataService",
                "GIS-Data/{id}",
                new { controller = "Data", action = "GISDataService", id = 0 },
                null, routenamespaces);

            routes.MapRoute("HydroServer.Framework.Region",
                "Region/{id}",
                new { controller = "Data", action = "Region", id = 0 },
                null, routenamespaces);

            routes.MapRoute("HydroServer.Framework.DataQuery",
                "Data-Query",
                new { controller = "DataQuery", action = "DataQuery" },
                null, routenamespaces);

            routes.MapRoute("root",
                "",
                new { controller = "Home", action = "Index", id = "" },
                null, routenamespaces);

            routes.MapRoute("HydroServer.Framework.Controllers.HomeController",
                "{txt}",
                new { controller = "Home", action = "OtherView", txt = "" },
                null, routenamespaces);
        }
    }
}
