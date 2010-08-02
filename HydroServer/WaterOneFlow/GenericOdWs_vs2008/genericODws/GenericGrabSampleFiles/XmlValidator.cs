using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Text;

namespace GenericGrabSampleFiles
{

    public class XMLValidator
    {
        // Validation Error Count
        static int ErrorsCount = 0;

        // Validation Error Message
        static string ErrorMessage = "";

        public static void ValidationHandler(object sender,
                                             ValidationEventArgs args)
        {
            ErrorMessage = ErrorMessage + args.Message + "\r\n";
            ErrorsCount++;
        }

        public void Validate(Stream XMLDoc)
        {
            try
            {
                // Declare local objects
                XmlReader tr = null;
                XmlSchemaSet xsc = null;
                

                // Text reader object
                
                xsc = new XmlSchemaSet();
                xsc.Add("http://www.cuahsi.org/waterML/1.1/", "cuahsiTimeSeries_v1_1.xsd");
                xsc.Add("http://www.cuahsi.org/waterML/1.0/", "cuahsiTimeSeries_v1_0.xsd");

                // XML validator object

                // Set the validation settings.
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = xsc;

                // Add validation event handler

                settings.ValidationType = ValidationType.Schema;
                settings.ValidationEventHandler +=
                         new ValidationEventHandler(ValidationHandler);

                // Validate XML data
                tr = XmlReader.Create(XMLDoc, settings);

                while (tr.Read()) ;

                tr.Close();

                // Raise exception, if XML validation fails
                if (ErrorsCount > 0)
                {
                    throw new Exception(ErrorMessage);
                }

                // XML Validation succeeded
                Console.WriteLine("XML validation succeeded.\r\n");
            }
            catch (Exception error)
            {
                // XML Validation failed
                Console.WriteLine("XML validation failed." + "\r\n" +
                "Error Message: " + error.Message);
            }
        }
    }
}
