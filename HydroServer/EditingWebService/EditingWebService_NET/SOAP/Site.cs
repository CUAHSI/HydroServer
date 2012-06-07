using System;
using System.Collections.Generic;
using System.Web;

namespace SoapService
{
    public class Site
    {
        public long Id { get; set; } 
        public string Code { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Elevation { get; set; }
        public double LocalX { get; set; }
        public double LocalY { get; set; }
        public string SiteType { get; set; }
        public string Comments { get; set; }
    }
}