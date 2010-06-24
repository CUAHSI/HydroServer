using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HydroServer.Proxy;

namespace HydroServer.Proxy
{
    interface IDataAccess
    {
        List<ODMDatabase> ODMDatabases();
        List<MapServer> MapServers();
        List<Region> Regions();
    }
}
