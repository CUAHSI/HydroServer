using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Configure : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
 
 
        if (!Page.IsPostBack ) fillFields() ;
  

    }

    private void fillFields()
    {
        System.Configuration.Configuration webConf = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
        AppSettingsSection appSettings = webConf.AppSettings;

        ConnectionStringsSection connStrings = webConf.ConnectionStrings;
        if (connStrings.SectionInformation.IsProtected)  connStrings.SectionInformation.UnprotectSection();

        txt_Network.Text = appSettings.Settings["network"].Value;
        txt_Vocabulary.Text = appSettings.Settings["vocabulary"].Value;
        txt_serviceExampleHTMLPage.Text = appSettings.Settings["serviceDescriptionPage"].Value;
        txtSeriesName.Text = appSettings.Settings["GetValuesName"].Value;
        txtContactEmail.Text = appSettings.Settings["contactEmail"].Value;
        string encryptString = appSettings.Settings["EncryptConnectionString"].Value;
        Boolean encrypt;
        try
       {
           encrypt = Boolean.Parse(encryptString);
       } catch
       {
           encrypt = false;
       }
        cb_encryptConnectionString.Checked = encrypt;
        txt_odmconnectionString.Text = connStrings.ConnectionStrings["ODDB"].ConnectionString;

    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        fillFields();
    }
    protected void btn_ok_Click(object sender, EventArgs e)
    {
        System.Configuration.Configuration webConf = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
        AppSettingsSection appSettings = webConf.AppSettings;
    
        ConnectionStringsSection connStrings = webConf.ConnectionStrings;

        appSettings.Settings["network"].Value =txt_Network.Text;
        appSettings.Settings["vocabulary"].Value=txt_Vocabulary.Text ;
        appSettings.Settings["serviceDescriptionPage"].Value = txt_serviceExampleHTMLPage.Text;
         appSettings.Settings["GetValuesName"].Value=txtSeriesName.Text ;
        appSettings.Settings["contactEmail"].Value = txtContactEmail.Text;
        ConnectionStringSettings oddb = connStrings.ConnectionStrings["ODDB"];
        oddb.ConnectionString = txt_odmconnectionString.Text;
        if (cb_encryptConnectionString.Checked)
        {
            appSettings.Settings["EncryptConnectionString"].Value = Boolean.TrueString;
               connStrings.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
        } else
        {
           appSettings.Settings["EncryptConnectionString"].Value = false.ToString();
            connStrings.SectionInformation.UnprotectSection();
        }
        // should trap an error, and test
        try
        {
            lbl_error.Text = "";
        webConf.Save(ConfigurationSaveMode.Modified );
            } catch
            {
                lbl_error.Text =
                    "Cannot write configuration file. Be sure web.config,  release_connectionstrings.config, and release_appsettings.config are writeable by aspnet, and IIS_wpg";
            }
    }
}
