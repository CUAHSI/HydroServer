using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using WaterOneFlow.Schema.v1_1;
using WaterOneFlowImpl;

using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Addressing;
using Microsoft.Web.Services3.Messaging;

/* In order to keep the "Contract" Clean. Descriptions are found the WsDescriptions Class.
 * This is a set of constants.
 * The Namespace is presently held in the Constants.
 * The used of a constant makes mainataing multiple services simpler. Any changes asked for b
 * by the community can be easily propagated to the services.
 * valentine aug 2006
 */
namespace WaterOneFlow
{
    using ConstantsNs = WaterOneFlowImpl.v1_1.Constants;
namespace v1_1 {

    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1,
        Name = WsDescriptions.WsDefaultName,
   Namespace = ConstantsNs.WS_NAMSPACE)]
    interface IService
    {
        [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc )]
        string GetSites(string[] site, String authToken);

        [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
        string GetSiteInfo(string site, String authToken);

        [WebMethod(Description =  WsDescriptions.GetVariableInfoDefaultDesc)]
        string GetVariableInfo(string variable, String authToken);


        [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc )]
        string GetValues(string location, string variable, string startDate, string endDate, String authToken);

        [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
        SiteInfoResponseType GetSitesObject(string[] site, String authToken);

        [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
        SiteInfoResponseType GetSiteInfoObject(string site, String authToken);

        [SoapDocumentMethod(
      ResponseNamespace = ConstantsNs.XML_SCHEMA_NAMSPACE,
       ResponseElementName = "VariablesResponse")]
        [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
        VariablesResponseType GetVariableInfoObject(string variable, String authToken);

        [SoapDocumentMethod(
       ResponseNamespace = ConstantsNs.XML_SCHEMA_NAMSPACE,
       ResponseElementName = "TimeSeriesResponse")]  
        [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
        TimeSeriesResponseType GetValuesObject(string location, string variable, string startDate, string endDate, String authToken);

        // 1.1 methods
       
        [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
        SiteInfoResponseType GetSiteInfoMultpleObject(string[] site,  String authToken);
        
        [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
        SiteInfoResponseType GetSitesByBoxObject(float west, float south, float east, float north, Boolean IncludeSeries, String authToken);

        [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
        TimeSeriesResponseType GetValuesForASiteObject(string site, string startDate, string endDate, String authToken);

        [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
        VariablesResponseType GetVariablesObject(String authToken);

        [WebMethod(Description = WsDescriptions.GetVariableInfoDefaultDesc)]
        string GetVariables(String authToken);

        //[WebMethod(Description = "Capabilites")]
        //XmlDocument GetCapabilities();

        // This will be expensive to implement on the present codebase. 
        // Leaving to later
        //[WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
        //TimeSeriesResponseType GetValuesInBoxObject(string variable, string startDate, string endDate, float west, float south, float east, float north,  String authToken);

    }
    }
}