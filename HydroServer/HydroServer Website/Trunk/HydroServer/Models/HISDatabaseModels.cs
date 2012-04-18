using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hydroserver.Models;

namespace Hydroserver.Models
{
    /// <summary>
    /// An ODM Database and a list of its metadata
    /// </summary>
    public class ODMDatabaseModel
    {
        /// <summary>
        /// Gets or sets the ODM database.
        /// </summary>
        /// <value>The ODM database.</value>
        public ODMDatabase ODMDatabase { get; set; }
        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        /// <value>The metadata.</value>
        public List<ODMDatabaseMetadata> Metadata { get; set; }
        /// <summary>
        /// Gets or sets the metadata contact.
        /// </summary>
        /// <value>The metadata contact.</value>
        public Contact MetadataContact { get; set; }
        /// <summary>
        /// Gets or sets the sites.
        /// </summary>
        /// <value>The sites.</value>
        public List<Site> Sites { get; set; }
    }

    /// <summary>
    /// A MapService and a list of its metadata
    /// </summary>
    public class MapServiceModel
    {
        /// <summary>
        /// Gets or sets the map service.
        /// </summary>
        /// <value>The map service.</value>
        public MapService MapService { get; set; }
        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        /// <value>The metadata.</value>
        public List<MapServiceMetadata> Metadata { get; set; }
        /// <summary>
        /// Gets or sets the metadata contact.
        /// </summary>
        /// <value>The metadata contact.</value>
        public Contact MetadataContact { get; set; }
    }

    /// <summary>
    /// A Region, a list of its metadata, and lists of the ODMDatabases and MapServices within the region
    /// </summary>
    public class RegionContentsModel
    {
        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>The region.</value>
        public Region Region { get; set; }
        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        /// <value>The metadata.</value>
        public List<RegionMetadata> Metadata { get; set; }
        /// <summary>
        /// Gets or sets the metadata contact.
        /// </summary>
        /// <value>The metadata contact.</value>
        public Contact MetadataContact { get; set; }
        /// <summary>
        /// Gets or sets the ODM databases.
        /// </summary>
        /// <value>The ODM databases.</value>
        public List<ODMDatabase> ODMDatabases { get; set; }
        /// <summary>
        /// Gets or sets the map services.
        /// </summary>
        /// <value>The map services.</value>
        public List<MapService> MapServices { get; set; }
    }
}
