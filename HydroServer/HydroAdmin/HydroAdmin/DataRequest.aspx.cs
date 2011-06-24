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
    public partial class DataRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataRequestGridLoad();
            }
        }

        private void DataRequestGridLoad()
        {
            DBLayer.DataRequest requestObj = new DBLayer.DataRequest();
            DataTable dt = new DataTable();
            dt = requestObj.GetAllDataRequest();
            DataRequestGrid.DataSource = dt;
            DataRequestGrid.DataBind();
        }

        protected void DataRequestGrid_DataBound(object sender, EventArgs e)
        {
            if (DataRequestGrid.Rows.Count > 0)
            {

                GridViewRow headerRow = DataRequestGrid.HeaderRow;
                headerRow.Cells[3].Visible = false;
                headerRow.Cells[4].Visible = false;
                headerRow.Cells[5].Visible = false;
                headerRow.Cells[6].Visible = false;
                headerRow.Cells[8].Visible = false;
                headerRow.Cells[9].Visible = false;
                foreach (GridViewRow row in DataRequestGrid.Rows)
                {

                    HyperLink odmLink = (HyperLink)row.FindControl("odmInfoLink");
                    odmLink.Text = row.Cells[3].Text.ToString();
                    odmLink.NavigateUrl = "#";
                    odmLink.Attributes.Add("onclick", "window.open('TimeSeriesInformation.aspx?tm=" + row.Cells[3].Text + "',null,'height=600, width=500,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no');");
                    HyperLink userLink = (HyperLink)row.FindControl("requesterInfoLink");
                    userLink.Text = row.Cells[4].Text.ToString();
                    userLink.NavigateUrl = "#";
                    userLink.Attributes.Add("onclick", "window.open('UserQuickInfo.aspx?user=" + row.Cells[4].Text + "',null,'height=250, width=350,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no');");
                    row.Cells[3].Visible = false;
                    row.Cells[4].Visible = false;
                    row.Cells[5].Visible = false;
                    row.Cells[6].Visible = false;
                    row.Cells[8].Visible = false;
                    row.Cells[9].Visible = false;
                }
            }
            
            
        }

        protected void grantButton_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in DataRequestGrid.Rows)
            {
                CheckBox groupCheckBox = (CheckBox)row.FindControl("selectGroup");
                if (groupCheckBox.Checked)
                {
                    AccessControl accessObj = new AccessControl();
                    accessObj.SetUserAccess(row.Cells[3].Text.ToString(), Convert.ToInt16(row.Cells[5].Text), Convert.ToInt16(row.Cells[8].Text));
                    DBLayer.DataRequest dataRequestObj = new DBLayer.DataRequest();
                    dataRequestObj.ReleaseDataRequestRow(Convert.ToInt16(row.Cells[9].Text));
                    DataRequestGridLoad();
                }
            }
        }

        protected void DataRequestGrid_PreRender(object sender, EventArgs e)
        {
            DataRequestGrid.Style["border-collapse"] = "seperate";
        }

        
        
    }
}
