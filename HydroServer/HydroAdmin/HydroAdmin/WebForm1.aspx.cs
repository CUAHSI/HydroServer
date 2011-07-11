using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Data;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace HydroAdmin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {

            TimeSeriesResources tm = new TimeSeriesResources();
            DataTable dt = new DataTable();
            dt = tm.GetTimeSeriesResources("MudLakeODM");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // Get reference to button field in the gridview.  
                    LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                    string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "Select$" + e.Row.RowIndex);
                    e.Row.Style["cursor"] = "hand";
                    e.Row.Attributes["onclick"] = _jsSingle;
                }
            }  
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridView1.SelectedRow;
            TextBox1.Text = selectedRow.Cells[3].Text;
            selectedRow.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.LightBlue);

            
        }
    }
}
