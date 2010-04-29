using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HydroServer.Framework.Models
{
    /// <summary>
    /// Represents composite data from several ODM databases.
    /// </summary>
    public class DataQueryModel
    {
        /// <summary>
        /// A list of all Time Series from multiple databases.
        /// </summary>
        /// <value>The series catalog.</value>
        public List<TimeSeriesModel> SeriesCatalog { get; set; }
        /// <summary>
        /// A list of all Regions from multiple databases.
        /// </summary>
        /// <value>The regions.</value>
        public List<RegionModel> Regions { get; set; }
        /// <summary>
        /// A list of all Sites from multiple databases.
        /// </summary>
        /// <value>The sites.</value>
        public List<SiteModel> Sites { get; set; }
        /// <summary>
        /// A list of all Sources from multiple databases.
        /// </summary>
        /// <value>The sources.</value>
        public List<SourceModel> Sources { get; set; }
        /// <summary>
        /// A list of all Variables from multiple databases.
        /// </summary>
        /// <value>The variables.</value>
        public List<VariableModel> Variables { get; set; }
        /// <summary>
        /// The data query form.
        /// </summary>
        /// <value>The data query form.</value>
        public DataQueryFormModel DataQueryForm { get; set; }
    }

    /// <summary>
    /// Lists of DbIDs for all sites, sources, and variables that were selected by the user
    /// </summary>
    public class DataQueryFormModel
    {
        /// <summary>
        /// Region IDs.
        /// </summary>
        /// <value>The region IDs.</value>
        public List<DbID> RegionIDs { get; set; }
        /// <summary>
        /// Variable IDs.
        /// </summary>
        /// <value>The variable IDs.</value>
        public List<DbID> VariableIDs { get; set; }
        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public Nullable<DateTime> StartTime { get; set; }
        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>The end time.</value>
        public Nullable<DateTime> EndTime { get; set; }
        /// <summary>
        /// Gets or sets the custom variable.
        /// </summary>
        /// <value>The custom variable.</value>
        public string CustomVariable { get; set; }
    }

    /// <summary>
    /// List of string values for each Region and Variable selected by the user; each
    /// string contains the primary key and database name of the element
    /// </summary>
    public class UnparsedDataQueryFormModel
    {
        /// <summary>
        /// Gets or sets the region IDs.
        /// </summary>
        /// <value>The site IDs.</value>
        public List<string> RegionIDs { get; set; }
        /// <summary>
        /// Gets or sets the variable IDs.
        /// </summary>
        /// <value>The variable IDs.</value>
        public List<string> VariableIDs { get; set; }
        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public string StartTime { get; set; }
        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>The end time.</value>
        public string EndTime { get; set; }
        /// <summary>
        /// Gets or sets the custom variable.
        /// </summary>
        /// <value>The custom variable.</value>
        public string CustomVariable { get; set; }
    }

    /// <summary>
    /// A region
    /// </summary>
    public class RegionModel
    {
        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>The region.</value>
        public Region Region { get; set; }
        /// <summary>
        /// Gets or sets the odm db.
        /// </summary>
        /// <value>The odm db.</value>
        public string OdmDb { get; set; }
    }

    /// <summary>
    /// A site
    /// </summary>
    public class SiteModel
    {
        /// <summary>
        /// Gets or sets the site.
        /// </summary>
        /// <value>The site.</value>
        public Site Site { get; set; }
        /// <summary>
        /// Gets or sets the odm db.
        /// </summary>
        /// <value>The odm db.</value>
        public string OdmDb { get; set; }
    }

    /// <summary>
    /// A source
    /// </summary>
    public class SourceModel
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public Source Source { get; set; }
        /// <summary>
        /// Gets or sets the odm db.
        /// </summary>
        /// <value>The odm db.</value>
        public string OdmDb { get; set; }
    }

    /// <summary>
    /// A variable
    /// </summary>
    public class VariableModel
    {
        /// <summary>
        /// Gets or sets the variable.
        /// </summary>
        /// <value>The variable.</value>
        public Variable Variable { get; set; }
        /// <summary>
        /// Gets or sets the odm db.
        /// </summary>
        /// <value>The odm db.</value>
        public string OdmDb { get; set; }
    }

    /// <summary>
    /// A timeseries
    /// </summary>
    public class TimeSeriesModel
    {
        /// <summary>
        /// Gets or sets the time series.
        /// </summary>
        /// <value>The time series.</value>
        public TimeSeries TimeSeries { get; set; }
        /// <summary>
        /// Gets or sets the odm db.
        /// </summary>
        /// <value>The odm db.</value>
        public string OdmDb { get; set; }
    }

    /// <summary>
    /// Contains the primary key of an element, plus the ODM database name it comes from
    /// </summary>
    public class DbID
    {
        /// <summary>
        /// The primary key of the element.
        /// </summary>
        /// <value>The ID.</value>
        public int ID { get; set; }
        /// <summary>
        /// The name of the containing ODM database.
        /// </summary>
        /// <value>The odm db.</value>
        public string OdmDb { get; set; }
    }
}
