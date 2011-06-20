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
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = "Sitecode";
            cell.Width = 150;
            cell.BorderStyle = BorderStyle.Solid;
            cell.BorderWidth = 1;
            cell.BackColor = System.Drawing.Color.Blue;
            cell.HorizontalAlign = HorizontalAlign.Center;
            TableCell cell1 = new TableCell();
            cell1.Text = "SiteName";
            cell1.Width = 150;
            cell1.BorderStyle = BorderStyle.Solid;
            cell1.BorderWidth = 1;
            cell1.HorizontalAlign = HorizontalAlign.Center;
            TableCell cell2 = new TableCell();
            cell2.Text = "VariableCode";
            cell2.Width = 150;
            cell2.BorderStyle = BorderStyle.Solid;
            cell2.BorderWidth = 1;
            cell2.HorizontalAlign = HorizontalAlign.Center;
            TableCell cell3 = new TableCell();
            cell3.Text = "VariableName";
            cell3.Width = 150;
            cell3.BorderStyle = BorderStyle.Solid;
            cell3.BorderWidth = 1;
            cell3.HorizontalAlign = HorizontalAlign.Center;
            row.Cells.Add(cell);
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            Table1.Rows.Add(row);
            TableRow row1 = new TableRow();
            TableCell cell4 = new TableCell();
            TextBox tb = new TextBox();
            tb.ID = "sitecodetextbox";
            tb.Height = 50;
            tb.Width = 150;
            tb.TextMode = TextBoxMode.MultiLine;
            cell4.Controls.Add(tb);
            cell4.Width = 150;
            cell4.Height = 50;
            cell4.BorderWidth = 1;
            cell4.BorderStyle = BorderStyle.Solid;
            row1.Cells.Add(cell4);
            Table1.Rows.Add(row1);

        }
    }
}
