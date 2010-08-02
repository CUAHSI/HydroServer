using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    private String networkName;
    private String vocabularyName;
    private String wsdlLocation;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string remoteIP = Request.ServerVariables["remote_addr"];
        string allowedIP = System.Configuration.ConfigurationSettings.AppSettings["AdminIPAddress"];

        if (remoteIP != allowedIP)
        {
            LocalConfiguration.Visible = false;
        } 

        PageTitle.Text = ConfigurationManager.AppSettings["network"] + " Web Service";
        Page.Title = PageTitle.Text;
      

        // use UriBuilder to make a valid URL
        UriBuilder wsdl = new UriBuilder();
        wsdl.Scheme = Request.Url.Scheme;
        wsdl.Host = Request.Url.DnsSafeHost;
        /* UriBuilder is not aware of standard ports
         * if a port is added, then it will display           
         * Co-PI say port :80 is not needed. 
         * so below handles standard port cases
         */
        if (Request.Url.Scheme =="http") {
            if ( !(Request.Url.Port==80) ) wsdl.Port = Request.Url.Port;
        }
        else if (Request.Url.Scheme == "https")
        {
           if ( !(Request.Url.Port == 443)) wsdl.Port = Request.Url.Port;
        } else
        {
            wsdl.Port = Request.Url.Port;
        }

        serviceLocation.NavigateUrl = "~/" + ConfigurationManager.AppSettings["asmxPage"]; 
       wsdl.Path = serviceLocation.ResolveUrl(ConfigurationManager.AppSettings["asmxPage"]) ;
         serviceLocation.Text = wsdl.ToString();

 serviceLocation_1_1.NavigateUrl = "~/" + ConfigurationManager.AppSettings["asmxPage_1_1"]; 
        wsdl.Path = serviceLocation.ResolveUrl( serviceLocation_1_1.NavigateUrl);
        serviceLocation_1_1.Text = wsdl.ToString();

      Boolean OdGetValues = Boolean.Parse(ConfigurationManager.AppSettings["UseODForValues"]);
        if (!OdGetValues)
      {
          //HyperLinkGetValuesObject.Enabled = false;
          //HyperLinkGetValuesObject.Text = HyperLinkGetValuesObject.Text + " External or not implemented";
          //HyperLinkGetValues.Enabled = false;
          //HyperLinkGetValues.Text = HyperLinkGetValues.Text + " External or not implemented";
      }
        wsversion.Text = String.Format("Compile Date (UTC) {0}", AssemblyVersion);
        
    }

    public static string AssemblyVersion
    {
        get
        {
            //return File.GetCreationTimeUtc( Assembly.GetExecutingAssembly().Location).ToString();
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
