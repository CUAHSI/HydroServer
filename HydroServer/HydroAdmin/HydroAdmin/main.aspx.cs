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
            odmInfoGridView.Width = 1000;
            if (!IsPostBack)
            {
                siteCodeDropDownList.Enabled = false;
                variableCodeDropDownList.Enabled = false;
                
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
            if (odmList.Items.Count > 0)
            {

                odmList.SelectedValue = odmList.Items[odmList.Items.Count - 1].ToString();
            }

            siteCodeDropDownList.Items.Clear();
            variableCodeDropDownList.Items.Clear();

            ODM odmInfo = new ODM();
            DataTable dt = new DataTable();
            if (odmList.Items.Count > 0)
            {
                dt = odmInfo.GetODMInfo(odmList.Items[odmList.Items.Count - 1].ToString());
            }
            foreach (DataRow row in dt.Rows)
            {
                Title.Text = row["title"].ToString();
                serverName.Text = row["serveraddress"].ToString();
                Topic.Text = row["topiccategory"].ToString();
                abstractODM.Text = row["abstract"].ToString();
                citation.Text = row["citation"].ToString();
            }
            TimeSeriesResources tmResObj = new TimeSeriesResources();
            if (odmList.Items.Count > 0)
            {
                timeSeriesTable = tmResObj.GetTimeSeriesResources(odmList.Items[odmList.Items.Count - 1].ToString());
            }
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
            ViewState["mydata"] = timeSeriesTable;
            //recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";

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
            //recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";

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
            TimeSeriesResources tmResObj = new TimeSeriesResources();
            if (odmList.Items.Count > 0)
            {
                timeSeriesTable = tmResObj.GetTimeSeriesResources(odmList.Items[odmList.Items.Count - 1].ToString());
            }




            //timeSeriesTable = (DataTable)ViewState["mydata"];
            DataTable dt = new DataTable();
            dt = timeSeriesTable;
            //ViewState["mydata"] = dt;
            for (int i = 0; i < timeSeriesTable.Rows.Count; i++)
            {
                DataRow row = timeSeriesTable.Rows[i];
                string sel = row["sitecode"].ToString();
                if (!sel.Equals(siteCodeDropDownList.SelectedValue.ToString()))
                {
                    timeSeriesTable.Rows[i].Delete();
                }
            }
            timeSeriesTable.AcceptChanges();
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
            ViewState["mydata"] = timeSeriesTable;
            //timeSeriesTable.RejectChanges();
            List<string> variableCodeListObj = new List<string>();
            foreach (DataRow row in timeSeriesTable.Rows)
            {
                variableCodeListObj.Add(row["variablecode"].ToString());
            }
            variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            variableCodeDropDownList.DataBind();


            //timeSeriesTable = (DataTable)ViewState["mydata"];
            //ViewState["mydata"] = null;
            //DataTable dt = timeSeriesTable;
            //for(int i=0; i < timeSeriesTable.Rows.Count ; i++)
            //{
            //    DataRow row = timeSeriesTable.Rows[i];
            //    string sel = row["sitecode"].ToString();
            //    if ( !sel.Equals(siteCodeDropDownList.SelectedValue.ToString()))
            //    {
            //        timeSeriesTable.Rows[i].Delete();
            //    }
            //}
            //timeSeriesTable.AcceptChanges();
            //odmInfoGridView.DataSource = timeSeriesTable;
            //odmInfoGridView.DataBind();
            //ViewState["mydata"] = timeSeriesTable;

            //List<string> siteCodeListObj = new List<string>();
            //List<string> variableCodeListObj = new List<string>();
            //foreach (DataRow row in dt.Rows)
            //{
            //    siteCodeListObj.Add(row["sitecode"].ToString());
            //    variableCodeListObj.Add(row["variablecode"].ToString());
            //}

            //siteCodeDropDownList.DataSource = siteCodeListObj.Distinct().ToList();
            //siteCodeDropDownList.DataBind();
            //variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            //variableCodeDropDownList.DataBind();
            //recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";
            
        }

        protected void variableCodeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            timeSeriesTable = (DataTable)ViewState["mydata"];
            DataTable dt = new DataTable();
            dt = timeSeriesTable;
            ViewState["mydata"] = dt;
            for (int i = 0; i < timeSeriesTable.Rows.Count; i++)
            {
                DataRow row = timeSeriesTable.Rows[i];
                string sel = row["variablecode"].ToString();
                if (!sel.Equals(variableCodeDropDownList.SelectedValue.ToString()))
                {
                    timeSeriesTable.Rows[i].Delete();
                }
            }
            //timeSeriesTable.AcceptChanges();
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
            timeSeriesTable.RejectChanges();
           
            //timeSeriesTable = (DataTable)ViewState["mydata"];
            //ViewState["mydata"] = null;
            //DataTable dt = timeSeriesTable;
            //for (int i = 0; i < timeSeriesTable.Rows.Count; i++)
            //{
            //    DataRow row = timeSeriesTable.Rows[i];
            //    string sel = row["variablecode"].ToString();
            //    if (!sel.Equals(variableCodeDropDownList.SelectedValue.ToString()))
            //    {
            //        timeSeriesTable.Rows[i].Delete();
            //    }
            //}
            //timeSeriesTable.AcceptChanges();
            //odmInfoGridView.DataSource = timeSeriesTable;
            //odmInfoGridView.DataBind();
            //ViewState["mydata"] = timeSeriesTable;

            //List<string> siteCodeListObj = new List<string>();
            //List<string> variableCodeListObj = new List<string>();
            //foreach (DataRow row in dt.Rows)
            //{
            //    siteCodeListObj.Add(row["sitecode"].ToString());
            //    variableCodeListObj.Add(row["variablecode"].ToString());
            //}

            //siteCodeDropDownList.DataSource = siteCodeListObj.Distinct().ToList();
            //siteCodeDropDownList.DataBind();
            //variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            //variableCodeDropDownList.DataBind();
            //recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";
        }

        protected void resetOdmInfoButton_Click(object sender, EventArgs e)
        {
            timeSeriesTable = (DataTable)ViewState["mydata"];
            DataTable dt = new DataTable();
            dt = timeSeriesTable;
            ViewState["mydata"] = dt;
            odmInfoGridView.DataSource = dt;
            odmInfoGridView.DataBind();
            timeSeriesTable.RejectChanges();

            //siteCodeDropDownList.Items.Clear();
            //variableCodeDropDownList.Items.Clear();

            //ODM odmInfo = new ODM();
            //DataTable dt = new DataTable();
            //dt = odmInfo.GetODMInfo(odmList.SelectedValue.ToString());
            //foreach (DataRow row in dt.Rows)
            //{
            //    Title.Text = row["title"].ToString();
            //    serverName.Text = row["serveraddress"].ToString();
            //    Topic.Text = row["topiccategory"].ToString();
            //    abstractODM.Text = row["abstract"].ToString();
            //    citation.Text = row["citation"].ToString();
            //}
            //TimeSeriesResources tmResObj = new TimeSeriesResources();
            //timeSeriesTable = tmResObj.GetTimeSeriesResources(odmList.SelectedValue.ToString());
            //odmInfoGridView.DataSource = timeSeriesTable;
            //odmInfoGridView.DataBind();
            //ViewState["mydata"] = timeSeriesTable;
            ////recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";

            //List<string> siteCodeListObj = new List<string>();
            //List<string> variableCodeListObj = new List<string>();
            //foreach (DataRow row in timeSeriesTable.Rows)
            //{
            //    siteCodeListObj.Add(row["sitecode"].ToString());
            //    variableCodeListObj.Add(row["variablecode"].ToString());
            //}

            //siteCodeDropDownList.DataSource = siteCodeListObj.Distinct().ToList();
            //siteCodeDropDownList.DataBind();
            //variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            //variableCodeDropDownList.DataBind();


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
            for (int i = 12; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Visible = false;
            }
            e.Row.Cells[0].Width = 10;
            e.Row.Cells[1].Width = 100;
            e.Row.Cells[2].Width = 70;
            e.Row.Cells[3].Width = 30;
            e.Row.Cells[4].Width = 30;
            e.Row.Cells[5].Width = 30;
            e.Row.Cells[6].Width = 30;
            e.Row.Cells[7].Width = 150;
            e.Row.Cells[8].Width = 30;
            e.Row.Cells[9].Width = 150;
            e.Row.Cells[10].Width = 30;
            e.Row.Cells[11].Width = 30;
            //e.Row.Cells[6].Width = 300;
            //e.Row.Cells[21].Width = 300;
            //e.Row.Cells[23].Width = 300;
            //e.Row.Cells[24].Width = 450;
            //e.Row.Cells[25].Width = 450;

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
                odmLink.Attributes.Add("onclick", "window.open('TimeSeriesInformation.aspx?tm=" + gridrow.Cells[12].Text + "',null,'height=600, width=500,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no');");
                Table sitecodeTable = (Table)gridrow.FindControl("sitecodetable");
                TableRow sitecodeRow = new TableRow();
                TableCell sitecodeCell = new TableCell();
                Table variablecodeTable = (Table)gridrow.FindControl("variablecodetable");
                TableRow variablecodeRow = new TableRow();
                TableCell variablecodeCell = new TableCell();
                Table generalcategoryTable = (Table)gridrow.FindControl("generalcategorytable");
                TableRow generalcategoryRow = new TableRow();
                TableCell generalcategoryCell = new TableCell();
                Table valuetypeTable = (Table)gridrow.FindControl("valuetypetable");
                TableRow valuetypeRow = new TableRow();
                TableCell valuetypeCell = new TableCell();
                Table samplemediumTable = (Table)gridrow.FindControl("samplemediumtable");
                TableRow samplemediumRow = new TableRow();
                TableCell samplemediumCell = new TableCell();
                Table qclevelTable = (Table)gridrow.FindControl("qcleveltable");
                TableRow qclevelRow = new TableRow();
                TableCell qclevelCell = new TableCell();
                Table methoddescriptionTable = (Table)gridrow.FindControl("methoddescriptiontable");
                TableRow methoddescriptionRow = new TableRow();
                TableCell methoddescriptionCell = new TableCell();
                Table organizationTable = (Table)gridrow.FindControl("organizationtable");
                TableRow organizationRow = new TableRow();
                TableCell organizationCell = new TableCell();
                Table sourcedescriptionTable = (Table)gridrow.FindControl("sourcedescriptiontable");
                TableRow sourcedescriptionRow = new TableRow();
                TableCell sourcedescriptionCell = new TableCell();
                Table datetimerangeTable = (Table)gridrow.FindControl("datetimerangetable");
                TableRow datetimerangeRow = new TableRow();
                TableCell datetimerangeCell = new TableCell();
                Table obervationsTable = (Table)gridrow.FindControl("observationstable");
                TableRow obervationsRow = new TableRow();
                TableCell obervationsCell = new TableCell(); 



                TimeSeriesResources tmObj = new TimeSeriesResources();
                DataTable dt = new DataTable();
                dt = tmObj.GetTimeSeriesInfo(gridrow.Cells[12].Text);
                foreach(DataRow row in dt.Rows)
                {
                    sitecodeCell.Text = row["sitecode"].ToString()+Environment.NewLine+row["sitename"].ToString();
                    variablecodeCell.Text = row["variablecode"].ToString() + " : " + row["variablename"].ToString();
                    generalcategoryCell.Text = row["generalcategory"].ToString();
                    valuetypeCell.Text = row["valuetype"].ToString();
                    samplemediumCell.Text = row["samplemedium"].ToString();
                    qclevelCell.Text = row["qualitycontrollevelcode"].ToString();
                    methoddescriptionCell.Text = row["methoddescription"].ToString();
                    organizationCell.Text = row["organization"].ToString();
                    sourcedescriptionCell.Text = row["sourcedescription"].ToString();
                    datetimerangeCell.Text = row["datecreated"].ToString();
                    obervationsCell.Text = row["valuecount"].ToString();
                }
                sitecodeRow.Cells.Add(sitecodeCell);
                sitecodeTable.Rows.Add(sitecodeRow);
                variablecodeRow.Cells.Add(variablecodeCell);
                variablecodeTable.Rows.Add(variablecodeRow);
                generalcategoryRow.Cells.Add(generalcategoryCell);
                generalcategoryTable.Rows.Add(generalcategoryRow);
                valuetypeRow.Cells.Add(valuetypeCell);
                valuetypeTable.Rows.Add(valuetypeRow);
                samplemediumRow.Cells.Add(samplemediumCell);
                samplemediumTable.Rows.Add(samplemediumRow);
                qclevelRow.Cells.Add(qclevelCell);
                qclevelTable.Rows.Add(qclevelRow);
                methoddescriptionRow.Cells.Add(methoddescriptionCell);
                methoddescriptionTable.Rows.Add(methoddescriptionRow);
                organizationRow.Cells.Add(organizationCell);
                organizationTable.Rows.Add(organizationRow);
                sourcedescriptionRow.Cells.Add(sourcedescriptionCell);
                sourcedescriptionTable.Rows.Add(sourcedescriptionRow);
                datetimerangeRow.Cells.Add(datetimerangeCell);
                datetimerangeTable.Rows.Add(datetimerangeRow);
                valuetypeRow.Cells.Add(valuetypeCell);
                valuetypeTable.Rows.Add(valuetypeRow);
                obervationsRow.Cells.Add(obervationsCell);
                obervationsTable.Rows.Add(obervationsRow);
                
            }
        }

        protected void odmInfoGridView_PreRender(object sender, EventArgs e)
        {
             odmInfoGridView.Style["border-collapse"] = "seperate";
        }

        protected void odmInfoGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //GridViewRow row = e.Row;
            //// Intitialize TableCell list
            //List<TableCell> cells = new List<TableCell>();

            //foreach (DataControlField column in odmInfoGridView.Columns)
            //{
            //    // Retrieve first cell
            //    TableCell cell = row.Cells[0];

            //    // Remove cell
            //    row.Cells.Remove(cell);

            //    // Add cell to list
            //    cells.Add(cell);
            //}

            //// Add cells
            //row.Cells.AddRange(cells.ToArray());
        }

        protected void enableFiltersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableFiltersCheckBox.Checked)
            {
                siteCodeDropDownList.Enabled = true;
                //variableCodeDropDownList.Enabled = true;
               
                timeSeriesTable = (DataTable)ViewState["mydata"];
                odmInfoGridView.DataSource = timeSeriesTable;
                odmInfoGridView.DataBind();
            }
            else
            {
                siteCodeDropDownList.Enabled = false;
                variableCodeDropDownList.Enabled = false;
                enableVariableCodeFilter.Checked = false;
              
                TimeSeriesResources tmResObj = new TimeSeriesResources();
                if (odmList.Items.Count > 0)
                {
                    timeSeriesTable = tmResObj.GetTimeSeriesResources(odmList.Items[odmList.Items.Count - 1].ToString());
                }
                odmInfoGridView.DataSource = timeSeriesTable;
                odmInfoGridView.DataBind();
            }

            
        }

        protected void enableVariableCodeFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (enableVariableCodeFilter.Checked)
            {
                variableCodeDropDownList.Enabled = true;
            }
            else
            {
                variableCodeDropDownList.Enabled = false;
            }

            timeSeriesTable = (DataTable)ViewState["mydata"];
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
        }

        
        
    }
}
