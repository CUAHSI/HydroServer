using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HydroServer.Framework.Models;

namespace HydroServer.Framework.Controllers
{
    /// <summary>
    /// This controller handles Observational and GIS Data Services
    /// </summary>
    public class DataController : Controller
    {
        HISDataContext db = new HISDataContext();

        /// <summary>
        /// Provides a list of observational data services.
        /// </summary>
        /// <returns></returns>
        public ActionResult ObservationalDataServices()
        {
            DataServiceTable dataTable = new DataServiceTable() { ItemUrl = "Observational-Data/", Entries = new List<DataServiceTableEntry>() };
            var services = db.ODMDatabases;

            foreach (var item in services)
            {
                DataServiceTableEntry entry =
                    new DataServiceTableEntry
                    {
                        DatabaseID = item.DatabaseID,
                        Title = item.Title,
                        Abstract = item.Abstract,
                        Citation = item.Citation,
                        ServerName = item.ServerAddress,
                        Topic = item.TopicCategory,
                        DatabaseName = item.DatabaseName
                    };
                dataTable.Entries.Add(entry);
            }

            return View(dataTable);
        }

        /// <summary>
        /// /// Provides a list of GIS data services.
        /// </summary>
        /// <returns></returns>
        public ActionResult GISDataServices()
        {
            DataServiceTable dataTable = new DataServiceTable() { ItemUrl = "GIS-Data/", Entries = new List<DataServiceTableEntry>() };
            var services = db.MapServices;

            foreach (var item in services)
            {
                DataServiceTableEntry entry =
                    new DataServiceTableEntry
                        {
                            DatabaseID = item.MapServiceID,
                            Title = item.Title,
                            Abstract = item.Abstract,
                            ServerName = item.MapServer.MapServerName,
                            Topic = item.TopicCategory
                        };
                dataTable.Entries.Add(entry);
            }

            return View(dataTable);
        }

        /// <summary>
        /// View details for a specific observational data service
        /// </summary>
        /// <param name="id">The DatabaseID of the data service.</param>
        /// <returns></returns>
        public ActionResult ObservationalDataService(int id)
        {
            var item = db.ODMDatabases.SingleOrDefault(d => d.DatabaseID == id);

            if (item != null)
            {
                var metaDataList = (from md in db.ODMDatabaseMetadatas
                                    where (md.DatabaseID == item.DatabaseID)
                                    orderby md.DisplayOrder
                                    select md).ToList();
                
                var siteList = new List<Site>();

                using (var db2 = DataQueryRepository.GetODMDbDataContext(item))
                {
                    siteList = db2.Sites.ToList();
                }

                return View(new ODMDatabaseModel { 
                    ODMDatabase = item, 
                    Metadata = metaDataList, 
                    MetadataContact = (item.MetadataContactID != null) ?
                        db.Contacts.SingleOrDefault(c => c.ContactID == item.MetadataContactID) :
                        null,
                    Sites = siteList
                });
            }

            return View("NotFound");
        }

        /// <summary>
        /// View details for a specific GIS data service
        /// </summary>
        /// <param name="id">The MapServerID of the data service.</param>
        /// <returns></returns>
        public ActionResult GISDataService(int id)
        {
            var item = db.MapServices.SingleOrDefault(d => d.MapServiceID == id);

            if (item != null)
            {
                var metaDataList = (from md in db.MapServiceMetadatas
                                    where (md.MapServiceID == item.MapServiceID)
                                    orderby md.DisplayOrder
                                    select md).ToList();
                return View(new MapServiceModel { 
                    MapService = item, 
                    Metadata = metaDataList ,
                    MetadataContact = (item.MetadataContactID != null) ?
                        db.Contacts.SingleOrDefault(c => c.ContactID == item.MetadataContactID) :
                        null
                });
            }

            return View("NotFound");
        }

        public ActionResult Regions()
        {
            DataServiceTable dataTable = new DataServiceTable() { ItemUrl = "Region/", Entries = new List<DataServiceTableEntry>() };
            var regions = db.Regions;

            foreach (var item in regions)
            {
                var rd = db.RegionDatabases.SingleOrDefault(r => r.RegionID == item.RegionID);
                var database = db.ODMDatabases.SingleOrDefault(o => o.DatabaseID == rd.DatabaseID);

                DataServiceTableEntry entry =
                    new DataServiceTableEntry
                    {
                        DatabaseID = item.RegionID,
                        Title = item.RegionTitle,
                        Abstract = item.RegionDescription,
                        Topic = item.RegionName,
                        DatabaseName = database.DatabaseName
                    };

                dataTable.Entries.Add(entry);
            }

            return View(dataTable);
        }

        public ActionResult Region(int id)
        {
            Region item = db.Regions.SingleOrDefault(d => d.RegionID == id);

            if (item != null)
            {
                var databases = from data in db.RegionDatabases
                                where (data.RegionID == item.RegionID)
                                select db.ODMDatabases.SingleOrDefault(d => d.DatabaseID == data.DatabaseID);

                var gisServices = from data in db.RegionMapServices
                                  where (data.RegionID == item.RegionID)
                                  select db.MapServices.SingleOrDefault(d => d.MapServiceID == data.MapServiceID);

                var metaDataList = (from md in db.RegionMetadatas
                                    where (md.RegionID == item.RegionID)
                                    orderby md.DisplayOrder
                                    select md).ToList();

                return View(new RegionContentsModel { 
                    Region = item, 
                    ODMDatabases = 
                    databases.ToList(), 
                    MapServices = gisServices.ToList(), 
                    Metadata = metaDataList
                });
            }

            return View("NotFound");
        }
    }
}
