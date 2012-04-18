using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HydroServer.Framework.Models;

namespace HydroServer.Framework.Controllers
{
    /// <summary>
    /// This controller handles the Data Query tool, allowing users to query multiple ODM 
    /// databases for information by Region and Variable, and download sets of time series
    /// </summary>
    public class DataQueryController : Controller
    {
        HISDataContext db = new HISDataContext();

        /// <summary>
        /// Returns the Data Query start page.
        /// </summary>
        /// <returns></returns>
        public ActionResult DataQuery()
        {
            return View(DataQueryRepository.NewDataQueryModel(db));
        }

        /// <summary>
        /// Runs the Data Query tool, and either provides a list of query results or downloads
        /// a specified set of results.
        /// </summary>
        /// <param name="unparsedDataQueryForm">
        ///     A list of checkbox values and odmDb titles; this list can be converted into a
        ///     List of DbIDs by using ParsedDataQueryForm(unparsedDataQueryForm) in the 
        ///     DataQueryRepository class.
        /// </param>
        /// <param name="submit">
        ///     The value of the submit button pressed:
        ///     "Query" to run a database query, "Download" to download the results
        /// </param>
        /// <param name="form">Paramaters passed to the server as a FormCollection.</param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DataQuery(UnparsedDataQueryFormModel unparsedDataQueryForm, string submit, FormCollection form)
        {
            DateTime startTime = new DateTime();
            DateTime endTime = new DateTime();
            if (unparsedDataQueryForm.StartTime != null)
            {
                if (!DateTime.TryParse(unparsedDataQueryForm.StartTime.ToString(), out startTime))
                {
                    ViewData["startTime"] = "Invalid start date!";
                    return View(DataQueryRepository.NewDataQueryModel(db));
                }
            }
            if (unparsedDataQueryForm.EndTime != null)
            {
                if (!DateTime.TryParse(unparsedDataQueryForm.EndTime.ToString(), out endTime))
                {
                    ViewData["endTime"] = "Invalid end date!";
                    return View(DataQueryRepository.NewDataQueryModel(db));
                }
            }
               
            DataQueryFormModel dataQueryForm = DataQueryRepository.ParsedDataQueryForm(unparsedDataQueryForm);

            ViewData["norecords"] = "No records found.";

            switch (submit)
            {
                case "Query":
                    return View(DataQueryRepository.NewDataQueryModel(db, dataQueryForm));
                    break;

                case "Download":
                    DownloadToSingleFile(dataQueryForm, form);
                    return View("Download");
                    break;
            }

            return View(DataQueryRepository.NewDataQueryModel(db));
            
        }

        /// <summary>
        /// Downloads the selected time series into a single file.
        /// </summary>
        /// <param name="dataQueryForm">The data query form.</param>
        /// <param name="form">Parameters passed to the server.</param>
        public void DownloadToSingleFile(DataQueryFormModel dataQueryForm, FormCollection form)
        {            
            HttpContext.Response.Clear();

            string fileName = String.Format("data-{0}.csv", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
            HttpContext.Response.ContentType = "text/csv";
            HttpContext.Response.AddHeader("content-disposition", "filename=" + fileName);

            DataQueryRepository.Download(db, dataQueryForm, form);

            HttpContext.Response.End();
        }
    }
}
