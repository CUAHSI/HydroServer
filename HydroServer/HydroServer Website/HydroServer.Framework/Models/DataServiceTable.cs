using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HydroServer.Framework.Models
{
    public class DataServiceTableEntry
    {
        public int DatabaseID { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Citation { get; set; }
        public string ServerName { get; set; }
        public string Topic { get; set; }
        public string DatabaseName { get; set; }
    }

    public class DataServiceTable
    {
        public string ItemUrl { get; set; }
        public List<DataServiceTableEntry> Entries;
    }
}

