use HydroSecure;

create table TimeSeriesResources
(
 TimeSeriesResourcesId uniqueidentifier primary key(TimeSeriesResourcesId),
 VariableCode varchar(64),
 SiteCode varchar(64),
 MethodId int,
 SourceId int,
 QualityControlLevelId int,
 
)

create table ResourceType
(
ResourceTypeId int identity(1,1) primary key(ResourceTypeId),
Name varchar(10) unique(Name) not null,
description varchar(32),
);

create table Resources
(
ResourceId uniqueidentifier primary key(ResourceId) references TimeSeriesResources(TimeSeriesResourcesId),
ResourceType int references ResourceType(ResourceTypeId) not null,
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