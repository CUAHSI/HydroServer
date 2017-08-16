# WaterOneFlow Web Services for Windows and SQL Server
The WaterOneFlow Web Services were created for publishing on the Internet hydrologic observations stored in an ODM database that is hosted on a HydroServer.  Each ODM database requires a separate WaterOneFlow Web Service to publish its contents.  The WaterOneFlow services respond to user requests for data by querying the underlying ODM database and then translating the results of the query into WaterML format.  The data is then communicated back to the user over the Internet using WaterML.  The WaterOneFlow services consist of a standard set of data discovery and data delivery methods (e.g., GetSites, GetVariables, GetSiteInfo, GetVariableInfo, GetValues) that can be used by computer programmers and a variety of client software program to access hydrologic observations stored in an ODM database over the Internet.

## Software Manual - Updated 6/29/2010
* [WaterOneFlow Version 1.1 Software Manual](WaterOneFlow Web Services_HydroServerWaterOneFlow1.1SoftwareManual_8-31-2011.pdf)

# WaterOneFlow Web Services for PHP and MySQL
A PHP version of the WaterOneFlow web services for publishing the contents of a MySQL ODM database on the Internet in WaterML format. This component can run on any Linux or Windows server with PHP and MySQL support.

## Documentation - Updated 6/28/2013
* [WaterOneFlow Web Service for PHP](WaterOneFlow-Web-Service-for-PHP)

