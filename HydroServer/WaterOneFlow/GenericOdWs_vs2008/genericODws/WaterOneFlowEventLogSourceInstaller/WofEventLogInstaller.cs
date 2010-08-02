using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Configuration.Install;

namespace WaterOneFlowEventLogSourceInstaller
{
    
    [RunInstaller(true)]
    public class WofEventLogInstaller : Installer
    {
        private EventLogInstaller wofEventLogInstaller;

        public WofEventLogInstaller()
        {
            //Create Instance of EventLogInstaller
            wofEventLogInstaller = new EventLogInstaller();

            // Set the Source of Event Log, to be created.
            wofEventLogInstaller.Source = "WaterOneFlow";

            // Set the Log that source is created in
            wofEventLogInstaller.Log = "Application";

            
            // Add myEventLogInstaller to the Installers Collection.
            Installers.Add(wofEventLogInstaller);
        }
    }
}
