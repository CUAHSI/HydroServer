# ODM Web Data Loader

The main objective of the ODM Web Data Loader (ODMDL) is to provide HydroServer data managers with a set of tools for loading data into an ODM database through a Web interface.  The ODMWDL can be used to overcome common limitations experienced by research groups that are working across institutional firewalls.  Most firewalls block the ports used to make external connections to a SQL Server database.  An example of this is an investigator from outside a University campus trying to load data into an ODM database that is within the University's firewall, but being blocked by firewall restrictions imposed by the University.  The ODMWDL enables users to submit files to be loaded into an ODM database through a Web interface over the common HTTP port, which is unlikely to be blocked. 

Like the Windows-based ODMDL, ODMWDL is a file based data loader. It is capable of loading all of the individual tables within ODM separately from separate input files (i.e., one file per table), or it can do bulk data loading of all of the ODM tables from a single input file.  In general, a single execution of ODWMDL loads a single file.  ODMDL logs all successful data loads and errors in a text log file. To protect the integrity of data within an ODM database, the ODMWDL treats each input file as a single data loading transaction.  Because of this, the ODMWDL will not load any data unless it can successfully load all of the data contained within the file.  Users of the ODMWDL must authenticate themselves and be authorized by a HydroServer administrator to use the tool.

The following documentation is available for the ODM Web Data Loader. Please consult the software manual for instructions on how to install and use the ODM Web Data Loader.

## Design Specifications
* [ODM Web Data Loader Design Specifications Document](ODM Web Data Loader_ODMWebDataLoaderFunctionalSpecifications.pdf)

## Software Manual
* [ODM Web Data Loader Software Manaual](ODM Web Data Loader_ODMWebDataLoaderSoftwareManual_3-1-2012.pdf)
