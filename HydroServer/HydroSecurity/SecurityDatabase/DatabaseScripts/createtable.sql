use HydroSecure;

create table ResourceType
(
ResourceTypeId int identity(1,1) primary key(ResourceTypeId),
Name varchar(10) unique(Name) not null,
description varchar(32),
);

create table Resources
(
ResourceId uniqueidentifier primary key(ResourceId),
ResourceType int references ResourceType(ResourceTypeId) not null,
DateCreated datetime not null,
);

create table TimeSeriesResource
(
TimeSeriesResourceId uniqueidentifier primary key(TimeSeriesResourceId) references Resources(ResourceId),
TimeSeriesMetadataId  uniqueidentifier,
SeriesID int,
SiteID   int,
SiteCode varchar(50),
SiteName varchar(255),
VariableID int,
VariableCode varchar(50),
VariableName varchar(225),
Speciation   varchar(225),
VariableUnitsID int,
VariableUnitsName varchar(225),
SampleMedium varchar(225),
ValueType  varchar(225),
TimeSupport float,
TimeUnitsID  int,
TimeUnitsName  varchar(225),
DataType varchar(225),
GeneralCategory  varchar(225),
MethodID  int,
MethodDescription varchar(max),
SourceID  int,
Organization  varchar(225),
SourceDescription  varchar(max),
Citation varchar(max),
QualityControlLevelID int,
QualityControlLevelCode varchar(50),
ValueCount int,
DateCreated datetime not null,
DatabaseName varchar(255),
WaterOneFlowWSDL varchar(max),
 
);

create table ResourceMetaDataMapping
(
TimeSeriesDataId uniqueidentifier primary key(TimeSeriesDataId) references TimeSeriesResource(TimeSeriesResourceId),
TimeSeriesMetaDataId uniqueidentifier,
);

Create table Document
(
DocumentId uniqueidentifier primary key(DocumentId) references Resources(ResourceId),
Name varchar(128),
Title varchar(max),
Location varchar(max),
DateCreated datetime not null,
);



create table TrustedCA
(
 CertificateAuthorityId int identity(1,1) primary key(CertificateAuthorityId),
 Name varchar(132) not null,
);

create table ConsumerCertificate
(
CertificateId int identity(1,1) primary key(CertificateId),
SerialNo varchar(264) ,
Verson varchar(64) not null,
SubjectName varchar(132) not null,
SubjectOrganization varchar(132) not null,
SubjectEmailAdd varchar(132) not null,
SubjectCountry varchar(64) not null,
IssuerName varchar(132) not null,
ValidFrom datetime not null,
ValidTill datetime not null,
);


create table ResourceConsumer
(
ResourceConsumerId int identity(1,1) Primary key(ResourceConsumerId),
ResourceConsumerCertificate int references ConsumerCertificate(CertificateId) not null,
ResourceConsumerName varchar(132) not null,
ResourceConsumerEmailAdd varchar(132) not null,

);


create table UserGroup
(
UserGroupId int identity(1,1) primary key(UserGroupId),
Name varchar(32) unique(Name) not null,
DateCreated datetime not null,
OwnerId int references ResourceConsumer(ResourceConsumerId) not null,
);

create table UserGroupResourceConsumer
( 
UserGroupConsumerId int identity(1,1) primary key(UserGroupConsumerId),
UserGroupId int references UserGroup(UserGroupId) not null,
ResourceConsumerId int references ResourceConsumer(ResourceConsumerId) not null,
Assignedby int references ResourceConsumer(ResourceConsumerId) not null,
AssignedOn datetime not null,
);
create table Privilege
(
PrivilegeId int identity(1,1) primary key(PrivilegeId),
Name varchar(10) unique(Name) not null,
Description varchar(32),
);


create table PersonResources
( 
PersonResourcesId int identity(1,1) primary key(PersonResourcesId),
ResourcesId uniqueidentifier references Resources(ResourceId) not null,
PersonId int references ResourceConsumer(ResourceConsumerId) not null,
PrivilegesGivenBy int references ResourceConsumer(ResourceConsumerId) not null,
PrivilegeId int references Privilege(PrivilegeId),
DateCreated datetime not null,
DateValidTill datetime,
);

create table GroupResources
(
GroupResourcesId int identity(1,1) primary key(GroupResourcesId),
ResourcesId uniqueidentifier references Resources(ResourceId) not null,
GroupId int references UserGroup(UserGroupId) not null,
PrivilegesGivenBy int references ResourceConsumer(ResourceConsumerId) not null,
PrivilegeId int references Privilege(PrivilegeId),
DateCreated datetime not null,
DateValidTill datetime, 
);

 
create table PriviledgeRequest
(
PriviledgeRequestId int identity(1,1) primary key(PriviledgeRequestId),
PriviledgeRequesterId int references ResourceConsumer(ResourceConsumerId) not null,
ResourceId uniqueidentifier references Resources(ResourceId) not null,
AuthorizedBy int references  ResourceConsumer(ResourceConsumerId),
DateRequested datetime not null,
Priviledge varchar(16),

);

create table DataRequest
(
DataRequestId int identity(1,1) primary key(DataRequestId),
ResourceId uniqueidentifier references Resources(ResourceId),
RequesterId int references ResourceConsumer(ResourceConsumerId),
DateRequested datetime not null,
Priviledge varchar(16),
IsAnonymous bit,
IsGranted bit,
);