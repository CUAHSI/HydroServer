using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Data;
using System.Collections;

namespace HydroAdmin
{
    public partial class CustomDOI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            resourceInfoDisplayGrid.Width = 6000;
            if (!IsPostBack)
            {
                string odmName = Request.QueryString["odmname"];
                ODM odmObj = new ODM();
                DataTable dt = new DataTable();
                dt = odmObj.GetUploadODMInfo(odmName);
                resourceInfoDisplayGrid.DataSource = dt;
                resourceInfoDisplayGrid.DataBind();
            }
        }

        protected void resourceInfoDisplayGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[20].Width = 300;
            e.Row.Cells[23].Width = 450;
        }

        protected void resourceInfoDisplayGrid_PreRender(object sender, EventArgs e)
        {
            resourceInfoDisplayGrid.Style["border-collapse"] = "seperate";
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }
    }
}
