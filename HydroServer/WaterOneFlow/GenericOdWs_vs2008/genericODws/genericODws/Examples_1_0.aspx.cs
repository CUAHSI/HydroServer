using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Examples_1_0 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          Examples examples = new Examples();

        examples.ConnectionString = ConfigurationManager.ConnectionStrings["ODDB"].ConnectionString;
        examples.NetworkCode = ConfigurationManager.AppSettings["network"];
        examples.VocabularyCode = ConfigurationManager.AppSettings["vocabulary"];

        List<String> sites = examples.GetSites();
        GetSites.DataSource = sites;
        GetSites.DataBind();

        List<String> siteInfos = examples.GetSiteInfo();
        GetSiteInfo.DataSource = siteInfos;
        GetSiteInfo.DataBind();

        GetVariableInfo.DataSource = examples.GetVariableSimple();
        GetVariableInfo.DataBind();

        GetVariableInfoDetailed.DataSource = examples.GetVariableDetailed();
        GetVariableInfoDetailed.DataBind();

    }

}
