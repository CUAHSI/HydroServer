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
    public partial class _Default : System.Web.UI.Page
    {
        public DataTable timeSeriesTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            odmInfoGridView.Width = 6000;
            if (!IsPostBack)
            {
                ODMDatabaseListLoad();
            }
        }

        private void ODMDatabaseListLoad()
        {
            odmList.Items.Clear();
            List<string> odmDBList = new List<string>();
            TimeSeriesResources tmObj = new TimeSeriesResources();
            odmDBList = tmObj.GetODMList();
            foreach (string s in odmDBList)
            {
                odmList.Items.Add(s);
            }

            odmList.SelectedValue = odmList.Items[odmList.Items.Count - 1].ToString();

            siteCodeDropDownList.Items.Clear();
            variableCodeDropDownList.Items.Clear();

            ODM odmInfo = new ODM();
            DataTable dt = new DataTable();
            dt = odmInfo.GetODMInfo(odmList.Items[odmList.Items.Count - 1].ToString());
            foreach (DataRow row in dt.Rows)
            {
                Title.Text = row["title"].ToString();
                serverName.Text = row["serveraddress"].ToString();
                Topic.Text = row["topiccategory"].ToString();
                abstractODM.Text = row["abstract"].ToString();
                citation.Text = row["citation"].ToString();
            }
            TimeSeriesResources tmResObj = new TimeSeriesResources();
            timeSeriesTable = tmResObj.GetTimeSeriesResources(odmList.Items[odmList.Items.Count - 1].ToString());
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
            ViewState["mydata"] = timeSeriesTable;
            recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";

            List<string> siteCodeListObj = new List<string>();
            List<string> variableCodeListObj = new List<string>();
            foreach (DataRow row in timeSeriesTable.Rows)
            {
                siteCodeListObj.Add(row["sitecode"].ToString());
                variableCodeListObj.Add(row["variablecode"].ToString());
            }

            siteCodeDropDownList.DataSource = siteCodeListObj.Distinct().ToList();
            siteCodeDropDownList.DataBind();
            variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            variableCodeDropDownList.DataBind();
        }

        protected void odmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            siteCodeDropDownList.Items.Clear();
            variableCodeDropDownList.Items.Clear();

            ODM odmInfo = new ODM();
            DataTable dt = new DataTable();
            dt = odmInfo.GetODMInfo(odmList.SelectedValue.ToString());
            foreach (DataRow row in dt.Rows)
            {
                Title.Text = row["title"].ToString();
                serverName.Text = row["serveraddress"].ToString();
                Topic.Text = row["topiccategory"].ToString();
                abstractODM.Text = row["abstract"].ToString();
                citation.Text = row["citation"].ToString();
            }
            TimeSeriesResources tmResObj = new TimeSeriesResources();
            timeSeriesTable = tmResObj.GetTimeSeriesResources(odmList.SelectedValue.ToString());
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
            ViewState["mydata"] = timeSeriesTable;
            recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";

            List<string> siteCodeListObj = new List<string>();
            List<string> variableCodeListObj = new List<string>();
            foreach (DataRow row in timeSeriesTable.Rows)
            {
                siteCodeListObj.Add(row["sitecode"].ToString());
                variableCodeListObj.Add(row["variablecode"].ToString());
            }

            siteCodeDropDownList.DataSource = siteCodeListObj.Distinct().ToList();
            siteCodeDropDownList.DataBind();
            variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            variableCodeDropDownList.DataBind();

        }

        protected void addODM_Click(object sender, EventArgs e)
        {
            Response.Redirect("ODMUpload.aspx");
        }

        protected void siteCodeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeSeriesTable = (DataTable)ViewState["mydata"];
            ViewState["mydata"] = null;
            DataTable dt = timeSeriesTable;
            for(int i=0; i < timeSeriesTable.Rows.Count ; i++)
            {
                DataRow row = timeSeriesTable.Rows[i];
                string sel = row["sitecode"].ToString();
                if ( !sel.Equals(siteCodeDropDownList.SelectedValue.ToString()))
                {
                    timeSeriesTable.Rows[i].Delete();
                }
            }
            timeSeriesTable.AcceptChanges();
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
            ViewState["mydata"] = timeSeriesTable;

            List<string> siteCodeListObj = new List<string>();
            List<string> variableCodeListObj = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                siteCodeListObj.Add(row["sitecode"].ToString());
                variableCodeListObj.Add(row["variablecode"].ToString());
            }

            siteCodeDropDownList.DataSource = siteCodeListObj.Distinct().ToList();
            siteCodeDropDownList.DataBind();
            variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            variableCodeDropDownList.DataBind();
            recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";
            
        }

        protected void variableCodeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            timeSeriesTable = (DataTable)ViewState["mydata"];
            ViewState["mydata"] = null;
            DataTable dt = timeSeriesTable;
            for (int i = 0; i < timeSeriesTable.Rows.Count; i++)
            {
                DataRow row = timeSeriesTable.Rows[i];
                string sel = row["variablecode"].ToString();
                if (!sel.Equals(variableCodeDropDownList.SelectedValue.ToString()))
                {
                    timeSeriesTable.Rows[i].Delete();
                }
            }
            timeSeriesTable.AcceptChanges();
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
            ViewState["mydata"] = timeSeriesTable;

            List<string> siteCodeListObj = new List<string>();
            List<string> variableCodeListObj = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                siteCodeListObj.Add(row["sitecode"].ToString());
                variableCodeListObj.Add(row["variablecode"].ToString());
            }

            siteCodeDropDownList.DataSource = siteCodeListObj.Distinct().ToList();
            siteCodeDropDownList.DataBind();
            variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            variableCodeDropDownList.DataBind();
            recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";
        }

        protected void resetOdmInfoButton_Click(object sender, EventArgs e)
        {
            siteCodeDropDownList.Items.Clear();
            variableCodeDropDownList.Items.Clear();

            ODM odmInfo = new ODM();
            DataTable dt = new DataTable();
            dt = odmInfo.GetODMInfo(odmList.SelectedValue.ToString());
            foreach (DataRow row in dt.Rows)
            {
                Title.Text = row["title"].ToString();
                serverName.Text = row["serveraddress"].ToString();
                Topic.Text = row["topiccategory"].ToString();
                abstractODM.Text = row["abstract"].ToString();
                citation.Text = row["citation"].ToString();
            }
            TimeSeriesResources tmResObj = new TimeSeriesResources();
            timeSeriesTable = tmResObj.GetTimeSeriesResources(odmList.SelectedValue.ToString());
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
            ViewState["mydata"] = timeSeriesTable;
            recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";

            List<string> siteCodeListObj = new List<string>();
            List<string> variableCodeListObj = new List<string>();
            foreach (DataRow row in timeSeriesTable.Rows)
            {
                siteCodeListObj.Add(row["sitecode"].ToString());
                variableCodeListObj.Add(row["variablecode"].ToString());
            }

            siteCodeDropDownList.DataSource = siteCodeListObj.Distinct().ToList();
            siteCodeDropDownList.DataBind();
            variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            variableCodeDropDownList.DataBind();


        }

        protected void deleteODM_Click(object sender, EventArgs e)
        {
            TimeSeriesResources tmResObj = new TimeSeriesResources();
            tmResObj.DeleteTimeSeriesResources(odmList.SelectedValue.ToString());
            List<string> DBList = new List<string>();
            DBList = tmResObj.GetODMList();
            odmList.Items.Clear();
            foreach (string s in DBList)
            {
                odmList.Items.Add(s);
            }
            ODMDatabaseListLoad();
        }

        protected void odmInfoGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[6].Width = 300;
            e.Row.Cells[21].Width = 300;
            e.Row.Cells[23].Width = 300;
            e.Row.Cells[24].Width = 450;
            e.Row.Cells[25].Width = 450;

        }

        protected void odmInfoGridView_Load(object sender, EventArgs e)
        {
            
        }

        protected void odmInfoGridView_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow gridrow in odmInfoGridView.Rows)
            {
                HyperLink odmLink = (HyperLink)gridrow.FindControl("odmInfoLink");
                odmLink.NavigateUrl = "#";
                odmLink.Attributes.Add("onclick", "window.open('TimeSeriesInformation.aspx?tm=" + gridrow.Cells[2].Text + "',null,'height=600, width=500,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no');");
                Table Table1 = (Table)gridrow.FindControl("TimeSeriesInfoTable");
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = "Sitecode";
                cell.Width = 200;
                cell.BorderStyle = BorderStyle.Solid;
                cell.BorderWidth = 1;
                cell.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell1 = new TableCell();
                cell1.Text = "SiteName";
                cell1.Width = 200;
                cell1.BorderStyle = BorderStyle.Solid;
                cell1.BorderWidth = 1;
                cell1.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell2 = new TableCell();
                cell2.Text = "VariableCode";
                cell2.Width = 200;
                cell2.BorderStyle = BorderStyle.Solid;
                cell2.BorderWidth = 1;
                cell2.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell3 = new TableCell();
                cell3.Text = "VariableName";
                cell3.Width = 200;
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
                TextBox sitecodetext = new TextBox();
                sitecodetext.ID = "sitecodetextbox";
                sitecodetext.Height = 50;
                sitecodetext.Width = 200;
                sitecodetext.TextMode = TextBoxMode.MultiLine;
                cell4.Controls.Add(sitecodetext);
                cell4.Width = 200;
                cell4.Height = 50;
                cell4.BorderWidth = 1;
                cell4.BorderStyle = BorderStyle.Solid;
                row1.Cells.Add(cell4);

                TableCell cell5 = new TableCell();
                TextBox sitenametext = new TextBox();
                sitenametext.ID = "sitenametextbox";
                sitenametext.Height = 50;
                sitenametext.Width = 200;
                sitenametext.TextMode = TextBoxMode.MultiLine;
                cell5.Controls.Add(sitenametext);
                cell5.Width = 200;
                cell5.Height = 50;
                cell5.BorderWidth = 1;
                cell5.BorderStyle = BorderStyle.Solid;
                row1.Cells.Add(cell5);

                TableCell cell6 = new TableCell();
                TextBox variablecodetext = new TextBox();
                variablecodetext.ID = "variablecodetextbox";
                variablecodetext.Height = 50;
                variablecodetext.Width = 200;
                variablecodetext.TextMode = TextBoxMode.MultiLine;
                cell6.Controls.Add(variablecodetext);
                cell6.Width = 200;
                cell6.Height = 50;
                cell6.BorderWidth = 1;
                cell6.BorderStyle = BorderStyle.Solid;
                row1.Cells.Add(cell6);

                TableCell cell7 = new TableCell();
                TextBox variablenametext = new TextBox();
                variablenametext.ID = "variablenametextbox";
                variablenametext.Height = 50;
                variablenametext.Width = 200;
                variablenametext.TextMode = TextBoxMode.MultiLine;
                cell7.Controls.Add(variablenametext);
                cell7.Width = 200;
                cell7.Height = 50;
                cell7.BorderWidth = 1;
                cell7.BorderStyle = BorderStyle.Solid;
                row1.Cells.Add(cell7);

                Table1.Rows.Add(row1);

                TableRow row2 = new TableRow();
                TableCell cell8 = new TableCell();
                cell8.Text = "Speciation";
                cell8.Width = 200;
                cell8.BorderStyle = BorderStyle.Solid;
                cell8.BorderWidth = 1;
                cell8.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell9 = new TableCell();
                cell9.Text = "VariableUnitsName";
                cell9.Width = 200;
                cell9.BorderStyle = BorderStyle.Solid;
                cell9.BorderWidth = 1;
                cell9.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell10 = new TableCell();
                cell10.Text = "SampleMedium";
                cell10.Width = 200;
                cell10.BorderStyle = BorderStyle.Solid;
                cell10.BorderWidth = 1;
                cell10.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell11 = new TableCell();
                cell11.Text = "ValueType";
                cell11.Width = 200;
                cell11.BorderStyle = BorderStyle.Solid;
                cell11.BorderWidth = 1;
                cell11.HorizontalAlign = HorizontalAlign.Center;
                row2.Cells.Add(cell8);
                row2.Cells.Add(cell9);
                row2.Cells.Add(cell10);
                row2.Cells.Add(cell11);
                Table1.Rows.Add(row2);


                TableRow row3 = new TableRow();
                TableCell cell12 = new TableCell();
                TextBox speciationtext = new TextBox();
                speciationtext.ID = "speciationtextbox";
                speciationtext.Height = 50;
                speciationtext.Width = 200;
                speciationtext.TextMode = TextBoxMode.MultiLine;
                cell12.Controls.Add(speciationtext);
                cell12.Width = 200;
                cell12.Height = 50;
                cell12.BorderWidth = 1;
                cell12.BorderStyle = BorderStyle.Solid;
                row3.Cells.Add(cell12);

                TableCell cell13 = new TableCell();
                TextBox variableunitsnametext = new TextBox();
                variableunitsnametext.ID = "variableunitsnametextbox";
                variableunitsnametext.Height = 50;
                variableunitsnametext.Width = 200;
                variableunitsnametext.TextMode = TextBoxMode.MultiLine;
                cell13.Controls.Add(variableunitsnametext);
                cell13.Width = 200;
                cell13.Height = 50;
                cell13.BorderWidth = 1;
                cell13.BorderStyle = BorderStyle.Solid;
                row3.Cells.Add(cell13);

                TableCell cell16 = new TableCell();
                TextBox samplemediumtext = new TextBox();
                samplemediumtext.ID = "samplemediumtextbox";
                samplemediumtext.Height = 50;
                samplemediumtext.Width = 200;
                samplemediumtext.TextMode = TextBoxMode.MultiLine;
                cell16.Controls.Add(samplemediumtext);
                cell16.Width = 200;
                cell16.Height = 50;
                cell16.BorderWidth = 1;
                cell16.BorderStyle = BorderStyle.Solid;
                row3.Cells.Add(cell16);

                TableCell cell17 = new TableCell();
                TextBox valuetypetext = new TextBox();
                valuetypetext.ID = "valuetypetextbox";
                valuetypetext.Height = 50;
                valuetypetext.Width = 200;
                valuetypetext.TextMode = TextBoxMode.MultiLine;
                cell17.Controls.Add(valuetypetext);
                cell17.Width = 200;
                cell17.Height = 50;
                cell17.BorderWidth = 1;
                cell17.BorderStyle = BorderStyle.Solid;
                row3.Cells.Add(cell17);

                Table1.Rows.Add(row3);

                TableRow row4 = new TableRow();
                TableCell cell18 = new TableCell();
                cell18.Text = "TimeSupport";
                cell18.Width = 200;
                cell18.BorderStyle = BorderStyle.Solid;
                cell18.BorderWidth = 1;
                cell18.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell19 = new TableCell();
                cell19.Text = "TimeUnitsId";
                cell19.Width = 200;
                cell19.BorderStyle = BorderStyle.Solid;
                cell19.BorderWidth = 1;
                cell19.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell20 = new TableCell();
                cell20.Text = "TimeUnitsName";
                cell20.Width = 200;
                cell20.BorderStyle = BorderStyle.Solid;
                cell20.BorderWidth = 1;
                cell20.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell21 = new TableCell();
                cell21.Text = "DataType";
                cell21.Width = 200;
                cell21.BorderStyle = BorderStyle.Solid;
                cell21.BorderWidth = 1;
                cell21.HorizontalAlign = HorizontalAlign.Center;
                row4.Cells.Add(cell18);
                row4.Cells.Add(cell19);
                row4.Cells.Add(cell20);
                row4.Cells.Add(cell21);
                Table1.Rows.Add(row4);

                TableRow row5 = new TableRow();
                TableCell cell22 = new TableCell();
                TextBox timesupportext = new TextBox();
                timesupportext.ID = "timesupportextbox";
                timesupportext.Height = 50;
                timesupportext.Width = 200;
                timesupportext.TextMode = TextBoxMode.MultiLine;
                cell22.Controls.Add(timesupportext);
                cell22.Width = 200;
                cell22.Height = 50;
                cell22.BorderWidth = 1;
                cell22.BorderStyle = BorderStyle.Solid;
                row5.Cells.Add(cell22);

                TableCell cell23 = new TableCell();
                TextBox timeunitsidtext = new TextBox();
                timeunitsidtext.ID = "timeunitsidtextbox";
                timeunitsidtext.Height = 50;
                timeunitsidtext.Width = 200;
                timeunitsidtext.TextMode = TextBoxMode.MultiLine;
                cell23.Controls.Add(timeunitsidtext);
                cell23.Width = 200;
                cell23.Height = 50;
                cell23.BorderWidth = 1;
                cell23.BorderStyle = BorderStyle.Solid;
                row5.Cells.Add(cell23);

                TableCell cell24 = new TableCell();
                TextBox timeunitsnametext = new TextBox();
                timeunitsnametext.ID = "timeunitsnamebox";
                timeunitsnametext.Height = 50;
                timeunitsnametext.Width = 200;
                timeunitsnametext.TextMode = TextBoxMode.MultiLine;
                cell24.Controls.Add(timeunitsnametext);
                cell24.Width = 200;
                cell24.Height = 50;
                cell24.BorderWidth = 1;
                cell24.BorderStyle = BorderStyle.Solid;
                row5.Cells.Add(cell24);

                TableCell cell25 = new TableCell();
                TextBox datatypetext = new TextBox();
                datatypetext.ID = "datatypetextbox";
                datatypetext.Height = 50;
                datatypetext.Width = 200;
                datatypetext.TextMode = TextBoxMode.MultiLine;
                cell25.Controls.Add(datatypetext);
                cell25.Width = 200;
                cell25.Height = 50;
                cell25.BorderWidth = 1;
                cell25.BorderStyle = BorderStyle.Solid;
                row5.Cells.Add(cell25);

                Table1.Rows.Add(row5);

                TableRow row6 = new TableRow();
                TableCell cell26 = new TableCell();
                cell26.Text = "GeneralCategory";
                cell26.Width = 200;
                cell26.BorderStyle = BorderStyle.Solid;
                cell26.BorderWidth = 1;
                cell26.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell27 = new TableCell();
                cell27.Text = "MethodDescription";
                cell27.Width = 200;
                cell27.BorderStyle = BorderStyle.Solid;
                cell27.BorderWidth = 1;
                cell27.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell28 = new TableCell();
                cell28.Text = "Organization";
                cell28.Width = 200;
                cell28.BorderStyle = BorderStyle.Solid;
                cell28.BorderWidth = 1;
                cell28.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell29 = new TableCell();
                cell29.Text = "SourceDescription";
                cell29.Width = 200;
                cell29.BorderStyle = BorderStyle.Solid;
                cell29.BorderWidth = 1;
                cell29.HorizontalAlign = HorizontalAlign.Center;
                row6.Cells.Add(cell26);
                row6.Cells.Add(cell27);
                row6.Cells.Add(cell28);
                row6.Cells.Add(cell29);
                Table1.Rows.Add(row6);

                TableRow row7 = new TableRow();
                TableCell cell30 = new TableCell();
                TextBox generalcategorytext = new TextBox();
                generalcategorytext.ID = "generalcategorytextbox";
                generalcategorytext.Height = 50;
                generalcategorytext.Width = 200;
                generalcategorytext.TextMode = TextBoxMode.MultiLine;
                cell30.Controls.Add(generalcategorytext);
                cell30.Width = 200;
                cell30.Height = 50;
                cell30.BorderWidth = 1;
                cell30.BorderStyle = BorderStyle.Solid;
                row7.Cells.Add(cell30);

                TableCell cell31 = new TableCell();
                TextBox methoddescriptiontext = new TextBox();
                methoddescriptiontext.ID = "methoddescriptiontextbox";
                methoddescriptiontext.Height = 50;
                methoddescriptiontext.Width = 200;
                methoddescriptiontext.TextMode = TextBoxMode.MultiLine;
                cell31.Controls.Add(methoddescriptiontext);
                cell31.Width = 200;
                cell31.Height = 50;
                cell31.BorderWidth = 1;
                cell31.BorderStyle = BorderStyle.Solid;
                row7.Cells.Add(cell31);

                TableCell cell32 = new TableCell();
                TextBox organizationtext = new TextBox();
                organizationtext.ID = "organizationtextbox";
                organizationtext.Height = 50;
                organizationtext.Width = 200;
                organizationtext.TextMode = TextBoxMode.MultiLine;
                cell32.Controls.Add(organizationtext);
                cell32.Width = 200;
                cell32.Height = 50;
                cell32.BorderWidth = 1;
                cell32.BorderStyle = BorderStyle.Solid;
                row7.Cells.Add(cell32);

                TableCell cell33 = new TableCell();
                TextBox sourcedescriptiontext = new TextBox();
                sourcedescriptiontext.ID = "sourcedescriptionbox";
                sourcedescriptiontext.Height = 50;
                sourcedescriptiontext.Width = 200;
                sourcedescriptiontext.TextMode = TextBoxMode.MultiLine;
                cell33.Controls.Add(sourcedescriptiontext);
                cell33.Width = 200;
                cell33.Height = 50;
                cell33.BorderWidth = 1;
                cell33.BorderStyle = BorderStyle.Solid;
                row7.Cells.Add(cell33);

                Table1.Rows.Add(row7);

                TimeSeriesResources tm = new TimeSeriesResources();
                DataTable dt = new DataTable();
                dt = tm.GetTimeSeriesInfo(gridrow.Cells[2].Text);
                foreach (DataRow dtrow in dt.Rows)
                {
                    sitecodetext.Text= dtrow["sitecode"].ToString();
                    sitenametext.Text= dtrow["sitename"].ToString();
                    variablecodetext.Text= dtrow["variablecode"].ToString();
                    variablenametext.Text= dtrow["speciation"].ToString();
                    speciationtext.Text= dtrow["variablecode"].ToString();
                    variableunitsnametext.Text= dtrow["variableunitsname"].ToString();
                    samplemediumtext.Text= dtrow["samplemedium"].ToString();
                    valuetypetext.Text= dtrow["valuetype"].ToString();
                    timesupportext.Text= dtrow["timesupport"].ToString();
                    timeunitsidtext.Text= dtrow["timeunitsid"].ToString();
                    timeunitsnametext.Text= dtrow["timeunitsname"].ToString();
                    datatypetext.Text= dtrow["datatype"].ToString();
                    generalcategorytext.Text= dtrow["generalcategory"].ToString();
                    methoddescriptiontext.Text= dtrow["methoddescription"].ToString();
                    organizationtext.Text= dtrow["organization"].ToString();
                    sourcedescriptiontext.Text = dtrow["sourcedescription"].ToString();

                }

                Table1.BorderColor = System.Drawing.Color.Black;
                Table1.BorderStyle = BorderStyle.Solid;
                Table1.BorderWidth = 1;
            }
        }

        protected void odmInfoGridView_PreRender(object sender, EventArgs e)
        {
             odmInfoGridView.Style["border-collapse"] = "seperate";
        }

        private void GridTableLoad()
        {
            foreach(GridViewRow gridrow in odmInfoGridView.Rows)
            {
                Table Table1 = (Table)gridrow.FindControl("TimeSeriesInfoTable");
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
}
