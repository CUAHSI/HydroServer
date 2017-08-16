# Observations Data Model (ODM)

ODM is a data model for the storage and retrieval of hydrologic observations in a relational database. The purpose for such a database is to store hydrologic observations data in a system designed to optimize data retrieval for integrated analysis of information collected by multiple investigators. It is intended to provide a standard format to aid in the effective sharing of information between investigators and to allow analysis of information from disparate sources both within a single study area or hydrologic observatory and across hydrologic observatories and regions. ODM is designed to store hydrologic observations and sufficient ancillary information (metadata) about the data values to provide traceable heritage from raw measurements to usable information allowing them to be unambiguously interpreted and used. A relational database format is used to provide querying capability to allow data retrieval supporting diverse analyses.

The following documentation downloads are available for the CUAHSI Observations Data Model. They may require [Adobe Reader](http://get.adobe.com/reader/)

## Design Specifications
* [ODM 1.1 Design Specifications Document](Observations Data Model_ODM1.1DesignSpecifications.pdf) (2.3M)
* [ODM 1.1.1 Design Specifications Document](Observations Data Model_ODM1.1.1DesignSpecifications.pdf) (2.4M)

## Schema Diagram
![](Observations Data Model_ ODM1_1SchemaDiagram_sm.jpg)
* [ODM 1.1 Schema Diagram](Observations Data Model_ODM1.1SchemaDiagram.pdf)
* [ODM 1.1.1 Schema Diagram](Observations Data Model_ODM1.1.1SchemaDiagram.pdf)

##  Getting Started With ODM for Microsoft SQL Server
* [Instructions for attaching blank ODM 1.1 SQL Server Schema ](Observations Data Model_GettingStartedWithODM.pdf ) (381KB)
* [Instructions for attaching blank ODM 1.1.1 SQL Server Schema ](Observations Data Model_GettingStartedWithODM1.1.1.pdf ) (592KB)

##  Getting Started With ODM for MySQL
* [Instructions for creating a blank ODM 1.1 database in MySQL ](Observations Data Model_GettingStartedWithODMforMySQL.pdf ) (607KB)
* [Instructions for creating a blank ODM 1.1.1 database in MySQL ](Observations Data Model_GettingStartedWithODM1.1.1forMySQL.pdf ) (3.2MB)

## ODM 1.1 Sample Microsoft SQL Server Database
The following ODM 1.1 sample database is available. It contains preliminary continuous water quality monitoring data from the Little Bear River Experimantal Watershed in Utah.  It was created in Microsoft SQL Server 2005 but is also compatible with 2008.
* [Little Bear River Utah ODM 1.1 SQL Server Database](http://his.cuahsi.org/software/LittleBear1.1TestingDatabase.zip) (58MB)

## ODM 1.1.1 Sample Microsoft SQL Server Database
The following ODM 1.1.1 sample database is available. It contains a small set of preliminary continuous water quality and weather monitoring data from the Little Bear River Experimental Watershed in Utah.  It was created in Microsoft SQL Server 2005 but is also compatible with 2008.
* [Little Bear River Utah ODM 1.1.1 SQL Server Database](http://his.cuahsi.org/software/LittleBear1.1.1TestingDatabase.zip) (3MB)

## ODM 1.1.1 Sample MySQL Database
The following ODM 1.1.1 sample database is available. It contains a small set of preliminary continuous water quality and weather monitoring data from the Little Bear River Experimental Watershed in Utah.  It was created in MySQL and contains the same data as the SQL Server version.
* [Little Bear River Utah ODM 1.1.1 MySQL Database](Observations Data Model_LittleBear_ODM_1.1.1_MySQL.zip) (1MB)

## Convert ODM 1.1 to ODM 1.1.1
The following SQL script is available to convert your ODM 1.1 database to an ODM 1.1.1 database with a SiteType field in the Sites table.  Instructions for using the script are also provided.
* [Convert ODM 1.1 to ODM 1.1.1 SQL Script](Observations Data Model_Convert_ODM_1.1_to_1.1.1.sql) (54KB)
* [Instructions for converting ODM 1.1 to ODM 1.1.1](Observations Data Model_Convert_ODM_1.1_to_1.1.1_Instructions.pdf) (3.1MB)

## Convert ODM SQL Server to MySQL
The following python scripts are available to convert your ODM database content from SQL Server to MySQL and back. The first script (mssql2mysql.py) converts SQL Server to MySQL. The second script (mysql2mssql.py) converts data from MySQL to SQL Server. You need to edit the database name and password in the script. The output of each script is a .sql file with the exported data that can be imported into the database.
* [Convert SQL Server to MySQL Script in Python](Observations Data Model_mssql2mysql.py) (10KB)
* [Convert MySQL to SQL Server Script in Python ](Observations Data Model_mysql2mssql.py) (9KB)
* [Instructions ](Observations Data Model_README_mysql2mssql.txt) (1KB)

## Controlled Vocabularies and ODM
Please be aware that sample and example ODM databases that you download only contain a snapshot of the controlled vocabulary data as of a certain date. Since ODM's master controlled vocabulary tables are updated on a continual basis, any snapshot is bound to almost immediatly become out of date. However, once you attach a database file to an instance of SQL Server, you can use [ODM Tools](ODM-Tools) to update the controlled vocabulary in your ODM database from the master controlled vocabulary tables. 