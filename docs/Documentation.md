[Getting HydroServer](Getting-HydroServer), [Presentations and Publications](Presentations-and-Publications), [Training Materials](Training-Materials)
----
# HydroServer Documentation
## Getting HydroServer
Get [instructions](Getting-HydroServer) on how to access the source code for HydroServer applications.

## HydroServer Components
Documentation for each of the HydroServer software components can be found on the following pages:
* [Observations Data Model](Observations-Data-Model) - A relational schema for storing point hydrologic observations in a relational database managmenet system.
* [ODM Tools](ODM-Tools) - A software application for querying, visualizing, and editing data stored in an ODM database.
* [ODM Data Loader](ODM-Data-Loader) - A software application for loading data from CSV or Excel files into an ODM database.
* [ODM Web Data Loader](ODM-Web-Data-Loader) - A Web application for enabling users to load data into an ODM database on your HydroServer.
* [ODM Streaming Data Loader](ODM-Streaming-Data-Loader) - A software application for automating the loading of streaming sensor data into an ODM database.
* [WaterOneFlow Web Services](WaterOneFlow-Web-Services) - A web application for publishing the contents of an ODM database on the Internet in WaterML format.
* [HydroServer Capabilities](HydroServer-Capabilities) - A database, configuration tool, and web service for publishing the capabilities of a HydroServer on the Internet in a machine readable format.
* [HydroServer Website](HydroServer-Website) - A public website for publishing the capabilities of a HydroServer.
* [Time Series Analyst](Time-Series-Analyst) - A web application that provides data visualization, summary, and download for observational data stored in ODM databases on a HydroServer.
* [HydroServer Map](HydroServer-Map) - A dynamic web map application for presenting both spatial (GIS) datasets and observational data for a reasearch watershed or region for which data have been published.
* [Security and Access Control](Security-and-Access-Control) - The system for controlling access to data hosted on a HydroServer.

## HydroServer Derivatives
* BioODM ([http://hydroserver.codeplex.com/SourceControl/list/changesets](http://hydroserver.codeplex.com/SourceControl/list/changesets)) - BioODM is an extension of ODM to support biological taxa as an additional axis upon which data values are indexed.  It was developed for an ocean sampling project for which several researchers submitted data files to be loaded into a single database. The ODM Data Loader was also updated accordingly.  A blank BioODM database and the source code for the modified ODM Data Loader are provided in the subfolders under BioODM. These modifications were made for the COMIDA project (http://comidacab.org/).  The project is now finished and there are no current plans to update BioODM with ongoing updates to ODM and related software.  There are additional readme files in the subfolders included here, which further explain changes to ODM and the data loader.  BioODM includes these changes to ODM: 
	*  The addition of a SourceFile field in the Sources table to store the name of the file containing the data values as sent by the investigator.
	* The addition of a Taxonomy table to describe organisms in the study, and a TaxaID field in the DataValues table to relate each data value to a row in the Taxonomy table. 

## Other HydroServer-Related Development Efforts
Visit the [HydroServer-Related Developments](HydroServer-Related-Developments) page to learn more about ongoing development of tools and utilities related to CUAHSI HIS and HydroServer.  

## Presentations and Publications
Visit the [Presentations and Publications](Presentations-and-Publications) page for a list of presentations and publications associated with HydroServer.

## Training Materials and Exercises
Visit the [Training Materials](Training-Materials) page for computer exercises and sample datasets that will assist you in setting up, configuring, and using your HydroServer.

## Automated Builds
* [WaterOneFlow Services](http://hydro10.sdsc.edu:88/viewType.html?buildTypeId=bt71&tab=buildTypeStatusDiv) log in a guest