using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HydroServer.Framework.Models;

namespace HydroServer.Framework.Controllers
{
    /// <summary>
    /// Default HomeController
    /// </summary>
    [HandleError]
    public class HomeController : Controller
    {
        /// <summary>
        /// Default Index page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var db = new HISDataContext();

            return View(new DataServiceModel { ODMDatabases = db.ODMDatabases.ToList(), MapServices = db.MapServices.ToList(), Regions = db.Regions.ToList() });
        }

        public ActionResult OtherView(string txt)
        {
            return View(txt);
        }
    }
}
