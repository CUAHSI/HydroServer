**ODM Version 1.1.1 for Microsoft SQL Server - Updated 5-16-2012**
- We now have versions for both Microsoft SQL Server and for MySQL
- Updated CVs in blank schemas
- Add SiteTypeCV

**ODM Version 1.1.1 for MySQL - Updated 5-7-2013**
- Added SiteTypeCV
- Updated SQL dump script to fix some issues with foreign key creation
- Changed all table names to lower case to enhance compatibility with MySQL on Linux

**ODM Tools Version 1.1.3.4 - Updated 10-29-2012**
- Includes a fix moving configuration file out of the Program Files folder for Windows 7 non-admin users
- Includes major performance enhancements - particularly on the Edit tab
- Includes fixes to the statistical summary tab
- Includes fixes to the database connection form
- Includes several other performance related and aesthetic fixes
- Database Configuration boxes allow any character
- Includes fixes for DateTime Errors in Other languages
- Add SiteType CV
- Includes fixes for CV Synchronization
- fix errors created by adding SiteType CV 

**ODM Data Loader Version 1.1.6.1 - Updated 5-16-2012**
- Includes a fix moving the configuration and log files out of the Program Files folder for Windows 7 non-admin users.
- Includes a fix for supporting larger Excel files
- Includes a fix to more accurately report the number of records added to the database
- Includes a fix to the installer to ensure that batch mode operation works correctly
- Includes a fix to ensure that LocalX and LocalY are loaded correctly with Sites
- Includes a fix to increase speed when loading large amounts of datavalues
- Includes a fix to enable loading Categorical Data
- Add SiteType CV

**ODM Streaming Data Loader Version 1.1.3.4 - Updated 5-20-2014**
- Includes new functionality for supporting beginning or end of interval loading of data into an ODM database.
- Includes a fix moving the configuration and log files out of the Program Files folder for Windows 7 non-admin users.
- Includes confirmation dialogs for delete buttons to avoid accidental deletions.
- Includes  a fix to include the capability to use other date formats
- Add SiteType CV
- Increased performance
- Uses SeriesCatalog table to get previous EndDateTime instead of DataValues Table
- Fixes "UNIQUE value" contraint error

**ODM Web Data Loader Version 1.1.1**

**HydroServer Capabilities Database Version 1.1**

**HydroServer Capabilities Database Configuration Tool 1.1.2.2 - Updated 8-24-2011**
- Includes fixes for better handling addition of ODM database information to the HydroServer Capabilities Database
- Includes a fix that checks to ensure that users are connecting to a HydroServer Capabilities database.
- Includes a fix on the database connection form.
- Includes confirmation dialogs on delete buttons to avoid accidental deletions.
- Includes a fix on the Citation entry field to allow longer text strings.

**HydroServer Capabilities Web Service Version 1.1.1.1 - Updated 11-9-2011**
- Includes a fix to ensure correct encoding of the extensible metadata elements within the XML returned by the web service methods
- Includes a fix to ensure that the XML returned by the web service methods is well formed.
- Fixed the deployment directory to have the correct structure.

**HydroServer Map Application Version 1.1**

**HydroServer Time Series Analyst Version 1.1.4**
- Fixed the deployment directory to have the correct structure.
- Added internationalization settings to web.config file.
- Fixed DatePicker so that the Calendar can be selected.
- Rename ZipFolder.

**HydroServer Website Version 1.1.3.3 - Updated 5-16-2012**
- Includes a fix for the incorrect display of the dataset and metadata contacts on individual dataset pages
- Includes a fix for incorrectly displaying preview maps on regions, ODM and GIS Data Services
- Includes fixes to the date picker fields and Regions and Variables lists on the data query page
- Includes new version of MVC and is independent of MVC install on server.
- TSA on ObservationalDataServices page renamed to Time Series Analyst
- Includes a fix to an error caused when multiple ODM databases are added to a single region
- Fixed the depolyment directory to have the correct structure.
- Increase the flexibility of exporting data 

**ODM WaterOneFlow Web Services Version 1.1.1 - Updated 4-7-2014**
- Addresses errors in the cuahsi11.asmx endpoint
- Includes WFS Datacart endpoints
- Includes WaterML 1.0, 1.1, and 2.0 endpoints
- New Web Interface
- Rest endpoints
- Includes improvements over Version 1.0 for delivering more of the content of an ODM database via WaterML responses.
- Includes fixes for returning decimal time support values.
- Includes SiteType CV

**ODM Water One Flow Web Services for PHP Version 2.1 - Updated 5-7-2013**
-Initial upload and documentation added to CodePlex

