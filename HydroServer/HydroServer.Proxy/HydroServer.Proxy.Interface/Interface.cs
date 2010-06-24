using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HydroServer.Proxy;

namespace HydroServer.Proxy
{
    public class Interface : IDisposable
    {
        private DataAccess da { get; set; }

        public Interface()
        {
            da = new DataAccess();
        }

        public List<ODMDatabase> ODMDatabases()
        {
            return da.ODMDatabases();   
        }

        public List<ODMDatabase> ODMDatabaseQuery1()
        {
            return (from item in da.ODMDatabases()
                    where (item.Title == "TWDEF ODM Database" )
                    select item).ToList();
        }

        public List<MapServer> MapServers()
        {
            return da.MapServers();
        }

        public List<Region> Regions()
        {
            return da.Regions();
        }

        public void Dispose()
        {
            da.Dispose();
        }
    }
}
