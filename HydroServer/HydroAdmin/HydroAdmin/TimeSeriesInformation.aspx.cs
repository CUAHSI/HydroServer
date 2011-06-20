using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Data;

namespace HydroAdmin
{
    public partial class TimeSeriesInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string timeSeriesId = Request.QueryString["tm"];
            TimeSeriesResources tm = new TimeSeriesResources();
            DataTable dt = new DataTable();
            dt = tm.GetTimeSeriesInfo(timeSeriesId);
            timeSeriesInfoView.DataSource = dt;
            timeSeriesInfoView.DataBind();
        }
    }
}
