# Security and Access Control

This page describes the security and access control system for HydroServer.

The following documentation downloads are available for the HydroServer Security and Access Control System. They may require [Adobe Reader](http://get.adobe.com/reader/)

## Functional Requirements
This document contains the functional requirements for the HydroServer Security and Access Control System.
* [Security and Access Control Requirements Document ](Security and Access Control_DataAccessControl_FunctionalRequirements_8-16-2010.docx)

## Presentations
The following presentation provides a high level overview of the HydroServer Security and Access Control System.
* [Description of HydroServer Security and Access Control System ](Security and Access Control_HydroServerSecurityAndAccessControl.pptx)

## Sequence Diagrams (WORK IN PROGRESS)
The following sequence diagrams describe specific processes that have been identified as requirements in the design for HydroServer security and data acces control.  Each sequence diagram was formulated to identify the key functional requirements that the systems designed for each process will have to support.  These diagrams also show the interaction of the system components and are being used to help define the interfaces and messages transmitted between components.
* [All Sequence Diagrams](Security and Access Control_HydroServerSecuritySequenceDiagrams_10-19-2010.vsd) - This is a Microsoft Visio file that contains all of the sequence diagrams.
* [Sequence 1 - Client Requests User Registration](Security and Access Control_Sequence1.jpg) - The process by which a client application like HydroDesktop can request the registration of a user on a HydroServer.
* [Sequence 2 - Administrator Authorizes User ](Security and Access Control_Sequence2.jpg) - The process by which a HydroServer Administrator authorizes a user to perform operations on a data resource (e.g., create, read, update, delete).
* [Sequence 3 - Client Requests Authorization ](Security and Access Control_Sequence3.jpg) - The process by which a client appication makes a request on bahalf of a user for authorization to perform operations on a data resource.
* [Sequence 4 - Administrator Manages Authorization Requests ](Security and Access Control_Sequence4.jpg) - The process by which a HydroServer administrator manages authorization requests from users.
* [Sequence 5 - Client Gets Metadata ](Security and Access Control_Sequence5.jpg) - The process by which a client application like the HIS Central harvester application gets metadata from a HydroServer.
* [Sequence 6 - Client Gets Data ](Security and Access Control_Sequence6.jpg) - The process by which a client application like HydroDesktop gets data from a HydroServer.
* [Sequence 7 - Security Authenticate User ](Security and Access Control_Sequence7.jpg) - The process by which the security service authenticates a user who has made a request for data or metadata from a HydroServer.
* [Sequence 8 - Security Resolve Resources ](Security and Access Control_Sequence8.jpg) - The process by which the security service determines from the service call which resources a user is requesting.
* [Sequence 9 - Security Authorize Request ](Security and Access Control_Sequence9.jpg) - The process by which the security service authorizes specific requests.


##  Design Documentation (WORK IN PROGRESS)
The design document contains all of the sequence diagrams and text describing them.  It also contains the design for the application programmer interfaces (APIs) that support security and access control on a HydroServer.
* [HydroServer Security and Access Control Design Documentation ](Security and Access Control_HydroServerSecurityandAccessControlDesign_10-19-2010.docx )

