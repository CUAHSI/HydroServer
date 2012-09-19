10:31 AM 9/14/2012

BioODM is an extension of ODM to support biological taxa as an additional axis upon which data values are indexed.  It was developed for an ocean sampling project for which several researchers submitted data files to be loaded into a single database.  BioODM includes these changes to ODM:

1.	The addition of a SourceFile field in the Sources table to store the name of the file containing the data values as sent by the investigator.
2.	The addition of a Taxonomy table to describe organisms in the study, and a TaxaID field in the DataValues table to relate each data value to a row in the Taxonomy table.

The ODM Data Loader was also updated accordingly.  A blank BioODM database and the source code for the modified ODM Data Loader are provided.

These modifications were made by Dr. Tim Whiteaker at The University of Texas at Austin for the COMIDA project (http://comidacab.org/).  The project is now finished and there are no current plans to update BioODM with ongoing updates to ODM and related software.

There are additional readme files in the subfolders included here, which further explain changes to ODM and the data loader.