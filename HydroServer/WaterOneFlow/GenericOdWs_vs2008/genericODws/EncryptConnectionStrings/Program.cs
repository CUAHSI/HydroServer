using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web.Configuration;

namespace EncryptConnectionStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("cryptWebConfig filename ");
                Console.ReadKey();
                return;
            }
            string filename = System.AppDomain.CurrentDomain.BaseDirectory  + args[0];
            ConfigurationFileMap filemap = new ConfigurationFileMap(filename);
           // System.Configuration.Configuration webConf = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(filename);
            System.Configuration.Configuration webConf = System.Configuration.ConfigurationManager.OpenExeConfiguration(filename);
            AppSettingsSection appSettings = webConf.AppSettings;

            ConnectionStringsSection connStrings = webConf.ConnectionStrings;
            if (connStrings.SectionInformation.IsProtected)
            {

                Console.WriteLine("Decrypting Section ");
                connStrings.SectionInformation.UnprotectSection();
                webConf.Save();
            }
            else
            {
                Console.WriteLine("Encyprting Section ");
                webConf.ConnectionStrings.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                webConf.Save();
            }

        }
    }
}
