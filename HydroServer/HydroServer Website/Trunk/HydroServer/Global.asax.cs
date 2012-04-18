﻿using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hydroserver
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
       
        public static void RegisterRoutes(RouteCollection routes)
        {
            string[] routenamespaces = { "Hydroserver.Controllers" };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");            

            routes.MapRoute("Hydroserver.Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = "" },
                null, routenamespaces);

       

        }

        protected void Application_Start()
        {
            Hydroserver.Configure();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}