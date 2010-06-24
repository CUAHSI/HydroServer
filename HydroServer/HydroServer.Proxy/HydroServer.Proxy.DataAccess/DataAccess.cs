using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HydroServer.Proxy;

namespace HydroServer.Proxy
{
    public class DataAccess : IDisposable, IDataAccess
    {
        private LINQDataContext db { get; set; }

        public DataAccess()
        {
            db = new LINQDataContext();
        }

        public List<ODMDatabase> ODMDatabases()
        {
            return db.ODMDatabases.ToList();
        }

        public List<MapServer> MapServers()
        {
            return db.MapServers.ToList();
        }

        public List<Region> Regions()
        {
            return db.Regions.ToList();
        }

        public void Dispose() 
        {
            db.Dispose();
        }
    }
}
