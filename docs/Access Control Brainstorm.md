Separate the Authorization from Authentication
# Project 1: Add Roles to be used for Authorization to access data
We will need this, no matter what system we choose.
* adding auth database in front of (one or more ODM datasources)
	* What Series have access control (from which source)
	* we know who you are (trust project 2)
		* can does user have the role that allows them to  access data
		* what data have you access
	*  UI to manage applying roles to data series

# Project 1.1
* update generic web services to accommodate authorization service

# Project 2: Look at Authorization Service
* Who you are
* What solutions are out there: Federated/central
	* cloud based
* What is needed to integrate with Authorization System (project 1)

Requirements:
* It needs to be a service that a small user community can install and manage

OAuth 2:
* [Oauth2 wiki](http://wiki.oauth.net/OAuth-2)
* [Facebook](http://developers.facebook.com/docs/authentication/)

Simple Web Token:
* [Azure obtaining simple web tokens](http://jasonfollas.com/blog/archive/2010/03/22/windows-azure-platform-appfabric-access-control-obtaining-tokens.aspx)
* [WCF with simple web token](http://www.leastprivilege.com/IntegratingSimpleWebTokensSWTWithWCFRESTServicesUsingWIF.aspx)
* [developmentor wcf/swt](-http___browse.develop.com_token_wcf_)

Azure Appfabric Access Control (also Windows Server AppFabic)
* [MS Page for Appfabric](http://msdn.microsoft.com/en-us/windowsserver/ee695849.aspx)
* [Samples in Azre Labs](http://acs.codeplex.com/)
* [Federated Auth Samples from Michèle Leroux Bustamante](http://www.dasblonde.net/2010/06/21/NDCNdashOsloNorwayNdashSessionCodeAndResources.aspx)
* [Blog on AppFabic Server and Azure](http://www.hanselman.com/blog/WindowsServerAndAzureAppFabricVirtualLaunchMay20th.aspx)
* [Webcast Introducing Windows Azure AppFabric Access Control Service (ACS)  Labs Release](http://www.ditii.com/2010/08/06/webcast-introducing-windows-azure-appfabric-access-control-service-acs-features-of-august-2010-labs-release/)
* [http://www.dasblonde.net/2010/04/19/DevConnectionsVSLaunchApril2010NdashCode.aspx](http://www.dasblonde.net/2010/04/19/DevConnectionsVSLaunchApril2010NdashCode.aspx)

WIndows Identity Foundation:
* [WCF, WIF and Odata](http://www.leastprivilege.com/ThinktectureIdentityModelWIFSupportForWCFRESTServicesAndOData.aspx)
