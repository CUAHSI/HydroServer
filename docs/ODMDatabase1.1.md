# Observations Data Model (ODM)

The CUAHSI Hydrologic Information System project is developing information technology infrastructure to support hydrologic science. One aspect of this is a data model for the storage and retrieval of hydrologic observations in a relational database. The purpose for such a database is to store hydrologic observations data in a system designed to optimize data retrieval for integrated analysis of information collected by multiple investigators. It is intended to provide a standard format to aid in the effective sharing of information between investigators and to allow analysis of information from disparate sources both within a single study area or hydrologic observatory and across hydrologic observatories and regions. The observations data model is designed to store hydrologic observations and sufficient ancillary information (metadata) about the data values to provide traceable heritage from raw measurements to usable information allowing them to be unambiguously interpreted and used. A relational database format is used to provide querying capability to allow data retrieval supporting diverse analyses. A generic template for the observations database is presented. This is referred to as the Observations Data Model (ODM).

## Controlled Vocabularies and ODM
Please be aware that sample and example ODM databases that you download only contain a snapshot of the controlled vocabulary data as of a certain date. Since HIS's master controlled vocabulary tables are updated on a continual basis, any snapshot is bound to almost immediatly become out of date. However, once you attach a database file to an instance of SQL Server, you can use the ODM Tools utility to update the controlled vocabulary in a database from HIS's master controlled vocabulary tables. 

## ODM 1.1
The following downloads are available for Version 1.1 of the CUAHSI Observations Data Model. May require [Adobe Reader](http://get.adobe.com/reader/)
* [ODM 1.1 Design Specifications Document ](ODMDatabase1.1_ODM1.1DesignSpecifications.pdf) (2.3M)
* [ODM 1.1 Blank SQL Server Schema Database ](ODMDatabase1.1_ODM1.1BlankSQLServerSchema.zip) (577KB CV dated 1/27/2010)
* [Instructions for attaching blank SQL Server schema ](ODMDatabase1.1_GettingStartedWithODM.pdf ) (381KB)

## ODM 1.1 Sample Databases
The following ODM 1.1 sample databases are available. The Little Bear River database contains preliminary continuous water quality monitoring data from the Little Bear River WATERS Test Bed in Utah. 
* [Little Bear River Utah ODM 1.1 SQL Server Database](ODMDatabase1.1_HydroServer.zip) (58MB) 