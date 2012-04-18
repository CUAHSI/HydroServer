using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HydroServer.Framework
{
    public class DownloadResult : ActionResult
    {

        public DownloadResult()
        {
        }

        public DownloadResult(StringWriter content)
        {
            this.Content = content;
        }

        public StringWriter Content
        {
            get;
            set;
        }

        public override void ExecuteResult(ControllerContext context) 
        {
 
        }
    }
}
