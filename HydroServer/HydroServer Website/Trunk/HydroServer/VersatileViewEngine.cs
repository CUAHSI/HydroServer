using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Hosting;
using System.Reflection;
using System.Configuration;

namespace Hydroserver
{
    public class VersatileViewEngine : WebFormViewEngine
    {
        public VersatileViewEngine()
            : this(
                new[]
                {
                    "~/Views/{1}/{0}.aspx",
                    "~/Views/{1}/{0}.ascx",
                    "~/Views/Shared/{0}.aspx",
                    "~/Views/Shared/{0}.ascx",
                    "~/[Embedded Resource]/Hydroserver.Views.{1}.{0}.aspx",
                    "~/[Embedded Resource]/Hydroserver.Views.{1}.{0}.ascx",
                    "~/[Embedded Resource]/Hydroserver.Views.Shared.{0}.aspx",
                    "~/[Embedded Resource]/Hydroserver.Views.Shared.{0}.ascx"
                },
                new[]
                {
                    "~/Views/{1}/{0}.Master",
                    "~/Views/Shared/{0}.Master",
                    "~/[Embedded Resource]/Hydroserver.Views.Shared.{0}.Master",
                    "~/[Embedded Resource]/Hydroserver.Views.Shared.Master"
                })
        {
        }

        public VersatileViewEngine(
            IEnumerable<string> viewLocationFormats,
            IEnumerable<string> masterLocationFormats)
        {
            //AreaViewLocationFormats = viewLocationFormats.ToArray();
            //AreaPartialViewLocationFormats = viewLocationFormats.ToArray();
            ViewLocationFormats = viewLocationFormats.ToArray();
            PartialViewLocationFormats = viewLocationFormats.ToArray();
            //AreaMasterLocationFormats = masterLocationFormats.ToArray();
            MasterLocationFormats = masterLocationFormats.ToArray();
        }        

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
	    {
            if (ConfigurationManager.AppSettings["masterName"] != null)
            {
                masterName = ConfigurationManager.AppSettings["masterName"];
            }

	        return base.FindView(controllerContext, viewName, masterName, useCache);
	    }
    }
}
