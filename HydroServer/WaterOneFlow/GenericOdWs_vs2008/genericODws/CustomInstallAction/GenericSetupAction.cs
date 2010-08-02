using System;
using System.Configuration;
using System.Configuration.Install;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO;
using System.Web.Configuration;

/*
 * This in installed in GenericWSSetup.
 * There is an interface
 * There is a custom action that includes
 * 
 * If you change something in the interface 
 * (eg a field name) then change the custom action command line
 * 
 * and to debug put a 
 * Debugger.Break();
 * 
 */
namespace MyCustomAction
{
    [RunInstaller(true)]
    public class GenericSetupAction : Installer
    {
      public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);

            // Retrieve configuration settings
            string targetSite = Context.Parameters["targetsite"];
            string targetVDir = Context.Parameters["targetvdir"];
            string targetDirectory = Context.Parameters["targetdir"];
            string connectionString = Context.Parameters["connectionstring"];
            string network = Context.Parameters["odnetwork"];
            string vocabulary = Context.Parameters["odvocabulary"];

            if (targetSite == null)
                throw new InstallException("IIS Site Name Not Specified!");

            if (targetSite.StartsWith("/LM/"))
                targetSite = targetSite.Substring(4);

            RegisterScriptMaps(targetSite, targetVDir);
           //Debugger.Break();    
            ConfigureODProperties(targetSite, targetVDir, network, vocabulary, connectionString);
        }

        void RegisterScriptMaps(string targetSite, string targetVDir)
        {
           // Calculate Windows path
            string sysRoot = System.Environment.GetEnvironmentVariable("SystemRoot");

            // Launch aspnet_regiis.exe utility to configure mappings
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = Path.Combine(sysRoot, @"Microsoft.NET\Framework\v2.0.50727\aspnet_regiis.exe");
            info.Arguments = string.Format("-s {0}/ROOT/{1}", targetSite, targetVDir);
            info.CreateNoWindow = true;
            info.UseShellExecute = false;

            Process.Start(info);
        }

  
        void ConfigureODProperties(string targetSite, string targetVDir, string network, string vocabulary, string connectionString)
        {
            // Retrieve "Friendly Site Name" from IIS for TargetSite
            DirectoryEntry entry = new DirectoryEntry("IIS://LocalHost/" + targetSite);
            string friendlySiteName = entry.Properties["ServerComment"].Value.ToString();

            // Open Application's Web.Config
            Configuration config = WebConfigurationManager.OpenWebConfiguration("/" + targetVDir, friendlySiteName);
            // Add new connection string setting for web.config
            AppSettingsSection apps = config.AppSettings;

               apps.Settings["network"].Value = network;
            apps.Settings["vocabulary"].Value = vocabulary;

            config.ConnectionStrings.ConnectionStrings.Clear();// Add new connection string setting for web.config
            ConnectionStringSettings appDatabase = new ConnectionStringSettings();
            appDatabase.Name = "ODDB";
            appDatabase.ConnectionString = connectionString;
            appDatabase.ProviderName = "System.Data.SqlClient";


            
            config.ConnectionStrings.ConnectionStrings.Add(appDatabase);

            // Persist web.config settings
            config.Save();
        }
    }
}