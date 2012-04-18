using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System;

namespace POC.MVC.PluginHost
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.RewritePath(Request.ApplicationPath);
            IHttpHandler httpHandler = new MvcHttpHandler();
            httpHandler.ProcessRequest(HttpContext.Current);
        }
    }
}
