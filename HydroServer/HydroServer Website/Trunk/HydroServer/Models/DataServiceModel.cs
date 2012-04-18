using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hydroserver.Models
{
    public class DataServiceModel
    {
        /// <summary>
        /// Gets or sets the regions.
        /// </summary>
        /// <value>The regions.</value>
        public List<Region> Regions { get; set; }
        /// <summary>
        /// Gets or sets the ODM databases.
        /// </summary>
        /// <value>The ODM databases.</value>
        public List<ODMDatabase> ODMDatabases { get; set; }
        /// <summary>
        /// Gets or sets the map services.
        /// </summary>
        /// <value>The map services.</value>
        public List<MapService> MapServices { get; set; }

        /// <summary>
        /// Produces a string HTML summary of the information in a Contact object.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns></returns>
        public static string ContactSummary(Contact contact)
        {
            if (contact != null)
            {
                return "<a href='mailto:" + contact.EmailAddress + "'>" + contact.LastName + ", " + contact.FirstName + "</a><br />" +
                    contact.OrganizationName + "<br />" +
                    contact.MailingAddress + "<br />" + contact.City + ", " + contact.Area + " " + contact.PostalCode +
                    "<br />Phone: " + contact.PhoneNumber + "<br />" +
                    "Fax: " + contact.FaxNumber
                    ;
            }
            else 
                return string.Empty;

        }
    }
}
