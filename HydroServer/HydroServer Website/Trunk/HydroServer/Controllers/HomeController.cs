using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hydroserver.Models;

namespace Hydroserver.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        

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
