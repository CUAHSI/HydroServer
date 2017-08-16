# ODM Data Loader

The main objective of the ODM Data Loader (ODMDL) is to provide data managers with a set of tools for loading data into an ODM database. ODMDL is implemented as a single executable file. However, it can be run using its simple graphical user interface or as a command line executable with arguments that specify the database connection and the files to be loaded. ODMDL is a file based data loader. It is capable of loading all of the individual tables within ODM separately from separate input files (i.e., one file per table), or it can do bulk data loading of all of the ODM tables from a single input file. In general, a single execution of ODMDL loads a single file. ODMDL can be executed using a command line batch file that repeatedly runs the executable with command line arguments so that complex data loading tasks using multiple tables can be automated and repeated. Additionally, ODMDL logs all successful data loads and errors in a text log file. To protect the integrity of data within an ODM database, the ODMDL treats each input file as a single data loading transaction. Because of this, the ODMDL will not load any data unless it can successfully load all of the data contained within the file.

The following documentation is available for the ODM Data Loader. Please consult the software manual for instructions on how to install and use the ODM Data Loader.

## Design Specifications
* [ODM Data Loader Design Specifications Document](ODM Data Loader_ODMDataLoaderFunctionalSpecifications.pdf)

## Software Manual
* [ODM Data Loader Software Manual](ODM Data Loader_ODMDataLoaderSoftwareManual_3-1-2012.pdf)