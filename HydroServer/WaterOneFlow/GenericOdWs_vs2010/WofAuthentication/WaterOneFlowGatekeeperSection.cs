using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace WaterOneFlow.Services.Gatekeeper
{
    // Inherit from "ConfigurationSection"... simple enough!
    public class WaterOneFlowGatekeeperSection : ConfigurationSection
    {

        // I only want one property... LogFilePath, and I'm
        // here telling .NET to look for an attribute in the
        // config file called 'logFilePath' to get the value from.
        //[ConfigurationProperty("gatekeeperAssembely",
        //   DefaultValue = "WofAuthentication", IsRequired = true)]
        //public string GatekeeperAssembely
        //{
        //    get
        //    {
        //        return (string)base["gatekeeperAssembely"];
        //    }

        //    set
        //    {
        //        base["gatekeeperAssembely"] = value;
        //    }
        //}

        //[ConfigurationProperty("gatekeeperClass",
        //   DefaultValue = "AlwaysTrueGatekeeper",
        //    IsRequired = true)]
        //public string GatekeeperClass
        //{
        //    get
        //    {
        //        return (string)base["gatekeeperClass"];
        //    }

        //    set
        //    {
        //        base["gatekeeperClass"] = value;
        //    }
        //}


        [ConfigurationProperty("gatekeeper")]
        public GatekeeperClassConfigElement GatekeeperClassSection
        {
            get
            { return (GatekeeperClassConfigElement)this["gatekeeper"]; }
            set
            { this["gatekeeper"] = value; }


        }


        [ConfigurationProperty("gatekeeperProperties")]
        public GatekeeperPropertiesCollection GatekeeperPropertiesSection
        {
            get
            { return (GatekeeperPropertiesCollection)this["gatekeeperProperties"]; }
            set
            { this["gatekeeperProperties"] = value; }
        }
    }

 
    public class GatekeeperClassConfigElement : ConfigurationElement
    {
        public GatekeeperClassConfigElement()
        {
           
        }

        public GatekeeperClassConfigElement(String gatekeeperClass, 
            String gatekeeperAssembely)
        {
            GatekeeperClass = gatekeeperClass;
            GatekeeperAssembely = gatekeeperAssembely;
        }

        [ConfigurationProperty("Class",
     IsRequired = true,
     IsKey = true)]
        public string GatekeeperClass
        {
            get
            {
                return (string)this["Class"];
            }
            set
            {
                this["Class"] = value;
            }
        }

        [ConfigurationProperty("Assembely",
IsRequired = true)]
        public string GatekeeperAssembely
        {
            get
            {
                return (string)this["Assembely"];
            }
            set
            {
                this["Assembely"] = value;
            }
        }
    }

    public class GatekeeperPropertiesCollection : ConfigurationElementCollection
    {
        public GatekeeperPropertiesCollection()
        {

        }
        //see http://msdn.microsoft.com/en-us/library/2tw134k3.aspx

        public override
           ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return
                    ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new GateKeeperPropertiesConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((GateKeeperPropertiesConfigElement)element).property;
        }
    }

    /// <summary>
    /// basically all we want is a key value pair for a set of properties
    /// </summary>
    public class GateKeeperPropertiesConfigElement : ConfigurationElement
    {


        public GateKeeperPropertiesConfigElement(String newClassName,
            String newAssembeley)
        {
            property = newClassName;
            value = newAssembeley;

        }

        public GateKeeperPropertiesConfigElement()
        {

        }

        public GateKeeperPropertiesConfigElement(string elementName)
        {
            property = elementName;
        }

        /// <summary>
        ///  
        /// </summary>
        [ConfigurationProperty("property",
            DefaultValue = "state",
            IsRequired = true,
            IsKey = true)]
        public string property
        {
            get
            {
                return (string)this["property"];
            }
            set
            {
                this["property"] = value;
            }
        }

        [ConfigurationProperty("value",
            DefaultValue = "true",
            IsRequired = true)]
        // [RegexStringValidator(@"\w+:\/\/[\w.]+\S*")]
        public string value
        {
            get
            {
                return (string)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }


    }
}

